using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace _272HW3.Controllers
{
public class FileController : Controller 
{

            public ActionResult Index()
            {


                string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/uploads/"));


                List<FileModel> files = new List<FileModel>();

                foreach (string filePath in filePaths)
                {
                    files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
                }
                return View(files);
            }

            public FileResult DownloadFile(string fileName) 
            {

                string path = Server.MapPath("~/App_Data/uploads/") + fileName;

                byte[] bytes = System.IO.File.ReadAllBytes(path);

                return File(bytes, "application/octet-stream", fileName);
            }

            public ActionResult DeleteFile(string fileName)
            {
                string path = Server.MapPath("~/App_Data/uploads/") + fileName;
                byte[] bytes = System.IO.File.ReadAllBytes(path);

                System.IO.File.Delete(path);

                return RedirectToAction("Index");
            }
        }
    }
}
}

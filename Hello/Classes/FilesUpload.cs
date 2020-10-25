using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Hello.Classes
{
    public class FilesUpload
    {
        public static string UploadPhoto(HttpPostedFileBase file, string folder)
        {
            string path = string.Empty;
            string pic = string.Empty;

            if (file != null)
            {
                pic = Path.GetFileName(file.FileName);
                path = Path.Combine(HttpContext.Current.Server.MapPath(folder), pic);
                file.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    ms.Close();
                }

            }

            return pic;
        }

        public static string UploadPhotos(Remessa arq, string folder)
        {
            string path = string.Empty;
            string pic = string.Empty;
            foreach (HttpPostedFileBase arquivo in arq.Arquivos)
            {
                if (arquivo.ContentLength > 0)
                {
                    pic = Path.GetFileName(arquivo.FileName);
                    path = Path.Combine(HttpContext.Current.Server.MapPath(folder), pic);
                    arquivo.SaveAs(path);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        arquivo.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }
                }
            }
            return pic;

        }

        public class Remessa
        {
            public IEnumerable<HttpPostedFileBase> Arquivos { get; set; }
        }

    }
}
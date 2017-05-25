using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SharedProject
{
    public class MySharedCode
    {
        public string GetFilePath(string fileName)
        {
#if WINDOWS_UWP
            var filePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, fileName);
#else
#if __ANDROID__
            var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(libraryPath, fileName);
#endif
#endif
            return filePath;
        }
    }
}

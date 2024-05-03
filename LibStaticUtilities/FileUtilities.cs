using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolTester.Utilities
{
    public static class FileUtilities
    {
        public static string GetLoadFilePath(string fileName = "", string filter = "All Files|*.*", string title = "Select a file.")
        {
            Microsoft.Win32.OpenFileDialog diag = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = filter,
                Title = title,
                FileName = fileName
            };

            if (diag.ShowDialog() == true)
                return diag.FileName;
            else
                return "";

        }
        public static string GetSaveFilePath(string fileName = "", string filter = "All Files|*.*", string title = "Save a file.")
        {
            Microsoft.Win32.SaveFileDialog diag = new Microsoft.Win32.SaveFileDialog
            {
                Filter = filter,
                Title = title,
                FileName = fileName
            };

            if (diag.ShowDialog() == true)
                return diag.FileName;
            else
                return "";
        }

    }
}

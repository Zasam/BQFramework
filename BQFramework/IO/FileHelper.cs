using System;
using System.IO;
using System.Reflection;

namespace BQFramework.IO
{
    public static class FileHelper
    {
        /// <summary>
        /// Read text from a file within the specified assembly
        /// </summary>
        /// <param name="filename">The name of the file to read text from</param>
        /// <param name="assembly">Use typeof(classInAssembly).GetTypeInfo().Assembly to determine the current assembly where the textfile is located</param>
        /// <returns>The text from the specified file</returns>
        public static string GetTextFromFile(string filename, Assembly assembly)
        {
            try
            {
                var stream = assembly.GetManifestResourceStream(filename);
                var text = string.Empty;

                if (stream != null)
                {
                    using var reader = new StreamReader(stream);
                    text = reader.ReadToEnd();
                }

                return text;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
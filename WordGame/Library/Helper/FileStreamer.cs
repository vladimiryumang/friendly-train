using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Helper
{
    public class FileStreamer
    {

        public string Directory { get; set; }
        public string FileName { get; set; }

        public FileStreamer(string directory, string fileName)
        {
            Directory = directory;
            FileName = fileName;
        }

        public IEnumerable<string> ReadByLine()
        {
            IEnumerable<string> retVal = null;
            try
            {
                retVal = File.ReadLines($"{Directory}/{FileName}");
            }
            catch (FileNotFoundException)
            {
                FileNotFoundExceptionMessage();
            }
            catch (DirectoryNotFoundException)
            {
                DirectoryNotFoundExceptionMessage();
            }
            catch (DriveNotFoundException)
            {
                DriveNotFoundExceptionMessage();
            }
            catch (PathTooLongException)
            {
                PathTooLongExceptionMessage();
            }
            catch (UnauthorizedAccessException)
            {
                UnauthorizedAccessExceptionMessage();
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                IOExceptionSharingExceptionMessage();
            }
            catch (IOException e)
            {
                IOExceptionMessage(e);
            }
            return retVal;
        }

        public string ReadAllText()
        {
            string retVal = "";
            try
            {
                retVal = File.ReadAllText($"{Directory}/{FileName}");
            }
            catch (FileNotFoundException)
            {
                FileNotFoundExceptionMessage();
            }
            catch (DirectoryNotFoundException)
            {
                DirectoryNotFoundExceptionMessage();
            }
            catch (DriveNotFoundException)
            {
                DriveNotFoundExceptionMessage();
            }
            catch (PathTooLongException)
            {
                PathTooLongExceptionMessage();
            }
            catch (UnauthorizedAccessException)
            {
                UnauthorizedAccessExceptionMessage();
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                IOExceptionSharingExceptionMessage();
            }
            catch (IOException e)
            {
                IOExceptionMessage(e);
            }
            return retVal;
        }


        private void FileNotFoundExceptionMessage()
        {
            Console.WriteLine("The file or directory cannot be found.");
        }

        private void DirectoryNotFoundExceptionMessage()
        {
            Console.WriteLine("The file or directory cannot be found.");
        }

        private void DriveNotFoundExceptionMessage()
        {
            Console.WriteLine("The drive specified in 'path' is invalid.");
        }

        private void PathTooLongExceptionMessage()
        {
            Console.WriteLine("The drive specified in 'path' is invalid.");
        }

        private void UnauthorizedAccessExceptionMessage()
        {
            Console.WriteLine("You do not have permission to create this file.");
        }

        private void IOExceptionSharingExceptionMessage()
        {
            Console.WriteLine("There is a sharing violation.");
        }

        private void IOExceptionMessage(IOException e)
        {
            Console.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
        }
    }

}
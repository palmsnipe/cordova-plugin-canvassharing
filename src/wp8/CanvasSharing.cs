using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Media.PhoneExtensions;
using System;
using System.IO;
using System.Text;
using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;
using Microsoft.Phone.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;
/*
using Windows.ApplicationModel.Email.EmailMessage;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.ApplicationModel.Email;
using System.Windows.Threading;
*/

namespace Cordova.Extension.Commands
{

    public class CanvasSharing : BaseCommand
    {
        private StorageFile storageFile;
        
        public CanvasSharing()
        {
        }
    
        public void saveImageDataToLibrary(string jsonArgs)
        {
            try
            {
                var options = JsonHelper.Deserialize<string[]>(jsonArgs);
    
                string imageData = options[0];
                byte[] imageBytes = Convert.FromBase64String(imageData);
    
                using (var imageStream = new MemoryStream(imageBytes))
                {
                    imageStream.Seek(0, SeekOrigin.Begin);
    
                    string fileName = String.Format("kortti_{0:yyyyMMdd_HHmmss}", DateTime.Now);
                    var library = new MediaLibrary();
                    var picture = library.SavePicture(fileName, imageStream);
    
                    if (picture.Name.Contains(fileName))
                    {
                        DispatchCommandResult(new PluginResult(PluginResult.Status.OK, picture.GetPath()));
                    }
                    else
                    {
                        DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, 
                            "Failed to save image: " + picture.Name));
                    }
                }
            }
            catch (Exception ex)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, ex.Message));
            }
        }
    
        public void sharePicture(string jsonArgs)
        {
            try
            {
                var options = JsonHelper.Deserialize<string[]>(jsonArgs);
    
                string path = options[0];
                Microsoft.Phone.Tasks.ShareMediaTask smt = new ShareMediaTask();
                smt.FilePath = path; 
                smt.Show();
                
                DispatchCommandResult(new PluginResult(PluginResult.Status.OK, path));
            }
            catch (Exception ex)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, ex.Message));
            }
        }
    
        public void appVersion(string jsonArgs)
        {
            try
            {
                string version = XDocument.Load("WMAppManifest.xml").Root.Element("App").Attribute("Version").Value;
    
                DispatchCommandResult(new PluginResult(PluginResult.Status.OK, version));
            }
            catch (Exception ex)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, ex.Message));
            }
        }
        
        /*
        private async void ComposeEmail(String subject, String messageBody, StorageFile fl)
        {
            var msg = new EmailMessage();
            msg.Subject = subject;
            msg.Body = messageBody;
            msg.To.Add(new EmailRecipient("contact@123kidsfun.com"));
    
            String attachmentFile = fl.Name;
    
            if (fl != null && attachmentFile != "")
            {
                try
                {
                    var rastream = RandomAccessStreamReference.CreateFromFile(fl);
                    var attachment = new EmailAttachment(attachmentFile, rastream);
                    msg.Attachments.Add(attachment);
                }
                catch (Exception e)
                {
                    //  Debug.WriteLine("[C#] attachment exception: " + e.Message);
                }
            }
    
            
            try
            {
                await EmailManager.ShowComposeNewEmailAsync(msg);
            }
            catch (Exception e)
            {
                //  Debug.WriteLine("[C#] email manager exception: " + e.Message);
            }
        }
    
        private async void CreateEmail(String subject, String body, String path)
        {
            storageFile = await StorageFile.GetFileFromPathAsync(path);
            ComposeEmail(subject, body, storageFile);
        }
        */
    
        public void sendEmail(string jsonArgs)
        {
            /*
            try
            {
                var options = JsonHelper.Deserialize<string[]>(jsonArgs);
    
                string title = options[0];
                string description = options[1];
                string path = options[2];
                
                Dispatcher.BeginInvoke(() =>
                {
                    CreateEmail(title, description, path);
                });
                CreateEmail(title, description, path);
                //  Microsoft.Phone.Tasks.ShareMediaTask smt = new ShareMediaTask();
                //  smt.FilePath = path; 
                //  smt.Show();
                
                // Send an Email with attachment
                EmailMessage email = new EmailMessage();
                //  email.To.Add(new EmailRecipient("test@developerpublish.com"));
                email.Subject = title;
                email.Body = description;
                
                StorageFile fl = StorageFile.GetFileFromPathAsync(path);
                String attachmentFile = fl.Name;

                if (fl != null && attachmentFile != "")
                {
                    try
                    {
                        var rastream = RandomAccessStreamReference.CreateFromFile(fl);
                        var attachment = new EmailAttachment(attachmentFile, rastream);
                        msg.Attachments.Add(attachment);
                    }
                    catch (Exception e)
                    {
                        //  Debug.WriteLine("[C#] attachment exception: " + e.Message);
                    }
                }
                
                //  var file = await GetTextFile();
                //  email.Attachments.Add(new EmailAttachment(file.Name, file));
                await EmailManager.ShowComposeNewEmailAsync(email);

                
                DispatchCommandResult(new PluginResult(PluginResult.Status.OK, path));
            }
            catch (Exception ex)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR, ex.Message));
            }
            */
        }
        
    }

}
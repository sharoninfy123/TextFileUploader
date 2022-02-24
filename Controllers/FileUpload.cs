using Azure.Storage.Blobs;
using MyFileUploader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyFileUploader.Controllers
{
    public class FileUpload : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost("FileUpload")]

        public async Task<IActionResult> Index(IFormFile files)
        {
            string message = null;
            if (files == null || files.Length == 0)
            {
                ViewBag.message = "Please upload a valid text file";
            }

            else
            {
                string connectionstring = "DefaultEndpointsProtocol=https;AccountName=blobstoragecreation;AccountKey=QkKpmpkOPFfR5h4Ex9fisMuX6Lh90COS09icNDCJEIWXM2e/ALDly0zIY4RDI7/3r/ASR60asqZi+ASttlbiNQ==;EndpointSuffix=core.windows.net";
                string blobContainerName = "rootcontainer";
                BlobClient blobClient = new BlobClient(connectionString: connectionstring, blobContainerName: blobContainerName, blobName: files.FileName);
                try
                {
                    var result = await blobClient.UploadAsync(files.OpenReadStream());
                    ViewBag.message ="File successfully uploaded to blob storage";
                }
                catch (Exception)
                {
                    ViewBag.message = "Upload Failed, please try again later!";
                }

                //TempData["message"] = message;
            }
            return View();

        }
    }
}

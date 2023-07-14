using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAspCrudBackend.Models;
using ReactAspCRUDBackend.Models;

namespace ReactAspCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDbContext.Student.ToListAsync();
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<Student> AddStudent(Student objStudent)
        {
            _studentDbContext.Student.Add(objStudent);
            await _studentDbContext.SaveChangesAsync();
            return objStudent;
        }

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<Student> UpdateStudent(Student objStudent)
        {
            _studentDbContext.Entry(objStudent).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objStudent;
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public bool DeleteStudent(int id)
        {
            bool a = false;
            var student = _studentDbContext.Student.Find(id);
            if (student != null)
            {
                a = true;
                _studentDbContext.Entry(student).State = EntityState.Deleted;
                _studentDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;

        }

    }

 //My code
    [Route("api/image")]
    [ApiController]
    public class ImageApiController : ControllerBase
    {
        private const string StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=studentstorage3e4;AccountKey=knYsohauq/EySXacbR1AYzu+qiUv5S8RY7jRQogqELEwAPk9379VTD64mk/ZWI3letWC4HPMC5pj+AStRHn+7A==;EndpointSuffix=core.windows.net";
        private const string ContainerName = "images";

        [HttpPost("upload")]
        public async Task<IActionResult> Upload()
        {
            IFormFile file = Request.Form.Files[0];

            if (file != null && file.Length > 0)
            {
                // Retrieve the filename and file extension
                string fileName = Path.GetFileName(file.FileName);
                string fileExtension = Path.GetExtension(fileName);

                // Generate a unique name for the blob using a GUID
                string blobName = $"{Guid.NewGuid()}{fileExtension}";

                // Create a BlobServiceClient object using the storage connection string
                BlobServiceClient blobServiceClient = new BlobServiceClient(StorageConnectionString);

                // Get a reference to the container
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

                // Get a reference to the blob
                BlobClient blobClient = containerClient.GetBlobClient(blobName);

                // Upload the file to the blob
                using (Stream stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream);
                }

                // Optionally, you can set the cache control header for the blob
                await blobClient.SetHttpHeadersAsync(new BlobHttpHeaders { CacheControl = "public, max-age=3600" });

                // Return the URL of the uploaded image
                return Ok(blobClient.Uri.AbsoluteUri);
            }

            return BadRequest("No file selected.");
        }

        [HttpGet("download/{blobName}")]
        public IActionResult Download(string blobName)
        {
            // Create a BlobServiceClient object using the storage connection string
            BlobServiceClient blobServiceClient = new BlobServiceClient(StorageConnectionString);

            // Get a reference to the container
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

            // Get a reference to the blob
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            // Download the blob as a byte array
            BlobDownloadInfo downloadInfo = blobClient.Download();

            // Return the image file to the client
            return File(downloadInfo.Content, downloadInfo.ContentType, blobName);
        }
    }



    //My code
    [Route("api/image")]
    [ApiController]
    public class ImageApiController : ControllerBase
    {
        private const string StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=studentstorage3e4;AccountKey=knYsohauq/EySXacbR1AYzu+qiUv5S8RY7jRQogqELEwAPk9379VTD64mk/ZWI3letWC4HPMC5pj+AStRHn+7A==;EndpointSuffix=core.windows.net";
        private const string ContainerName = "images";

        [HttpPost("upload")]
        public async Task<IActionResult> Upload()
        {
            IFormFile file = Request.Form.Files[0];

            if (file != null && file.Length > 0)
            {
                // Retrieve the filename and file extension
                string fileName = Path.GetFileName(file.FileName);
                string fileExtension = Path.GetExtension(fileName);

                // Generate a unique name for the blob using a GUID
                string blobName = $"{Guid.NewGuid()}{fileExtension}";

                // Create a BlobServiceClient object using the storage connection string
                BlobServiceClient blobServiceClient = new BlobServiceClient(StorageConnectionString);

                // Get a reference to the container
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

                // Get a reference to the blob
                BlobClient blobClient = containerClient.GetBlobClient(blobName);

                // Upload the file to the blob
                using (Stream stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream);
                }

                // Optionally, you can set the cache control header for the blob
                await blobClient.SetHttpHeadersAsync(new BlobHttpHeaders { CacheControl = "public, max-age=3600" });

                // Return the URL of the uploaded image
                return Ok(blobClient.Uri.AbsoluteUri);
            }

            return BadRequest("No file selected.");
        }

        [HttpGet("download/{blobName}")]
        public IActionResult Download(string blobName)
        {
            // Create a BlobServiceClient object using the storage connection string
            BlobServiceClient blobServiceClient = new BlobServiceClient(StorageConnectionString);

            // Get a reference to the container
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

            // Get a reference to the blob
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            // Download the blob as a byte array
            BlobDownloadInfo downloadInfo = blobClient.Download();

            // Return the image file to the client
            return File(downloadInfo.Content, downloadInfo.ContentType, blobName);
        }
    }



    //My code

    

}
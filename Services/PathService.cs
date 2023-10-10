using myFruits.Options;

namespace myFruits.Services;

public class PathService
{
    private readonly IConfiguration configuration;
    private readonly IWebHostEnvironment env;

    public PathService(IConfiguration configuration, IWebHostEnvironment env)
    {
        this.configuration = configuration;
        this.env = env;
    }

    public string GetUploadPath(string filename = null, bool withWebRootPath = true)
    {
        var pathOptions = new PathOptions();

        configuration.GetSection(PathOptions.Path).Bind(pathOptions);

        var uploadPath = pathOptions.FruitsImages;

        if(null != filename)
            uploadPath = Path.Combine(uploadPath, filename);

        return withWebRootPath ? Path.Combine(env.WebRootPath, uploadPath) : uploadPath;
    }
}

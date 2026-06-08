using System;
using System.Globalization;
using System.IO;

namespace Castle.Core.Resource
{
	public class FileResource : AbstractStreamResource
	{
		private string filePath;

		private string basePath;

		public override string FileBasePath => basePath;

		public FileResource(CustomUri resource)
		{
			FileResource fileResource = this;
			base.CreateStream = () => fileResource.CreateStreamFromUri(resource, AbstractResource.DefaultBasePath);
		}

		public FileResource(CustomUri resource, string basePath)
		{
			FileResource fileResource = this;
			base.CreateStream = () => fileResource.CreateStreamFromUri(resource, basePath);
		}

		public FileResource(string resourceName)
		{
			FileResource fileResource = this;
			base.CreateStream = () => fileResource.CreateStreamFromPath(resourceName, AbstractResource.DefaultBasePath);
		}

		public FileResource(string resourceName, string basePath)
		{
			FileResource fileResource = this;
			base.CreateStream = () => fileResource.CreateStreamFromPath(resourceName, basePath);
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "FileResource: [{0}] [{1}]", new object[2] { filePath, basePath });
		}

		public override IResource CreateRelative(string relativePath)
		{
			return new FileResource(relativePath, basePath);
		}

		private Stream CreateStreamFromUri(CustomUri resource, string rootPath)
		{
			if (resource == null)
			{
				throw new ArgumentNullException("resource");
			}
			if (rootPath == null)
			{
				throw new ArgumentNullException("rootPath");
			}
			if (!resource.IsFile)
			{
				throw new ArgumentException("The specified resource is not a file", "resource");
			}
			return CreateStreamFromPath(resource.Path, rootPath);
		}

		private Stream CreateStreamFromPath(string resourcePath, string rootPath)
		{
			if (resourcePath == null)
			{
				throw new ArgumentNullException("resourcePath");
			}
			if (rootPath == null)
			{
				throw new ArgumentNullException("rootPath");
			}
			if (!Path.IsPathRooted(resourcePath) || !File.Exists(resourcePath))
			{
				resourcePath = Path.Combine(rootPath, resourcePath);
			}
			CheckFileExists(resourcePath);
			filePath = Path.GetFileName(resourcePath);
			basePath = Path.GetDirectoryName(resourcePath);
			return File.OpenRead(resourcePath);
		}

		private static void CheckFileExists(string path)
		{
			if (!File.Exists(path))
			{
				throw new ResourceException(string.Format(CultureInfo.InvariantCulture, "File {0} could not be found", new object[1] { new FileInfo(path).FullName }));
			}
		}
	}
}

using System;
using System.Globalization;
using System.IO;

namespace Castle.Core.Resource
{
	public class UncResource : AbstractStreamResource
	{
		private string basePath;

		private string filePath;

		public override string FileBasePath => basePath;

		public UncResource(CustomUri resource)
		{
			UncResource uncResource = this;
			base.CreateStream = () => uncResource.CreateStreamFromUri(resource, AbstractResource.DefaultBasePath);
		}

		public UncResource(CustomUri resource, string basePath)
		{
			UncResource uncResource = this;
			base.CreateStream = () => uncResource.CreateStreamFromUri(resource, basePath);
		}

		public UncResource(string resourceName)
			: this(new CustomUri(resourceName))
		{
		}

		public UncResource(string resourceName, string basePath)
			: this(new CustomUri(resourceName), basePath)
		{
		}

		public override IResource CreateRelative(string relativePath)
		{
			return new UncResource(Path.Combine(basePath, relativePath));
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "UncResource: [{0}] [{1}]", new object[2] { filePath, basePath });
		}

		private Stream CreateStreamFromUri(CustomUri resource, string rootPath)
		{
			if (resource == null)
			{
				throw new ArgumentNullException("resource");
			}
			if (!resource.IsUnc)
			{
				throw new ArgumentException("Resource must be an Unc", "resource");
			}
			if (!resource.IsFile)
			{
				throw new ArgumentException("The specified resource is not a file", "resource");
			}
			string text = resource.Path;
			if (!File.Exists(text) && rootPath != null)
			{
				text = Path.Combine(rootPath, text);
			}
			filePath = Path.GetFileName(text);
			basePath = Path.GetDirectoryName(text);
			CheckFileExists(text);
			return File.OpenRead(text);
		}

		private static void CheckFileExists(string path)
		{
			if (!File.Exists(path))
			{
				throw new ResourceException(string.Format(CultureInfo.InvariantCulture, "File {0} could not be found", new object[1] { path }));
			}
		}
	}
}

using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Castle.Core.Resource
{
	public class AssemblyResource : AbstractStreamResource
	{
		private string assemblyName;

		private string resourcePath;

		private string basePath;

		public AssemblyResource(CustomUri resource)
		{
			AssemblyResource assemblyResource = this;
			base.CreateStream = () => assemblyResource.CreateResourceFromUri(resource, null);
		}

		public AssemblyResource(CustomUri resource, string basePath)
		{
			AssemblyResource assemblyResource = this;
			base.CreateStream = () => assemblyResource.CreateResourceFromUri(resource, basePath);
		}

		public AssemblyResource(string resource)
		{
			AssemblyResource assemblyResource = this;
			base.CreateStream = () => assemblyResource.CreateResourceFromPath(resource, assemblyResource.basePath);
		}

		public override IResource CreateRelative(string relativePath)
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "AssemblyResource: [{0}] [{1}]", assemblyName, resourcePath);
		}

		private Stream CreateResourceFromPath(string resource, string path)
		{
			if (!resource.StartsWith("assembly" + CustomUri.SchemeDelimiter, StringComparison.CurrentCulture))
			{
				resource = "assembly" + CustomUri.SchemeDelimiter + resource;
			}
			return CreateResourceFromUri(new CustomUri(resource), path);
		}

		private Stream CreateResourceFromUri(CustomUri resourcex, string path)
		{
			if (resourcex == null)
			{
				throw new ArgumentNullException("resourcex");
			}
			assemblyName = resourcex.Host;
			resourcePath = ConvertToResourceName(assemblyName, resourcex.Path);
			Assembly assembly = ObtainAssembly(assemblyName);
			string[] manifestResourceNames = assembly.GetManifestResourceNames();
			string nameFound = GetNameFound(manifestResourceNames);
			if (nameFound == null)
			{
				resourcePath = resourcex.Path.Replace('/', '.').Substring(1);
				nameFound = GetNameFound(manifestResourceNames);
			}
			if (nameFound == null)
			{
				throw new ResourceException(string.Format(CultureInfo.InvariantCulture, "The assembly resource {0} could not be located", resourcePath));
			}
			basePath = ConvertToPath(resourcePath);
			return assembly.GetManifestResourceStream(nameFound);
		}

		private string GetNameFound(string[] names)
		{
			string result = null;
			foreach (string text in names)
			{
				if (string.Compare(resourcePath, text, StringComparison.OrdinalIgnoreCase) == 0)
				{
					result = text;
					break;
				}
			}
			return result;
		}

		private string ConvertToResourceName(string assembly, string resource)
		{
			assembly = GetSimpleName(assembly);
			return string.Format(CultureInfo.CurrentCulture, "{0}{1}", assembly, resource.Replace('/', '.'));
		}

		private string GetSimpleName(string assembly)
		{
			int num = assembly.IndexOf(',');
			if (num < 0)
			{
				return assembly;
			}
			return assembly.Substring(0, num);
		}

		private string ConvertToPath(string resource)
		{
			string text = resource.Replace('.', '/');
			if (text[0] != '/')
			{
				text = string.Format(CultureInfo.CurrentCulture, "/{0}", text);
			}
			return text;
		}

		private static Assembly ObtainAssembly(string assemblyName)
		{
			try
			{
				return Assembly.Load(assemblyName);
			}
			catch (Exception innerException)
			{
				throw new ResourceException(string.Format(CultureInfo.InvariantCulture, "The assembly {0} could not be loaded", assemblyName), innerException);
			}
		}
	}
}

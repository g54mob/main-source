using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;

namespace Castle.Core.Resource
{
	public class AssemblyBundleResource : AbstractResource
	{
		private readonly CustomUri resource;

		public AssemblyBundleResource(CustomUri resource)
		{
			this.resource = resource;
		}

		public override TextReader GetStreamReader()
		{
			Assembly assembly = ObtainAssembly(resource.Host);
			string[] array = resource.Path.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != 2)
			{
				throw new ResourceException("AssemblyBundleResource does not support paths with more than 2 levels in depth. See " + resource.Path);
			}
			return new StringReader(new ResourceManager(array[0], assembly).GetString(array[1]));
		}

		public override TextReader GetStreamReader(Encoding encoding)
		{
			return GetStreamReader();
		}

		public override IResource CreateRelative(string relativePath)
		{
			throw new NotImplementedException();
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

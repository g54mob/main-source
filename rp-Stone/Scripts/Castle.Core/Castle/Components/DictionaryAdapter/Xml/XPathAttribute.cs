using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = true)]
	public class XPathAttribute : Attribute
	{
		private readonly CompiledXPath getPath;

		private readonly CompiledXPath setPath;

		public CompiledXPath GetPath => getPath;

		public CompiledXPath SetPath => setPath;

		public bool Nullable { get; set; }

		public XPathAttribute(string path)
		{
			if (path == null)
			{
				throw Error.ArgumentNull("path");
			}
			getPath = XPathCompiler.Compile(path);
			setPath = getPath;
		}

		public XPathAttribute(string get, string set)
		{
			if (get == null)
			{
				throw Error.ArgumentNull("get");
			}
			if (set == null)
			{
				throw Error.ArgumentNull("set");
			}
			getPath = XPathCompiler.Compile(get);
			setPath = XPathCompiler.Compile(set);
		}
	}
}

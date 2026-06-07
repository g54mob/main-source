using System;

namespace Noesis
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public sealed class XmlnsDefinitionAttribute : Attribute
	{
		private string _xmlNamespace;

		private string _clrNamespace;

		private string _assemblyName;

		public string XmlNamespace => null;

		public string ClrNamespace => null;

		public string AssemblyName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public XmlnsDefinitionAttribute(string xmlNamespace, string clrNamespace)
		{
		}
	}
}

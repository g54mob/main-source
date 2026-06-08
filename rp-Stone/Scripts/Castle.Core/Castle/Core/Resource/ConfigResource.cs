using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace Castle.Core.Resource
{
	public class ConfigResource : AbstractResource
	{
		private readonly XmlNode configSectionNode;

		private readonly string sectionName;

		public ConfigResource()
			: this("castle")
		{
		}

		public ConfigResource(CustomUri uri)
			: this(uri.Host)
		{
		}

		public ConfigResource(string sectionName)
		{
			this.sectionName = sectionName;
			XmlNode xmlNode = (XmlNode)ConfigurationManager.GetSection(sectionName);
			if (xmlNode == null)
			{
				throw new ConfigurationErrorsException(string.Format(CultureInfo.InvariantCulture, "Could not find section '{0}' in the configuration file associated with this domain.", new object[1] { sectionName }));
			}
			configSectionNode = xmlNode;
		}

		public override TextReader GetStreamReader()
		{
			return new StringReader(configSectionNode.OuterXml);
		}

		public override TextReader GetStreamReader(Encoding encoding)
		{
			throw new NotSupportedException("Encoding is not supported");
		}

		public override IResource CreateRelative(string relativePath)
		{
			return new ConfigResource(relativePath);
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "ConfigResource: [{0}]", new object[1] { sectionName });
		}
	}
}

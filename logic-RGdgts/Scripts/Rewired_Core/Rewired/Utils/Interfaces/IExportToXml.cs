using System.Xml;

namespace Rewired.Utils.Interfaces
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IExportToXml
	{
		bool writesOwnElementTag { get; }

		void WriteXml(XmlWriter writer);
	}
}

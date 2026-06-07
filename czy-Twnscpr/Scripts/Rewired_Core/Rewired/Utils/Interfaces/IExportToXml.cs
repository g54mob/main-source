using System.Xml;

namespace Rewired.Utils.Interfaces
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IExportToXml
	{
		bool writesOwnElementTag { get; }

		void WriteXml(XmlWriter writer);
	}
}

using System.Xml.Linq;
using ModApi.Common.Extensions;

namespace Assets.Scripts.State
{
	public class CrewMember
	{
		public const string XmlElementName = "CrewMember";

		public int Id { get; private set; }

		public int NodeId { get; set; }

		public string Location { get; set; }

		public string Name { get; set; }

		public CrewMemberState State { get; set; }

		public bool UseAlternateJetpack { get; private set; }

		public CrewMember(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public CrewMember(XElement xml)
		{
			Id = xml.GetIntAttribute("id");
			NodeId = xml.GetIntAttribute("nodeId", -1);
			Name = xml.GetStringAttribute("name");
			Location = xml.GetStringAttribute("location");
			State = xml.GetEnumAttribute("state", CrewMemberState.Available);
			UseAlternateJetpack = Name.StartsWith("Yuri G") || Name.StartsWith("Sally R");
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("CrewMember");
			xElement.SetAttributeValue("id", Id);
			xElement.SetAttributeValue("nodeId", NodeId);
			xElement.SetAttributeValue("name", Name);
			xElement.SetAttributeValue("location", Location);
			xElement.SetAttributeValue("state", State);
			return xElement;
		}
	}
}

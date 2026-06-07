using System.Xml.Linq;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class MfdPage
	{
		public string Id { get; }

		public string Name { get; }

		public Widget Widget { get; set; }

		public MfdPage(XElement xml)
		{
			Id = xml.GetStringAttribute("id");
			Name = xml.GetStringAttribute("name");
		}
	}
}

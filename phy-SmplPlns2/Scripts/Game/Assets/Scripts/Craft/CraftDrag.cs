using System.Xml.Linq;
using Assets.Scripts.Craft.Parts;

namespace Assets.Scripts.Craft
{
	public class CraftDrag
	{
		public PartDrag StreamlineFactor { get; private set; } = new PartDrag();

		public CraftDrag(XElement xml)
		{
			if (xml != null)
			{
				StreamlineFactor = new PartDrag(xml);
			}
		}

		public void WriteToXml(XElement craftDragXml)
		{
			StreamlineFactor.WriteToXml(craftDragXml);
		}
	}
}

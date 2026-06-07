using ModApi.Ui.Inspector;
using UI.Xml;

namespace Assets.Scripts.Ui.Inspector
{
	public class TableRowElement : ItemElement
	{
		public XmlElement Container { get; set; }

		public TableRowElement(XmlElement xmlElement, TableRowModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			Container = xmlElement;
		}
	}
}

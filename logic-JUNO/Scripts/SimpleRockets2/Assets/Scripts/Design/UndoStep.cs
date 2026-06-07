using System.Xml.Linq;

namespace Assets.Scripts.Design
{
	public class UndoStep
	{
		public bool IsHead { get; internal set; }

		public XElement Xml { get; private set; }

		public UndoStep(XElement xml)
		{
			Xml = xml;
		}

		public virtual void OnRedoComplete(DesignerScript designer)
		{
			ClosePartProperties(designer);
		}

		public virtual void OnUndoComplete(DesignerScript designer)
		{
			ClosePartProperties(designer);
		}

		private void ClosePartProperties(DesignerScript designer)
		{
		}
	}
}

using System;
using System.Xml.Linq;

namespace Assets.Scripts.Design
{
	public class UndoStep : IUndoStep
	{
		public DateTime DateTime { get; set; }

		public string Description { get; set; }

		public bool IsHead { get; set; }

		public XElement Xml { get; private set; }

		public UndoStep(XElement xml, string description, DateTime dateTime)
		{
			Xml = xml;
			Description = description;
			DateTime = dateTime;
		}

		public bool DeepEquals(IUndoStep undoStep)
		{
			if (undoStep is UndoStep undoStep2)
			{
				return XNode.DeepEquals(Xml, undoStep2.Xml);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}

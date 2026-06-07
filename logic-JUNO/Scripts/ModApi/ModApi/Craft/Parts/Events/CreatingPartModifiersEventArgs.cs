using System;
using System.Xml.Linq;

namespace ModApi.Craft.Parts.Events
{
	public class CreatingPartModifiersEventArgs : EventArgs
	{
		private static readonly CreatingPartModifiersEventArgs _static = new CreatingPartModifiersEventArgs();

		public PartData Part { get; private set; }

		public PartType PartType { get; private set; }

		public XElement PartXml { get; private set; }

		public int PartXmlVersion { get; private set; }

		private CreatingPartModifiersEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatingPartModifiersEventArgs> eventHandler, PartType partType, PartData part, XElement partXml, int partXmlVersion)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.PartType = partType;
			_static.Part = part;
			_static.PartXml = partXml;
			_static.PartXmlVersion = partXmlVersion;
			try
			{
				eventHandler(partType, _static);
			}
			finally
			{
				_static.PartType = null;
				_static.Part = null;
				_static.PartXml = null;
			}
		}
	}
}

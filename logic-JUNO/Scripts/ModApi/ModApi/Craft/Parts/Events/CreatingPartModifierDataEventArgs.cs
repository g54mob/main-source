using System;
using System.Xml.Linq;

namespace ModApi.Craft.Parts.Events
{
	public class CreatingPartModifierDataEventArgs : EventArgs
	{
		private static readonly CreatingPartModifierDataEventArgs _static = new CreatingPartModifierDataEventArgs();

		public PartData Part { get; private set; }

		public XElement PartModifierStateXml { get; private set; }

		public XElement PartModifierXml { get; private set; }

		public int PartModifierXmlVersion { get; private set; }

		private CreatingPartModifierDataEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatingPartModifierDataEventArgs> eventHandler, XElement partModifierXml, XElement partModifierStateXml, PartData part, int partModifierXmlVersion)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.PartModifierXml = partModifierXml;
			_static.PartModifierStateXml = partModifierStateXml;
			_static.PartModifierXmlVersion = partModifierXmlVersion;
			_static.Part = part;
			try
			{
				eventHandler(null, _static);
			}
			finally
			{
				_static.PartModifierXml = null;
				_static.PartModifierStateXml = null;
				_static.Part = null;
			}
		}
	}
}

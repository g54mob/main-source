using System;
using System.Xml.Linq;

namespace ModApi.Craft.Parts.Events
{
	public class CreatedPartModifierDataEventArgs : EventArgs
	{
		private static readonly CreatedPartModifierDataEventArgs _static = new CreatedPartModifierDataEventArgs();

		public PartData Part { get; private set; }

		public PartModifierData PartModifier { get; private set; }

		public XElement PartModifierStateXml { get; private set; }

		public XElement PartModifierXml { get; private set; }

		public int PartModifierXmlVersion { get; private set; }

		private CreatedPartModifierDataEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatedPartModifierDataEventArgs> eventHandler, XElement partModifierXml, XElement partModifierStateXml, PartData part, int partModifierXmlVersion, PartModifierData partModifier)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.PartModifierXml = partModifierXml;
			_static.PartModifierStateXml = partModifierStateXml;
			_static.PartModifierXmlVersion = partModifierXmlVersion;
			_static.Part = part;
			_static.PartModifier = partModifier;
			try
			{
				eventHandler(null, _static);
			}
			finally
			{
				_static.PartModifierXml = null;
				_static.PartModifierStateXml = null;
				_static.Part = null;
				_static.PartModifier = null;
			}
		}
	}
}

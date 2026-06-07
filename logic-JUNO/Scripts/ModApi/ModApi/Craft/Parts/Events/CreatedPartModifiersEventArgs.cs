using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ModApi.Craft.Parts.Events
{
	public class CreatedPartModifiersEventArgs : EventArgs
	{
		private static readonly CreatedPartModifiersEventArgs _static = new CreatedPartModifiersEventArgs();

		public PartData Part { get; private set; }

		public IReadOnlyList<PartModifierData> PartModifiers { get; private set; }

		public PartType PartType { get; private set; }

		public XElement PartXml { get; private set; }

		public int PartXmlVersion { get; private set; }

		private CreatedPartModifiersEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatedPartModifiersEventArgs> eventHandler, PartType partType, PartData part, XElement partXml, int partXmlVersion, IReadOnlyList<PartModifierData> partModifiers)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.PartType = partType;
			_static.Part = part;
			_static.PartXml = partXml;
			_static.PartXmlVersion = partXmlVersion;
			_static.PartModifiers = partModifiers;
			try
			{
				eventHandler(partType, _static);
			}
			finally
			{
				_static.PartType = null;
				_static.Part = null;
				_static.PartXml = null;
				_static.PartModifiers = null;
			}
		}
	}
}

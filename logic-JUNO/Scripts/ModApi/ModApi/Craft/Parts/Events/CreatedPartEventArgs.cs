using System;
using System.Xml.Linq;

namespace ModApi.Craft.Parts.Events
{
	public class CreatedPartEventArgs : EventArgs
	{
		private static readonly CreatedPartEventArgs _static = new CreatedPartEventArgs();

		public PartData Part { get; private set; }

		public PartType PartType { get; private set; }

		public XElement PartXml { get; private set; }

		public int PartXmlVersion { get; private set; }

		private CreatedPartEventArgs()
		{
		}

		public static void RaiseStaticEvent(EventHandler<CreatedPartEventArgs> eventHandler, PartData part, PartType partType, XElement partXml, int partXmlVersion)
		{
			if (eventHandler == null)
			{
				return;
			}
			_static.Part = part;
			_static.PartType = partType;
			_static.PartXml = partXml;
			_static.PartXmlVersion = partXmlVersion;
			try
			{
				eventHandler(part, _static);
			}
			finally
			{
				_static.Part = null;
				_static.PartType = null;
				_static.PartXml = null;
			}
		}
	}
}

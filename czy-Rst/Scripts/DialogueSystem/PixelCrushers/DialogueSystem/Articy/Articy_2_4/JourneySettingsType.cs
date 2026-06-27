using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	[Serializable]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	public class JourneySettingsType
	{
		private BackgroundImageModeType backgroundImageModeField;

		private ReferenceType backgroundImageField;

		private BackgroundImagePositioningModeType backgroundImagePositioningModeField;

		private BackgroundColorModeType backgroundColorModeField;

		private string backgroundColorField;

		private BackgroundColorGradientModeType backgroundColorGradientModeField;

		private int durationField;

		private TransitionModeType transitionModeField;

		public BackgroundImageModeType BackgroundImageMode
		{
			get
			{
				return backgroundImageModeField;
			}
			set
			{
				backgroundImageModeField = value;
			}
		}

		public ReferenceType BackgroundImage
		{
			get
			{
				return backgroundImageField;
			}
			set
			{
				backgroundImageField = value;
			}
		}

		public BackgroundImagePositioningModeType BackgroundImagePositioningMode
		{
			get
			{
				return backgroundImagePositioningModeField;
			}
			set
			{
				backgroundImagePositioningModeField = value;
			}
		}

		public BackgroundColorModeType BackgroundColorMode
		{
			get
			{
				return backgroundColorModeField;
			}
			set
			{
				backgroundColorModeField = value;
			}
		}

		public string BackgroundColor
		{
			get
			{
				return backgroundColorField;
			}
			set
			{
				backgroundColorField = value;
			}
		}

		public BackgroundColorGradientModeType BackgroundColorGradientMode
		{
			get
			{
				return backgroundColorGradientModeField;
			}
			set
			{
				backgroundColorGradientModeField = value;
			}
		}

		public int Duration
		{
			get
			{
				return durationField;
			}
			set
			{
				durationField = value;
			}
		}

		public TransitionModeType TransitionMode
		{
			get
			{
				return transitionModeField;
			}
			set
			{
				transitionModeField = value;
			}
		}
	}
}

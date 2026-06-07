using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ControlSurfaceData
	{
		public enum TrimType
		{
			Off = 0,
			On = 1,
			Inverted = 2
		}

		[DesignerPropertyButton(Label = "Delete Control Surface", Style = ButtonStyle.Danger, Order = 5)]
		private bool _deleteControlSurface;

		[DesignerPropertyButton(Label = "Edit Shape", Style = ButtonStyle.Default, Order = 4)]
		private bool _editControlSurfaceShape;

		[DesignerPropertyToggleButton(new string[] { "Roll", "Pitch", "Yaw", "Flaps" }, Label = "Input", AllowFunkyInput = true, Order = 1)]
		private string _inputId = "Roll";

		[DesignerPropertyToggleButton(new string[] { "Yes", "No" }, Label = "Invert", Order = 2)]
		private bool _invert;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Trim", Order = 3)]
		private TrimType _trim;

		public int ActivationGroup { get; set; }

		public bool ActivationGroupLocksInput { get; set; }

		public string ActivationString { get; set; }

		public bool AutoInvert
		{
			get
			{
				if (!(InputId == "Pitch"))
				{
					return InputId == "-Pitch";
				}
				return true;
			}
		}

		public int End { get; set; }

		public string InputId
		{
			get
			{
				return _inputId;
			}
			set
			{
				_inputId = value;
			}
		}

		public bool Invert
		{
			get
			{
				return _invert;
			}
			set
			{
				_invert = value;
			}
		}

		public int Length => End - Start;

		public int MaxDeflectionDegree { get; set; }

		public int Start { get; set; }

		public TrimType Trim
		{
			get
			{
				return _trim;
			}
			set
			{
				_trim = value;
			}
		}

		public ControlSurfaceData(XElement element)
		{
			InputId = element.Attribute("inputId").Value;
			MaxDeflectionDegree = int.Parse(element.Attribute("maxDeflectionDegree").Value);
			Invert = bool.Parse(element.Attribute("invert").Value);
			End = int.Parse(element.Attribute("end").Value);
			Start = int.Parse(element.Attribute("start").Value);
			ActivationString = ((string)element.Attribute("activationGroup")) ?? "0";
			if (int.TryParse(ActivationString, out var result))
			{
				ActivationGroup = result;
			}
			ActivationGroupLocksInput = (bool?)element.Attribute("activationGroupLocksInput") == true;
			XAttribute xAttribute = element.Attribute("trim");
			if (xAttribute != null)
			{
				if (xAttribute.Value == "on")
				{
					Trim = TrimType.On;
				}
				else if (xAttribute.Value == "inverted")
				{
					Trim = TrimType.Inverted;
				}
				else
				{
					Trim = TrimType.Off;
				}
			}
			else if (InputId == "Pitch" || InputId == "-Pitch")
			{
				Trim = TrimType.On;
			}
			else
			{
				Trim = TrimType.Off;
			}
		}

		public ControlSurfaceData(int start, int length, string inputId, int maxDeflectionDegree, bool invert)
		{
			Start = start;
			End = start + length;
			InputId = inputId;
			MaxDeflectionDegree = maxDeflectionDegree;
			Invert = invert;
			ActivationGroup = 0;
			ActivationGroupLocksInput = true;
			ActivationString = "0";
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("ControlSurface", new XAttribute("start", Start), new XAttribute("end", End), new XAttribute("inputId", InputId), new XAttribute("invert", Invert.ToString().ToLower()), new XAttribute("maxDeflectionDegree", MaxDeflectionDegree.ToString()), (ActivationString == "0") ? null : new XAttribute("activationGroup", ActivationString), (!ActivationGroupLocksInput) ? null : new XAttribute("activationGroupLocksInput", ActivationGroupLocksInput));
			if (Trim == TrimType.On)
			{
				xElement.Add(new XAttribute("trim", "on"));
			}
			else if (Trim == TrimType.Inverted)
			{
				xElement.Add(new XAttribute("trim", "inverted"));
			}
			else
			{
				xElement.Add(new XAttribute("trim", "off"));
			}
			return xElement;
		}
	}
}

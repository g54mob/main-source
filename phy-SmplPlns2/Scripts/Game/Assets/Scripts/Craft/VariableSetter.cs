using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Jundroo.Common.Expressions;

namespace Assets.Scripts.Craft
{
	public class VariableSetter
	{
		private Func<bool> _compiledActivator;

		private Func<float> _compiledFunction;

		public bool Activated
		{
			get
			{
				if (_compiledActivator != null)
				{
					return _compiledActivator();
				}
				return true;
			}
		}

		public string Activator { get; set; }

		public string Expression { get; set; }

		public bool IsCompiled => _compiledFunction != null;

		public int Priority { get; set; }

		public float Value
		{
			get
			{
				if (_compiledFunction != null)
				{
					return _compiledFunction();
				}
				return 0f;
			}
		}

		public string VariableName { get; set; }

		public static VariableSetter LoadFromXml(XElement xml)
		{
			string text = (string)xml.Attribute("variable");
			string expression = (string)xml.Attribute("function");
			string activator = (string)xml.Attribute("activator");
			int valueOrDefault = ((int?)xml.Attribute("priority")).GetValueOrDefault();
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}
			return new VariableSetter
			{
				VariableName = text,
				Expression = expression,
				Priority = valueOrDefault,
				Activator = activator
			};
		}

		public static void UpgradeLegacyFlapsSetters(XElement aircraftXml, XElement variablesXml)
		{
			if (variablesXml == null)
			{
				return;
			}
			XElement xElement = aircraftXml.Element("Assembly").Element("Parts");
			Regex regex = new Regex("\\bFlaps\\b");
			foreach (XElement item in variablesXml.Elements("Setter"))
			{
				if (item.GetStringAttribute("variable") == "Flaps")
				{
					item.SetAttributeValue("variable", "LegacyFlaps");
				}
				string stringAttribute = item.GetStringAttribute("function");
				if (!string.IsNullOrEmpty(stringAttribute) && regex.IsMatch(stringAttribute))
				{
					item.SetAttributeValue("function", regex.Replace(stringAttribute, "LegacyFlaps"));
				}
			}
			foreach (XElement item2 in xElement.Elements("Part"))
			{
				foreach (XElement item3 in item2.Elements("InputController.State"))
				{
					XAttribute xAttribute = item3.Attribute("input");
					if (xAttribute != null && regex.IsMatch(xAttribute.Value))
					{
						xAttribute.Value = regex.Replace(xAttribute.Value, "LegacyFlaps");
					}
				}
			}
		}

		public void Compile(AircraftScript aircraft)
		{
			if (!string.IsNullOrWhiteSpace(Expression))
			{
				_compiledFunction = Parser.Process<float>(Expression, aircraft.ExpressionContext);
			}
			if (!string.IsNullOrWhiteSpace(Activator))
			{
				_compiledActivator = Parser.Process<bool>(Activator, aircraft.ExpressionContext);
			}
		}

		public XElement SaveToXml()
		{
			XElement xElement = new XElement("Setter", new XAttribute("variable", VariableName), new XAttribute("function", Expression), new XAttribute("priority", Priority));
			if (!string.IsNullOrWhiteSpace(Activator))
			{
				xElement.SetAttributeValue("activator", Activator);
			}
			return xElement;
		}
	}
}

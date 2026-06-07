using System;
using System.Xml.Linq;
using Jundroo.Common.Expressions;

namespace Assets.Scripts.Craft.Parts.Modifiers.Variables
{
	public class VariableOutput
	{
		private Func<bool> _activator;

		private Func<float> _getter;

		private PartModifierScript _modifier;

		public string Activator { get; set; }

		public VariableOutputDefinition Definition { get; private set; }

		public bool Enabled { get; set; }

		public bool IsActivated => _activator?.Invoke() ?? true;

		public int Priority { get; set; }

		public float Value => _getter();

		public string Variable { get; set; }

		public VariableOutput(VariableOutputDefinition definition, XElement xml)
		{
			Definition = definition;
			Activator = (string)xml.Attribute("activator");
			Priority = ((int?)xml.Attribute("priority")).GetValueOrDefault();
			Variable = (string)xml.Attribute("variable");
		}

		public VariableOutput(VariableOutputDefinition definition)
		{
			Definition = definition;
			Activator = null;
			Priority = definition.DefaultOutputPriority;
			Variable = definition.DefaultOutputVariable;
		}

		public void Compile()
		{
			if (!string.IsNullOrEmpty(Activator))
			{
				_activator = Parser.Process<bool>(Activator, _modifier.PartScript.ExpressionContext);
			}
		}

		public void InitScript(PartModifierScript script)
		{
			_modifier = script;
			_getter = Definition.GetGetter(script);
		}

		public XElement SaveToXML()
		{
			XElement xElement = new XElement("VariableOutput", new XAttribute("id", Definition.Id), new XAttribute("variable", Variable), new XAttribute("priority", Priority));
			if (Activator != null)
			{
				xElement.SetAttributeValue("activator", Activator);
			}
			return xElement;
		}
	}
}

using System.Collections.Generic;
using System.Xml.Linq;

namespace ModApi.Craft.Program
{
	public class VariableSet
	{
		public const string VariablesElementsName = "Variables";

		private Dictionary<string, Variable> _variables = new Dictionary<string, Variable>();

		public IEnumerable<Variable> Variables => _variables.Values;

		public VariableSet()
		{
		}

		public VariableSet(XElement xml)
		{
			if (xml == null)
			{
				return;
			}
			foreach (XElement item in xml.Elements())
			{
				Variable variable = new Variable(item);
				AddVariable(variable);
			}
		}

		public void AddVariable(Variable variable)
		{
			_variables[variable.Name] = variable;
		}

		public VariableSet Clone()
		{
			VariableSet variableSet = new VariableSet();
			foreach (Variable value in _variables.Values)
			{
				Variable variable = new Variable(value.Name);
				variable.Value.Set(value.Value);
				variableSet.AddVariable(variable);
			}
			return variableSet;
		}

		public void DeleteVariable(string name)
		{
			_variables.Remove(name);
		}

		public Variable GetOrCreateVariable(string name)
		{
			Variable value = null;
			if (!_variables.TryGetValue(name, out value))
			{
				value = new Variable(name);
				AddVariable(value);
			}
			return value;
		}

		public Variable GetVariable(string name)
		{
			_variables.TryGetValue(name, out var value);
			return value;
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("Variables");
			foreach (Variable variable in Variables)
			{
				XElement xElement2 = new XElement("Variable");
				variable.SaveXml(xElement2);
				xElement.Add(xElement2);
			}
			return xElement;
		}
	}
}

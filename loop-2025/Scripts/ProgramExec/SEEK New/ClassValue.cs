// add
using System;
using System.Collections.Generic;

namespace GptDeepResearch
{
	/// <summary>
	/// Represents a class definition in the Python interpreter
	/// </summary>
	public class ClassValue
	{
		public string Name { get; }
		public List<Stmt> Body { get; }
		public string Docstring { get; }
		public Dictionary<string, object> Methods { get; } = new Dictionary<string, object>();

		public ClassValue(string name, List<Stmt> body, string docstring = null)
		{
			Name = name;
			Body = body;
			Docstring = docstring;

			// Process methods from the body during construction
			foreach (var stmt in body)
			{
				if (stmt is FunctionDefStmt methodDef)
				{
					Methods[methodDef.Name] = methodDef;
				}
			}
		}

		/// <summary>
		/// Create an instance of this class
		/// </summary>
		public ClassInstanceValue CreateInstance()
		{
			return new ClassInstanceValue(this);
		}

		public override string ToString()
		{
			return $"<class '{Name}'>";
		}
	}

	/// <summary>
	/// Represents an instance of a class
	/// </summary>
	public class ClassInstanceValue
	{
		public ClassValue Class { get; }
		public Dictionary<string, object> Attributes { get; } = new Dictionary<string, object>();

		public ClassInstanceValue(ClassValue classValue)
		{
			Class = classValue;
		}

		/// <summary>
		/// Get attribute value
		/// </summary>
		public object GetAttribute(string name)
		{
			// Check instance attributes first
			if (Attributes.ContainsKey(name))
			{
				return Attributes[name];
			}

			// Check class methods
			if (Class.Methods.ContainsKey(name))
			{
				var method = Class.Methods[name];
				if (method is FunctionDefStmt funcDef)
				{
					// Return a bound method (simplified - just return the function for now)
					return funcDef;
				}
				return method;
			}

			throw new Exception($"'{Class.Name}' object has no attribute '{name}'");
		}

		/// <summary>
		/// Set attribute value
		/// </summary>
		public void SetAttribute(string name, object value)
		{
			Attributes[name] = value;
		}

		/// <summary>
		/// Check if attribute exists
		/// </summary>
		public bool HasAttribute(string name)
		{
			return Attributes.ContainsKey(name) || Class.Methods.ContainsKey(name);
		}

		public override string ToString()
		{
			return $"<{Class.Name} object>";
		}
	}
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/Float Formula", order = 1000)]
	public class FloatFormula : FloatVar
	{
		[Serializable]
		public class FloatOperation
		{
			[HideInInspector]
			public string display;

			public string name = "Formula Name";

			public MathOperation operation;

			public FloatReference value = new FloatReference();

			public float GetResult(float MainValue)
			{
				return operation switch
				{
					MathOperation.Add => MainValue + (float)value, 
					MathOperation.Substract => MainValue - (float)value, 
					MathOperation.Multiply => MainValue * (float)value, 
					MathOperation.Divide => MainValue / (float)value, 
					_ => 0f, 
				};
			}

			public string GetOperation()
			{
				return operation switch
				{
					MathOperation.Add => "+", 
					MathOperation.Substract => "-", 
					MathOperation.Multiply => "*", 
					MathOperation.Divide => "/", 
					_ => "", 
				};
			}

			public FloatOperation(string name, MathOperation operation, FloatReference value)
			{
				this.name = name;
				this.operation = operation;
				this.value = value;
			}
		}

		public List<FloatOperation> values = new List<FloatOperation>();

		public override float Value
		{
			get
			{
				float result = value;
				foreach (FloatOperation value in values)
				{
					result = value.GetResult(result);
				}
				if (debug)
				{
					Debug.Log($"<B>{base.name} -> [<color=red> {result} </color>] </B>", this);
				}
				return result;
			}
		}

		public void SetFormula(string Name, MathOperation operation, float value)
		{
			values.Add(new FloatOperation(Name, operation, new FloatReference(value)));
		}

		public void SetFormula(string Name, MathOperation operation, FloatReference value)
		{
			values.Add(new FloatOperation(Name, operation, value));
		}

		public void SetFormula(FloatOperation formula)
		{
			values.Add(formula);
		}

		public void FormulaAdd(FloatVar value)
		{
			values.Add(new FloatOperation(value.name, MathOperation.Add, new FloatReference(value)));
		}

		public void FormulaSubstact(FloatVar value)
		{
			values.Add(new FloatOperation(value.name, MathOperation.Substract, new FloatReference(value)));
		}

		public void FormulaMultiply(FloatVar value)
		{
			values.Add(new FloatOperation(value.name, MathOperation.Multiply, new FloatReference(value)));
		}

		public void FormulaDivide(FloatVar value)
		{
			values.Add(new FloatOperation(value.name, MathOperation.Divide, new FloatReference(value)));
		}

		public void RemoveFormula(string name)
		{
			values.RemoveAll((FloatOperation v) => v.name == name);
		}

		private void OnValidate()
		{
			string text = $"{value}";
			foreach (FloatOperation value in values)
			{
				value.display = text + $" {value.GetOperation()} {value.value.Value}";
				text = value.display;
			}
		}
	}
}

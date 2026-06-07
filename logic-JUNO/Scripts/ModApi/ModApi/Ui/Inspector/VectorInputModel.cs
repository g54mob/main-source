using System;

namespace ModApi.Ui.Inspector
{
	public abstract class VectorInputModel<T> : ValueModel<T>
	{
		public string Label { get; set; }

		public int NumComponents { get; set; }

		public VectorInputModel(string label, Func<T> valueGetter, Action<T> valueSetter, int numComponents)
			: base(valueGetter, valueSetter)
		{
			Label = label;
			NumComponents = numComponents;
		}

		public abstract string GetComponentText(int component);

		public abstract void OnInputChanged(string[] components, int componentChanged);

		protected string DefaultFormatterDouble(double x)
		{
			return x.ToString();
		}

		protected string DefaultFormatterFloat(float x)
		{
			return x.ToString();
		}

		protected string DefaultFormatterInt(int x)
		{
			return x.ToString();
		}

		protected double DefaultParserDouble(string s)
		{
			double result = 0.0;
			double.TryParse(s, out result);
			return result;
		}

		protected float DefaultParserFloat(string s)
		{
			float result = 0f;
			float.TryParse(s, out result);
			return result;
		}

		protected int DefaultParserInt(string s)
		{
			int result = 0;
			int.TryParse(s, out result);
			return result;
		}
	}
}

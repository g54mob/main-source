using System;
using System.Collections.Generic;
using System.Numerics;

public class StonescriptBigNumber : StonescriptObject
{
	private BigInteger value;

	private static readonly double floatPrecisionFactor = Math.Pow(2.0, 24.0);

	private static readonly string[] suffixes = new string[12]
	{
		"", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc",
		"No", "Dc"
	};

	public BigInteger Value => value;

	public StonescriptBigNumber()
		: this("bignumber")
	{
		value = new BigInteger(0);
	}

	public StonescriptBigNumber(int value)
		: this("bignumber")
	{
		this.value = new BigInteger(value);
	}

	public StonescriptBigNumber(long value)
		: this("bignumber")
	{
		this.value = new BigInteger(value);
	}

	public StonescriptBigNumber(float value)
		: this("bignumber")
	{
		this.value = new BigInteger(value);
	}

	private StonescriptBigNumber(BigInteger value)
		: this("bignumber")
	{
		this.value = new BigInteger(value.ToByteArray());
	}

	public static StonescriptBigNumber Parse(string s)
	{
		if (BigInteger.TryParse(s, out var result))
		{
			return new StonescriptBigNumber(result);
		}
		if (s.Length > 24)
		{
			s = s.Substring(0, 23) + "…";
		}
		throw new StonescriptRuntimeException("Parse failed for '" + s + "'");
	}

	public StonescriptBigNumber(string name, StonescriptObject parent = null)
		: base(name, parent)
	{
		base.ObjectType = "BigNumber";
		BindFunctions();
	}

	public void BindFunctions()
	{
		DeclareFunction(Add, new List<string> { "value" });
		DeclareFunction(Sub, new List<string> { "value" });
		DeclareFunction(Mul, new List<string> { "value" });
		DeclareFunction(Div, new List<string> { "value" });
		DeclareFunction("Eq", EqualTo, new List<string> { "value" });
		DeclareFunction("Gt", GreaterThan, new List<string> { "value" });
		DeclareFunction("Ge", GreaterThanOrEqualTo, new List<string> { "value" });
		DeclareFunction("Lt", LessThan, new List<string> { "value" });
		DeclareFunction("Le", LessThanOrEqualTo, new List<string> { "value" });
		DeclareFunction(ToString, new List<string>());
		DeclareFunction(ToUI, new List<string>());
	}

	protected override void Link(HashSet<StonescriptObject> processedObjects)
	{
		BindFunctions();
		base.Link(processedObjects);
	}

	private object Add(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || (!(parameters[0] is int) && !(parameters[0] is float) && !(parameters[0] is StonescriptBigNumber)))
		{
			throw new StonescriptRuntimeException("BigNumber.Add expects a number or BigNumber");
		}
		if (parameters[0] is int)
		{
			value += (BigInteger)(int)parameters[0];
		}
		else if (parameters[0] is float)
		{
			value += new BigInteger((float)parameters[0]);
		}
		else if (parameters[0] is StonescriptBigNumber)
		{
			value += ((StonescriptBigNumber)parameters[0]).Value;
		}
		return this;
	}

	private object Sub(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || (!(parameters[0] is int) && !(parameters[0] is float) && !(parameters[0] is StonescriptBigNumber)))
		{
			throw new StonescriptRuntimeException("BigNumber.Sub expects a number or BigNumber");
		}
		if (parameters[0] is int)
		{
			value -= (BigInteger)(int)parameters[0];
		}
		else if (parameters[0] is float)
		{
			value -= new BigInteger((float)parameters[0]);
		}
		else if (parameters[0] is StonescriptBigNumber)
		{
			value -= ((StonescriptBigNumber)parameters[0]).Value;
		}
		return this;
	}

	private object Mul(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || (!(parameters[0] is int) && !(parameters[0] is float) && !(parameters[0] is StonescriptBigNumber)))
		{
			throw new StonescriptRuntimeException("BigNumber.Mul expects a number or BigNumber");
		}
		if (parameters[0] is int)
		{
			value *= (BigInteger)(int)parameters[0];
		}
		else if (parameters[0] is float)
		{
			float num = (float)parameters[0];
			value *= new BigInteger(floatPrecisionFactor * (double)num);
			value /= new BigInteger(floatPrecisionFactor);
		}
		else if (parameters[0] is StonescriptBigNumber)
		{
			value *= ((StonescriptBigNumber)parameters[0]).Value;
		}
		return this;
	}

	private object Div(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || (!(parameters[0] is int) && !(parameters[0] is float) && !(parameters[0] is StonescriptBigNumber)))
		{
			throw new StonescriptRuntimeException("BigNumber.Div expects a number or BigNumber");
		}
		if (parameters[0] is int)
		{
			value /= (BigInteger)(int)parameters[0];
		}
		else if (parameters[0] is float)
		{
			float num = (float)parameters[0];
			value *= new BigInteger(floatPrecisionFactor);
			value /= new BigInteger(floatPrecisionFactor * (double)num);
		}
		else if (parameters[0] is StonescriptBigNumber)
		{
			value /= ((StonescriptBigNumber)parameters[0]).Value;
		}
		return this;
	}

	private object EqualTo(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 1 && parameters[0] is int)
		{
			return value.Equals((int)parameters[0]);
		}
		if (parameters.Count == 1 && parameters[0] is StonescriptBigNumber)
		{
			return value.Equals(((StonescriptBigNumber)parameters[0]).Value);
		}
		if (parameters.Count == 1 && parameters[0] is float)
		{
			float num = (float)parameters[0];
			BigInteger bigInteger = new BigInteger(floatPrecisionFactor) * value;
			BigInteger other = new BigInteger(floatPrecisionFactor * (double)num);
			return bigInteger.Equals(other);
		}
		throw new StonescriptRuntimeException("BigNumber.Eq expects a number or BigNumber");
	}

	private object GreaterThan(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 1 && parameters[0] is int)
		{
			return value.CompareTo((int)parameters[0]) > 0;
		}
		if (parameters.Count == 1 && parameters[0] is StonescriptBigNumber)
		{
			return value.CompareTo(((StonescriptBigNumber)parameters[0]).Value) > 0;
		}
		if (parameters.Count == 1 && parameters[0] is float)
		{
			float num = (float)parameters[0];
			BigInteger bigInteger = new BigInteger(floatPrecisionFactor) * value;
			BigInteger other = new BigInteger(floatPrecisionFactor * (double)num);
			return bigInteger.CompareTo(other) > 0;
		}
		throw new StonescriptRuntimeException("BigNumber.Gt expects a number or BigNumber");
	}

	private object GreaterThanOrEqualTo(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 1 && parameters[0] is int)
		{
			return value.CompareTo((int)parameters[0]) >= 0;
		}
		if (parameters.Count == 1 && parameters[0] is StonescriptBigNumber)
		{
			return value.CompareTo(((StonescriptBigNumber)parameters[0]).Value) >= 0;
		}
		if (parameters.Count == 1 && parameters[0] is float)
		{
			float num = (float)parameters[0];
			BigInteger bigInteger = new BigInteger(floatPrecisionFactor) * value;
			BigInteger other = new BigInteger(floatPrecisionFactor * (double)num);
			return bigInteger.CompareTo(other) >= 0;
		}
		throw new StonescriptRuntimeException("BigNumber.Ge expects a number or BigNumber");
	}

	private object LessThan(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 1 && parameters[0] is int)
		{
			return value.CompareTo((int)parameters[0]) < 0;
		}
		if (parameters.Count == 1 && parameters[0] is StonescriptBigNumber)
		{
			return value.CompareTo(((StonescriptBigNumber)parameters[0]).Value) < 0;
		}
		if (parameters.Count == 1 && parameters[0] is float)
		{
			float num = (float)parameters[0];
			BigInteger bigInteger = new BigInteger(floatPrecisionFactor) * value;
			BigInteger other = new BigInteger(floatPrecisionFactor * (double)num);
			return bigInteger.CompareTo(other) < 0;
		}
		throw new StonescriptRuntimeException("BigNumber.Lt expects a number or BigNumber");
	}

	private object LessThanOrEqualTo(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 1 && parameters[0] is int)
		{
			return value.CompareTo((int)parameters[0]) <= 0;
		}
		if (parameters.Count == 1 && parameters[0] is StonescriptBigNumber)
		{
			return value.CompareTo(((StonescriptBigNumber)parameters[0]).Value) <= 0;
		}
		if (parameters.Count == 1 && parameters[0] is float)
		{
			float num = (float)parameters[0];
			BigInteger bigInteger = new BigInteger(floatPrecisionFactor) * value;
			BigInteger other = new BigInteger(floatPrecisionFactor * (double)num);
			return bigInteger.CompareTo(other) <= 0;
		}
		throw new StonescriptRuntimeException("BigNumber.Le expects a number or BigNumber");
	}

	private object ToString(List<object> parameters, InvocationContext ctx)
	{
		return value.ToString();
	}

	private object ToUI(List<object> parameters, InvocationContext ctx)
	{
		int num = 4;
		string text = ".";
		int length = BigInteger.Abs(value).ToString().Length;
		int num2 = (length - 1) / 3;
		string text2 = ((num2 >= 0 && num2 < suffixes.Length) ? suffixes[num2] : ("E" + 3 * num2));
		string obj = ((value.Sign < 0) ? "-" : "");
		string text3 = string.Join("", BigInteger.Abs(value).ToString("E").Split("E")[0].Split("."));
		text3 = text3.PadRight(num, '0').Substring(0, num).TrimEnd('0');
		int num3 = length - num2 * 3;
		text3 = text3.PadRight(num3, '0');
		string text4 = text3.Substring(0, num3);
		string text5 = ((num3 < text3.Length) ? (text + text3.Substring(num3)) : "");
		return obj + text4 + text5 + text2;
	}

	public override string ToString()
	{
		return value.ToString();
	}
}

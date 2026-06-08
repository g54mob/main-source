using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Stonescript;
using Stonescript.Runtime;
using Stonescript.Types;
using UnityEngine;

public class StonescriptGlobals
{
	public static int maxExecutionTime = 250;

	private static object Color_FromRGB(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 3 || !(parameters[0] is int) || !(parameters[1] is int) || !(parameters[2] is int))
		{
			throw new StonescriptRuntimeException("color.FromRGB() expects three integers");
		}
		int num = (int)parameters[0];
		int num2 = (int)parameters[1];
		int num3 = (int)parameters[2];
		Color color = new Color((float)num / 255f, (float)num2 / 255f, (float)num3 / 255f);
		return "#" + ColorUtility.ToHtmlStringRGB(color);
	}

	private static object Color_ToRGB(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("color.ToRGB() expects string");
		}
		Color color = Utils.ConvertColor((string)parameters[0]);
		return new StonescriptArray(3)
		{
			Mathf.RoundToInt(color.r * 255f),
			Mathf.RoundToInt(color.g * 255f),
			Mathf.RoundToInt(color.b * 255f)
		};
	}

	private static object Color_Random(List<object> parameters, InvocationContext ctx)
	{
		float value = UnityEngine.Random.value;
		float value2 = UnityEngine.Random.value;
		float value3 = UnityEngine.Random.value;
		Color color = new Color(value, value2, value3);
		return "#" + ColorUtility.ToHtmlStringRGB(color);
	}

	private static object Color_Lerp(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 3 || !(parameters[0] is string) || !(parameters[1] is string) || !(parameters[2] is float))
		{
			throw new StonescriptRuntimeException("Invalid parameters for color.Lerp()");
		}
		Color a = Utils.ConvertColor((string)parameters[0]);
		Color b = Utils.ConvertColor((string)parameters[1]);
		float t = (float)parameters[2];
		Color color = Color.Lerp(a, b, t);
		return "#" + ColorUtility.ToHtmlStringRGB(color);
	}

	public static object IntParse(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters for Parse function");
		}
		string text = parameters[0] as string;
		try
		{
			return Utils.ParseInt(text);
		}
		catch
		{
			if (text.Length > 24)
			{
				text = text.Substring(0, 23) + "…";
			}
			throw new StonescriptRuntimeException("Parse failed for '" + text + "'");
		}
	}

	public static object Length(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters for Length function");
		}
		return (parameters[0] as string).Length;
	}

	public static object Equals(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 2 || !(parameters[0] is string) || !(parameters[1] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters for Equals function");
		}
		string obj = parameters[0] as string;
		string value = parameters[1] as string;
		return obj.Equals(value);
	}

	public static object IndexOf(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 2 || parameters.Count > 3 || !(parameters[0] is string) || !(parameters[1] is string) || (parameters.Count == 3 && !(parameters[2] is int)))
		{
			throw new StonescriptRuntimeException("Invalid parameters for IndexOf function");
		}
		string text = parameters[0] as string;
		string value = parameters[1] as string;
		if (parameters.Count == 2)
		{
			return text.IndexOf(value);
		}
		int startIndex = (int)parameters[2];
		return text.IndexOf(value, startIndex);
	}

	public static object SubString(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 2 || parameters.Count > 3 || !(parameters[0] is string) || !(parameters[1] is int) || (parameters.Count == 3 && !(parameters[2] is int)))
		{
			throw new StonescriptRuntimeException("Invalid parameters for Sub function");
		}
		string text = parameters[0] as string;
		int startIndex = (int)parameters[1];
		if (parameters.Count == 2)
		{
			return text.Substring(startIndex);
		}
		int length = (int)parameters[2];
		return text.Substring(startIndex, length);
	}

	public static object String_Capitalize(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters string.Capitalize(string)");
		}
		string text = parameters[0] as string;
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		string text2 = text.Substring(0, 1).ToUpper();
		if (text.Length > 1)
		{
			text2 += text.Substring(1);
		}
		return text2;
	}

	public static object String_Format(List<object> parameters, InvocationContext ctx)
	{
		string text = parameters[0] as string;
		if (text == null)
		{
			return "";
		}
		if (text.StartsWith("tid_"))
		{
			text = Te.xt(text);
		}
		if (parameters.Count <= 1)
		{
			return text;
		}
		text = text.Replace("｛", "{");
		text = text.Replace("｝", "}");
		parameters.RemoveAt(0);
		return string.Format(text, parameters.ToArray());
	}

	public static object String_ToLower(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters string.ToLower(string)");
		}
		string text = parameters[0] as string;
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		return text.ToLowerInvariant();
	}

	public static object String_ToUpper(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters string.ToUpper(string)");
		}
		string text = parameters[0] as string;
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		return text.ToUpperInvariant();
	}

	public static object String_BreakLines(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 2 || !(parameters[0] is string) || !(parameters[1] is int))
		{
			throw new StonescriptRuntimeException("Invalid parameters string.Break(string, int)");
		}
		string message = parameters[0] as string;
		int preferredWidth = (int)parameters[1];
		return new StonescriptArray(Utils.BreakIntoLines(message, preferredWidth));
	}

	public static object String_Split(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters string.Split(string, …)");
		}
		string text = parameters[0] as string;
		List<string> list = new List<string>();
		int num = 0;
		bool flag = false;
		for (int i = 1; i < parameters.Count; i++)
		{
			if (parameters[i] is string)
			{
				list.Add(parameters[i] as string);
			}
			else if (parameters[i] is int && num <= 0)
			{
				num = (int)parameters[i];
			}
			else if (parameters[i] is bool)
			{
				flag = true;
				break;
			}
		}
		if (list.Count == 0)
		{
			list.Add(" ");
		}
		string[] list2 = ((num > 0) ? ((!flag) ? text.Split(list.ToArray(), num, StringSplitOptions.None) : text.Split(list.ToArray(), num, StringSplitOptions.RemoveEmptyEntries)) : ((!flag) ? text.Split(list.ToArray(), StringSplitOptions.None) : text.Split(list.ToArray(), StringSplitOptions.RemoveEmptyEntries)));
		return new StonescriptArray(list2);
	}

	public static object String_Join(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 2 || !(parameters[0] is string) || !(parameters[1] is StonescriptArray))
		{
			throw new StonescriptRuntimeException("Invalid parameters string.Join(string, [], …)");
		}
		string separator = parameters[0] as string;
		string[] array;
		try
		{
			array = (parameters[1] as StonescriptArray).ToArray<string>();
		}
		catch (Exception ex)
		{
			if (ex is InvalidCastException)
			{
				throw new StonescriptRuntimeException("string.Join() can only join an array of strings");
			}
			throw ex;
		}
		int num = 0;
		int num2 = array.Length;
		if (parameters.Count > 2 && parameters[2] is int)
		{
			num = (int)parameters[2];
			num = Mathf.Clamp(num, 0, array.Length - 1);
			if (parameters.Count > 3 && parameters[3] is int)
			{
				num2 = (int)parameters[3];
			}
			num2 = Mathf.Clamp(num2, 1, array.Length - num);
		}
		return string.Join(separator, array, num, num2);
	}

	public static object GetType(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1)
		{
			throw new StonescriptRuntimeException("Invalid parameters for Type function");
		}
		object obj = parameters[0];
		if (obj == null)
		{
			return "null";
		}
		if (obj is int)
		{
			return "int";
		}
		if (obj is string)
		{
			return "string";
		}
		if (obj is bool)
		{
			return "bool";
		}
		if (obj is float)
		{
			return "float";
		}
		if (obj is IFunction)
		{
			return "function";
		}
		if (obj is StonescriptArray)
		{
			return "array";
		}
		if (obj is StonescriptBigNumber)
		{
			return "bignumber";
		}
		return "object";
	}

	public static object Text_Localization(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("te.xt expects a string");
		}
		return Te.xt(parameters[0] as string);
	}

	public static object Text_GetTID(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("te.GetTID expects a string");
		}
		return Te.GetTID(parameters[0] as string);
	}

	public static object Text_ToEnglish(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("te.ToEnglish expects a string");
		}
		return Te.ToEnglish(parameters[0] as string);
	}

	public static object Math_Round(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.Round expects a number");
		}
		if (parameters[0] is int)
		{
			return Convert.ToSingle(parameters[0]);
		}
		return Mathf.Round((float)parameters[0]);
	}

	public static object Math_RoundToInt(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.RoundToInt expects a number");
		}
		if (parameters[0] is int)
		{
			return (int)parameters[0];
		}
		return Mathf.RoundToInt((float)parameters[0]);
	}

	public static object Math_Ceil(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.Ceil expects a number");
		}
		if (parameters[0] is int)
		{
			return Convert.ToSingle(parameters[0]);
		}
		return Mathf.Ceil((float)parameters[0]);
	}

	public static object Math_CeilToInt(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.CeilToInt expects a number");
		}
		if (parameters[0] is int)
		{
			return (int)parameters[0];
		}
		return Mathf.CeilToInt((float)parameters[0]);
	}

	public static object Math_Exp(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.Exp expects a number");
		}
		return Mathf.Exp(DataTypes.ToFloat(parameters[0]));
	}

	public static object Math_Log(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 2 || (!(parameters[0] is int) && !(parameters[0] is float)) || (!(parameters[1] is int) && !(parameters[1] is float)))
		{
			throw new StonescriptRuntimeException("math.Log expects two numbers");
		}
		float f = DataTypes.ToFloat(parameters[0]);
		float p = DataTypes.ToFloat(parameters[1]);
		return Mathf.Log(f, p);
	}

	public static object Math_Power(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 2 || (!(parameters[0] is int) && !(parameters[0] is float)) || (!(parameters[1] is int) && !(parameters[1] is float)))
		{
			throw new StonescriptRuntimeException("math.Pow expects two numbers");
		}
		float f = DataTypes.ToFloat(parameters[0]);
		float p = DataTypes.ToFloat(parameters[1]);
		return Mathf.Pow(f, p);
	}

	public static object Math_SquareRoot(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.Sqrt expects a number");
		}
		return Mathf.Sqrt(DataTypes.ToFloat(parameters[0]));
	}

	public static object Math_ToDegrees(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.ToDeg expects a number");
		}
		return DataTypes.ToFloat(parameters[0]) * 57.29578f;
	}

	public static object Math_ToRadians(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.ToRad expects a number");
		}
		return DataTypes.ToFloat(parameters[0]) * (MathF.PI / 180f);
	}

	public static object Math_ArcCosine(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.Acos expects a number");
		}
		return Mathf.Acos(DataTypes.ToFloat(parameters[0]));
	}

	public static object Math_ArcSine(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.Asin expects a number");
		}
		return Mathf.Asin(DataTypes.ToFloat(parameters[0]));
	}

	public static object Math_ArcTangent(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.Atan expects a number");
		}
		return Mathf.Atan(DataTypes.ToFloat(parameters[0]));
	}

	public static object Math_ArcTangent2(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 2 || (!(parameters[0] is int) && !(parameters[0] is float)) || (!(parameters[1] is int) && !(parameters[1] is float)))
		{
			throw new StonescriptRuntimeException("math.Atan2 expects two numbers");
		}
		float y = DataTypes.ToFloat(parameters[0]);
		float x = DataTypes.ToFloat(parameters[1]);
		return Mathf.Atan2(y, x);
	}

	public static object Math_Cosine(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.Cos expects a number");
		}
		return Mathf.Cos(DataTypes.ToFloat(parameters[0]));
	}

	public static object Math_Sine(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.Sin expects a number");
		}
		return Mathf.Sin(DataTypes.ToFloat(parameters[0]));
	}

	public static object Math_Tangent(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.Tan expects a number");
		}
		return Mathf.Tan(DataTypes.ToFloat(parameters[0]));
	}

	public static object Math_BigNumber(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			return new StonescriptBigNumber();
		}
		if (parameters[0] is int)
		{
			return new StonescriptBigNumber((int)parameters[0]);
		}
		if (parameters[0] is float)
		{
			return new StonescriptBigNumber((float)parameters[0]);
		}
		if (parameters[0] is string)
		{
			return StonescriptBigNumber.Parse((string)parameters[0]);
		}
		throw new StonescriptRuntimeException("math.BigNumber expects a number or a string");
	}

	public static object Math_Lerp(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 3 || (!(parameters[0] is int) && !(parameters[0] is float)) || (!(parameters[1] is int) && !(parameters[1] is float)) || (!(parameters[2] is int) && !(parameters[2] is float)))
		{
			throw new StonescriptRuntimeException("math.Lerp expects three numbers");
		}
		float a = DataTypes.ToFloat(parameters[0]);
		float b = DataTypes.ToFloat(parameters[1]);
		float t = DataTypes.ToFloat(parameters[2]);
		return Mathf.Lerp(a, b, t);
	}

	public static object Vector2_Length(List<object> parameters, InvocationContext ctx)
	{
		return new Vector2(DataTypes.ToFloat(parameters[0]), DataTypes.ToFloat(parameters[1])).magnitude;
	}

	public static object Math_Floor(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.Floor expects a number");
		}
		if (parameters[0] is int)
		{
			return Convert.ToSingle(parameters[0]);
		}
		return Mathf.Floor((float)parameters[0]);
	}

	public static object Math_FloorToInt(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || (!(parameters[0] is int) && !(parameters[0] is float)))
		{
			throw new StonescriptRuntimeException("math.FloorToInt expects a number");
		}
		if (parameters[0] is int)
		{
			return (int)parameters[0];
		}
		return Mathf.FloorToInt((float)parameters[0]);
	}

	public static object Math_Sign(List<object> parameters, InvocationContext ctx)
	{
		if (parameters[0] is int)
		{
			return Mathf.Sign((int)parameters[0]);
		}
		if (parameters[0] is float)
		{
			return Mathf.Sign((float)parameters[0]);
		}
		throw new Exception("math.Sign expects an int or float.");
	}

	public static object Math_Abs(List<object> parameters, InvocationContext ctx)
	{
		if (parameters[0] is int)
		{
			return Mathf.Abs((int)parameters[0]);
		}
		if (parameters[0] is float)
		{
			return Mathf.Abs((float)parameters[0]);
		}
		throw new Exception("math.Abs expects an int or float.");
	}

	public static object Math_Min(List<object> parameters, InvocationContext ctx)
	{
		int num = int.MaxValue;
		float num2 = float.MaxValue;
		bool flag = false;
		foreach (object parameter in parameters)
		{
			if (!flag && parameter is float)
			{
				flag = true;
				num2 = Convert.ToSingle(num);
			}
			if (flag)
			{
				if (parameter is int)
				{
					num2 = Mathf.Min(num2, (int)parameter);
					continue;
				}
				if (!(parameter is float))
				{
					throw new Exception("math.Min expects only ints and floats.");
				}
				num2 = Mathf.Min(num2, (float)parameter);
			}
			else
			{
				if (!(parameter is int))
				{
					throw new Exception("math.Min expects only ints and floats.");
				}
				num = Mathf.Min(num, (int)parameter);
			}
		}
		if (flag)
		{
			return num2;
		}
		return num;
	}

	public static object Math_Max(List<object> parameters, InvocationContext ctx)
	{
		int num = int.MinValue;
		float num2 = float.MinValue;
		bool flag = false;
		foreach (object parameter in parameters)
		{
			if (!flag && parameter is float)
			{
				flag = true;
				num2 = Convert.ToSingle(num);
			}
			if (flag)
			{
				if (parameter is int)
				{
					num2 = Mathf.Max(num2, (int)parameter);
					continue;
				}
				if (!(parameter is float))
				{
					throw new Exception("math.Max expects only ints and floats.");
				}
				num2 = Mathf.Max(num2, (float)parameter);
			}
			else
			{
				if (!(parameter is int))
				{
					throw new Exception("math.Max expects only ints and floats.");
				}
				num = Mathf.Max(num, (int)parameter);
			}
		}
		if (flag)
		{
			return num2;
		}
		return num;
	}

	public static object Math_Clamp(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 3 || !DataTypes.IsNumber(parameters[0]) || !DataTypes.IsNumber(parameters[1]) || !DataTypes.IsNumber(parameters[2]))
		{
			throw new StonescriptRuntimeException("Invalid parameters for math.Clamp function");
		}
		if (DataTypes.IsFloat(parameters[0]) || DataTypes.IsFloat(parameters[1]) || DataTypes.IsFloat(parameters[2]))
		{
			float value = DataTypes.ToFloat(parameters[0]);
			float min = DataTypes.ToFloat(parameters[1]);
			float max = DataTypes.ToFloat(parameters[2]);
			return Mathf.Clamp(value, min, max);
		}
		int value2 = DataTypes.ToInt(parameters[0]);
		int min2 = DataTypes.ToInt(parameters[1]);
		int max2 = DataTypes.ToInt(parameters[2]);
		return Mathf.Clamp(value2, min2, max2);
	}

	private static object Music_GetCurrent()
	{
		if ((bool)MusicController.singleton.currentMusic)
		{
			return MusicController.singleton.currentMusic.id;
		}
		return "";
	}

	private static object Music_Play(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("music.Play expects a string");
		}
		string id = (string)parameters[0];
		if (parameters.Count >= 2 && parameters[1] is int)
		{
			float delay = (float)(int)parameters[1] / 30f;
			MusicController.singleton.Play(id, delay);
		}
		else
		{
			MusicController.singleton.Play(id);
		}
		return null;
	}

	private static object Music_Stop(List<object> parameters, InvocationContext ctx)
	{
		MusicController.singleton.FadeToSilence();
		return null;
	}

	private static object Ambient_GetCurrent()
	{
		return AmbianceController.singleton.GetCurrentAmbientIDs();
	}

	private static object Ambient_Add(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("ambient.Add expects a string");
		}
		string id = (string)parameters[0];
		AmbianceController.singleton.AddAmbient(id);
		return null;
	}

	private static object Ambient_Stop(List<object> parameters, InvocationContext ctx)
	{
		AmbianceController.singleton.StopAllAmbient();
		return null;
	}

	private static object Time_FormatCasual(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Invalid parameters for time.FormatCasual function");
		}
		int num = (int)parameters[0];
		int num2 = num / 30;
		int num3 = num - num2 * 30;
		bool flag = false;
		if (parameters.Count >= 2 && parameters[1] is bool)
		{
			flag = (bool)parameters[1];
		}
		string text = Utils.FormatTimeCasual(num2, flag);
		if (flag)
		{
			text = text + " " + num3 + Te.xt("tid_time_suffix_frames");
		}
		return text;
	}

	private static object Time_FormatDigital(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Invalid parameters for time.FormatDigital function");
		}
		int num = (int)parameters[0];
		int num2 = num / 30;
		int num3 = num - num2 * 30;
		bool flag = false;
		if (parameters.Count >= 2 && parameters[1] is bool)
		{
			flag = (bool)parameters[1];
		}
		string text = Utils.FormatTimeDigital(num2);
		if (flag)
		{
			num3 = num3 * 10 / 3;
			text = ((num3 >= 10) ? (text + "." + num3) : (text + ".0" + num3));
		}
		return text;
	}

	private static object Key_Bind(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 2 || !(parameters[0] is string) || !(parameters[1] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters for key.Bind function");
		}
		string actionStr = (string)parameters[0];
		string text = (string)parameters[1];
		if (parameters.Count >= 3 && parameters[2] is string)
		{
			string secondKeyCodeStr = (string)parameters[2];
			Binding.singleton.Set(actionStr, text, secondKeyCodeStr);
		}
		else
		{
			Binding.singleton.Set(actionStr, text);
		}
		return null;
	}

	private static object Key_GetKeyAction(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters for key.GetCodeAction function");
		}
		string keyCodeStr = (string)parameters[0];
		return Binding.singleton.GetActionForCode(keyCodeStr);
	}

	private static object Key_GetActionKey(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters for key.GetActionCode function");
		}
		string actionStr = (string)parameters[0];
		return Binding.singleton.GetFirstCodeForAction(actionStr);
	}

	private static object Key_GetActionKey2(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters for key.GetActionCode2 function");
		}
		string actionStr = (string)parameters[0];
		return Binding.singleton.GetSecondCodeForAction(actionStr);
	}

	private static object Key_GetActionLabel(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters for key.GetActionLabel function");
		}
		string actionStr = (string)parameters[0];
		string firstCodeForAction = Binding.singleton.GetFirstCodeForAction(actionStr);
		if (firstCodeForAction.Length == 0 || firstCodeForAction == "None")
		{
			return "";
		}
		return firstCodeForAction[0].ToString();
	}

	private static object Key_ResetBindings(List<object> parameters, InvocationContext ctx)
	{
		Binding.singleton.ResetToDefault();
		return null;
	}

	public static object Sleep(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Invalid parameters for Sleep function");
		}
		int num = (int)parameters[0];
		if (num > 50)
		{
			throw new StonescriptRuntimeException("Cannot sleep for more than 50 milliseconds");
		}
		Thread.Sleep(num);
		return null;
	}

	public static object SetMaxExecutionTime(List<object> parameters, InvocationContext ctx)
	{
		maxExecutionTime = (int)parameters[0];
		if (ctx != null && ctx.machine != null)
		{
			ctx.machine.MAX_EXECUTION_TIME = maxExecutionTime;
		}
		return null;
	}

	public static object Debug_Log(List<object> parameters, InvocationContext ctx)
	{
		string text = "";
		bool flag = true;
		foreach (object parameter in parameters)
		{
			if (!flag)
			{
				text += "\n";
			}
			text = ((parameter != null) ? (text + parameter.ToString()) : (text + "null"));
			flag = false;
		}
		Debug.Log(text);
		return null;
	}

	public static object Debug_LogWarning(List<object> parameters, InvocationContext ctx)
	{
		string text = "";
		bool flag = true;
		foreach (object parameter in parameters)
		{
			if (!flag)
			{
				text += "\n";
			}
			text = ((parameter != null) ? (text + parameter.ToString()) : (text + "null"));
			flag = false;
		}
		Debug.LogWarning(text);
		return null;
	}

	public static bool Command_Print(string command, List<StonescriptResult> results, Stonescript.Runtime.ExecutionContext ctx)
	{
		string param = ctx.machine.SubstituteExpressions(command.Substring(1), ctx);
		StonescriptResult stonescriptResult = StonescriptResult.NewResult();
		stonescriptResult.type = StonescriptResult.Type.Print;
		stonescriptResult.param = param;
		results.Add(stonescriptResult);
		return true;
	}

	public static bool Command_Profile(string command, List<StonescriptResult> results, Stonescript.Runtime.ExecutionContext ctx)
	{
		string scriptName = command.Substring("profile".Length).Trim();
		ctx.machine.AddProfiler(scriptName);
		return true;
	}

	public static bool Command_Brew(string command, List<StonescriptResult> results, Stonescript.Runtime.ExecutionContext ctx)
	{
		StonescriptResult stonescriptResult = StonescriptResult.NewResult();
		stonescriptResult.type = StonescriptResult.Type.Brew;
		stonescriptResult.param = command.Substring(5).Trim();
		results.Add(stonescriptResult);
		return true;
	}

	public static bool Command_Loadout(string command, List<StonescriptResult> results, Stonescript.Runtime.ExecutionContext ctx)
	{
		if (command.Length >= 8)
		{
			string text = ctx.machine.SubstituteExpressions(command.Substring(7).Trim(), ctx);
			if (int.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
			{
				StonescriptResult stonescriptResult = StonescriptResult.NewResult();
				stonescriptResult.type = StonescriptResult.Type.EquipLoadout;
				stonescriptResult.paramInt = result;
				results.Add(stonescriptResult);
			}
			else
			{
				StonescriptResult stonescriptResult2 = StonescriptResult.NewResult();
				stonescriptResult2.type = StonescriptResult.Type.Error;
				stonescriptResult2.param = "Found '" + text + "' instead of Loadout number";
				results.Add(stonescriptResult2);
			}
		}
		else
		{
			StonescriptResult stonescriptResult3 = StonescriptResult.NewResult();
			stonescriptResult3.type = StonescriptResult.Type.Error;
			stonescriptResult3.param = "Missing loadout number";
			results.Add(stonescriptResult3);
		}
		return true;
	}

	public static bool Command_Activate(string command, List<StonescriptResult> results, Stonescript.Runtime.ExecutionContext ctx)
	{
		if (command.Length >= 9)
		{
			StonescriptResult stonescriptResult = StonescriptResult.NewResult();
			stonescriptResult.type = StonescriptResult.Type.ActivateAbility;
			stonescriptResult.param = command.Substring(8).Trim();
			results.Add(stonescriptResult);
		}
		else
		{
			StonescriptResult stonescriptResult2 = StonescriptResult.NewResult();
			stonescriptResult2.type = StonescriptResult.Type.Error;
			stonescriptResult2.param = "Missing ability name in 'activate' command.";
			results.Add(stonescriptResult2);
		}
		return true;
	}

	public static bool Command_Play(string command, List<StonescriptResult> results, Stonescript.Runtime.ExecutionContext ctx)
	{
		if (command.Length >= 5)
		{
			string param = ctx.machine.SubstituteExpressions(command.Substring(4).Trim(), ctx);
			StonescriptResult stonescriptResult = StonescriptResult.NewResult();
			stonescriptResult.type = StonescriptResult.Type.PlaySound;
			stonescriptResult.param = param;
			results.Add(stonescriptResult);
		}
		else
		{
			StonescriptResult stonescriptResult2 = StonescriptResult.NewResult();
			stonescriptResult2.type = StonescriptResult.Type.Error;
			stonescriptResult2.param = "Missing sound ID in 'play' command.";
			results.Add(stonescriptResult2);
		}
		return true;
	}

	public static bool Command_EquipR(string command, List<StonescriptResult> results, Stonescript.Runtime.ExecutionContext ctx)
	{
		if (command.Length >= 7)
		{
			StonescriptResult stonescriptResult = StonescriptResult.NewResult();
			stonescriptResult.type = StonescriptResult.Type.EquipRight;
			stonescriptResult.param = ctx.machine.SubstituteExpressions(command.Substring(6).Trim(), ctx);
			results.Add(stonescriptResult);
		}
		else
		{
			StonescriptResult stonescriptResult2 = StonescriptResult.NewResult();
			stonescriptResult2.type = StonescriptResult.Type.Error;
			stonescriptResult2.param = "Missing weapon name";
			results.Add(stonescriptResult2);
		}
		return true;
	}

	public static bool Command_EquipL(string command, List<StonescriptResult> results, Stonescript.Runtime.ExecutionContext ctx)
	{
		if (command.Length >= 7)
		{
			StonescriptResult stonescriptResult = StonescriptResult.NewResult();
			stonescriptResult.type = StonescriptResult.Type.EquipLeft;
			stonescriptResult.param = ctx.machine.SubstituteExpressions(command.Substring(6).Trim(), ctx);
			results.Add(stonescriptResult);
		}
		else
		{
			StonescriptResult stonescriptResult2 = StonescriptResult.NewResult();
			stonescriptResult2.type = StonescriptResult.Type.Error;
			stonescriptResult2.param = "Missing weapon name";
			results.Add(stonescriptResult2);
		}
		return true;
	}

	public static bool Command_EquipF(string command, List<StonescriptResult> results, Stonescript.Runtime.ExecutionContext ctx)
	{
		if (command.Length >= 7)
		{
			StonescriptResult stonescriptResult = StonescriptResult.NewResult();
			stonescriptResult.type = StonescriptResult.Type.EquipFaerie;
			stonescriptResult.param = ctx.machine.SubstituteExpressions(command.Substring(6).Trim(), ctx);
			results.Add(stonescriptResult);
		}
		else
		{
			StonescriptResult stonescriptResult2 = StonescriptResult.NewResult();
			stonescriptResult2.type = StonescriptResult.Type.Error;
			stonescriptResult2.param = "Missing weapon name";
			results.Add(stonescriptResult2);
		}
		return true;
	}

	public static bool Command_Equip(string command, List<StonescriptResult> results, Stonescript.Runtime.ExecutionContext ctx)
	{
		if (command.Length >= 6)
		{
			StonescriptResult stonescriptResult = StonescriptResult.NewResult();
			stonescriptResult.type = StonescriptResult.Type.Equip;
			stonescriptResult.param = ctx.machine.SubstituteExpressions(command.Substring(5).Trim(), ctx);
			results.Add(stonescriptResult);
		}
		else
		{
			StonescriptResult stonescriptResult2 = StonescriptResult.NewResult();
			stonescriptResult2.type = StonescriptResult.Type.Error;
			stonescriptResult2.param = "Missing weapon name";
			results.Add(stonescriptResult2);
		}
		return true;
	}

	public static bool Command_Enable(string command, List<StonescriptResult> results, Stonescript.Runtime.ExecutionContext ctx)
	{
		if (command.Length >= 7)
		{
			StonescriptResult stonescriptResult = StonescriptResult.NewResult();
			stonescriptResult.type = StonescriptResult.Type.EnableGameElement;
			stonescriptResult.param = command.Substring(6).Trim();
			results.Add(stonescriptResult);
		}
		else
		{
			StonescriptResult stonescriptResult2 = StonescriptResult.NewResult();
			stonescriptResult2.type = StonescriptResult.Type.Error;
			stonescriptResult2.param = "Missing game element in 'enable' command.";
			results.Add(stonescriptResult2);
		}
		return true;
	}

	public static bool Command_Disable(string command, List<StonescriptResult> results, Stonescript.Runtime.ExecutionContext ctx)
	{
		if (command.Length >= 8)
		{
			StonescriptResult stonescriptResult = StonescriptResult.NewResult();
			stonescriptResult.type = StonescriptResult.Type.DisableGameElement;
			stonescriptResult.param = command.Substring(7).Trim();
			results.Add(stonescriptResult);
		}
		else
		{
			StonescriptResult stonescriptResult2 = StonescriptResult.NewResult();
			stonescriptResult2.type = StonescriptResult.Type.Error;
			stonescriptResult2.param = "Missing game element in 'disable' command.";
			results.Add(stonescriptResult2);
		}
		return true;
	}

	public static void RegisterAll(Machine machine, AStonescriptGameModel gameModel)
	{
		RegisterGlobals(machine);
		RegisterGameModel(machine, gameModel);
	}

	public static void RegisterGlobals(Machine machine)
	{
		machine.RegisterFunction("color.FromRGB", Color_FromRGB);
		machine.RegisterFunction("color.ToRGB", Color_ToRGB);
		machine.RegisterFunction("color.Random", Color_Random);
		machine.RegisterFunction("color.Lerp", Color_Lerp);
		machine.RegisterFunction("int.Parse", IntParse);
		machine.RegisterFunction("math.Abs", Math_Abs);
		machine.RegisterFunction("math.Sign", Math_Sign);
		machine.RegisterFunction("math.Min", Math_Min);
		machine.RegisterFunction("math.Max", Math_Max);
		machine.RegisterFunction("math.Clamp", Math_Clamp);
		machine.RegisterFunction("math.Round", Math_Round);
		machine.RegisterFunction("math.RoundToInt", Math_RoundToInt);
		machine.RegisterFunction("math.Floor", Math_Floor);
		machine.RegisterFunction("math.FloorToInt", Math_FloorToInt);
		machine.RegisterFunction("math.Ceil", Math_Ceil);
		machine.RegisterFunction("math.CeilToInt", Math_CeilToInt);
		machine.RegisterFunction("math.Lerp", Math_Lerp);
		machine.RegisterFunction("math.Exp", Math_Exp);
		machine.RegisterFunction("math.Log", Math_Log);
		machine.RegisterFunction("math.Pow", Math_Power);
		machine.RegisterFunction("math.Sqrt", Math_SquareRoot);
		machine.RegisterVariable("math.pi", () => MathF.PI);
		machine.RegisterVariable("math.e", () => MathF.E);
		machine.RegisterFunction("math.ToDeg", Math_ToDegrees);
		machine.RegisterFunction("math.ToRad", Math_ToRadians);
		machine.RegisterFunction("math.Acos", Math_ArcCosine);
		machine.RegisterFunction("math.Asin", Math_ArcSine);
		machine.RegisterFunction("math.Atan", Math_ArcTangent);
		machine.RegisterFunction("math.Atan2", Math_ArcTangent2);
		machine.RegisterFunction("math.Cos", Math_Cosine);
		machine.RegisterFunction("math.Sin", Math_Sine);
		machine.RegisterFunction("math.Tan", Math_Tangent);
		machine.RegisterFunction("math.BigNumber", Math_BigNumber);
		machine.RegisterFunction("vector2.Length", Vector2_Length);
		machine.RegisterFunction("string.IndexOf", IndexOf);
		machine.RegisterFunction("string.Size", Length);
		machine.RegisterFunction("string.Equals", Equals);
		machine.RegisterFunction("string.Sub", SubString);
		machine.RegisterFunction("string.Capitalize", String_Capitalize);
		machine.RegisterFunction("string.Format", String_Format);
		machine.RegisterFunction("string.ToLower", String_ToLower);
		machine.RegisterFunction("string.ToUpper", String_ToUpper);
		machine.RegisterFunction("string.Break", String_BreakLines);
		machine.RegisterFunction("string.Split", String_Split);
		machine.RegisterFunction("string.Join", String_Join);
		machine.RegisterFunction("Type", GetType);
		machine.RegisterGlobal("ui", new SSUIStatic());
		machine.RegisterGlobal("sys", new SSSystemProperties());
		machine.RegisterFunction("stonescript.SetMaxExecutionTime", SetMaxExecutionTime);
	}

	public static void RegisterDevTools(Machine machine)
	{
		machine.RegisterFunction("stonescript.Sleep", Sleep);
	}

	public static void RegisterGameModel(Machine machine, AStonescriptGameModel gameModel)
	{
		machine.RegisterVariable("app.state", () => gameModel.GetApplicationState());
		machine.RegisterFunction("app.GetStateNumber", gameModel.GetStateNumber);
		machine.RegisterVariable("loc", gameModel.GetCurrentLocation);
		machine.RegisterVariable("loc.id", gameModel.GetCurrentLocationID);
		machine.RegisterVariable("loc.name", gameModel.GetCurrentLocationName);
		machine.RegisterVariable("loc.stars", () => gameModel.GetCurrentLocationStars());
		machine.RegisterVariable("loc.begin", () => gameModel.IsStartEvent());
		machine.RegisterVariable("loc.loop", () => gameModel.IsLoopEvent());
		machine.RegisterFunction("loc.Leave", gameModel.LeaveLocation);
		machine.RegisterFunction("loc.Pause", gameModel.PauseLocation);
		machine.RegisterVariable("loc.bestTime", () => gameModel.GetCurrentLocationBestTime());
		machine.RegisterVariable("loc.averageTime", () => gameModel.GetCurrentLocationAverageTime());
		machine.RegisterVariable("loc.isQuest", () => gameModel.IsCurrentLocationCustomQuest());
		machine.RegisterVariable("foe", gameModel.GetFoe);
		machine.RegisterVariable("foe.id", gameModel.GetFoeId);
		machine.RegisterVariable("foe.name", gameModel.GetFoeName);
		machine.RegisterVariable("foe.damage", () => gameModel.GetFoeDamage());
		machine.RegisterVariable("foe.distance", () => gameModel.GetFoeDistance());
		machine.RegisterVariable("foe.count", () => gameModel.GetFoeCount());
		machine.RegisterFunction("foe.GetCount", gameModel.GetFoeCount);
		machine.RegisterVariable("foe.hp", () => gameModel.GetFoeHitpoints());
		machine.RegisterVariable("foe.maxhp", () => gameModel.GetFoeMaxHitpoints());
		machine.RegisterVariable("foe.armor", () => gameModel.GetFoeArmor());
		machine.RegisterVariable("foe.maxarmor", () => gameModel.GetFoeMaxArmor());
		machine.RegisterVariable("foe.buffs.count", () => gameModel.GetFoeBuffCount());
		machine.RegisterVariable("foe.buffs.string", () => gameModel.GetFoeBuffString());
		machine.RegisterVariable("foe.debuffs.count", () => gameModel.GetFoeDebuffCount());
		machine.RegisterVariable("foe.debuffs.string", () => gameModel.GetFoeDebuffString());
		machine.RegisterVariable("foe.state", () => gameModel.GetFoeState());
		machine.RegisterVariable("foe.time", () => gameModel.GetFoeStateTime());
		machine.RegisterVariable("foe.level", () => gameModel.GetFoeLevel());
		machine.RegisterVariable("pickup", gameModel.GetPickup);
		machine.RegisterVariable("pickup.distance", () => gameModel.GetPickupDistance());
		machine.RegisterVariable("harvest", gameModel.GetHarvest);
		machine.RegisterVariable("harvest.distance", () => gameModel.GetHarvestDistance());
		machine.RegisterVariable("time", () => gameModel.GetTime());
		machine.RegisterVariable("totaltime", () => gameModel.GetTotalTime());
		machine.RegisterVariable("time.ms", delegate
		{
			throw new StonescriptRuntimeException("time.ms is deprecated, use time.msbn instead");
		});
		machine.RegisterVariable("time.msbn", () => new StonescriptBigNumber(DateTimeOffset.Now.ToUnixTimeMilliseconds()));
		machine.RegisterVariable("time.year", () => DateTime.Now.Year);
		machine.RegisterVariable("time.month", () => DateTime.Now.Month);
		machine.RegisterVariable("time.day", () => DateTime.Now.Day);
		machine.RegisterVariable("time.hour", () => DateTime.Now.Hour);
		machine.RegisterVariable("time.minute", () => DateTime.Now.Minute);
		machine.RegisterVariable("time.second", () => DateTime.Now.Second);
		machine.RegisterVariable("utc.year", () => DateTime.UtcNow.Year);
		machine.RegisterVariable("utc.month", () => DateTime.UtcNow.Month);
		machine.RegisterVariable("utc.day", () => DateTime.UtcNow.Day);
		machine.RegisterVariable("utc.hour", () => DateTime.UtcNow.Hour);
		machine.RegisterVariable("utc.minute", () => DateTime.UtcNow.Minute);
		machine.RegisterVariable("utc.second", () => DateTime.UtcNow.Second);
		machine.RegisterFunction("time.FormatCasual", Time_FormatCasual);
		machine.RegisterFunction("time.FormatDigital", Time_FormatDigital);
		machine.RegisterVariable("hp", () => gameModel.GetHitpoints());
		machine.RegisterVariable("maxhp", () => gameModel.GetMaxHitpoints());
		machine.RegisterVariable("armor", () => gameModel.GetArmor());
		machine.RegisterVariable("armor.f", () => gameModel.GetArmorFraction());
		machine.RegisterVariable("maxarmor", () => gameModel.GetMaxArmor());
		machine.RegisterVariable("pos.x", () => gameModel.GetPosX());
		machine.RegisterVariable("pos.y", () => gameModel.GetPosY());
		machine.RegisterVariable("pos.z", () => gameModel.GetPosZ());
		machine.RegisterVariable("buffs.count", () => gameModel.GetPlayerBuffCount());
		machine.RegisterVariable("buffs.string", () => gameModel.GetPlayerBuffString());
		machine.RegisterVariable("buffs.oldest", () => gameModel.GetPlayerOldestBuff());
		machine.RegisterVariable("debuffs.count", () => gameModel.GetPlayerDebuffCount());
		machine.RegisterVariable("debuffs.string", () => gameModel.GetPlayerDebuffString());
		machine.RegisterVariable("debuffs.oldest", () => gameModel.GetPlayerOldestDebuff());
		machine.RegisterVariable("face", gameModel.GetFacialExpression);
		machine.RegisterVariable("ai.enabled", () => gameModel.IsAiEnabled());
		machine.RegisterVariable("ai.paused", () => gameModel.IsAiPaused());
		machine.RegisterVariable("ai.idle", () => gameModel.IsAiIdle());
		machine.RegisterVariable("ai.walking", () => gameModel.IsAiWalking());
		machine.RegisterVariable("bighead", () => gameModel.IsBigHead());
		machine.RegisterVariable("res.stone", () => gameModel.GetResourceStone());
		machine.RegisterVariable("res.wood", () => gameModel.GetResourceWood());
		machine.RegisterVariable("res.tar", () => gameModel.GetResourceTar());
		machine.RegisterVariable("res.ki", () => gameModel.GetResourceKi());
		machine.RegisterVariable("res.bronze", () => gameModel.GetResourceBronze());
		machine.RegisterVariable("res.crystals", () => gameModel.GetKiCrystalCount());
		machine.RegisterVariable("player.direction", () => gameModel.GetPlayerDirection());
		machine.RegisterVariable("player.name", () => gameModel.GetPlayerName());
		machine.RegisterFunction("player.ShowScaredFace", gameModel.ShowPlayerScaredFace);
		machine.RegisterVariable("totalgp", () => gameModel.GetTotalGearPoints());
		machine.RegisterVariable("key", gameModel.GetKeyInput);
		machine.RegisterFunction("key.Bind", Key_Bind);
		machine.RegisterFunction("key.GetKeyAct", Key_GetKeyAction);
		machine.RegisterFunction("key.GetActKey", Key_GetActionKey);
		machine.RegisterFunction("key.GetActKey1", Key_GetActionKey);
		machine.RegisterFunction("key.GetActKey2", Key_GetActionKey2);
		machine.RegisterFunction("key.GetActLabel", Key_GetActionLabel);
		machine.RegisterFunction("key.ResetBinds", Key_ResetBindings);
		machine.RegisterVariable("screen.i", () => gameModel.GetScreenIndex());
		machine.RegisterVariable("screen.x", () => gameModel.GetScreenPosX());
		machine.RegisterVariable("screen.w", () => gameModel.GetScreenWidth());
		machine.RegisterVariable("screen.h", () => gameModel.GetScreenHeight());
		machine.RegisterFunction("screen.FromWorldX", gameModel.FromWorldToScreenX);
		machine.RegisterFunction("screen.FromWorldZ", gameModel.FromWorldToScreenZ);
		machine.RegisterFunction("screen.ToWorldX", gameModel.FromScreenToWorldX);
		machine.RegisterFunction("screen.ToWorldZ", gameModel.FromScreenToWorldZ);
		machine.RegisterFunction("screen.Next", gameModel.MoveCameraToNextScreen);
		machine.RegisterFunction("screen.Previous", gameModel.MoveCameraToPreviousScreen);
		machine.RegisterFunction("screen.ResetOffset", gameModel.ResetCameraScreenOffset);
		machine.RegisterVariable("rng", () => gameModel.GetRandom());
		machine.RegisterVariable("rngf", () => UnityEngine.Random.value);
		machine.RegisterVariable("te.language", () => Te.id);
		machine.RegisterFunction("te.xt", Text_Localization);
		machine.RegisterFunction("te.GetTID", Text_GetTID);
		machine.RegisterFunction("te.ToEnglish", Text_ToEnglish);
		machine.RegisterFunction("draw.Clear", gameModel.ClearScreen);
		machine.RegisterFunction("draw.Player", gameModel.DrawHero);
		machine.RegisterFunction("draw.Bg", gameModel.DrawBackground);
		machine.RegisterFunction("draw.Box", gameModel.DrawBox);
		machine.RegisterFunction("draw.GetSymbol", gameModel.DrawGetSymbol);
		machine.RegisterVariable("input.x", () => gameModel.GetCursorX());
		machine.RegisterVariable("input.y", () => gameModel.GetCursorY());
		machine.RegisterFunction("storage.Get", gameModel.StorageGet);
		machine.RegisterFunction("storage.Set", gameModel.StorageSet);
		machine.RegisterFunction("storage.Has", gameModel.StorageExists);
		machine.RegisterFunction("storage.Delete", gameModel.StorageDelete);
		machine.RegisterFunction("storage.Incr", gameModel.StorageIncr);
		machine.RegisterFunction("storage.Keys", gameModel.StorageKeys);
		machine.RegisterFunction("item.CanActivate", gameModel.ItemCanActivate);
		machine.RegisterFunction("item.GetCooldown", gameModel.ItemGetCooldown);
		machine.RegisterFunction("item.GetCount", gameModel.ItemGetCount);
		machine.RegisterFunction("item.GetTreasureCount", gameModel.ItemGetTreasureCount);
		machine.RegisterFunction("item.GetTreasureLimit", gameModel.ItemGetTreasureLimit);
		machine.RegisterVariable("item.potion", () => gameModel.ItemGetPotion());
		machine.RegisterVariable("item.left", () => gameModel.ItemGetLeft());
		machine.RegisterVariable("item.right", () => gameModel.ItemGetRight());
		machine.RegisterVariable("item.left.id", () => gameModel.ItemGetLeftId());
		machine.RegisterVariable("item.right.id", () => gameModel.ItemGetRightId());
		machine.RegisterVariable("item.left.state", () => gameModel.ItemGetLeftState());
		machine.RegisterVariable("item.right.state", () => gameModel.ItemGetRightState());
		machine.RegisterVariable("item.left.time", () => gameModel.ItemGetLeftTime());
		machine.RegisterVariable("item.right.time", () => gameModel.ItemGetRightTime());
		machine.RegisterFunction("item.GetLoadoutL", gameModel.LoadoutGetLeft);
		machine.RegisterFunction("item.GetLoadoutR", gameModel.LoadoutGetRight);
		machine.RegisterVariable("summon.count", () => gameModel.SummonGetCount());
		machine.RegisterFunction("summon.GetId", gameModel.SummonGetId);
		machine.RegisterFunction("summon.GetName", gameModel.SummonGetName);
		machine.RegisterFunction("summon.GetVar", gameModel.SummonGetVar);
		machine.RegisterFunction("summon.GetState", gameModel.SummonGetState);
		machine.RegisterFunction("summon.GetTime", gameModel.SummonGetTime);
		machine.RegisterVariable("music", () => Music_GetCurrent());
		machine.RegisterFunction("music.Play", Music_Play);
		machine.RegisterFunction("music.Stop", Music_Stop);
		machine.RegisterVariable("ambient", () => Ambient_GetCurrent());
		machine.RegisterFunction("ambient.Add", Ambient_Add);
		machine.RegisterFunction("ambient.Stop", Ambient_Stop);
		machine.RegisterFunction("damage.New", Damage.SSNew);
		RegisterCommands(machine);
	}

	public static void RegisterCommands(Machine machine)
	{
		machine.RegisterCommand(">", Command_Print);
		machine.RegisterCommand("play", Command_Play);
		machine.RegisterCommand("equipR", Command_EquipR);
		machine.RegisterCommand("equipL", Command_EquipL);
		machine.RegisterCommand("equipF", Command_EquipF);
		machine.RegisterCommand("equip", Command_Equip);
		machine.RegisterCommand("loadout", Command_Loadout);
		machine.RegisterCommand("activate", Command_Activate);
		machine.RegisterCommand("enable", Command_Enable);
		machine.RegisterCommand("disable", Command_Disable);
		machine.RegisterCommand("profile", Command_Profile);
		machine.RegisterCommand("brew", Command_Brew);
	}
}

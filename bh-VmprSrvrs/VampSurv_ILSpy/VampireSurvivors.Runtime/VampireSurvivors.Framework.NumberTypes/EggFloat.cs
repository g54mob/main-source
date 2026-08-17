using System;
using Cpp2ILInjected;

namespace VampireSurvivors.Framework.NumberTypes;

public class EggFloat
{
	private float _val;

	private float _eggVal;

	private float Val
	{
		get
		{
			return _val;
		}
		set
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			object obj = value & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = value & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F427h\"");
					if (value == -1f / 0f)
					{
						_val = -3.4028235E+38f;
					}
					else
					{
						_val = value;
					}
					return;
				}
			}
			_val = 3.4028235E+38f;
		}
	}

	private float EggVal
	{
		get
		{
			return _eggVal;
		}
		set
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			object obj = value & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = value & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F477h\"");
					if (value == -1f / 0f)
					{
						_eggVal = -3.4028235E+38f;
					}
					else
					{
						_eggVal = value;
					}
					return;
				}
			}
			_eggVal = 3.4028235E+38f;
		}
	}

	public EggFloat(float value, float eggValue = 0f)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		float num = default(float);
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F4D5h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_0120;
			}
		}
		num = 3.4028235E+38f;
		goto IL_0120;
		IL_0120:
		_val = num;
		object obj3 = eggValue & -2147483649L;
		if ((nint)obj3 != 2139095040)
		{
			object obj4 = eggValue & -2147483649L;
			if ((nint)obj4 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F505h\"");
				if (eggValue == -1f / 0f)
				{
					_eggVal = -3.4028235E+38f;
				}
				else
				{
					_eggVal = eggValue;
				}
				return;
			}
		}
		_eggVal = 3.4028235E+38f;
	}

	public void SetValue(float value)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		object obj = value & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = value & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F427h\"");
				if (value == -1f / 0f)
				{
					_val = -3.4028235E+38f;
				}
				else
				{
					_val = value;
				}
				return;
			}
		}
		_val = 3.4028235E+38f;
	}

	public float GetValue()
	{
		return _val;
	}

	public void SetEggValue(float value)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		object obj = value & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = value & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F477h\"");
				if (value == -1f / 0f)
				{
					_eggVal = -3.4028235E+38f;
				}
				else
				{
					_eggVal = value;
				}
				return;
			}
		}
		_eggVal = 3.4028235E+38f;
	}

	public float GetEggValue()
	{
		return _eggVal;
	}

	public static implicit operator float(EggFloat eggFloat)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F564h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public static EggFloat operator +(EggFloat a, EggFloat b)
	{
		if (a != null && b != null)
		{
			float eggValue = default(float);
			float value = default(float);
			EggFloat result = new EggFloat(value, eggValue);
			eggValue = b._eggVal + a._eggVal;
			value = b._val + a._val;
			return result;
		}
		return (EggFloat)(object)new NullReferenceException();
	}

	public static EggFloat operator +(EggFloat a, float b)
	{
		if (a != null)
		{
			float value = default(float);
			EggFloat result = new EggFloat(value, a._eggVal);
			value = a._val + b;
			return result;
		}
		return (EggFloat)(object)new NullReferenceException();
	}

	public static EggFloat operator ++(EggFloat a)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		float num;
		if (a != null)
		{
			num = a._val + 1f;
			object obj = num & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F73Ch\"");
					if (num == -1f / 0f)
					{
						a._val = -3.4028235E+38f;
						return a;
					}
					goto IL_00e9;
				}
			}
			num = 3.4028235E+38f;
			goto IL_00e9;
		}
		return (EggFloat)(object)new NullReferenceException();
		IL_00e9:
		a._val = num;
		return a;
	}

	public static EggFloat operator -(EggFloat a, EggFloat b)
	{
		if (a != null && b != null)
		{
			float eggValue = default(float);
			float value = default(float);
			EggFloat result = new EggFloat(value, eggValue);
			eggValue = a._eggVal - b._eggVal;
			value = a._val - b._val;
			return result;
		}
		return (EggFloat)(object)new NullReferenceException();
	}

	public static EggFloat operator -(EggFloat a, float b)
	{
		if (a != null)
		{
			float value = default(float);
			EggFloat result = new EggFloat(value, a._eggVal);
			value = a._val - b;
			return result;
		}
		return (EggFloat)(object)new NullReferenceException();
	}

	public static EggFloat operator --(EggFloat a)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		float num;
		if (a != null)
		{
			num = a._val - 1f;
			object obj = num & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F90Ch\"");
					if (num == -1f / 0f)
					{
						a._val = -3.4028235E+38f;
						return a;
					}
					goto IL_00e9;
				}
			}
			num = 3.4028235E+38f;
			goto IL_00e9;
		}
		return (EggFloat)(object)new NullReferenceException();
		IL_00e9:
		a._val = num;
		return a;
	}

	public static EggFloat operator *(EggFloat a, float b)
	{
		if (a != null)
		{
			float eggValue = default(float);
			float value = default(float);
			EggFloat result = new EggFloat(value, eggValue);
			eggValue = a._eggVal * b;
			value = a._val * b;
			return result;
		}
		return (EggFloat)(object)new NullReferenceException();
	}

	public static EggFloat operator /(EggFloat a, float b)
	{
		//IL_0061: Invalid comparison between F4 and I4
		bool flag = b == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F9FFh\"");
		if (!flag)
		{
			float eggValue = default(float);
			float value = default(float);
			EggFloat result = new EggFloat(value, eggValue);
			eggValue = a._eggVal / b;
			value = a._val / b;
			return result;
		}
		DivideByZeroException ex = new DivideByZeroException();
		throw ex;
	}

	private static float Cap(float value)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		float num = default(float);
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5FADAh\"");
				if (num == -1f / 0f)
				{
					return -3.4028235E+38f;
				}
			}
		}
		return 3.4028235E+38f;
	}
}

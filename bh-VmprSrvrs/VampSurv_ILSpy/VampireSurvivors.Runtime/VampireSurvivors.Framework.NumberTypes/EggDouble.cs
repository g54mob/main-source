using System;
using Cpp2ILInjected;

namespace VampireSurvivors.Framework.NumberTypes;

public class EggDouble
{
	private double _val;

	private double _eggVal;

	private double Val
	{
		get
		{
			return _val;
		}
		set
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			object obj = value & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj != 9218868437227405312L)
			{
				object obj2 = value & 0x7FFFFFFFFFFFFFFFL;
				if ((long)obj2 <= 9218868437227405312L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,qword ptr [188A11860h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5ECE8h\"");
					if ((long)obj2 == 9218868437227405312L)
					{
						_val = -1.7976931348623157E+308;
					}
					else
					{
						_val = value;
					}
					return;
				}
			}
			_val = 1.7976931348623157E+308;
		}
	}

	private double EggVal
	{
		get
		{
			return _eggVal;
		}
		set
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			object obj = value & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj != 9218868437227405312L)
			{
				object obj2 = value & 0x7FFFFFFFFFFFFFFFL;
				if ((long)obj2 <= 9218868437227405312L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,qword ptr [188A11860h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5ED48h\"");
					if ((long)obj2 == 9218868437227405312L)
					{
						_eggVal = -1.7976931348623157E+308;
					}
					else
					{
						_eggVal = value;
					}
					return;
				}
			}
			_eggVal = 1.7976931348623157E+308;
		}
	}

	public EggDouble(double value, double eggValue = 0.0)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		double num = default(double);
		object obj = num & 0x7FFFFFFFFFFFFFFFL;
		if ((long)obj != 9218868437227405312L)
		{
			object obj2 = num & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj2 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,xmm4\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5EDB6h\"");
				if ((long)obj2 == 9218868437227405312L)
				{
					num = -1.7976931348623157E+308;
				}
				goto IL_0158;
			}
		}
		num = 1.7976931348623157E+308;
		goto IL_0158;
		IL_0158:
		_val = num;
		object obj3 = eggValue & 0x7FFFFFFFFFFFFFFFL;
		if ((long)obj3 != 9218868437227405312L)
		{
			object obj4 = eggValue & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj4 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm2,xmm4\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5EDE3h\"");
				if ((long)obj4 == 9218868437227405312L)
				{
					_eggVal = -1.7976931348623157E+308;
				}
				else
				{
					_eggVal = eggValue;
				}
				return;
			}
		}
		_eggVal = 1.7976931348623157E+308;
	}

	public void SetValue(double value)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		object obj = value & 0x7FFFFFFFFFFFFFFFL;
		if ((long)obj != 9218868437227405312L)
		{
			object obj2 = value & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj2 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,qword ptr [188A11860h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5ECE8h\"");
				if ((long)obj2 == 9218868437227405312L)
				{
					_val = -1.7976931348623157E+308;
				}
				else
				{
					_val = value;
				}
				return;
			}
		}
		_val = 1.7976931348623157E+308;
	}

	public double GetValue()
	{
		return _val;
	}

	public void SetEggValue(double value)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		object obj = value & 0x7FFFFFFFFFFFFFFFL;
		if ((long)obj != 9218868437227405312L)
		{
			object obj2 = value & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj2 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,qword ptr [188A11860h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5ED48h\"");
				if ((long)obj2 == 9218868437227405312L)
				{
					_eggVal = -1.7976931348623157E+308;
				}
				else
				{
					_eggVal = value;
				}
				return;
			}
		}
		_eggVal = 1.7976931348623157E+308;
	}

	public double GetEggValue()
	{
		return _eggVal;
	}

	public static implicit operator double(EggDouble eggDouble)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		double result = eggDouble._eggVal;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [rcx+10h]\"");
		object obj = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
		if ((long)obj != 9218868437227405312L)
		{
			object obj2 = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj2 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [188A11860h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5EE45h\"");
				if ((long)obj2 == 9218868437227405312L)
				{
					result = -1.7976931348623157E+308;
				}
				return result;
			}
		}
		return 1.7976931348623157E+308;
	}

	public static EggDouble operator +(EggDouble a, EggDouble b)
	{
		if (a != null && b != null)
		{
			EggDouble result = new EggDouble(b._val, b._eggVal);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm7,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm8,xmm9\"");
			return result;
		}
		return (EggDouble)(object)new NullReferenceException();
	}

	public static EggDouble operator +(EggDouble a, double b)
	{
		if (a != null)
		{
			EggDouble result = new EggDouble(a._val, a._eggVal);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm7,xmm8\"");
			return result;
		}
		return (EggDouble)(object)new NullReferenceException();
	}

	public static EggDouble operator ++(EggDouble a)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		double val;
		if (a != null)
		{
			val = a._val;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [188A10758h]\"");
			object obj = a._val & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj != 9218868437227405312L)
			{
				object obj2 = a._val & 0x7FFFFFFFFFFFFFFFL;
				if ((long)obj2 <= 9218868437227405312L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [188A11860h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F02Dh\"");
					if ((long)obj2 == 9218868437227405312L)
					{
						a._val = -1.7976931348623157E+308;
						return a;
					}
					goto IL_0113;
				}
			}
			val = 1.7976931348623157E+308;
			goto IL_0113;
		}
		return (EggDouble)(object)new NullReferenceException();
		IL_0113:
		a._val = val;
		return a;
	}

	public static EggDouble operator -(EggDouble a, EggDouble b)
	{
		if (a != null && b != null)
		{
			EggDouble result = new EggDouble(a._val, a._eggVal);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm8,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm9,xmm7\"");
			return result;
		}
		return (EggDouble)(object)new NullReferenceException();
	}

	public static EggDouble operator -(EggDouble a, double b)
	{
		if (a != null)
		{
			EggDouble result = new EggDouble(a._val, a._eggVal);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm7,xmm8\"");
			return result;
		}
		return (EggDouble)(object)new NullReferenceException();
	}

	public static EggDouble operator --(EggDouble a)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		double val;
		if (a != null)
		{
			val = a._val;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,qword ptr [188A10758h]\"");
			object obj = a._val & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj != 9218868437227405312L)
			{
				object obj2 = a._val & 0x7FFFFFFFFFFFFFFFL;
				if ((long)obj2 <= 9218868437227405312L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [188A11860h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F20Dh\"");
					if ((long)obj2 == 9218868437227405312L)
					{
						a._val = -1.7976931348623157E+308;
						return a;
					}
					goto IL_0113;
				}
			}
			val = 1.7976931348623157E+308;
			goto IL_0113;
		}
		return (EggDouble)(object)new NullReferenceException();
		IL_0113:
		a._val = val;
		return a;
	}

	public static EggDouble operator *(EggDouble a, double b)
	{
		if (a != null)
		{
			EggDouble result = new EggDouble(a._val, a._eggVal);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm6,xmm8\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm7,xmm8\"");
			return result;
		}
		return (EggDouble)(object)new NullReferenceException();
	}

	public static EggDouble operator /(EggDouble a, double b)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2A35]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm8,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F300h\"");
		if (!flag)
		{
			EggDouble result = new EggDouble(a._val, a._eggVal);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm6,xmm8\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm7,xmm8\"");
			return result;
		}
		DivideByZeroException ex = new DivideByZeroException();
		throw ex;
	}

	private static double Cap(double value)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		double num = default(double);
		object obj = num & 0x7FFFFFFFFFFFFFFFL;
		if ((long)obj != 9218868437227405312L)
		{
			object obj2 = num & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj2 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [188A11860h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B5F3EBh\"");
				if ((long)obj2 == 9218868437227405312L)
				{
					return -1.7976931348623157E+308;
				}
			}
		}
		return 1.7976931348623157E+308;
	}
}

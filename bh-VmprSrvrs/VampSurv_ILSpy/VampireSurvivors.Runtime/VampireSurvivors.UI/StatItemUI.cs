using System;
using System.Globalization;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class StatItemUI : MonoBehaviour
{
	private string _Format;

	public PowerUpType _Type;

	private float _DefaultValue;

	private bool _UsePlus;

	private TextMeshProUGUI _Name;

	private TextMeshProUGUI _Value;

	private Image _Icon;

	private bool _IsPercentage;

	private bool _RoundToInt;

	private bool _MultiplyPowerUpByCharacterValue;

	public void SetData(PowerUpData data, PowerUpType t)
	{
		Localize component = _Name.GetComponent<Localize>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C7B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = data.GetPrefix(t);
		string term = prefix + "name";
		component.Term = term;
		Sprite sprite = SpriteManager.GetSprite(data._003CframeName_003Ek__BackingField, data._003Ctexture_003Ek__BackingField);
		_Icon.sprite = sprite;
	}

	public TextMeshProUGUI GetNameText()
	{
		return _Name;
	}

	public unsafe void SetValue(float finalvalue, bool hasPowerUp)
	{
		//IL_0044: Expected O, but got Ref
		string text = GetText(finalvalue);
		_Value.text = text;
		if (!hasPowerUp)
		{
		}
		object obj = default(object);
		_Value.color = (Color)(&obj);
	}

	public float GetDefaultValue()
	{
		return _DefaultValue;
	}

	public void SetValue(float finalValue)
	{
	}

	public void SetFormat(string s)
	{
		_Format = s;
	}

	private unsafe string GetText(float value)
	{
		//IL_005a: Expected I8, but got I
		//IL_0708: Invalid comparison between F4 and I4
		//IL_0088: Expected I8, but got I
		//IL_00c4: Expected I8, but got I
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected Ref, but got Unknown
		//IL_0101: Expected I8, but got I4
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected Ref, but got Unknown
		//IL_012e: Expected O, but got I4
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected Ref, but got Unknown
		//IL_0245: Expected I8, but got I4
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected Ref, but got Unknown
		//IL_0272: Expected O, but got I4
		//IL_027b: Expected O, but got I4
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected Ref, but got Unknown
		//IL_0369: Expected I8, but got I4
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected Ref, but got Unknown
		//IL_0396: Expected O, but got I4
		//IL_07d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dd: Expected Ref, but got Unknown
		//IL_07f4: Expected I8, but got I4
		//IL_07fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0802: Expected Ref, but got Unknown
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Expected Ref, but got Unknown
		//IL_04ad: Expected I8, but got I4
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Expected Ref, but got Unknown
		//IL_04da: Expected O, but got I4
		//IL_04e3: Expected O, but got I4
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Expected Ref, but got Unknown
		//IL_05c2: Expected I8, but got I4
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d1: Expected Ref, but got Unknown
		//IL_05ef: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A35AC]");
		bool flag = (nint)0 != 0;
		StatItemUI statItemUI = this;
		if (!flag)
		{
			_ = 1;
			statItemUI = (StatItemUI)(object)"";
		}
		string format = _Format;
		object obj = "health";
		if ((object)_Format != "health")
		{
			bool flag2 = _Format == null;
			IntPtr intPtr = default(IntPtr);
			ulong num = (ulong)(nint)intPtr;
			ref byte reference = ref *(byte*)statItemUI;
			object obj2 = default(object);
			if (!flag2)
			{
				bool flag3 = "health" == null;
				num = (ulong)(nint)intPtr;
				reference = ref *(byte*)statItemUI;
				if (!flag3)
				{
					int stringLength = format._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v1+10]");
					bool flag4 = (nint)stringLength != 0;
					num = (ulong)(nint)intPtr;
					reference = ref *(byte*)statItemUI;
					if (!flag4)
					{
						reference = ref *(byte*)(_Format + 20);
						num = (ulong)(format._stringLength + format._stringLength);
						bool flag5 = System.SpanHelpers.SequenceEqual(ref reference, ref *(byte*)("health" + 20), num);
						obj2 = 0;
						if (flag5)
						{
							goto IL_0959;
						}
					}
				}
			}
			ref byte reference2 = ref *(byte*)"flat";
			bool flag6 = (object)_Format == "flat";
			ref byte reference3 = ref *(byte*)"flat";
			if (!flag6)
			{
				bool flag7 = _Format == null;
				object obj3 = obj2;
				ulong num2 = num;
				ref byte reference4 = ref reference;
				if (!flag7)
				{
					bool flag8 = "flat" == null;
					obj3 = obj2;
					num2 = num;
					reference4 = ref reference;
					if (!flag8)
					{
						int stringLength2 = format._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v5 (System.Byte&)+10]");
						bool flag9 = (nint)stringLength2 != 0;
						obj3 = obj2;
						num2 = num;
						reference4 = ref reference;
						if (!flag9)
						{
							reference4 = ref *(byte*)(_Format + 20);
							num2 = (ulong)(format._stringLength + format._stringLength);
							bool flag10 = System.SpanHelpers.SequenceEqual(ref reference4, ref *(byte*)("flat" + 20), num2);
							obj3 = 0;
							obj2 = 0;
							num = num2;
							reference = ref reference4;
							if (flag10)
							{
								goto IL_06ff;
							}
						}
					}
				}
				object obj4 = "percentagePerSecond";
				if ((object)_Format != "percentagePerSecond")
				{
					bool flag11 = _Format == null;
					ref byte reference5 = ref reference4;
					if (!flag11)
					{
						bool flag12 = "percentagePerSecond" == null;
						reference5 = ref reference4;
						if (!flag12)
						{
							int stringLength3 = format._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rdx_v15+10]");
							bool flag13 = (nint)stringLength3 != 0;
							reference5 = ref reference4;
							if (!flag13)
							{
								reference5 = ref *(byte*)(_Format + 20);
								num2 = (ulong)(format._stringLength + format._stringLength);
								bool flag14 = System.SpanHelpers.SequenceEqual(ref reference5, ref *(byte*)("percentagePerSecond" + 20), num2);
								obj3 = 0;
								if (flag14)
								{
									goto IL_06df;
								}
							}
						}
					}
					ref byte reference6 = ref *(byte*)"percentage1";
					bool flag15 = (object)_Format == "percentage1";
					ref byte reference7 = ref *(byte*)"percentage1";
					if (!flag15)
					{
						bool flag16 = _Format == null;
						object obj5 = obj3;
						ulong num3 = num2;
						ref byte reference8 = ref reference5;
						if (!flag16)
						{
							bool flag17 = "percentage1" == null;
							obj5 = obj3;
							num3 = num2;
							reference8 = ref reference5;
							if (!flag17)
							{
								int stringLength4 = format._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rdx_v20 (System.Byte&)+10]");
								bool flag18 = (nint)stringLength4 != 0;
								obj5 = obj3;
								num3 = num2;
								reference8 = ref reference5;
								if (!flag18)
								{
									reference8 = ref *(byte*)(_Format + 20);
									num3 = (ulong)(format._stringLength + format._stringLength);
									bool flag19 = System.SpanHelpers.SequenceEqual(ref reference8, ref *(byte*)("percentage1" + 20), num3);
									obj5 = 0;
									obj3 = 0;
									num2 = num3;
									reference5 = ref reference8;
									if (flag19)
									{
										goto IL_067d;
									}
								}
							}
						}
						ref byte reference9 = ref *(byte*)"percentagePlusOne";
						bool flag20 = (object)_Format == "percentagePlusOne";
						ref byte reference10 = ref *(byte*)"percentagePlusOne";
						if (!flag20)
						{
							if (_Format != null && "percentagePlusOne" != null)
							{
								int stringLength5 = format._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ rdx_v25 (System.Byte&)+10]");
								if ((nint)stringLength5 == 0)
								{
									ref byte reference11 = ref *(byte*)(_Format + 20);
									num3 = (ulong)(format._stringLength + format._stringLength);
									bool flag21 = System.SpanHelpers.SequenceEqual(ref reference11, ref *(byte*)("percentagePlusOne" + 20), num3);
									obj5 = 0;
									reference8 = ref reference11;
									if (flag21)
									{
										goto IL_060b;
									}
								}
							}
							return "";
						}
						goto IL_060b;
					}
					goto IL_067d;
				}
				goto IL_06df;
			}
			goto IL_06ff;
		}
		goto IL_0959;
		IL_067d:
		bool flag22 = value < 1f;
		string text = "";
		if (!flag22)
		{
			text = "+";
		}
		float num4 = value - 1f;
		float num5 = num4 * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int num6 = default(int);
		string text2 = num6.ToString();
		string result = text + text2 + "%";
		int num7 = default(int);
		if (num7 == 0)
		{
			result = "-";
		}
		return result;
		IL_0920:
		string text3;
		object obj6;
		if (text3 != obj6)
		{
			if (text3 != null && obj6 != null)
			{
				int stringLength6 = text3._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rdx_v6+10]");
				if ((nint)stringLength6 == 0)
				{
					ref byte first = ref *(byte*)(text3 + 20);
					ulong length = (ulong)(text3._stringLength + text3._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)(obj6 + 20), length))
					{
						goto IL_082a;
					}
				}
			}
			return text3;
		}
		goto IL_082a;
		IL_06df:
		float num8 = default(float);
		text3 = num8.ToString("F2");
		obj6 = "0.00";
		goto IL_0920;
		IL_082a:
		return "-";
		IL_06ff:
		bool flag23 = value < 0f;
		string text4 = "";
		if (!flag23)
		{
			text4 = "+";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text5 = System.Number.FormatSingle(value, null, currentInfo);
		text3 = text4 + text5;
		obj6 = "+0";
		goto IL_0920;
		IL_060b:
		float num9 = value + 1f;
		bool flag24 = num9 < 1f;
		string text6 = "";
		if (!flag24)
		{
			text6 = "+";
		}
		float num10 = value * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		string text7 = num6.ToString();
		string result2 = text6 + text7 + "%";
		int num11 = default(int);
		if (num11 == 0)
		{
			result2 = "-";
		}
		return result2;
		IL_0959:
		NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
		return System.Number.FormatSingle(value, "F0", currentInfo2);
	}

	public StatItemUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}

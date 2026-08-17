using System;
using UnityEngine;

namespace Doozy.Engine;

[Serializable]
public class MColor
{
	public string Name;

	public Color M50;

	public Color M100;

	public Color M200;

	public Color M300;

	public Color M400;

	public Color M500;

	public Color M600;

	public Color M700;

	public Color M800;

	public Color M900;

	public Color A100;

	public Color A200;

	public Color A400;

	public Color A700;

	public MColor(string name, Color m50, Color m100, Color m200, Color m300, Color m400, Color m500, Color m600, Color m700, Color m800, Color m900, Color a100, Color a200, Color a400, Color a700)
	{
		//IL_001e: Expected O, but got F4
		//IL_002d: Expected O, but got F4
		//IL_003c: Expected O, but got F4
		//IL_004b: Expected O, but got F4
		//IL_005a: Expected O, but got F4
		//IL_0069: Expected O, but got F4
		//IL_0078: Expected O, but got F4
		//IL_0087: Expected O, but got F4
		//IL_0096: Expected O, but got F4
		//IL_00a0: Expected O, but got I
		Name = name;
		M50 = (Color)m50.r;
		M100 = (Color)m100.r;
		M200 = (Color)m700.r;
		M300 = (Color)m800.r;
		M400 = (Color)m900.r;
		M500 = (Color)a100.r;
		M600 = (Color)a200.r;
		M700 = (Color)a400.r;
		M800 = (Color)a700.r;
		IntPtr intPtr = default(IntPtr);
		M900 = (Color)(nint)intPtr;
		object a701 = default(object);
		A100 = (Color)a701;
		object a702 = default(object);
		A200 = (Color)a702;
		object a703 = default(object);
		A400 = (Color)a703;
		object a704 = default(object);
		A700 = (Color)a704;
	}

	public unsafe MColor(string name, string m50Hex, string m100Hex, string m200Hex, string m300Hex, string m400Hex, string m500Hex, string m600Hex, string m700Hex, string m800Hex, string m900Hex, string a100Hex, string a200Hex, string a400Hex, string a700Hex)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Ref, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Ref, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Ref, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Ref, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Ref, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Ref, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected Ref, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected Ref, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected Ref, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected Ref, but got Unknown
		//IL_0137: Expected O, but got I
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected Ref, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected Ref, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected Ref, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected Ref, but got Unknown
		Name = name;
		bool flag = ColorUtility.TryParseHtmlString(m50Hex, out *(Color*)(this + 24));
		bool flag2 = ColorUtility.TryParseHtmlString(m100Hex, out *(Color*)(this + 40));
		bool flag3 = ColorUtility.TryParseHtmlString(m700Hex, out *(Color*)(this + 56));
		bool flag4 = ColorUtility.TryParseHtmlString(m800Hex, out *(Color*)(this + 72));
		bool flag5 = ColorUtility.TryParseHtmlString(m900Hex, out *(Color*)(this + 88));
		bool flag6 = ColorUtility.TryParseHtmlString(a100Hex, out *(Color*)(this + 104));
		bool flag7 = ColorUtility.TryParseHtmlString(a200Hex, out *(Color*)(this + 120));
		bool flag8 = ColorUtility.TryParseHtmlString(a400Hex, out *(Color*)(this + 136));
		bool flag9 = ColorUtility.TryParseHtmlString(a700Hex, out *(Color*)(this + 152));
		IntPtr intPtr = default(IntPtr);
		bool flag10 = ColorUtility.TryParseHtmlString((string)(nint)intPtr, out *(Color*)(this + 168));
		string htmlString = default(string);
		bool flag11 = ColorUtility.TryParseHtmlString(htmlString, out *(Color*)(this + 184));
		string htmlString2 = default(string);
		bool flag12 = ColorUtility.TryParseHtmlString(htmlString2, out *(Color*)(this + 200));
		string htmlString3 = default(string);
		bool flag13 = ColorUtility.TryParseHtmlString(htmlString3, out *(Color*)(this + 216));
		string htmlString4 = default(string);
		bool flag14 = ColorUtility.TryParseHtmlString(htmlString4, out *(Color*)(this + 232));
	}
}

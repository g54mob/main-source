using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

public class FTUEArgs
{
	public RectTransform TgtXfm;

	public Vector2 VizPctSize;

	public Vector2 VizOffset;

	public Vector2 DescOffset;

	public float DescWidth;

	public string Desc;

	public List<LocalizationParamsManager.ParamValue> DescParams;

	public bool IsShowingBtn;

	public FTUEArgs()
	{
	}

	public FTUEArgs(RectTransform tgtXfm, Vector2 descOffset, float descWidth, string desc, bool showBtn, string paramName = null, string paramVal = null)
	{
	}

	public FTUEArgs(RectTransform tgtXfm, Vector2 vizOffset, Vector2 vizPctSize, Vector2 descOffset, float descWidth, string desc, bool showBtn, string paramName = null, string paramVal = null)
	{
	}

	public void AddDescParam(string paramName, string paramVal)
	{
	}
}

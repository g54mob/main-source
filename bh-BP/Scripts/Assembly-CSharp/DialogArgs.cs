using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

[Serializable]
public class DialogArgs
{
	public Sprite Img;

	public Color ImgColor;

	public string Txt;

	public List<LocalizationParamsManager.ParamValue> TxtParams;

	public bool ShowOk;

	public string OkText;

	public Action OnOk;

	public bool ShowCancel;

	public string CancelText;

	public Action OnCancel;

	public bool DefaultFocusOk;

	public void AddParam(string paramName, string val)
	{
	}
}

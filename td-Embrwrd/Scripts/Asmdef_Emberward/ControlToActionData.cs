using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ControlToActionData
{
	[Serializable]
	public class ExtraActionData
	{
		public eInputAction action;

		public string locKey;
	}

	[Header("Control Scheme類型")]
	public eControlScheme controlScheme;

	[Header("要顯示的Action")]
	public List<eInputAction> inputAction;

	[Header("額外不包含在Action清單中，要顯示資料")]
	public List<ExtraActionData> extraActionData;
}

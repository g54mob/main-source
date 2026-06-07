using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/遙控器操控提示設定 (ControllerActionTipData)", order = 1)]
public class ControllerActionTipData : ScriptableObject
{
	[SerializeField]
	private List<ControlToActionData> list_ControlToActionData;

	public ControlToActionData GetDataByControlScheme(eControlScheme scheme)
	{
		return null;
	}
}

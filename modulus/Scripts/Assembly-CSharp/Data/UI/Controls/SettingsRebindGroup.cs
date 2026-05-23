using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data.UI.Controls
{
	[CreateAssetMenu(fileName = "SettingsRebindGroup", menuName = "General/Settings/RebindGroup")]
	public class SettingsRebindGroup : ScriptableObject
	{
		[SerializeField]
		[LocaKey]
		private string _groupLocName;

		[Space]
		[SerializeField]
		[FormerlySerializedAs("_rebindables")]
		private SettingsRebindActionData[] _rebindActionDatas;

		public IReadOnlyList<SettingsRebindActionData> RebindActionDatas => _rebindActionDatas;

		public string GetLocalizedName()
		{
			return LocalizationUtility.GetLocalizedText(_groupLocName);
		}
	}
}

using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Settings/UI/StringSettings")]
	public class SettingCreatorString : SettingCreator<string>
	{
		[SerializeField]
		private UISetting<string> _prefab;

		public override UISetting Spawn(Transform parent)
		{
			UISetting<string> uISetting = CTSFactory.Instantiate(_prefab, parent, instantiateInWorldSpace: false, false);
			uISetting.Initialize(base.Setting, base.SettingName);
			uISetting.gameObject.SetActive(value: true);
			return uISetting;
		}
	}
}

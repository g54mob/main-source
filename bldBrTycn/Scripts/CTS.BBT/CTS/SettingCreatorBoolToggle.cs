using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Settings/UI/Bool Toggle")]
	public class SettingCreatorBoolToggle : SettingCreator<bool>
	{
		[SerializeField]
		private UISetting<bool> _prefab;

		public override UISetting Spawn(Transform parent)
		{
			UISetting<bool> uISetting = CTSFactory.Instantiate(_prefab, parent, instantiateInWorldSpace: false, false);
			uISetting.Initialize(base.Setting, base.SettingName);
			uISetting.gameObject.SetActive(value: true);
			return uISetting;
		}
	}
}

using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Settings/UI/Bool Graphics Toggle")]
	public class SettingCreatorEnumToggle : SettingCreator<FullScreenMode>
	{
		[SerializeField]
		private UISetting<FullScreenMode> _prefab;

		public override UISetting Spawn(Transform parent)
		{
			UISetting<FullScreenMode> uISetting = CTSFactory.Instantiate(_prefab, parent, false, (bool?)null, (IConstructor<UISetting<FullScreenMode>>)null);
			uISetting.Initialize(base.Setting, base.SettingName);
			uISetting.gameObject.SetActive(value: true);
			return uISetting;
		}
	}
}

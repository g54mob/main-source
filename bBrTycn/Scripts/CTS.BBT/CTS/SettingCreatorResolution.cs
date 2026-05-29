using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Settings/UI/Vector2Int")]
	public class SettingCreatorResolution : SettingCreator<Vector2Int>
	{
		[SerializeField]
		private UISetting<Vector2Int> _prefab;

		public override UISetting Spawn(Transform parent)
		{
			UISetting<Vector2Int> uISetting = CTSFactory.Instantiate(_prefab, parent, instantiateInWorldSpace: false, false);
			uISetting.Initialize(base.Setting, base.SettingName);
			uISetting.gameObject.SetActive(value: true);
			return uISetting;
		}
	}
}

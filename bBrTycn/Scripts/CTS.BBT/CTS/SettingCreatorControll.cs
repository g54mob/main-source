using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Settings/UI/Controll")]
	public class SettingCreatorControll : SettingCreator
	{
		[SerializeField]
		private UISettingControl _prefab;

		public override UISetting Spawn(Transform parent)
		{
			return CTSFactory.Instantiate(_prefab, parent, instantiateInWorldSpace: false, true);
		}
	}
}

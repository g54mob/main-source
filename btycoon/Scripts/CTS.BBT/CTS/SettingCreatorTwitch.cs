using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Settings/UI/Twitch")]
	public class SettingCreatorTwitch : SettingCreator
	{
		[SerializeField]
		private UISettingTwitch _prefab;

		public override UISetting Spawn(Transform parent)
		{
			return CTSFactory.Instantiate(_prefab, parent, instantiateInWorldSpace: false, true);
		}
	}
}

using ScheduleOne.Core.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.Core.Equipping
{
	public class ThirdPersonEquippableAlignmentHelper : MonoBehaviour
	{
		private const string HelperAvatarPrefabPath = "TPHelperAvatar";

		private TPEquippedItem _equippedItem;

		private GameObject _helperAvatarInstance;

		[Button("Show Helper", "!_helperAvatarInstance")]
		public void ShowHelper()
		{
		}

		private void OnValidate()
		{
		}

		[Button("Hide Helper", "_helperAvatarInstance")]
		public void HideHelper()
		{
		}

		private void RefreshHelperAlignment()
		{
		}
	}
}

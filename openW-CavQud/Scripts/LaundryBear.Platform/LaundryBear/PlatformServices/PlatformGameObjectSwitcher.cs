using UnityEngine;

namespace LaundryBear.PlatformServices
{
	public class PlatformGameObjectSwitcher : MonoBehaviour
	{
		[SerializeField]
		private Platform m_enabledForPlatforms;

		private void OnEnable()
		{
			if ((Utilities.GetCurrentPlatform() & m_enabledForPlatforms) > Platform.None)
			{
				base.gameObject.SetActive(value: true);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}

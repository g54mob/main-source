using UnityEngine;

namespace Huey.Game
{
	public class ShowObjectOnSelectedPlatforms : MonoBehaviour
	{
		[Tooltip("Select the platforms that you want this object to be visible on")]
		[SerializeField]
		private EPlatforms platformToShowOn;

		[Tooltip("Enable this if you want this game object to be visible on the demo version")]
		[SerializeField]
		private bool showOnDemo = true;

		[Tooltip("Enable this if you want this script to run each time Start, Awake or OnEnable is called")]
		[SerializeField]
		private bool runOnEveryCallback;

		private bool hasRunOnce;

		private void Awake()
		{
			Evaluate();
		}

		private void OnEnable()
		{
			Evaluate();
		}

		private void Evaluate()
		{
			if (runOnEveryCallback || !hasRunOnce)
			{
				base.transform.gameObject.SetActive(platformToShowOn.HasFlag(GetCurrentPlatform()));
				hasRunOnce = true;
			}
		}

		private EPlatforms GetCurrentPlatform()
		{
			return EPlatforms.Steam;
		}
	}
}

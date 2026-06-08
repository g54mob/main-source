using System.Collections.Generic;
using Dorfromantik.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Dorfromantik
{
	public class UiPlatformVisibility : MonoBehaviour
	{
		[SerializeField]
		[FormerlySerializedAs("disableOnPlatform")]
		private List<RuntimePlatform> targetPlatforms = new List<RuntimePlatform> { RuntimePlatform.Switch };

		[SerializeField]
		private bool shouldShow;

		[SerializeField]
		private UnityEvent onHide;

		[SerializeField]
		private bool initializeOnAwake;

		[SerializeField]
		private bool ignoreCurrentHideableUiState;

		private void Awake()
		{
			if (initializeOnAwake)
			{
				SetupVisibility();
			}
		}

		private void SetupVisibility()
		{
			bool flag = (targetPlatforms.Contains(Application.platform) ? shouldShow : (!shouldShow));
			HideableUi component = GetComponent<HideableUi>();
			if ((bool)component)
			{
				if (!flag || component.IsShown)
				{
					component.Show(flag, shouldAnimate: false);
				}
				if (!flag)
				{
					component.Lock(shouldLock: true, HideableUi.LockType.LockedForever);
				}
			}
			else
			{
				base.gameObject.SetActive(flag);
			}
			if (!shouldShow)
			{
				onHide?.Invoke();
			}
		}

		private void Start()
		{
			if (!initializeOnAwake)
			{
				SetupVisibility();
			}
		}
	}
}

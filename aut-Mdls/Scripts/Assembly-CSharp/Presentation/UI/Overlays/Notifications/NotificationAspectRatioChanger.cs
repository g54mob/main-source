using System.Collections;
using Events;
using UnityEngine;

namespace Presentation.UI.Overlays.Notifications
{
	public class NotificationAspectRatioChanger : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private BaseEvent<float> _QuestUIHeightChangedEvent;

		private Coroutine _watchResolutionCoroutine;

		private void OnEnable()
		{
			_watchResolutionCoroutine = StartCoroutine(WatchResolution());
		}

		private void OnDisable()
		{
			StopCoroutine(_watchResolutionCoroutine);
		}

		private IEnumerator WatchResolution()
		{
			int w = Screen.width;
			int h = Screen.height;
			while (true)
			{
				if (w != Screen.width || h != Screen.height)
				{
					w = Screen.width;
					h = Screen.height;
					yield return null;
					_QuestUIHeightChangedEvent.Fire(_rectTransform.rect.height);
				}
				yield return new WaitForSeconds(1f);
			}
		}
	}
}

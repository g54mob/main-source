using UnityEngine;

namespace Restory.UI.Presenters.PC.Notifications
{
	public abstract class GUI_PcNotificationBase : MonoBehaviour
	{
		[SerializeField]
		private RectTransform rectTransform;

		private void OnEnable()
		{
			rectTransform.anchoredPosition = Vector2.zero;
		}
	}
}

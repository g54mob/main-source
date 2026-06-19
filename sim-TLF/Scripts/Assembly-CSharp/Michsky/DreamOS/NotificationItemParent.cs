using System.Collections;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class NotificationItemParent : MonoBehaviour
	{
		[Header("Resources")]
		public UIPopup clearPanel;

		public UIPopup emptyPanel;

		private bool clearInProgress;

		private bool isCleared = true;

		private void OnEnable()
		{
			clearInProgress = false;
			UpdateState();
		}

		public void UpdateState()
		{
			if (!isCleared && base.transform.childCount == 0)
			{
				emptyPanel.PlayIn();
				clearPanel.PlayOut();
				isCleared = true;
			}
			else if (isCleared && base.transform.childCount > 0)
			{
				emptyPanel.PlayOut();
				clearPanel.PlayIn();
				isCleared = false;
			}
		}

		public void Clear()
		{
			if (clearInProgress)
			{
				return;
			}
			clearInProgress = true;
			foreach (Transform item in base.transform)
			{
				NotificationItem component = item.GetComponent<NotificationItem>();
				if (component != null)
				{
					component.Close();
				}
			}
			StartCoroutine(WaitForClear());
		}

		private IEnumerator WaitForClear()
		{
			while (base.transform.childCount > 0)
			{
				yield return null;
			}
			emptyPanel.PlayIn();
			clearPanel.PlayOut();
			clearInProgress = false;
		}
	}
}

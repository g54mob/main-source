using UnityEngine;

namespace Michsky.DreamOS
{
	public class EmptyChildIndicator : MonoBehaviour
	{
		[SerializeField]
		private Transform targetParent;

		[SerializeField]
		private GameObject targetIndicator;

		private void OnEnable()
		{
			CheckForParent();
		}

		public void CheckForParent()
		{
			if (targetParent.childCount > 0)
			{
				targetIndicator.SetActive(value: false);
			}
			else
			{
				targetIndicator.SetActive(value: true);
			}
		}
	}
}

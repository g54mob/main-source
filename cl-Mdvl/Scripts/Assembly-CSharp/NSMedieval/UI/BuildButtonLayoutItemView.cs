using UnityEngine;

namespace NSMedieval.UI
{
	public class BuildButtonLayoutItemView : ButtonLayoutItemView
	{
		private int notificationIndex = 5;

		private int highlightIndex = 6;

		private int variantIconIndex = 7;

		public bool NotificationEnabled => base.GroupItems[notificationIndex].activeInHierarchy;

		public void EnableVariantIcon(bool enable)
		{
			base.GroupItems[variantIconIndex].SetActive(enable);
		}

		public void EnableNotification(bool enable)
		{
			base.GroupItems[notificationIndex].SetActive(enable);
		}

		public void EnableHighlight(bool enable)
		{
			Animator component = base.GroupItems[highlightIndex].GetComponent<Animator>();
			component.gameObject.SetActive(enable);
			if (enable)
			{
				component.Play("DamageBlinkAnimation");
			}
		}
	}
}

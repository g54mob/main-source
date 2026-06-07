using UnityEngine;

namespace DV.UIFramework
{
	public class UIOptimizedEnableDisable : MonoBehaviour
	{
		public Transform activeParent;

		public Transform disabledParent;

		public bool IsActivated
		{
			get
			{
				if (base.gameObject.activeSelf)
				{
					return activeParent.Equals(base.transform.parent);
				}
				return false;
			}
		}

		public void Disable()
		{
			base.gameObject.SetActive(value: false);
			base.transform.SetParent(disabledParent, worldPositionStays: false);
		}

		public void Enable(int siblingIndex = -1)
		{
			base.transform.SetParent(activeParent, worldPositionStays: false);
			if (siblingIndex != -1)
			{
				base.transform.SetSiblingIndex(siblingIndex);
			}
			base.gameObject.SetActive(value: true);
		}
	}
}

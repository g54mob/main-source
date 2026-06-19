using UnityEngine;

namespace TH20
{
	public class RibbonMenuBarAnimator
	{
		public enum State
		{
			Default = 0,
			Build = 1,
			Hire = 2
		}

		private RibbonMenuBarAnimatorParams _params;

		private GameObject[] _previousEnabledGameObjects;

		public RibbonMenuBarAnimator(RibbonMenuBarAnimatorParams ribbonMenuBarAnimatorParams)
		{
			_params = ribbonMenuBarAnimatorParams;
		}

		public void Transition(int barWidth, int leftSectionWidth, GameObject[] gameObjectsToEnable)
		{
			TransitionInstantly(_params, barWidth, leftSectionWidth, gameObjectsToEnable, _previousEnabledGameObjects);
			_previousEnabledGameObjects = gameObjectsToEnable;
		}

		public static void TransitionInstantly(RibbonMenuBarAnimatorParams param, int barWidth, int leftSectionWidth, GameObject[] gameObjectsToEnable, GameObject[] previousEnabledGameObjects)
		{
			param.RibbonBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, barWidth);
			param.BarLeftSection.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, leftSectionWidth);
			param.BarRightSection.anchoredPosition = new Vector2(leftSectionWidth, 0f);
			param.BarRightSection.sizeDelta = new Vector2(-leftSectionWidth, 0f);
			if (previousEnabledGameObjects != null)
			{
				for (int i = 0; i < previousEnabledGameObjects.Length; i++)
				{
					if (!ContainsPrevious(gameObjectsToEnable, previousEnabledGameObjects[i]))
					{
						GameObjectUtils.SetActive(previousEnabledGameObjects[i], isActive: false);
					}
				}
			}
			if (gameObjectsToEnable != null)
			{
				for (int j = 0; j < gameObjectsToEnable.Length; j++)
				{
					GameObjectUtils.SetActive(gameObjectsToEnable[j], isActive: true);
				}
			}
		}

		private static bool ContainsPrevious(GameObject[] gameObjectsToEnable, GameObject gameObject)
		{
			if (gameObjectsToEnable == null)
			{
				return false;
			}
			for (int i = 0; i < gameObjectsToEnable.Length; i++)
			{
				if (gameObjectsToEnable[i] == gameObject)
				{
					return true;
				}
			}
			return false;
		}
	}
}

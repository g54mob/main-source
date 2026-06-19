using System;
using UnityEngine;

namespace TH20
{
	public class RibbonMenuBodyAnimator
	{
		[Serializable]
		public struct Target
		{
			public int BodyHeight;

			public int BackgroundWidth;

			public int ScrollViewWidth;

			public int RowsScrollViewportLeftInset;

			public int RowsScrollViewportWidth;
		}

		private RibbonMenuBodyAnimatorParams _params;

		private GameObject[] _previousEnabledGameObjects;

		public RibbonMenuBodyAnimator(RibbonMenuBodyAnimatorParams ribbonMenuBodyAnimatorParams)
		{
			_params = ribbonMenuBodyAnimatorParams;
		}

		public void Transition(ref Target target, GameObject[] gameObjectsToEnable)
		{
			TransitionInstantly(_params, ref target, gameObjectsToEnable, _previousEnabledGameObjects);
			_previousEnabledGameObjects = gameObjectsToEnable;
		}

		public static void TransitionInstantly(RibbonMenuBodyAnimatorParams param, ref Target target, GameObject[] gameObjectsToEnable, GameObject[] previousEnabledGameObjects)
		{
			param.Body.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 158f, target.BodyHeight);
			param.Background.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, target.BackgroundWidth);
			param.ScrollView.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, target.ScrollViewWidth);
			param.RowsScrollViewport.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, target.RowsScrollViewportLeftInset, target.RowsScrollViewportWidth);
			if (previousEnabledGameObjects != null)
			{
				for (int i = 0; i < previousEnabledGameObjects.Length; i++)
				{
					if (!ContainsPrevious(gameObjectsToEnable, previousEnabledGameObjects[i]))
					{
						previousEnabledGameObjects[i].SetActive(value: false);
					}
				}
			}
			if (gameObjectsToEnable != null)
			{
				for (int j = 0; j < gameObjectsToEnable.Length; j++)
				{
					gameObjectsToEnable[j].SetActive(value: true);
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

using System;
using System.Collections.Generic;
using PimDeWitte.UnityMainThreadDispatcher;
using UnityEngine;

public class LinearLayoutUIComponent : UIComponentMonoBehaviour
{
	public bool horizontal;

	public bool reversed;

	public int gapBetweenItems;

	public float paddingStart;

	public float paddingEnd;

	public SpriteRenderer background;

	public bool renderFrameLate;

	private float width;

	private float height;

	public override void RenderUIComponent(bool force = false)
	{
		if (!(Dirty || force))
		{
			return;
		}
		if (renderFrameLate)
		{
			UnityMainThreadDispatcher.Instance().Enqueue(delegate
			{
				RenderUIComponentLate(force);
			});
		}
		else
		{
			RenderUIComponentLate(force);
		}
	}

	private void RenderUIComponentLate(bool force)
	{
		base.RenderUIComponent(force);
		SpaceUIComponentChildren();
		UpdateBackground();
	}

	protected override bool IsUIComponentRenderingDependentOnChildren()
	{
		return true;
	}

	private void SpaceUIComponentChildren()
	{
		if (horizontal)
		{
			float num = 0.0625f * paddingStart;
			float num2 = 0.0625f * (float)gapBetweenItems;
			List<UIComponentMonoBehaviour> directUIComponentChildren = GetDirectUIComponentChildren();
			height = 0f;
			for (int i = 0; i < directUIComponentChildren.Count; i++)
			{
				UIComponentMonoBehaviour uIComponentMonoBehaviour = directUIComponentChildren[i];
				if (PlatformStorefrontUtility.MatchesCurrent(uIComponentMonoBehaviour.activeInPlatforms, uIComponentMonoBehaviour.activeInStoreFronts))
				{
					num = UIManager.PositionElementToRight(uIComponentMonoBehaviour.transform, num, uIComponentMonoBehaviour.GetUIComponentRenderWidth(), (i != 0) ? num2 : 0f, uIComponentMonoBehaviour.GetUIComponentRenderHeight(), uIComponentMonoBehaviour.GetUIComponentPivotPosition() == PivotPosition.MiddleLeft);
					height = Math.Max(height, uIComponentMonoBehaviour.GetUIComponentRenderHeight());
				}
			}
			width = (reversed ? (0f - num) : num);
		}
		else if (reversed)
		{
			float num3 = 0.0625f * paddingStart;
			float num4 = 0.0625f * (float)gapBetweenItems;
			List<UIComponentMonoBehaviour> directUIComponentChildren2 = GetDirectUIComponentChildren();
			width = 0f;
			for (int num5 = directUIComponentChildren2.Count - 1; num5 >= 0; num5--)
			{
				UIComponentMonoBehaviour uIComponentMonoBehaviour2 = directUIComponentChildren2[num5];
				if (PlatformStorefrontUtility.MatchesCurrent(uIComponentMonoBehaviour2.activeInPlatforms, uIComponentMonoBehaviour2.activeInStoreFronts) && uIComponentMonoBehaviour2.gameObject.activeInHierarchy)
				{
					num3 = UIManager.PositionElementAbove(uIComponentMonoBehaviour2.transform, num3, uIComponentMonoBehaviour2.GetUIComponentRenderHeight(), (num5 != directUIComponentChildren2.Count - 1) ? num4 : 0f, uIComponentMonoBehaviour2.GetUIComponentPivotPosition() == PivotPosition.MiddleLeft, setXToZero: false, uIComponentMonoBehaviour2.GetUIComponentPivotPosition() == PivotPosition.TopLeft);
					width = Math.Max(width, uIComponentMonoBehaviour2.GetUIComponentRenderWidth());
				}
			}
			height = 0f - num3;
		}
		else
		{
			float num6 = 0.0625f * (0f - paddingStart);
			float num7 = 0.0625f * (float)gapBetweenItems;
			List<UIComponentMonoBehaviour> directUIComponentChildren3 = GetDirectUIComponentChildren();
			width = 0f;
			for (int j = 0; j < directUIComponentChildren3.Count; j++)
			{
				UIComponentMonoBehaviour uIComponentMonoBehaviour3 = directUIComponentChildren3[j];
				if (PlatformStorefrontUtility.MatchesCurrent(uIComponentMonoBehaviour3.activeInPlatforms, uIComponentMonoBehaviour3.activeInStoreFronts) && uIComponentMonoBehaviour3.gameObject.activeInHierarchy)
				{
					num6 = UIManager.PositionElementBeneath(uIComponentMonoBehaviour3.transform, num6, uIComponentMonoBehaviour3.GetUIComponentRenderHeight(), (j != 0) ? num7 : 0f, uIComponentMonoBehaviour3.GetUIComponentPivotPosition() == PivotPosition.MiddleLeft);
					width = Math.Max(width, uIComponentMonoBehaviour3.GetUIComponentRenderWidth());
				}
			}
			height = 0f - num6;
		}
		if (!horizontal)
		{
			return;
		}
		List<UIComponentMonoBehaviour> directUIComponentChildren4 = GetDirectUIComponentChildren();
		for (int k = 0; k < directUIComponentChildren4.Count; k++)
		{
			UIComponentMonoBehaviour uIComponentMonoBehaviour4 = directUIComponentChildren4[k];
			if (PlatformStorefrontUtility.MatchesCurrent(uIComponentMonoBehaviour4.activeInPlatforms, uIComponentMonoBehaviour4.activeInStoreFronts) && uIComponentMonoBehaviour4.centerInParent)
			{
				Transform obj = uIComponentMonoBehaviour4.transform;
				Vector3 localPosition = obj.localPosition;
				float num8 = 0f;
				float num9 = 0f;
				if (uIComponentMonoBehaviour4.GetUIComponentPivotPosition() == PivotPosition.TopLeft)
				{
					num9 = 0.5f;
				}
				float num10 = height / 2f - uIComponentMonoBehaviour4.GetUIComponentRenderHeight() * num9;
				obj.localPosition = new Vector3(y: num8 - (num10 - num10 % 0.0625f), x: localPosition.x, z: 0f);
			}
		}
	}

	private void UpdateBackground()
	{
		if (!(background == null))
		{
			Vector2 size = background.size;
			if (horizontal)
			{
				size.x = GetUIComponentRenderWidth();
				background.transform.localPosition = new Vector3((0f - size.x) / 2f, 0f, 0f);
			}
			else
			{
				size.y = GetUIComponentRenderHeight();
				Transform obj = background.transform;
				obj.localPosition = new Vector3(obj.localPosition.x, (0f - size.y) / 2f, 0f);
			}
			background.size = size;
		}
	}

	public override float GetUIComponentRenderWidth()
	{
		if (!horizontal)
		{
			return width;
		}
		return width + 0.0625f * paddingEnd;
	}

	public override float GetUIComponentRenderHeight()
	{
		if (!horizontal)
		{
			return height + 0.0625f * paddingEnd;
		}
		return height;
	}
}

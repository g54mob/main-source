using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public abstract class UIComponentMonoBehaviour : MonoBehaviour
{
	public enum PivotPosition
	{
		TopLeft = 0,
		MiddleLeft = 1
	}

	public bool centerInParent;

	public PlatformFlags activeInPlatforms = (PlatformFlags)(-1);

	public StorefrontFlags activeInStoreFronts = (StorefrontFlags)(-1);

	protected bool Dirty;

	private TimerSimple _previewRefreshTimer = new TimerSimple(0.25f);

	protected virtual void OnEnable()
	{
		MarkUIComponentAsDirty();
	}

	protected virtual void OnDisable()
	{
		MarkUIComponentAsDirty();
	}

	public virtual void RenderUIComponent(bool force = false)
	{
		if (Dirty || force)
		{
			if (!PlatformStorefrontUtility.MatchesCurrent(activeInPlatforms, activeInStoreFronts))
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			RenderUIComponentChildren(force);
			Dirty = false;
		}
	}

	public virtual float GetUIComponentRenderWidth()
	{
		return 0f;
	}

	public virtual float GetUIComponentRenderHeight()
	{
		return 0f;
	}

	protected virtual bool IsUIComponentRenderingDependentOnChildren()
	{
		return false;
	}

	public void MarkUIComponentAsDirty(bool render = false)
	{
		Dirty = true;
		if (base.transform.parent != null)
		{
			UIComponentMonoBehaviour component = base.transform.parent.GetComponent<UIComponentMonoBehaviour>();
			if (component != null && component.IsUIComponentRenderingDependentOnChildren())
			{
				component.MarkUIComponentAsDirty(render);
			}
			else if (render)
			{
				RenderUIComponent();
			}
		}
	}

	public virtual PivotPosition GetUIComponentPivotPosition()
	{
		return PivotPosition.TopLeft;
	}

	private void RenderUIComponentChildren(bool force = false)
	{
		GetDirectUIComponentChildren().ForEach(delegate(UIComponentMonoBehaviour component)
		{
			component.RenderUIComponent(force);
		});
	}

	protected List<UIComponentMonoBehaviour> GetDirectUIComponentChildren()
	{
		List<UIComponentMonoBehaviour> list = new List<UIComponentMonoBehaviour>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			if (child.gameObject.activeInHierarchy)
			{
				UIComponentMonoBehaviour component = child.GetComponent<UIComponentMonoBehaviour>();
				if (component != null)
				{
					list.Add(component);
				}
			}
		}
		return list;
	}

	public void RenderUIComponentOrphans(bool force = false)
	{
		foreach (UIComponentMonoBehaviour allUIComponentChild in GetAllUIComponentChildren())
		{
			if (allUIComponentChild != this && allUIComponentChild.transform.parent != null && allUIComponentChild.transform.parent.GetComponent<UIComponentMonoBehaviour>() == null)
			{
				allUIComponentChild.RenderUIComponent(force);
			}
		}
	}

	protected List<UIComponentMonoBehaviour> GetAllUIComponentChildren()
	{
		List<UIComponentMonoBehaviour> list = new List<UIComponentMonoBehaviour>();
		GetComponentsInChildren(list);
		return list;
	}

	private void ScrollIntoView()
	{
		float num = 0f;
		Transform parent = base.transform;
		while (parent != null)
		{
			ScrollableUIComponent component = parent.parent.GetComponent<ScrollableUIComponent>();
			if (component != null)
			{
				component.ScrollTo(num, GetUIComponentRenderHeight());
				return;
			}
			UIScrollWindow component2 = parent.parent.GetComponent<UIScrollWindow>();
			if (component2 != null)
			{
				Transform scrollingContent = component2.scrollingContent;
				float num2 = base.transform.position.y - scrollingContent.position.y;
				float num3 = GetUIComponentRenderHeight() / 2f;
				if (GetUIComponentPivotPosition() == PivotPosition.TopLeft)
				{
					num2 -= num3;
				}
				component2.MoveScrollToIncludePosition(num2, num3);
				return;
			}
			num -= parent.localPosition.y;
			parent = parent.parent;
		}
		Debug.LogWarning("No scrollable UI component found to scroll into view.");
	}

	public void ScrollIntoViewIfNotUsingMouse()
	{
		if (!Manager.input.SystemIsUsingMouse())
		{
			ScrollIntoView();
		}
	}
}

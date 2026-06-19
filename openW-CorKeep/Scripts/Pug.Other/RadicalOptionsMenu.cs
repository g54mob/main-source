using UnityEngine;

public class RadicalOptionsMenu : RadicalMenu, IScrollable
{
	public SpriteRenderer background;

	public bool slimBackground;

	[Tooltip("Whether to write settings files to disk if they have been changed.")]
	public bool writeSettings;

	public UIComponentMonoBehaviour scrollingContent;

	private bool m_slimBackgroundOn;

	private Vector3 m_backgroundRestoreScale;

	private Vector3 m_backgroundRestorePosition;

	private Color m_backgroundRestoreColor;

	protected override void Awake()
	{
		base.Awake();
		m_backgroundRestoreScale = background.transform.localScale;
		m_backgroundRestorePosition = background.transform.localPosition;
		m_backgroundRestoreColor = background.color;
	}

	public override void Deactivate(bool pop)
	{
		if (writeSettings)
		{
			Manager.prefs.Write();
		}
		base.Deactivate(pop);
	}

	private void Update()
	{
		if (slimBackground && Manager.sceneHandler.isInGame && !m_slimBackgroundOn)
		{
			SetSlimBackground(value: true);
		}
		else if ((!slimBackground || !Manager.sceneHandler.isInGame) && m_slimBackgroundOn)
		{
			SetSlimBackground(value: false);
		}
	}

	public void UpdateContainingElements(float scroll)
	{
	}

	public bool IsBottomElementSelected()
	{
		for (int num = menuOptions.Count - 1; num >= 0; num--)
		{
			if (menuOptions[num].gameObject.activeInHierarchy)
			{
				return menuOptions[num] == Manager.ui.currentSelectedUIElement;
			}
		}
		return false;
	}

	public bool IsTopElementSelected()
	{
		for (int i = 0; i < menuOptions.Count; i++)
		{
			if (menuOptions[i].gameObject.activeInHierarchy)
			{
				return menuOptions[i] == Manager.ui.currentSelectedUIElement;
			}
		}
		return false;
	}

	public float GetCurrentWindowHeight()
	{
		return scrollingContent.GetUIComponentRenderHeight();
	}

	private void SetSlimBackground(bool value)
	{
		m_slimBackgroundOn = value;
		if (!m_slimBackgroundOn)
		{
			background.transform.localScale = m_backgroundRestoreScale;
			background.transform.localPosition = m_backgroundRestorePosition;
			background.color = m_backgroundRestoreColor;
			return;
		}
		RadicalMenuOption[] componentsInChildren = GetComponentsInChildren<RadicalMenuOption>(includeInactive: true);
		if (componentsInChildren == null || componentsInChildren.Length < 1)
		{
			return;
		}
		Rect rect = default(Rect);
		bool flag = false;
		foreach (RadicalMenuOption radicalMenuOption in componentsInChildren)
		{
			if (radicalMenuOption.gameObject.activeSelf)
			{
				Rect dimensions = radicalMenuOption.labelText.dimensions;
				Rect dimensions2 = radicalMenuOption.valueText.dimensions;
				dimensions.center += (Vector2)radicalMenuOption.labelText.transform.position;
				dimensions2.center += (Vector2)radicalMenuOption.valueText.transform.position;
				if (!flag)
				{
					rect = dimensions;
					flag = true;
				}
				rect.min = Vector2.Min(rect.min, dimensions.min);
				rect.max = Vector2.Max(rect.max, dimensions.max);
				rect.min = Vector2.Min(rect.min, dimensions2.min);
				rect.max = Vector2.Max(rect.max, dimensions2.max);
			}
		}
		float num = 1f;
		float num2 = Mathf.Max(0f - rect.min.x, rect.max.x) * 2f + num;
		float num3 = rect.height + num;
		Bounds localBounds = background.localBounds;
		float x = num2 / localBounds.size.x;
		float y = num3 / localBounds.size.y;
		background.transform.localScale = new Vector3(x, y, 1f);
		background.transform.localPosition = new Vector3(0f, rect.center.y, background.transform.localPosition.z);
		background.color = new Color(0f, 0f, 0f, 0.8f);
	}
}

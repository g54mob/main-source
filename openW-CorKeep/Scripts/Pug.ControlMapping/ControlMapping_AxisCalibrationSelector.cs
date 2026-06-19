using System;
using Pug.UnityExtensions;
using UnityEngine;

public class ControlMapping_AxisCalibrationSelector : RadicalMenuOption
{
	private const float WIDTH_USING_ICONS = 3f;

	private const float HEIGHT_USING_ICONS = 1.5f;

	private const float WIDTH_USING_TEXT = 8f;

	private const float HEIGHT_USING_TEXT = 1f;

	[SerializeField]
	private GameObject _selectedIndicator;

	[SerializeField]
	private GameObject _activeIndicator;

	public int AxisIndex { get; private set; } = -1;

	public event Action<int> Selected;

	public event Action<int> Activated;

	public void Setup(string axisName, int index, bool useControllerCharacters)
	{
		float x = (useControllerCharacters ? 3f : 8f);
		float num = (useControllerCharacters ? 1.5f : 1f);
		Vector2 size = new Vector2(x, num);
		SpriteRenderer[] componentsInChildren = GetComponentsInChildren<SpriteRenderer>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].size = size;
		}
		_selectedIndicator.transform.SetLocalPositionY(num / 2f);
		GetComponent<WrapperUIComponent>().renderHeightPixels = Mathf.RoundToInt(16f * num);
		BoxCollider component = GetComponent<BoxCollider>();
		component.size = new Vector3(size.x, size.y, component.size.z);
		AxisIndex = index;
		labelText.style.fontFace = (useControllerCharacters ? TextManager.FontFace.button : TextManager.FontFace.thinSmall);
		labelText.Render(axisName);
	}

	public void Clear()
	{
		SetActive(active: false);
	}

	public void SetActive(bool active)
	{
		if (active)
		{
			this.Activated?.Invoke(AxisIndex);
		}
		_activeIndicator.SetActive(active);
	}

	public override void OnSelected()
	{
		base.OnSelected();
		_selectedIndicator.SetActive(value: true);
		this.Selected?.Invoke(AxisIndex);
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		_selectedIndicator.SetActive(value: false);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		SetActive(active: true);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		Cleanup();
	}

	private void Cleanup()
	{
		this.Activated = null;
		this.Selected = null;
		AxisIndex = -1;
	}
}

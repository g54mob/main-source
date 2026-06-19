using System;
using UnityEngine;

public class ControlMapping_CategorySelector : RadicalMenuOption
{
	[SerializeField]
	private PugText _categoryName;

	[SerializeField]
	private GameObject _selectedIndicator;

	[SerializeField]
	private GameObject _activeIndicator;

	[SerializeField]
	private Transform _offset;

	[SerializeField]
	private SpriteRenderer[] _spriteRenderers;

	public int CategoryId { get; private set; } = -1;

	public event Action<ControlMapping_CategorySelector> CategoryActivated;

	public void Setup(int categoryId, string categoryLocaKey)
	{
		CategoryId = categoryId;
		_categoryName.Render(categoryLocaKey, rewindEffectAnims: false, force: true);
		float num = Mathf.Max(6f, _categoryName.GetUIComponentRenderWidth() * 2.2f);
		SpriteRenderer[] spriteRenderers = _spriteRenderers;
		foreach (SpriteRenderer obj in spriteRenderers)
		{
			Vector2 size = obj.size;
			size.x = num;
			obj.size = size;
		}
		Vector3 localPosition = _offset.localPosition;
		localPosition.x = num / 2f;
		_offset.localPosition = localPosition;
		GetComponent<WrapperUIComponent>().renderWidthPixels = (int)(num * 16f);
	}

	public override void OnActivated()
	{
		_activeIndicator.SetActive(value: true);
		this.CategoryActivated?.Invoke(this);
	}

	public override void OnSelected()
	{
		_selectedIndicator.SetActive(value: true);
		base.OnSelected();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		_selectedIndicator.SetActive(value: false);
		base.OnDeselected(playEffect);
	}

	public void SetActive(bool select)
	{
		_activeIndicator.SetActive(select);
		if (!select)
		{
			_selectedIndicator.SetActive(value: false);
		}
	}

	protected override void OnDisable()
	{
		Cleanup();
		base.OnDisable();
	}

	private void Cleanup()
	{
		this.CategoryActivated = null;
		CategoryId = -1;
		_categoryName.Render("", rewindEffectAnims: false, force: true);
		_selectedIndicator.SetActive(value: false);
		_activeIndicator.SetActive(value: false);
	}
}

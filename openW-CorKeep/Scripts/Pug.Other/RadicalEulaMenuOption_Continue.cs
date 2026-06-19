using UnityEngine;

public class RadicalEulaMenuOption_Continue : RadicalMenuOption
{
	[SerializeField]
	private SpriteRenderer _borderSpriteRenderer;

	[SerializeField]
	private Color _borderUnselectedColor;

	private Color _borderSelectedColor;

	private RadicalEulaMenu _eulaMenu;

	protected override void Awake()
	{
		if (_borderSpriteRenderer != null)
		{
			_borderSelectedColor = _borderSpriteRenderer.color;
		}
		base.Awake();
	}

	private void Start()
	{
		_eulaMenu = GetComponentInParent<RadicalEulaMenu>(includeInactive: true);
		_borderSpriteRenderer.color = _borderUnselectedColor;
	}

	public override void OnActivated()
	{
		_eulaMenu.AcceptPressed();
		base.OnActivated();
	}

	public override void OnSelected()
	{
		if (_borderSpriteRenderer != null)
		{
			_borderSpriteRenderer.color = _borderSelectedColor;
		}
		if (menuOptionEffects != null)
		{
			PugTextEffectMenuOption[] array = menuOptionEffects;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnSelected();
			}
		}
	}

	public override void OnDeselected(bool playEffect = true)
	{
		if (_borderSpriteRenderer != null)
		{
			_borderSpriteRenderer.color = _borderUnselectedColor;
		}
		if (menuOptionEffects == null)
		{
			return;
		}
		PugTextEffectMenuOption[] array = menuOptionEffects;
		foreach (PugTextEffectMenuOption pugTextEffectMenuOption in array)
		{
			if (playEffect)
			{
				pugTextEffectMenuOption.OnDeselected();
			}
			else
			{
				pugTextEffectMenuOption.EndEffectImmediate();
			}
		}
	}
}

using UnityEngine;

public class RadicalEulaMenuOption_Cancel : RadicalMenuOption
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
			if (!IsSelectionEnabled())
			{
				_borderSpriteRenderer.color = _borderUnselectedColor;
			}
		}
		base.Awake();
	}

	private void Start()
	{
		_eulaMenu = GetComponentInParent<RadicalEulaMenu>(includeInactive: true);
	}

	public override void OnActivated()
	{
		_eulaMenu.DeclinePressed();
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

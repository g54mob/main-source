using Unity.Mathematics;
using UnityEngine;

public class SelectParamValueOption : RadicalMenuOption
{
	private int _activeIndex = 2;

	public SpriteRenderer hoverSprite;

	public Animator animator;

	public PugText text;

	public Transform leftArrow;

	public Transform rightArrow;

	private bool _readOnly;

	private static string[] levels = new string[5] { "Menu/ParamOff", "Menu/ParamLow", "Menu/ParamNormal", "Menu/ParamHigh", "Menu/ParamExtreme" };

	public int activeIndex
	{
		get
		{
			return _activeIndex;
		}
		set
		{
			_activeIndex = value;
			UpdateText();
		}
	}

	public bool readOnly
	{
		get
		{
			return _readOnly;
		}
		set
		{
			_readOnly = value;
			leftArrow.gameObject.SetActive(!value);
			rightArrow.gameObject.SetActive(!value);
		}
	}

	public override void OnParentMenuActivation()
	{
		base.OnParentMenuActivation();
		UpdateText();
	}

	protected override void Awake()
	{
		base.Awake();
		hoverSprite.enabled = false;
	}

	public override void OnSelected()
	{
		base.OnSelected();
		hoverSprite.enabled = true;
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		hoverSprite.enabled = false;
	}

	public override void OnActivated()
	{
		base.OnActivated();
		if (!readOnly)
		{
			OnSkimRight();
		}
	}

	public override bool OnSkimLeft()
	{
		if (!readOnly)
		{
			SkimLeft();
		}
		return base.OnSkimLeft();
	}

	public void SkimLeft()
	{
		activeIndex--;
		if (activeIndex < 0)
		{
			activeIndex = levels.Length - 1;
		}
		UpdateText();
		AudioManager.SfxUI(SfxID.FIXME_menu_select, 1f, reuse: true, 1f, 0.15f, playOnGamepad: true);
		animator.SetTrigger(2063870753);
	}

	public override bool OnSkimRight()
	{
		if (!readOnly)
		{
			SkimRight();
		}
		return base.OnSkimRight();
	}

	public void SkimRight()
	{
		activeIndex = (activeIndex + 1) % levels.Length;
		UpdateText();
		AudioManager.SfxUI(SfxID.FIXME_menu_select, 1f, reuse: true, 1f, 0.15f, playOnGamepad: true);
		animator.SetTrigger(-1144262676);
	}

	private void UpdateText()
	{
		if (activeIndex < 0)
		{
			activeIndex = levels.Length - 1;
		}
		string text = levels[activeIndex];
		this.text.Render(text);
		this.text.SetTempColor((activeIndex == 2) ? Manager.text.rarityTextColors[0] : Manager.text.rarityTextColors[1], keepColorOnStart: true);
		float num = this.text.dimensions.width / 2f + 0.625f;
		num += num % 0.125f;
		leftArrow.localPosition = new Vector3(math.min(-2.3125f, 0f - num), -0.0625f, 0f);
		rightArrow.localPosition = new Vector3(math.max(2.3125f, num), -0.0625f, 0f);
		float y = this.text.dimensions.size.y + this.text.dimensions.size.y % 0.125f;
		float x = this.text.dimensions.size.x + this.text.dimensions.size.x % 0.125f + 0.375f;
		hoverSprite.size = new Vector2(x, y);
		leftArrow.gameObject.SetActive(activeIndex > 0);
		rightArrow.gameObject.SetActive(activeIndex < levels.Length - 1);
	}
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class BinaryImageSwitcher : ActiveComponent
{
	private Sprite[] images = new Sprite[2];

	private Image buttonImage;

	private Button button;

	public Sprite inactiveSprite;

	public Sprite activeSprite;

	public Action activeAction;

	public Action inactiveAction;

	private bool interactible = true;

	public int SwitcherState { get; private set; }

	public bool Interactible
	{
		get
		{
			return button.interactable;
		}
		set
		{
			button.interactable = value;
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		buttonImage = base.gameObject.GetComponent<Image>();
		button = base.gameObject.GetComponent<Button>();
		button.onClick.AddListener(Switch);
	}

	public void Switch()
	{
		SwitcherState = 1 - SwitcherState;
		buttonImage.sprite = images[SwitcherState];
		if (SwitcherState == 0 && inactiveAction != null)
		{
			inactiveAction();
		}
		else if (activeAction != null)
		{
			activeAction();
		}
	}

	public override void Init()
	{
		throw new NotImplementedException("Use Init(Action inactiveAction = null, Action activeAction = null)");
	}

	public void Init(Action inactiveAction = null, Action activeAction = null)
	{
		base.Init();
		this.inactiveAction = inactiveAction;
		this.activeAction = activeAction;
		SwitcherState = 0;
		images[0] = inactiveSprite;
		images[1] = activeSprite;
		buttonImage.sprite = images[0];
	}
}

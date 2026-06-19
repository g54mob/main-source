using FMODUnity;
using OUSystems.Basics.DataStructures;
using OUSystems.Basics.UI;
using UnityEngine;
using UnityEngine.UI;

public class GameHUDSprintSymbol : ClickListener
{
	[SerializeField]
	private Image _buttonImage;

	public Sprite DefaultSprite;

	public Sprite ActiveSprite;

	private int _disableStacks;

	public BoolContainer Locked;

	public EventReference OnSound;

	public EventReference OffSound;

	public void Unlock()
	{
	}

	private void Start()
	{
	}

	public void AddEnableStack()
	{
	}

	public void RemoveEnableStack()
	{
	}

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetSprinting(bool sprinting)
	{
	}

	public override void Click()
	{
	}
}

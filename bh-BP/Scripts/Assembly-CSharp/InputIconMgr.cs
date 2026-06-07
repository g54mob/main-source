using Rewired;
using UnityEngine;

public class InputIconMgr : MonoBehaviour
{
	public static InputIconMgr I;

	[NamedArray(typeof(ControllerBtn))]
	public Sprite[] ControllerBtnSprites_XBox;

	[NamedArray(typeof(ControllerBtn))]
	public Sprite[] ControllerBtnSprites_PS;

	[NamedArray(typeof(ControllerBtn))]
	public Sprite[] ControllerBtnSprites_PS5;

	[NamedArray(typeof(ControllerBtn))]
	public Sprite[] ControllerBtnSprites_Switch;

	[NamedArray(typeof(KeyboardBtn))]
	public Sprite[] KeyboardBtnSprites;

	public Texture2D TexCursorDefault;

	private void Awake()
	{
	}

	public Sprite GetBtnSprite(ControllerBtn btn)
	{
		return null;
	}

	public Sprite GetFaceBtnSprite(CardinalDir btn)
	{
		return null;
	}

	public Sprite GetBtnSprite(GameActionType action, Pole axis = Pole.Positive)
	{
		return null;
	}

	public string GetBtnSpriteTag(GameActionType action, Pole axis = Pole.Positive)
	{
		return null;
	}

	public Sprite GetBtnSprite(KeyboardBtn btn)
	{
		return null;
	}

	public Sprite GetBtnSprite(ControllerBtn controller, KeyboardBtn kb)
	{
		return null;
	}

	public string GetBtnSpriteTag(ControllerBtn btn)
	{
		return null;
	}

	public string GetFaceBtnSpriteTag(CardinalDir dir)
	{
		return null;
	}

	public string GetBtnSpriteTag(KeyboardBtn btn, bool disableResize = false)
	{
		return null;
	}

	public string GetBtnSpriteTag(ControllerBtn controller, KeyboardBtn kb)
	{
		return null;
	}

	public void ResetToDefaultCursor()
	{
	}
}

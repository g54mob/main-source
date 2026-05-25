using UnityEngine;

public class Compressor_Button : MonoBehaviour
{
	public Compressor_MiniGame Parent;

	public bool IsTop;

	private SpriteRenderer _renderer;

	public void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
	}

	private void OnMouseOver()
	{
		if (Compressor.GlobalInfo.CanHighlightDevice())
		{
			_renderer.color = Color.yellow;
		}
	}

	private void OnMouseExit()
	{
		if (Compressor.GlobalInfo.CanHighlightDevice())
		{
			_renderer.color = Color.white;
		}
	}

	private void OnMouseDown()
	{
		if (!Sign.PreventEvent)
		{
			Parent.ButtonPressed(IsTop);
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_click);
		}
	}
}

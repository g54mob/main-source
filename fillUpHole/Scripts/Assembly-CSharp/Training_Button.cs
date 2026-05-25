using DG.Tweening;
using UnityEngine;

public class Training_Button : MonoBehaviour
{
	public Training_MiniGame Parent;

	public bool IsLeft;

	private SpriteRenderer _renderer;

	private Color _originalColor;

	public void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_originalColor = _renderer.color;
	}

	public void Flash()
	{
		_renderer.DOColor(GameController.EvilColor, 0.25f).OnComplete(delegate
		{
			_renderer.DOColor(_originalColor, 0.1f);
		});
	}

	private void OnMouseOver()
	{
		if (Training.GlobalInfo.CanHighlightDevice())
		{
			_originalColor = Color.yellow;
			_renderer.color = Color.yellow;
		}
	}

	private void OnMouseExit()
	{
		if (Training.GlobalInfo.CanHighlightDevice())
		{
			_originalColor = Color.white;
			_renderer.color = Color.white;
		}
	}

	private void OnMouseDown()
	{
		if (!Sign.PreventEvent && Parent.ButtonPressed(IsLeft))
		{
			Flash();
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_click);
		}
	}
}

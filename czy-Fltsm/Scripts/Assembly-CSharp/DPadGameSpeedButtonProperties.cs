using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Flotsam/DPad/DPad GameSpeed Button Properties")]
public class DPadGameSpeedButtonProperties : DPadButtonProperties
{
	[SerializeField]
	private Sprite _iconPaused;

	[SerializeField]
	private Sprite _icon1x;

	[SerializeField]
	private Sprite _icon2x;

	[SerializeField]
	private Sprite _icon3x;

	public override void Enable(Image image)
	{
		base.Enable(image);
		GameEventDispatcher.AddListener(GameEventType.GameSpeedChange, OnGameSpeedChanged);
		OnGameSpeedChanged();
	}

	public override void Disable()
	{
		base.Disable();
		GameEventDispatcher.RemoveListener(GameEventType.GameSpeedChange, OnGameSpeedChanged);
	}

	private void OnGameSpeedChanged(GameEvent gameEvent = null)
	{
		if (!(base.Image == null))
		{
			switch (GameSpeedManager.GameSpeed)
			{
			case GameSpeed.Paused:
			case GameSpeed.Zero:
				base.Image.sprite = _iconPaused;
				break;
			case GameSpeed.One:
				base.Image.sprite = _icon1x;
				break;
			case GameSpeed.Two:
				base.Image.sprite = _icon2x;
				break;
			case GameSpeed.Three:
			case GameSpeed.Four:
			case GameSpeed.Eight:
			case GameSpeed.Sixteen:
				base.Image.sprite = _icon3x;
				break;
			}
		}
	}
}

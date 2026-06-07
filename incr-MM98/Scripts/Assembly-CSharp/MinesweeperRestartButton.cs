using System;
using MessagePipe;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MinesweeperRestartButton : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private Image icon;

	[SerializeField]
	private Sprite surprisedFace;

	[SerializeField]
	private Sprite happyFace;

	[SerializeField]
	private Sprite sadFace;

	private bool _inProgress;

	private void Awake()
	{
		Initializer.Context(button).AddListener(EventHub.Scene.Publish<MinesweeperRestarted>).Assign(origin: true, out _inProgress)
			.SceneEvents()
			.Subscribe(HandleRestarting, Array.Empty<MessageHandlerFilter<MinesweeperRestarted>>())
			.Subscribe(HandleFinish, Array.Empty<MessageHandlerFilter<MinesweeperFinished>>())
			.Subscribe(HandleMouseEvent, Array.Empty<MessageHandlerFilter<MinesweeperMouse>>())
			.Build(this);
	}

	private void HandleRestarting(MinesweeperRestarted _)
	{
		_inProgress = true;
		icon.overrideSprite = null;
	}

	private void HandleFinish(MinesweeperFinished ctx)
	{
		_inProgress = false;
		icon.overrideSprite = (ctx.Won ? happyFace : sadFace);
	}

	private void HandleMouseEvent(MinesweeperMouse ctx)
	{
		if (_inProgress)
		{
			icon.overrideSprite = (ctx.Down ? surprisedFace : null);
		}
	}
}

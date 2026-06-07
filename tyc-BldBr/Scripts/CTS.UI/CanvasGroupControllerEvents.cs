using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.Events;

public class CanvasGroupControllerEvents : CTSBehaviour
{
	[SerializeField]
	[Inject(false)]
	private CanvasGroupController _canvasGroupController;

	[SerializeField]
	private UnityEvent _canvasOpening;

	[SerializeField]
	private UnityEvent _canvasOpened;

	[SerializeField]
	private UnityEvent _canvasClosing;

	[SerializeField]
	private UnityEvent _canvasClosed;

	[SerializeField]
	private UnityEvent _onDestroy;

	protected override void OnEnabled()
	{
		base.OnEnabled();
		_canvasGroupController.CanvasShowning += OnCanvasShowing;
		_canvasGroupController.CanvasShowned += OnCanvasShowed;
	}

	protected override void OnDisabled()
	{
		base.OnDisabled();
		_canvasGroupController.CanvasShowning -= OnCanvasShowing;
		_canvasGroupController.CanvasShowned -= OnCanvasShowed;
	}

	private void OnDestroy()
	{
		_onDestroy?.Invoke();
	}

	private void OnCanvasShowing(bool value)
	{
		if (value)
		{
			_canvasOpening.Invoke();
		}
		else
		{
			_canvasClosing.Invoke();
		}
	}

	private void OnCanvasShowed(bool value)
	{
		if (value)
		{
			_canvasOpened.Invoke();
		}
		else
		{
			_canvasClosed.Invoke();
		}
	}
}

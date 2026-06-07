using System;
using CTS;
using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.Events;

public class CanvasExclusivity : CTSBehaviour
{
	[SerializeField]
	[Inject(false)]
	private CanvasGroupController _controller;

	[SerializeField]
	private StringKey _exclusivityGroup;

	[SerializeField]
	private bool _hideCanvas = true;

	[SerializeField]
	private UnityEvent _closed;

	public StringKey ExclusivityGroup => _exclusivityGroup;

	public static event Action<CanvasExclusivity, StringKey> ExclusivityClosed;

	protected override void OnEnabled()
	{
		base.OnEnabled();
		if ((bool)_controller)
		{
			_controller.CanvasShowning += OnCanvasShowing;
		}
		ExclusivityClosed += OnExclusivityClosed;
	}

	protected override void OnDisabled()
	{
		base.OnDisabled();
		if ((bool)_controller)
		{
			_controller.CanvasShowning -= OnCanvasShowing;
		}
		ExclusivityClosed -= OnExclusivityClosed;
	}

	private void OnExclusivityClosed(CanvasExclusivity source, StringKey key)
	{
		if (!(source == this) && key == _exclusivityGroup)
		{
			_closed.Invoke();
		}
	}

	private void OnCanvasShowing(bool value)
	{
		if (value)
		{
			CloseExclusivityGroup();
		}
	}

	public static bool IsOpen(StringKey key)
	{
		if (!MonoSingleton<CanvasGroupManager>.TryGetInstance(out var outInstance))
		{
			return false;
		}
		foreach (CanvasGroupController openedController in outInstance.OpenedControllers)
		{
			if (openedController.TryGetComponent<CanvasExclusivity>(out var component) && component._exclusivityGroup == key)
			{
				return true;
			}
		}
		return false;
	}

	public void CloseExclusivityGroup()
	{
		Close(this, _exclusivityGroup);
	}

	public static void Close(CanvasExclusivity canvas, StringKey exclusivityKey)
	{
		if (!MonoSingleton<CanvasGroupManager>.TryGetInstance(out var outInstance))
		{
			return;
		}
		outInstance.CleanCanvases();
		CanvasExclusivity.ExclusivityClosed?.Invoke(canvas, exclusivityKey);
		for (int num = outInstance.OpenedControllers.Count - 1; num >= 0; num--)
		{
			CanvasGroupController canvasGroupController = outInstance.OpenedControllers[num];
			if ((!canvas || !(canvas._controller == canvasGroupController)) && canvasGroupController.TryGetComponent<CanvasExclusivity>(out var component) && component._exclusivityGroup == exclusivityKey && component._hideCanvas)
			{
				canvasGroupController.QuickHide();
			}
		}
	}
}

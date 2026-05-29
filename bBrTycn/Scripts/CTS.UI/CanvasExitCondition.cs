using CTS.Core;
using CTS.UI;
using UnityEngine;

public abstract class CanvasExitCondition : CTSBehaviour
{
	[SerializeField]
	[Inject(false)]
	private CanvasGroupController _controller;

	public abstract bool CanBeExitedWithMouse();

	public abstract bool CanBeExitedWithEscape();
}

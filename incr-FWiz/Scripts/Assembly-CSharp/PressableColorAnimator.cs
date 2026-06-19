using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PressableColorAnimator : PressListenerAnimator
{
	public Graphic Graphic;

	public Color DefaultColor;

	public Color HoveredColor;

	public Color PressedColor;

	public float TransitionTime;

	public Ease Ease;

	private Tween _tween;

	public override void AfterStateUpdate()
	{
	}
}

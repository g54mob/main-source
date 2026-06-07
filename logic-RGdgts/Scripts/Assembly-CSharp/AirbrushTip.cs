using DG.Tweening;
using UnityEngine;

public class AirbrushTip : MonoBehaviour
{
	public BrushGestaltEnum brushEnum;

	private Airbrush airbrush;

	private Sequence tween;

	private float attachValue;

	public bool isMoving => false;

	private void OnAttachComplete()
	{
	}

	public void Attach(Airbrush airbrush, bool immediate = false, float delay = 0f)
	{
	}

	public void Detach(bool immediate = false)
	{
	}
}

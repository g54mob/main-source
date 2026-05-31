using Assets.Source.World.Frames;
using UnityEngine;

public class T2SpinningWidgetDial : MonoBehaviour
{
	private ActiveWorldFrame _parent;

	private void Start()
	{
		_parent = GetComponentInParent<ActiveWorldFrame>();
	}

	private void Update()
	{
		if (_parent?.ActiveFrame is T2SpinningWidget t2SpinningWidget)
		{
			base.transform.localRotation = Quaternion.Euler(0f, 0f, t2SpinningWidget.SpinnerAngle * -360f);
		}
	}
}

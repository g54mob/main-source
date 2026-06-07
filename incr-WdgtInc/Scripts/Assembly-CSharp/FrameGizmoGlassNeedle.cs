using Assets.Source.World.Frames;
using UnityEngine;

public class FrameGizmoGlassNeedle : MonoBehaviour
{
	private ActiveWorldFrame _parent;

	private void Start()
	{
		_parent = GetComponentInParent<ActiveWorldFrame>();
	}

	private void Update()
	{
		if (_parent?.ActiveFrame is T2Glass t2Glass)
		{
			float num = t2Glass.Temperature / 30f;
			base.transform.localRotation = Quaternion.Euler(0f, 0f, num * -80f);
		}
	}
}

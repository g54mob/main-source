using Assets.Source.World.Frames;
using UnityEngine;

public class T3OilDial : MonoBehaviour
{
	[SerializeField]
	private Transform _dial;

	private ActiveWorldFrame _parentFrame;

	private void Awake()
	{
		_parentFrame = GetComponentInParent<ActiveWorldFrame>();
	}

	private void Update()
	{
		if (_parentFrame.ActiveFrame is T3Oil t3Oil)
		{
			_dial.localEulerAngles = new Vector3(0f, 0f, 0f - t3Oil.Pressure);
		}
	}
}

using MyBox;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
	private enum Anchor
	{
		LeftTop = 0,
		LeftBottom = 1,
		RightTop = 2,
		RightBottom = 3
	}

	public bool EditorOnly;

	[Separator]
	[SerializeField]
	private float _updateInterval;

	[SerializeField]
	private int _targetFrameRate;

	[Separator]
	[SerializeField]
	private Anchor _anchor;

	[SerializeField]
	private int _xOffset;

	[SerializeField]
	private int _yOffset;

	private float _idleTime;

	private float _elapsed;

	private int _frames;

	private int _quantity;

	private float _fps;

	private float _averageFps;

	private Color _goodColor;

	private Color _okColor;

	private Color _badColor;

	private float _okFps;

	private float _badFps;

	private Rect _rect1;

	private Rect _rect2;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnGUI()
	{
	}
}

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

	[SerializeField]
	private float _updateInterval = 1f;

	[SerializeField]
	private int _targetFrameRate = 30;

	[SerializeField]
	private Anchor _anchor;

	[SerializeField]
	private int _xOffset;

	[SerializeField]
	private int _yOffset;

	private float _idleTime = 2f;

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
		if (!EditorOnly || Application.isEditor)
		{
			_goodColor = new Color(0.4f, 0.6f, 0.4f);
			_okColor = new Color(0.8f, 0.8f, 0.2f, 0.6f);
			_badColor = new Color(0.8f, 0.6f, 0.6f);
			int num = _targetFrameRate / 100;
			int num2 = num * 10;
			int num3 = num * 40;
			_okFps = _targetFrameRate - num2;
			_badFps = _targetFrameRate - num3;
			int num4 = 0;
			int num5 = 0;
			int num6 = 40;
			int num7 = 90;
			if (_anchor == Anchor.LeftBottom || _anchor == Anchor.RightBottom)
			{
				num5 = Screen.height - num6;
			}
			if (_anchor == Anchor.RightTop || _anchor == Anchor.RightBottom)
			{
				num4 = Screen.width - num7;
			}
			num4 += _xOffset;
			num5 += _yOffset;
			int num8 = num5 + 18;
			_rect1 = new Rect(num4, num5, num7, num6);
			_rect2 = new Rect(num4, num8, num7, num6);
			_elapsed = _updateInterval;
		}
	}

	private void Update()
	{
		if (EditorOnly && !Application.isEditor)
		{
			return;
		}
		if (_idleTime > 0f)
		{
			_idleTime -= Time.deltaTime;
			return;
		}
		_elapsed += Time.deltaTime;
		_frames++;
		if (_elapsed >= _updateInterval)
		{
			_fps = (float)_frames / _elapsed;
			_elapsed = 0f;
			_frames = 0;
		}
		_quantity++;
		_averageFps += (_fps - _averageFps) / (float)_quantity;
	}

	private void OnGUI()
	{
		if (!EditorOnly || Application.isEditor)
		{
			Color color = GUI.color;
			Color color2 = _goodColor;
			if (_fps <= _okFps || _averageFps <= _okFps)
			{
				color2 = _okColor;
			}
			if (_fps <= _badFps || _averageFps <= _badFps)
			{
				color2 = _badColor;
			}
			GUI.color = color2;
			GUI.Label(_rect1, "FPS: " + (int)_fps);
			GUI.color = color;
		}
	}
}

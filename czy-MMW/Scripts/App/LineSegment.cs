using UnityEngine;

public struct LineSegment
{
	private Vector2 _start;

	private Vector2 _end;

	private Vector2 _direction;

	private float _length;

	private bool _dirty;

	public static readonly LineSegment Null = new LineSegment(Vector2.zero, Vector2.zero);

	public bool IsNull
	{
		get
		{
			if (_start.x == 0f && _start.y == 0f && _end.x == 0f)
			{
				return _end.y == 0f;
			}
			return false;
		}
	}

	public Vector2 Start
	{
		get
		{
			return _start;
		}
		set
		{
			_start = value;
			_dirty = true;
		}
	}

	public Vector2 End
	{
		get
		{
			return _end;
		}
		set
		{
			_end = value;
			_dirty = true;
		}
	}

	public Vector2 Direction
	{
		get
		{
			if (_dirty)
			{
				Update();
			}
			return _direction;
		}
	}

	public Vector2 Normal
	{
		get
		{
			if (_dirty)
			{
				Update();
			}
			return _direction.GetTangent();
		}
	}

	public float Length
	{
		get
		{
			if (_dirty)
			{
				Update();
			}
			return _length;
		}
	}

	public LineSegment(Vector2 start, Vector2 end)
	{
		_start = start;
		_end = end;
		_direction = Vector2.zero;
		_length = 0f;
		_dirty = true;
		Update();
	}

	public Vector2 GetPosition(float t)
	{
		return Start + Direction * t;
	}

	public float GetParametricCoordinate(Vector2 point)
	{
		if (!Mathf.Approximately(_start.x, _end.x))
		{
			return (point.x - _start.x) / (_end.x - _start.x);
		}
		if (!Mathf.Approximately(_start.y, _end.y))
		{
			return (point.y - _start.y) / (_end.y - _start.y);
		}
		return 0f;
	}

	public override string ToString()
	{
		return $"[LineSegment: Start={_start}, End={_end}]";
	}

	private void Update()
	{
		if (!IsNull)
		{
			_direction = End - Start;
			_length = _direction.magnitude;
			_direction /= _length;
			_dirty = false;
		}
	}
}

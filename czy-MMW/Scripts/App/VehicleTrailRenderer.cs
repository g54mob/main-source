using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class VehicleTrailRenderer : MonoBehaviour
{
	[SerializeField]
	private LineRenderer _line;

	[SerializeField]
	private float _minSampleDistance = 0.1f;

	[SerializeField]
	private float _lifetime = 0.5f;

	private const int MaxPoints = 200;

	private Vector3[] _points = new Vector3[200];

	private float[] _times = new float[200];

	private int _head;

	private int _tail;

	private bool _started;

	private bool _lineChanged;

	private float _currentTime;

	public Renderer Renderer => _line;

	public Color Color
	{
		get
		{
			return _line.startColor;
		}
		set
		{
			_line.endColor = value;
			value.a = 0f;
			_line.startColor = value;
		}
	}

	private void OnEnable()
	{
		_line.positionCount = 0;
		_started = true;
	}

	private void OnDisable()
	{
		_line.positionCount = 0;
	}

	public void Tick(float deltaTime)
	{
		_currentTime += deltaTime;
		if (_started)
		{
			_head = 0;
			_tail = 0;
			_points[_tail] = base.transform.position;
			_times[_tail] = _currentTime;
			_lineChanged = true;
			_started = false;
		}
		if (_head < 199 && (base.transform.position - _points[_head]).sqrMagnitude > _minSampleDistance * _minSampleDistance)
		{
			_head++;
			_points[_head] = base.transform.position;
			_times[_head] = _currentTime;
			_lineChanged = true;
			if (_head >= 199)
			{
				RelocatePoints();
			}
		}
		while (_currentTime - _times[_tail] > _lifetime && _tail < _head)
		{
			_tail++;
			_lineChanged = true;
		}
		if (_lineChanged)
		{
			AssignPointsToLineRenderer();
		}
		else
		{
			_line.SetPosition(_line.positionCount - 1, base.transform.position);
		}
	}

	private void AssignPointsToLineRenderer()
	{
		int num = _head - _tail + 1;
		Vector3[] array = new Vector3[num + 1];
		Array.Copy(_points, _tail, array, 0, num);
		array[num] = base.transform.position;
		_line.positionCount = array.Length;
		_line.SetPositions(array);
	}

	private void RelocatePoints()
	{
		int num = _head - _tail + 1;
		if (num < 100)
		{
			Array.Copy(_points, _tail, _points, 0, num);
			Array.Copy(_times, _tail, _times, 0, num);
			_tail = 0;
			_head = num - 1;
			return;
		}
		Vector3[] array = new Vector3[num];
		Array.Copy(_points, _tail, array, 0, num);
		Array.Copy(array, _points, array.Length);
		float[] array2 = new float[num];
		Array.Copy(_times, _tail, array2, 0, num);
		Array.Copy(array2, _times, array2.Length);
		_tail = 0;
		_head = num - 1;
	}

	public void SetLifetime(float newLifetime)
	{
		_lifetime = newLifetime;
	}

	public float GetTimeForPoint(int index)
	{
		return _times[index];
	}

	public int GetTailIndex()
	{
		return _tail;
	}

	public int GetHeadIndex()
	{
		return _head;
	}
}

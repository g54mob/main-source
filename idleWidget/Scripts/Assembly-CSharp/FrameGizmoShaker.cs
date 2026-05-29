using UnityEngine;

public class FrameGizmoShaker : FrameGizmo
{
	[SerializeField]
	private float _amplitudeX = 0.02f;

	[SerializeField]
	private float _amplitudeY = 0.05f;

	[SerializeField]
	private ParticleSystem _linkedParticles;

	private Vector3 _origin;

	private Vector3 _start;

	private Vector3 _destination;

	private float _moveTime = 0.05f;

	private float _moveTimeSpent;

	public bool ForceActive;

	private bool _active;

	private void Start()
	{
		_origin = base.transform.localPosition;
		_updateDestination();
	}

	private void _updateDestination()
	{
		_start = base.transform.localPosition;
		_destination = new Vector3(_origin.x + SeededRandom.Global.RandomRange(0f - _amplitudeX, _amplitudeX), _origin.y + SeededRandom.Global.RandomRange(0f - _amplitudeY, _amplitudeY), _origin.z);
	}

	private void Update()
	{
		if (!ForceActive && !_active)
		{
			base.transform.localPosition = _origin;
			return;
		}
		_moveTimeSpent += Time.deltaTime;
		if (_moveTimeSpent >= _moveTime)
		{
			_moveTimeSpent = 0f;
			_updateDestination();
		}
		float t = _moveTimeSpent / _moveTime;
		base.transform.localPosition = Vector3.Lerp(_start, _destination, t);
	}

	public override void OnStartGizmo()
	{
		_active = true;
		if ((bool)_linkedParticles)
		{
			_linkedParticles.Play();
		}
	}

	public override void OnStopGizmo()
	{
		_active = false;
		if ((bool)_linkedParticles)
		{
			_linkedParticles.Stop();
		}
	}
}

using UnityEngine;

public class AircraftTow : MonoBehaviour
{
	public float followSpeed = 3f;

	public float rotationSpeed = 2f;

	public float maxTowDistance = 6f;

	private Transform _player;

	private bool _isTowed;

	private float _lastPlayerYaw;

	private Vector3 _offset;

	private void Update()
	{
		if (!_isTowed || _player == null)
		{
			return;
		}
		Vector3 vector = _player.position - base.transform.position;
		vector.y = 0f;
		if (!(vector.magnitude > maxTowDistance))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, _player.position - _offset, followSpeed * Time.deltaTime);
			float y = _player.eulerAngles.y;
			float num = Mathf.DeltaAngle(_lastPlayerYaw, y);
			if (Mathf.Abs(num) > 0.1f)
			{
				Quaternion b = Quaternion.Euler(base.transform.eulerAngles.x, base.transform.eulerAngles.y + num, base.transform.eulerAngles.z);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, rotationSpeed * Time.deltaTime);
			}
			_lastPlayerYaw = y;
		}
	}

	public void OnTowStart(PlayerTowController p)
	{
		_player = p.transform;
		_isTowed = true;
		_lastPlayerYaw = _player.eulerAngles.y;
		_offset = _player.position - base.transform.position;
		_offset.y = 0f;
	}

	public void OnTowStop()
	{
		_player = null;
		_isTowed = false;
	}
}

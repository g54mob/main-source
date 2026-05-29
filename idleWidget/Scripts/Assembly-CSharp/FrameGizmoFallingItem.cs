using UnityEngine;

public class FrameGizmoFallingItem : MonoBehaviour
{
	[SerializeField]
	private float _speed;

	[SerializeField]
	private float _lifeTime;

	private float _rotationSpeed;

	private float _angle;

	private void Awake()
	{
		base.transform.localPosition = base.transform.localPosition + new Vector3(SeededRandom.Global.RandomRange(-0.1f, 0.1f), SeededRandom.Global.RandomRange(-0.1f, 0.1f), 0f);
		_angle = SeededRandom.Global.RandomRange(0f, 360f);
		base.transform.localRotation = Quaternion.Euler(0f, 0f, _angle);
		_rotationSpeed = SeededRandom.Global.RandomRange(-180f, 180f);
	}

	private void Update()
	{
		_lifeTime -= Time.deltaTime;
		if (_lifeTime < 0f)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		_angle += _rotationSpeed * Time.deltaTime;
		base.transform.localPosition = base.transform.localPosition + new Vector3(0f, (0f - _speed) * Time.deltaTime, 0f);
		base.transform.localRotation = Quaternion.Euler(0f, 0f, _angle);
	}
}

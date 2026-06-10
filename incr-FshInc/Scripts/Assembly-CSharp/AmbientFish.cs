using UnityEngine;

public class AmbientFish : MonoBehaviour
{
	[Header("Movement Settings")]
	public float moveSpeed = 2f;

	public float waveFrequency = 2f;

	public float waveMagnitude = 0.5f;

	[Header("Limits")]
	public float destroyX = 15f;

	private float _randomOffset;

	private int _direction = 1;

	private void Awake()
	{
		_randomOffset = Random.Range(0f, 10f);
	}

	public void Setup(float speed, int direction)
	{
		moveSpeed = speed;
		_direction = direction;
	}

	private void Update()
	{
		float x = moveSpeed * (float)_direction * Time.deltaTime;
		float y = Mathf.Sin((Time.time + _randomOffset) * waveFrequency) * waveMagnitude * Time.deltaTime;
		base.transform.position += new Vector3(x, y, 0f);
		if (Mathf.Abs(base.transform.position.x) > destroyX)
		{
			Object.Destroy(base.gameObject);
		}
	}
}

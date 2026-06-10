using UnityEngine;

public class SpriteParallax : MonoBehaviour
{
	[Header("Settings")]
	[Tooltip("How far it moves in World Units. Keep this small! (e.g., 0.5 to 1.0)")]
	public float parallaxAmount = 0.5f;

	[Tooltip("How quickly it follows the mouse. Higher = snappier.")]
	public float smoothTime = 5f;

	private Vector3 _startPos;

	private Vector3 _targetPos;

	private void Start()
	{
		_startPos = base.transform.position;
	}

	private void Update()
	{
		float num = Mathf.Clamp(Input.mousePosition.x / (float)Screen.width - 0.5f, -0.5f, 0.5f);
		float num2 = Mathf.Clamp(Input.mousePosition.y / (float)Screen.height - 0.5f, -0.5f, 0.5f);
		Vector3 vector = new Vector3((0f - num) * parallaxAmount, (0f - num2) * parallaxAmount, 0f);
		_targetPos = _startPos + vector;
		base.transform.position = Vector3.Lerp(base.transform.position, _targetPos, Time.deltaTime * smoothTime);
	}
}

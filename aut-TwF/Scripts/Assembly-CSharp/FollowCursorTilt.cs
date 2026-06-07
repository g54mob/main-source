using UnityEngine;
using UnityEngine.InputSystem;

public class FollowCursorTilt : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Cuantos grados rota por cada 100 pixeles")]
	private float degreesPercentPixelRatio;

	[SerializeField]
	private float followSmooth;

	private Quaternion targetRotation;

	private Vector3 startRightTransform;

	private Quaternion startRotation;

	private void Awake()
	{
		startRightTransform = base.transform.right;
		startRotation = base.transform.rotation;
	}

	private void Update()
	{
		if (Application.isFocused)
		{
			Vector2 scale = new Vector2(1920f / (float)Screen.width, 1080f / (float)Screen.height);
			Vector2 value = Mouse.current.position.value;
			value.Scale(scale);
			Vector2 vector = new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
			vector.Scale(scale);
			targetRotation = startRotation * Quaternion.AngleAxis((value.x - vector.x) * degreesPercentPixelRatio * 0.01f, Vector3.up);
			targetRotation = Quaternion.AngleAxis((value.y - vector.y) * (0f - degreesPercentPixelRatio) * 0.01f, startRightTransform) * targetRotation;
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, targetRotation, 1f - Mathf.Clamp01(followSmooth));
		}
	}
}

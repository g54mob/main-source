using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public static CameraController instance;

	public AnimationCurve shakeCurve;

	public float shakeDuration = 1f;

	public float shakeScaleFactor = -1f;

	private Camera targetCamera;

	private float initialScale;

	private bool initialized;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one camera controller in the scene.");
		}
		instance = this;
	}

	private void Start()
	{
		targetCamera = Camera.main;
		initialScale = targetCamera.orthographicSize;
		initialized = true;
	}

	public void ShakePunch()
	{
		if (initialized)
		{
			StopAllCoroutines();
			StartCoroutine(ExecuteShake(shakeScaleFactor, shakeDuration));
		}
	}

	private IEnumerator ExecuteShake(float scale, float duration)
	{
		float timer = 0f;
		while (timer <= duration)
		{
			timer += Time.deltaTime;
			targetCamera.orthographicSize = initialScale + shakeCurve.Evaluate(timer / duration) * scale;
			yield return null;
		}
		targetCamera.orthographicSize = initialScale;
	}
}

using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DecalAnimation : MonoBehaviour
{
	[SerializeField]
	private float duration = 1f;

	[SerializeField]
	private AnimationCurve opacityCurve;

	[SerializeField]
	private float roationSpeed;

	[SerializeField]
	private bool playOnStart = true;

	[SerializeField]
	private bool destroyAtEnd;

	private DecalProjector projector;

	private void Awake()
	{
		projector = GetComponent<DecalProjector>();
	}

	private void Start()
	{
		projector.fadeFactor = 0f;
		if (playOnStart)
		{
			PlayDecalAnimation();
		}
	}

	public void PlayDecalAnimation()
	{
		StartCoroutine(AnimationCoroutine());
	}

	private IEnumerator AnimationCoroutine()
	{
		float timer = 0f;
		while (timer <= duration)
		{
			timer += Time.deltaTime;
			projector.fadeFactor = opacityCurve.Evaluate(timer / duration);
			base.transform.Rotate(Vector3.up, roationSpeed * Time.deltaTime, Space.World);
			yield return null;
		}
		if (destroyAtEnd)
		{
			Object.Destroy(base.gameObject);
		}
	}
}

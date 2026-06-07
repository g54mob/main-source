using UnityEngine;

public class ShrinkByDistance : MonoBehaviour
{
	[Header("Scaling")]
	[SerializeField]
	private Vector2 scaleSpectrum;

	[SerializeField]
	private float distToScaleMult;

	[SerializeField]
	private float offset;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
		Vector3 localScale = Mathf.Clamp(Vector3.Distance(GameManager.Singleton.playerCamera.transform.position, base.transform.position) * distToScaleMult + offset, scaleSpectrum.x, scaleSpectrum.y) * Vector3.one;
		base.transform.localScale = localScale;
	}
}

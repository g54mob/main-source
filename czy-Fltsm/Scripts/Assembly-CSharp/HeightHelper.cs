using PajamaLlama.Math;
using UnityEngine;

public class HeightHelper : MonoBehaviour, IProducerVisualHelper
{
	[Tooltip("Hide the object when it's at the lowest.")]
	[SerializeField]
	private bool _hideWhenZero = true;

	[Space]
	[Tooltip("Y-Position to start object at.")]
	[SerializeField]
	private float _lowestYPosition;

	[Tooltip("Y-Position to end object at.")]
	[SerializeField]
	private float _highestYPosition = 1f;

	public void SetProgress(float progress)
	{
		if (!base.gameObject.activeSelf && progress > 0f)
		{
			base.gameObject.SetActive(value: true);
		}
		float y = Mathf.Lerp(_lowestYPosition, _highestYPosition, progress);
		base.transform.localPosition = base.transform.localPosition.SetY(y);
		if (progress == 0f && _hideWhenZero)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void Reset()
	{
		SetProgress(0f);
	}
}

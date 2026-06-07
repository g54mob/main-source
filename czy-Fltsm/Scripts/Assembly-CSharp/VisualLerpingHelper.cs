using UnityEngine;

public class VisualLerpingHelper : MonoBehaviour, IProducerVisualHelper
{
	[Tooltip("Hide the object when it's at 0.")]
	[SerializeField]
	private bool _hideWhenZero = true;

	[Header("Start")]
	[SerializeField]
	private Vector3 _startPosition = Vector3.zero;

	[SerializeField]
	private Vector3 _startRotation = Vector3.zero;

	[SerializeField]
	private Vector3 _startScale = Vector3.one;

	[Header("Target")]
	[SerializeField]
	private Vector3 _targetPosition = Vector3.one;

	[SerializeField]
	private Vector3 _targettRotation = Vector3.one;

	[SerializeField]
	private Vector3 _targetScale = Vector3.one;

	public void SetProgress(float progress)
	{
		if (progress == 0f && _hideWhenZero)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		if (!base.gameObject.activeInHierarchy)
		{
			base.gameObject.SetActive(value: true);
		}
		base.transform.localPosition = Vector3.Lerp(_startPosition, _targetPosition, progress);
		base.transform.localEulerAngles = Vector3.Lerp(_startRotation, _targettRotation, progress);
		base.transform.localScale = Vector3.Lerp(_startScale, _targetScale, progress);
	}

	public void Reset()
	{
		SetProgress(0f);
	}
}

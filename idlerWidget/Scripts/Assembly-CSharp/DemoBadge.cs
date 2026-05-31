using UnityEngine;

public class DemoBadge : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup _group;

	private void Update()
	{
		(base.transform as RectTransform).localEulerAngles = new Vector3(0f, 0f, -12f + 5f * Mathf.Sin(Time.unscaledTime));
		_group.alpha = 0.8f + Mathf.Cos(Time.unscaledTime) / 5f;
	}
}

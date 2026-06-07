using Data.Variables;
using UnityEngine;

public class CloudSizeToScreenAdapter : MonoBehaviour
{
	[SerializeField]
	private Transform _cloudTransform;

	[SerializeField]
	private Vector3 _wideScreenScale;

	[SerializeField]
	private ResolutionSO _resolutionSO;

	private const float WIDTH_2K = 1920f;

	private const float WIDTH_MAX = 5120f;

	private void Start()
	{
		UpdateScale(new Vector2Int(Screen.width, Screen.height));
		if ((bool)_resolutionSO)
		{
			_resolutionSO.ValueChanged += UpdateScale;
		}
	}

	private void OnDestroy()
	{
		if ((bool)_resolutionSO)
		{
			_resolutionSO.ValueChanged -= UpdateScale;
		}
	}

	private void UpdateScale(Vector2Int screenSize)
	{
		if (base.enabled)
		{
			float value = Mathf.Max(screenSize.x, 1920f);
			float t = Mathf.InverseLerp(1920f, 5120f, value);
			_cloudTransform.localScale = Vector3.Lerp(_cloudTransform.localScale, _wideScreenScale, t);
		}
	}
}

using UnityEngine;
using UnityEngine.UI;

public class UIRotationScript : MonoBehaviour
{
	private bool _stop;

	public float Speed = -50f;

	public AnimationCurve ScaleCurve;

	public Image Overlay;

	private Vector3 _scale;

	private float stopped;

	private void Start()
	{
		_scale = base.transform.localScale;
	}

	public void Stop()
	{
		_stop = true;
		stopped = Time.realtimeSinceStartup;
	}

	private void Update()
	{
		if (_stop)
		{
			Overlay.fillAmount = Mathf.Min(1f, (Time.realtimeSinceStartup - stopped) / 2.5f);
			base.transform.localScale = _scale * ScaleCurve.Evaluate(Time.realtimeSinceStartup);
		}
		else
		{
			base.transform.rotation = base.transform.rotation * Quaternion.Euler(0f, 0f, Time.deltaTime * Speed);
		}
	}
}

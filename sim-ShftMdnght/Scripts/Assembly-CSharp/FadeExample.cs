using UnityEngine;

public class FadeExample : MonoBehaviour
{
	private Material _material;

	private bool _reappearing;

	private static readonly int Transparency = Shader.PropertyToID("_Transparency");

	[SerializeField]
	private float fadeSpeed = 1f;

	private void Awake()
	{
		_material = GetComponent<Renderer>().material;
	}

	private void Update()
	{
		float num = _material.GetFloat(Transparency);
		num = (_reappearing ? (num + Time.deltaTime * fadeSpeed) : (num - Time.deltaTime * fadeSpeed));
		if (num < 0f)
		{
			num = 0f;
			_reappearing = !_reappearing;
		}
		else if (num > 1f)
		{
			num = 1f;
			_reappearing = !_reappearing;
		}
		_material.SetFloat(Transparency, num);
	}
}

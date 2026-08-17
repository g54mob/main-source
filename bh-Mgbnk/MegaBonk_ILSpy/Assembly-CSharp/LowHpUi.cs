using UnityEngine;
using UnityEngine.UI;

public class LowHpUi : MonoBehaviour
{
	public RawImage vignette;

	private Color vignetteColor;

	private float maxOpacity = 1f;

	private void Awake()
	{
	}

	private unsafe void Update()
	{
		//IL_0028: Expected O, but got Ref
		Color color = vignette.color;
		object obj = default(object);
		vignette.color = (Color)(&obj);
	}
}

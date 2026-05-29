using UnityEngine;

public class Fade : MonoBehaviour
{
	[SerializeField]
	private float fade;

	[SerializeField]
	private MeshRenderer render;

	private float oldFade;

	private void Update()
	{
		if (fade != oldFade)
		{
			oldFade = fade;
			Color white = Color.white;
			white.a = fade;
			render.sharedMaterial.color = white;
		}
	}
}

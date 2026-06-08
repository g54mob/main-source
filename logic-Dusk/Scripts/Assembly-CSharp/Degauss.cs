using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Cale/Degauss")]
public class Degauss : ImageEffectBase
{
	public float strength = 1f;

	public Vector2 freq = Vector2.one;

	public float yPhase;

	public float yPhasePerSecond = 0.1f;

	public float xPhase;

	public float xPhaseperSecond = 0.1f;

	private void OnDestroy()
	{
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		yPhase += yPhasePerSecond * Time.deltaTime;
		xPhase += xPhaseperSecond * Time.deltaTime;
		base.material.SetFloat("_Strength", strength);
		base.material.SetVector("_Shape", new Vector4(freq.x, freq.y, xPhase, yPhase));
		Graphics.Blit(source, destination, base.material);
	}
}

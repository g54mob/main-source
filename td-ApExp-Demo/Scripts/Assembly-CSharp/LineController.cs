using UnityEngine;

public class LineController : MonoBehaviour
{
	public LineRenderer lineRenderer;

	public Texture[] textures;

	public int animationStep;

	public const float FPS = 30f;

	public float fpsCounter;

	private void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	private void Update()
	{
		fpsCounter += Time.deltaTime;
		if (fpsCounter >= 1f / 30f)
		{
			animationStep++;
			if (animationStep == textures.Length)
			{
				animationStep = 0;
			}
			lineRenderer.material.SetTexture("_MainTex", textures[animationStep]);
			fpsCounter = 0f;
		}
	}
}

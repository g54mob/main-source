using UnityEngine;

public class LightBillboard : SceneBehaviour
{
	public MeshRenderer Renderer;

	public int Intensity = 4;

	protected override void Awake()
	{
		base.Awake();
		Renderer.material = Object.Instantiate(Renderer.material);
	}
}

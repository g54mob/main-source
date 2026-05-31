using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RendererInstance : LODInstance
{
	private Renderer m_Renderer;

	private void Awake()
	{
	}

	public override void SetAvailability(bool b)
	{
	}
}

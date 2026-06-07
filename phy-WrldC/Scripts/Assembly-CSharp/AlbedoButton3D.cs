using UnityEngine;

public class AlbedoButton3D : Button3D
{
	private Renderer[] renderers;

	protected override void Start()
	{
		base.Start();
		renderers = base.gameObject.GetComponentsInChildren<Renderer>();
	}

	protected override void SetColor(Color color)
	{
		Renderer[] array = renderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].material.color = color;
		}
	}
}

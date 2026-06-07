using System;
using UnityEngine;

public class PlotObject : MonoBehaviour
{
	public MeshFilter EdgeMesh;

	public MeshFilter PlotMesh;

	public MeshRenderer Renderer;

	public MeshRenderer EdgeRenderer;

	public MeshRenderer GridRend;

	public Material DisableMat;

	[NonSerialized]
	public PlotArea Plot;

	public Color GetColor(float alpha)
	{
		if (!Plot.PlayerOwned)
		{
			return Plot.PlotColor.ToColor().Alpha(alpha);
		}
		return new Color(1f, 1f, 1f, 0.5f);
	}

	public void UpdatePlayerOwned()
	{
		Renderer.material.color = GetColor(0.5f);
		PlotMesh.gameObject.SetActive((GameSettings.Instance.EditMode || !GameSettings.Instance.RentMode) && Plot.Owner > 0);
		if (!Plot.PlayerOwned && Plot.Owner > 0)
		{
			GridRend.sharedMaterial = DisableMat;
		}
		else
		{
			GridRend.sharedMaterial = BuildController.Instance.MainGridMaterial;
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (Plot.Neighbors == null)
		{
			return;
		}
		Gizmos.color = Plot.PlotColor;
		foreach (uint neighbor in Plot.Neighbors)
		{
			PlotArea plot = GameSettings.Instance.GetPlot(neighbor);
			Gizmos.DrawLine(Plot.Center, plot.Center);
		}
	}

	private void Start()
	{
		UpdatePlayerOwned();
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(PlotMesh);
		UnityEngine.Object.Destroy(EdgeMesh);
	}
}

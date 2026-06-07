using System.Collections.Generic;
using UnityEngine;

public class MapNodePathLine : MonoBehaviour
{
	public enum eLineType
	{
		AVALIABLE_PATH = 0,
		DISABLED_PATH = 1,
		PREVIEW_PATH = 2
	}

	public class lineTypeAssets
	{
		public Gradient Gradient;

		public Material Material;

		public Color Color;
	}

	[SerializeField]
	private LineRenderer lineRenderer;

	[SerializeField]
	private LineRenderer lineRenderer_FogMask;

	[SerializeField]
	private BoxCollider collider;

	[SerializeField]
	private List<Vector3> list_PathPoints;

	private bool isLineOn;

	public void SetPathPoints(List<Vector3> path)
	{
	}

	public void SetLineType(eLineType lineType)
	{
	}

	public void SetColorGradient(Gradient gradient)
	{
	}

	public void SetMaterial(Material material)
	{
	}

	public void SetLightLineColor(Color color)
	{
	}

	public void SetShowPercentage(float percentage)
	{
	}

	private void ToggleLine(bool isOn)
	{
	}

	public void ToggleFogMaskLine(bool isOn)
	{
	}

	public void SetupCollider(Vector3 start, Vector3 end)
	{
	}
}

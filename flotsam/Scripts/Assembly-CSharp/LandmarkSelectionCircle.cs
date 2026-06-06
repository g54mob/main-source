using UnityEngine;

public class LandmarkSelectionCircle : CircleWaveHighlighter
{
	public override void Initialize(float radius, Vector3 position, Color color)
	{
		_material = GetComponentInChildren<MeshRenderer>().material;
		SetRadius(radius);
		base.transform.position = position;
		_material.SetColor("_SelectionColor", color);
	}
}

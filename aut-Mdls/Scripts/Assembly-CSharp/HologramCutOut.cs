using UnityEngine;

public class HologramCutOut : MonoBehaviour
{
	[SerializeField]
	private Transform _cutOutPoint;

	[SerializeField]
	private Color _lineColor;

	private void Start()
	{
	}

	private void Update()
	{
		Shader.SetGlobalFloat("_BuildingAppear", _cutOutPoint.position.y);
		Shader.SetGlobalColor("_LineColor", _lineColor);
	}
}

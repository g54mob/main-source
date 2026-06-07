using System.Collections.Generic;
using Data.Variables;
using UnityEngine;

public class HideInHeatmap : MonoBehaviour
{
	[Header("Heatmap")]
	[SerializeField]
	private List<MeshRenderer> _trackedMeshRenderers = new List<MeshRenderer>();

	[SerializeField]
	private BoolVariableSO _heatMapIsOn;

	private void OnEnable()
	{
		_heatMapIsOn.ValueChanged += OnHeatmapToggle;
		OnHeatmapToggle(_heatMapIsOn.Value);
	}

	private void OnDisable()
	{
		_heatMapIsOn.ValueChanged -= OnHeatmapToggle;
	}

	private void OnHeatmapToggle(bool toggle)
	{
		foreach (MeshRenderer trackedMeshRenderer in _trackedMeshRenderers)
		{
			trackedMeshRenderer.enabled = !toggle;
		}
	}
}

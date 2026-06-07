using UnityEngine;

[CreateAssetMenu(fileName = "VisualPrefab Preview Settings", menuName = "Flotsam/Settings/VisualPrefab Preview Settings")]
public class VisualPrefabPreviewSettings : ScriptableObject
{
	[SerializeField]
	private Material _material;

	[SerializeField]
	private string _colorParameterName = "_BaseColor";

	[SerializeField]
	private Color _validColor;

	[SerializeField]
	private Color _invalidColor;

	public VisualPrefab InstantiatePreview(VisualPrefab visualPrefab)
	{
		VisualPrefab visualPrefab2 = Object.Instantiate(visualPrefab);
		visualPrefab2.InstanceRenderers();
		visualPrefab2.SetProgress(1f);
		visualPrefab2.EnableShowOnCompleteVisuals(active: false);
		visualPrefab2.SetReplacementMaterial(_material);
		return visualPrefab2;
	}

	public void SetValid(VisualPrefab visualPrefab, bool isValid)
	{
		visualPrefab.SetColor(isValid ? _validColor : _invalidColor, _colorParameterName);
	}
}

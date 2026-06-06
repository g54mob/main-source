using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class UIElementsLayer : MonoBehaviour
{
	[SerializeField]
	[GeneratedEnum]
	private UIElementsLayerID _layerID;

	[SerializeField]
	private Canvas _canvas;

	[SerializeField]
	private GraphicRaycaster _graphicRaycaster;

	private readonly List<PanelContainer> _panels = new List<PanelContainer>(16);

	public IReadOnlyList<PanelContainer> Panels => _panels;

	public UIElementsLayerID LayerID => _layerID;

	private void OnValidate()
	{
		if (_canvas == null)
		{
			_canvas = GetComponent<Canvas>();
		}
		if (_graphicRaycaster == null)
		{
			_graphicRaycaster = GetComponent<GraphicRaycaster>();
		}
	}

	private void Awake()
	{
		DetectPanels();
	}

	private void DetectPanels()
	{
		_panels.Clear();
		_panels.AddRange(GetComponentsInChildren<PanelContainer>(includeInactive: false));
	}

	public void SetInputsActive(bool active)
	{
		_graphicRaycaster.enabled = active;
	}
}

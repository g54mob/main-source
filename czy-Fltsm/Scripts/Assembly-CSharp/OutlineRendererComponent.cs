using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class OutlineRendererComponent : SceneBehaviour
{
	[SerializeField]
	[FormerlySerializedAs("objectType")]
	private ObjectType _objectType;

	private OutlineRenderController _outlineObjectRenderer;

	private OutlineRenderController _placeableController;

	private readonly List<OutlineRenderController> _hoveredAgentRenderers = new List<OutlineRenderController>();

	private readonly List<OutlineRenderController> _storageVisualOutlineRenderers = new List<OutlineRenderController>();

	private Agent _agent;

	private IOutlineRenderControllerProvider _controllerProvider;

	private void Start()
	{
		Buildable component = null;
		Decoration component2 = null;
		switch (_objectType)
		{
		case ObjectType.CommunityMember:
		case ObjectType.Agent:
			_agent = GetComponent<Agent>();
			break;
		case ObjectType.Buildable:
			if (TryGetComponent<Buildable>(out component))
			{
				_placeableController = component.SpawnedVisual.GetComponent<OutlineRenderController>();
			}
			break;
		case ObjectType.Decoration:
			if (TryGetComponent<Decoration>(out component2))
			{
				_placeableController = component2.SpawnedVisual.GetComponent<OutlineRenderController>();
			}
			break;
		}
		IOutlineRenderControllerProvider controllerProvider;
		switch (_objectType)
		{
		case ObjectType.Marker:
			controllerProvider = GetComponent<Marker>();
			break;
		case ObjectType.CommunityMember:
		case ObjectType.Agent:
			controllerProvider = _agent;
			break;
		case ObjectType.Buildable:
			controllerProvider = component;
			break;
		case ObjectType.Decoration:
			controllerProvider = component2;
			break;
		case ObjectType.Bird:
			controllerProvider = GetComponent<Bird>();
			break;
		default:
			controllerProvider = null;
			break;
		}
		_controllerProvider = controllerProvider;
	}

	public void ResetOutline()
	{
		OutlineRenderController outlineObjectRenderer = _outlineObjectRenderer;
		DisablePreviousOutlines();
		if (_agent != null && outlineObjectRenderer != null && !outlineObjectRenderer.IsHighlightEnabled)
		{
			Buildable buildable = _agent.ReturnCurrentBuildable();
			if (buildable != null && buildable.OutlineController != null)
			{
				outlineObjectRenderer.SetOutlineEnabled(buildable.OutlineController.IsOutlineEnabled);
				outlineObjectRenderer.SetHighlightEnabled(buildable.OutlineController.IsHighlightEnabled);
			}
		}
	}

	public void ResetHighlightOutline()
	{
		DisablePreviousOutlinesAndHighlights();
		PopulateOutlineControllers();
		if (_outlineObjectRenderer != null)
		{
			SetOutlineAndHighlightEnabled(_outlineObjectRenderer, enabled: false);
		}
	}

	public void UpdateHoverObject(bool ignoreUI = false)
	{
		DisablePreviousOutlines();
		if ((!ignoreUI && EventSystem.current.IsPointerOverGameObject()) || UIManager.State == UIState.Building)
		{
			return;
		}
		PopulateOutlineControllers();
		if (_outlineObjectRenderer != null)
		{
			_outlineObjectRenderer.EnableOutline();
		}
		foreach (OutlineRenderController hoveredAgentRenderer in _hoveredAgentRenderers)
		{
			if (!hoveredAgentRenderer.IsHighlightEnabled)
			{
				hoveredAgentRenderer.EnableOutline();
			}
		}
		foreach (OutlineRenderController storageVisualOutlineRenderer in _storageVisualOutlineRenderers)
		{
			if (!storageVisualOutlineRenderer.IsHighlightEnabled)
			{
				storageVisualOutlineRenderer.EnableOutline();
			}
		}
	}

	public void UpdateSelectedObject()
	{
		DisablePreviousOutlines();
		PopulateOutlineControllers();
		if (_outlineObjectRenderer != null)
		{
			SetOutlineAndHighlightEnabled(_outlineObjectRenderer, enabled: true);
		}
		foreach (OutlineRenderController hoveredAgentRenderer in _hoveredAgentRenderers)
		{
			SetOutlineAndHighlightEnabled(hoveredAgentRenderer, enabled: true);
		}
		foreach (OutlineRenderController storageVisualOutlineRenderer in _storageVisualOutlineRenderers)
		{
			SetOutlineAndHighlightEnabled(storageVisualOutlineRenderer, enabled: true);
		}
	}

	public void UpdateAgent(Agent agent, bool AddToConstructionOutline = false)
	{
		if (!(agent == null) && !(Selector.Selection == agent.SelectionLink))
		{
			OutlineRenderController outlineController = agent.OutlineController;
			if (AddToConstructionOutline)
			{
				SetOutlineAndHighlightEnabled(outlineController, _placeableController.IsOutlineEnabled, _placeableController.IsHighlightEnabled);
				_hoveredAgentRenderers.Add(outlineController);
			}
			else
			{
				SetOutlineAndHighlightEnabled(outlineController, enabled: false);
				_hoveredAgentRenderers.Remove(outlineController);
			}
		}
	}

	public void UpdateStorageVisual(StorageVisual visual, bool addToConstructionOutline = false)
	{
		if (!base.enabled || !(visual.OutlineController != null))
		{
			return;
		}
		if (addToConstructionOutline)
		{
			if (_placeableController == null)
			{
				Start();
			}
			SetOutlineAndHighlightEnabled(visual.OutlineController, _placeableController.IsOutlineEnabled, _placeableController.IsHighlightEnabled);
			_storageVisualOutlineRenderers.Add(visual.OutlineController);
		}
		else
		{
			SetOutlineAndHighlightEnabled(visual.OutlineController, enabled: false);
			_storageVisualOutlineRenderers.Remove(visual.OutlineController);
		}
	}

	private void DisablePreviousOutlinesAndHighlights()
	{
		if (_outlineObjectRenderer != null && !_outlineObjectRenderer.IsHighlightEnabled)
		{
			SetOutlineAndHighlightEnabled(_outlineObjectRenderer, enabled: false);
			_outlineObjectRenderer = null;
		}
		foreach (OutlineRenderController hoveredAgentRenderer in _hoveredAgentRenderers)
		{
			SetOutlineAndHighlightEnabled(hoveredAgentRenderer, enabled: false);
		}
		_hoveredAgentRenderers.Clear();
		foreach (OutlineRenderController storageVisualOutlineRenderer in _storageVisualOutlineRenderers)
		{
			SetOutlineAndHighlightEnabled(storageVisualOutlineRenderer, enabled: false);
		}
	}

	private void DisablePreviousOutlines()
	{
		if (_outlineObjectRenderer != null && !_outlineObjectRenderer.IsHighlightEnabled)
		{
			_outlineObjectRenderer.SetOutlineEnabled(enabled: false);
			_outlineObjectRenderer = null;
		}
		for (int num = _hoveredAgentRenderers.Count - 1; num >= 0; num--)
		{
			OutlineRenderController outlineRenderController = _hoveredAgentRenderers[num];
			if (!outlineRenderController.IsHighlightEnabled)
			{
				outlineRenderController.SetOutlineEnabled(enabled: false);
				_hoveredAgentRenderers.RemoveAt(num);
			}
		}
		foreach (OutlineRenderController storageVisualOutlineRenderer in _storageVisualOutlineRenderers)
		{
			if (!storageVisualOutlineRenderer.IsHighlightEnabled)
			{
				storageVisualOutlineRenderer.SetOutlineEnabled(enabled: false);
			}
		}
	}

	private void PopulateOutlineControllers()
	{
		if (_controllerProvider != null)
		{
			_outlineObjectRenderer = _controllerProvider.OutlineController;
			if (_controllerProvider is Buildable buildable)
			{
				PopulateAgentsOnBuildable(buildable);
			}
		}
		else if (_objectType == ObjectType.LandmarkInteractable)
		{
			_outlineObjectRenderer = GetComponentInChildren<OutlineRenderController>();
		}
	}

	private void PopulateAgentsOnBuildable(Buildable buildable)
	{
		Agent[] array = buildable.ReturnAgentsOnBuildable();
		for (int i = 0; i < array.Length; i++)
		{
			OutlineRenderController outlineController = array[i].OutlineController;
			if (outlineController != null)
			{
				_hoveredAgentRenderers.Add(outlineController);
			}
		}
	}

	private static void SetOutlineAndHighlightEnabled(OutlineRenderController outlineController, bool enabled)
	{
		SetOutlineAndHighlightEnabled(outlineController, enabled, enabled);
	}

	private static void SetOutlineAndHighlightEnabled(OutlineRenderController outlineController, bool outlineEnabled, bool highlightEnabled)
	{
		outlineController.SetOutlineEnabled(outlineEnabled);
		outlineController.SetHighlightEnabled(highlightEnabled);
	}
}

using System;
using PajamaLlama.Extensions;
using UnityEngine;

public abstract class LandmarkInteractable : MonoBehaviour, ITooltipProvider
{
	public Target Target;

	private OutlineRendererComponent _outlineRenderer;

	public bool IsInteractable { get; set; }

	public SelectionLink SelectionLink { get; private set; }

	private void Awake()
	{
		SelectionLink = GetComponentInChildren<SelectionLink>();
		if (SelectionLink != null)
		{
			SelectionLink.SetObjectToSelect(base.gameObject, ObjectType.Buildable);
			SelectionLink.SetOnShowTooltipListener(OnShowTooltip);
			SelectionLink.SetOnSelectedListener(OnSelected);
			SelectionLink.SetOnDeselectedListener(OnDeselected);
		}
		_outlineRenderer = GetComponentInChildren<OutlineRendererComponent>();
	}

	public abstract void Initialize(LandmarkBehaviour landmarkBehaviour);

	protected virtual void Start()
	{
		if (IsInteractable)
		{
			if (Target == null)
			{
				Debug.LogException(new Exception("No Target set for Landmarkinteractable '" + base.transform.HierarchyPathToString() + "'"));
			}
			else if (Target.PrimaryMarker == null)
			{
				Debug.LogException(new Exception("Target '" + base.transform.HierarchyPathToString() + "' has no PrimaryMarker set"));
			}
			else if (!Target.PrimaryMarker.AddToConstructionGraph())
			{
				Debug.LogErrorFormat("LandmarkInteractable '{0}' could not add Primary marker with path '{1}' to the construction graph!", base.name, Target.HierarchyPathToString());
			}
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	protected virtual void OnDestroy()
	{
		if (GameManager.GraphManager != null)
		{
			Target.PrimaryMarker.RemoveFromConstructionGraph();
		}
	}

	public virtual bool Validate()
	{
		return true;
	}

	public void OnShowTooltip()
	{
		TooltipPanel.ShowTooltip(this);
	}

	public void OnSelected(bool playSelectionSound)
	{
	}

	public void OnDeselected()
	{
		_outlineRenderer.ResetHighlightOutline();
	}

	public string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return "LandmarkInteractable";
	}
}

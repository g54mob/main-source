using System.Collections.Generic;
using UnityEngine;

public class BuildGUI : MonoBehaviour
{
	public enum PaneType
	{
		NONE = 0,
		BASIC = 1
	}

	public PaneType currentPaneType;

	private PaneType requestedPaneType;

	public GameObject basicToolsPane;

	public ConstructionInstruction constructionInstructions;

	private bool docked;

	private int elementsToDock = 2;

	private int elementsDocked;

	private List<Segment> dockSegments = new List<Segment>();

	private bool transitioning;

	private Inchworm inchwormRef;

	private void Awake()
	{
		CloseAllPanes();
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
	}

	public void Load()
	{
		transitioning = false;
		currentPaneType = PaneType.NONE;
		SetPaneType(PaneType.BASIC);
	}

	public void Unload()
	{
		transitioning = false;
		currentPaneType = PaneType.NONE;
		CloseAllPanes();
		ResetDock();
	}

	public bool ArePanesDocked()
	{
		return docked;
	}

	private void ResetDock()
	{
		if (docked)
		{
			for (int i = 0; i < dockSegments.Count; i++)
			{
				Segment segment = dockSegments[i];
				inchwormRef.CancelEase(ref segment);
			}
			dockSegments.Clear();
		}
		docked = false;
		elementsDocked = 0;
	}

	public void DockPanes()
	{
		if (!docked)
		{
			dockSegments.Clear();
		}
	}

	public void UnDockPanes()
	{
		if (docked)
		{
			dockSegments.Clear();
		}
	}

	public void UpdateConstructionInstructionText(string newText, bool immediate = false)
	{
		constructionInstructions.UpdateText(newText, immediate);
	}

	public void ShowConstructionInstructions(bool immediate = false)
	{
		constructionInstructions.Show(null, immediate);
	}

	public void HideConstructionInstructions(bool immediate = false)
	{
		constructionInstructions.Hide(null, immediate);
	}

	private void OnElementDocked()
	{
		elementsDocked++;
		if (elementsDocked >= elementsToDock)
		{
			OnDockComplete();
		}
	}

	private void OnElementUndocked()
	{
		elementsDocked--;
		if (elementsDocked <= 0)
		{
			OnUndockComplete();
		}
	}

	private void OnDockComplete()
	{
		docked = true;
		dockSegments.Clear();
	}

	private void OnUndockComplete()
	{
		docked = false;
		dockSegments.Clear();
	}

	public void SetPaneType(PaneType newPane)
	{
		if (currentPaneType != newPane && !transitioning)
		{
			transitioning = true;
			requestedPaneType = newPane;
			if (currentPaneType != PaneType.NONE)
			{
				RequestPaneTypeUnload(currentPaneType);
			}
			else
			{
				RequestPaneTypeLoad(newPane);
			}
		}
	}

	private void CloseAllPanes()
	{
		basicToolsPane.GetComponent<BuildToolsPane>().ForceImmediateUnload();
		basicToolsPane.SetActive(value: false);
	}

	private void RequestPaneTypeLoad(PaneType paneType)
	{
		switch (paneType)
		{
		case PaneType.NONE:
			PaneLoadedCallback();
			break;
		case PaneType.BASIC:
			basicToolsPane.SetActive(value: true);
			basicToolsPane.GetComponent<BuildToolsPane>().RequestLoad(BasicToolsPaneLoadedCallback);
			break;
		default:
			Debug.LogError("No GameObject found for PaneType: " + paneType);
			break;
		}
	}

	private void RequestPaneTypeUnload(PaneType paneType)
	{
		switch (paneType)
		{
		case PaneType.NONE:
			PaneUnloadedCallback();
			break;
		case PaneType.BASIC:
			basicToolsPane.GetComponent<BuildToolsPane>().RequestUnload(PaneUnloadedCallback);
			break;
		default:
			Debug.LogError("No GameObject found for PaneType: " + paneType);
			break;
		}
	}

	private void BasicToolsPaneLoadedCallback()
	{
		PaneLoadedCallback();
	}

	private void PaneLoadedCallback()
	{
		ResetDock();
		transitioning = false;
		currentPaneType = requestedPaneType;
	}

	private void PaneUnloadedCallback()
	{
		transitioning = false;
		currentPaneType = PaneType.NONE;
		if (requestedPaneType != PaneType.NONE)
		{
			SetPaneType(requestedPaneType);
		}
	}
}

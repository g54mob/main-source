using System;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class PipelineCanvas : MonoBehaviour
{
	public List<UIPipe> UIPipePrefabs;

	public List<UIPipe> UIPipes;

	public RectTransform ParentRect;

	public PipelineCanvasJoinManager JoinManager;

	public Pipe SelectedPipe;

	public UIPipe SelectedUIPipe;

	public UIPipe HoveredPipe;

	public MagicLine MagicLine;

	public List<PipeUIConnection> HiddenConnections;

	public List<PipeUIConnection> DeletableConnections;

	public EventReference StartSound;

	public EventReference ConnectSound;

	public EventReference DisconnectSound;

	public EventReference HoverSound;

	public EventReference EndSound;

	public StudioEventEmitter DraggingConnectionSoundEmitter;

	public void ApplyShowFilter(Func<Pipe, bool> filter)
	{
	}

	public void Show()
	{
	}

	public void Hide()
	{
	}

	public void Cancel()
	{
	}

	public void CancelSelection()
	{
	}

	public void OnSelectPipeUI(UIPipe uiPipe)
	{
	}

	public void SelectInitialPipe(UIPipe uiPipe)
	{
	}

	public void SelectSecondPipe(UIPipe uiPipe)
	{
	}

	public void Populate()
	{
	}

	private void Update()
	{
	}

	public void UpdateConnectionDraglLink()
	{
	}

	public void Clear()
	{
	}

	public void OnHoverPipeStart(UIPipe uiPipe)
	{
	}

	public void OnHoverPipeEnd(UIPipe uiPipe)
	{
	}

	public void ClearConnectionDetails()
	{
	}
}

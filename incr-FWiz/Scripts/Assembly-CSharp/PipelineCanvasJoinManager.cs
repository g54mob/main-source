using System.Collections.Generic;
using UnityEngine;

public class PipelineCanvasJoinManager : MonoBehaviour
{
	public UIPipe SelectedPipe;

	public PipelineCanvas PipelineCanvas;

	public PipeUIConnection UIConnectionPrefab;

	public List<PipeUIConnection> UIConnections;

	public void CreateConnectionsUI(PipelineCanvas canvas)
	{
	}

	public void ClearConnectionsUI()
	{
	}

	public PipeUIConnection GetConnection(PipeConnection pipeConnection)
	{
		return null;
	}

	public void ShowConnection(PipeConnection connection)
	{
	}

	public void HideConnection(PipeConnection connection)
	{
	}
}

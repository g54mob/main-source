using System.Collections.Generic;
using UnityEngine;

public class TrafficCityRoadV2 : MonoBehaviour
{
	public List<TrafficCityRoadData> roadData;

	public List<TrafficCityConnectedPoint> connectedLanes;

	public bool modeEditorEditorGizmo;

	public bool modeEditorMoveingPoints;

	public bool modeEditorViewConnections;

	public bool modeEditorEditorConnections;

	public bool modeEditorOnluViewListGizmo;

	public bool gizmoMode;

	public bool useGizmoMode;

	private void Reset()
	{
	}

	public static void UpdateReferences()
	{
	}
}

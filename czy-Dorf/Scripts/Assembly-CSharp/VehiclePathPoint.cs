using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;
using UnityEngine.Serialization;

public class VehiclePathPoint : MonoBehaviour
{
	public VehiclePathPointType type;

	[FormerlySerializedAs("edge")]
	public int localEdge;

	public int worldEdge;

	public List<VehiclePathPoint> connectedPathPoints;

	private MeshRenderer pathPointRenderer;

	private void Start()
	{
		pathPointRenderer = GetComponentInChildren<MeshRenderer>();
		if ((bool)pathPointRenderer)
		{
			Object.Destroy(pathPointRenderer.gameObject);
		}
	}

	public void ApplyRotation(int rotation)
	{
		worldEdge = GridCalculator.RotatedDirection(localEdge, rotation);
	}

	public void AssignInitialData(PathPointData pathPointData)
	{
		base.transform.localPosition = pathPointData.localPosition;
		type = pathPointData.type;
		localEdge = pathPointData.localEdge;
	}

	public void AssignConnectedPathPoints(PathPointData pathPointData, List<VehiclePathPoint> allVehiclePathPoints)
	{
		connectedPathPoints = new List<VehiclePathPoint>();
		foreach (int connectedPathPoint in pathPointData.connectedPathPoints)
		{
			connectedPathPoints.Add(allVehiclePathPoints[connectedPathPoint]);
		}
		string text = $"PathPoint_{allVehiclePathPoints.IndexOf(this)}";
		if (type == VehiclePathPointType.entrance)
		{
			text += $"_Entrance_{localEdge}";
		}
		else
		{
			text += "_Connecting";
			foreach (VehiclePathPoint connectedPathPoint2 in connectedPathPoints)
			{
				text += $"_{allVehiclePathPoints.IndexOf(connectedPathPoint2)}";
			}
		}
		base.name = text;
	}
}

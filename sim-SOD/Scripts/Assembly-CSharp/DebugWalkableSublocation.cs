using UnityEngine;

public class DebugWalkableSublocation : MonoBehaviour
{
	public NewNode node;

	public MeshRenderer rend;

	public Material unoccupiedMat;

	public Material occupiedActualMat;

	public Material occupiedDestinationMat;

	public NewNode.NodeSpace space;

	public void Setup(NewNode newNode, NewNode.NodeSpace newSpace)
	{
	}

	private void Update()
	{
	}
}

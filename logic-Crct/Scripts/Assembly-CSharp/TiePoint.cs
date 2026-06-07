using Simulation;
using UnityEngine;

public class TiePoint
{
	public int id;

	public Vector3 position;

	public BaseComponent attachedComp;

	public Circuit.Lead attachedLead;

	public Node attachedNode;

	public BaseComponent parent;

	public TiePoint(int i, Vector3 vec, Node node, BaseComponent p)
	{
	}
}

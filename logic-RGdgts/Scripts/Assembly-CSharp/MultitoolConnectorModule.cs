using UnityEngine;

public class MultitoolConnectorModule : Module
{
	public BoxCollider2D flipArea;

	public Transform socket;

	public Vector2Int[] socketPositions;

	public override void AllocResources()
	{
	}

	public override void SetRotation(int rotationI)
	{
	}

	protected override void OnSolder()
	{
	}

	protected override void OnUnsolder()
	{
	}
}

using AssembleSystem;
using AssembleSystem.FSM.Parts;
using MyBox;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
	[SerializeField]
	private AssembleObjectParent _parent;

	[SerializeField]
	private PartObject _part;

	public Vector3 Placement;

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	private void BuildItem()
	{
		_parent.StateMachine.Placed = true;
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	private void PlacePart()
	{
		_part.GetComponent<PartObjectStateMachine>().Placed = true;
	}
}

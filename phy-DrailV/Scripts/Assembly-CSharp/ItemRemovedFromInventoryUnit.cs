using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Remove from inventory")]
[UnitCategory("Interaction")]
[UnitSubtitle("Wait for player to take out a specified item")]
[TypeIcon(typeof(CharacterController))]
public class ItemRemovedFromInventoryUnit : ItemInInventoryUnit
{
	protected override bool DesiredState => false;

	protected override string OutName => "Out";
}

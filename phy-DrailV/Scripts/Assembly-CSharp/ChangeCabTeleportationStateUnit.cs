using System.Linq;
using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Toggle Cab Teleportation")]
[UnitSubtitle("Allow or disallow teleportation to loco's cab")]
[UnitCategory("Trains")]
[TypeIcon(typeof(TrainCar))]
public class ChangeCabTeleportationStateUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ValueInput trainCar;

	[DoNotSerialize]
	public ValueInput enabledValue;

	[DoNotSerialize]
	public ValueInput teleporterValue;

	[DoNotSerialize]
	public ValueInput walkablesValue;

	[DoNotSerialize]
	public ControlOutput changedTrigger;

	protected override void Definition()
	{
		changedTrigger = ControlOutput("Changed");
		trainCar = ValueInput<GameObject>("Train");
		enabledValue = ValueInput<bool>("Enabled");
		teleporterValue = ValueInput<bool>("On Teleporter");
		walkablesValue = ValueInput<bool>("On Walkables");
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			TrainCar trainCar = TrainCar.Resolve(flow.GetValue<GameObject>(this.trainCar));
			bool enabled = flow.GetValue<bool>(enabledValue);
			if (flow.GetValue<bool>(teleporterValue))
			{
				CabTeleportDestination cabTeleportDestination = trainCar.cabTeleportDestination;
				if (cabTeleportDestination != null)
				{
					cabTeleportDestination.gameObject.SetActive(enabled);
				}
			}
			if (flow.GetValue<bool>(walkablesValue))
			{
				Transform transform = trainCar.interior.Find("[walkable]");
				if (transform != null)
				{
					foreach (GameObject item in (from t in transform.GetComponentsInChildren<Collider>(includeInactive: true)
						where t != null && t.CompareTag(enabled ? "NO_TELEPORT" : "Untagged")
						select t.gameObject).ToList())
					{
						item.tag = (enabled ? "Untagged" : "NO_TELEPORT");
					}
				}
			}
			return changedTrigger;
		});
	}
}

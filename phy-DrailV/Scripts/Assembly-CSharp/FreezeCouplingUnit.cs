using System.Collections.Generic;
using Bolt;
using DV.CabControls.Spec;
using Ludiq;
using UnityEngine;

[UnitTitle("Freeze Coupling")]
[UnitCategory("Interaction")]
[TypeIcon(typeof(SphereCollider))]
[UnitSubtitle("Make coupling and hoses non-interactive on a train set")]
public class FreezeCouplingUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput targetCar;

	[DoNotSerialize]
	public ValueInput doFreezeValue;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		targetCar = ValueInput<GameObject>("Train Car", null);
		doFreezeValue = ValueInput("Freeze", @default: true);
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			GameObject value = flow.GetValue<GameObject>(targetCar);
			bool enabled = !flow.GetValue<bool>(doFreezeValue);
			TrainCar trainCar = TrainCar.Resolve(value);
			List<ControlSpec> list = new List<ControlSpec>();
			foreach (TrainCar car in trainCar.trainset.cars)
			{
				Coupler[] couplers = car.couplers;
				foreach (Coupler coupler in couplers)
				{
					list.AddRange(coupler.ChainScript.GetComponentsInChildren<ControlSpec>());
					list.AddRange(coupler.visualCoupler.hoses.GetComponentsInChildren<ControlSpec>());
					CouplingHoseDisconnectButton[] componentsInChildren = coupler.visualCoupler.hoses.GetComponentsInChildren<CouplingHoseDisconnectButton>();
					foreach (CouplingHoseDisconnectButton couplingHoseDisconnectButton in componentsInChildren)
					{
						list.AddRange(couplingHoseDisconnectButton.buttonGO.GetComponentsInChildren<ControlSpec>());
					}
					foreach (ControlSpec item in list)
					{
						GameObject[] colliderGameObjects = item.colliderGameObjects;
						for (int j = 0; j < colliderGameObjects.Length; j++)
						{
							Collider[] componentsInChildren2 = colliderGameObjects[j].GetComponentsInChildren<Collider>();
							for (int k = 0; k < componentsInChildren2.Length; k++)
							{
								componentsInChildren2[k].enabled = enabled;
							}
						}
					}
					list.Clear();
				}
			}
			return doneTrigger;
		});
	}
}

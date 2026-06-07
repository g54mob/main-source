using System;
using Bolt;
using DV.Utils;
using Ludiq;
using UnityEngine;
using VRTK;

namespace DV.Tutorial
{
	[UnitTitle("VR Controller Connected")]
	[UnitSubtitle("Check if VR controller(s) are connected and branch.")]
	[UnitCategory("VR")]
	[TypeIcon(typeof(CharacterController))]
	public class VRControllersConnectedUnit : Unit
	{
		private new enum Requirement
		{
			Any = 0,
			Left = 1,
			Right = 2,
			Both = 3
		}

		[DoNotSerialize]
		public ControlInput inputTrigger;

		[DoNotSerialize]
		public ControlOutput connectedTrigger;

		[DoNotSerialize]
		public ControlOutput notConnectedTrigger;

		[DoNotSerialize]
		public ValueInput requirementValue;

		protected override void Definition()
		{
			connectedTrigger = ControlOutput("Connected");
			notConnectedTrigger = ControlOutput("Not Connected");
			requirementValue = ValueInput("Requirement", Requirement.Any);
			inputTrigger = ControlInput("Input", delegate(Flow flow)
			{
				VRTK_ControllerReference controllerReferenceLeftHand = SingletonBehaviour<TutorialHelper>.Instance.ControllerReferenceLeftHand;
				VRTK_ControllerReference controllerReferenceRightHand = SingletonBehaviour<TutorialHelper>.Instance.ControllerReferenceRightHand;
				bool flag = VRManager.IsControllerEnabledLeft && controllerReferenceLeftHand != null && controllerReferenceLeftHand.IsValid();
				bool flag2 = VRManager.IsControllerEnabledRight && controllerReferenceRightHand != null && controllerReferenceRightHand.IsValid();
				Requirement value = flow.GetValue<Requirement>(requirementValue);
				switch (value)
				{
				case Requirement.Any:
					if (!(flag || flag2))
					{
						return notConnectedTrigger;
					}
					return connectedTrigger;
				case Requirement.Left:
					if (!flag)
					{
						return notConnectedTrigger;
					}
					return connectedTrigger;
				case Requirement.Right:
					if (!flag2)
					{
						return notConnectedTrigger;
					}
					return connectedTrigger;
				case Requirement.Both:
					if (!(flag && flag2))
					{
						return notConnectedTrigger;
					}
					return connectedTrigger;
				default:
					throw new NotImplementedException(string.Format("Value {0} is not implemented in {1}, check code.", value, "VRControllersConnectedUnit"));
				}
			});
		}
	}
}

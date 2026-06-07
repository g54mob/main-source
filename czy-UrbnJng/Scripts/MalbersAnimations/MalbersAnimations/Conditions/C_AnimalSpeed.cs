using System;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_AnimalSpeed : MAnimalCondition
	{
		public enum SpeedCondition
		{
			VerticalSpeed = 0,
			CurrentSpeedSet = 1,
			CurrentSpeedModifier = 2,
			ActiveIndex = 3,
			Sprinting = 4,
			CanSprint = 5
		}

		public SpeedCondition Condition;

		[Hide("showCompare", false)]
		public ComparerInt compare;

		[Hide("showValue", false)]
		public float Value;

		[Hide("showName", false)]
		public string SpeedName;

		[HideInInspector]
		[SerializeField]
		private bool showName;

		[HideInInspector]
		[SerializeField]
		private bool showValue;

		[HideInInspector]
		[SerializeField]
		private bool showCompare;

		public override string DisplayName => "Animal/Speeds";

		public override bool _Evaluate()
		{
			if ((bool)Target)
			{
				switch (Condition)
				{
				case SpeedCondition.VerticalSpeed:
					return Target.VerticalSmooth.CompareFloat(Value, compare);
				case SpeedCondition.CurrentSpeedSet:
					return Target.CurrentSpeedSet.name == SpeedName;
				case SpeedCondition.CurrentSpeedModifier:
					return Target.CurrentSpeedModifier.name == SpeedName;
				case SpeedCondition.ActiveIndex:
					return (float)Target.CurrentSpeedIndex == Value;
				case SpeedCondition.Sprinting:
					return Target.Sprint;
				case SpeedCondition.CanSprint:
					return Target.CanSprint;
				}
			}
			return false;
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			showName = Condition == SpeedCondition.CurrentSpeedModifier || Condition == SpeedCondition.CurrentSpeedSet;
			showValue = Condition == SpeedCondition.ActiveIndex || Condition == SpeedCondition.VerticalSpeed;
			showCompare = Condition == SpeedCondition.VerticalSpeed;
		}

		private void Reset()
		{
			Name = "New Animal Speed Condition";
			Target = this.FindComponent<MAnimal>();
		}
	}
}

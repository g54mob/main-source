using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[CreateAssetMenu(menuName = "Malbers Animations/Modifier/Mode/Input Axis")]
	public class ModifierInputAxis : ModeModifier
	{
		public List<AxisAbility> axisAbilities = new List<AxisAbility>(1)
		{
			new AxisAbility
			{
				Ability = 1,
				Direction = Vector3.zero
			}
		};

		public override void OnModeEnter(Mode mode)
		{
			Vector3 rawInputAxis = mode.Animal.RawInputAxis;
			AxisAbility axisAbility = axisAbilities[0];
			float num = (axisAbility.Direction - rawInputAxis).sqrMagnitude;
			foreach (AxisAbility axisAbility2 in axisAbilities)
			{
				float sqrMagnitude = (axisAbility2.Direction - rawInputAxis).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					axisAbility = axisAbility2;
				}
			}
			mode.AbilityIndex = axisAbility.Ability;
			if (mode.Animal.debugModes)
			{
				mode.Debugging($"Input Axis Mode Modifier Set Index to [{axisAbility.Name} - {axisAbility.Ability}]");
			}
		}
	}
}

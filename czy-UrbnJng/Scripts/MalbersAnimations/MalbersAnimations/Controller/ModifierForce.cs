using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[CreateAssetMenu(menuName = "Malbers Animations/Modifier/Mode/Force")]
	public class ModifierForce : ModeModifier
	{
		[HelpBox]
		public string Desc = "Applies a Force to the Animal when the Mode starts. Remove the force when the mode ends";

		[Tooltip("Direction of the Force")]
		public Vector3Reference Direction = new Vector3Reference(Vector3.forward);

		[Tooltip("Use the Raw Input Axis Instead of the Direction Value")]
		public BoolReference UseInputAxis = new BoolReference();

		[Tooltip("Amount of force to apply to the Animal")]
		public FloatReference Force = new FloatReference(2f);

		[Tooltip("Time the Force will be applied to the Animal. if is set to Zero then it will be applied during the whole Animation")]
		public FloatReference m_Time = new FloatReference(0f);

		[Tooltip("Start Acceleration of the force")]
		public FloatReference EnterAceleration = new FloatReference(5f);

		[Tooltip("Exit Acceleration of the force")]
		public FloatReference ExitAceleration = new FloatReference(5f);

		[Tooltip("When the Force is applied the Gravity will be Reseted")]
		public BoolReference ResetGravity = new BoolReference(value: true);

		[Tooltip("Remove Y value from the Additive position")]
		public BoolReference NoY = new BoolReference();

		[Header("Check States")]
		[Tooltip("Increase the Force applied depending which state the Animal is playing")]
		public List<StateMultiplier> stateMultipliers;

		public override void OnModeEnter(Mode mode)
		{
			float num = 1f;
			if (stateMultipliers != null && stateMultipliers.Count > 0)
			{
				StateID ActiveState = mode.Animal.ActiveStateID;
				StateMultiplier stateMultiplier = stateMultipliers.Find((StateMultiplier x) => x.ID == ActiveState);
				if (stateMultiplier != null)
				{
					num = stateMultiplier.Multiplier;
				}
			}
			Vector3 direction = (UseInputAxis.Value ? mode.Animal.RawInputAxis : ((Vector3)Direction));
			mode.Animal.Force_Add(mode.Animal.transform.TransformDirection(direction), (float)Force * num, EnterAceleration, ResetGravity);
			mode.Animal.UpInertia_Clear();
		}

		public override void OnModeMove(Mode mode)
		{
			if ((float)m_Time > 0f && MTools.ElapsedTime(mode.ActivationTime, m_Time) && mode.Animal.ExternalForce != Vector3.zero)
			{
				mode.Animal.Force_Remove(ExitAceleration);
			}
			if ((bool)NoY)
			{
				mode.Animal.additivePosition.y = 0f;
			}
			if ((bool)ResetGravity)
			{
				mode.Animal.GravityOffset = Vector3.zero;
				mode.Animal.GravityTime--;
			}
		}

		public override void OnModeExit(Mode mode)
		{
			mode.Animal.Force_Remove(ExitAceleration);
		}
	}
}

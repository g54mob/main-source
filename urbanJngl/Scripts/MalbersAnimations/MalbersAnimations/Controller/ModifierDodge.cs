using System;
using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[CreateAssetMenu(menuName = "Malbers Animations/Modifier/Mode/Directional Dodge")]
	public class ModifierDodge : ModeModifier
	{
		[Serializable]
		public class DodgeDistance
		{
			public StateID state;

			public float distance = 1f;
		}

		public enum DirectionDodge
		{
			TwoSides = 0,
			FourSides = 1,
			EightSides = 2
		}

		[HelpBox]
		public string Desc = "";

		public DirectionDodge direction = DirectionDodge.EightSides;

		[Tooltip("Apply Extra movement to the Dodge")]
		public bool MoveDodge = new BoolReference(value: true);

		[Tooltip("How Much it will mode if Move Dodge is enabled")]
		public List<DodgeDistance> dodgeDistance = new List<DodgeDistance>();

		private Vector3 DodgeDirection;

		private float Distance;

		public override void OnModeEnter(Mode mode)
		{
			int abilityIndex = ((!mode.Animal.UsingMoveWithDirection) ? MovewithWorld(mode) : MovewithDirection(mode));
			DodgeDirection = DodgeDirection.normalized;
			DodgeDistance dodgeDistance = this.dodgeDistance.Find((DodgeDistance x) => x.state == mode.Animal.ActiveStateID);
			if (dodgeDistance != null)
			{
				Distance = dodgeDistance.distance;
			}
			mode.AbilityIndex = abilityIndex;
		}

		private int MovewithDirection(Mode mode)
		{
			Vector3 move_Direction = mode.Animal.Move_Direction;
			float num = Vector3.Angle(mode.Animal.Forward, move_Direction);
			bool flag = Vector3.Dot(mode.Animal.Right, move_Direction) < 0f;
			num = ((!flag) ? num : (num * -1f));
			switch (direction)
			{
			case DirectionDodge.TwoSides:
				DodgeDirection = (flag ? Vector3.left : Vector3.right);
				if (!flag)
				{
					return 2;
				}
				return 1;
			case DirectionDodge.FourSides:
				if (Mathf.Abs(num) < 45f)
				{
					DodgeDirection = Vector3.forward;
					return 1;
				}
				if (num > 45f && num <= 135f)
				{
					DodgeDirection = Vector3.right;
					return 2;
				}
				if (Mathf.Abs(num) > 135f)
				{
					DodgeDirection = Vector3.back;
					return 3;
				}
				DodgeDirection = Vector3.left;
				return 4;
			case DirectionDodge.EightSides:
				if (Mathf.Abs(num) < 22.5f)
				{
					DodgeDirection = Vector3.forward;
					return 1;
				}
				if (num > 22.5f && num <= 67.5f)
				{
					DodgeDirection = (Vector3.forward + Vector3.right).normalized;
					return 2;
				}
				if (num > 67.5f && num <= 112.5f)
				{
					DodgeDirection = Vector3.right;
					return 3;
				}
				if (num > 112.5f && num <= 157.5f)
				{
					DodgeDirection = (Vector3.back + Vector3.right).normalized;
					return 4;
				}
				if (Mathf.Abs(num) > 157.5f)
				{
					DodgeDirection = Vector3.back;
					return 5;
				}
				if (num < -112.5f && num >= -157.5f)
				{
					DodgeDirection = (Vector3.back + Vector3.left).normalized;
					return 6;
				}
				if (num < -67.5f && num >= -112.5f)
				{
					DodgeDirection = Vector3.left;
					return 7;
				}
				DodgeDirection = (Vector3.forward + Vector3.left).normalized;
				return 8;
			default:
				return 0;
			}
		}

		private int MovewithWorld(Mode mode)
		{
			int result = 0;
			Vector3 movementAxisRaw = mode.Animal.MovementAxisRaw;
			bool flag = movementAxisRaw.x < 0f;
			bool flag2 = movementAxisRaw.x > 0f;
			bool flag3 = movementAxisRaw.z > 0f;
			bool flag4 = movementAxisRaw.z < 0f;
			switch (direction)
			{
			case DirectionDodge.TwoSides:
				result = (flag ? 1 : 2);
				DodgeDirection = (flag ? Vector3.left : Vector3.right);
				break;
			case DirectionDodge.FourSides:
				if (flag3)
				{
					result = 1;
					DodgeDirection = Vector3.forward;
				}
				else if (flag2)
				{
					result = 2;
					DodgeDirection = Vector3.right;
				}
				else if (flag4)
				{
					result = 3;
					DodgeDirection = Vector3.back;
				}
				else if (flag)
				{
					result = 4;
					DodgeDirection = Vector3.left;
				}
				break;
			case DirectionDodge.EightSides:
			{
				flag = movementAxisRaw.x < 0f && movementAxisRaw.z == 0f;
				flag2 = movementAxisRaw.x > 0f && movementAxisRaw.z == 0f;
				flag3 = movementAxisRaw.z > 0f && movementAxisRaw.x == 0f;
				flag4 = movementAxisRaw.z < 0f && movementAxisRaw.x == 0f;
				bool flag5 = movementAxisRaw.z > 0f && movementAxisRaw.x > 0f;
				bool flag6 = movementAxisRaw.z > 0f && movementAxisRaw.x < 0f;
				bool flag7 = movementAxisRaw.z < 0f && movementAxisRaw.x > 0f;
				bool flag8 = movementAxisRaw.z < 0f && movementAxisRaw.x < 0f;
				if (flag3)
				{
					result = 1;
					DodgeDirection = Vector3.forward;
				}
				else if (flag5)
				{
					result = 2;
					DodgeDirection = (Vector3.forward + Vector3.right).normalized;
				}
				else if (flag2)
				{
					result = 3;
					DodgeDirection = Vector3.right;
				}
				else if (flag7)
				{
					result = 4;
					DodgeDirection = (Vector3.back + Vector3.right).normalized;
				}
				else if (flag4)
				{
					result = 5;
					DodgeDirection = Vector3.back;
				}
				else if (flag8)
				{
					result = 6;
					DodgeDirection = (Vector3.back + Vector3.left).normalized;
				}
				else if (flag)
				{
					result = 7;
					DodgeDirection = Vector3.left;
				}
				else if (flag6)
				{
					result = 8;
					DodgeDirection = (Vector3.forward + Vector3.left).normalized;
				}
				break;
			}
			}
			return result;
		}

		public override void OnModeMove(Mode mode)
		{
			if (MoveDodge)
			{
				MAnimal animal = mode.Animal;
				animal.transform.position += animal.DeltaTime * Distance * animal.transform.TransformDirection(DodgeDirection);
			}
		}

		private void OnValidate()
		{
			switch (direction)
			{
			case DirectionDodge.TwoSides:
				Desc = "The Dodge will be done with Horizontal Sides\nAbility 1: Dodge Left\nAbility 2: Dodge Right";
				break;
			case DirectionDodge.FourSides:
				Desc = "The Dodge will be done with Horizontal and Vertical Sides\nAbility 1: Dodge Front\nAbility 2: Dodge Right\nAbility 3: Dodge Back\nAbility 4: Dodge Left\n";
				break;
			case DirectionDodge.EightSides:
				Desc = "The Dodge will be done with Vertical, Horizontal and Diagonal Sides\nAbility 1: Dodge Front\nAbility 2: Dodge Front Left\nAbility 3: Dodge Left\nAbility 4: Dodge Back Left\nAbility 5: Dodge Back\nAbility 6: Dodge Back Right\nAbility 7: Dodge Right\nAbility 8: Dodge Front Right";
				break;
			}
		}
	}
}

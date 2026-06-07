using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Directional")]
	[Image(typeof(IconGamepadCross), ColorTheme.Type.Green)]
	[Category("Directional")]
	[Description("Moves the Player using a directional input from the Main Camera's perspective")]
	public class UnitPlayerDirectional : TUnitPlayer
	{
		[SerializeField]
		private InputPropertyValueVector2 m_InputMove;

		public UnitPlayerDirectional()
		{
			m_InputMove = InputValueVector2MotionPrimary.Create();
		}

		public override void OnStartup(Character character)
		{
			base.OnStartup(character);
			m_InputMove.OnStartup();
		}

		public override void OnDispose(Character character)
		{
			base.OnDispose(character);
			m_InputMove.OnDispose();
		}

		public override void OnDisable()
		{
			base.OnDisable();
			base.Character.Motion?.MoveToDirection(Vector3.zero, Space.World, 0);
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			m_InputMove.OnUpdate();
			base.InputDirection = Vector3.zero;
			if (base.Character.IsPlayer)
			{
				Vector3 input = (m_IsControllable ? m_InputMove.Read() : Vector2.zero);
				base.InputDirection = GetMoveDirection(input);
				float num = base.Character.Motion?.LinearSpeed ?? 0f;
				base.Character.Motion?.MoveToDirection(base.InputDirection * num, Space.World, 0);
			}
		}

		protected virtual Vector3 GetMoveDirection(Vector3 input)
		{
			Vector3 vector = new Vector3(input.x, 0f, input.y);
			Vector3 vector2 = ((base.Camera != null) ? Quaternion.Euler(0f, base.Camera.rotation.eulerAngles.y, 0f) : Quaternion.identity) * vector;
			vector2.Scale(Vector3Plane.NormalUp);
			vector2.Normalize();
			return vector2 * vector.magnitude;
		}

		public override string ToString()
		{
			return "Directional";
		}
	}
}

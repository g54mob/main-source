using System;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("At Pointer")]
	[Image(typeof(IconCursor), ColorTheme.Type.Green)]
	[Category("Targets/At Pointer")]
	[Description("Rotates towards where the pointer is, relative to the Character")]
	public class UnitFacingPointer : TUnitFacing
	{
		private enum Axis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private const float MIN_DISTANCE = 0.05f;

		[SerializeField]
		private Axis m_InPlane;

		[SerializeField]
		private Axonometry m_Axonometry = new Axonometry();

		public override Axonometry Axonometry
		{
			get
			{
				return m_Axonometry;
			}
			set
			{
				m_Axonometry = value;
			}
		}

		public UnitFacingPointer()
		{
			m_InPlane = Axis.Y;
		}

		protected override Vector3 GetDefaultDirection()
		{
			if (!base.Character.IsPlayer || !base.Character.Player.IsControllable)
			{
				Vector3 vector = DecideDirection(Vector3.zero);
				return m_Axonometry?.ProcessRotation(this, vector) ?? vector;
			}
			Camera camera = ShortcutMainCamera.Get<Camera>();
			if (camera == null)
			{
				Vector3 vector2 = DecideDirection(Vector3.zero);
				return m_Axonometry?.ProcessRotation(this, vector2) ?? vector2;
			}
			Vector2 vector3 = Mouse.current?.position.ReadValue() ?? ((Vector2)base.Character.Feet);
			Ray ray = camera.ScreenPointToRay(vector3);
			if (!new Plane(m_InPlane switch
			{
				Axis.X => Vector3.right, 
				Axis.Y => Vector3.up, 
				Axis.Z => Vector3.forward, 
				_ => throw new ArgumentOutOfRangeException(), 
			}, base.Character.Feet).Raycast(ray, out var enter))
			{
				Vector3 vector4 = DecideDirection(Vector3.zero);
				return m_Axonometry?.ProcessRotation(this, vector4) ?? vector4;
			}
			Vector3 vector5 = Vector3.Scale(ray.GetPoint(enter) - base.Character.Feet, Vector3Plane.NormalUp);
			Vector3 vector6 = DecideDirection((vector5.sqrMagnitude > 0.05f) ? vector5 : Vector3.zero);
			return m_Axonometry?.ProcessRotation(this, vector6) ?? vector6;
		}

		public override string ToString()
		{
			return "At Pointer";
		}
	}
}

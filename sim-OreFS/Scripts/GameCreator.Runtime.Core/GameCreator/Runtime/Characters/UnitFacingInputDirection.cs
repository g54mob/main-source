using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Input Direction")]
	[Image(typeof(IconGamepadCross), ColorTheme.Type.Yellow)]
	[Category("Direction/Input Direction")]
	[Description("Rotates the Character towards the input direction from a camera")]
	public class UnitFacingInputDirection : TUnitFacing
	{
		[SerializeField]
		private InputPropertyValueVector2 m_Input = InputValueVector2MobileStickRight.Create;

		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		[SerializeField]
		private Axonometry m_Axonometry = new Axonometry();

		[NonSerialized]
		private Args m_Args;

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

		public override void OnStartup(Character character)
		{
			base.OnStartup(character);
			m_Input?.OnStartup();
		}

		public override void OnDispose(Character character)
		{
			base.OnDispose(character);
			m_Input?.OnDispose();
		}

		protected override Vector3 GetDefaultDirection()
		{
			if (m_Args == null)
			{
				m_Args = new Args(base.Character);
			}
			Vector2 vector = m_Input?.Read() ?? default(Vector2);
			Vector3 vector2 = new Vector3(vector.x, 0f, vector.y);
			Camera camera = m_Camera.Get<Camera>(m_Args);
			if (camera != null)
			{
				vector2 = camera.transform.TransformDirection(vector2);
			}
			Vector3 driverDirection = Vector3.Scale(vector2, Vector3Plane.NormalUp);
			Vector3 vector3 = DecideDirection(driverDirection);
			return m_Axonometry?.ProcessRotation(this, vector3) ?? vector3;
		}

		public override string ToString()
		{
			return "Input Direction";
		}
	}
}

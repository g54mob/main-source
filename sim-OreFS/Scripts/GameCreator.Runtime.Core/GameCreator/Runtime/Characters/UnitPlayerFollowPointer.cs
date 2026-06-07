using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Follow Pointer")]
	[Image(typeof(IconCursor), ColorTheme.Type.Green)]
	[Category("Follow Pointer")]
	[Description("Moves the Player straight towards the pointer, relative to itself")]
	public class UnitPlayerFollowPointer : TUnitPlayer
	{
		private class RaycastComparer : IComparer<RaycastHit>
		{
			public int Compare(RaycastHit a, RaycastHit b)
			{
				return a.distance.CompareTo(b.distance);
			}
		}

		private const int BUFFER_SIZE = 32;

		private static readonly RaycastComparer RAYCAST_COMPARER = new RaycastComparer();

		[SerializeField]
		private InputPropertyButton m_InputMove;

		[SerializeField]
		private PropertyGetInstantiate m_Indicator;

		[NonSerialized]
		private RaycastHit[] m_HitBuffer;

		[NonSerialized]
		private Vector3 m_Direction;

		[NonSerialized]
		private bool m_PointerPress;

		[NonSerialized]
		private Vector3 m_Pointer;

		public UnitPlayerFollowPointer()
		{
			m_Indicator = new PropertyGetInstantiate
			{
				usePooling = true,
				size = 5,
				hasDuration = true,
				duration = 1f
			};
			m_InputMove = InputButtonMouseWhilePressing.Create();
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

		public override void OnEnable()
		{
			base.OnEnable();
			m_HitBuffer = new RaycastHit[32];
			m_InputMove.RegisterStart(OnStartPointer);
			m_InputMove.RegisterPerform(OnPerformPointer);
			m_Direction = Vector3.zero;
		}

		public override void OnDisable()
		{
			base.OnDisable();
			m_HitBuffer = Array.Empty<RaycastHit>();
			m_InputMove.ForgetStart(OnStartPointer);
			m_InputMove.ForgetPerform(OnPerformPointer);
			base.Character.Motion?.MoveToDirection(Vector3.zero, Space.World, 0);
			m_Direction = Vector3.zero;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			m_InputMove.OnUpdate();
			if (base.Character.IsPlayer)
			{
				float num = base.Character.Motion?.LinearSpeed ?? 0f;
				base.Character.Motion?.MoveToDirection(m_Direction * num, Space.World, 0);
				if (m_PointerPress)
				{
					m_Indicator.Get(base.Character.gameObject, m_Pointer, Quaternion.identity);
				}
				m_Direction = Vector3.zero;
				m_PointerPress = false;
				m_Pointer = Vector3.zero;
			}
		}

		private void OnStartPointer()
		{
			if (base.Character.IsPlayer && base.Character.Player.IsControllable)
			{
				m_PointerPress = true;
			}
		}

		private void OnPerformPointer()
		{
			if (base.Character.IsPlayer)
			{
				m_Pointer = GetFollowPoint();
				m_Direction = (m_Pointer - base.Character.Feet).normalized;
			}
		}

		private Vector3 GetFollowPoint()
		{
			if (!m_IsControllable)
			{
				return base.Character.Feet;
			}
			Ray ray = ShortcutMainCamera.Get<Camera>().ScreenPointToRay(Application.isMobilePlatform ? Touchscreen.current.primaryTouch.position.ReadValue() : Mouse.current.position.ReadValue());
			int num = Physics.RaycastNonAlloc(ray, m_HitBuffer, float.PositiveInfinity, -1, QueryTriggerInteraction.Ignore);
			Array.Sort(m_HitBuffer, 0, num, RAYCAST_COMPARER);
			if (num == 0)
			{
				return base.Character.Feet;
			}
			if ((m_HitBuffer[0].transform.gameObject.layer & 0x20) > 0)
			{
				return base.Character.Feet;
			}
			if (!new Plane(Vector3.up, base.Character.Feet).Raycast(ray, out var enter))
			{
				return base.Character.Feet;
			}
			Vector3 point = ray.GetPoint(enter);
			float num2 = Vector3.Distance(base.Character.Feet, point);
			float radius = base.Character.Motion.Radius;
			if (!(num2 >= radius))
			{
				return base.Character.Feet;
			}
			return point;
		}

		public override string ToString()
		{
			return "Follow Pointer";
		}
	}
}

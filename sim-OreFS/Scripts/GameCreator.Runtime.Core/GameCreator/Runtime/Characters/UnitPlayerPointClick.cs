using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Point & Click")]
	[Image(typeof(IconLocationDrop), ColorTheme.Type.Green)]
	[Category("Point & Click")]
	[Description("Moves the Player where the pointer's position clicks from the Main Camera's perspective")]
	public class UnitPlayerPointClick : TUnitPlayer
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
		private LayerMask m_LayerMask;

		[SerializeField]
		private PropertyGetInstantiate m_Indicator;

		[NonSerialized]
		private RaycastHit[] m_HitBuffer;

		[NonSerialized]
		private bool m_Press;

		[NonSerialized]
		private Location m_Location;

		public UnitPlayerPointClick()
		{
			m_LayerMask = -5;
			m_Indicator = new PropertyGetInstantiate
			{
				usePooling = true,
				size = 5,
				hasDuration = true,
				duration = 1f
			};
			m_InputMove = InputButtonMousePress.Create();
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
			m_InputMove.RegisterStart(OnStartPointClick);
			m_InputMove.RegisterPerform(OnPerformPointClick);
		}

		public override void OnDisable()
		{
			base.OnDisable();
			m_HitBuffer = Array.Empty<RaycastHit>();
			m_InputMove.ForgetStart(OnStartPointClick);
			m_InputMove.ForgetPerform(OnPerformPointClick);
			base.Character.Motion?.MoveToDirection(Vector3.zero, Space.World, 0);
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			m_InputMove.OnUpdate();
			GameObject gameObject = base.Character.gameObject;
			if (m_Location.HasPosition(gameObject))
			{
				Vector3 position = m_Location.GetPosition(gameObject);
				base.Character.Motion?.MoveToLocation(m_Location, 0.1f, null, 0);
				if (m_Press)
				{
					m_Indicator.Get(gameObject, position, Quaternion.identity);
				}
				m_Press = false;
				m_Location = Location.None;
			}
		}

		private void OnStartPointClick()
		{
			if (base.Character.IsPlayer && base.Character.Player.IsControllable)
			{
				m_Press = true;
			}
		}

		private void OnPerformPointClick()
		{
			if (!base.Character.IsPlayer || !m_IsControllable)
			{
				return;
			}
			int num = Physics.RaycastNonAlloc(ShortcutMainCamera.Get<Camera>().ScreenPointToRay(Application.isMobilePlatform ? Touchscreen.current.primaryTouch.position.ReadValue() : Mouse.current.position.ReadValue()), m_HitBuffer, float.PositiveInfinity, m_LayerMask, QueryTriggerInteraction.Ignore);
			Array.Sort(m_HitBuffer, 0, num, RAYCAST_COMPARER);
			for (int i = 0; i < num && (m_HitBuffer[i].transform.gameObject.layer & 0x20) <= 0; i++)
			{
				if (!m_HitBuffer[i].transform.IsChildOf(base.Transform))
				{
					Vector3 point = m_HitBuffer[i].point;
					m_Location = new Location(point);
					base.InputDirection = Vector3.Scale(point - base.Character.transform.position, Vector3Plane.NormalUp);
					break;
				}
			}
		}

		public override string ToString()
		{
			return "Point & Click";
		}
	}
}

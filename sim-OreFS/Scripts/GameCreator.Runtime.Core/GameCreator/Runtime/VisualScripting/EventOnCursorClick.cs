using System;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Cursor Click")]
	[Category("Input/On Cursor Click")]
	[Description("Detects when the cursor clicks this game object")]
	[Image(typeof(IconCursor), ColorTheme.Type.Yellow)]
	[Keywords(new string[] { "Down", "Mouse", "Button", "Hover" })]
	public class EventOnCursorClick : TEventMouse
	{
		[SerializeField]
		private LayerMask m_LayerMask = -5;

		[SerializeField]
		private int m_PressCount = 1;

		private RaycastHit m_Hit3D;

		private RaycastHit2D m_Hit2D;

		public override bool RequiresCollider => true;

		protected override bool InteractionSuccessful(Trigger trigger)
		{
			bool flag = m_PressCount == base.PressCount;
			if (base.WasPressedThisFrame && flag)
			{
				return CheckRaycast(trigger);
			}
			return false;
		}

		private bool CheckRaycast(Trigger trigger)
		{
			if (ShortcutMainCamera.Instance == null)
			{
				return false;
			}
			Camera camera = ShortcutMainCamera.Instance.Get<Camera>();
			if (camera == null)
			{
				return false;
			}
			Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
			bool hit = Physics.Raycast(ray, out m_Hit3D, float.PositiveInfinity, m_LayerMask, QueryTriggerInteraction.Ignore);
			if (RaycastHit3D(hit, trigger))
			{
				return true;
			}
			m_Hit2D = Physics2D.Raycast(ray.origin, ray.direction, float.PositiveInfinity, m_LayerMask);
			return RaycastHit2D(m_Hit2D.collider != null, trigger);
		}

		private bool RaycastHit3D(bool hit, Trigger trigger)
		{
			if (!hit)
			{
				return false;
			}
			return m_Hit3D.collider.gameObject == trigger.gameObject;
		}

		private bool RaycastHit2D(bool hit, Trigger trigger)
		{
			if (!hit)
			{
				return false;
			}
			return m_Hit2D.collider.gameObject == trigger.gameObject;
		}
	}
}

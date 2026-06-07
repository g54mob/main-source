using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Touch")]
	[Category("Input/On Touch")]
	[Description("Detects when a finger touches this game object on a touchscreen")]
	[Image(typeof(IconTouch), ColorTheme.Type.Yellow)]
	[Keywords(new string[] { "Down", "Finger", "Press", "Click" })]
	public class EventOnTouch : TEventTouch
	{
		[SerializeField]
		private LayerMask m_LayerMask = -5;

		[SerializeField]
		private EnablerInt m_TapCount = new EnablerInt(isEnabled: false, 2);

		private RaycastHit m_Hit3D;

		private RaycastHit2D m_Hit2D;

		public override bool RequiresCollider => true;

		protected override bool InteractionSuccessful(Trigger trigger)
		{
			bool flag = !m_TapCount.IsEnabled || m_TapCount.Value == base.TapCount;
			if (base.WasTouchedThisFrame && flag)
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
			Vector2 position = base.Position;
			Ray ray = camera.ScreenPointToRay(position);
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

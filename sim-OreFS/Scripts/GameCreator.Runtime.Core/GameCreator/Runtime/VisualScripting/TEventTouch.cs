using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Utilities;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Min Distance", "If set to None, the touch input acts globally. If set to Game Object, the event only fires if the target object is within a certain radius")]
	[Keywords(new string[] { "Finger", "Press", "Click" })]
	public abstract class TEventTouch : Event
	{
		private static readonly List<RaycastResult> HITS = new List<RaycastResult>();

		[SerializeField]
		private CompareMinDistanceOrNone m_MinDistance = new CompareMinDistanceOrNone();

		protected bool WasTouchedThisFrame
		{
			get
			{
				foreach (Touch activeTouch in Touch.activeTouches)
				{
					if (activeTouch.began)
					{
						return true;
					}
				}
				return false;
			}
		}

		protected bool WasReleasedThisFrame
		{
			get
			{
				foreach (Touch activeTouch in Touch.activeTouches)
				{
					if (activeTouch.ended)
					{
						return true;
					}
				}
				return false;
			}
		}

		protected bool IsPressed
		{
			get
			{
				foreach (Touch activeTouch in Touch.activeTouches)
				{
					if (activeTouch.inProgress)
					{
						return true;
					}
				}
				return false;
			}
		}

		protected int TapCount
		{
			get
			{
				ReadOnlyArray<Touch> activeTouches = Touch.activeTouches;
				int num = ((activeTouches.Count > 0) ? 1 : 0);
				foreach (Touch item in activeTouches)
				{
					if (num < item.tapCount)
					{
						num = item.tapCount;
					}
				}
				return num;
			}
		}

		protected Vector2 Position
		{
			get
			{
				ReadOnlyArray<Touch> activeTouches = Touch.activeTouches;
				if (activeTouches.Count <= 0)
				{
					return Vector2.one * -1f;
				}
				return activeTouches[activeTouches.Count - 1].screenPosition;
			}
		}

		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			Singleton<InputManager>.Instance.RequireEnhancedTouchInput();
		}

		protected internal override void OnUpdate(Trigger trigger)
		{
			base.OnUpdate(trigger);
			Singleton<InputManager>.Instance.RequireEnhancedTouchInput();
			if (InteractionSuccessful(trigger) && !IsPointerOverUI() && m_MinDistance.Match(trigger.transform, new Args(base.Self)))
			{
				m_Trigger.Execute(base.Self);
			}
		}

		protected abstract bool InteractionSuccessful(Trigger trigger);

		private static bool IsPointerOverUI()
		{
			if (EventSystem.current == null)
			{
				return false;
			}
			ReadOnlyArray<Touch> activeTouches = Touch.activeTouches;
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			foreach (Touch item in activeTouches)
			{
				pointerEventData.position = item.screenPosition;
				EventSystem.current.RaycastAll(pointerEventData, HITS);
				HITS.Sort(CompareHitDistance);
				if (HITS.Count != 0 && HITS[0].gameObject.layer == 5)
				{
					return true;
				}
			}
			return false;
		}

		private static int CompareHitDistance(RaycastResult x, RaycastResult y)
		{
			return x.distance.CompareTo(y.distance);
		}

		protected internal override void OnDrawGizmosSelected(Trigger trigger)
		{
			base.OnDrawGizmosSelected(trigger);
			m_MinDistance.OnDrawGizmos(trigger.transform, new Args(trigger.gameObject));
		}
	}
}

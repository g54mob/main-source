using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Button", "The mouse button to detect")]
	[Parameter("Min Distance", "If set to None, the mouse input acts globally. If set to Game Object, the event only fires if the target object is within a certain radius")]
	[Keywords(new string[] { "Left", "Middle", "Right" })]
	public abstract class TEventMouse : Event
	{
		private static readonly List<RaycastResult> HITS = new List<RaycastResult>();

		[SerializeField]
		protected MouseButton m_Button;

		[SerializeField]
		private CompareMinDistanceOrNone m_MinDistance = new CompareMinDistanceOrNone();

		protected bool WasPressedThisFrame
		{
			get
			{
				if (Mouse.current != null)
				{
					return GetButton().wasPressedThisFrame;
				}
				return false;
			}
		}

		protected bool WasReleasedThisFrame
		{
			get
			{
				if (Mouse.current != null)
				{
					return GetButton().wasReleasedThisFrame;
				}
				return false;
			}
		}

		protected bool IsPressed
		{
			get
			{
				if (Mouse.current != null)
				{
					return GetButton().IsPressed();
				}
				return false;
			}
		}

		protected int PressCount
		{
			get
			{
				if (Mouse.current == null)
				{
					return 0;
				}
				return Mouse.current.clickCount.ReadValue();
			}
		}

		protected internal override void OnUpdate(Trigger trigger)
		{
			base.OnUpdate(trigger);
			if (InteractionSuccessful(trigger) && !IsPointerOverUI() && m_MinDistance.Match(trigger.transform, new Args(base.Self)))
			{
				m_Trigger.Execute(base.Self);
			}
		}

		protected abstract bool InteractionSuccessful(Trigger trigger);

		private ButtonControl GetButton()
		{
			return m_Button switch
			{
				MouseButton.Left => Mouse.current.leftButton, 
				MouseButton.Right => Mouse.current.rightButton, 
				MouseButton.Middle => Mouse.current.middleButton, 
				MouseButton.Forward => Mouse.current.forwardButton, 
				MouseButton.Back => Mouse.current.backButton, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		private static bool IsPointerOverUI()
		{
			if (EventSystem.current == null)
			{
				return false;
			}
			PointerEventData eventData = new PointerEventData(EventSystem.current)
			{
				position = Mouse.current.position.ReadValue()
			};
			EventSystem.current.RaycastAll(eventData, HITS);
			HITS.Sort(CompareHitDistance);
			if (HITS.Count != 0)
			{
				return HITS[0].gameObject.layer == 5;
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

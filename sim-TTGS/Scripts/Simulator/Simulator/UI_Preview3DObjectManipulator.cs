using System;
using Dhs5.Utility.Updates;
using Simulator.Preview3D;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Simulator
{
	public class UI_Preview3DObjectManipulator : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
	{
		[Flags]
		public enum ERotationAxis
		{
			PITCH = 1,
			YAW = 2
		}

		[ReadOnly(true, false)]
		private IPreview3DObject m_target;

		private Vector2 m_cursorPositionAtBeginDrag;

		private bool m_updateRegistered;

		private ERotationAxis RotationAxis => Preview3DSettings.RotationAxis;

		private bool HideCursorOnDrag => Preview3DSettings.HideCursorOnDrag;

		private bool CursorStayAtPositionOnDragEnd => Preview3DSettings.CursorStayAtPositionOnDragEnd;

		public IPreview3DObject Target
		{
			set
			{
				if (value == null)
				{
					Debug.LogError("New target value is null");
				}
				m_target = value;
			}
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (m_target == null)
			{
				eventData.pointerDrag = null;
			}
			else if (HideCursorOnDrag)
			{
				Cursor.visible = false;
				if (CursorStayAtPositionOnDragEnd)
				{
					m_cursorPositionAtBeginDrag = Mouse.current.position.ReadValue();
				}
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			Rotate(eventData.delta);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			Cursor.visible = true;
			if (HideCursorOnDrag && CursorStayAtPositionOnDragEnd)
			{
				Mouse.current.WarpCursorPosition(m_cursorPositionAtBeginDrag);
			}
		}

		public void RegisterToUpdate(bool register)
		{
			if (m_updateRegistered != register)
			{
				m_updateRegistered = register;
				Updater.RegisterChannelCallback(register, EUpdateChannel.CLASSIC, OnUpdate);
			}
		}

		private void Rotate(Vector2 delta)
		{
			if (RotationAxis.HasFlag(ERotationAxis.PITCH))
			{
				delta.x = 0f - delta.x;
			}
			else
			{
				delta.x = 0f;
			}
			if (RotationAxis.HasFlag(ERotationAxis.YAW))
			{
				delta.y = 0f - delta.y;
			}
			else
			{
				delta.y = 0f;
			}
			m_target.Rotate(delta);
		}

		private void OnUpdate(float deltaTime)
		{
			if (m_target != null && Gamepad.current != null)
			{
				Vector2 vector = Gamepad.current.rightStick.ReadValue();
				if (!(vector == Vector2.zero))
				{
					Rotate(vector * Preview3DSettings.GamepadDragSpeedMultiplier * deltaTime);
				}
			}
		}
	}
}

using System;
using Dhs5.Utility.Tags;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class Door : MonoBehaviour
	{
		[Serializable]
		public struct DoorAxis
		{
			[SerializeField]
			private Transform m_axis;

			[SerializeField]
			private float m_openLocalAngle;

			[SerializeField]
			private float m_closeLocalAngle;

			public Transform Axis => m_axis;

			public float OpenLocalAngle => m_openLocalAngle;

			public float CloseLocalAngle => m_closeLocalAngle;
		}

		[Header("References")]
		[SerializeField]
		private DoorTrigger[] m_triggers;

		[Header("Conditions")]
		[SerializeField]
		private GameplayTagsList m_requiredTags;

		[Header("Animation")]
		[SerializeField]
		private DoorAxis[] m_doorsAxis;

		private bool IsOpen { get; set; }

		public GameplayTagsList RequiredTags => m_requiredTags;

		public event Action OnOpen;

		public event Action OnClose;

		private void OnEnable()
		{
			DoorTrigger[] triggers = m_triggers;
			foreach (DoorTrigger doorTrigger in triggers)
			{
				if (doorTrigger != null)
				{
					doorTrigger.CharacterListChanged += OnCharacterListChange;
				}
			}
		}

		private void OnDisable()
		{
			DoorTrigger[] triggers = m_triggers;
			foreach (DoorTrigger doorTrigger in triggers)
			{
				if (doorTrigger != null)
				{
					doorTrigger.CharacterListChanged -= OnCharacterListChange;
				}
			}
		}

		protected virtual void OnCharacterListChange()
		{
			if (IsOpen && !HasCharacterInside())
			{
				TrySetOpen(open: false);
			}
			else if (!IsOpen && HasCharacterInside())
			{
				TrySetOpen(open: true);
			}
		}

		private bool HasCharacterInside()
		{
			DoorTrigger[] triggers = m_triggers;
			foreach (DoorTrigger doorTrigger in triggers)
			{
				if (doorTrigger != null && doorTrigger.HasCharacterInside())
				{
					return true;
				}
			}
			return false;
		}

		protected virtual bool CanOpen(bool open)
		{
			if (open)
			{
				if (!IsOpen)
				{
					return HasCharacterInside();
				}
				return false;
			}
			if (IsOpen)
			{
				return !HasCharacterInside();
			}
			return false;
		}

		protected bool TrySetOpen(bool open)
		{
			if (!CanOpen(open))
			{
				return false;
			}
			SetOpen(open);
			return true;
		}

		private void SetOpen(bool open)
		{
			IsOpen = open;
			if (IsOpen)
			{
				Open();
			}
			else
			{
				Close();
			}
		}

		private void Open()
		{
			SetOpenVisual();
			this.OnOpen?.Invoke();
		}

		private void Close()
		{
			SetCloseVisual();
			this.OnClose?.Invoke();
		}

		private void SetOpenVisual()
		{
			for (int i = 0; i < m_doorsAxis.Length; i++)
			{
				DoorAxis doorAxis = m_doorsAxis[i];
				doorAxis.Axis.localRotation = Quaternion.Euler(0f, doorAxis.OpenLocalAngle, 0f);
			}
		}

		private void SetCloseVisual()
		{
			for (int i = 0; i < m_doorsAxis.Length; i++)
			{
				DoorAxis doorAxis = m_doorsAxis[i];
				doorAxis.Axis.localRotation = Quaternion.Euler(0f, doorAxis.CloseLocalAngle, 0f);
			}
		}
	}
}

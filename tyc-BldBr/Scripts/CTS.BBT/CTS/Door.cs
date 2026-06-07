using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using DG.Tweening;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(BoxCollider))]
	public class Door : CTSBehaviour
	{
		[SerializeField]
		private DoorVisualSelector _doorVisual;

		[SerializeField]
		[Inject(false)]
		private BoxCollider _trigger;

		[SerializeField]
		private float _openRotation = 90f;

		[SerializeField]
		private Ease _easeOpen;

		[SerializeField]
		private Ease _easeClose;

		[SerializeField]
		private float _defaultYRotation;

		[SerializeField]
		private bool _debug;

		private int _currentUsers;

		private bool _hitLastFrame;

		[Header("Sound Assets")]
		[SerializeField]
		private AudioAsset _openAudioAsset;

		[SerializeField]
		private AudioAsset _closeAudioAsset;

		public bool Open { get; private set; }

		public static event Action<Door> OpeningDoor;

		public static event Action<Door> ClosingDoor;

		public event Action<bool> OnDoorOpen;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_trigger.isTrigger = true;
			_defaultYRotation = _doorVisual.CurrentDoor.eulerAngles.y;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_doorVisual.CurrentDoor.eulerAngles = _doorVisual.CurrentDoor.eulerAngles.SetY(_defaultYRotation);
		}

		private void OnTriggerStay(Collider other)
		{
			if (!other.transform.parent.TryGetComponent<Agent>(out var component))
			{
				return;
			}
			_hitLastFrame = true;
			Vector3 velocity = component.Movement.Velocity;
			if (!(velocity.sqrMagnitude < 1E-05f))
			{
				velocity = velocity.normalized;
				Vector3 normalized = (base.transform.position - component.transform.position).normalized;
				if (!(Vector3.Dot(velocity, normalized) < 0.1f))
				{
					float num = Vector3.Dot(velocity, base.transform.forward);
					float rotation = _openRotation * (float)((!(num > 0f)) ? 1 : (-1));
					OpenDoor(rotation);
				}
			}
		}

		private void FixedUpdate()
		{
			if (!_hitLastFrame)
			{
				CloseDoor();
			}
			_hitLastFrame = false;
		}

		private void OpenDoor(float rotation)
		{
			if (!Open)
			{
				Open = true;
				_doorVisual.CurrentDoor.DOKill();
				_doorVisual.CurrentDoor.DORotate(new Vector3(0f, _defaultYRotation - rotation, 0f), 0.25f).SetEase(_easeOpen);
				Door.OpeningDoor?.Invoke(this);
				this.OnDoorOpen?.Invoke(obj: true);
				MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(_openAudioAsset, _doorVisual.CurrentDoor.position);
			}
		}

		private void CloseDoor()
		{
			if (Open)
			{
				Open = false;
				Door.ClosingDoor?.Invoke(this);
				this.OnDoorOpen?.Invoke(obj: false);
				MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(_closeAudioAsset, _doorVisual.CurrentDoor.position);
				_doorVisual.CurrentDoor.DOKill();
				_doorVisual.CurrentDoor.DORotate(new Vector3(0f, _defaultYRotation, 0f), 1f).SetEase(_easeClose);
			}
		}

		public void ForceClose()
		{
			if (!_hitLastFrame)
			{
				CloseDoor();
			}
		}

		public void ForceOpen()
		{
			if (!_hitLastFrame)
			{
				OpenDoor(_openRotation);
			}
		}
	}
}

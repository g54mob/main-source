using System;
using System.Collections.Generic;
using Kitchen.Components;
using KitchenData;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.VFX;

namespace Kitchen
{
	public class PlayerEffectsComponent : MonoBehaviour
	{
		[Serializable]
		public struct ProcessAudioLookup
		{
			public Process Key;

			public AudioClip Value;
		}

		[FormerlySerializedAs("Footsteps")]
		[Header("References")]
		[SerializeField]
		private VisualEffect FootstepsVFX;

		[SerializeField]
		private SoundSource FootstepSound;

		[SerializeField]
		private SoundSource PickupSound;

		[SerializeField]
		private SoundSource DropSound;

		[SerializeField]
		private SoundSource InteractionSound;

		[SerializeField]
		private List<ProcessAudioLookup> Sounds = new List<ProcessAudioLookup>();

		[Header("State")]
		private bool FootstepsActive;

		private bool PlayProcessSound;

		private int Process;

		private int CurrentSoundProcess;

		private bool HasProcessSound;

		private bool IsHolding;

		private bool IsMoving;

		private bool IsPaused;

		private void Start()
		{
			if ((bool)FootstepsVFX)
			{
				FootstepsVFX.Stop();
			}
			if ((bool)FootstepSound)
			{
				FootstepSound.Pitch = 0.9f + 0.2f * UnityEngine.Random.value;
			}
		}

		public void UpdateData(int process, bool is_interacting, bool is_holding, bool is_paused)
		{
			Process = process;
			PlayProcessSound = Process != 0 && is_interacting;
			IsPaused = is_paused;
		}

		public void UpdateMoving(bool is_moving)
		{
			IsMoving = is_moving;
		}

		private AudioClip GetSound(int process)
		{
			foreach (ProcessAudioLookup sound in Sounds)
			{
				if (sound.Key.ID == process)
				{
					return sound.Value;
				}
			}
			return null;
		}

		private void Update()
		{
			if (IsPaused)
			{
				if ((bool)InteractionSound)
				{
					InteractionSound.Stop();
				}
				if ((bool)FootstepSound)
				{
					FootstepSound.Stop();
				}
				return;
			}
			if (Process != CurrentSoundProcess)
			{
				AudioClip sound = GetSound(Process);
				CurrentSoundProcess = Process;
				HasProcessSound = sound != null;
				if (HasProcessSound && (bool)InteractionSound)
				{
					InteractionSound.Clip = sound;
				}
			}
			if (HasProcessSound && PlayProcessSound)
			{
				if ((bool)InteractionSound)
				{
					InteractionSound.Play();
				}
			}
			else if ((bool)InteractionSound)
			{
				InteractionSound.Stop();
			}
			if (IsMoving)
			{
				if (!FootstepsActive && (bool)FootstepsVFX)
				{
					FootstepsVFX.Play();
				}
				if ((bool)FootstepSound)
				{
					FootstepSound.Play();
				}
			}
			else
			{
				if (FootstepsActive && (bool)FootstepsVFX)
				{
					FootstepsVFX.Stop();
				}
				if ((bool)FootstepSound)
				{
					FootstepSound.Stop();
				}
			}
			FootstepsActive = IsMoving;
		}
	}
}

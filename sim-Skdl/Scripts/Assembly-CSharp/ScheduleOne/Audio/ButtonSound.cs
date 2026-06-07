using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ScheduleOne.Audio
{
	[RequireComponent(typeof(Button))]
	[RequireComponent(typeof(EventTrigger))]
	[RequireComponent(typeof(AudioSourceController))]
	public class ButtonSound : MonoBehaviour
	{
		[SerializeField]
		[FormerlySerializedAs("PlaySoundOnClickStart")]
		private bool _playSoundOnClickStart;

		[FormerlySerializedAs("HoverClip")]
		[SerializeField]
		private AudioClip _hoverClip;

		[FormerlySerializedAs("HoverSoundVolume")]
		[SerializeField]
		private float _hoverVolume;

		[FormerlySerializedAs("ClickClip")]
		[SerializeField]
		private AudioClip _clickClip;

		[FormerlySerializedAs("ClickSoundVolume")]
		[SerializeField]
		private float _clickVolume;

		private AudioSourceController _audioSource;

		private Button _button;

		private EventTrigger _eventTrigger;

		public void Awake()
		{
		}

		public void AddEventTrigger(EventTrigger eventTrigger, EventTriggerType eventTriggerType, Action action)
		{
		}

		protected virtual void Hovered()
		{
		}

		protected virtual void Clicked()
		{
		}
	}
}

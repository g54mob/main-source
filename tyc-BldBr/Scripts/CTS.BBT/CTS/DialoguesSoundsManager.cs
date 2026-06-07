using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class DialoguesSoundsManager : MonoBehaviour
	{
		[Serializable]
		private struct ActorAudioConfig
		{
			public EActors Actor;

			public AudioAsset DefaultAudio;

			public AudioAsset HappyAudio;

			public AudioAsset AngryAudio;
		}

		[SerializeField]
		private AudioAsset _conversationPanelOpening;

		[SerializeField]
		private bool _debug;

		[SerializeField]
		private List<ActorAudioConfig> _conversationActorsSounds;

		private void OnDisable()
		{
			ConversationPanelEvents.ConversationPanelOpening -= OnConversationPanelOpening;
			DialogueEvents.ConversationLinePlaying -= OnConversationLinePlaying;
		}

		private void OnEnable()
		{
			ConversationPanelEvents.ConversationPanelOpening += OnConversationPanelOpening;
			DialogueEvents.ConversationLinePlaying += OnConversationLinePlaying;
		}

		private void OnConversationLinePlaying(EActors actor, EMood mood)
		{
			if (actor != EActors.Player)
			{
				MonoSingleton<SoundManager>.Instance.PlayAudioAsset(GetAudioForActorAndMood(actor, mood));
				if (_debug)
				{
					MonoBehaviour.print("Line actor: " + actor.ToString() + " | Mood: " + mood);
				}
			}
		}

		private void OnConversationPanelOpening()
		{
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_conversationPanelOpening);
		}

		private AudioAsset GetAudioForActorAndMood(EActors actor, EMood mood)
		{
			foreach (ActorAudioConfig conversationActorsSound in _conversationActorsSounds)
			{
				if (conversationActorsSound.Actor == actor)
				{
					switch (mood)
					{
					case EMood.Neutral:
						return conversationActorsSound.DefaultAudio;
					case EMood.Offended:
						return conversationActorsSound.AngryAudio;
					case EMood.Honored:
						return conversationActorsSound.HappyAudio;
					}
				}
			}
			return null;
		}
	}
}

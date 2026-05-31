using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Emotes;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class VigilanceEmotes : CTSSingleton<VigilanceEmotes>
	{
		[SerializeField]
		private PaletteData _emoteContentColor;

		[SerializeField]
		private Sprite _emoteAddBackground;

		[SerializeField]
		private PaletteData _emoteAddColor;

		[SerializeField]
		private Sprite _emoteRemoveBackground;

		[SerializeField]
		private PaletteData _emoteRemoveColor;

		[SerializeField]
		private string _baseText = "<line-height=75%><size=150%><sprite=\"Emoji_Notifications_Overlay\" index=\"11\">\n</size>";

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public void Play(Agent agent, EBone bone, int amount, Vector3 localOffset = default(Vector3))
		{
			if (agent.SkeletonData.TryGetBone(bone, out var boneTransform))
			{
				Play(boneTransform.position + agent.transform.rotation * localOffset, amount);
			}
		}

		public void Play(Vector3 position, int amount)
		{
			if (amount != 0)
			{
				if (amount > 0)
				{
					PlayPositive(position, amount);
				}
				else
				{
					PlayNegative(position, amount);
				}
			}
		}

		public void PlayPositive(Vector3 position, int amount)
		{
			amount = Math.Abs(amount);
			EmoteBBT emote = EmoteManager.Play<EmoteBBT>(position, _baseText + "+" + amount);
			emote.SetBackgroundSprite(_emoteAddBackground);
			emote.SetBackgroundColor(_emoteAddColor);
			SetupEmote(emote);
		}

		public void PlayNegative(Vector3 position, int amount)
		{
			if (amount > 0)
			{
				amount = -amount;
			}
			EmoteBBT emote = EmoteManager.Play<EmoteBBT>(position, _baseText + amount);
			emote.SetBackgroundSprite(_emoteRemoveBackground);
			emote.SetBackgroundColor(_emoteRemoveColor);
			SetupEmote(emote);
		}

		private void SetupEmote(EmoteBBT emote)
		{
			emote.SetContentColor(_emoteContentColor);
			emote.SetPadding(75f);
		}
	}
}

using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Pooling;
using UnityEngine;

namespace CTS.Emotes
{
	public class EmoteManager : MonoSingleton<EmoteManager>
	{
		[SerializeField]
		private EmotePlayer _emotePlayerPrefab;

		private static EmotePlayer _staticEmotePlayer;

		private static readonly List<Transform> Parents = new List<Transform>();

		private static readonly List<EmotePlayer> Players = new List<EmotePlayer>();

		private static EmotePlayer EmotePlayerPrefab
		{
			get
			{
				if ((bool)_staticEmotePlayer)
				{
					return _staticEmotePlayer;
				}
				_staticEmotePlayer = MonoSingleton<EmoteManager>.Instance._emotePlayerPrefab;
				return _staticEmotePlayer;
			}
		}

		protected override void SingletonAwake()
		{
		}

		private void LateUpdate()
		{
			for (int num = Players.Count - 1; num >= 0; num--)
			{
				Transform transform = Parents[num];
				if (!(transform == base.transform))
				{
					EmotePlayer emotePlayer = Players[num];
					if (transform == null)
					{
						UnlinkPlayer(emotePlayer);
						break;
					}
					emotePlayer.transform.position = Vector3.Lerp(emotePlayer.transform.position, transform.position, emotePlayer.CurrentEmote.DeltaTime * 15f);
				}
			}
		}

		protected override void OnSingletonDestroy()
		{
			Parents.Clear();
			Players.Clear();
		}

		public static TEmote Play<TEmote>(Vector3 position, string text, TEmote emote = null) where TEmote : Emote, new()
		{
			return GetSimplePlayer(position).Play(text, emote);
		}

		public static TEmote Play<TEmote>(Vector3 position, E_EmoteIcons icon, TEmote emote = null) where TEmote : Emote, new()
		{
			return Play(position, (int)icon, emote);
		}

		public static TEmote Play<TEmote>(Vector3 position, int iconIndex, TEmote emote = null) where TEmote : Emote, new()
		{
			return GetSimplePlayer(position).Play(iconIndex, emote);
		}

		public static TEmote Play<TEmote>(Vector3 position, Sprite sprite, TEmote emote = null) where TEmote : Emote, new()
		{
			return GetSimplePlayer(position).Play(sprite, emote);
		}

		private static EmotePlayer GetSimplePlayer(Vector3 position)
		{
			EmotePlayer emotePlayer = Pooler.Pull(EmotePlayerPrefab, active: true);
			emotePlayer.transform.position = position;
			Parents.Add(MonoSingleton<EmoteManager>.Instance.transform);
			Players.Add(emotePlayer);
			return emotePlayer;
		}

		public static TEmote Play<TEmote>(GameObject gameObject, string text, TEmote emote = null) where TEmote : Emote, new()
		{
			return Play(gameObject.transform, text, emote);
		}

		public static TEmote Play<TEmote>(Component component, string text, TEmote emote = null) where TEmote : Emote, new()
		{
			return Play(component.transform, text, emote);
		}

		public static TEmote Play<TEmote>(Transform parent, string text, TEmote emote = null) where TEmote : Emote, new()
		{
			return (TEmote)GetOrCreatePlayer(parent).Play(text, emote).SetTransform(parent);
		}

		public static TEmote Play<TEmote>(GameObject gameObject, E_EmoteIcons icon, TEmote emote = null) where TEmote : Emote, new()
		{
			return Play(gameObject.transform, icon, emote);
		}

		public static TEmote Play<TEmote>(Component component, E_EmoteIcons icon, TEmote emote = null) where TEmote : Emote, new()
		{
			return Play(component.transform, icon, emote);
		}

		public static TEmote Play<TEmote>(Transform transform, E_EmoteIcons icon, TEmote emote = null) where TEmote : Emote, new()
		{
			return Play(transform, (int)icon, emote);
		}

		public static TEmote Play<TEmote>(GameObject gameObject, int iconIndex, TEmote emote = null) where TEmote : Emote, new()
		{
			return Play(gameObject.transform, iconIndex, emote);
		}

		public static TEmote Play<TEmote>(Component component, int iconIndex, TEmote emote = null) where TEmote : Emote, new()
		{
			return Play(component.transform, iconIndex, emote);
		}

		public static TEmote Play<TEmote>(Transform parent, int iconIndex, TEmote emote = null) where TEmote : Emote, new()
		{
			return (TEmote)GetOrCreatePlayer(parent).Play(iconIndex, emote).SetTransform(parent);
		}

		public static TEmote Play<TEmote>(GameObject gameObject, Sprite sprite, TEmote emote = null) where TEmote : Emote, new()
		{
			return Play(gameObject.transform, sprite, emote);
		}

		public static TEmote Play<TEmote>(Component component, Sprite sprite, TEmote emote = null) where TEmote : Emote, new()
		{
			return Play(component.transform, sprite, emote);
		}

		public static TEmote Play<TEmote>(Transform parent, Sprite sprite, TEmote emote = null) where TEmote : Emote, new()
		{
			return (TEmote)GetOrCreatePlayer(parent).Play(sprite, emote).SetTransform(parent);
		}

		private static EmotePlayer GetOrCreatePlayer(Transform transform)
		{
			EmotePlayer emotePlayer = ((!Parents.Contains(transform)) ? Pooler.Pull(EmotePlayerPrefab, active: true) : Players[Parents.IndexOf(transform)]);
			LinkPlayer(emotePlayer, transform);
			return emotePlayer;
		}

		public static void Kill(Transform parent)
		{
			if (Parents.Contains(parent))
			{
				Players[Parents.IndexOf(parent)].Kill();
			}
		}

		private static void LinkPlayer(EmotePlayer player, Transform transform)
		{
			if (Parents.Contains(transform) && transform != MonoSingleton<EmoteManager>.Instance.transform)
			{
				int index = Parents.IndexOf(transform);
				if (!(Players[index] == player))
				{
					Players[index].TransferPool(player);
				}
			}
			else
			{
				Parents.Add(transform);
				Players.Add(player);
				player.transform.position = transform.position;
			}
		}

		internal static void UnlinkPlayer(EmotePlayer player)
		{
			if (Players.Contains(player))
			{
				int index = Players.IndexOf(player);
				Players.Remove(player);
				Parents.RemoveAt(index);
			}
		}
	}
}

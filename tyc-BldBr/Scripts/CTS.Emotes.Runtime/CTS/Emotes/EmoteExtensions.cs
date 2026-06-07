using UnityEngine;

namespace CTS.Emotes
{
	public static class EmoteExtensions
	{
		public static TEmote SetBackgroundMaterial<TEmote>(this TEmote emote, Material material) where TEmote : Emote
		{
			emote.SetBackgroundMaterial(material);
			return emote;
		}

		public static TEmote SetSpriteMaterial<TEmote>(this TEmote emote, Material material) where TEmote : Emote
		{
			emote.SetSpriteMaterial(material);
			return emote;
		}

		public static TEmote SetText<TEmote>(this TEmote emote, string text) where TEmote : Emote
		{
			emote.SetText(text);
			return emote;
		}

		public static TEmote SetIcon<TEmote>(this TEmote emote, int spriteIndex) where TEmote : Emote
		{
			emote.SetIcon(spriteIndex);
			return emote;
		}

		public static TEmote SetSprite<TEmote>(this TEmote emote, Sprite sprite) where TEmote : Emote
		{
			emote.SetSprite(sprite);
			return emote;
		}

		public static TEmote SetUseScaledTime<TEmote>(this TEmote emote, bool isScaled) where TEmote : Emote
		{
			emote.SetUseScaledTime(isScaled);
			return emote;
		}

		public static TEmote SetContentSize<TEmote>(this TEmote emote, float size) where TEmote : Emote
		{
			emote.SetContentSize(size);
			return emote;
		}

		public static TEmote SetAppearDuration<TEmote>(this TEmote emote, float duration) where TEmote : Emote
		{
			emote.SetAppearDuration(duration);
			return emote;
		}

		public static TEmote SetStayDuration<TEmote>(this TEmote emote, float duration) where TEmote : Emote
		{
			emote.SetStayDuration(duration);
			return emote;
		}

		public static TEmote SetDisappearDuration<TEmote>(this TEmote emote, float duration) where TEmote : Emote
		{
			emote.SetDisappearDuration(duration);
			return emote;
		}

		public static TEmote SetContentColor<TEmote>(this TEmote emote, Color color) where TEmote : Emote
		{
			emote.SetContentColor(color);
			return emote;
		}

		public static TEmote SetBackgroundColor<TEmote>(this TEmote emote, Color color) where TEmote : Emote
		{
			emote.SetBackgroundColor(color);
			return emote;
		}

		public static TEmote SetBackgroundSprite<TEmote>(this TEmote emote, Sprite sprite) where TEmote : Emote
		{
			emote.SetBackgroundSprite(sprite);
			return emote;
		}

		public static TEmote SetEase<TEmote>(this TEmote emote, AnimationCurve easeCurve) where TEmote : Emote
		{
			emote.SetEase(easeCurve);
			return emote;
		}

		public static TEmote SetPadding<TEmote>(this TEmote emote, float padding) where TEmote : Emote
		{
			emote.SetPadding(padding);
			return emote;
		}

		public static TEmote SetHeight<TEmote>(this TEmote emote, float height) where TEmote : Emote
		{
			emote.SetHeight(height);
			return emote;
		}

		public static TEmote SetHeight<TEmote>(this TEmote emote, Collider collider, float offset = 0f) where TEmote : Emote
		{
			emote.SetHeight(collider, offset);
			return emote;
		}

		public static TEmote SetHeight<TEmote>(this TEmote emote, Bounds worldBounds, float offset = 0f) where TEmote : Emote
		{
			emote.SetHeight(worldBounds, offset);
			return emote;
		}
	}
}

using System;
using UnityEngine;

namespace CTS.Emotes
{
	public class Emote : CustomYieldInstruction
	{
		private Func<float> _getDeltaTime;

		private Transform _parent;

		private float _basePadding;

		public override bool keepWaiting => IsPlaying;

		public string Text { get; private set; }

		public Sprite Sprite { get; private set; }

		public Material SpriteMaterial { get; private set; }

		public Material BackgroundMaterial { get; private set; }

		public float ContentSize { get; private set; } = 10f;

		public float AppearDuration { get; private set; } = 1f;

		public AnimationCurve AppearEase { get; private set; }

		public float StayDuration { get; private set; }

		public bool IsInfinite { get; private set; }

		public float DisappearDuration { get; private set; }

		public bool IsRound { get; private set; }

		public float DeltaTime => _getDeltaTime();

		public Color ContentColor { get; private set; }

		public Color BackgroundColor { get; private set; }

		public Sprite BackgroundSprite { get; private set; }

		public float Padding { get; private set; }

		public float Height { get; private set; }

		public EmotePlayer CurrentPlayer { get; private set; }

		public bool IsPlaying
		{
			get
			{
				if ((bool)CurrentPlayer)
				{
					return CurrentPlayer.CurrentEmote == this;
				}
				return false;
			}
		}

		public void Kill()
		{
			StayDuration = 0f;
			IsInfinite = false;
			if (!IsPlaying && (bool)CurrentPlayer)
			{
				CurrentPlayer.RemoveFromQueue(this);
			}
		}

		internal Emote SetTransform(Transform transform)
		{
			_parent = transform;
			return this;
		}

		internal void SetText(string text)
		{
			Text = text;
			IsRound = false;
			Sprite = null;
			SetPadding(_basePadding);
			if (IsPlaying)
			{
				CurrentPlayer.SetText(Text);
			}
		}

		internal void SetIcon(int spriteIndex)
		{
			Text = "<sprite=" + spriteIndex + " tint=1>";
			IsRound = true;
			Sprite = null;
			SetPadding(_basePadding);
			if (IsPlaying)
			{
				CurrentPlayer.SetText(Text);
			}
		}

		internal void SetSprite(Sprite sprite)
		{
			Text = string.Empty;
			Sprite = sprite;
			IsRound = true;
			SetPadding(_basePadding);
			if (IsPlaying)
			{
				CurrentPlayer.SetSprite(sprite);
			}
		}

		internal void SetSpriteMaterial(Material material)
		{
			SpriteMaterial = material;
			if (IsPlaying)
			{
				CurrentPlayer.SetSpriteMaterial(SpriteMaterial);
			}
		}

		internal void SetBackgroundMaterial(Material material)
		{
			BackgroundMaterial = material;
			if (IsPlaying)
			{
				CurrentPlayer.SetBackgroundMaterial(BackgroundMaterial);
			}
		}

		internal void SetUseScaledTime(bool isScaled)
		{
			if (isScaled)
			{
				_getDeltaTime = () => Time.deltaTime;
			}
			else
			{
				_getDeltaTime = () => Time.unscaledDeltaTime;
			}
		}

		internal void SetContentSize(float size)
		{
			ContentSize = Math.Max(0.0001f, size);
			if ((object)Sprite != null)
			{
				SetPadding(_basePadding);
			}
			if (IsPlaying)
			{
				CurrentPlayer.SetContentSize(size);
			}
		}

		internal void SetAppearDuration(float duration)
		{
			AppearDuration = Math.Max(0.0001f, duration);
		}

		internal void SetStayDuration(float duration)
		{
			if (duration < 0f)
			{
				StayDuration = float.MaxValue;
				IsInfinite = true;
			}
			else
			{
				StayDuration = duration;
				IsInfinite = false;
			}
		}

		internal void SetDisappearDuration(float duration)
		{
			DisappearDuration = Math.Max(0.0001f, duration);
		}

		internal void SetContentColor(Color color)
		{
			ContentColor = color;
			if (IsPlaying)
			{
				CurrentPlayer.SetContentColor(ContentColor);
			}
		}

		internal void SetBackgroundColor(Color color)
		{
			BackgroundColor = color;
			if (IsPlaying)
			{
				CurrentPlayer.SetBackgroundColor(BackgroundColor);
			}
		}

		internal void SetBackgroundSprite(Sprite sprite)
		{
			BackgroundSprite = sprite;
			if (IsPlaying)
			{
				CurrentPlayer.SetBackgroundSprite(BackgroundSprite);
			}
		}

		internal void SetEase(AnimationCurve easeCurve)
		{
			AppearEase = easeCurve;
		}

		internal void SetPadding(float padding)
		{
			_basePadding = padding;
			if ((object)Sprite != null)
			{
				Padding = _basePadding * (ContentSize * 0.05f + 2f);
			}
			else if (IsRound)
			{
				Padding = _basePadding * 2f;
			}
			else
			{
				Padding = _basePadding;
			}
		}

		internal void SetHeight(float height)
		{
			Height = height;
			if (IsPlaying)
			{
				CurrentPlayer.SetHeight(Height);
			}
		}

		internal void SetHeight(Collider collider, float offset = 0f)
		{
			SetHeight(collider.bounds, offset);
		}

		internal void SetHeight(Bounds worldBounds, float offset = 0f)
		{
			if ((bool)_parent)
			{
				float y = _parent.position.y;
				float num = worldBounds.extents.y + worldBounds.center.y - y;
				SetHeight(num + offset);
			}
		}

		internal void SetPlayer(EmotePlayer player)
		{
			CurrentPlayer = player;
			SetUseScaledTime(isScaled: false);
		}

		internal void SetDefaultVisuals(float fontSize, Color textColor, Color backgroundColor, Sprite backgroundSprite, float padding, float height)
		{
			ContentSize = fontSize;
			ContentColor = textColor;
			BackgroundColor = backgroundColor;
			BackgroundSprite = backgroundSprite;
			_basePadding = padding;
			SetPadding(_basePadding);
			Height = height;
		}

		internal void SetDefaultDurations(float appearDuration, float stayDuration, float disappearDuration, AnimationCurve ease)
		{
			SetAppearDuration(Math.Max(0.0001f, appearDuration));
			SetStayDuration(stayDuration);
			SetDisappearDuration(Math.Max(0.0001f, disappearDuration));
			AppearEase = ease;
		}
	}
}

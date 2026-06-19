using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Pug.Sprite;
using UnityEngine;

public class SpriteObjectAnimationEventEffects : MonoBehaviour
{
	public enum Direction
	{
		DOWN = 0,
		SIDE = 1,
		UP = 2
	}

	public enum FlashType
	{
		Default = 0,
		Bright = 1
	}

	[Serializable]
	public class AnimationEventEffect
	{
		public string eventName;

		public SFXTableIDField sound;

		public SFXTableIDField alternativeSound;

		public List<SpriteObjectPuffParameters> particles;

		public bool playFlash;

		[ShowIf("playFlash")]
		[AllowNesting]
		public bool customFlash;

		[ShowIf("playFlash")]
		[AllowNesting]
		public float flashDuration = 0.3f;

		[ShowIf("customFlash")]
		[AllowNesting]
		public Color flashColor;

		[ShowIf("customFlash")]
		[AllowNesting]
		public AnimationCurve flashCurve;

		[ShowIf("playFlash")]
		[AllowNesting]
		public FlashType flashType;
	}

	[Serializable]
	public struct SpriteObjectPuffParameters
	{
		public PuffID puff;

		public int particleCount;

		public Vector3 position;

		public Vector3 positionRight;

		public Vector3 positionUp;
	}

	[HideInInspector]
	public bool useAlternateSounds;

	public List<AnimationEventEffect> effects;

	private SpriteObject m_spriteObject;

	private Flashable m_flashable;

	private Dictionary<int, AnimationEventEffect> m_effectLookup;

	private void Awake()
	{
		m_spriteObject = GetComponent<SpriteObject>();
		if (m_spriteObject == null)
		{
			return;
		}
		m_spriteObject.onAnimationEvent += OnAnimationEvent;
		m_effectLookup = new Dictionary<int, AnimationEventEffect>();
		foreach (AnimationEventEffect effect in effects)
		{
			m_effectLookup.Add(SpriteAsset.StringToHash(effect.eventName), effect);
		}
		m_flashable = GetComponent<Flashable>();
		if (m_flashable == null)
		{
			m_flashable = base.gameObject.AddComponent<Flashable>();
		}
	}

	private void OnAnimationEvent(int hash)
	{
		if (!m_effectLookup.TryGetValue(hash, out var value))
		{
			return;
		}
		Direction dir = ((m_spriteObject.currentVariantHash == 1133833840) ? Direction.UP : ((m_spriteObject.currentVariantHash == 595663797) ? Direction.SIDE : Direction.DOWN));
		if (useAlternateSounds && value.alternativeSound.value != 0)
		{
			AudioManager.SfxFollowTransform(value.alternativeSound.value, base.transform);
		}
		else
		{
			AudioManager.SfxFollowTransform(value.sound.value, base.transform);
		}
		for (int i = 0; i < value.particles.Count; i++)
		{
			SpriteObjectPuffParameters puffParams = value.particles[i];
			Manager.effects.PlayPuff(new PuffParams
			{
				puff = puffParams.puff,
				particleCount = puffParams.particleCount
			}, GetPosition(dir, puffParams));
		}
		if (value.playFlash)
		{
			if (value.customFlash)
			{
				m_flashable.Flash(value.flashCurve, value.flashColor, value.flashDuration);
			}
			else if (value.flashType == FlashType.Bright)
			{
				m_flashable.Flash(Manager.effects.brightFlashCurve, Color.white, value.flashDuration);
			}
			else
			{
				m_flashable.Flash(Manager.effects.simpleFlashCurve, Color.white, value.flashDuration);
			}
		}
	}

	private Vector3 GetPosition(Direction dir, SpriteObjectPuffParameters puffParams)
	{
		Vector3 position = puffParams.position;
		switch (dir)
		{
		case Direction.SIDE:
			position = puffParams.positionRight;
			break;
		case Direction.UP:
			position = puffParams.positionUp;
			break;
		}
		return base.transform.TransformPoint(position);
	}

	private void OnDrawGizmosSelected()
	{
		foreach (AnimationEventEffect effect in effects)
		{
			foreach (SpriteObjectPuffParameters particle in effect.particles)
			{
				Gizmos.DrawSphere(base.transform.TransformPoint(particle.position), 0.05f);
				if (particle.positionRight != Vector3.zero)
				{
					Gizmos.DrawSphere(base.transform.TransformPoint(particle.positionRight), 0.05f);
				}
				if (particle.positionUp != Vector3.zero)
				{
					Gizmos.DrawSphere(base.transform.TransformPoint(particle.positionUp), 0.05f);
				}
			}
		}
	}
}

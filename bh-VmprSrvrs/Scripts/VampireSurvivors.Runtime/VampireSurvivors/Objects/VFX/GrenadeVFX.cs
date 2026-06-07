using System.Collections.Generic;
using QFSW.MOP2;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.VFX
{
	public class GrenadeVFX : PoolableMonoBehaviour
	{
		[FormerlySerializedAs("_screenFillRenderer")]
		[SerializeField]
		private SpriteRenderer _ScreenFillRenderer;

		[FormerlySerializedAs("_burstAnimation")]
		[SerializeField]
		private SpriteAnimation _BurstAnimation;

		private Timer _timer;

		private Transform _originalParent;

		private List<PhaserSprite> explosionSprites;

		private void Awake()
		{
		}

		public void SetParent(Transform newParent)
		{
		}

		public void Play(float volume = 1.8f)
		{
		}

		private void Cleanup()
		{
		}

		private void SetupScreenFill()
		{
		}

		private void SetupBurstAnim()
		{
		}

		private void ResetParent()
		{
		}
	}
}

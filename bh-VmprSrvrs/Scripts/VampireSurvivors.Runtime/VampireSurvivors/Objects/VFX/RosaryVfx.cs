using QFSW.MOP2;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.VFX
{
	public class RosaryVfx : PoolableMonoBehaviour
	{
		[FormerlySerializedAs("_screenFillRenderer")]
		[SerializeField]
		private SpriteRenderer _ScreenFillRenderer;

		[FormerlySerializedAs("_burstAnimation")]
		[SerializeField]
		private SpriteAnimation _BurstAnimation;

		private Timer _timer;

		private Transform _originalParent;

		private void Awake()
		{
		}

		public void SetParent(Transform newParent)
		{
		}

		public void Play(float volume = 1.8f, bool setDark = false)
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

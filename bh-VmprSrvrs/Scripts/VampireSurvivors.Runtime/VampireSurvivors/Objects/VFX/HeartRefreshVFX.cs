using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.VFX
{
	public class HeartRefreshVFX : PoolableMonoBehaviour
	{
		public MeshRenderer _banner;

		public ParticleSystem _flash;

		public ParticleSystem _HeartVfx;

		public float _animT;

		private MultiTargetTween _tween;

		private Timer _flashTimer;

		private void Start()
		{
		}

		public void PlaySequence()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}

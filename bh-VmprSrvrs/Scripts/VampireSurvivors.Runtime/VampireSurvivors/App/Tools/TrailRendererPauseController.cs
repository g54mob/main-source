using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.App.Tools
{
	public class TrailRendererPauseController : GameMonoBehaviour
	{
		private TrailRenderer _trail;

		private Timer _trailTimeResetTimer;

		private float _trailTime;

		private float _trailPauseTime;

		public void Init(TrailRenderer trailRenderer, float trailTime)
		{
		}

		protected override void OnPause()
		{
		}

		protected override void OnResume()
		{
		}

		public void Despawn()
		{
		}

		private void SetTrailTime()
		{
		}
	}
}

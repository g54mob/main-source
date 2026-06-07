using System.Collections.Generic;
using DG.Tweening;

namespace VampireSurvivors.Framework.PhaserTweens
{
	public class MultiTargetTween
	{
		private List<Sequence> tweens;

		private List<float> delays;

		private float _lastUpdateTime;

		private TweenCallback _onUpdate;

		private bool _isPaused;

		public void Add(Sequence tween, float delay = 0f)
		{
		}

		public void Pause()
		{
		}

		public void Play()
		{
		}

		public bool IsPaused()
		{
			return false;
		}

		public void Restart()
		{
		}

		public void Stop()
		{
		}

		public void Kill()
		{
		}

		public bool IsAlive()
		{
			return false;
		}

		public MultiTargetTween SetAutoKill(bool autoKill)
		{
			return null;
		}

		public Sequence GetFirstTween()
		{
			return null;
		}

		public Sequence GetLastTween()
		{
			return null;
		}

		public Sequence GetLongestTween()
		{
			return null;
		}

		public void SetOnUpdate(TweenCallback onUpdate)
		{
		}

		public void OnUpdate()
		{
		}
	}
}

using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace Restory.Utils
{
	public class TweenSequencesService : IDisposable
	{
		private readonly List<Sequence> sequences = new List<Sequence>();

		private readonly List<Tween> tweens = new List<Tween>();

		public string ID { get; private set; }

		public TweenSequencesService()
		{
			ID = Guid.NewGuid().ToString();
		}

		public Sequence Create()
		{
			sequences.RemoveAll((Sequence x) => !x.IsActive());
			Sequence sequence = DOTween.Sequence();
			sequences?.Add(sequence);
			return sequence;
		}

		public void Kill(Sequence sequence)
		{
			if (sequence != null)
			{
				if (sequence.IsActive())
				{
					sequence.Kill();
				}
				sequences.Remove(sequence);
			}
		}

		public void Kill(Tween tween)
		{
			if (tween.IsActive())
			{
				tween.Kill();
			}
			tweens.Remove(tween);
		}

		public void Dispose()
		{
			DisposeSequences();
			DisposeTweens();
		}

		private void DisposeSequences()
		{
			for (int i = 0; i < sequences.Count; i++)
			{
				sequences[i]?.Kill();
			}
			sequences.Clear();
		}

		private void DisposeTweens()
		{
			for (int i = 0; i < tweens.Count; i++)
			{
				tweens[i]?.Kill();
			}
			tweens.Clear();
		}

		public Tween FloatTo(DOGetter<float> getter, DOSetter<float> setter, float endValue, float duration)
		{
			tweens.RemoveAll((Tween x) => !x.IsActive());
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			tweens?.Add(tweenerCore);
			return tweenerCore;
		}
	}
}

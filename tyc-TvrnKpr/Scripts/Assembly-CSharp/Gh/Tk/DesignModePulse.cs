using System.Collections.Generic;
using DG.Tweening;
using Shapes;
using UnityEngine;

namespace Gh.Tk
{
	public class DesignModePulse : MonoBehaviour
	{
		public List<Disc> discs;

		public List<Torus> torus;

		public float duration;

		public Ease ease;

		public List<Tween> tweens;

		private List<Color> innerColors;

		private List<Color> outerColors;

		private List<Color> colors;

		private void Start()
		{
		}

		public void ResetColors()
		{
		}

		public void PlayColorTweens()
		{
		}

		private void OnDestroy()
		{
		}
	}
}

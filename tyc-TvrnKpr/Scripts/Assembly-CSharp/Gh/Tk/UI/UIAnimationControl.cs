using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;

namespace Gh.Tk.UI
{
	public class UIAnimationControl
	{
		private List<Tween> _tweens;

		private int _tweensFinished;

		public event EventHandler Finished
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public UIAnimationControl(List<Tween> tweens)
		{
		}

		private void OnTweenFinished()
		{
		}

		public void Kill()
		{
		}

		private void CleanUp()
		{
		}

		public void Pause()
		{
		}

		public void Play()
		{
		}
	}
}

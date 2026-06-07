using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public abstract class TournamentScreen : SerializedMonoBehaviour
	{
		public List<TweenPosition> Tweens;

		protected TournamentUI Manager;

		public bool IsShown { get; private set; }

		public void Init(TournamentUI manager)
		{
			Manager = manager;
			Init();
		}

		public abstract void Init();

		public void Show(bool show)
		{
			if (show)
			{
				IsShown = true;
				Tweens.ForEach(delegate(TweenPosition t)
				{
					t.PlayForward();
				});
				Show();
			}
			else
			{
				IsShown = false;
				Tweens.ForEach(delegate(TweenPosition t)
				{
					t.PlayReverse();
				});
				Hide();
			}
		}

		public virtual void Show()
		{
		}

		public virtual void Hide()
		{
		}
	}
}

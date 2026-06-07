using UnityEngine;

namespace Assets.Nimbatus.GUI.PlanetLocation.Scripts
{
	public class PlanetLocationNavigator : MonoBehaviour
	{
		public TweenPosition[] MainPageObjects;

		public static EPlanetLocationPage PageToLoad = EPlanetLocationPage.Main;

		public static EPlanetLocationPage CurrentPage;

		public static PlanetLocationNavigator Instance;

		private float _duration;

		public void Awake()
		{
			Instance = this;
		}

		public void Start()
		{
			if (PageToLoad == EPlanetLocationPage.None)
			{
				PageToLoad = EPlanetLocationPage.Main;
			}
			NavigateTowards(PageToLoad);
			PageToLoad = EPlanetLocationPage.Main;
		}

		public void NavigateTowards(EPlanetLocationPage page, float duration = 0f)
		{
			_duration = duration;
			PlayBackwards(MainPageObjects);
			if (page == EPlanetLocationPage.Main)
			{
				PlayForward(MainPageObjects);
			}
			CurrentPage = page;
		}

		private void PlayForward(TweenPosition[] positions)
		{
			if (positions == null)
			{
				return;
			}
			foreach (TweenPosition tweenPosition in positions)
			{
				if (_duration > 0f)
				{
					tweenPosition.duration = _duration;
				}
				tweenPosition.PlayForward();
			}
		}

		private void PlayBackwards(TweenPosition[] positions)
		{
			if (positions == null)
			{
				return;
			}
			foreach (TweenPosition tweenPosition in positions)
			{
				if (_duration > 0f)
				{
					tweenPosition.duration = _duration;
				}
				tweenPosition.PlayReverse();
			}
		}
	}
}

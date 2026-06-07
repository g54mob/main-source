using System.Collections;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts
{
	public class MissionControlNavigator : SerializedMonoBehaviour
	{
		public TweenPosition[] MainPageObjects;

		public TweenPosition[] LoadingObjects;

		public static EMissionControlPage PageToLoad;

		public static EMissionControlPage CurrentPage;

		public static MissionControlNavigator Instance;

		private float _duration;

		protected void Awake()
		{
			Instance = this;
		}

		public void OnDisable()
		{
			Instance = null;
		}

		public IEnumerator Start()
		{
			while (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.IsLoading || RuntimeGlobals.IsGameLoading)
			{
				yield return true;
			}
			if (PageToLoad == EMissionControlPage.Main && SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.FirstVisit)
			{
				PageToLoad = EMissionControlPage.Main;
				SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.FirstVisit = false;
			}
			NavigateTowards(PageToLoad);
			PageToLoad = EMissionControlPage.Main;
		}

		public void NavigateTowards(EMissionControlPage page, float duration = 0f)
		{
			_duration = duration;
			PlayBackwards(MainPageObjects);
			PlayBackwards(LoadingObjects);
			switch (page)
			{
			case EMissionControlPage.Main:
				PlayForward(MainPageObjects);
				break;
			case EMissionControlPage.Loading:
				PlayForward(LoadingObjects);
				break;
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

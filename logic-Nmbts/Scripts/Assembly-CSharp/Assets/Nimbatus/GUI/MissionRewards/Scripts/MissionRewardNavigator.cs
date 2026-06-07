using Sirenix.OdinInspector;

namespace Assets.Nimbatus.GUI.MissionRewards.Scripts
{
	public class MissionRewardNavigator : SerializedMonoBehaviour
	{
		public TweenPosition[] SuccessPageObjects;

		public TweenPosition[] FailurePageObjects;

		public static EMissionRewardPage PageToLoad = EMissionRewardPage.Success;

		public static EMissionRewardPage CurrentPage;

		public static MissionRewardNavigator Instance;

		private float _duration;

		protected void Awake()
		{
			Instance = this;
		}

		public void NavigateTowards(EMissionRewardPage page, float duration = 0f)
		{
			_duration = duration;
			PlayBackwards(SuccessPageObjects);
			PlayBackwards(FailurePageObjects);
			switch (page)
			{
			case EMissionRewardPage.Success:
				PlayForward(SuccessPageObjects);
				break;
			case EMissionRewardPage.Failure:
				PlayForward(FailurePageObjects);
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

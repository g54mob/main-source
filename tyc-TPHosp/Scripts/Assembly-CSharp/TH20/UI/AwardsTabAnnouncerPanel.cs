using UnityEngine;

namespace TH20.UI
{
	public class AwardsTabAnnouncerPanel : OverviewMenuTabPanel
	{
		public enum EAdvisorAnimState
		{
			None = 0,
			PoppingUp = 1,
			PoppingDown = 2,
			InitialTalking = 3,
			Talking = 4,
			Idling = 5,
			IdlingAlt = 6,
			AwardReady = 7,
			Winning = 8,
			Losing = 9
		}

		[SerializeField]
		private GameObject _advisorRoot;

		[SerializeField]
		private float _popupAnimTime = 1.1f;

		[SerializeField]
		private float _awardReadyAnimTime = 1f;

		[SerializeField]
		private float _winningAnimTime = 8f;

		[SerializeField]
		private float _losingAnimTime = 8f;

		[SerializeField]
		private float _timeBetweenAltIdlesMin = 6f;

		[SerializeField]
		private float _timeBetweenAltIdlesMax = 12f;

		[SerializeField]
		private float _maxIdleAltAnimDuration = 6f;

		[SerializeField]
		private int _numIdleAltAnims = 8;

		[SerializeField]
		private int _numIdleAnims = 5;

		[SerializeField]
		private int _numWinAnims = 4;

		[SerializeField]
		private int _numLoseAnims = 2;

		private GameObject _advisorPortraitSceneObject;

		private AdvisorPortraitScene _advisorPortraitScene;

		private float _timeSinceLastIdleUpdate;

		private float _timeInCurrentState;

		private float _currentStateDuration = -1f;

		private float _timeToNextAltIdleAnim;

		private int _currentAltIdleIndex;

		private bool _allowIdleActions;

		private EAdvisorAnimState _advisorAnimState;

		public bool AnnouncerVisible
		{
			private get
			{
				if (_advisorPortraitSceneObject != null)
				{
					return _advisorPortraitSceneObject.activeSelf;
				}
				return false;
			}
			set
			{
				if (value)
				{
					SetAdvisorAnimState(EAdvisorAnimState.PoppingUp);
				}
				else
				{
					SetAdvisorAnimState(EAdvisorAnimState.PoppingDown);
				}
			}
		}

		public void SetupAdvisor(AdvisorPortraitScene _theAdvisorPortraitScene)
		{
			_advisorPortraitScene = _theAdvisorPortraitScene;
			_advisorPortraitSceneObject = _advisorPortraitScene.gameObject;
		}

		public void ResetAdvisor()
		{
			_advisorPortraitScene.HideAdvisorModel();
			_advisorRoot.SetActive(value: false);
			SetAdvisorAnimState(EAdvisorAnimState.None);
		}

		public GameObject GetLetterBeamFocusGameObject()
		{
			return _advisorRoot;
		}

		public void SetAdvisorAllowIdleActions(bool bAllow)
		{
			_allowIdleActions = bAllow;
		}

		public void SetAdvisorAnimState(EAdvisorAnimState newState)
		{
			if (_advisorAnimState != newState)
			{
				_advisorAnimState = newState;
				_timeInCurrentState = 0f;
				_currentStateDuration = -1f;
				switch (_advisorAnimState)
				{
				case EAdvisorAnimState.PoppingUp:
					_advisorRoot.SetActive(value: true);
					_advisorPortraitScene.ShowAdvisorModel();
					_currentStateDuration = _popupAnimTime;
					_currentAltIdleIndex = Random.Range(0, _numIdleAltAnims);
					break;
				case EAdvisorAnimState.PoppingDown:
					_advisorPortraitScene.PopDownAdvisor();
					break;
				case EAdvisorAnimState.InitialTalking:
					_advisorPortraitScene.SetAnimGraphParameter("OnInitialTalk");
					break;
				case EAdvisorAnimState.Talking:
					_advisorPortraitScene.SetAnimGraphParameter("OnTalk");
					break;
				case EAdvisorAnimState.Idling:
					_advisorPortraitScene.SetAnimGraphParameter("IdleAnimIndex", Random.Range(0, _numIdleAnims));
					_advisorPortraitScene.SetAnimGraphParameter("OnIdle");
					_timeToNextAltIdleAnim = Random.Range(_timeBetweenAltIdlesMin, _timeBetweenAltIdlesMax);
					break;
				case EAdvisorAnimState.IdlingAlt:
					_currentAltIdleIndex = (_currentAltIdleIndex + 1) % _numIdleAltAnims;
					_advisorPortraitScene.SetAnimGraphParameter("IdleAltAnimIndex", _currentAltIdleIndex);
					_advisorPortraitScene.SetAnimGraphParameter("OnIdleAlt");
					_currentStateDuration = _maxIdleAltAnimDuration;
					break;
				case EAdvisorAnimState.AwardReady:
					_advisorPortraitScene.SetAnimGraphParameter((Random.Range(0f, 1f) <= 0.5f) ? "OnAwardReady" : "OnAwardReady2");
					_currentStateDuration = _awardReadyAnimTime;
					break;
				case EAdvisorAnimState.Winning:
					_advisorPortraitScene.SetAnimGraphParameter("WinAnimIndex", Random.Range(0, _numWinAnims));
					_advisorPortraitScene.SetAnimGraphParameter("OnWin");
					_currentStateDuration = _winningAnimTime;
					break;
				case EAdvisorAnimState.Losing:
					_advisorPortraitScene.SetAnimGraphParameter("LoseAnimIndex", Random.Range(0, _numLoseAnims));
					_advisorPortraitScene.SetAnimGraphParameter("OnLose");
					_currentStateDuration = _losingAnimTime;
					break;
				case EAdvisorAnimState.None:
					break;
				}
			}
		}

		protected override void Update()
		{
			_timeInCurrentState += Time.unscaledDeltaTime;
			if (_currentStateDuration >= 0f && _timeInCurrentState > _currentStateDuration)
			{
				SetAdvisorAnimState(EAdvisorAnimState.Idling);
			}
			switch (_advisorAnimState)
			{
			case EAdvisorAnimState.Idling:
				_timeSinceLastIdleUpdate += Time.unscaledDeltaTime;
				if (_timeSinceLastIdleUpdate >= 1f)
				{
					_timeSinceLastIdleUpdate = 0f;
					_advisorPortraitScene.SetAnimGraphParameter("IdleAnimIndex", Random.Range(0, _numIdleAnims));
				}
				if (_allowIdleActions)
				{
					_timeToNextAltIdleAnim -= Time.unscaledDeltaTime;
					if (_timeToNextAltIdleAnim <= 0f)
					{
						SetAdvisorAnimState(EAdvisorAnimState.IdlingAlt);
					}
				}
				break;
			case EAdvisorAnimState.PoppingUp:
			case EAdvisorAnimState.PoppingDown:
			case EAdvisorAnimState.InitialTalking:
			case EAdvisorAnimState.Talking:
			case EAdvisorAnimState.IdlingAlt:
			case EAdvisorAnimState.AwardReady:
			case EAdvisorAnimState.Winning:
			case EAdvisorAnimState.Losing:
				break;
			}
		}
	}
}

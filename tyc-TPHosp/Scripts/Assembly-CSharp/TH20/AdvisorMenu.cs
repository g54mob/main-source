using System;
using System.Collections;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[DontSave]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdvisorMenu : MenuBase, IGameEventsBase
	{
		[SerializeField]
		private CanvasGroup _advisorMessageGroup;

		[SerializeField]
		private CanvasGroup _advisorButtonGroup;

		[SerializeField]
		private DynamicButton _advisorMessageCloseButton;

		[SerializeField]
		private TMP_Text _advisorMessageText;

		[SerializeField]
		private Image _advisorMessageIcon;

		[SerializeField]
		private ScaleElementOnMouseOver _advisorMessageScaler;

		[SerializeField]
		private GameObject _advisorPortraitScenePrefab;

		[NonSerialized]
		public Action OnAdvisorMessageFinished;

		[NonSerialized]
		public bool IsAdvisorActivated = true;

		private float _timeRemaining = -1f;

		private bool _showIndefinitely;

		private bool _fadingIn;

		private bool _fadingOut;

		private float _startY = -30f;

		private float _targetY;

		private Vector3? _cameraFocus;

		private GameObject _cameraTrackObject;

		private bool _gotoCollaborativeOnClick;

		private AdvisorPortraitScene _advisorPortraitScene;

		private RuntimeAnimatorController _advisorAnimationController;

		private GameObject _advisorPortraitSceneObject;

		private MetagameMap _metagameMap;

		public bool IsShowingMessage { get; private set; }

		public AdvisorPortraitScene AdvisorPortraitScene => _advisorPortraitScene;

		protected override void Awake()
		{
			base.Awake();
			_advisorMessageGroup.alpha = 0f;
			_advisorButtonGroup.alpha = 0f;
			_targetY = _advisorMessageGroup.transform.localPosition.y;
			_startY += _targetY;
		}

		public void Setup(MetagameMap metagameMap)
		{
			GameEventsRegistry.RegisterLevelEvent(this);
			_metagameMap = metagameMap;
			if (_advisorPortraitSceneObject == null)
			{
				_advisorPortraitSceneObject = UnityEngine.Object.Instantiate(_advisorPortraitScenePrefab);
				_advisorPortraitScene = _advisorPortraitSceneObject.GetComponent<AdvisorPortraitScene>();
				_advisorPortraitScene.Setup();
				_advisorPortraitScene.transform.localPosition = new Vector3(_advisorPortraitScene.transform.localPosition.x, 2000f, _advisorPortraitScene.transform.localPosition.z);
			}
		}

		public void OnDestroy()
		{
			if (_advisorPortraitSceneObject != null)
			{
				UnityEngine.Object.Destroy(_advisorPortraitSceneObject);
			}
			StopAllCoroutines();
		}

		private void OnEnable()
		{
			if (_advisorPortraitSceneObject != null)
			{
				_advisorPortraitSceneObject.SetActive(value: true);
			}
			if (_fadingIn)
			{
				StartCoroutine(FadeIn());
			}
			else if (_fadingOut)
			{
				StartCoroutine(FadeOut());
			}
		}

		private void OnDisable()
		{
			if (_advisorPortraitSceneObject != null)
			{
				_advisorPortraitSceneObject.SetActive(value: false);
			}
		}

		public void VerifyEvents()
		{
			OnAdvisorMessageFinished.VerifyIsNull();
		}

		protected override void Update()
		{
			base.Update();
			if (_metagameMap.Level != null && (_metagameMap.Level.GameTime.IsSuperPaused || _metagameMap.Level.GameTime.IsPausedByMenu || _metagameMap.Level.HUD.IsPauseTimeMenuOpen))
			{
				return;
			}
			if (!_showIndefinitely && _timeRemaining >= 0f)
			{
				_timeRemaining -= Time.unscaledDeltaTime;
				if (_timeRemaining <= 0f)
				{
					HideAdvisorMessage();
				}
			}
			if (!IsShowingMessage || _fadingIn || _fadingOut)
			{
				return;
			}
			RectTransform component = base.gameObject.GetComponent<RectTransform>();
			if (!(component != null))
			{
				return;
			}
			Rect screenSpaceRect = component.GetScreenSpaceRect();
			Vector2 mousePos = base.HUD.InputManager.GetMousePos();
			mousePos.y = (float)Screen.height - mousePos.y;
			if (screenSpaceRect.Contains(mousePos))
			{
				if (_cameraFocus.HasValue || _cameraTrackObject != null)
				{
					_advisorMessageScaler.OnPointerEnter(null);
				}
				if (base.HUD.InputManager.GetMouseDown(MouseButton.Left))
				{
					OnClicked();
				}
			}
			else
			{
				_advisorMessageScaler.OnPointerExit(null);
			}
		}

		public void ShowAdvisorMessage(AdvisorMessageDefinition definition)
		{
			if (IsAdvisorActivated && !IsShowingMessage && !(base.HUD.FindMenu<ViewYearlyReviewMenu>() != null))
			{
				_advisorMessageGroup.alpha = 1f;
				_advisorButtonGroup.alpha = 1f;
				_advisorButtonGroup.blocksRaycasts = true;
				if (definition.LocalisedMessage.Term != null && definition.LocalisedMessage.Translation != null)
				{
					_advisorMessageText.text = definition.LocalisedMessage.Translation.Replace("\\n", "\r\n");
				}
				else
				{
					_advisorMessageText.text = definition.Message.Replace("\\n", "\r\n");
				}
				_timeRemaining = definition.Duration;
				_showIndefinitely = definition.ShowIndefinitely;
				_advisorAnimationController = definition.OverrideAnimationGraph;
				_advisorMessageCloseButton.onPrimaryDown.AddListener(HideAdvisorMessage);
				_advisorButtonGroup.gameObject.SetActive(definition.UserCanDismiss);
				_advisorMessageGroup.gameObject.SetActive(value: true);
				_advisorMessageIcon.sprite = definition.Icon;
				GameObjectUtils.SetActive(_advisorMessageIcon.gameObject, definition.Icon != null);
				_cameraFocus = definition.CameraFocus;
				_cameraTrackObject = definition.CameraTrackObject;
				_gotoCollaborativeOnClick = definition.StartCollaborativeMenuOnClick && PlatformFeatureSupport.IsFeatureSupported(definition.FeatureRequired);
				_advisorMessageGroup.blocksRaycasts = _cameraFocus.HasValue;
				if (base.gameObject.activeInHierarchy)
				{
					StartCoroutine(FadeIn());
				}
				else
				{
					_fadingIn = true;
				}
				IsShowingMessage = true;
			}
		}

		public void HideAdvisorMessage()
		{
			if (_fadingIn)
			{
				StopAllCoroutines();
			}
			_fadingIn = false;
			if (!_fadingOut && (_fadingIn || IsShowingMessage))
			{
				_advisorMessageCloseButton.onPrimaryDown.RemoveListener(HideAdvisorMessage);
				if (base.gameObject.activeInHierarchy)
				{
					StartCoroutine(FadeOut());
				}
			}
		}

		private IEnumerator FadeIn()
		{
			_fadingIn = true;
			_advisorPortraitScene.ShowAdvisorModel(_advisorAnimationController);
			for (float t = 0f; t <= 1f; t += Time.unscaledDeltaTime)
			{
				float num = EasingsUtils.CubicEaseOut(t);
				_advisorMessageGroup.alpha = num;
				_advisorButtonGroup.alpha = num;
				float y = Mathf.Lerp(_startY, _targetY, num);
				_advisorMessageGroup.transform.localPosition = new Vector3(_advisorMessageGroup.transform.localPosition.x, y, _advisorMessageGroup.transform.localPosition.z);
				yield return null;
			}
			_fadingIn = false;
		}

		private IEnumerator FadeOut()
		{
			_fadingOut = true;
			_advisorPortraitScene.PopDownAdvisor();
			_advisorButtonGroup.alpha = 0f;
			yield return new WaitForSecondsRealtime(1f);
			for (float t = 1f; t >= 0f; t -= Time.unscaledDeltaTime)
			{
				float num = EasingsUtils.CubicEaseIn(t);
				_advisorMessageGroup.alpha = num;
				float y = Mathf.Lerp(_startY, _targetY, num);
				_advisorMessageGroup.transform.localPosition = new Vector3(_advisorMessageGroup.transform.localPosition.x, y, _advisorMessageGroup.transform.localPosition.z);
				yield return null;
			}
			_advisorButtonGroup.blocksRaycasts = false;
			_advisorButtonGroup.gameObject.SetActive(value: false);
			_advisorMessageGroup.gameObject.SetActive(value: false);
			_advisorPortraitScene.HideAdvisorModel();
			if (IsShowingMessage)
			{
				IsShowingMessage = false;
				OnAdvisorMessageFinished.InvokeSafe();
			}
			_fadingOut = false;
		}

		private void OnClicked()
		{
			if (_gotoCollaborativeOnClick)
			{
				if (OnlineManager.IsInitializedAndLoggedOn() && _metagameMap?.Level != null && _metagameMap.App.GameMode is GameModeCareer)
				{
					CollaborativeResearchMenu collaborativeResearchMenu = _metagameMap.Level.HUD.FindMenu<CollaborativeResearchMenu>();
					if (collaborativeResearchMenu == null)
					{
						collaborativeResearchMenu = _metagameMap.Level.HUD.CreateMenu<CollaborativeResearchMenu>();
					}
					collaborativeResearchMenu.Initialise(_metagameMap.App);
				}
			}
			else if (_cameraTrackObject != null)
			{
				base.HUD.Level.CameraLogic.TrackObject(_cameraTrackObject.transform);
			}
			else if (_cameraFocus.HasValue)
			{
				base.HUD.Level.CameraLogic.SetFocalPoint(_cameraFocus.Value, snap: false);
			}
		}
	}
}

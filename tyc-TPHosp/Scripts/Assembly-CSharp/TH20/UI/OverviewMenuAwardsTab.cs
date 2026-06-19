using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class OverviewMenuAwardsTab : OverviewMenuTab
	{
		private enum CeremonyStates
		{
			CsNone = 0,
			CsCeremonying = 1,
			CsFinished = 2
		}

		[SerializeField]
		private AwardsTabAnnouncerPanel _theAnnouncerPanel;

		[SerializeField]
		private AwardsTabEnvelopePanel _theEnvelopePanel;

		[SerializeField]
		private AwardsTabTrophyPanel _theTrophyPanel;

		[SerializeField]
		private GameObject _theEffectsPanel;

		[SerializeField]
		private OverviewMenuSpotlightBeam[] _spotlights;

		[SerializeField]
		private LocalisedString[] _rivalHospitalNamesLoc = new LocalisedString[0];

		[SerializeField]
		private float _beamFadeTimeIn = 2f;

		[SerializeField]
		private float _beamFadeTimeOut = 2f;

		[SerializeField]
		private float _advisorStartsShowTime = 4.5f;

		[SerializeField]
		private float _beamIntensity = 0.55f;

		[SerializeField]
		private float _beamIntensityLetter = 0.75f;

		private HospitalAwardsManager _awardsManager;

		[SerializeField]
		private TMP_Text _debugAnnouncerText;

		private DynamicButton _theDynamicButton;

		[SerializeField]
		private float awardDisplayTimeoutWin = 5f;

		[SerializeField]
		private float awardDisplayTimeoutLose = 4f;

		[SerializeField]
		private float betweenAwardsRandomBeamMovementTime = 5f;

		[SerializeField]
		private float _initialAwardsRandomBeamMovementTime = 8f;

		[SerializeField]
		private float _awardReadyStartAnimTime = 1f;

		[SerializeField]
		private float _advisorBeamTargetX = 0.3f;

		[SerializeField]
		private float _advisorBeamTargetY = 0.1f;

		[SerializeField]
		private float _openLetterBeamTargetX = 0.3f;

		[SerializeField]
		private float _openLetterBeamTargetY = -0.3f;

		[SerializeField]
		private float _awardBeamScale = 1.25f;

		[SerializeField]
		private string _audioEventDrumRollLoop = "DrumRollLoop:Awards";

		[SerializeField]
		private string _audioEventDrumRollLoopOff = "DrumRollLoopOff:Awards";

		[SerializeField]
		private string _audioEventMusicLoop = "MusicLoop:Awards";

		[SerializeField]
		private string _audioEventMusicLoopOff = "MusicLoopOff:Awards";

		[SerializeField]
		private string _audioEventOpenLose = "OpenLose:Awards";

		[SerializeField]
		private string _audioEventOpenWin = "OpenWin:Awards";

		[SerializeField]
		private string _audioEventLetterAway = "LetterAway:Awards";

		private List<HospitalAwardsManager.SimpleAwardInfo> _awardInfoList = new List<HospitalAwardsManager.SimpleAwardInfo>();

		private CeremonyStates _theCeremonyState;

		private float _currCeremonyBeamIntensity;

		private float _targetCeremonyBeamIntensity;

		private float _currCeremonyBeamIntensityFadeTime;

		private bool _ceremonyBeamFadingActive;

		[DontSave]
		private AudioEmitter _awardsAudioEmitterMusic;

		[DontSave]
		private AudioEmitter _awardsAudioEmitterSamples;

		[DontSave]
		private AudioEmitter _awardsAudioEmitterSamplesEmphasis;

		private static bool _useoverideBeamFactors;

		private static float _overideBeamFactorX;

		private static float _overideBeamFactorY;

		public override void Setup(OverviewMenu theOverviewRoot, OverviewMenu.Mode theMode)
		{
			base.Setup(theOverviewRoot, theMode);
			_theAnnouncerPanel.SetupAdvisor(theOverviewRoot.TheAdvisorAwardsScene);
			_awardsManager = theOverviewRoot.TheLevel.HospitalAwardsManager;
			_spotlights = _spotlights ?? new OverviewMenuSpotlightBeam[0];
			OverviewMenuSpotlightBeam[] spotlights = _spotlights;
			for (int i = 0; i < spotlights.Length; i++)
			{
				spotlights[i].Setup();
			}
			SetEffectsPanelSize(theOverviewRoot._mainPanel);
		}

		public override void Activate(bool state)
		{
			base.Activate(state);
			if (state)
			{
				if (_theCeremonyState == CeremonyStates.CsNone)
				{
					_theAnnouncerPanel.ResetAdvisor();
					if (base.TheOverviewMenu.IsEndOfYear)
					{
						TriggerAwards(skipCeremony: false);
					}
					else
					{
						TriggerAwards(skipCeremony: true);
					}
				}
			}
			else
			{
				_theAnnouncerPanel.ResetAdvisor();
				if (_theCeremonyState != CeremonyStates.CsNone)
				{
					_awardsManager.UpdateAllAwardsWonForTooltips();
				}
			}
		}

		public void SetEffectsPanelSize(GameObject mainPanel)
		{
			if (_theEffectsPanel != null && mainPanel != null)
			{
				_theEffectsPanel.gameObject.transform.SetParent(mainPanel.gameObject.transform.parent);
				RectTransform rectTransform = _theEffectsPanel.transform as RectTransform;
				RectTransform rectTransform2 = mainPanel.transform as RectTransform;
				if (rectTransform != null && rectTransform2 != null)
				{
					Vector3 vector = default(Vector3);
					Vector2 vector2 = default(Vector2);
					vector = rectTransform2.localPosition;
					vector2 = rectTransform2.sizeDelta;
					vector2.x -= 20f;
					vector2.y -= 20f;
					rectTransform.localPosition = vector;
					rectTransform.sizeDelta = vector2;
				}
			}
		}

		public void TriggerAwards(bool skipCeremony)
		{
			_awardInfoList.Clear();
			_awardsManager.UpdateAllAwardsWonForTooltips();
			if (base.TheOverviewMenu.IsEndOfYear)
			{
				_awardsManager.OnStartAwardsCeremony();
				foreach (KeyValuePair<HospitalAwardsManager.AwardType, HospitalAwardsManager.AwardInstanceData> awardDatum in _awardsManager.AwardsConfig.AwardData)
				{
					UpdateTrophyPanelItemAwardCounts(awardDatum.Key);
				}
				_awardsManager.ProcessAwards(ref _awardInfoList);
			}
			else
			{
				foreach (KeyValuePair<HospitalAwardsManager.AwardType, HospitalAwardsManager.AwardInstanceData> awardDatum2 in _awardsManager.AwardsConfig.AwardData)
				{
					bool hasWon = _awardsManager.HasAwardBeenWon(awardDatum2.Key);
					_awardInfoList.Add(new HospitalAwardsManager.SimpleAwardInfo(awardDatum2.Key, hasWon));
				}
				SetAllTrophyPanelItemAwardCounts();
			}
			_awardsManager.CheckWinAllAwardsAchievement(_awardInfoList);
			if (skipCeremony)
			{
				foreach (HospitalAwardsManager.SimpleAwardInfo awardInfo in _awardInfoList)
				{
					if (awardInfo.Winner)
					{
						_theTrophyPanel.GetTrophy(awardInfo.AwardType).ShowAward();
					}
				}
				return;
			}
			StartCoroutine(DoCeremony());
		}

		private void SetAllTrophyPanelItemAwardCounts()
		{
			foreach (HospitalAwardsManager.SimpleAwardInfo awardInfo in _awardInfoList)
			{
				UpdateTrophyPanelItemAwardCounts(awardInfo.AwardType);
			}
		}

		private void UpdateTrophyPanelItemAwardCounts(HospitalAwardsManager.AwardType awardType)
		{
			if (_awardsManager.HasAwardBeenWon(awardType))
			{
				int awardWinCount = _awardsManager.GetAwardWinCount(awardType);
				if (awardWinCount > 0)
				{
					_theTrophyPanel.GetTrophy(awardType).SetAwardCount(awardWinCount);
				}
			}
		}

		private void Update()
		{
			ProcessBeams();
		}

		private IEnumerator DoCeremony()
		{
			base.TheOverviewMenu.TheLevel.AwardCeremonyInProgress = true;
			base.TheOverviewMenu.SetAwardsAdvisor();
			_currCeremonyBeamIntensity = 0f;
			_targetCeremonyBeamIntensity = 0f;
			SetBeamsOff();
			SetBeamIntensity(_currCeremonyBeamIntensity);
			StartAwardsMusic();
			yield return new WaitForSecondsRealtime(2.5f);
			SetBeamFocusOn(_theAnnouncerPanel.GetLetterBeamFocusGameObject());
			StartBeamsFadeIn();
			yield return new WaitForSecondsRealtime(0.5f);
			_theEnvelopePanel.SetupEnvelopeAndLetter();
			_theEnvelopePanel.RepositionForegroundEnvelope();
			_theEnvelopePanel.ResetLetterText();
			_ = _awardInfoList.Count;
			_advisorStartsShowTime = 0f;
			_theCeremonyState = CeremonyStates.CsCeremonying;
			_theAnnouncerPanel.AnnouncerVisible = true;
			_theAnnouncerPanel.SetAdvisorAllowIdleActions(bAllow: false);
			yield return new WaitForSecondsRealtime(Mathf.Max(_advisorStartsShowTime - 2.5f - 0.5f, 0f));
			_theEnvelopePanel.SetOpenAllButtonState(active: true, enabled: true);
			bool fullPresentation = true;
			_theAnnouncerPanel.SetAdvisorAnimState(AwardsTabAnnouncerPanel.EAdvisorAnimState.InitialTalking);
			yield return new WaitForSecondsRealtime(0.65f);
			SetRandomBeamMovement();
			float secondsRemaining = _initialAwardsRandomBeamMovementTime;
			bool bSkipButtonPressed = false;
			while (!bSkipButtonPressed && secondsRemaining > 0f && !_theEnvelopePanel.ReadyToOpenAll())
			{
				if (Input.GetMouseButtonDown(0))
				{
					bSkipButtonPressed = true;
					break;
				}
				secondsRemaining -= Time.unscaledDeltaTime;
				yield return null;
			}
			if (_theEnvelopePanel.ReadyToOpenAll())
			{
				fullPresentation = false;
			}
			if (fullPresentation)
			{
				_theEnvelopePanel.FadeInEnvelopes();
			}
			_theAnnouncerPanel.SetAdvisorAllowIdleActions(bAllow: true);
			int i = 0;
			int n = _awardInfoList.Count;
			while (i < n)
			{
				HospitalAwardsManager.SimpleAwardInfo award = _awardInfoList[i];
				_theEnvelopePanel.ResetLetterText();
				_theEnvelopePanel.SetPresentingPenultimateAward(i >= n - 2);
				_theAnnouncerPanel.SetAdvisorAnimState(AwardsTabAnnouncerPanel.EAdvisorAnimState.Idling);
				string awardName = HospitalAwardsManager.AwardNames[(int)award.AwardType];
				PanelItemTrophyItem trophyUpForGrabs = _theTrophyPanel.GetTrophy(award.AwardType);
				if (fullPresentation)
				{
					if (!bSkipButtonPressed)
					{
						SetRandomBeamMovement();
					}
					StartAwardsAudioDrumRoll();
					_theEnvelopePanel.EnvelopeAppearClosed();
					if (i > 0)
					{
						_theEnvelopePanel.RepositionForegroundEnvelope();
					}
					secondsRemaining = Mathf.Max(betweenAwardsRandomBeamMovementTime - _awardReadyStartAnimTime, 0f);
					while (!bSkipButtonPressed && secondsRemaining > 0f && !_theEnvelopePanel.ReadyToOpenAll() && !Input.GetMouseButtonDown(0))
					{
						secondsRemaining -= Time.unscaledDeltaTime;
						yield return null;
					}
					bSkipButtonPressed = false;
					if (!_theEnvelopePanel.ReadyToOpenAll())
					{
						_theAnnouncerPanel.SetAdvisorAnimState(AwardsTabAnnouncerPanel.EAdvisorAnimState.AwardReady);
						SetBeamFocusOn(_theEnvelopePanel.GetLetterBeamFocusGameObject());
						yield return new WaitForSecondsRealtime(_awardReadyStartAnimTime);
						StopAwardsAudioDrumRoll();
						_theEnvelopePanel.SetOpenButtonState(active: true, enabled: true);
					}
				}
				while (!_theEnvelopePanel.LetterOpened() && !_theEnvelopePanel.ReadyToOpenAll())
				{
					yield return null;
				}
				if (fullPresentation && _theEnvelopePanel.ReadyToOpenAll())
				{
					fullPresentation = false;
				}
				if (fullPresentation)
				{
					if (!_theEnvelopePanel.LetterOpened())
					{
						yield return null;
					}
					StartAwardsAudioEmphasisDrum();
					string textUpperPage;
					string textLowerPage;
					if (award.Winner)
					{
						_awardsManager.GetSuccessTextItems2(award.AwardType, awardName, out textUpperPage, out textLowerPage, out var textLowerPage2);
						_theEnvelopePanel.SetLetterText(textUpperPage, textLowerPage, textLowerPage2);
						_theAnnouncerPanel.SetAdvisorAnimState(AwardsTabAnnouncerPanel.EAdvisorAnimState.Winning);
						SetBeamFocusOn(trophyUpForGrabs.gameObject, _awardBeamScale);
						StartAwardsAudioWin();
						yield return new WaitForSecondsRealtime(1f);
						trophyUpForGrabs.AddAward();
						_awardsManager.UpdateAwardWonForTooltips(award.AwardType);
					}
					else
					{
						string rivalHospitalName = ScriptLocalization.Menu_Overview_Menu_Awards_Announcer.NotYou_CS;
						if (_rivalHospitalNamesLoc.Length != 0)
						{
							int num = 0;
							if (_rivalHospitalNamesLoc.Length > 1)
							{
								num = Random.Range(0, _rivalHospitalNamesLoc.Length) % _rivalHospitalNamesLoc.Length;
							}
							rivalHospitalName = _rivalHospitalNamesLoc[num].Translation;
						}
						_awardsManager.GetNonSuccessTextItems(award.AwardType, awardName, rivalHospitalName, out textUpperPage, out textLowerPage);
						_theEnvelopePanel.SetLetterText(textUpperPage, textLowerPage);
						_theEnvelopePanel.SetLetterText(textUpperPage, textLowerPage);
						StartAwardsAudioLose();
						_theAnnouncerPanel.SetAdvisorAnimState(AwardsTabAnnouncerPanel.EAdvisorAnimState.Losing);
					}
					secondsRemaining = (award.Winner ? awardDisplayTimeoutWin : awardDisplayTimeoutLose);
					while (!Input.GetMouseButtonDown(0) && secondsRemaining > 0f)
					{
						secondsRemaining -= Time.unscaledDeltaTime;
						yield return null;
					}
					_theEnvelopePanel.HideLetter();
					_theEnvelopePanel.EnvelopeRemove();
					StartAwardsAudioLetterAway();
					while (!_theEnvelopePanel.LetterRemoved())
					{
						yield return null;
					}
				}
				else if (award.Winner)
				{
					trophyUpForGrabs.AddAward();
					_awardsManager.UpdateAwardWonForTooltips(award.AwardType);
				}
				yield return null;
				int num2 = i + 1;
				i = num2;
			}
			_theEnvelopePanel.SetOpenAllButtonState(active: false);
			StopAwardsAudioDrumRoll(bWithSnareFinish: false);
			_theAnnouncerPanel.SetAdvisorAnimState(AwardsTabAnnouncerPanel.EAdvisorAnimState.Talking);
			SetBeamFocusOn(_theAnnouncerPanel.GetLetterBeamFocusGameObject());
			StartBeamsFadeOut();
			EndAwardsMusic();
			yield return new WaitForSecondsRealtime(0.25f);
			yield return new WaitForSecondsRealtime(2f);
			StopBeamsFade();
			SetBeamIntensity(0f);
			_theAnnouncerPanel.AnnouncerVisible = false;
			_theCeremonyState = CeremonyStates.CsFinished;
			yield return new WaitForSecondsRealtime(1.25f);
			CleanupPostCeremony(bCloseOverviewMenu: false);
			base.TheOverviewMenu.SelectAwardsMode();
		}

		public void StopAwardsCeremony()
		{
			CleanupPostCeremony(bCloseOverviewMenu: true);
		}

		private void CleanupPostCeremony(bool bCloseOverviewMenu)
		{
			SetBeamsOff();
			_theAnnouncerPanel.AnnouncerVisible = false;
			_theCeremonyState = CeremonyStates.CsFinished;
			_awardsManager.OnEndAwardsCeremony();
			EnsureAllAwardsAudioStopped();
			if (bCloseOverviewMenu)
			{
				base.TheOverviewMenu.TheLevel.HospitalHUDManager.HideOverviewMenu();
			}
			base.TheOverviewMenu.TheLevel.AwardCeremonyInProgress = false;
			base.TheOverviewMenu.SetupTabButtonsInteractivityAll(allActive: true);
		}

		private void StartBeamsFadeIn()
		{
			_ceremonyBeamFadingActive = true;
			_targetCeremonyBeamIntensity = _beamIntensity;
			_currCeremonyBeamIntensityFadeTime = _beamFadeTimeIn;
			StartCoroutine(ProcessBeamsFade());
		}

		private void StartBeamsFadeOut()
		{
			_targetCeremonyBeamIntensity = 0f;
			_currCeremonyBeamIntensityFadeTime = _beamFadeTimeOut;
		}

		private void StopBeamsFade()
		{
			_ceremonyBeamFadingActive = false;
			StopCoroutine(ProcessBeamsFade());
		}

		private IEnumerator ProcessBeamsFade()
		{
			while (_ceremonyBeamFadingActive)
			{
				if (_currCeremonyBeamIntensity != _targetCeremonyBeamIntensity)
				{
					float num = 1f / _currCeremonyBeamIntensityFadeTime * Time.unscaledDeltaTime;
					float num2 = _targetCeremonyBeamIntensity - _currCeremonyBeamIntensity;
					if (Mathf.Abs(num2) > num)
					{
						_currCeremonyBeamIntensity += ((num2 > 0f) ? num : (0f - num));
					}
					else
					{
						_currCeremonyBeamIntensity = _targetCeremonyBeamIntensity;
					}
					SetBeamIntensity(_currCeremonyBeamIntensity);
				}
				yield return null;
			}
		}

		private void SetRandomBeamMovement()
		{
			OverviewMenuSpotlightBeam[] spotlights = _spotlights;
			for (int i = 0; i < spotlights.Length; i++)
			{
				spotlights[i].SetRandomMovement();
			}
		}

		private void SetBeamFocus(Vector2 target, float scale = -1f)
		{
			OverviewMenuSpotlightBeam[] spotlights = _spotlights;
			for (int i = 0; i < spotlights.Length; i++)
			{
				spotlights[i].SetFocus(target, scale);
			}
		}

		private void SetBeamFocusOn(GameObject focusOnGameObject, float scale = -1f)
		{
			if (!(focusOnGameObject != null))
			{
				return;
			}
			CanvasScaler componentInChildren = base.transform.root.GetComponentInChildren<CanvasScaler>();
			if (!(componentInChildren != null))
			{
				return;
			}
			Canvas component = componentInChildren.gameObject.GetComponent<Canvas>();
			if (component != null)
			{
				float scaleFactor = component.scaleFactor;
				float num = (component.transform as RectTransform).rect.width * 0.5f;
				float num2 = focusOnGameObject.transform.position.x / scaleFactor;
				float x = (num - num2) / num * 0.5f;
				float num3 = (component.transform as RectTransform).rect.height * 0.5f;
				float num4 = focusOnGameObject.transform.position.y / scaleFactor;
				float y = (0f - (num3 - num4) / num3) * 0.5f;
				if (_useoverideBeamFactors)
				{
					x = _overideBeamFactorX;
					y = _overideBeamFactorY;
				}
				Vector2 target = new Vector2(x, y);
				SetBeamFocus(target, scale);
			}
		}

		private void SetSingleBeamFocus(int beamIndex, Vector2 target, float scale = -1f)
		{
			_spotlights[beamIndex].SetFocus(target, scale);
		}

		private void SetSingleBeamIntensity(int beamIndex, float inIntensity)
		{
			_spotlights[beamIndex].SetIntensity(inIntensity);
		}

		private void SetBeamIntensity(float inIntensity)
		{
			OverviewMenuSpotlightBeam[] spotlights = _spotlights;
			for (int i = 0; i < spotlights.Length; i++)
			{
				spotlights[i].SetIntensity(inIntensity);
			}
		}

		private void SetBeamsOff()
		{
			OverviewMenuSpotlightBeam[] spotlights = _spotlights;
			for (int i = 0; i < spotlights.Length; i++)
			{
				spotlights[i].SetOff();
			}
		}

		private void ProcessBeams()
		{
			OverviewMenuSpotlightBeam[] spotlights = _spotlights;
			for (int i = 0; i < spotlights.Length; i++)
			{
				spotlights[i].Process();
			}
		}

		private void StartAwardsMusic()
		{
			_awardsAudioEmitterMusic = AudioManager.Instance.Play(_audioEventMusicLoop);
			_awardsAudioEmitterMusic.AutoRolloff = false;
		}

		private void EndAwardsMusic()
		{
			AudioManager.Instance.Stop(_awardsAudioEmitterMusic);
			_awardsAudioEmitterMusic = AudioManager.Instance.Play(_audioEventMusicLoopOff);
		}

		private void StartAwardsAudioDrumRoll()
		{
			_awardsAudioEmitterSamples = AudioManager.Instance.Play(_audioEventDrumRollLoop);
		}

		private void StartAwardsAudioEmphasisDrum()
		{
			_awardsAudioEmitterSamplesEmphasis = AudioManager.Instance.Play(_audioEventDrumRollLoopOff);
		}

		private void StopAwardsAudioDrumRoll(bool bWithSnareFinish = true)
		{
			AudioManager.Instance.Stop(_awardsAudioEmitterSamples);
			if (bWithSnareFinish)
			{
				_awardsAudioEmitterSamples = AudioManager.Instance.Play(_audioEventDrumRollLoopOff);
			}
		}

		private void StartAwardsAudioWin()
		{
			_awardsAudioEmitterSamples = AudioManager.Instance.Play(_audioEventOpenWin);
		}

		private void StartAwardsAudioLose()
		{
			_awardsAudioEmitterSamples = AudioManager.Instance.Play(_audioEventOpenLose);
		}

		private void StartAwardsAudioLetterAway()
		{
			_awardsAudioEmitterSamples = AudioManager.Instance.Play(_audioEventLetterAway);
		}

		private void EnsureAllAwardsAudioStopped()
		{
			if (_awardsAudioEmitterMusic != null && !_awardsAudioEmitterMusic.Finished)
			{
				AudioManager.Instance.Stop(_awardsAudioEmitterMusic);
			}
			if (_awardsAudioEmitterSamples != null && !_awardsAudioEmitterSamples.Finished)
			{
				AudioManager.Instance.Stop(_awardsAudioEmitterSamples);
			}
			if (_awardsAudioEmitterSamplesEmphasis != null && !_awardsAudioEmitterSamplesEmphasis.Finished)
			{
				AudioManager.Instance.Stop(_awardsAudioEmitterSamplesEmphasis);
			}
		}
	}
}

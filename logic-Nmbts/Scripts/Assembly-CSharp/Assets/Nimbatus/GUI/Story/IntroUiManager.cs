using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.CampaignSettings.Scripts;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using UnityEngine;
using UnityEngine.Video;

namespace Assets.Nimbatus.GUI.Story
{
	public class IntroUiManager : MonoBehaviour
	{
		public Transform TextLabelPanel;

		public UILabel TextLabelPrefab;

		public IntroNextButton NextButton;

		public IntroSkipButton SkipButton;

		public GameObject VideoPanel;

		public VideoPlayer Video;

		public string NextSoundEffect;

		public string SlideSoundEffect;

		public float Typespeed = 100f;

		public float TypespeedFast = 500f;

		public string TextStartSoundEffect;

		public string TypeSoundEffect;

		public string FullStopSoundEffect;

		public List<IntroSetting> IntroSlides;

		private CampaignModeSettingsManager _manager;

		private bool _inTutorial;

		private bool _inEndOfTutorial;

		private int _slideIndex;

		private int _subSlideIndex;

		private int _textIndex;

		private string _targetText;

		private Coroutine _typewriter;

		private List<UILabel> _textLabels = new List<UILabel>();

		private UILabel _activeTextLabel;

		public IntroSetting CurrentSlide
		{
			get
			{
				return IntroSlides[_slideIndex];
			}
		}

		public void Init(CampaignModeSettingsManager manager)
		{
			_manager = manager;
			_inTutorial = (SaveManager.SelectedSave != null && SaveManager.SelectedSave.Settings != null && SaveManager.SelectedSave.Settings.ViewCampaignTutorial) || (SaveManager.LoadedSave != null && RuntimeGlobals.GameModeSettings != null && RuntimeGlobals.GameModeSettings.InCampaignTutorial);
			_inEndOfTutorial = RuntimeGlobals.GameModeSettings != null && RuntimeGlobals.GameModeSettings.InCampaignTutorial && SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.UniqueId == SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.EndLocationId;
			NextButton.Init(this);
			SkipButton.Init(this);
			NextButton.DisableButton();
			try
			{
				VideoPanel.SetActive(false);
				Video.Prepare();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			_slideIndex = IntroSlides.IndexOf(IntroSlides.First((IntroSetting s) => !SkipSlide(s)));
			StartCoroutine(_NextSlide());
		}

		public void Next(bool skip)
		{
			if (_slideIndex >= IntroSlides.Count)
			{
				Continue();
			}
			else if ((skip && CurrentSlide.Skippable) || SkipSlide(CurrentSlide))
			{
				_subSlideIndex = 0;
				_slideIndex++;
				StopAllCoroutines();
				ResetText();
				Next(skip);
			}
			else if (HasNextSubSlide())
			{
				NextSubSlide();
			}
			else
			{
				_slideIndex++;
				StartCoroutine(_NextSlide());
			}
		}

		private IEnumerator _NextSlide()
		{
			if (_slideIndex >= IntroSlides.Count)
			{
				Continue();
				yield break;
			}
			if (CurrentSlide.Delay > 0f)
			{
				yield return new WaitForSecondsRealtime(CurrentSlide.Delay);
			}
			AudioController.Play(SlideSoundEffect);
			NextButton.DisableButton();
			ResetText();
			_subSlideIndex = 0;
			Next(false);
		}

		public bool HasNextSubSlide()
		{
			return _subSlideIndex < CurrentSlide.SubSettings.Count;
		}

		public void NextSubSlide()
		{
			IntroSubSetting introSubSetting = CurrentSlide.Execute(_subSlideIndex);
			_textIndex = 0;
			_subSlideIndex++;
			if (introSubSetting.Type == ETypeOfIntroSetting.TextLines)
			{
				NextText();
			}
			else if (introSubSetting.Type == ETypeOfIntroSetting.Video)
			{
				StartCoroutine(StartVideo());
			}
			else if (introSubSetting.Type != ETypeOfIntroSetting.CaptainSelection)
			{
				Next(false);
			}
		}

		public void Continue()
		{
			if (!_inTutorial || (_inTutorial && !_inEndOfTutorial))
			{
				StartCoroutine(_manager.LoadGame());
				return;
			}
			SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.PreparePerk(_manager.SelectedPerk.UniqueId);
			NimbatusSceneManager.LoadScene("EndOfGalaxyScene");
		}

		public void Skip()
		{
			if (!Video.isPlaying)
			{
				Next(true);
			}
		}

		private bool SkipSlide(IntroSetting slide)
		{
			if ((_inTutorial || (slide.IntroMode != EShowIntroMode.TutorialStartOnly && slide.IntroMode != EShowIntroMode.TutorialEndOnly)) && (!_inTutorial || (slide.IntroMode != EShowIntroMode.CampaignOnly && (!_inEndOfTutorial || (slide.IntroMode != EShowIntroMode.TutorialStartOnly && slide.IntroMode != EShowIntroMode.CampaignAndTutorialStart)) && (_inEndOfTutorial || slide.IntroMode != EShowIntroMode.TutorialEndOnly))))
			{
				if (slide.IntroMode == EShowIntroMode.CampaignAndTutorialEnd && _inTutorial)
				{
					return !_inEndOfTutorial;
				}
				return false;
			}
			return true;
		}

		private void ResetText()
		{
			_textIndex = 0;
			_activeTextLabel = null;
			_textLabels.ToList().ForEach(delegate(UILabel l)
			{
				UnityEngine.Object.Destroy(l.gameObject);
			});
			_textLabels.Clear();
		}

		public void NextText(bool continuing = true)
		{
			if (CurrentSlide.TextLines != null && _textIndex < CurrentSlide.TextLines.Count)
			{
				if (continuing)
				{
					AudioController.Play(SlideSoundEffect);
					NextButton.DisableButton();
				}
				else
				{
					AudioController.Play(TextStartSoundEffect);
				}
				TextLine textLine = CurrentSlide.TextLines[_textIndex];
				if (textLine.UsePreviousLabel)
				{
					if (_activeTextLabel == null)
					{
						throw new Exception("first text line in slide can't use previous label");
					}
					for (int i = 0; i < textLine.ReturnsToAdd; i++)
					{
						_activeTextLabel.text += LabelHelper.NewLine;
					}
					_targetText = _activeTextLabel.text + textLine.Text.GetTranslation();
				}
				else
				{
					UILabel uILabel = UnityEngine.Object.Instantiate(TextLabelPrefab, TextLabelPanel);
					uILabel.transform.localPosition = new Vector3(0f, textLine.LocalYPosition, 0f);
					uILabel.text = "";
					_targetText = textLine.Text.GetTranslation();
					if (textLine.OverwriteFontSize)
					{
						uILabel.fontSize = textLine.FontSize;
					}
					if (textLine.Center)
					{
						uILabel.overflowMethod = UILabel.Overflow.ResizeFreely;
						uILabel.text = _targetText;
						float x = uILabel.CalculateBounds().size.x;
						uILabel.overflowMethod = UILabel.Overflow.ShrinkContent;
						uILabel.text = "";
						uILabel.width = Mathf.CeilToInt(x);
					}
					_activeTextLabel = uILabel;
					_textLabels.Add(uILabel);
				}
				if (_typewriter != null)
				{
					StopCoroutine(_typewriter);
				}
				_typewriter = StartCoroutine(StartTypewriter(textLine.Italic, textLine.AutoContinue));
				_textIndex++;
			}
			else
			{
				_textIndex = 0;
				NextButton.DisableButton();
				Next(false);
			}
		}

		private IEnumerator StartTypewriter(bool isItalic, bool autoContinue)
		{
			if (_activeTextLabel == null)
			{
				yield break;
			}
			bool isFast = false;
			float textTime = 0f;
			bool hasPlayedNextSfx = false;
			if (isItalic)
			{
				_targetText = "[i]" + _targetText + "[/i]";
				textTime = 3f;
			}
			int length = _activeTextLabel.text.Length;
			textTime += (float)length;
			int remainingLength = _targetText.Length - length;
			while (remainingLength > 0)
			{
				if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
				{
					isFast = true;
				}
				float num = (isFast ? TypespeedFast : Typespeed);
				textTime += Time.deltaTime * num;
				int length2 = _activeTextLabel.text.Length;
				if (isItalic)
				{
					int length3 = Mathf.FloorToInt(Mathf.Clamp(textTime, 0f, _targetText.Length - 4));
					_activeTextLabel.text = _targetText.Substring(0, length3);
					if (_activeTextLabel.text.Length >= _targetText.Length - 4)
					{
						NextButton.EnableButton();
						if (!string.IsNullOrEmpty(NextSoundEffect) && !hasPlayedNextSfx)
						{
							AudioController.Play(NextSoundEffect);
							hasPlayedNextSfx = true;
						}
					}
				}
				else
				{
					int length4 = Mathf.FloorToInt(Mathf.Clamp(textTime, 0f, _targetText.Length));
					_activeTextLabel.text = _targetText.Substring(0, length4);
					if (_activeTextLabel.text.Length >= _targetText.Length)
					{
						NextButton.EnableButton();
						if (!string.IsNullOrEmpty(NextSoundEffect) && !hasPlayedNextSfx)
						{
							AudioController.Play(NextSoundEffect);
							hasPlayedNextSfx = true;
						}
					}
				}
				remainingLength = _targetText.Length - _activeTextLabel.text.Length;
				int num2 = _activeTextLabel.text.Length - length2;
				if (num2 > 0)
				{
					string text = _activeTextLabel.text.Substring(_activeTextLabel.text.Length - num2, num2);
					if (text != "[" && text != "[" && text != " " && text != LabelHelper.NewLine)
					{
						if (text == ".")
						{
							if (!string.IsNullOrEmpty(FullStopSoundEffect))
							{
								AudioController.Play(FullStopSoundEffect);
							}
						}
						else if (!string.IsNullOrEmpty(TypeSoundEffect))
						{
							AudioController.Play(TypeSoundEffect);
						}
					}
				}
				yield return null;
			}
			if (autoContinue)
			{
				NextText();
			}
		}

		private IEnumerator StartVideo()
		{
			VideoPanel.SetActive(true);
			Video.SetDirectAudioVolume(0, RuntimeGlobals.Settings.MusicVolume);
			bool flag = false;
			try
			{
				Video.Play();
			}
			catch (Exception)
			{
				flag = true;
			}
			if (!flag)
			{
				while (!Video.isPlaying)
				{
					yield return null;
				}
				while (Video.isPlaying && !Input.GetKeyDown(KeyCode.Escape))
				{
					yield return null;
				}
				Video.Stop();
			}
			Next(false);
		}
	}
}

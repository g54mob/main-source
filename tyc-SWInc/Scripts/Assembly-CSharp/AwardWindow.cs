using System.Collections.Generic;
using Achievements;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AwardWindow : MonoBehaviour
{
	public GUIWindow Window;

	public RectTransform CompRect;

	public RectTransform FirstStar;

	public RectTransform SecondStar;

	public RectTransform ThirdStar;

	public RectTransform Reward;

	public RectTransform MainButton;

	public RectTransform RewardTexTransform;

	public RectTransform TargetTransform;

	public RectTransform[] CompRects;

	public RawImage[] Logos;

	public Text MainText;

	public Text RewardText;

	public Text MainButtonText;

	public Text TargetText;

	public Text EffectText;

	public Text YearInARowText;

	public Image RewardImage;

	public AudioClip[] CompA;

	public AudioClip EndA;

	public AudioSource DrumRoll;

	public Color DefaultColor;

	public Color[] CompColors;

	public float StarRotSpeed;

	public float WinSpeed = 1f;

	public float ColorSpeed = 0.2f;

	public float WindowFoldSpeed = 0.5f;

	public float RewardBounceSpeed = 1.5f;

	private Sequence _activeSequence;

	private List<KeyValuePair<Company, string>>[] _winners;

	private int _lastWin;

	private bool _allowSkip;

	private void Start()
	{
	}

	public bool Show(List<KeyValuePair<Company, string>>[] winners)
	{
		int num = winners.Count((List<KeyValuePair<Company, string>> x) => x.Any((KeyValuePair<Company, string> z) => z.Key == GameSettings.Instance.MyCompany));
		if (num > 0)
		{
			if (Options.IgnoreQuestions.Contains("AwardNomination"))
			{
				GiveAwards(winners);
				NotificationManager.AddNotification("AwardNotification".Loc(num), "Star", NotificationManager.NotificationType.Good);
				return false;
			}
			_winners = winners;
			WindowManager.Instance.ShowMessageBox("AwardNominationMessage".Loc(num, 4), true, DialogWindow.DialogType.Question, delegate
			{
				Window.rectTransform.localScale = Vector3.one * Mathf.Min(1f, (float)Screen.height / Options.UISize / 640f);
				ResetContent();
				Window.Show();
				DoThing(FindNextPlayerList(0));
				GameSettings.ForcePause = true;
				GameSettings.FreezeGame = true;
				Window.OnClose = delegate
				{
					GiveAwards(winners);
					GameSettings.ForcePause = false;
				};
			}, "AwardNomination", delegate
			{
				GiveAwards(winners);
			}, false);
			return true;
		}
		return false;
	}

	private int FindNextPlayerList(int from)
	{
		for (int i = from; i < _winners.Length; i++)
		{
			if (_winners[i].Any((KeyValuePair<Company, string> x) => x.Key == GameSettings.Instance.MyCompany))
			{
				return i;
			}
		}
		return -1;
	}

	private static void GiveAwards(List<KeyValuePair<Company, string>>[] winners)
	{
		for (int i = 0; i < winners.Length; i++)
		{
			List<KeyValuePair<Company, string>> list = winners[i];
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].Key == GameSettings.Instance.MyCompany)
				{
					AwardTrophy.AwardType type = (AwardTrophy.AwardType)i;
					GameSettings.Instance.AddAward(type, (AwardTrophy.AwardTier)(j + 1), SDateTime.Now().RealYear, list[j].Value);
					if (j == 0)
					{
						if (GameSettings.Instance.PlatinumProgress[i] != -1)
						{
							GameSettings.Instance.PlatinumProgress[i]++;
							if (GameSettings.Instance.PlatinumProgress[i] >= 5)
							{
								GameSettings.Instance.PlatinumProgress[i] = -1;
								GameSettings.Instance.AddAward(type, AwardTrophy.AwardTier.Platinum, SDateTime.Now().RealYear, null);
								NotificationManager.AddNotification("PlatinumNotification".Loc(type.ToString().Loc()), "Star", NotificationManager.NotificationType.Good);
								AchievementController.SetAchievement("PLATINUM");
							}
						}
					}
					else
					{
						GameSettings.Instance.PlatinumProgress[i] = 0;
					}
					break;
				}
				GameSettings.Instance.PlatinumProgress[i] = 0;
			}
		}
	}

	private void DoThing(int nom)
	{
		_allowSkip = false;
		Text mainText = MainText;
		AwardTrophy.AwardType awardType = (AwardTrophy.AwardType)nom;
		mainText.text = awardType.ToString().Loc();
		_lastWin = nom;
		List<int> list = new List<int>(new int[3] { 0, 1, 2 });
		list.Shuffle();
		int num = FindNextPlayerList(nom + 1);
		Text mainButtonText = MainButtonText;
		string text;
		if (num != -1)
		{
			awardType = (AwardTrophy.AwardType)num;
			text = awardType.ToString().Loc();
		}
		else
		{
			text = "Close".Loc();
		}
		mainButtonText.text = text;
		for (int i = 0; i < Logos.Length; i++)
		{
			Logos[i].uvRect = LogoController.Instance.GetLogoRect(_winners[nom][list[i]].Key);
		}
		int num2 = _winners[nom].FindIndex((KeyValuePair<Company, string> x) => x.Key == GameSettings.Instance.MyCompany);
		switch (num2)
		{
		case 0:
			RewardText.text = "FirstPlace".Loc();
			break;
		case 1:
			RewardText.text = "SecondPlace".Loc();
			break;
		case 2:
			RewardText.text = "ThirdPlace".Loc();
			break;
		}
		RewardImage.sprite = ObjectDatabase.Instance.GetAwardSprite((AwardTrophy.AwardType)nom, (AwardTrophy.AwardTier)(num2 + 1));
		if (num2 == 0 && GameSettings.Instance.PlatinumProgress[nom] > 0)
		{
			YearInARowText.text = "YearInARow".Loc(GameSettings.Instance.PlatinumProgress[nom] + 1);
			YearInARowText.gameObject.SetActive(true);
			YearInARowText.rectTransform.localScale = Vector3.zero;
			if (GameSettings.Instance.PlatinumProgress[nom] == 4)
			{
				RewardImage.sprite = ObjectDatabase.Instance.GetAwardSprite((AwardTrophy.AwardType)nom, AwardTrophy.AwardTier.Platinum);
			}
		}
		else
		{
			YearInARowText.gameObject.SetActive(false);
		}
		Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent(AwardTrophy.AwardFurn[nom]);
		string[] furniture = Localization.GetFurniture(furnitureComponent.GetLocalizationName(), furnitureComponent.GetDefaultName(), furnitureComponent.ButtonDescription);
		EffectText.text = ((furniture.Length > 1) ? furniture[1] : "");
		DrumRoll.volume = 0f;
		DrumRoll.Play();
		if (_activeSequence != null)
		{
			_activeSequence.Kill();
		}
		_activeSequence = DOTween.Sequence();
		_activeSequence.Insert(0f, DrumRoll.DOFade(1f, WinSpeed * 3f));
		_activeSequence.Insert(WinSpeed * 3f, DrumRoll.DOFade(0f, WinSpeed * 3f + 0.1f));
		_activeSequence.InsertCallback(WinSpeed * 3f + 0.1f, delegate
		{
			DrumRoll.Stop();
		});
		for (int num3 = 0; num3 < list.Count; num3++)
		{
			int num4 = list[num3];
			RectTransform rectTransform = CompRects[num3];
			float num5 = 1f - (float)num4 / 3f;
			float num6 = (float)(3 - num4) * WinSpeed;
			_activeSequence.Insert(0f, rectTransform.DOSizeDelta(new Vector2(rectTransform.sizeDelta.x, num5 * (CompRect.rect.height - 64f - 8f)), num6, true).SetEase(Ease.Linear));
			Image component = rectTransform.GetComponent<Image>();
			_activeSequence.Insert(num6, component.DOColor(Color.white, ColorSpeed));
			_activeSequence.Insert(num6 + ColorSpeed, component.DOColor(CompColors[num4], ColorSpeed));
			int i2 = num4;
			_activeSequence.InsertCallback(num6, delegate
			{
				UISoundFX.PlaySFX(CompA[i2]);
			});
		}
		_activeSequence.InsertCallback(WinSpeed * 3f, delegate
		{
			UISoundFX.PlaySFX(EndA);
			_allowSkip = true;
		});
		float num7 = WinSpeed * 3f - WindowFoldSpeed;
		_activeSequence.Insert(num7, Window.rectTransform.DOSizeDelta(new Vector2(Window.rectTransform.sizeDelta.x, 630f), WindowFoldSpeed, true).SetEase(Ease.OutCubic));
		float num8 = num7 + WindowFoldSpeed;
		_activeSequence.Insert(num8, FirstStar.DOScale(Vector3.one, RewardBounceSpeed).SetEase(Ease.OutElastic));
		if (num2 < 2)
		{
			_activeSequence.Insert(num8, SecondStar.DOScale(Vector3.one, RewardBounceSpeed).SetEase(Ease.OutElastic));
		}
		if (num2 < 1)
		{
			_activeSequence.Insert(num8, ThirdStar.DOScale(Vector3.one, RewardBounceSpeed).SetEase(Ease.OutElastic));
		}
		_activeSequence.Insert(num8, Reward.DOScale(Vector3.one, RewardBounceSpeed).SetEase(Ease.OutElastic));
		_activeSequence.Insert(num8, MainButton.DOScale(Vector3.one, RewardBounceSpeed).SetEase(Ease.OutElastic));
		_activeSequence.Insert(num8, RewardTexTransform.DOScale(Vector3.one, RewardBounceSpeed).SetEase(Ease.OutElastic));
		string value = _winners[nom][num2].Value;
		if (value != null)
		{
			TargetText.text = value;
			_activeSequence.Insert(num8, TargetTransform.DOScale(Vector3.one, RewardBounceSpeed).SetEase(Ease.OutElastic));
		}
		if (YearInARowText.gameObject.activeSelf)
		{
			_activeSequence.Insert(num8 + RewardBounceSpeed / 4f, YearInARowText.rectTransform.DOScale(Vector3.one, RewardBounceSpeed).SetEase(Ease.OutElastic));
		}
		_activeSequence.AppendCallback(delegate
		{
			_activeSequence = null;
		});
	}

	public void Advance()
	{
		int num = FindNextPlayerList(_lastWin + 1);
		if (num == -1)
		{
			Window.Close();
			return;
		}
		ResetContent();
		DoThing(num);
	}

	private void ResetContent()
	{
		if (_activeSequence != null)
		{
			_activeSequence.Kill();
		}
		for (int i = 0; i < CompRects.Length; i++)
		{
			SetCompBar(CompRects[i], 0f);
			CompRects[i].GetComponent<Image>().color = DefaultColor;
		}
		Window.rectTransform.sizeDelta = new Vector2(Window.rectTransform.sizeDelta.x, 326f);
		FirstStar.localScale = Vector2.zero;
		SecondStar.localScale = Vector2.zero;
		ThirdStar.localScale = Vector2.zero;
		Reward.localScale = Vector2.zero;
		TargetTransform.localScale = Vector2.zero;
		RewardTexTransform.localScale = Vector2.zero;
		MainButton.localScale = new Vector3(0f, 1f, 1f);
		Window.rectTransform.anchoredPosition = new Vector2((float)Screen.width / Options.UISize / 2f - Window.rectTransform.sizeDelta.x * Window.rectTransform.localScale.x / 2f, (float)(-Screen.height) / Options.UISize / 2f + 630f * Window.rectTransform.localScale.y / 2f);
	}

	private void SetCompBar(RectTransform bar, float p)
	{
		bar.sizeDelta = new Vector2(bar.sizeDelta.x, p * (CompRect.rect.height - 64f - 8f));
	}

	private void Update()
	{
		if (_allowSkip && (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter)))
		{
			Advance();
		}
		FirstStar.rotation = Quaternion.Euler(0f, 0f, StarRotSpeed * Time.deltaTime) * FirstStar.rotation;
		SecondStar.rotation = Quaternion.Euler(0f, 0f, (0f - StarRotSpeed) * Time.deltaTime) * SecondStar.rotation;
		ThirdStar.rotation = Quaternion.Euler(0f, 0f, StarRotSpeed * Time.deltaTime * 2f) * ThirdStar.rotation;
	}
}

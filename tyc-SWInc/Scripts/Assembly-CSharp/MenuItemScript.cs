using System;
using System.Diagnostics;
using DG.Tweening;
using DevConsole;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuItemScript : MonoBehaviour
{
	[Serializable]
	public struct TweenerRect
	{
		public RectTransform MainTransform;

		public Vector2 PosStart;

		public Vector2 PosEnd;

		public Vector2 SizeStart;

		public Vector2 SizeEnd;

		public float Time;

		public float Delay;

		public bool TweenPos;

		public bool TweenSize;

		public override string ToString()
		{
			if (!(MainTransform == null))
			{
				return MainTransform.gameObject.name;
			}
			return base.ToString();
		}
	}

	private bool disable;

	public MainMenuController mainMenu;

	public TweenerRect[] Tweens;

	public Transform Cam;

	public Transform CamTarget;

	public Image BlockImg;

	public RectTransform[] MultiOptions;

	[NonSerialized]
	private Sequence _multiTween;

	public void ShowMultiOptions(bool show)
	{
		Sequence multiTween = _multiTween;
		if (multiTween != null)
		{
			multiTween.Kill();
		}
		_multiTween = DOTween.Sequence();
		for (int i = 0; i < MultiOptions.Length; i++)
		{
			_multiTween.Insert(0f, MultiOptions[i].DOScale(show ? Vector3.one : Vector3.zero, show ? 0.5f : 0.2f).SetEase(show ? Ease.OutElastic : Ease.InQuad));
		}
		_multiTween.OnComplete(delegate
		{
			_multiTween = null;
		});
	}

	private void Start()
	{
		for (int i = 0; i < Tweens.Length; i++)
		{
			TweenerRect tweenerRect = Tweens[i];
			if (tweenerRect.TweenPos)
			{
				tweenerRect.MainTransform.anchoredPosition = tweenerRect.PosStart;
				tweenerRect.MainTransform.DOAnchorPos(tweenerRect.PosEnd, tweenerRect.Time).SetDelay(tweenerRect.Delay);
			}
			if (tweenerRect.TweenSize)
			{
				tweenerRect.MainTransform.sizeDelta = tweenerRect.SizeStart;
				tweenerRect.MainTransform.DOSizeDelta(tweenerRect.SizeEnd, tweenerRect.Time).SetDelay(tweenerRect.Delay);
			}
		}
	}

	private void DoAction(Action a)
	{
		if (SaveGameManager.SaveGames.Count > 0)
		{
			a();
			return;
		}
		for (int i = 0; i < Tweens.Length; i++)
		{
			TweenerRect tweenerRect = Tweens[i];
			if (tweenerRect.TweenPos)
			{
				tweenerRect.MainTransform.anchoredPosition = tweenerRect.PosEnd;
				tweenerRect.MainTransform.DOAnchorPos(tweenerRect.PosStart, 0.5f);
			}
			if (tweenerRect.TweenSize)
			{
				tweenerRect.MainTransform.sizeDelta = tweenerRect.SizeEnd;
				tweenerRect.MainTransform.DOSizeDelta(tweenerRect.SizeStart, 0.5f);
			}
		}
		mainMenu.HaltScreen = true;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(Cam.DOMove(CamTarget.position, 2f));
		sequence.Insert(0f, Cam.DORotate(CamTarget.rotation.eulerAngles, 2f));
		sequence.Insert(1.5f, BlockImg.DOColor(BlockImg.color.Alpha(1f), 0.5f));
		sequence.OnComplete(delegate
		{
			a();
		});
	}

	public void GoBack()
	{
		BlockImg.color = BlockImg.color.Alpha(0f);
		for (int i = 0; i < Tweens.Length; i++)
		{
			TweenerRect tweenerRect = Tweens[i];
			if (tweenerRect.TweenPos)
			{
				tweenerRect.MainTransform.anchoredPosition = tweenerRect.PosEnd;
			}
			if (tweenerRect.TweenSize)
			{
				tweenerRect.MainTransform.sizeDelta = tweenerRect.SizeEnd;
			}
		}
	}

	public void LoadSave(SaveGame save)
	{
		disable = true;
		DoAction(delegate
		{
			mainMenu.WaitPanel.SetActive(true);
			SiteNewsFeeder.AbortIfActive();
			FrameTransition.StartTransition(true);
			disable = SaveGameManager.LoadGame(save, null, default(SDateTime), false, true, true, false);
			mainMenu.WaitPanel.SetActive(disable);
			if (!disable)
			{
				GoBack();
			}
		});
	}

	public void Action(int action)
	{
		if (disable)
		{
			return;
		}
		switch (action)
		{
		case 0:
			disable = true;
			DoAction(delegate
			{
				SiteNewsFeeder.AbortIfActive();
				ErrorLogging.FirstOfScene = true;
				ErrorLogging.SceneChanging = true;
				if (GUILoading.Instance != null)
				{
					GUILoading.SetState(true);
				}
				DevConsole.Console.SaveConsole();
				SceneManager.LoadScene("Customization");
			});
			break;
		case 1:
		{
			SaveGame currentSaveGame = mainMenu.CurrentSaveGame;
			if (currentSaveGame != null)
			{
				LoadSave(currentSaveGame);
			}
			else
			{
				WindowManager.SpawnDialog().Show("MissingSaveContinue".Loc(), true, DialogWindow.DialogType.Error, null);
			}
			break;
		}
		case 2:
			SaveGameManager.Instance.Show(false, false);
			break;
		case 3:
			OptionsWindow.Instance.Show();
			break;
		case 4:
			GameSettings.IsQuitting = true;
			DevConsole.Console.SaveHistory();
			Process.GetCurrentProcess().Kill();
			break;
		case 5:
			SaveGameManager.Instance.Show(false, true, true, true);
			break;
		}
	}
}

using System.Collections;
using DG.Tweening;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Tasks_for_levels;
using UnityEngine;

namespace CodeBase.Logic
{
	public class LoadingCurtain : MonoBehaviour
	{
		public CanvasGroup StartLoadCurtain;

		public CanvasGroup FinishLoadCurtain;

		public CanvasGroup FinishLoadCurtain2;

		public CanvasGroup[] ActDrops;

		private string _sceneName;

		private int currentAct;

		private void Awake()
		{
			Object.DontDestroyOnLoad(this);
		}

		public void Show(string sceneName)
		{
			StartLoadCurtain.gameObject.SetActive(value: true);
			FinishLoadCurtain.gameObject.SetActive(value: true);
			FinishLoadCurtain2.gameObject.SetActive(value: true);
			FinishLoadCurtain.transform.DOLocalMoveX(Screen.width, 0f).SetEase(Ease.Linear);
			FinishLoadCurtain2.transform.DOLocalMoveX(-Screen.width, 0f).SetEase(Ease.Linear);
			_sceneName = sceneName;
		}

		public void Hide()
		{
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.ShowCurtain)
			{
				currentAct = 11;
				FinishLoadCurtain.gameObject.SetActive(value: false);
				FinishLoadCurtain2.gameObject.SetActive(value: false);
			}
			else
			{
				SetCurrentAct();
			}
			ActDrops[currentAct].gameObject.SetActive(value: true);
			StartLoadCurtain.gameObject.SetActive(value: false);
			FinishLoadCurtain2.transform.DOLocalMoveX(0f, 0.33f).SetEase(Ease.InOutSine);
			FinishLoadCurtain.transform.DOLocalMoveX(0f, 0.33f).SetEase(Ease.InOutSine).OnComplete(delegate
			{
				StartCoroutine(WaitForDrop());
			});
		}

		private IEnumerator WaitForDrop()
		{
			yield return new WaitForSeconds(0.1f);
			FinishLoadCurtain2.transform.DOScale(1.04f * Vector3.one, 1.66f).SetEase(Ease.InOutSine);
			FinishLoadCurtain.transform.DOScale(1.04f * Vector3.one, 1.66f).SetEase(Ease.InOutSine).OnComplete(delegate
			{
				StartCoroutine(HideActDrop());
			});
		}

		private IEnumerator HideActDrop()
		{
			Application.targetFrameRate = 60;
			AllServices.Container.Single<ITaskService>().GetCurrentTask()?.CheckTasks();
			while (FinishLoadCurtain.alpha > 0f)
			{
				FinishLoadCurtain.alpha -= 0.03f;
				FinishLoadCurtain2.alpha -= 0.03f;
				ActDrops[currentAct].alpha -= 0.03f;
				yield return new WaitForSeconds(0.03f);
			}
			ActDrops[currentAct].gameObject.SetActive(value: false);
			FinishLoadCurtain.gameObject.SetActive(value: false);
			FinishLoadCurtain2.gameObject.SetActive(value: false);
			StartLoadCurtain.gameObject.SetActive(value: false);
			FinishLoadCurtain.transform.localPosition = Vector3.zero;
			FinishLoadCurtain2.transform.localPosition = Vector3.zero;
			FinishLoadCurtain.transform.localScale = Vector3.one;
			FinishLoadCurtain2.transform.localScale = Vector3.one;
			FinishLoadCurtain.alpha = 1f;
			FinishLoadCurtain2.alpha = 1f;
			ActDrops[currentAct].alpha = 1f;
			InputManager.Instance.gamePause = false;
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.IsFirstLaunch)
			{
				ChangeLanguageOnSystemLanguage();
			}
			if (DialogueManager.Instance != null && !AllServices.Container.Single<IPersistentProgressService>().Progress.ShowCurtain && currentAct != 0)
			{
				DialogueManager.Instance.ShowStartingDialogue();
			}
		}

		private void SetCurrentAct()
		{
			currentAct = _sceneName switch
			{
				"Level_0_New" => 0, 
				"Level_1_New" => 1, 
				"Level_2_New" => 2, 
				"Level_3_New" => 3, 
				"Level_4_New" => 4, 
				"Level_5_New" => 5, 
				"Level_6_New" => 6, 
				"Level_7_New" => 7, 
				"Level_8_New" => 8, 
				"Level_9_New" => 9, 
				"Level_10_New" => 10, 
				"Level_0_CreativeMode" => 0, 
				"Level_1_CreativeMode" => 1, 
				"Level_2_CreativeMode" => 2, 
				"Level_3_CreativeMode" => 3, 
				"Level_4_CreativeMode" => 4, 
				"Level_5_CreativeMode" => 5, 
				"Level_6_CreativeMode" => 6, 
				"Level_7_CreativeMode" => 7, 
				"Level_8_CreativeMode" => 8, 
				"Level_9_CreativeMode" => 9, 
				"Level_10_CreativeMode" => 10, 
				_ => 0, 
			};
		}

		private void ChangeLanguageOnSystemLanguage()
		{
			int index = 0;
			switch (Application.systemLanguage)
			{
			case SystemLanguage.English:
				index = 0;
				break;
			case SystemLanguage.Russian:
				index = 1;
				break;
			case SystemLanguage.Japanese:
				index = 2;
				break;
			case SystemLanguage.German:
				index = 3;
				break;
			case SystemLanguage.French:
				index = 4;
				break;
			case SystemLanguage.Spanish:
				index = 5;
				break;
			case SystemLanguage.ChineseSimplified:
				index = 6;
				break;
			case SystemLanguage.ChineseTraditional:
				index = 7;
				break;
			case SystemLanguage.Korean:
				index = 8;
				break;
			case SystemLanguage.Portuguese:
				index = 9;
				break;
			case SystemLanguage.Ukrainian:
				index = 10;
				break;
			case SystemLanguage.Thai:
				index = 11;
				break;
			case SystemLanguage.Turkish:
				index = 12;
				break;
			}
			SettingsUI.Instance.ChangeLanguage(index);
		}
	}
}

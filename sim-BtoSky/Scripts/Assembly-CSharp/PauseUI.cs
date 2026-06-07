using System;
using System.Collections;
using RainbowArt.CleanFlatUI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
	[SerializeField]
	private ModalWindowContentFitterMultiButton pauseUI;

	[SerializeField]
	private GameObject settingUI;

	[SerializeField]
	private BusStopUI busStopUI;

	public static event Action OnSaveAndQuit;

	public static event Action OnStartSaveFadeOut;

	private void Start()
	{
		FirstPersonController.S.OnEscPressed += Player_OnEscPressed;
		QuestManager.S.OnCompleteDemo += S_OnCompleteDemo;
	}

	private void S_OnCompleteDemo()
	{
		DemoCompleted();
	}

	public void DemoCompleted()
	{
		FirstPersonController.S.canControl = false;
		Time.timeScale = 1f;
		AudioManager.S.demoComplete = true;
		StartCoroutine(DemoClearSaveAndQuitSequence());
	}

	public void ReturnToMainMenu()
	{
		pauseUI.HideModalWindow();
		FirstPersonController.S.canControl = false;
		Time.timeScale = 1f;
		StartCoroutine(SaveAndQuitSequence());
	}

	private IEnumerator SaveAndQuitSequence()
	{
		if (busStopUI != null)
		{
			yield return StartCoroutine(busStopUI.FadeOutSaveAndQuitRoutine());
		}
		yield return null;
		ES3AutoSaveMgr.Current.PauseSave();
		PauseUI.OnSaveAndQuit?.Invoke();
		yield return null;
		SceneManager.LoadScene(0);
	}

	private IEnumerator DemoClearSaveAndQuitSequence()
	{
		if (busStopUI != null)
		{
			yield return StartCoroutine(busStopUI.FadeOutSaveAndQuitRoutineDemoClear());
		}
		yield return null;
		ES3AutoSaveMgr.Current.PauseSave();
		PauseUI.OnSaveAndQuit?.Invoke();
		yield return null;
		SceneManager.LoadScene(0);
	}

	private IEnumerator WaitOneFrame()
	{
		yield return null;
		SceneManager.LoadScene(0);
	}

	private void Player_OnEscPressed()
	{
		Debug.Log("ESC");
		if (FirstPersonController.S.canControl)
		{
			if (!pauseUI.gameObject.activeSelf)
			{
				FirstPersonController.S.canControl = false;
				Cursor.visible = true;
				Time.timeScale = 0f;
				pauseUI.ShowModalWindow();
			}
		}
		else
		{
			if (!pauseUI.gameObject.activeSelf)
			{
				return;
			}
			if (!settingUI.gameObject.activeSelf)
			{
				if (!FirstPersonController.S.rcControl)
				{
					FirstPersonController.S.canControl = true;
				}
				Cursor.visible = false;
				Time.timeScale = 1f;
				pauseUI.HideModalWindow();
			}
			else
			{
				settingUI.GetComponent<SettingUI>().CloseSettingUI();
			}
		}
	}

	private void OnDestroy()
	{
		FirstPersonController.S.OnEscPressed -= Player_OnEscPressed;
		QuestManager.S.OnCompleteDemo -= S_OnCompleteDemo;
	}

	public void Resume()
	{
		if (pauseUI.gameObject.activeSelf)
		{
			if (!FirstPersonController.S.rcControl)
			{
				FirstPersonController.S.canControl = true;
			}
			Cursor.visible = false;
			Time.timeScale = 1f;
			pauseUI.HideModalWindow();
		}
	}
}

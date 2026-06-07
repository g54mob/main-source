using System;
using System.Collections;
using DevConsole;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMainMenu : MonoBehaviour
{
	[NonSerialized]
	private int _state;

	private bool waitForInput;

	public UIRotationScript rotScript;

	public GameObject RingScript;

	public GameObject WorkshopController;

	private IEnumerator Start()
	{
		yield return new WaitForEndOfFrame();
		IEnumerator mainData = GameData.Initialize();
		int last = -1;
		float tt = Time.realtimeSinceStartup;
		while (mainData.MoveNext())
		{
			if (last >= 0)
			{
				LoadDebugger.AddToLine(last, ": " + (Time.realtimeSinceStartup - tt).SecondsToTime());
			}
			string text = mainData.Current as string;
			if (text != null)
			{
				tt = Time.realtimeSinceStartup;
				last = LoadDebugger.AddInfo(text);
				yield return new WaitForEndOfFrame();
			}
		}
		if (last >= 0)
		{
			LoadDebugger.AddToLine(last, ": " + (Time.realtimeSinceStartup - tt).SecondsToTime());
		}
		tt = Time.realtimeSinceStartup;
		try
		{
			SaveGameManager.InitializeSaves();
		}
		catch (Exception exception)
		{
			LoadDebugger.AddError("An error occured while initializing saves");
			Debug.LogException(exception);
		}
		LoadDebugger.AddInfo("Finished loading save games: " + (Time.realtimeSinceStartup - tt).SecondsToTime());
		yield return new WaitForEndOfFrame();
		0f.Currency().Loc();
		ModController.Initialize(false);
		yield return new WaitForEndOfFrame();
		tt = Time.realtimeSinceStartup;
		LoadDebugger.AddInfo("Loading modded furniture");
		WorkshopController.SetActive(true);
		IEnumerator res = FurnitureLoader.InitSteps();
		int furns = ObjectDatabase.Instance.GetAllFurniture().Count;
		while (res.MoveNext())
		{
			LoadDebugger.SetLastLine("Loading modded furniture: " + res.Current.ToString() + " (" + (ObjectDatabase.Instance.GetAllFurniture().Count - furns) + ")");
			yield return new WaitForEndOfFrame();
		}
		LoadDebugger.SetLastLine("Loaded " + (ObjectDatabase.Instance.GetAllFurniture().Count - furns) + " modded furniture: " + (Time.realtimeSinceStartup - tt).SecondsToTime());
		while (!SteamWorkshop.HasFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		RoomMaterialController.Instance.Init();
		_state = 1;
		rotScript.Stop();
		RingScript.SetActive(true);
	}

	private void Update()
	{
		if (_state == 1)
		{
			if (!LoadDebugger.Instance.Errors)
			{
				FrameTransition.StartTransition(true);
				DevConsole.Console.SaveConsole();
				SceneManager.LoadSceneAsync("MainMenu");
			}
			else
			{
				waitForInput = true;
				LoadDebugger.AddInfo("<size=32>Press any key to continue...</size>", "#00FF00");
			}
			_state = 2;
		}
		if (waitForInput && (Input.anyKey || Input.GetMouseButton(0) || Input.GetMouseButton(1)))
		{
			FrameTransition.StartTransition(true);
			DevConsole.Console.SaveConsole();
			SceneManager.LoadSceneAsync("MainMenu");
			waitForInput = false;
		}
	}
}

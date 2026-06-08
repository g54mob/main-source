using System;
using UnityEngine;

public class SceneLevelInput : MonoBehaviour
{
	public static SceneLevelInput Instance;

	public static char AdditionalSupportedChar = '$';

	public static bool DisableCtrlOnAlias;

	public static bool DisableEnemyAnimation;

	private bool enableAutoHide = true;

	private Vector3 lastKnownMousePos = Vector3.zero;

	private float timerSinceLastMouseMove;

	private void Awake()
	{
		Instance = this;
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs != null && commandLineArgs.Length > 0)
		{
			int num = commandLineArgs.Length;
			string text = string.Empty;
			for (int i = 0; i < num; i++)
			{
				text += commandLineArgs[i].ToString();
				text += "\n";
				if (commandLineArgs[i].ToLower() == "-alias-additional" && commandLineArgs.Length > i + 1)
				{
					i++;
					AdditionalSupportedChar = commandLineArgs[i][0];
				}
				else if (commandLineArgs[i].ToLower() == "-alias-disablectrl")
				{
					DisableCtrlOnAlias = true;
				}
				else if (commandLineArgs[i].ToLower() == "-enemy-animation-disable")
				{
					DisableEnemyAnimation = true;
				}
			}
		}
		RefreshAutoHideState();
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	private void Start()
	{
		lastKnownMousePos = Input.mousePosition;
	}

	private void Update()
	{
		if (!enableAutoHide)
		{
			return;
		}
		if (!Cursor.visible && Input.mousePosition != lastKnownMousePos)
		{
			lastKnownMousePos = Input.mousePosition;
			timerSinceLastMouseMove = 0f;
			if (!Cursor.visible)
			{
				Cursor.visible = true;
			}
		}
		else if (Cursor.visible)
		{
			timerSinceLastMouseMove += Time.deltaTime;
			if (timerSinceLastMouseMove >= 2f)
			{
				Cursor.visible = false;
			}
		}
	}

	public void RefreshAutoHideState()
	{
		enableAutoHide = GameSaveFile.Get("O_AHM", true);
		if (!enableAutoHide)
		{
			Cursor.visible = true;
			return;
		}
		lastKnownMousePos = Input.mousePosition;
		timerSinceLastMouseMove = 0f;
	}
}

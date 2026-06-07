using System;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleScriptRow : MonoBehaviour
{
	[NonSerialized]
	public RPLRunnerPane runnerPane;

	public GameObject editButton;

	public GameObject compileButton;

	public GameObject runButton;

	public GameObject runOnceButton;

	public GameObject stopButton;

	public Text counterText;

	public Text lastExecutionCountText;

	public Color color;

	public Color overColor;

	public Color selectedColor;

	public Text nameText;

	public Image background;

	private CModRplCore core;

	private int updateCount;

	private bool outputLogDirty;

	private FixedSizedQueue<string> queue;

	private string _fullFilePath;

	private bool _isRunning;

	private bool _selected;

	public string fullFilePath
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool isRunning
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void LateUpdate()
	{
	}

	public void GameUpdate()
	{
	}

	public void OnDelete()
	{
	}

	public void OnMoveUp()
	{
	}

	public void OnMoveDown()
	{
	}

	public void OnPointerOver()
	{
	}

	public void OnPointerOut()
	{
	}

	public void OnPointerDown()
	{
	}

	public void OnSelect()
	{
	}

	public void OnEdit()
	{
	}

	public void OnCompile()
	{
	}

	public void OnRun()
	{
	}

	public void OnRunOnce()
	{
	}

	public void OnStop()
	{
	}

	public void DestroyRow()
	{
	}

	private void DebugTextClearCallback(RplCore core)
	{
	}

	public void ClearLog()
	{
	}

	private void DebugTextCallback(RplCore core, string val)
	{
	}

	public void LogMessage(RplCore core, string message)
	{
	}

	public string GetTraceLog()
	{
		return null;
	}

	public void ClearTraceLog()
	{
	}
}

using UnityEngine;
using UnityEngine.UI;

public class BasicTutorials : ActiveComponent
{
	[SceneBind("StartDragWindow")]
	public Image StartDragWindow;

	[SceneBind("StartDragLine")]
	public Image StartDragLine;

	[SceneBind("TestWindow")]
	public Image TestWindow;

	[SceneBind("ConnectOtherLines")]
	private Image ConnectOtherLines;

	private Construction constr;

	private bool wasTestShow;

	public bool IsActive()
	{
		if (!StartDragWindow.gameObject.activeSelf && !ConnectOtherLines.gameObject.activeSelf && !StartDragLine.gameObject.activeSelf)
		{
			return TestWindow.gameObject.activeSelf;
		}
		return true;
	}

	private bool FastBreak()
	{
		if (constr.testMode)
		{
			return true;
		}
		if (ActiveComponent.Model.P.passedFirstQuest == 1)
		{
			return true;
		}
		if (ActiveComponent.Model.P.basicsTutorial == 1)
		{
			return true;
		}
		if (ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial))
		{
			return true;
		}
		return false;
	}

	private void ResetZoom()
	{
		Vector3 one = Vector3.one;
		one = Vector3.one * ActiveComponent._staticData.Settings.DefaultMobileZoom;
		ActiveComponent.Model.construction.InitAlgoBlock(ActiveComponent.Model.construction.constrBlock.transform.position, one, Vector2.one * 0.5f);
	}

	private void StartDragClick()
	{
		if (!FastBreak())
		{
			ConnectOtherLines.gameObject.SetActive(value: false);
		}
	}

	private void EndDragClick()
	{
		if (!FastBreak())
		{
			StartDragWindow.gameObject.SetActive(value: false);
			if (constr.blocksInScheme.Count == 0)
			{
				StartDragWindow.gameObject.SetActive(value: true);
				ResetZoom();
				StartDragLine.gameObject.SetActive(value: false);
				ConnectOtherLines.gameObject.SetActive(value: false);
			}
			else
			{
				StartDragLine.gameObject.SetActive(value: true);
				ConnectOtherLines.gameObject.SetActive(value: false);
				EndDrawLine();
			}
		}
	}

	private void BlockDeleted()
	{
		if (!FastBreak())
		{
			if (constr.blocksInScheme.Count == 0)
			{
				StartDragWindow.gameObject.SetActive(value: true);
				ResetZoom();
				StartDragLine.gameObject.SetActive(value: false);
				TestWindow.gameObject.SetActive(value: false);
				ConnectOtherLines.gameObject.SetActive(value: false);
			}
			else if (constr.blocksInScheme.Count == 1)
			{
				EndDrawLine();
			}
		}
	}

	private void StartDrawLine()
	{
		if (!FastBreak())
		{
			ConnectOtherLines.gameObject.SetActive(value: false);
			StartDragLine.gameObject.SetActive(value: false);
			TestWindow.gameObject.SetActive(value: false);
			ConnectOtherLines.gameObject.SetActive(value: false);
		}
	}

	private void EndDrawLine()
	{
		if (FastBreak())
		{
			return;
		}
		Chain[] componentsInChildren = constr.constrBlock.GetComponentsInChildren<Chain>();
		int num = 0;
		Chain[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			if (!array[i].IsDummy())
			{
				num++;
			}
		}
		StartDragLine.gameObject.SetActive(num == 0 && constr.blocksInScheme.Count > 0);
		if (!wasTestShow)
		{
			if (constr.blocksInScheme.Count > 1)
			{
				TestWindow.gameObject.SetActive(value: false);
				ConnectOtherLines.gameObject.SetActive(value: false);
			}
			else if (num > 0)
			{
				StartDragLine.gameObject.SetActive(value: false);
				TestWindow.gameObject.SetActive(!constr.HasFreeOutSockets() && constr.blocksInScheme.Count == 1);
			}
			if (!constr.HasFreeOutSockets() && constr.blocksInScheme.Count == 1)
			{
				wasTestShow = true;
				StartDragWindow.gameObject.SetActive(value: false);
			}
		}
	}

	private void TestClick()
	{
		StartDragWindow.gameObject.SetActive(value: false);
		TestWindow.gameObject.SetActive(value: false);
		ConnectOtherLines.gameObject.SetActive(value: false);
	}

	private void TestSuccess()
	{
		if (ActiveComponent.Model.P.basicsTutorial != 1 && !ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial) && constr.blocksInScheme.Count <= 1)
		{
			wasTestShow = true;
			ConnectOtherLines.gameObject.SetActive(value: false);
			ReleaseSucess();
		}
	}

	private void StopClick()
	{
		if (ActiveComponent.Model.P.basicsTutorial == 1 || ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial) || constr.blocksInScheme.Count > 1)
		{
			return;
		}
		if (ActiveComponent.Model.P.passedFirstQuest == 0)
		{
			if (!wasTestShow)
			{
				wasTestShow = true;
				TestWindow.gameObject.SetActive(value: true);
				ConnectOtherLines.gameObject.SetActive(value: false);
			}
		}
		else
		{
			ConnectOtherLines.gameObject.SetActive(value: false);
		}
	}

	private void ReleaseClick()
	{
		ConnectOtherLines.gameObject.SetActive(value: false);
	}

	private void ReleaseSucess()
	{
		ActiveComponent.Model.P.basicsTutorial = 1;
		TestWindow.gameObject.SetActive(value: false);
		Logic.UpdateGameSaves();
	}

	public void Hide()
	{
		StartDragWindow.gameObject.SetActive(value: false);
		StartDragLine.gameObject.SetActive(value: false);
		TestWindow.gameObject.SetActive(value: false);
		ConnectOtherLines.gameObject.SetActive(value: false);
	}

	public void StartTutorial()
	{
		StartDragWindow.gameObject.SetActive(constr.blocksInScheme.Count == 0);
		if (constr.blocksInScheme.Count == 0)
		{
			ResetZoom();
		}
		StartDragLine.gameObject.SetActive(value: false);
	}

	public void OnInit(Construction construction)
	{
		base.Init();
		constr = construction;
		SceneBindContainer.BindObjects(this, base.transform);
		construction.startDragEvent.AddListener(StartDragClick);
		construction.endDragEvent.AddListener(EndDragClick);
		construction.startDrawLineEvent.AddListener(StartDrawLine);
		construction.endDrawLineEvent.AddListener(EndDrawLine);
		StartDragWindow.gameObject.SetActive(value: false);
		StartDragLine.gameObject.SetActive(value: false);
		TestWindow.gameObject.SetActive(value: false);
		constr.deleteEvent.AddListener(BlockDeleted);
		constr.stopEvent.AddListener(StopClick);
		constr.testEvent.AddListener(TestClick);
		constr.releaseSucessEvent.AddListener(ReleaseSucess);
		constr.releaseEvent.AddListener(ReleaseClick);
		constr.testSuccessEvent.AddListener(TestSuccess);
		ConnectOtherLines.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (base.IsInited && !(TestWindow == null) && TestWindow.gameObject.activeSelf && ActiveComponent.Program.joyInput.xUp)
		{
			ActiveComponent.Model.construction.TestButton.onClick.Invoke();
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TablePanel : Panel
{
	[SerializeField]
	private ContentSizeFitter csf;

	private PanelManager managedTables;

	private ScrollRect scrollRect;

	private Transform rowContainer;

	private int currentRowsOpen = 1;

	private bool isAdding;

	private bool lockDataVisibility;

	private bool isPlayingMinimize;

	private float scrollPos;

	protected override void Awake()
	{
		base.Awake();
		managedTables = UIUtils.FindCanvasFromChild(base.transform).GetComponent<PanelManager>();
		scrollRect = GetComponentInChildren<ScrollRect>();
		scrollRect.verticalNormalizedPosition = 1f;
	}

	private void OnDisable()
	{
		csf.enabled = true;
		SetRows(isActive: false);
		currentRowsOpen = 1;
	}

	public override void OpenPanel()
	{
		if (!isOpen || (isMinimizing && !IsPanelMaximizing()))
		{
			if (isOpen)
			{
				StartCoroutine(LockScrollRectDelay(0.3f, scrollPos));
			}
			else
			{
				StartCoroutine(LockScrollRectDelay(0.3f, 1f));
			}
			StartCoroutine(OnPanelOpen(0f));
			lockDataVisibility = true;
			base.OpenPanel();
			StartCoroutine(FinishedAnimation(0.3f));
		}
	}

	public override void OnMinimizePanel()
	{
		if (!isPlayingMinimize)
		{
			scrollPos = scrollRect.verticalNormalizedPosition;
		}
		isPlayingMinimize = true;
		StartCoroutine(LockScrollRectDelay(0.4f, scrollPos));
		StartCoroutine(FinishedMinimizing(0.1f));
	}

	public override void OnMaximizePanel()
	{
		isPlayingMinimize = true;
		StartCoroutine(LockScrollRectDelay(0.4f, scrollPos));
		StartCoroutine(FinishedMinimizing(0.1f));
	}

	protected virtual IEnumerator LockScrollRectDelay(float waitTime, float position)
	{
		float timer = 0f;
		while (timer < waitTime)
		{
			scrollRect.verticalNormalizedPosition = position;
			timer += Time.deltaTime;
			yield return null;
		}
		SetDataVisibilityUnlocked();
	}

	protected virtual IEnumerator FinishedMinimizing(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		isPlayingMinimize = false;
	}

	protected virtual IEnumerator OnPanelOpen(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		SetDataVisibilityInit();
		Debug.Log($"Open time: {DateTime.Now - Icon.timeClicked}");
	}

	protected virtual IEnumerator FinishedAnimation(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		lockDataVisibility = false;
	}

	protected override IEnumerator OnPanelClose(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		string toolbarName = GetToolbarName();
		if (!managedTables.Contains(toolbarName) && !isOpen)
		{
			DatabaseUtils.DropTable(toolbarName);
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else if (!isOpen)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void SetDataVisibility()
	{
		if (!lockDataVisibility && !isPlayingMinimize)
		{
			SetDataVisibilityUnlocked();
		}
	}

	public void SetDataVisibilityUnlocked()
	{
		Transform rowContainers = GetRowContainers();
		if (rowContainers.childCount == 1)
		{
			SetDataVisibilityInit();
		}
		else if (IsEffectivelyZero(scrollRect.verticalNormalizedPosition) && !isAdding && rowContainers.childCount > currentRowsOpen)
		{
			StartCoroutine(AddRow(rowContainers));
		}
		else if (currentRowsOpen >= rowContainers.childCount)
		{
			StartCoroutine(SetDataVisibilityDelay());
		}
	}

	private IEnumerator AddRow(Transform rowContainers)
	{
		if (currentRowsOpen < rowContainers.childCount)
		{
			isAdding = true;
			GameObject gameObject = rowContainers.GetChild(currentRowsOpen).gameObject;
			gameObject.SetActive(value: true);
			TableWindow tableWindow = gameObject.GetComponent<TableWindow>();
			tableWindow.SetInvisible();
			currentRowsOpen++;
			yield return new WaitForSeconds(0.1f);
			csf.enabled = false;
			csf.enabled = true;
			tableWindow.SetVisible();
			isAdding = false;
		}
	}

	public static bool IsEffectivelyZero(float value, float tolerance = 0.0001f)
	{
		return Math.Abs(value) < tolerance;
	}

	private IEnumerator SetDataVisibilityDelay()
	{
		if (isAdding)
		{
			yield break;
		}
		csf.enabled = false;
		yield return new WaitForSeconds(0.1f);
		Transform transform = base.transform.Find("Data Scroll View/Viewport/Row Container");
		TableWindow[] componentsInChildren = transform.GetComponentsInChildren<TableWindow>();
		float height = base.transform.Find("Data Scroll View").GetComponent<RectTransform>().rect.height;
		float y = transform.localPosition.y;
		int num = 0;
		List<TableWindow> visibleWindows = new List<TableWindow>();
		TableWindow[] array = componentsInChildren;
		foreach (TableWindow tableWindow in array)
		{
			if (tableWindow.SetVisibility(num++, 0f - y, 0f - (y + height)))
			{
				visibleWindows.Add(tableWindow);
			}
		}
		yield return new WaitForSeconds(0.05f * (float)visibleWindows.Count);
		foreach (TableWindow item in visibleWindows)
		{
			item.SetPosition();
		}
	}

	private void SetDataVisibilityInit()
	{
		Transform rowContainers = GetRowContainers();
		if (rowContainers.childCount > 0)
		{
			rowContainers.GetChild(0).gameObject.SetActive(value: true);
		}
	}

	private void SetRows(bool isActive)
	{
		foreach (Transform item in base.transform.Find("Data Scroll View/Viewport/Row Container"))
		{
			item.GetComponent<TableWindow>().EnableText();
			item.gameObject.SetActive(isActive);
		}
	}

	private Transform GetRowContainers()
	{
		if (rowContainer == null)
		{
			rowContainer = base.transform.Find("Data Scroll View/Viewport/Row Container");
		}
		return rowContainer;
	}
}

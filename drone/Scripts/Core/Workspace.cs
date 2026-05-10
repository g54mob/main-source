using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Workspace : MonoBehaviour
{
	public RectTransform container;

	public RectTransform zoomContainer;

	public Canvas editorCanvas;

	public CodeCompleter codeCompleter;

	public Camera uiCam;

	public CameraController cameraController;

	public SearchBox searchBox;

	public Tooltip tooltip;

	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private float zoomSpeed;

	[SerializeField]
	private float maxCanvasScaleFactor;

	[SerializeField]
	private float minCanvasScaleFactor;

	public bool slowMode;

	[SerializeField]
	private Vector2 spawnWindowOffset;

	[SerializeField]
	private Vector2 spawnDocsWindowOffset;

	[SerializeField]
	private CodeWindow codeWinPrefab;

	[SerializeField]
	private DocsWindow docWinPrefab;

	[SerializeField]
	private Texture2D textCursor;

	[SerializeField]
	private Texture2D horizontalResizeCursor;

	[SerializeField]
	private Texture2D verticalResizeCursor;

	[SerializeField]
	private Texture2D bidirectionalResizeCursor;

	public Window activeWindow;

	public UndoHistory undoHistory = new UndoHistory();

	public Dictionary<string, Window> openWindows = new Dictionary<string, Window>();

	public volatile ConcurrentDictionary<string, CodeWindow> codeWindows = new ConcurrentDictionary<string, CodeWindow>();

	private int docId;

	private bool containerDirty;

	private Window transitionTarget;

	private int transitionTargetCharIndex;

	private CodeInputField transitionTargetInputField;

	private float transitionStartTime;

	private float transitionEndTime;

	private Vector2 transitionStartPosition;

	public void Scroll(float scroll)
	{
		IOrderedEnumerable<Window> source = from w in openWindows.Values
			where RectTransformUtility.RectangleContainsScreenPoint(w.GetComponent<RectTransform>(), Input.mousePosition, uiCam)
			orderby w.HighestDockedParent.transform.GetSiblingIndex() descending
			select w;
		CodeWindow component2;
		if (source.Any() && source.First().TryGetComponent<DocsWindow>(out var component))
		{
			component.Scroll(scroll);
		}
		else if (source.Any() && source.First().TryGetComponent<CodeWindow>(out component2))
		{
			component2.Scroll(scroll);
		}
		else
		{
			Zoom(scroll);
		}
	}

	public void Zoom(float zoom)
	{
		if (zoom > 0f)
		{
			cameraController.zoom = Mathf.Clamp(cameraController.zoom * zoomSpeed, minCanvasScaleFactor, maxCanvasScaleFactor);
			zoomContainer.localScale = Vector3.one * cameraController.zoom;
			container.GetComponent<ContainerScaler>().UpdateMarginSize();
		}
		else if (zoom < 0f)
		{
			cameraController.zoom = Mathf.Clamp(cameraController.zoom / zoomSpeed, minCanvasScaleFactor, maxCanvasScaleFactor);
			zoomContainer.localScale = Vector3.one * cameraController.zoom;
			container.GetComponent<ContainerScaler>().UpdateMarginSize();
		}
	}

	private void Update()
	{
		if (containerDirty)
		{
			UpdateContainerSizeInternal();
		}
		LerpCameraToTarget();
		IOrderedEnumerable<Window> source = from w in openWindows.Values
			where RectTransformUtility.RectangleContainsScreenPoint(w.GetComponent<RectTransform>(), Input.mousePosition, uiCam)
			orderby w.transform.GetSiblingIndex() descending
			select w;
		if (source.Any() && source.First().TryGetComponent<Window>(out var component))
		{
			component.IsPointerOnResizeArea(Input.mousePosition, out var horizontal, out var vertical);
			float x = textCursor.width / 2;
			float y = textCursor.height / 2;
			CodeWindow component2;
			if (horizontal && vertical)
			{
				Cursor.SetCursor(bidirectionalResizeCursor, new Vector2(x, y), CursorMode.Auto);
			}
			else if (horizontal)
			{
				Cursor.SetCursor(horizontalResizeCursor, new Vector2(x, y), CursorMode.Auto);
			}
			else if (vertical)
			{
				Cursor.SetCursor(verticalResizeCursor, new Vector2(x, y), CursorMode.Auto);
			}
			else if (source.First().TryGetComponent<CodeWindow>(out component2) && component2.IsPointerOverCodeInput())
			{
				Cursor.SetCursor(textCursor, new Vector2(x, y), CursorMode.Auto);
			}
			else
			{
				Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			}
		}
		else
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}
	}

	private void Start()
	{
		SetViewportOptions("viewport sliding");
		OptionHolder.OnOptionChanged += SetViewportOptions;
	}

	private void SetViewportOptions(string option)
	{
		if (option == "viewport sliding")
		{
			scrollRect.inertia = OptionHolder.GetString("viewport sliding") == "enabled";
		}
	}

	public void UpdateContainerSize()
	{
		containerDirty = true;
	}

	private void UpdateContainerSizeInternal()
	{
		container.GetComponent<ContainerScaler>().UpdateSize();
		containerDirty = false;
	}

	public void OpenCodeWindow(string fileName, string code, Vector2 offset, Vector2 size = default(Vector2))
	{
		if (!openWindows.ContainsKey(fileName))
		{
			CodeWindow codeWindow = Object.Instantiate(codeWinPrefab, container);
			codeWindow.workspace = this;
			Window component = codeWindow.GetComponent<Window>();
			RegisterWindow(component, fileName, offset, size);
			codeWindow.fileName = fileName;
			if (!string.IsNullOrEmpty(code))
			{
				codeWindow.Load(code);
			}
			else
			{
				codeWindow.Load("");
			}
			codeWindow.Parse();
		}
	}

	public void OpenDocsWindow(string windowName, string docsPage, Vector2 offset, Vector2 size = default(Vector2))
	{
		DocsWindow docsWindow = Object.Instantiate(docWinPrefab, container);
		Window component = docsWindow.GetComponent<Window>();
		docId++;
		RegisterWindow(component, windowName, offset, size);
		docsWindow.LoadDoc(docsPage);
	}

	public void OpenAndGoTo(string doc)
	{
		AddNewDocsWindow(doc);
		if (MainSim.Inst.researchMenu.IsOpen)
		{
			MainSim.Inst.researchMenu.OpenCloseMenu();
		}
	}

	private void RegisterWindow(Window win, string name, Vector2 offset, Vector2 size = default(Vector2))
	{
		win.workspace = this;
		openWindows[name] = win;
		if (win.TryGetComponent<CodeWindow>(out var component))
		{
			codeWindows[name] = component;
		}
		win.windowName = name;
		win.GetComponent<RectTransform>().anchoredPosition = offset;
		if (size != default(Vector2))
		{
			win.playerSetSize = size;
			win.UpdateSize();
		}
		containerDirty = true;
	}

	public void MoveCameraTo(Window target, bool alwaysMoveWindow = false, int charIndex = -1, CodeInputField inputField = null)
	{
		RectTransform component = target.GetComponent<RectTransform>();
		if (!alwaysMoveWindow)
		{
			if (inputField != null)
			{
				Vector3 bottomRight = inputField.textComponent.textInfo.characterInfo[charIndex].bottomRight;
				Vector3 vector = inputField.textComponent.rectTransform.TransformPoint(bottomRight);
				if (vector.x >= 0f && vector.x < (float)Screen.width && vector.y >= 0f && vector.y < (float)Screen.height)
				{
					return;
				}
			}
			else
			{
				Rect rect = new Rect(Vector2.zero, ((RectTransform)base.transform).rect.size);
				Vector2 size = rect.size;
				Vector2 anchoredPosition = target.HighestDockedParent.GetComponent<RectTransform>().anchoredPosition;
				Vector2 vector2 = new Vector2(0f, target.DockingOffset);
				Vector2 position = anchoredPosition - vector2 + container.anchoredPosition + size / 2f;
				Rect rect2 = new Rect(position, component.rect.size);
				rect2.position -= new Vector2(0f, component.rect.size.y);
				if (rect2.Intersection(rect).Area() > rect2.Area() * 0.5f)
				{
					return;
				}
			}
		}
		float num = 0.2f;
		transitionStartPosition = container.anchoredPosition;
		transitionStartTime = Time.time;
		transitionEndTime = transitionStartTime + num;
		transitionTarget = target;
		transitionTargetCharIndex = charIndex;
		transitionTargetInputField = inputField;
	}

	private void LerpCameraToTarget()
	{
		if (transitionEndTime >= Time.time && transitionTarget != null)
		{
			RectTransform component = transitionTarget.GetComponent<RectTransform>();
			Vector2 anchoredPosition = transitionTarget.HighestDockedParent.GetComponent<RectTransform>().anchoredPosition;
			Vector2 vector = new Vector2(0f, transitionTarget.DockingOffset);
			Vector2 b = -anchoredPosition + vector;
			if (transitionTargetInputField != null)
			{
				Vector3 bottomRight = transitionTargetInputField.textComponent.textInfo.characterInfo[transitionTargetCharIndex].bottomRight;
				Vector3 position = transitionTargetInputField.textComponent.rectTransform.TransformPoint(bottomRight);
				Vector3 vector2 = component.InverseTransformPoint(position);
				b -= (Vector2)vector2;
			}
			else
			{
				b += new Vector2(0f - component.rect.width, component.rect.height) / 2f;
			}
			float t = (Time.time - transitionStartTime) / (transitionEndTime - transitionStartTime);
			container.anchoredPosition = Vector2.Lerp(transitionStartPosition, b, t);
		}
		else
		{
			transitionTarget = null;
		}
	}

	public string GenerateFileName(string prefix)
	{
		int num = 0;
		string text;
		do
		{
			text = prefix + num;
			num++;
		}
		while (!IsValidFileName(text));
		return text;
	}

	public bool IsValidFileName(string fileName)
	{
		if (string.IsNullOrEmpty(fileName) || openWindows.Keys.Select((string f) => f.ToLower()).Contains(fileName.ToLower()))
		{
			return false;
		}
		if (fileName == "__builtins__")
		{
			return false;
		}
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		foreach (char value in invalidFileNameChars)
		{
			if (fileName.Contains(value))
			{
				return false;
			}
		}
		return true;
	}

	public void AddNewWindow()
	{
		OpenCodeWindow(GenerateFileName("f"), "", -container.anchoredPosition + spawnWindowOffset);
		if (codeWindows.Count >= 20)
		{
			Achievements.UnlockAchievement("CHAOS");
		}
	}

	public void AddNewDocsWindow(string doc = "docs/home.md", Vector2 offset = default(Vector2))
	{
		OpenDocsWindow(GenerateFileName("docs"), doc, -container.anchoredPosition + spawnDocsWindowOffset + offset);
	}

	public void CallAddNewDocsWindow()
	{
		AddNewDocsWindow();
	}

	public void Undo()
	{
		if (activeWindow != null)
		{
			undoHistory.Undo(activeWindow.gameObject);
		}
	}

	public void Redo()
	{
		if (activeWindow != null)
		{
			undoHistory.Redo(activeWindow.gameObject);
		}
	}
}

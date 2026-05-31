using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppPDFReader : MonoBehaviour
{
	[Header("Components")]
	public FountBase fountBase;

	public PDFFileBase PDFFileBase;

	public DetectionInputField detectionInputField;

	[AppNameDropdown]
	[Header("Component Default")]
	public string nameInAppBase;

	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	[Header("UI")]
	public RectTransform ViewPage;

	public RectTransform PageParentOne;

	public RectTransform PageParentTwo;

	public CanvasGroup BlockCenterUpMenu;

	[Header("UI Page")]
	public TMP_InputField PageInput;

	public TMP_Text PageTotal;

	[Header("UI One Page View")]
	public RectTransform BoxPagePreview;

	public RectTransform OnePagePreview;

	public RectTransform TwoPagePreview;

	[Header("UI File Window")]
	public RectTransform ContextMenuFile;

	public RectTransform ContextMenuFileParent;

	public RectTransform ContextMenuFilePrefab;

	[Header("UI File Not Find Window")]
	public RectTransform BoxPageNotFindFile;

	public TMP_Text BoxPageNotFindFilePath;

	[Header("UI Resize")]
	public RectTransform ResizeToSmall;

	public RectTransform ResizeToBig;

	[Header("Scrolls")]
	public ScrollRect[] PreviewScroll;

	[Header("Last Open File")]
	public List<PDFPathFile> pathOpenFiles;

	[Header("App Explorer Selector")]
	public appExplorerSelector appExplorerSelectorPrefab;

	public Transform appExplorerSelectorPrefabParent;

	public appExplorerSelector appExplorerSelector;

	public static string[] supportedExtensions;

	public FileSystemObject currentFile;

	private bool isOpen;

	private AppBase appBase;

	private DirectoryManager directoryManager;

	private string AppNameFromApplicationBase;

	private int totalPage;

	private int ActualViewPage;

	private string openPathFile;

	private void OnValidate()
	{
	}

	public void OpenApp()
	{
	}

	public void OpenAppWithFile(FileSystemObject file)
	{
	}

	public void OpenApplication(FileSystemObject file, bool fromFiles)
	{
	}

	public void CloseAllSubWindow()
	{
	}

	public void CloseApp()
	{
	}

	public void CloseBoxWindowNotFindFile()
	{
	}

	public void BoxWindowNotFindFile(bool active, string path = "")
	{
	}

	public void ContextMenuFileDisplayed(bool active)
	{
	}

	public void OpenSelectFile()
	{
	}

	public void OpenContextMenuAdapter(PDFPathFile path)
	{
	}

	public void PageInputDeselect(string text)
	{
	}

	public void OpenPageFromField()
	{
	}

	public void OpenPage(int page)
	{
	}

	public void ChangedScrollOne(Vector2 pos)
	{
	}

	public void ChangedScrollTwo(Vector2 pos)
	{
	}

	public void BoxWindowPagesDisplayed(bool active)
	{
	}

	public void ResizePage(bool small)
	{
	}

	public void ChangeNumberPagesDisplayed(int display)
	{
	}

	public void GoToTopPage()
	{
	}

	public static long MathSizeBytePDF(List<PDFPage> pdf)
	{
		return 0L;
	}

	public void RenderDocument(FileSystemObject file)
	{
	}

	public void ClearDocument()
	{
	}

	private void RenderTextElement(PDFElement element, GameObject elementObject)
	{
	}

	private void RenderImageElement(PDFElement element, GameObject elementObject)
	{
	}

	public static List<PDFPage> DeepCopy(List<PDFPage> pdf)
	{
		return null;
	}

	public static PDFElement DuplicateElement(PDFElement el)
	{
		return null;
	}
}

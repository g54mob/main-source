using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabletAppPDFReader : MonoBehaviour
{
	[Header("Window Components")]
	public TabletAppFile tabletAppFile;

	public TabletAppAnimationWindow tabletAppAnimationWindow;

	public TabletAppPDFReaderFileExplorer tabletAppPDFReaderFileExplorer;

	[Header("Components")]
	public FountBase fountBase;

	public PDFFileBase PDFFileBase;

	public DetectionInputField detectionInputField;

	[Header("UI")]
	public RectTransform ViewPage;

	public RectTransform PageParentOne;

	public RectTransform AppMenuPDFFileExplorer;

	public RectTransform AppMenuPDFViewer;

	[Header("UI Page")]
	public TMP_InputField PageInput;

	public TMP_Text PageTotal;

	[Header("Scrolls")]
	public ScrollRect PreviewScroll;

	public static string[] supportedExtensions;

	private FileSystemObject currentFile;

	private bool isOpen;

	public int totalPage;

	public int ActualViewPage;

	public void OpenApp()
	{
	}

	public void OpenApplication(FileSystemObject file, bool fromFiles)
	{
	}

	public void CloseApp()
	{
	}

	public void BackToFileList()
	{
	}

	public void RenderDocumentAndOpen(FileSystemObject file)
	{
	}

	public void RenderDocument(FileSystemObject file)
	{
	}

	private void RenderTextElement(PDFElement element, GameObject elementObject)
	{
	}

	private void RenderImageElement(PDFElement element, GameObject elementObject)
	{
	}

	public void ClearDocument()
	{
	}

	public void OpenPage(int page)
	{
	}

	public void ChangedScrollOne(Vector2 pos)
	{
	}

	public void PageInputDeselect(string text)
	{
	}

	public void OpenPageFromField()
	{
	}

	public void GoToTopPage()
	{
	}
}

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowContentController : MonoBehaviour
{
	[Header("Components")]
	public RectTransform rect;

	public Button tabButton;

	public WindowTabController tabController;

	public InfoWindow window;

	public ZoomContent zoomController;

	public RectTransform pageRect;

	public Image pageImg;

	public Vector2 normalSize;

	public bool centred;

	public bool alwaysCentred;

	public float fitScale;

	public bool clearTextMode;

	private StateSaveData.MessageThreadSave thread;

	private int msgIndex;

	[NonSerialized]
	[Header("Content")]
	public DDSSaveClasses.DDSTreeSave content;

	public Dictionary<DDSSaveClasses.DDSMessageSettings, TextMeshProUGUI> spawnedText;

	private List<GameObject> spawnedContent;

	public TextMeshProUGUI elementText;

	public PageBasedContent pageBasedContent;

	public GameObject pageControls;

	public List<PagePipButtonController> pagePips;

	public int page;

	public ButtonController nextPage;

	public ButtonController prevPage;

	private void Awake()
	{
	}

	private void GetReferences()
	{
	}

	private void OnEnable()
	{
	}

	public void SetAlwaysCentred(bool newVal)
	{
	}

	public void CentrePage()
	{
	}

	public void UpdateFitScale()
	{
	}

	public void LoadContent()
	{
	}

	public void ConstructContent(DDSSaveClasses.DDSMessageSettings msg)
	{
	}

	public void UpdateNoteText()
	{
	}

	public void TextOverflowCheck(bool forcePageModeCheck = false)
	{
	}

	public void ReSpawnPagePips(bool resetPage = true)
	{
	}

	public void SetPage(int newPage, bool forceUpdate = false)
	{
	}

	public void NextPage()
	{
	}

	public void PrevPage()
	{
	}

	private void UpdatePips()
	{
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClueExplorer : Panel
{
	public const string CLUE_CONTAINER_PATH = "Clue Container";

	public const string CLUE_NAME_PATH = "Clue Name";

	[SerializeField]
	private GameObject clueIconPrefab;

	[SerializeField]
	private GameObject cluePopupPrefab;

	[SerializeField]
	private GameObject audioCluePopupPrefab;

	[SerializeField]
	private TaskbarManager taskbarManager;

	[SerializeField]
	private Sprite clueTaskbarSprite;

	private PanelManager cluePanelManager;

	private Canvas canvas;

	protected ClosePanelAudio audioPlayer;

	protected Notification notifPlayer;

	private bool hasLoaded;

	protected override void Start()
	{
		base.Start();
		audioPlayer = SoundEffectUtils.GetOpenClosePanelPlayer();
		notifPlayer = SoundEffectUtils.GetNotificationPlayer();
		cluePanelManager = GetComponent<PanelManager>();
		canvas = UIUtils.FindCanvasFromChild(base.transform);
	}

	public override void OpenPanel()
	{
		base.OpenPanel();
		if (!hasLoaded)
		{
			ClearClues();
			LoadClues();
		}
	}

	public override void ClosePanel()
	{
		hasLoaded = false;
		base.ClosePanel();
	}

	public void LoadClues()
	{
		hasLoaded = true;
		float num = 0.2f;
		int currLevel = LevelManager.GetCurrLevel();
		Dictionary<string, Clue> allClues = ResourcesManager.GetAllClues($"Evidence/{currLevel}/Icons/", currLevel);
		Dictionary<string, Clue> allClues2 = ResourcesManager.GetAllClues($"Evidence/{currLevel}/Clues/", currLevel);
		foreach (string key in allClues.Keys)
		{
			StartCoroutine(LoadIcon(num, allClues, allClues2, key, currLevel));
			num += 0.12f;
		}
	}

	private IEnumerator LoadIcon(float delay, Dictionary<string, Clue> clueIcons, Dictionary<string, Clue> cluePopups, string fileName, int level)
	{
		yield return new WaitForSeconds(delay);
		GameObject clueIcon = Object.Instantiate(clueIconPrefab, base.transform.Find("Clue Container"));
		SetClueIcon(clueIcon, clueIcons[fileName].photoClue);
		string text = "jpg";
		string transcript = null;
		if (cluePopups[fileName].IsAudioClue())
		{
			transcript = ResourcesManager.GetTranscript($"{level}/{fileName}");
			text = "mp3";
		}
		SetClueName(clueIcon, fileName + "<b>.</b>" + text);
		SetPopup(clueIcon, cluePopups[fileName], fileName, transcript);
		notifPlayer.PlayLoadClue();
	}

	public void ClearClues()
	{
		hasLoaded = false;
		foreach (Transform item in base.transform.Find("Clue Container"))
		{
			Object.Destroy(item.gameObject);
		}
	}

	private void SetClueIcon(GameObject clueIcon, Sprite sprite)
	{
		clueIcon.GetComponent<Image>().sprite = sprite;
	}

	private void SetClueName(GameObject clueIcon, string name)
	{
		clueIcon.transform.Find("Clue Name").GetComponent<TextMeshProUGUI>().text = name;
	}

	private void SetPopup(GameObject clueIcon, Clue clue, string clueName, string transcript)
	{
		clueIcon.GetComponent<Button>().onClick.AddListener(delegate
		{
			bool flag = taskbarManager.IsMaximumTaskbarButtons();
			if (!cluePanelManager.OpenPanel(clueName) && !flag)
			{
				audioPlayer.PlayOpen();
				GameObject gameObject = Object.Instantiate(clue.IsPhotoClue() ? cluePopupPrefab : audioCluePopupPrefab, canvas.transform.position, Quaternion.identity, canvas.transform);
				UIUtils.SetPenultimateLayer(gameObject);
				CluePopup component = gameObject.GetComponent<CluePopup>();
				if (clue.IsPhotoClue())
				{
					component.SetTransform(clue.photoClue.rect);
					component.SetImage(clue.photoClue);
				}
				else
				{
					component.SetAudio(clue.audioClue, transcript);
				}
				string toolbarName = UIUtils.ToTitleCase(string.Join(" ", clueName.Split('_')));
				component.SetToolbarName(toolbarName);
				cluePanelManager.ManagePanel(clueName, gameObject);
				PanelManager.OpenWindow(gameObject);
				taskbarManager.AddTaskbar(gameObject, clueTaskbarSprite, clueName);
			}
			else if (!flag)
			{
				audioPlayer.PlayOpen();
				taskbarManager.AddTaskbar(cluePanelManager.GetPanel(clueName), clueTaskbarSprite, clueName);
			}
		});
	}
}

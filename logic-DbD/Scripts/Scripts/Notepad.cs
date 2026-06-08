using System;
using System.Collections;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notepad : Panel
{
	private readonly string SAVED_NOTES_TABLE = "notes";

	public static readonly int TOTAL_PAGES = 8;

	[SerializeField]
	private Transform pageButtons;

	[SerializeField]
	private Transform colorButtons;

	[SerializeField]
	private TMP_InputField notePage;

	[SerializeField]
	private Image noteBackground;

	[SerializeField]
	private AudioSwitcher audioPlayer;

	private string[] notes;

	private int currentPage;

	private int currentColor;

	protected override void Awake()
	{
		base.Awake();
		LoadNotes();
	}

	protected override void Start()
	{
		base.Start();
		notePage.text = notes[0];
		currentPage = 0;
		SetColor(PlayerPrefs.GetInt(PlayerPrefsManager.NOTEPAD_COLOR));
		TMP_InputField tMP_InputField = notePage;
		tMP_InputField.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(tMP_InputField.onValidateInput, (TMP_InputField.OnValidateInput)((string input, int charIndex, char addedChar) => (addedChar != ';') ? addedChar : '\0'));
	}

	private void LoadNotes()
	{
		notes = new string[TOTAL_PAGES];
		for (int i = 0; i < notes.Length; i++)
		{
			notes[i] = "";
		}
		using (IDbConnection connection = DatabaseUtils.GetConnection(Save.PERSISTENT_SAVES_DATABASE))
		{
			if (!DatabaseUtils.ContainsTable(SAVED_NOTES_TABLE, connection))
			{
				Debug.Log(SAVED_NOTES_TABLE + " table does not exist");
			}
			else
			{
				CreateTablesHelpers.LoadSavedTable(connection, SAVED_NOTES_TABLE, LoadNote);
			}
		}
		void LoadNote(string[] row)
		{
			int num = int.Parse(row[1]);
			notes[num] = CreateTablesHelpers.RestoreQuotations(row[0]);
		}
	}

	public string GetNote(int page)
	{
		if (page >= 8 || page < 0)
		{
			return "";
		}
		return notes[page];
	}

	public int GetCurrentPage()
	{
		return currentPage;
	}

	public void SaveNote()
	{
		if (currentPage <= notes.Length)
		{
			notes[currentPage] = notePage.text;
			SaveNoteToDatabase();
		}
	}

	public void SetCurrentPage(int currPage)
	{
		Transform child = pageButtons.GetChild(currentPage);
		Debug.Log($"currPage={currPage}");
		SetCurrentPageButtonInteractable(child, value: true);
		currentPage = currPage;
		child = pageButtons.GetChild(currPage);
		SetCurrentPageButtonInteractable(child, value: false);
		audioPlayer.PlayEffect();
		notePage.text = notes[currPage];
	}

	public void SetCurrentPageButtonInteractable(Transform transform, bool value)
	{
		transform.GetComponent<Button>().interactable = value;
	}

	public void SetColorInteractable(int colorIndex)
	{
		Transform child = colorButtons.GetChild(currentColor);
		SetCurrentPageButtonInteractable(child, value: true);
		child = colorButtons.GetChild(colorIndex);
		SetCurrentPageButtonInteractable(child, value: false);
	}

	public void SetColor(int colorIndex)
	{
		Color color = GetColor();
		currentColor = colorIndex;
		Color color2 = GetColor();
		StartColorTransition(color, color2, 0.3f);
		bool flag = colorIndex == 5;
		notePage.textComponent.color = (flag ? Color.white : Color.black);
		notePage.caretColor = (flag ? Color.white : Color.black);
		PlayerPrefs.SetInt(PlayerPrefsManager.NOTEPAD_COLOR, colorIndex);
	}

	private Color GetColor()
	{
		return colorButtons.GetChild(currentColor).GetComponent<ColorButton>().GetColor();
	}

	private void SaveNoteToDatabase()
	{
		using IDbConnection connection = DatabaseUtils.GetConnection(Save.PERSISTENT_SAVES_DATABASE);
		if (!DatabaseUtils.ContainsTable(SAVED_NOTES_TABLE, connection))
		{
			DatabaseUtils.CreateTable(connection, SAVED_NOTES_TABLE, "note TEXT, page INT");
		}
		string value = $"\"{CreateTablesHelpers.RemoveQuotations(notes[currentPage])}\", {currentPage}";
		DatabaseUtils.DeleteFromTable(connection, SAVED_NOTES_TABLE, $"page = {currentPage}");
		DatabaseUtils.AddSingleRowToTable(connection, SAVED_NOTES_TABLE, "note, page", value);
	}

	public void StartColorTransition(Color startColor, Color endColor, float duration)
	{
		StartCoroutine(ChangeColor(startColor, endColor, duration));
	}

	private IEnumerator ChangeColor(Color startColor, Color endColor, float duration)
	{
		float timeElapsed = 0f;
		while (timeElapsed < duration)
		{
			float t = timeElapsed / duration;
			noteBackground.color = Color.Lerp(startColor, endColor, t);
			timeElapsed += 0.01f;
			yield return new WaitForSeconds(0.01f);
		}
		noteBackground.color = endColor;
	}
}

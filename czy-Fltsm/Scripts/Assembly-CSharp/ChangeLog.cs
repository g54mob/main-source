using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLog : MonoBehaviour
{
	[Tooltip("Text component for the change notes.")]
	[SerializeField]
	private TextMeshProUGUI _changesText;

	[SerializeField]
	private Button _previousPageButton;

	[SerializeField]
	private Button _nextPageButton;

	[SerializeField]
	private ScrollRect _scrollRect;

	[SerializeField]
	private bool _debug;

	private int _currentChangelogIndex;

	private TextAsset[] _changelogs;

	public void Initialize()
	{
		_previousPageButton.onClick.AddListener(PreviousPage);
		_nextPageButton.onClick.AddListener(NextPage);
		_nextPageButton.interactable = false;
		LoadChangelogs();
		_currentChangelogIndex = _changelogs.Length - 1;
		TextAsset textAsset = _changelogs[_currentChangelogIndex];
		string key = "lastSeenChangeLog";
		if (!(PlayerPrefs.GetString(key) == textAsset.name) || (Application.isEditor && _debug))
		{
			PlayerPrefs.SetString(key, textAsset.name);
			_changesText.text = ReturnCurrentChangelog();
			base.gameObject.SetActive(value: true);
		}
	}

	private void OnDestroy()
	{
		_previousPageButton.onClick.RemoveListener(PreviousPage);
		_nextPageButton.onClick.RemoveListener(NextPage);
	}

	private void LoadChangelogs()
	{
		Object[] array = Resources.LoadAll("ChangeLogs", typeof(TextAsset));
		_changelogs = new TextAsset[array.Length];
		for (int i = 0; i < _changelogs.Length; i++)
		{
			_changelogs[i] = (TextAsset)array[i];
		}
	}

	private string ParseText(string text)
	{
		return text.Replace("=== ", "<b>").Replace(" ===", "</b>").Replace("== ", "<size=26><b>")
			.Replace(" ==", "</b></size>")
			.Replace("***", "      *")
			.Replace("**", "   *")
			.Replace("*", "•");
	}

	private void PreviousPage()
	{
		if (_currentChangelogIndex > 0)
		{
			_nextPageButton.interactable = true;
			_scrollRect.verticalNormalizedPosition = 1f;
			_currentChangelogIndex--;
			_changesText.text = ReturnCurrentChangelog();
			if (_currentChangelogIndex == 0)
			{
				_previousPageButton.interactable = false;
			}
		}
	}

	private void NextPage()
	{
		if (_currentChangelogIndex < _changelogs.Length - 1)
		{
			_previousPageButton.interactable = true;
			_scrollRect.verticalNormalizedPosition = 1f;
			_currentChangelogIndex++;
			_changesText.text = ReturnCurrentChangelog();
			if (_currentChangelogIndex >= _changelogs.Length - 1)
			{
				_nextPageButton.interactable = false;
			}
		}
	}

	public void Display()
	{
		_changesText.text = ReturnCurrentChangelog();
		base.gameObject.SetActive(value: true);
	}

	private string ReturnCurrentChangelog()
	{
		return ParseText(_changelogs[_currentChangelogIndex].ToString());
	}
}

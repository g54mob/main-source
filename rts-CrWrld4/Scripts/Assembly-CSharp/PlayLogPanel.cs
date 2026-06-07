using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayLogPanel : MonoBehaviour
{
	[Serializable]
	public class OnSubmitCompleteEvent : UnityEvent<bool>
	{
	}

	public delegate void Function();

	public class ScoreEntry
	{
		public int rank;

		public string user;

		public int time;

		public int eco;

		public int unitsBuilt;

		public int unitsLost;

		public int plays;

		public ScoreEntry(int rank, string user, int time, int eco, int unitsBuilt, int unitsLost, int plays)
		{
		}
	}

	public GameObject playLogRowPrefab;

	public Transform playLogRowsContainer;

	public ScrollRect scrollRect;

	public GameObject submitPlayLogGO;

	public TMP_InputField submitNameInputField;

	public TMP_InputField submitGroupInputField;

	public TMP_InputField filterNameInputField;

	public TMP_InputField filterGroupInputField;

	public bool refreshOnStart;

	public float refreshOnStartDelay;

	public TextMeshProUGUI message;

	private bool callRetrievePlayLogAfterSubmit;

	public ObjectivesBar objectivesBar;

	public GameObject submitButtonIcon;

	public OnSubmitCompleteEvent OnSubmitComplete;

	[NonSerialized]
	public string guidOverride;

	public bool showSubmitOnStart;

	private bool _showSubmitPlayLog;

	private bool[] shouldSubmit;

	private string missionGUID;

	private List<List<ScoreEntry>> scoreLists;

	private bool scoreListDirty;

	private int submitScoreCallback;

	private string errorToShow;

	public bool showSubmitPlayLog
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void InvokeNextFrame(Function function)
	{
	}

	private IEnumerator _InvokeNextFrame(Function function)
	{
		return null;
	}

	public void ScrollToTop()
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void OnObjectiveClicked(int val)
	{
	}

	private void CreateTableRows()
	{
	}

	public void OnSubmitPlayLog()
	{
	}

	public void RefreshPlayLog()
	{
	}

	public void RetrievePlayLog(string missionGUID)
	{
	}

	private IEnumerator RetrievePlayLogCo()
	{
		return null;
	}

	private void ParseScores(XmlDocument doc)
	{
	}

	private IEnumerator SubmitScore(string missionGUID, string title, string version, string key, string user, string grp, int[] time, int[] eco, int[] unitsBuilt, int[] unitsLost, bool[] shouldSubmit)
	{
		return null;
	}

	private void ShowError()
	{
	}
}

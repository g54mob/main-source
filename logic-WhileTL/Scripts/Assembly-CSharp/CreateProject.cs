using System.Collections;
using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class CreateProject : ActiveComponent
{
	public class AlgoInProject
	{
		public Button deactiveButton;

		public int level;

		public int num;

		public int id;

		public AlgoInProject(int i, GameObject buttonPrefab, Transform root)
		{
			num = i;
			id = i;
			GameObject gameObject = Object.Instantiate(buttonPrefab, root.position, root.rotation);
			gameObject.transform.parent = root;
			deactiveButton = gameObject.GetComponent<Button>();
		}
	}

	public StartupView startupView;

	private bool isStartup;

	private GameObject buttonPrefab;

	[SceneBind("ProjectShortDescription")]
	private Text _projectShortDescription;

	[SceneBind("HelpText")]
	private Text helpText;

	[SceneBind("StartupFrame")]
	private Image startupFrame;

	[SceneBind("ResultFrame")]
	private Image resultFrame;

	[SceneBind("ProjectFrame")]
	private Image projectFrame;

	[SceneBind("HelpInProject")]
	private Text helpInProjectText;

	[SceneBind("Complexity")]
	private Text complexityText;

	[SceneBind("UserBlock")]
	private Text userBlock;

	[SceneBind("Servers")]
	private Text serversText;

	[SceneBind("Users")]
	private Text usersText;

	[SceneBind("RewardText")]
	private Text rewardText;

	[SceneBind("StartupType")]
	private Dropdown StartupType;

	[SceneBind("Name")]
	private InputField StartupName;

	[SceneBind("FinishContainer")]
	private Text _finishContainer;

	[SceneBind("CreateProjectButton")]
	private Button _createProjectButton;

	[SceneBind("ExitButton")]
	private Button exitButton;

	private int curComplexity;

	private int curServers;

	private AlgoProject _data;

	private const float LOADING_TIME = 1f;

	private bool _isLoading;

	private float _currentTime;

	private bool _isActive;

	public State LastResultState;

	private string _lastTemplate = string.Empty;

	private Actions _actions;

	private List<Button> algoButtons = new List<Button>();

	public List<AlgoInProject> algosInProject = new List<AlgoInProject>();

	public List<GameObject> usersCheckBox = new List<GameObject>();

	public Model model;

	private GameObject checkPrefab;

	private List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

	public List<string> GetListInUse()
	{
		List<string> result = new List<string>();
		for (int i = 0; i < algosInProject.Count; i++)
		{
		}
		return result;
	}

	public void CreateStartup(bool flag)
	{
		isStartup = flag;
	}

	private void UpdateInProjectList()
	{
	}

	private void MoveAlgoInPositions()
	{
		for (int i = 0; i < algosInProject.Count; i++)
		{
			algosInProject[i].num = i;
			GameObject obj = _finishContainer.gameObject;
			Vector3 position = obj.GetComponent<RectTransform>().position;
			Rect rect = obj.GetComponent<RectTransform>().rect;
			position += new Vector3(rect.width / 2f * ((float)(i % 2) * 1.5f) + rect.width / 2f - rect.width / 8f, (0f - rect.height) / 3f * ((float)(i / 2) * 1.5f) + rect.height / 2f, 0f);
			algosInProject[i].deactiveButton.GetComponent<RectTransform>().position = position;
			algosInProject[i].deactiveButton.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 1f, 1f);
			int newInstance = algosInProject[i].id;
			int newNum = i;
			algosInProject[i].deactiveButton.onClick = new Button.ButtonClickedEvent();
			algosInProject[i].deactiveButton.onClick.AddListener(delegate
			{
				DeleteAlgoFromProjectClick(newInstance, newNum);
			});
		}
	}

	private void DeleteAlgoFromProjectClick(int id, int i)
	{
		SetParams();
		Object.Destroy(algosInProject[i].deactiveButton.gameObject);
		algosInProject.RemoveAt(i);
		MoveAlgoInPositions();
		if (!isStartup)
		{
			UpdateInProjectList();
		}
	}

	private void SetParams()
	{
		serversText.text = TextResources.GetString("servers") + "~" + Logic.ServersToMoney(curServers) + "$";
		int num = 0;
		for (int i = 0; i < usersCheckBox.Count; i++)
		{
			if (usersCheckBox[i].GetComponent<Toggle>().isOn)
			{
				num++;
			}
		}
		if (isStartup)
		{
			usersText.text = TextResources.GetString("users") + " " + num * 10;
		}
	}

	private void OnAlgoButton(int id, AlgoBlockInf inform)
	{
	}

	public void OnExitClicked()
	{
		LastResultState = State.Denied;
		_ = isStartup;
		base.gameObject.SetActive(value: false);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		buttonPrefab = Resources.Load("Prefabs/BTNPrefab") as GameObject;
		checkPrefab = Resources.Load("Prefabs/UserCheck") as GameObject;
		StartupName.gameObject.SetActive(value: false);
		StartupType.gameObject.SetActive(value: false);
		_createProjectButton.onClick.AddListener(OnCreateClicked);
		exitButton.onClick.AddListener(OnExitClicked);
		TextResources.SetResourcesAccessHandler(ActiveComponent._staticData.TryGetText, ActiveComponent.Model);
		exitButton.GetComponentInChildren<Text>().text = TextResources.GetString("exit");
		_createProjectButton.GetComponentInChildren<Text>().text = TextResources.GetString("deploy");
	}

	public void IniEpochAlgoButtons(int epoch)
	{
	}

	public void ClearAll()
	{
		foreach (AlgoInProject item in algosInProject)
		{
			Object.Destroy(item.deactiveButton.gameObject);
		}
		_projectShortDescription.gameObject.SetActive(value: false);
		complexityText.gameObject.SetActive(value: false);
		algosInProject = new List<AlgoInProject>();
		curComplexity = 0;
		curServers = 0;
		LastResultState = State.Undefined;
	}

	public void IniEpochStartupsDropdown(int epoch)
	{
		StartupType.ClearOptions();
		options = new List<Dropdown.OptionData>();
		StartupType.AddOptions(options);
	}

	public void IniEpoch()
	{
	}

	private void CreareUsersCheckBox()
	{
		foreach (GameObject item in usersCheckBox)
		{
			Object.Destroy(item);
		}
		usersCheckBox = new List<GameObject>();
	}

	private string ParseTypesOfTask(AlgoProject p)
	{
		string text = "";
		foreach (ProjectType type in ActiveComponent._staticData.Types)
		{
			if (!text.Contains(type.Title) && p.Type.Contains(type.Title))
			{
				string text2 = "";
				if (helpInProjectText.text.Contains(type.Title))
				{
					Debug.Log("yellow");
					text2 = "<color=yellow>" + type.Title + "</color>";
				}
				else
				{
					text2 = type.Title;
				}
				if (!text.Contains(type.Title))
				{
					text = ((!(text == "")) ? (text + ", " + text2) : text2);
				}
			}
		}
		return text;
	}

	public void Redraw()
	{
		IniEpoch();
		ClearAll();
		curComplexity = 0;
		curServers = 0;
		_projectShortDescription.gameObject.SetActive(value: false);
		complexityText.gameObject.SetActive(value: false);
		StartupName.gameObject.SetActive(value: false);
		StartupType.gameObject.SetActive(value: false);
		CreareUsersCheckBox();
		if (!isStartup)
		{
			startupFrame.gameObject.SetActive(value: false);
			projectFrame.gameObject.SetActive(value: true);
			usersText.gameObject.SetActive(value: false);
			helpText.gameObject.SetActive(value: true);
			_projectShortDescription.gameObject.SetActive(value: true);
			complexityText.gameObject.SetActive(value: true);
			complexityText.text = TextResources.GetString("accreq") + ": " + ActiveComponent.Model.CurrentProject.Accuracy + "%";
			_projectShortDescription.text = TextResources.GetString(ActiveComponent.Model.CurrentProject.KeyName + "S");
			rewardText.text = TextResources.GetString("reward") + ": " + ActiveComponent.Model.CurrentProject.Reward + "$";
			UpdateInProjectList();
			helpText.text = TextResources.GetString("typesofproj") + ": " + ParseTypesOfTask(ActiveComponent.Model.CurrentProject);
		}
		else
		{
			startupFrame.gameObject.SetActive(value: true);
			projectFrame.gameObject.SetActive(value: false);
			helpText.gameObject.SetActive(value: false);
			usersText.gameObject.SetActive(value: true);
			StartupName.gameObject.SetActive(value: true);
			StartupType.gameObject.SetActive(value: true);
			helpText.text = "";
			helpInProjectText.text = "";
			rewardText.text = "";
		}
		SetParams();
	}

	public IEnumerator WaitForUserAction()
	{
		while (LastResultState == State.Undefined)
		{
			yield return new WaitForEndOfFrame();
		}
	}

	private void Resolve(State state)
	{
		LastResultState = state;
		HideAll();
	}

	private void HideAll()
	{
	}

	private void OnCreateClicked()
	{
	}

	private void OnTimeout()
	{
	}

	private void Update()
	{
		if (base.IsEnabled && _isActive && _isLoading)
		{
			_currentTime += Time.deltaTime;
			_ = _currentTime / 1f;
			_ = 1f;
		}
	}
}

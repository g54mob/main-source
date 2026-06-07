using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using StatementParser;
using UnityEngine;
using UnityEngine.UI;

public class MissionGuide : MonoBehaviour
{
	[Serializable]
	public class CampaignCharacter
	{
		public string Name;

		public CustomActor Person;

		public SDateTime Birthdate;

		public CampaignCharacter()
		{
		}

		public CampaignCharacter(string name, CustomActor person, int age)
		{
			Name = name;
			Person = person;
			Birthdate = SDateTime.Now() - SDateTime.GetYear(age);
		}
	}

	public class UITask
	{
		public CampaignMission Mission;

		public MissionProgress[] Bars;

		public GameObject FinishButton;

		public GameObject Header;

		private int _lastUpdated;

		private Dictionary<string, int> _taskProgress = new Dictionary<string, int>();

		private bool _wasFinished;

		private HashSet<RewardTask.Goal> _disabled = new HashSet<RewardTask.Goal>();

		public UITask(CampaignMission mission, GameObject headerPrefab, MissionProgress progressPrefab, Button finishPrefab, Transform contentPanel, Action<UITask> onFinish)
		{
			UITask obj = this;
			Mission = mission;
			Header = UnityEngine.Object.Instantiate(headerPrefab);
			Header.GetComponentInChildren<Text>().text = mission.Name;
			Header.transform.SetParent(contentPanel, false);
			if (!string.IsNullOrEmpty(mission.Task.Tutorial))
			{
				Button componentInChildren = Header.GetComponentInChildren<Button>(true);
				componentInChildren.onClick.AddListener(delegate
				{
					TutorialSystem.Instance.StartTutorial(mission.Task.Tutorial, true);
				});
				componentInChildren.GetComponent<GUIToolTipper>().ToolTipValue = "StartTutorialTip".Loc(mission.Task.Tutorial.LocTry());
				componentInChildren.gameObject.SetActive(true);
			}
			Bars = new MissionProgress[mission.Task.Goals.Length];
			for (int num = 0; num < mission.Task.Goals.Length; num++)
			{
				MissionProgress missionProgress = UnityEngine.Object.Instantiate(progressPrefab);
				missionProgress.transform.SetParent(contentPanel, false);
				missionProgress.Set(mission.Task.Goals[num]);
				Bars[num] = missionProgress;
			}
			Button button = UnityEngine.Object.Instantiate(finishPrefab);
			button.onClick.AddListener(delegate
			{
				onFinish(obj);
			});
			button.transform.SetParent(contentPanel, false);
			FinishButton = button.gameObject;
		}

		public void Destroy()
		{
			UnityEngine.Object.Destroy(Header);
			for (int i = 0; i < Bars.Length; i++)
			{
				UnityEngine.Object.Destroy(Bars[i].gameObject);
			}
			UnityEngine.Object.Destroy(FinishButton);
		}

		public bool Update()
		{
			RewardTask.Goal goal = Mission.Task.Goals[_lastUpdated];
			bool active = true;
			float progress = 1f;
			if (!_disabled.Contains(goal))
			{
				try
				{
					active = IsComplete(goal, LineParse.Execute(goal.Eval, ScriptSystem.TaskScope.Scope), out progress);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					_disabled.Add(goal);
				}
			}
			MissionProgress missionProgress = Bars[_lastUpdated];
			bool activeSelf = missionProgress.Tick.activeSelf;
			missionProgress.Bar.Value = Mathf.Clamp01(progress);
			missionProgress.Tick.SetActive(active);
			if (!activeSelf && missionProgress.Tick.activeSelf)
			{
				missionProgress.ToggleTipOff();
			}
			bool flag = true;
			for (int i = 0; i < Mission.Task.Goals.Length; i++)
			{
				RewardTask.Goal g = Mission.Task.Goals[i];
				if (!IsComplete(g))
				{
					flag = false;
					break;
				}
			}
			FinishButton.gameObject.SetActive(flag);
			_lastUpdated = (_lastUpdated + 1) % Mission.Task.Goals.Length;
			if (flag != _wasFinished)
			{
				_wasFinished = flag;
				if (_wasFinished)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsComplete(RewardTask.Goal g, object value, out float progress)
		{
			if (g.CompletedBy != null && g.CompletedBy.Length != 0)
			{
				for (int i = 0; i < g.CompletedBy.Length; i++)
				{
					int num = g.CompletedBy[i];
					RewardTask.Goal g2 = Mission.Task.Goals[num];
					if (IsComplete(g2))
					{
						progress = 1f;
						return true;
					}
				}
			}
			if (g.IsCountable)
			{
				int num2;
				try
				{
					num2 = Convert.ToInt32(value);
				}
				catch (Exception)
				{
					num2 = ((Convert.ToDouble(value) > 0.0) ? int.MaxValue : int.MinValue);
				}
				_taskProgress[g.IDName] = num2;
				progress = Mathf.Clamp01((float)num2 / (float)g.ReachGoal);
				return num2 >= g.ReachGoal;
			}
			if (g.IsAmount)
			{
				float num3 = (float)Convert.ToDouble(value);
				_taskProgress[g.IDName] = Mathf.FloorToInt(num3 * 1000f);
				progress = Mathf.Clamp01(num3 / g.FloatGoal);
				return num3 >= g.FloatGoal;
			}
			bool flag = (bool)value;
			_taskProgress[g.IDName] = (flag ? 1 : 0);
			progress = (flag ? 1 : 0);
			return flag;
		}

		public bool IsComplete(RewardTask.Goal g)
		{
			if (g.CompletedBy != null && g.CompletedBy.Length != 0)
			{
				for (int i = 0; i < g.CompletedBy.Length; i++)
				{
					int num = g.CompletedBy[i];
					RewardTask.Goal g2 = Mission.Task.Goals[num];
					if (IsComplete(g2))
					{
						return true;
					}
				}
			}
			if (_disabled.Contains(g))
			{
				return true;
			}
			if (g.IsCountable)
			{
				if (_taskProgress.GetOrDefault(g.IDName, 0) < g.ReachGoal)
				{
					return false;
				}
			}
			else if (g.IsAmount)
			{
				if ((float)_taskProgress.GetOrDefault(g.IDName, 0) / 1000f < g.FloatGoal)
				{
					return false;
				}
			}
			else if (_taskProgress.GetOrDefault(g.IDName, 0) < 1)
			{
				return false;
			}
			return true;
		}
	}

	public enum AnimationStates
	{
		Portrait = 0,
		Thinking = 1,
		Whatever = 2,
		Neutral = 3,
		Assertive = 4
	}

	public Color[] AnimColors;

	public static MissionGuide Instance;

	public GameObject Guide;

	public GameObject NothingButtonPrefab;

	public RectTransform TextArrow;

	public RectTransform GuideRect;

	public RectTransform TaskTransform;

	public RectTransform TaskContent;

	public RectTransform TaskMinimize;

	public AnimationCurve GuideBounce;

	public AnimationCurve ArrowBounce;

	public RawImage Img;

	public Image Background;

	public AnimatedText Prompt;

	public GameObject TaskHeader;

	public MissionProgress TaskProgress;

	public Button TaskFinish;

	public Toggle MuteGuideToggle;

	public Text NameTag;

	[NonSerialized]
	public CampaignMission LastActiveCampaign;

	[NonSerialized]
	public List<GUIArrow> Arrows = new List<GUIArrow>();

	[NonSerialized]
	private string[] _prompts;

	[NonSerialized]
	private string[] _mcharacters;

	[NonSerialized]
	private AnimationStates[] _emotes;

	public int CurrentPrompt;

	[NonSerialized]
	private List<UITask> _currentMissions = new List<UITask>();

	[NonSerialized]
	private AnimationStates _lastEmote;

	[NonSerialized]
	private float _guideAnim;

	[NonSerialized]
	private float _guideShow;

	[NonSerialized]
	private float _guideHide;

	[NonSerialized]
	private int _lastMissionUpdate;

	[NonSerialized]
	private int _lastSubMissionUpdate;

	[NonSerialized]
	private bool _expandTaskList;

	private static readonly string[] _subMissionList = new string[8] { "Servers", "Marketing", "Security", "Printing", "Contracts", "MoreMoney", "Education", "Reviews" };

	[NonSerialized]
	private List<CampaignMission> _subMissions = new List<CampaignMission>();

	[NonSerialized]
	private List<CampaignMission> _missionQueue = new List<CampaignMission>();

	[NonSerialized]
	private float _lastMouse;

	[NonSerialized]
	private bool _isDraggingTask;

	private int _taskListHeight = 256;

	[NonSerialized]
	private Dictionary<string, CampaignCharacter> _characters;

	[NonSerialized]
	private List<CampaignMission.FocusData> _focusQueue = new List<CampaignMission.FocusData>();

	public void StartTaskDrag()
	{
		if (!_expandTaskList)
		{
			ToggleTaskListHeight();
			_taskListHeight = 64;
		}
		_lastMouse = Input.mousePosition.y;
		_isDraggingTask = true;
	}

	private void Awake()
	{
		Instance = this;
	}

	public void MuteGuide(bool mute)
	{
		GameSettings.Instance.MuteGuide = mute;
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull() || GameSettings.Instance.EditMode || !GameSettings.Instance.CampaignMode)
		{
			return;
		}
		if (_focusQueue.Count > 0 && !HUD.Instance.HintPanel.gameObject.activeSelf && (_guideHide > 0f || !Guide.activeSelf))
		{
			for (int i = 0; i < _focusQueue.Count; i++)
			{
				CampaignMission.FocusData focusData = _focusQueue[i];
				if (focusData.Ready == null || (bool)LineParse.Execute(focusData.Ready, ScriptSystem.TaskScope.Scope))
				{
					HUD.Instance.HintPanel.NewTarget(focusData.Element, Utilities.RobustStringFormat(focusData.Message, true, false), focusData.Completion);
					_focusQueue.RemoveAt(i);
					break;
				}
			}
		}
		if (_missionQueue.Count > 0 && !Guide.activeSelf && !WindowManager.HasModal && TutorialSystem.Instance.CurrentTutorial == null && TutorialSystem.Instance.CurrentAskDialog == null)
		{
			StartMission(_missionQueue.Pop(), true);
		}
		if (_isDraggingTask)
		{
			int num = Mathf.RoundToInt(Mathf.Clamp((float)_taskListHeight + (Input.mousePosition.y - _lastMouse) / Options.UISize, 64f, (float)Screen.height / Options.UISize));
			TaskTransform.sizeDelta = new Vector2(TaskTransform.sizeDelta.x, num);
			if (Input.GetMouseButtonUp(0))
			{
				_taskListHeight = num;
				_isDraggingTask = false;
			}
		}
		if (_currentMissions.Count > 0 && !WindowManager.ModalMessageDialogOpen())
		{
			UITask uITask = _currentMissions[Mathf.Min(_currentMissions.Count - 1, _lastMissionUpdate)];
			if (uITask.Update())
			{
				UISoundFX.PlaySFX("NotificationWin", -1f, 0.5f);
				TaskTransform.DOPunchScale(new Vector3(0f, 0.25f, 0f), 0.5f, 8);
				if (LastActiveCampaign == uITask.Mission)
				{
					ClearArrows();
				}
				if (!_expandTaskList)
				{
					ToggleTaskListHeight();
				}
			}
			_lastMissionUpdate = (_lastMissionUpdate + 1) % _currentMissions.Count;
		}
		if (TaskTransform.gameObject.activeSelf && !_isDraggingTask)
		{
			int num2 = (_expandTaskList ? 256 : 24);
			if (Mathf.Abs((float)num2 - TaskTransform.sizeDelta.y) < 4f)
			{
				TaskTransform.sizeDelta = new Vector2(TaskTransform.sizeDelta.x, num2);
			}
			else
			{
				TaskTransform.sizeDelta = new Vector2(TaskTransform.sizeDelta.x, Mathf.RoundToInt(Mathf.Lerp(TaskTransform.sizeDelta.y, _expandTaskList ? _taskListHeight : 24, Time.deltaTime * 10f)));
			}
		}
		if (Guide.activeSelf)
		{
			Background.color = Color.Lerp(Background.color, AnimColors[(int)_emotes[Mathf.Min(_emotes.Length - 1, CurrentPrompt)]], Time.deltaTime * 10f);
			if (_guideHide > 0f)
			{
				_guideHide -= Time.deltaTime;
				GuideRect.localScale = new Vector3(_guideHide.MapRange(1f, 0.8f, 1f, 0f, true), 1f, 1f);
				if (_guideHide <= 0f)
				{
					Guide.SetActive(false);
				}
			}
			else
			{
				GuideRect.localScale = new Vector3(1f, (Time.realtimeSinceStartup - _guideShow).MapRange(0f, 0.2f, 0f, 1f, true), 1f);
				if (_guideAnim <= 1f)
				{
					_guideAnim += Time.deltaTime;
					Img.rectTransform.localScale = new Vector3(1f, GuideBounce.Evaluate(_guideAnim), 1f);
				}
				if (Prompt.Done)
				{
					TextArrow.gameObject.SetActive(true);
					TextArrow.anchoredPosition = new Vector2(-4f, ArrowBounce.Evaluate(Time.realtimeSinceStartup));
				}
				else
				{
					TextArrow.gameObject.SetActive(false);
				}
			}
		}
		if (_subMissions.Count > 0)
		{
			int index = Mathf.Min(_subMissions.Count - 1, _lastSubMissionUpdate);
			if (_subMissions[index].DoLaunchCheck())
			{
				StartMission(_subMissions[index], true);
				_subMissions.RemoveAt(index);
			}
			if (_subMissions.Count > 0)
			{
				_lastSubMissionUpdate = (_lastSubMissionUpdate + 1) % _subMissions.Count;
			}
		}
	}

	public void Advance()
	{
		if (!(_guideHide <= 0f))
		{
			return;
		}
		if (Prompt.Done)
		{
			CurrentPrompt++;
			if (CurrentPrompt < _prompts.Length)
			{
				SetEmote(_emotes[CurrentPrompt], _mcharacters[CurrentPrompt]);
				Prompt.ActualText = Utilities.RobustStringFormat(_prompts[CurrentPrompt], false, false);
				return;
			}
			if (_missionQueue.Count > 0)
			{
				Guide.SetActive(false);
				StartMission(_missionQueue.Pop(), true);
				return;
			}
			if (!_expandTaskList)
			{
				ToggleTaskListHeight();
			}
			else
			{
				UISoundFX.PlaySFX("SlideOut");
			}
			_guideHide = 1f;
			_lastEmote = AnimationStates.Portrait;
		}
		else
		{
			Prompt.MaxChars = int.MaxValue;
		}
	}

	public void SetEmote(AnimationStates emote, string character)
	{
		if (emote == _lastEmote)
		{
			return;
		}
		if (character.StartsWith(">"))
		{
			Actor actor = LineParse.Execute(LineParse.Parse(character.Substring(1)), ScriptSystem.TaskScope.Scope) as Actor;
			if (actor != null)
			{
				SetThumbnail(actor, emote);
				NameTag.text = actor.employee.FullName;
				Prompt.Gender = (actor.employee.Female ? "Female" : "Male");
			}
			else
			{
				CampaignCharacter campaignCharacter = _characters["Player"];
				SetThumbnail(campaignCharacter, emote);
				NameTag.text = campaignCharacter.Name;
				Prompt.Gender = (campaignCharacter.Person.Female ? "Female" : "Male");
			}
		}
		else
		{
			CampaignCharacter campaignCharacter2 = _characters[character];
			SetThumbnail(campaignCharacter2, emote);
			NameTag.text = campaignCharacter2.Name;
			Prompt.Gender = (campaignCharacter2.Person.Female ? "Female" : "Male");
		}
	}

	public void SetThumbnail(CampaignCharacter c, int animation, Dictionary<string, float> expression)
	{
		HUD.Instance.Portraits.RenderObject(c.Person.BodyItems, SDateTime.GetYears(c.Birthdate, SDateTime.Now()), Img.texture as RenderTexture, animation, expression);
	}

	public void SetThumbnail(Actor a, int animation, Dictionary<string, float> expression)
	{
		HUD.Instance.Portraits.RenderObject(a.employee.StyleGen, SDateTime.GetYears(a.employee.BirthDate, SDateTime.Now()), Img.texture as RenderTexture, animation, expression);
	}

	private Dictionary<string, float> GetExpression(AnimationStates state)
	{
		switch (state)
		{
		case AnimationStates.Thinking:
			return new Dictionary<string, float>
			{
				{ "Frown", 34f },
				{ "Arrogant", 100f }
			};
		case AnimationStates.Whatever:
			return new Dictionary<string, float>
			{
				{ "Smile", 100f },
				{ "Arrogant", 100f }
			};
		case AnimationStates.Neutral:
			return new Dictionary<string, float> { { "Smile", 40f } };
		case AnimationStates.Assertive:
			return new Dictionary<string, float> { { "Frown", 50f } };
		default:
			return new Dictionary<string, float>();
		}
	}

	public void SetThumbnail(CampaignCharacter c, AnimationStates state)
	{
		SetThumbnail(c, (int)state, GetExpression(state));
	}

	public void SetThumbnail(Actor a, AnimationStates state)
	{
		SetThumbnail(a, (int)state, GetExpression(state));
	}

	public void Init()
	{
		if (GameSettings.Instance.EditMode || !GameSettings.Instance.CampaignMode)
		{
			return;
		}
		Actor actor = GameSettings.Instance.sActorManager.Actors.First((Actor x) => x.employee.Founder);
		Img.texture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
		MuteGuideToggle.isOn = GameSettings.Instance.MuteGuide;
		for (int num = 0; num < HUD.Instance.BottomButtons.Count; num++)
		{
			MainBottomButton mainBottomButton = HUD.Instance.BottomButtons[num];
			if (!string.IsNullOrEmpty(mainBottomButton.UnlockMission) && !GameSettings.Instance.CompletedMissions.Contains(mainBottomButton.UnlockMission) && !GameSettings.Instance.CurrentMissions.Contains(mainBottomButton.UnlockMission))
			{
				mainBottomButton.HideMe(NothingButtonPrefab);
			}
		}
		string[] subMissionList = _subMissionList;
		foreach (string text in subMissionList)
		{
			if (!GameSettings.Instance.CompletedMissions.Contains(text) && !GameSettings.Instance.CurrentMissions.Contains(text))
			{
				_subMissions.Add(GameData.LoadMission(text));
			}
		}
		if (GameSettings.Instance.CampaignCharacters != null)
		{
			_characters = GameSettings.Instance.CampaignCharacters;
			return;
		}
		_characters = new Dictionary<string, CampaignCharacter>();
		_characters["Player"] = new CampaignCharacter(actor.employee.FullName, new CustomActor(actor.employee), 100);
		_characters["Bob"] = new CampaignCharacter(GameData.BobName ?? "Big Chungus", new CustomActor(XMLParser.ParseXML(Resources.Load<TextAsset>("Campaign/Bob").text), true), 30);
		_characters["Police"] = new CampaignCharacter("Officer Mostash", new CustomActor(XMLParser.ParseXML(Resources.Load<TextAsset>("Campaign/Police").text), true), 30);
		_characters["Mom"] = new CampaignCharacter("Mom", GenerateMom(actor.employee), 50);
		GameSettings.Instance.CampaignCharacters = _characters;
	}

	public CampaignCharacter GetCharacter(string name)
	{
		return _characters.GetOrNull(name);
	}

	public ActorBodyItem.BodyItemObject[] GetMom()
	{
		return _characters["Mom"].Person.BodyItems;
	}

	private CustomActor GenerateMom(Employee self)
	{
		List<ActorBodyItem.BodyItemObject> list = ActorGenerator.Instance.GenerateStyle(true, "Mom", 60f).ToList();
		ActorBodyItem.BodyItemObject bodyItemObject = list.First((ActorBodyItem.BodyItemObject x) => x.Key.Equals("HeadFemale"));
		ActorBodyItem.BodyItemObject bodyItemObject2 = self.StyleGen.First((ActorBodyItem.BodyItemObject x) => (!self.Female) ? x.Key.Equals("HeadMale") : x.Key.Equals("HeadFemale"));
		foreach (KeyValuePair<string, float> blend in bodyItemObject2.Blends)
		{
			if (!blend.Key.Equals("Weight") && bodyItemObject.Blends.ContainsKey(blend.Key) && Utilities.RandomValue < 0.9f)
			{
				bodyItemObject.Blends[blend.Key] = blend.Value;
			}
		}
		SVector3 value = bodyItemObject2.Colors["Skin"];
		int skinToneIndex = bodyItemObject2.SkinToneIndex;
		SVector3 value2 = bodyItemObject2.Colors["Hair"];
		foreach (ActorBodyItem.BodyItemObject item in list)
		{
			item.SkinToneIndex = skinToneIndex;
			if (item.Colors.ContainsKey("Skin"))
			{
				item.Colors["Skin"] = value;
			}
			if (item.Colors.ContainsKey("Hair"))
			{
				item.Colors["Hair"] = value2;
			}
		}
		ActorBodyItem.BodyItemObject[] bodyItems = list.ToArray();
		return new CustomActor(true, bodyItems, null, null, null, null);
	}

	public void UpdateBottomButtons()
	{
		bool flag = false;
		for (int i = 0; i < HUD.Instance.BottomButtons.Count; i++)
		{
			MainBottomButton mainBottomButton = HUD.Instance.BottomButtons[i];
			if (mainBottomButton.CurrentNothingButton != null && (GameSettings.Instance.CurrentMissions.Contains(mainBottomButton.UnlockMission) || GameSettings.Instance.CompletedMissions.Contains(mainBottomButton.UnlockMission)))
			{
				flag = true;
				mainBottomButton.ShowMe();
			}
		}
		if (flag)
		{
			HUD.Instance.UpdateButtonCounterPositions();
		}
	}

	public void CompleteAMission()
	{
		if (_currentMissions.Count > 0)
		{
			_currentMissions[0].FinishButton.GetComponent<Button>().onClick.Invoke();
		}
	}

	public void ClearArrows()
	{
		Arrows.ForEach(delegate(GUIArrow x)
		{
			if (x != null)
			{
				UnityEngine.Object.Destroy(x.gameObject);
			}
		});
		Arrows.Clear();
		LastActiveCampaign = null;
	}

	public void StartMission(CampaignMission m, bool withPrompt)
	{
		if ((Guide.activeSelf && withPrompt) || TutorialSystem.Instance.CurrentTutorial != null || TutorialSystem.Instance.CurrentAskDialog != null)
		{
			_missionQueue.Add(m);
			return;
		}
		if (m.Arrows != null && m.Arrows.Length != 0)
		{
			ClearArrows();
			LastActiveCampaign = m;
			CampaignMission.ArrowData[] arrows = m.Arrows;
			foreach (CampaignMission.ArrowData arrowData in arrows)
			{
				GUIArrow component = TutorialSystem.Instance.InstantiateArrow().GetComponent<GUIArrow>();
				component.ThreeD = arrowData.TOffset.HasValue;
				if (component.ThreeD)
				{
					component.ThreeDP = arrowData.TOffset.Value;
				}
				component.Anchor = arrowData.Element;
				component.Offset = arrowData.Offset;
				component.ScreenParent = arrowData.Element == null;
				component.AnyAngle = !arrowData.Angle.HasValue;
				if (arrowData.Angle.HasValue)
				{
					component.Angle = arrowData.Angle.Value;
				}
				component.ForceShow = arrowData.Force;
				component.HorizontalAlign = arrowData.HAnchor;
				component.VerticalAlign = arrowData.VAnchor;
				component.Completion = arrowData.Completion;
				Arrows.Add(component);
			}
		}
		if (withPrompt && m.Focus != null && m.Focus.Length != 0)
		{
			_focusQueue.AddRange(m.Focus);
		}
		if (m.Task != null)
		{
			_currentMissions.Add(new UITask(m, TaskHeader, TaskProgress, TaskFinish, TaskContent, delegate(UITask x)
			{
				_currentMissions.Remove(x);
				x.Destroy();
				GameSettings.Instance.CurrentMissions.Remove(m.ID);
				GameSettings.Instance.CompletedMissions.Add(m.ID);
				HUD.Instance.UpdateFurnitureButtons();
				if (x.Mission.NextMission != null)
				{
					StartMission(x.Mission.NextMission, true);
				}
				UpdateBottomButtons();
				UpdateTaskList();
			}));
			GameSettings.Instance.CurrentMissions.Add(m.ID);
			UpdateTaskList();
		}
		else
		{
			GameSettings.Instance.CompletedMissions.Add(m.ID);
		}
		HUD.Instance.UpdateFurnitureButtons();
		if (_expandTaskList)
		{
			ToggleTaskListHeight();
		}
		UpdateBottomButtons();
		if (withPrompt)
		{
			if (m.OnStartScript != null)
			{
				LineParse.Execute(LineParse.Parse(m.OnStartScript), ScriptSystem.TaskScope.Scope);
			}
			_prompts = m.GetPrompts().ToArray();
			_emotes = m.Emotes;
			_mcharacters = m.Characters;
			CurrentPrompt = 0;
			Prompt.ActualText = Utilities.RobustStringFormat(_prompts[0], false, false);
			SetEmote(_emotes[0], _mcharacters[0]);
			Guide.SetActive(true);
			_guideShow = Time.realtimeSinceStartup;
			_guideHide = 0f;
		}
	}

	public void StartMission(string mission, bool withPrompt)
	{
		if (_currentMissions.None((UITask x) => x.Mission.ID.Equals(mission)))
		{
			StartMission(GameData.LoadMission(mission), withPrompt);
		}
	}

	public void UpdateTaskList()
	{
		TaskTransform.gameObject.SetActive(_currentMissions.Count > 0);
	}

	public void ToggleTaskListHeight()
	{
		_expandTaskList = !_expandTaskList;
		TaskMinimize.rotation = Quaternion.Euler(0f, 0f, _expandTaskList ? 90 : 270);
		UISoundFX.PlaySFX(_expandTaskList ? "SlideIn" : "SlideOut");
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(Img.texture);
		if (Instance == this)
		{
			Instance = null;
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using StatementParser;
using Tyd;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TutorialSystem : MonoBehaviour
{
	[Serializable]
	public struct TutorialRectObject
	{
		public string Name;

		public RectTransform Rect;

		public TutorialRectObject(string name, RectTransform rect)
		{
			Name = name;
			Rect = rect;
		}

		public override string ToString()
		{
			return Name;
		}
	}

	public static Dictionary<string, Func<string, string>> RegReplacers = new Dictionary<string, Func<string, string>>
	{
		{
			"StartingFunds",
			(string x) => ActorCustomization.GetDefaultStartMoney().Currency()
		},
		{
			"StartingPlot",
			(string x) => PlotArea.StartPlotPrice.Currency()
		},
		{
			"SavingsInterest",
			(string x) => (Math.Pow(1.0 + InsuranceAccount.MonthlyInterest, 12.0) - 1.0).ToPercent()
		},
		{
			"KeyBind",
			(string x) => InputController.GetFullKeyBindString(InputController.GetKeyNum(x), false)
		},
		{
			"H",
			(string x) => "<Color=#312CDA>" + x + "</Color>"
		},
		{
			"Currency",
			(string x) => x.ConvertToFloatDef(0f).Currency()
		}
	};

	public static Dictionary<string, Func<bool>> ContinueChecks = new Dictionary<string, Func<bool>>
	{
		{
			"Build mode",
			() => HUD.Instance.BuildMode
		},
		{
			"AudioOverlay",
			() => AudioVisualizer.Instance != null && AudioVisualizer.Instance.isActiveAndEnabled
		},
		{
			"Company window",
			() => HUD.Instance.companyWindow.Window.Shown
		},
		{
			"Company detail window",
			() => WindowManager.AnyWindowsOfType<CompanyDetailWindow>()
		},
		{
			"Player company detail window",
			() => WindowManager.FindWindowType<CompanyDetailWindow>().Any((CompanyDetailWindow x) => x.company.IsLocalPlayer)
		},
		{
			"Other company detail window",
			() => WindowManager.FindWindowType<CompanyDetailWindow>().Any((CompanyDetailWindow x) => !x.company.Player)
		},
		{
			"Employee window",
			() => HUD.Instance.employeeWindow.Window.Shown
		},
		{
			"Contract window",
			() => HUD.Instance.contractWindow.Window.Shown
		},
		{
			"Product window",
			() => HUD.Instance.PlayerProductWindow.Window.Shown
		},
		{
			"Educate window",
			() => HUD.Instance.educationWindow.Window.Shown
		},
		{
			"Review window",
			() => HUD.Instance.reviewWindow.Window.Shown
		},
		{
			"Review start window",
			() => HUD.Instance.startReviewWindow.Window.Shown
		},
		{
			"Benefit window",
			() => HUD.Instance.benefitWindow.Window.Shown && HUD.Instance.benefitWindow.IsCompany
		},
		{
			"Individual benefit window",
			() => HUD.Instance.benefitWindow.Window.Shown && !HUD.Instance.benefitWindow.IsCompany
		},
		{
			"Copy order window",
			() => HUD.Instance.copyOrderWindow.Window.Shown
		},
		{
			"Server window",
			() => HUD.Instance.serverWindow.Window.Shown
		},
		{
			"Build environment",
			() => HUD.Instance.LastType == BuildDescriptor.BuildType.Environment
		},
		{
			"Research window",
			() => HUD.Instance.researchWindow.Window.Shown
		},
		{
			"Team window",
			() => HUD.Instance.TeamWindow.Window.Shown
		},
		{
			"Automation window",
			() => HUD.Instance.TeamWindow.autoWindow.Window.Shown
		},
		{
			"Project management window",
			() => HUD.Instance.AutoDevWindow.Window.Shown
		},
		{
			"Design document window",
			() => HUD.Instance.docWindow.Window.Shown
		},
		{
			"Distribution window",
			() => HUD.Instance.distributionWindow.Window.Shown
		},
		{
			"Digital distribution window",
			() => HUD.Instance.digitalDistributionWindow.Window.Shown
		},
		{
			"Market window",
			() => HUD.Instance.marketingWindow.Window.Shown
		},
		{
			"Owns stocks",
			() => GameSettings.Instance.MyCompany.NewOwnedStock.Count > 1
		},
		{
			"Building room",
			() => BuildController.Instance.CurrentTempWall != null || BuildController.Instance.RectPoints != null
		},
		{
			"Has room",
			() => GameSettings.Instance.sRoomManager.Rooms.Count > 0
		},
		{
			"Has segments",
			() => GameSettings.Instance.sRoomManager.GetAllSegments().Any((RoomSegment x) => x.Type.Contains("Door")) && GameSettings.Instance.sRoomManager.GetAllSegments().Any((RoomSegment x) => x.Type.Contains("Window"))
		},
		{
			"Has table",
			() => GameSettings.Instance.sRoomManager.Rooms.Any((Room x) => x.IsPlayerControlled() && x.GetFurniture("Table").Count > 0)
		},
		{
			"Has computer",
			() => GameSettings.Instance.sRoomManager.Rooms.Any((Room x) => x.IsPlayerControlled() && x.GetFurniture("Computer").Count > 0)
		},
		{
			"Has chair",
			() => GameSettings.Instance.sRoomManager.Rooms.Any((Room x) => x.IsPlayerControlled() && x.GetFurniture("Chair").Count > 0)
		},
		{
			"Room with team",
			() => GameSettings.Instance.sRoomManager.Rooms.Any((Room x) => x.Teams.Count > 0)
		},
		{
			"Employee with team",
			() => GameSettings.Instance.sActorManager.Actors.Any((Actor x) => x.Team != null)
		},
		{
			"Work with team",
			() => GameSettings.Instance.MyCompany.WorkItems.Where((WorkItem x) => x is DesignDocument).Any((WorkItem x) => x.DevTeams.Count > 0)
		},
		{
			"Employee details",
			() => HUD.Instance.DetailWindow.Window.Shown
		},
		{
			"Select stuff",
			() => SelectorController.Instance.Selected.Count > 1
		},
		{
			"Employee select",
			() => SelectorController.Instance.Selected.Count > 0 && SelectorController.Instance.Selected.All((Selectable x) => x is Actor)
		},
		{
			"Has contract design",
			() => GameSettings.Instance.MyCompany.WorkItems.OfType<DesignDocument>().Any((DesignDocument x) => x.contract != null)
		},
		{
			"Has contract alpha",
			() => GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareAlpha>().Any((SoftwareAlpha x) => x.contract != null)
		},
		{
			"No contract alpha",
			() => GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareAlpha>().None((SoftwareAlpha x) => x.contract != null)
		},
		{
			"Contract selected",
			() => HUD.Instance.contractWindow.Contracts.Selected.Count > 0
		},
		{
			"Has review",
			() => GameSettings.Instance.MyCompany.WorkItems.Any((WorkItem x) => x is ReviewWork)
		},
		{
			"Has autodev",
			() => GameSettings.Instance.MyCompany.WorkItems.Any((WorkItem x) => x is AutoDevWorkItem)
		},
		{
			"Has autodev project",
			() => GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>().Any((AutoDevWorkItem x) => x.Items.Count > 0)
		},
		{
			"Has design",
			() => GameSettings.Instance.MyCompany.WorkItems.OfType<DesignDocument>().Any((DesignDocument x) => x.contract == null)
		},
		{
			"Has alpha",
			() => GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareAlpha>().Any((SoftwareAlpha x) => x.contract == null && !x.InBeta)
		},
		{
			"Has beta",
			() => GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareAlpha>().Any((SoftwareAlpha x) => x.InBeta)
		},
		{
			"Has support",
			() => GameSettings.Instance.MyCompany.WorkItems.Any((WorkItem x) => x is SupportWork)
		},
		{
			"Has research",
			() => GameSettings.Instance.MyCompany.WorkItems.Any((WorkItem x) => x is ResearchWork)
		},
		{
			"Only design publisher",
			() => GameSettings.Instance.MyCompany.WorkItems.OfType<DesignDocument>().All((DesignDocument x) => x.contract != null || x.ActiveDeal != null || PublisherDeal.HasDeal(x, "Marketing"))
		},
		{
			"Only alpha publisher",
			() => GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareAlpha>().All((SoftwareAlpha x) => x.contract != null || x.ActiveDeal != null || PublisherDeal.HasDeal(x, "Marketing"))
		},
		{
			"Role change",
			() => HUD.Instance.roleSelect.Window.Shown
		},
		{
			"Hire window open",
			() => HUD.Instance.hireWindow.HireWin.Window.Shown
		},
		{
			"Hire selected",
			() => HUD.Instance.hireWindow.HireWin.EmployeeList.Selected.Count > 0
		},
		{
			"Has marketing plan",
			() => GameSettings.Instance.MyCompany.WorkItems.Any((WorkItem x) => x is MarketingPlan)
		},
		{
			"Staff open",
			() => HUD.Instance.staffWindow.Window.Shown
		},
		{
			"Hire look open",
			() => HUD.Instance.hireWindow.Window.Shown
		},
		{
			"Insurance open",
			() => HUD.Instance.insuranceWindow.Window.Shown
		},
		{
			"Color window",
			() => ColorWindow.Open
		},
		{
			"Wire mode",
			() => GameSettings.Instance.WireMode
		},
		{
			"Save window",
			() => SaveGameManager.Instance.SaveGameWindow.Shown
		},
		{
			"HR window",
			() => HUD.Instance.TeamWindow.autoWindow.Window.Shown
		},
		{
			"Has release date",
			() => GameSettings.Instance.MyCompany.WorkItems.OfType<DesignDocument>().Any((DesignDocument x) => x.ReleaseDate.HasValue)
		},
		{
			"Has press release",
			() => GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>().Any((MarketingPlan x) => x.Type == MarketingPlan.TaskType.PressRelease)
		},
		{
			"Has press build",
			() => GameSettings.Instance.PressBuildQueue.Count > 0
		},
		{
			"Team select window",
			() => HUD.Instance.TeamSelectWindow.Window.Shown
		},
		{
			"Rent overlay",
			() => "Rent".Equals(DataOverlay.Instance.ActiveOverlayName)
		},
		{
			"Has subsidiary window",
			() => WindowManager.FindWindowType<CompanyDetailWindow>().Any((CompanyDetailWindow x) => x.company != null && x.company.IsPlayerOwned())
		},
		{
			"Has subsidiary button",
			() => HUD.Instance.docWindow.SubsidiaryCombo.gameObject.activeSelf
		},
		{
			"Leasable room selected",
			() => SelectorController.Instance.Selected.OfType<Room>().Any((Room x) => x.Rentable && !x.PlayerOwned)
		},
		{
			"Deal negotiation window",
			() => HUD.Instance.distDealNegWindow.Window.Shown
		},
		{ "Any player rooms on floor", AnyPlayerRoomsOnFloor },
		{
			"Design document page 1",
			() => HUD.Instance.docWindow.CurrentPage == 0
		},
		{
			"Design document page 2",
			() => HUD.Instance.docWindow.CurrentPage == 1
		},
		{
			"Design document page 3",
			() => HUD.Instance.docWindow.CurrentPage == 2
		},
		{
			"Design document page 4",
			() => HUD.Instance.docWindow.CurrentPage == 3
		},
		{
			"Design document page 5",
			() => HUD.Instance.docWindow.CurrentPage == 4
		},
		{
			"Educatable employees",
			() => GameSettings.Instance.sActorManager.Actors.Any((Actor x) => x.employee.AnySpecPoints(x))
		},
		{
			"Research open",
			() => HUD.Instance.researchWindow.Spec != null
		},
		{
			"Invest Stock open",
			() => HUD.Instance.insuranceWindow.Stocks.isOn
		},
		{
			"Hardware design",
			() => HUD.Instance.docWindow.GetCategory().Hardware
		},
		{
			"Design manufacturing",
			() => HUD.Instance.docWindow.ManufactureView.activeSelf
		},
		{
			"Distribution hardware tab",
			() => HUD.Instance.distributionWindow.CurrentTab == 1
		},
		{
			"Hardware overlay",
			() => ManufactureOverlay.IsActive
		},
		{
			"Assembly lines window",
			() => AssemblyLineWindow.Instance.Window.Shown
		},
		{
			"Update window",
			() => HUD.Instance.updateWindow.Window.Shown
		},
		{
			"Has update",
			() => GameSettings.Instance.MyCompany.WorkItems.Any((WorkItem x) => x is SoftwareUpdate)
		},
		{
			"Has Add-on Product Window",
			() => WindowManager.FindWindowType<ProductDetailWindow>().Any((ProductDetailWindow x) => x.product != null && x.product.Addons.Count > 0)
		},
		{
			"Has Add-on Window",
			() => WindowManager.FindWindowType<ProductDetailWindow>().Any((ProductDetailWindow x) => x.Addon != null)
		},
		{
			"Has Add-on Design Window",
			() => HUD.Instance.addonDesignWindow.Window.Shown
		},
		{
			"Tax Menu Open",
			() => HUD.Instance.financeWindow.Window.Shown && HUD.Instance.financeWindow.TaxPanel.activeSelf
		},
		{
			"Accounting Window Open",
			() => HUD.Instance.accountingWindow.Window.Shown
		},
		{
			"Editing logo",
			() => WindowManager.AnyWindowsOfType<AdvancedLogoEditorWindow>()
		},
		{
			"Cleared logo",
			delegate
			{
				AdvancedLogoEditorWindow advancedLogoEditorWindow = WindowManager.FindFirstWindowType<AdvancedLogoEditorWindow>();
				return (object)advancedLogoEditorWindow != null && advancedLogoEditorWindow.MainEditor.Nodes.Count == 0;
			}
		},
		{ "Logo has shape", LogoHasShape },
		{ "Logo has effect", LogoHasEffect },
		{ "Logo is done", LogoIsDone }
	};

	public static Dictionary<string, TutorialMessage[]> Tutorials = null;

	public static Dictionary<string, HashSet<string>> Continuation = new Dictionary<string, HashSet<string>>();

	[NonSerialized]
	public TutorialMessage[] CurrentTutorial;

	public string CurrentTutorialName;

	public int CurrentMessage;

	public int TutorialLength;

	public List<int> PreviousMessages = new List<int>();

	public HashSet<int> SkippedMessages = new HashSet<int>();

	public static TutorialSystem Instance;

	public GUIWindow Window;

	public GameObject ContinueButton;

	public GameObject EndButton;

	public GameObject BackButton;

	public Text text;

	public Text ContinueText;

	public Text EndText;

	public LayoutElement textLayout;

	public Scrollbar scrollBar;

	public Texture2D ArrowTex;

	public GameObject RingPrefab;

	public GameObject ArrowPrefab;

	public RectTransform contentPanel;

	public Image ContinueButtonImage;

	public Image CancelButtonImage;

	public Gradient ButtonGradient;

	public CanvasGroup CGroup;

	public float FadeSpeed = 2f;

	[NonSerialized]
	public List<string> TutorialBacklog = new List<string>();

	public RawImage ExamplePic;

	public RectTransform TextPanel;

	public GameObject ExamplePicPanel;

	public VideoPlayer PicPlayer;

	public RenderTexture VideoTex;

	public GameObject CurrentAskDialog;

	public string LastAsk;

	private float _fading;

	private List<GameObject> PointsOfInterest = new List<GameObject>();

	[NonSerialized]
	private bool _forceManuelContinue;

	[NonSerialized]
	private bool _inGame;

	private static bool LogoHasShape()
	{
		AdvancedLogoEditorWindow advancedLogoEditorWindow = WindowManager.FindFirstWindowType<AdvancedLogoEditorWindow>();
		if (advancedLogoEditorWindow != null)
		{
			return advancedLogoEditorWindow.MainEditor.Nodes.Any((SDFNode x) => x.Node is SDFCreator.SDFShape);
		}
		return false;
	}

	private static bool LogoHasEffect()
	{
		AdvancedLogoEditorWindow advancedLogoEditorWindow = WindowManager.FindFirstWindowType<AdvancedLogoEditorWindow>();
		if (advancedLogoEditorWindow != null)
		{
			SDFNode sDFNode = advancedLogoEditorWindow.MainEditor.Nodes.FirstOrDefault((SDFNode x) => x.Node is SDFCreator.SDFShape);
			if (sDFNode != null)
			{
				return sDFNode.Outputs.Any((SDFNode x) => x.Node is SDFCreator.SDFEffect);
			}
		}
		return false;
	}

	private static bool LogoIsDone()
	{
		AdvancedLogoEditorWindow advancedLogoEditorWindow = WindowManager.FindFirstWindowType<AdvancedLogoEditorWindow>();
		if (advancedLogoEditorWindow != null && advancedLogoEditorWindow.MainEditor.FinalNode != null)
		{
			return advancedLogoEditorWindow.MainEditor.FinalNode.Node.IsValid();
		}
		return false;
	}

	private static bool AnyPlayerRoomsOnFloor()
	{
		bool flag = false;
		for (int i = 0; i < GameSettings.Instance.sRoomManager.Rooms.Count; i++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[i];
			if (room.PlayerOwned)
			{
				flag = true;
				if (room.Floor == GameSettings.Instance.ActiveFloor)
				{
					return true;
				}
			}
		}
		return !flag;
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void Start()
	{
		Window.Close();
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		if (Tutorials == null)
		{
			LoadTutorials();
		}
	}

	private void CheckBacklog()
	{
		if (CurrentTutorial == null && TutorialBacklog.Count > 0)
		{
			string text = TutorialBacklog[0];
			TutorialBacklog.RemoveAt(0);
			StartTutorial(text);
		}
	}

	public static void LoadTutorialFiles(Dictionary<string, TutorialMessage[]> tuts)
	{
		foreach (KeyValuePair<string, string> item in from x in GameData.LoadAllTextAssetsWithNameNoSplit("Tutorials")
			orderby (!x.Key.Equals("Shared")) ? 1 : 0
			select x)
		{
			bool shared = item.Key.Equals("Shared");
			TydCollection obj = TydFromText.ParseOne(item.Value) as TydCollection;
			TydCollection child = obj.GetChild<TydCollection>("Continuations");
			if (child != null)
			{
				Continuation[item.Key] = child.GetChildValues().ToHashSet();
			}
			List<TydCollection> list = obj.GetChild<TydCollection>("Messages", true).Nodes.OfType<TydCollection>().ToList();
			TutorialMessage[] array = new TutorialMessage[list.Count];
			string text = item.Key.ToUpper().Strip(' ');
			int num = 1;
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				TydCollection tydCollection = list[num2];
				int childValue = tydCollection.GetChildValue("Shared", false, -1);
				if (childValue >= 0)
				{
					array[num2] = tuts["Shared"][childValue];
					num++;
					continue;
				}
				TydString child2 = tydCollection.GetChild<TydString>("ID");
				if (child2 != null)
				{
					array[num2] = new TutorialMessage(tydCollection, child2.Value, shared);
					continue;
				}
				array[num2] = new TutorialMessage(tydCollection, text + num, shared);
				num++;
			}
			tuts.Add(item.Key, array);
		}
	}

	public void LoadTutorials()
	{
		Tutorials = new Dictionary<string, TutorialMessage[]>();
		LoadTutorialFiles(Tutorials);
	}

	private void ShowTut(string name)
	{
		if (MissionGuide.Instance != null)
		{
			MissionGuide.Instance.ClearArrows();
		}
		Window.rectTransform.anchoredPosition = new Vector2((float)Screen.width / 2f - Window.rectTransform.rect.width / 2f, (float)(-Screen.height) / 2f + Window.rectTransform.rect.height / 2f);
		Window.NonLocTitle = "TutorialPost".Loc(name.Loc());
		SkippedMessages.Clear();
		TutorialLength = CurrentTutorial.Count((TutorialMessage x) => !x.ShouldSkip());
		ShowWindow();
		CurrentTutorialName = name;
		SetCurrentMessage(0, false);
		UpdateContent();
	}

	private void ShowWindow()
	{
		Window.Show();
		_fading = 0f;
		CGroup.alpha = 1f;
	}

	private bool CheckContinuation(string before, string after)
	{
		HashSet<string> orNull = Continuation.GetOrNull(before);
		if (orNull != null)
		{
			return orNull.Contains(after);
		}
		return false;
	}

	public bool StartTutorial(string name, bool force = false)
	{
		_inGame = !GameSettings.Instance.IsReferenceNull();
		if (_inGame && !force && GameSettings.Instance.CampaignMode)
		{
			return false;
		}
		if (!GameSettings.HasCompletedOrInMission("Mission01"))
		{
			return false;
		}
		if (CurrentTutorialName != name && (force || (Options.Tutorial && (GameSettings.Instance.IsReferenceNull() || !GameSettings.Instance.DisabledTutorials.Contains(name)))) && (CurrentAskDialog == null || TutorialBacklog.Count == 0 || !TutorialBacklog[0].Equals(name)))
		{
			if (HUD.Instance == null)
			{
				CurrentMessage = 0;
				PreviousMessages.Clear();
				SkippedMessages.Clear();
				CurrentTutorial = null;
				if (Tutorials.TryGetValue(name, out CurrentTutorial))
				{
					ShowTut(name);
					return true;
				}
			}
			else if (force || (CurrentAskDialog == null && CurrentTutorial != null && CurrentMessage == CurrentTutorial.Length - 1 && CheckContinuation(CurrentTutorialName, name)))
			{
				if (CurrentTutorial != null && CurrentMessage == CurrentTutorial.Length - 1)
				{
					FinishTutorial(CurrentTutorialName);
				}
				CurrentMessage = 0;
				PreviousMessages.Clear();
				SkippedMessages.Clear();
				CurrentTutorial = null;
				if (Tutorials.TryGetValue(name, out CurrentTutorial))
				{
					ShowTut(name);
					GameSettings.GameSpeed = 0f;
					return true;
				}
			}
			else if (CurrentTutorial == null || CurrentMessage == CurrentTutorial.Length - 1)
			{
				if (CurrentAskDialog != null)
				{
					GameSettings.ForcePause = false;
					if (!TutorialBacklog.Contains(LastAsk))
					{
						TutorialBacklog.Insert(0, LastAsk);
					}
					UnityEngine.Object.Destroy(CurrentAskDialog);
				}
				bool show = Window.Shown;
				Window.Close();
				LastAsk = name;
				CurrentAskDialog = WindowManager.Instance.ShowMessageBox("TutorialPrompt".LocColor((FormatColorString)name.Loc()), true, DialogWindow.DialogType.Question, new KeyValuePair<string, Action>("Yes", delegate
				{
					UpdateContent(false);
					CurrentMessage = 0;
					PreviousMessages.Clear();
					SkippedMessages.Clear();
					CurrentTutorial = null;
					if (Tutorials.TryGetValue(name, out CurrentTutorial))
					{
						ShowTut(name);
						GameSettings.GameSpeed = 0f;
					}
				}), new KeyValuePair<string, Action>("Never", delegate
				{
					FinishTutorial(name);
					CurrentAskDialog = null;
					CheckBacklog();
					if (show)
					{
						ShowWindow();
					}
				}), new KeyValuePair<string, Action>("Disable all", delegate
				{
					if (show)
					{
						ShowWindow();
					}
					Options.SetAndSave("Tutorial", false);
				}), new KeyValuePair<string, Action>("Not now", delegate
				{
					CurrentAskDialog = null;
					CheckBacklog();
					if (show)
					{
						ShowWindow();
					}
				})).gameObject;
				return true;
			}
		}
		return false;
	}

	public void FinishTutorial(string tutName)
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		GameSettings.Instance.DisabledTutorials.Add(tutName);
		TutorialMessage[] array = Tutorials[tutName];
		foreach (TutorialMessage tutorialMessage in array)
		{
			if (tutorialMessage.Shared)
			{
				GameSettings.Instance.DisabledTutorials.Add(tutorialMessage.Message);
			}
		}
	}

	public void GoBackTutorial()
	{
		if (PreviousMessages.Count > 0)
		{
			int msg = PreviousMessages[PreviousMessages.Count - 1];
			PreviousMessages.RemoveAt(PreviousMessages.Count - 1);
			SetCurrentMessage(msg, false);
			UpdateContent();
		}
	}

	public void AdvanceTutorial(bool fadeIfDone, bool savePrevious)
	{
		SetCurrentMessage(CurrentMessage + 1, savePrevious);
		UpdateContent(true, fadeIfDone);
	}

	public void AdvanceTutorial()
	{
		SetCurrentMessage(CurrentMessage + 1);
		UpdateContent();
	}

	public void SetCurrentMessage(int msg, bool savePrevious = true)
	{
		if (savePrevious)
		{
			PreviousMessages.Add(CurrentMessage);
		}
		CurrentMessage = msg;
		while (CurrentMessage < CurrentTutorial.Length && CurrentTutorial[CurrentMessage].ShouldSkip())
		{
			CurrentMessage++;
		}
	}

	public void EndTutorial()
	{
		if (EndText.text == "Cancel".Loc())
		{
			Window.Close();
			DialogWindow d = WindowManager.SpawnDialog();
			d.Show("CancelTutorial".Loc(), false, DialogWindow.DialogType.Question, new KeyValuePair<string, Action>("Yes", delegate
			{
				CurrentTutorial = null;
				UpdateContent();
				d.Window.Close();
			}), new KeyValuePair<string, Action>("No", delegate
			{
				d.Window.Close();
				ShowWindow();
			}));
		}
		else
		{
			if (CurrentTutorial != null)
			{
				CurrentMessage = CurrentTutorial.Length;
			}
			UpdateContent();
		}
	}

	public void UpdateContent(bool checkBacklog = true, bool fadeIfDone = false)
	{
		if (CurrentTutorial == null || CurrentMessage >= CurrentTutorial.Length)
		{
			PointsOfInterest.ForEach(delegate(GameObject x)
			{
				UnityEngine.Object.Destroy(x.gameObject);
			});
			PointsOfInterest.Clear();
			if (CurrentTutorial != null)
			{
				FinishTutorial(CurrentTutorialName);
			}
			CurrentTutorialName = null;
			CurrentTutorial = null;
			CurrentMessage = 0;
			PreviousMessages.Clear();
			SkippedMessages.Clear();
			if (fadeIfDone)
			{
				_fading = 1f;
			}
			else
			{
				Window.Close();
			}
			if (checkBacklog)
			{
				CheckBacklog();
			}
			return;
		}
		BackButton.SetActive(PreviousMessages.Count > 0);
		AddPointsOfInterest();
		TutorialMessage tutorialMessage = CurrentTutorial[CurrentMessage];
		string tutorial = Localization.GetTutorial(tutorialMessage.Message);
		tutorial = new Regex("\\{([^\\}:]+):?([^\\}]+)?\\}").Replace(tutorial, delegate(Match x)
		{
			Func<string, string> orNull = RegReplacers.GetOrNull(x.Groups[1].Value);
			return "<B>" + ((orNull == null) ? x.Groups[1].Value : orNull(x.Groups[2].Value)) + "</B>";
		});
		text.text = tutorial;
		if (tutorialMessage.StartScript != null)
		{
			LineParse.Execute(LineParse.Parse(tutorialMessage.StartScript), ScriptSystem.TaskScope.Scope);
		}
		bool flag = false;
		if (tutorialMessage.ExamplePic != null)
		{
			Texture2D value;
			VideoClip value2;
			if (ObjectDatabase.Instance.TutorialPicDic.TryGetValue(tutorialMessage.ExamplePic, out value))
			{
				ExamplePic.texture = value;
				flag = true;
			}
			else if (ObjectDatabase.Instance.TutorialVidDic.TryGetValue(tutorialMessage.ExamplePic, out value2))
			{
				ExamplePicPanel.SetActive(true);
				ExamplePic.texture = VideoTex;
				PicPlayer.clip = value2;
				PicPlayer.Play();
				flag = true;
			}
		}
		if (flag)
		{
			ExamplePicPanel.SetActive(true);
			TextPanel.offsetMax = new Vector2(TextPanel.offsetMax.x, -136f);
		}
		else
		{
			if (PicPlayer.isPlaying)
			{
				PicPlayer.Stop();
			}
			ExamplePicPanel.SetActive(false);
			TextPanel.offsetMax = new Vector2(TextPanel.offsetMax.x, -4f);
		}
		scrollBar.value = 0f;
		contentPanel.anchoredPosition = new Vector2(contentPanel.anchoredPosition.x, 0f);
		bool flag2 = !tutorialMessage.ManualContinue && tutorialMessage.CanContinue();
		_forceManuelContinue = !tutorialMessage.CanIgnore && flag2;
		if (!_forceManuelContinue && flag2)
		{
			SkippedMessages.Add(CurrentMessage);
		}
		ContinueButton.SetActive(ManualContinue(tutorialMessage) && CurrentMessage < CurrentTutorial.Length - 1);
		ContinueText.text = (ManualContinue(tutorialMessage) ? "Continue" : "Skip").Loc();
		EndText.text = ((CurrentMessage == CurrentTutorial.Length - 1) ? "Finish" : "Cancel").Loc();
		Window.NonLocTitle = "TutorialPost".Loc(CurrentTutorialName.Loc()) + " (" + (CurrentMessage + 1 - SkippedMessages.Count((int x) => x <= CurrentMessage)) + "/" + (TutorialLength - SkippedMessages.Count) + ")";
		AddRings();
	}

	private bool ManualContinue(TutorialMessage msg)
	{
		if (!msg.ManualContinue)
		{
			return _forceManuelContinue;
		}
		return true;
	}

	public void AddPointsOfInterest()
	{
		PointsOfInterest.ForEach(delegate(GameObject x)
		{
			UnityEngine.Object.Destroy(x.gameObject);
		});
		PointsOfInterest.Clear();
		if (CurrentMessage < CurrentTutorial.Length)
		{
			CurrentTutorial[CurrentMessage].GetPoints(PointsOfInterest);
		}
	}

	public GameObject InstantiateArrow()
	{
		return UnityEngine.Object.Instantiate(ArrowPrefab);
	}

	private void Update()
	{
		if (_inGame && GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		Color color = ButtonGradient.Evaluate(Time.realtimeSinceStartup % 1f);
		ContinueButtonImage.color = color;
		CancelButtonImage.color = (EndText.text.Equals("Finish") ? color : Color.white);
		if (_fading > 0f)
		{
			_fading -= Time.deltaTime * FadeSpeed;
			CGroup.alpha = _fading;
			if (_fading <= 0f)
			{
				Window.Close();
			}
		}
		else if (CurrentTutorial != null && CurrentMessage < CurrentTutorial.Length)
		{
			TutorialMessage tutorialMessage = CurrentTutorial[CurrentMessage];
			if (!ManualContinue(tutorialMessage) && tutorialMessage.CanContinue())
			{
				AdvanceTutorial(true, false);
			}
		}
	}

	private void AddRings()
	{
		if (CurrentMessage < CurrentTutorial.Length)
		{
			AddRing(Window.rectTransform.anchoredPosition + new Vector2(Window.rectTransform.sizeDelta.x / 2f, (0f - Window.rectTransform.sizeDelta.y) / 2f), 512);
		}
	}

	public void AddRing(Vector2 p, int size = 256, bool above = false)
	{
		GameObject obj = UnityEngine.Object.Instantiate(RingPrefab);
		obj.transform.SetParent(above ? WindowManager.Instance.Canvas.transform : WindowManager.Instance.MainPanel.transform, false);
		RingScript component = obj.GetComponent<RingScript>();
		component.rect.anchoredPosition = p;
		component.size = size;
	}

	public static void ExportTutLoc()
	{
		Dictionary<string, TutorialMessage[]> dictionary = new Dictionary<string, TutorialMessage[]>();
		LoadTutorialFiles(dictionary);
		TydNode[] children = dictionary.SelectMany((KeyValuePair<string, TutorialMessage[]> x) => x.Value.WhereSelect((TutorialMessage y) => x.Key.Equals("Shared") || !y.Shared, (TutorialMessage y) => new TydString(y.Message, y.NonLoc))).ToArray();
		File.WriteAllText("Assets/Resources/Localization/English/Tutorial.tyd", TydToText.Write(new TydTable("Tutorial", children), true, 0, 0, true), Encoding.UTF8);
	}
}

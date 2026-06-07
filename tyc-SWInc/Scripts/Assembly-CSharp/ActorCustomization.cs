using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Achievements;
using DG.Tweening;
using DevConsole;
using MadGoat_SSAA;
using SINetworking;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CinematicEffects;
using UnityStandardAssets.ImageEffects;

public class ActorCustomization : MonoBehaviour, IStylable, ISpecController
{
	private const float FaceEditThreshold = 0.8f;

	public static ActorBodyItem.BlendTransform[] FetchedTranslations = null;

	public Image[] Colors;

	public Text GenderText;

	public Text DaysPerMonthLabel;

	public VarValueSheet MoneyDesc;

	public InputField CompanyName;

	public InputField FounderName;

	public static float[] RoundLimits = new float[7]
	{
		float.PositiveInfinity,
		5f,
		10f,
		15f,
		20f,
		25f,
		30f
	};

	public static int[] StartLoans = new int[4] { 0, 10000, 40000, 90000 };

	public static int StartLoanMonths = 60;

	public static int[] StartYears = new int[4] { 1980, 1990, 2000, 2010 };

	public FounderManager FManager;

	public GUICombobox Difficulty;

	public GUICombobox Year;

	public GUICombobox Animation;

	public GUICombobox[] PersonalityChosen;

	public Slider[] Skill;

	public Slider StartMoney;

	public Slider DaysPerMonth;

	public Transform[] CameraPositions;

	public int CurrentCameraPosition;

	public Transform MainCamera;

	public ActorBodyItemToggle ThumbnailButtonPrefab;

	public GameObject ButtonPrefab;

	public GameObject IPOLabel;

	public GameObject PlotAdjecencyLabel;

	public GameObject RoundLimitLabel;

	public GameObject RoundTypeLabel;

	public GameObject FurnModsLabel;

	public GameObject CodeModsLabel;

	public GameObject FounderStylePanel;

	public GameObject FounderSkillPanel;

	public Slider IPOSlider;

	public Slider AgeSlider;

	public GUICombobox RoundLimit;

	public GUICombobox RoundType;

	public Toggle PlotAdjacency;

	public Toggle FurnMods;

	public Toggle CodeMods;

	public Text IPOSliderLabel;

	public Text AgeLabel;

	public BodySliderGroup BodyGroupPrefab;

	public GameObject BodyPartPanel;

	public GameObject HeadSliderPanel;

	public GameObject ColorPanel;

	public Transform BodyPartContent;

	public Transform HeadSliderContent;

	public Transform ColorContent;

	public Transform TraitPanel;

	public Scrollbar BodyPartScroll;

	public Scrollbar HeadSliderScroll;

	public Scrollbar ColorScroll;

	public SpecializationChart SpecChart;

	public UITrait TraitPrefab;

	public Material TriangleHighlight;

	public RectTransform DiffTipHolder;

	public RectTransform FounderPanel;

	public ColorWindow ColorDialog;

	public Text DifficultyTip;

	public Toggle UnlockBlends;

	public Toggle LODToggle;

	public Image[] BlendIcons;

	public float DiffTipWidth;

	public float DiffTipHeight;

	public GameObject[] DisableOnCampaign;

	public GameObject[] DisableOnNetwork;

	public GameObject[] DisableOnNetworkClient;

	public GameObject[] DisableOnRestartCompany;

	public Text StartLabel;

	public ActorPatternPanel PatternPanel;

	public DynamicGridLayout GameConfLayout;

	private Dictionary<string, Color> _colorsUsed = new Dictionary<string, Color>();

	[NonSerialized]
	private DifficultyValues.DifficultySetting _customDifficulty;

	[NonSerialized]
	private Employee _forcedFounder;

	public Image[] Tabs;

	public Color ActiveTabColor;

	public GUIListView ModList;

	public SSAOPro SSAO;

	public BloomOptimized bloom;

	public Antialiasing FXAA;

	public AntiAliasing SMAA;

	public GammaSaturation GSat;

	public MadGoatSSAA SSAAScript;

	public Light[] lights;

	public Transform HeadBone;

	public bool Female;

	public int CurrentCategory;

	public Color[] SkinColors;

	public Color[] HairColors;

	public GameObject FinalActor;

	public GameObject LoadingPanel;

	public Text LoadingPanelLabel;

	public Texture2D[] MaleEyes;

	public Texture2D[] FemaleEyes;

	public Texture2D ColorMap;

	public Texture2D LightMap;

	public Sprite MaleVoid;

	public Sprite FemaleVoid;

	private float drag;

	private bool dragNow;

	private bool DisableStat;

	private bool DisablePerson;

	public static ActorCustomization Instance;

	public Animator Anim;

	public int PersonalityCounter;

	public float CurrentZoom;

	public float TargetZoom;

	public EyeScript Eyes;

	private float RandomAnim;

	public Slider CreativitySlider;

	public Text CreativityLabel;

	public Transform DemandPanel;

	public RectTransform[] SkillCap;

	public GUICombobox LeadFocus;

	public GameObject LeadFocusLabel;

	public RawImage LogoImage;

	[NonSerialized]
	public SDFCreator.ISDFNode Logo;

	[NonSerialized]
	public Dictionary<string, List<SDFCreator.SDFParameterExport>> LogoParameters;

	private RenderTexture LogoTexture;

	public GameObject SkinTonePanel;

	public Slider SkinToneSlider;

	public SkinToneGraph SkinToneGraph;

	private bool _isMorphDragging;

	[NonSerialized]
	private ActorBodyItem.BlendKeys[] _currentMorphDrag;

	private Vector3[] _morphStart;

	private Vector3[] _morphEnd;

	[NonSerialized]
	private bool _faceMeshDirty = true;

	private List<int> _faceTriangles = new List<int>();

	private List<Vector3> _faceVertices = new List<Vector3>();

	public bool SliderHover;

	private static float[] _creativityRanges = new float[3] { 0.5f, 0.75f, 0.95f };

	private static LeadDesignDemands.Demand[][] _demands = new LeadDesignDemands.Demand[3][]
	{
		new LeadDesignDemands.Demand[0],
		new LeadDesignDemands.Demand[2]
		{
			LeadDesignDemands.Demand.PrivateOffice,
			LeadDesignDemands.Demand.Royalties
		},
		new LeadDesignDemands.Demand[3]
		{
			LeadDesignDemands.Demand.PrivateOffice,
			LeadDesignDemands.Demand.Royalties,
			LeadDesignDemands.Demand.IPOwnership
		}
	};

	[NonSerialized]
	private List<ActorBodyItem> _bodyItems = new List<ActorBodyItem>();

	[SerializeField]
	private Transform _rootBone;

	[NonSerialized]
	private ActorBodyItem _watch;

	public GridLayoutGroup BodyItemLayout;

	public Button MainColorButton;

	public GUIToolTipper MainColorTip;

	public Image MainColorImage;

	[NonSerialized]
	private List<ActorBodyItemToggle> BodyButtons = new List<ActorBodyItemToggle>();

	[NonSerialized]
	private Dictionary<Employee.Trait, UITrait> _traitToggles = new Dictionary<Employee.Trait, UITrait>();

	public static List<Employee.Trait> TraitPriority = new List<Employee.Trait>
	{
		Employee.Trait.ThisIsFine,
		Employee.Trait.Watch,
		Employee.Trait.SilentButDeadly,
		Employee.Trait.Clean,
		Employee.Trait.FastLearner,
		Employee.Trait.Capacitor,
		Employee.Trait.RGBThumb,
		Employee.Trait.Sunshine,
		Employee.Trait.Skyscraper,
		Employee.Trait.BigBrain,
		Employee.Trait.FriendMaker,
		Employee.Trait.BornLeader,
		Employee.Trait.FirmwareInc,
		Employee.Trait.Detached,
		Employee.Trait.BumLeg,
		Employee.Trait.UnderTheWeather,
		Employee.Trait.WalkInstead,
		Employee.Trait.NeatFreak,
		Employee.Trait.SuperFocus,
		Employee.Trait.Claustrophobic,
		Employee.Trait.Forgetful,
		Employee.Trait.Cupholder
	};

	[NonSerialized]
	private HashSet<Employee.Trait> _dummyTraits = new HashSet<Employee.Trait>();

	[NonSerialized]
	private Employee.Trait _forcedTraits;

	private bool _disableSkinUpdate;

	[NonSerialized]
	private Dictionary<string, string> SliderToGroup = new Dictionary<string, string>();

	[NonSerialized]
	private Dictionary<string, BodySliderGroup> SliderGroups = new Dictionary<string, BodySliderGroup>();

	private bool _directSliderChange = true;

	private bool _styleDirty;

	public Image TransitionImage;

	public GUIToolTipper DaysPerMonthsKnob;

	private string defaultCompanyName;

	private Tweener _diffTween;

	[NonSerialized]
	private bool _initializing;

	public bool UsingSkinColor;

	public GameObject[] DeactivateDuringColor;

	[NonSerialized]
	private bool _founderLoading;

	private static readonly List<RaycastResult> CastResult = new List<RaycastResult>();

	private float _changeArms = -1f;

	[NonSerialized]
	public Color SkinColor;

	private bool _isSettingName;

	public string UseStyle = "Default";

	private static readonly float[] CampaignSkills = new float[5] { 0.25f, 0.63f, 0.63f, 0.63f, 0.36f };

	private static readonly Dictionary<string, int>[] CampaignSpecs = new Dictionary<string, int>[5]
	{
		new Dictionary<string, int>
		{
			{ "HR", 3 },
			{ "Socialization", 3 },
			{ "Multitasking", 3 }
		},
		new Dictionary<string, int>
		{
			{ "System", 2 },
			{ "2D", 2 },
			{ "Audio", 2 },
			{ "3D", 2 },
			{ "Network", 1 }
		},
		new Dictionary<string, int>
		{
			{ "System", 2 },
			{ "2D", 2 },
			{ "Audio", 2 },
			{ "3D", 2 },
			{ "Network", 1 }
		},
		new Dictionary<string, int>
		{
			{ "2D", 2 },
			{ "Audio", 1 },
			{ "3D", 1 }
		},
		new Dictionary<string, int>
		{
			{ "Support", 1 },
			{ "Marketing", 2 },
			{ "Accounting", 1 }
		}
	};

	private bool _waitingForHost;

	public bool AdvancedMode;

	public RectTransform SpecTrans;

	public RectTransform CreaTrans;

	public RectTransform AdvancedTrans;

	public Image SkillHeader;

	public int StartYear
	{
		get
		{
			return GetStartYear() - 1900;
		}
	}

	public List<ActorBodyItem> BodyItems
	{
		get
		{
			return _bodyItems;
		}
		set
		{
			_bodyItems = value;
		}
	}

	public Transform RootBone
	{
		get
		{
			return _rootBone;
		}
		set
		{
			_rootBone = value;
		}
	}

	public Dictionary<string, Transform> Rig { get; set; }

	public bool UsesLOD1
	{
		get
		{
			return false;
		}
	}

	public bool NeedsDestruction
	{
		get
		{
			return true;
		}
	}

	private HashSet<Employee.Trait> _activeTraits
	{
		get
		{
			FounderManager.FounderDescriptor selFounder = FManager.SelFounder;
			return ((selFounder != null) ? selFounder.Traits : null) ?? _dummyTraits;
		}
	}

	public GameObject[] GetShouldDisable()
	{
		if (GameData.CampaignMode || (GameData.RestartCompany && GameData.RestartCompletedMissions != null && GameData.RestartCompletedMissions.Count > 0))
		{
			return DisableOnCampaign;
		}
		if (GameData.MultiplayerMode)
		{
			if (!NetworkManager.IsClient)
			{
				return DisableOnNetwork;
			}
			return DisableOnNetworkClient;
		}
		if (GameData.RestartCompany)
		{
			return DisableOnRestartCompany;
		}
		return Array.Empty<GameObject>();
	}

	public void UpdateCreativity()
	{
		int num = Mathf.RoundToInt(CreativitySlider.value);
		CreativityLabel.text = SoftwareType.GetCreativityLabel(_creativityRanges[num], false);
		Utilities.InitializeDemands(_demands[num], DemandPanel, LeadDesignDemands.Demand.Fire);
		float maxSkill = GetMaxSkill(num);
		for (int i = 0; i < SkillCap.Length; i++)
		{
			SkillCap[i].gameObject.SetActive(num > 0);
			SkillCap[i].offsetMin = new Vector2(maxSkill * SkillCap[i].parent.GetComponent<RectTransform>().rect.width, 0f);
		}
		if (!_initializing && !_founderLoading)
		{
			FManager.SelFounder.Creativity = _creativityRanges[num];
			ScaleSkillStats();
		}
		LeadFocus.gameObject.SetActive(CreativitySlider.value > 0f);
		LeadFocusLabel.SetActive(CreativitySlider.value > 0f);
	}

	public Transform GetTransform()
	{
		return base.transform;
	}

	public void SetMainColor(string type, UnityAction coloring)
	{
		if (type == null)
		{
			MainColorButton.gameObject.SetActive(false);
			RectOffset padding = BodyItemLayout.padding;
			padding.top = 8;
			BodyItemLayout.padding = padding;
			return;
		}
		MainColorButton.gameObject.SetActive(true);
		MainColorTip.ToolTipValue = type;
		MainColorButton.onClick.RemoveAllListeners();
		MainColorButton.onClick.AddListener(coloring);
		RectOffset padding2 = BodyItemLayout.padding;
		padding2.top = 48;
		BodyItemLayout.padding = padding2;
		UpdateColorButtonColor();
	}

	public void UpdateColorButtonColor()
	{
		if (CurrentCategory == 1)
		{
			MainColorImage.color = GetEyebrowColor();
		}
		else if (CurrentCategory == 2)
		{
			MainColorImage.color = SkinColor;
		}
	}

	public void SetSkinColor()
	{
		Color skinColor = SkinColor;
		HashSet<Color> hashSet = new HashSet<Color>();
		hashSet.Add(skinColor);
		SkinTonePanel.SetActive(true);
		SetSkinTone(BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head).SkinToneIndex);
		foreach (ActorBodyItem bodyItem in BodyItems)
		{
			ActorBodyItem.ColorMapping[] colormap = bodyItem.Colormap;
			foreach (ActorBodyItem.ColorMapping colorMapping in colormap)
			{
				if ("Skin".Equals(colorMapping.LogicalCategory))
				{
					hashSet.Add(bodyItem.GetColorFromSlot(colorMapping.MaterialSlot));
				}
			}
		}
		UsingSkinColor = BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head).SkinToneIndex > 0;
		ShowColorDialog(delegate(Color x)
		{
			SetSkinColor(x, 0);
			MainColorImage.color = x;
			UpdateActiveThumb();
			SaveActiveStyle();
		}, skinColor, hashSet);
	}

	private Color GetEyebrowColor()
	{
		return BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head).GetColor("Hair");
	}

	public void SetEyebrowColor()
	{
		Color eyebrowColor = GetEyebrowColor();
		HashSet<Color> hashSet = new HashSet<Color>();
		hashSet.Add(eyebrowColor);
		SkinTonePanel.SetActive(false);
		foreach (ActorBodyItem bodyItem in BodyItems)
		{
			ActorBodyItem.ColorMapping[] colormap = bodyItem.Colormap;
			foreach (ActorBodyItem.ColorMapping colorMapping in colormap)
			{
				if ("Hair".Equals(colorMapping.LogicalCategory))
				{
					hashSet.Add(bodyItem.GetColorFromSlot(colorMapping.MaterialSlot));
				}
			}
		}
		ShowColorDialog(delegate(Color x)
		{
			ActorBodyItem actorBodyItem = BodyItems.First((ActorBodyItem z) => z.Type == ActorBodyItem.BodyType.Head);
			ActorBodyItem.ColorMapping mapFromColor = actorBodyItem.GetMapFromColor("Hair");
			try
			{
				actorBodyItem.SetColorDirect(mapFromColor.MaterialSlot, x);
			}
			catch (Exception ex)
			{
				Debug.LogException(new Exception("Error changing color for " + base.name + ":\n" + ex.ToString()));
			}
			SetColor(mapFromColor.Mapping, x);
			MainColorImage.color = x;
			UpdateActiveThumb();
			SaveActiveStyle();
		}, eyebrowColor, hashSet);
	}

	public void ChangeCategory(int cat)
	{
		CurrentCategory = cat;
		for (int i = 0; i < Tabs.Length; i++)
		{
			Tabs[i].color = ((cat == i) ? ActiveTabColor : Color.white);
		}
		if (cat == 2)
		{
			SetMainColor("Skin", SetSkinColor);
		}
		else
		{
			SetMainColor(null, null);
		}
		switch (cat)
		{
		case 0:
			HeadSliderPanel.SetActive(true);
			BodyPartPanel.SetActive(false);
			ColorPanel.SetActive(false);
			HeadSliderScroll.value = 1f;
			break;
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
			HeadSliderPanel.SetActive(false);
			BodyPartPanel.SetActive(true);
			ColorPanel.SetActive(false);
			UpdateBodyParts();
			BodyPartScroll.value = 1f;
			break;
		case 6:
			HeadSliderPanel.SetActive(false);
			BodyPartPanel.SetActive(false);
			ColorPanel.SetActive(true);
			ColorScroll.value = 1f;
			break;
		}
		switch (cat)
		{
		case 1:
			TargetZoom = 0.8f;
			break;
		case 2:
			TargetZoom = 1f;
			break;
		case 3:
		case 4:
			TargetZoom = 0f;
			break;
		}
	}

	private void UpdateBodyButtons()
	{
		BodyButtons.ForEach(delegate(ActorBodyItemToggle x)
		{
			x.Deactivate();
		});
		bool flag = false;
		bool flag2 = false;
		for (int num = 0; num < BodyItems.Count; num++)
		{
			ActorBodyItem item = BodyItems[num];
			if (item.Type != ActorBodyItem.BodyType.Eyebrows && item.Type != ActorBodyItem.BodyType.Head)
			{
				if (item.Type == ActorBodyItem.BodyType.Hair)
				{
					flag = true;
				}
				else if (item.Type == ActorBodyItem.BodyType.Accessory && (item.Category.Equals("Makeup") || item.Category.Equals("Beard")))
				{
					flag2 = true;
				}
				ActorBodyItemToggle actorBodyItemToggle = BodyButtons.FirstOrDefault((ActorBodyItemToggle x) => !x.IsVoid && x.Prefab.Name.Equals(item.Name) && x.Mirror == item.Mirror);
				if (actorBodyItemToggle != null)
				{
					actorBodyItemToggle.Activate(item, true);
				}
			}
		}
		ActorBodyItem.GenderType gender = (Female ? ActorBodyItem.GenderType.Female : ActorBodyItem.GenderType.Male);
		if (!flag)
		{
			BodyButtons.FirstOrDefault((ActorBodyItemToggle x) => x.IsVoid && x.Type == ActorBodyItem.BodyType.Hair && x.Gender == gender).Activate(null, true);
		}
		if (!flag2)
		{
			ActorBodyItemToggle actorBodyItemToggle2 = BodyButtons.FirstOrDefault((ActorBodyItemToggle x) => x.IsVoid && x.Type == ActorBodyItem.BodyType.Accessory && x.Gender == gender);
			if ((object)actorBodyItemToggle2 != null)
			{
				actorBodyItemToggle2.Activate(null, true);
			}
		}
	}

	public void SkinToneChange()
	{
		if (!_disableSkinUpdate)
		{
			SetSkinColor(Color.white, (int)SkinToneSlider.value);
		}
	}

	public void SetSkinTone(int value)
	{
		_disableSkinUpdate = true;
		SkinToneSlider.value = Mathf.Max(1, value);
		_disableSkinUpdate = false;
	}

	public void RandomizeCompanyName()
	{
		CompanyName.text = GameData.GetStaticNameGenerator("Company").GenerateName(Utilities.RNG);
	}

	private void CreateVoidItem(string name, Sprite thumb, ActorBodyItem.GenderType gender, ActorBodyItem.BodyType type, ActorBodyItem.GUICategory category)
	{
		ActorBodyItemToggle button = UnityEngine.Object.Instantiate(ThumbnailButtonPrefab);
		button.Set(thumb, name, gender, type, category);
		button.OnToggled.AddListener(delegate
		{
			if (ColorDialog.Window.Shown)
			{
				ColorDialog.Window.Close();
			}
			PatternPanel.Close();
			for (int i = 0; i < BodyButtons.Count; i++)
			{
				ActorBodyItemToggle actorBodyItemToggle = BodyButtons[i];
				if (!actorBodyItemToggle.IsVoid && button.Match(actorBodyItemToggle.Prefab) && actorBodyItemToggle.ActiveItem != null)
				{
					BodyItems.Remove(actorBodyItemToggle.ActiveItem);
					UnityEngine.Object.Destroy(actorBodyItemToggle.ActiveItem.gameObject);
					actorBodyItemToggle.Deactivate();
				}
			}
			UpdateActiveThumb();
			SaveActiveStyle();
			button.Activate(null, false);
		});
		button.transform.SetParent(BodyPartContent, false);
		button.gameObject.SetActive(false);
		BodyButtons.Add(button);
	}

	private void CreateBodyButton(ActorBodyItem item, bool mirrored)
	{
		ActorBodyItemToggle button = UnityEngine.Object.Instantiate(ThumbnailButtonPrefab);
		button.Set(item, mirrored);
		button.OnToggled.AddListener(delegate
		{
			if (button.ActiveItem == null)
			{
				if (ColorDialog.Window.Shown)
				{
					ColorDialog.Window.Close();
				}
				PatternPanel.Close();
				ActorBodyItem actorBodyItem = ActorGenerator.Instance.SetItem(this, mirrored, item.Key, true, "Default", _colorsUsed);
				if (actorBodyItem.Colormap.Any((ActorBodyItem.ColorMapping x) => x.ColorName.Equals("Skin")))
				{
					ActorBodyItem actorBodyItem2 = BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
					actorBodyItem.SetColor("Skin", actorBodyItem2.GetColor("Skin"));
				}
				SkinnedMeshRenderer skin;
				if (actorBodyItem.Blends != null && actorBodyItem.Blends.Length != 0 && (object)(skin = actorBodyItem.rend as SkinnedMeshRenderer) != null)
				{
					ActorBodyItem actorBodyItem3 = BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
					for (int num = 0; num < actorBodyItem.Blends.Length; num++)
					{
						ActorBodyItem.BlendKeys blendKeys = actorBodyItem.Blends[num];
						float blendValue = actorBodyItem3.GetBlendValue(blendKeys.BlendName);
						blendKeys.SetBlendValue(blendValue, skin, actorBodyItem.LOD1Renderer);
					}
				}
				InitColors(false);
				button.Activate(actorBodyItem, false);
				for (int num2 = 0; num2 < BodyButtons.Count; num2++)
				{
					ActorBodyItemToggle actorBodyItemToggle = BodyButtons[num2];
					if (actorBodyItemToggle != button && actorBodyItemToggle.Match(item))
					{
						actorBodyItemToggle.Deactivate();
					}
				}
				UpdateActiveThumb();
				SaveActiveStyle();
			}
		});
		button.OnUntoggled.AddListener(delegate
		{
			if (button.ActiveItem != null)
			{
				if (ColorDialog.Window.Shown)
				{
					ColorDialog.Window.Close();
				}
				PatternPanel.Close();
				if (button.ActiveItem.CanDeselect)
				{
					BodyItems.Remove(button.ActiveItem);
					UnityEngine.Object.Destroy(button.ActiveItem.gameObject);
				}
				UpdateActiveThumb();
				SaveActiveStyle();
			}
		});
		button.transform.SetParent(BodyPartContent, false);
		button.gameObject.SetActive(false);
		BodyButtons.Add(button);
	}

	private void GenerateBodyButtons()
	{
		CreateVoidItem("Bald", MaleVoid, ActorBodyItem.GenderType.Male, ActorBodyItem.BodyType.Hair, ActorBodyItem.GUICategory.Hair);
		CreateVoidItem("Bald", FemaleVoid, ActorBodyItem.GenderType.Female, ActorBodyItem.BodyType.Hair, ActorBodyItem.GUICategory.Hair);
		CreateVoidItem("None", MaleVoid, ActorBodyItem.GenderType.Male, ActorBodyItem.BodyType.Accessory, ActorBodyItem.GUICategory.Face);
		foreach (ActorBodyItem item in ActorGenerator.Instance.BodyItems.Values.Select((GameObject x) => x.GetComponent<ActorBodyItem>()))
		{
			if (!item.Hidden)
			{
				CreateBodyButton(item, false);
				if (item.CreateMirrorVersion)
				{
					CreateBodyButton(item, true);
				}
			}
		}
	}

	public void ResetSliders()
	{
		foreach (BodySliderGroup value in SliderGroups.Values)
		{
			if (value.gameObject.activeSelf)
			{
				value.ResetSliders();
			}
		}
	}

	private void UpdateSliders(ActorBodyItem item)
	{
		_faceMeshDirty = true;
		_directSliderChange = false;
		if (item.rend != null)
		{
			SliderGroups.Values.ForEachEnum(delegate(BodySliderGroup x)
			{
				x.DeactivateAll();
			});
			Renderer rend = item.rend;
			SkinnedMeshRenderer skinnedMeshRenderer = (((object)rend != null) ? rend.GetComponent<SkinnedMeshRenderer>() : null);
			if (skinnedMeshRenderer != null)
			{
				ActorBodyItem.BlendKeys[] blends = item.Blends;
				foreach (ActorBodyItem.BlendKeys blendKeys in blends)
				{
					if (!blendKeys.hide)
					{
						BodySliderGroup bodySliderGroup = SliderGroups[SliderToGroup[blendKeys.BlendName]];
						bodySliderGroup.Activate(blendKeys.BlendName);
						Slider value = bodySliderGroup.Sliders[blendKeys.BlendName].Value;
						value.maxValue = (UnlockBlends.isOn ? (blendKeys.Extreme * 100f) : 100f);
						if (blendKeys.doubleKey)
						{
							value.minValue = (UnlockBlends.isOn ? (blendKeys.Extreme * -100f) : (-100f));
						}
						else
						{
							value.minValue = (UnlockBlends.isOn ? ((blendKeys.Extreme - 1f) * -100f) : 0f);
						}
						value.value = blendKeys.GetBlendValue(skinnedMeshRenderer);
					}
				}
				SliderGroups.Values.ForEachEnum(delegate(BodySliderGroup x)
				{
					x.gameObject.SetActive(x.AnyActive());
				});
			}
		}
		_directSliderChange = true;
	}

	private Slider GetSlider(string name)
	{
		return SliderGroups[SliderToGroup[name]].Sliders[name].Value;
	}

	public void RandomizeAllBlends()
	{
		foreach (BodySliderGroup value in SliderGroups.Values)
		{
			if (value.gameObject.activeSelf)
			{
				value.Randomize();
			}
		}
	}

	public void UnlockBlendToggle()
	{
		UpdateSliders(BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head));
	}

	private void GenerateSliderCat(ActorBodyItem.BodyType type)
	{
		foreach (GameObject item in ActorGenerator.Instance.BodyItems.Values.Where((GameObject x) => x.GetComponent<ActorBodyItem>().Type == type).ToList())
		{
			ActorBodyItem.BlendKeys[] blends = item.GetComponent<ActorBodyItem>().Blends;
			foreach (ActorBodyItem.BlendKeys blendKeys in blends)
			{
				if (blendKeys.hide || SliderToGroup.ContainsKey(blendKeys.BlendName))
				{
					continue;
				}
				BodySliderGroup value;
				if (!SliderGroups.TryGetValue(blendKeys.GroupName, out value))
				{
					value = UnityEngine.Object.Instantiate(BodyGroupPrefab);
					value.Label.text = blendKeys.GroupName.Loc();
					value.transform.SetParent(HeadSliderContent, false);
					SliderGroups[blendKeys.GroupName] = value;
				}
				Slider slider = value.AddSlider(blendKeys.BlendName, blendKeys.Thumbnail);
				ActorBodyItem.BlendKeys lBlend = blendKeys;
				slider.onValueChanged.AddListener(delegate(float x)
				{
					foreach (ActorBodyItem bodyItem in BodyItems)
					{
						SkinnedMeshRenderer skin;
						if (bodyItem.rend != null && (object)(skin = bodyItem.rend as SkinnedMeshRenderer) != null)
						{
							ActorBodyItem.BlendKeys blendKey = bodyItem.GetBlendKey(lBlend.BlendName);
							if (blendKey != null)
							{
								blendKey.SetBlendValue(x, skin, bodyItem.LOD1Renderer);
							}
						}
					}
					ActorGenerator.ApplyBlendTransforms(this);
					if (!lBlend.GroupName.Equals("Body") && _directSliderChange)
					{
						TargetZoom = 1f;
					}
					_styleDirty = true;
				});
				SliderToGroup[blendKeys.BlendName] = blendKeys.GroupName;
			}
		}
	}

	private void GenerateSliders()
	{
		GenerateSliderCat(ActorBodyItem.BodyType.Head);
	}

	public void SetSkinColor(Color c, int skinIndex)
	{
		UsingSkinColor = skinIndex > 0;
		for (int i = 0; i < BodyItems.Count; i++)
		{
			BodyItems[i].SetColor("Skin", c);
			BodyItems[i].SetSkinTone(skinIndex);
		}
		if (ColorDialog.Window.Shown && skinIndex > 0)
		{
			ColorDialog.SetColorPassive(ActorGenerator.Instance.AllSkinColors[skinIndex]);
		}
		Color skinColor = c * ActorGenerator.Instance.AllSkinColors[skinIndex];
		SkinColor = skinColor;
		UpdateColorButtonColor();
		UpdateActiveThumb();
		SaveActiveStyle();
	}

	private static void ChangeColor(ActorBodyItem item, List<ActorBodyItem.ColorMapping> colorMap, ColorBarButton cb)
	{
		string[] tabs = colorMap.Select((ActorBodyItem.ColorMapping x) => x.ColorName.LocTry()).ToArray();
		string name = item.Name;
		Action<Color>[] actions = ((IEnumerable<ActorBodyItem.ColorMapping>)colorMap).Select((Func<ActorBodyItem.ColorMapping, int, Action<Color>>)((ActorBodyItem.ColorMapping x, int i) => delegate(Color y)
		{
			try
			{
				item.rend.material.SetColor(x.MaterialSlot, y);
			}
			catch (Exception ex)
			{
				Debug.LogException(new Exception("Error changing color for " + name + ":\n" + ex.ToString()));
			}
			cb.colors[i] = y;
			cb.Refresh();
		})).ToArray();
		Color[] startColors = colorMap.Select((ActorBodyItem.ColorMapping x) => item.rend.material.GetColor(x.MaterialSlot)).ToArray();
		HashSet<Color> hashSet = new HashSet<Color>();
		foreach (ActorBodyItem.ColorMapping item2 in colorMap)
		{
			if (string.IsNullOrEmpty(item2.LogicalCategory))
			{
				continue;
			}
			foreach (ActorBodyItem bodyItem in Instance.BodyItems)
			{
				ActorBodyItem.ColorMapping[] colormap = bodyItem.Colormap;
				foreach (ActorBodyItem.ColorMapping colorMapping in colormap)
				{
					if (item2.LogicalCategory.Equals(colorMapping.LogicalCategory))
					{
						hashSet.Add(bodyItem.GetColor(colorMapping.ColorName));
					}
				}
			}
		}
		WindowManager.SpawnColorDialog(tabs, actions, startColors, hashSet);
	}

	private void Awake()
	{
		TransitionImage.color = TransitionImage.color.Alpha(1f);
		TransitionImage.DOColor(TransitionImage.color.Alpha(0f), 0.5f);
	}

	private void UpdateBodyParts()
	{
		for (int i = 0; i < BodyButtons.Count; i++)
		{
			ActorBodyItemToggle actorBodyItemToggle = BodyButtons[i];
			ActorBodyItem.GUICategory gUICategory = (actorBodyItemToggle.IsVoid ? actorBodyItemToggle.Category : actorBodyItemToggle.Prefab.guiCategory);
			actorBodyItemToggle.gameObject.SetActive(GenderMatch(actorBodyItemToggle.IsVoid ? actorBodyItemToggle.Gender : actorBodyItemToggle.Prefab.Gender) && gUICategory == (ActorBodyItem.GUICategory)CurrentCategory);
		}
	}

	private bool GenderMatch(ActorBodyItem.GenderType gender)
	{
		switch (gender)
		{
		case ActorBodyItem.GenderType.Male:
			return !Female;
		case ActorBodyItem.GenderType.Female:
			return Female;
		default:
			return true;
		}
	}

	public void UpdateDifficultyTips()
	{
		DifficultyTip.text = GetDifficulty().Name.Loc().FontBold() + ":\n" + GetDifficulty().GetHintString();
		TextGenerationSettings generationSettings = DifficultyTip.GetGenerationSettings(new Vector2(0f, 0f));
		DiffTipHeight = DifficultyTip.cachedTextGeneratorForLayout.GetPreferredHeight(DifficultyTip.text, generationSettings) / Options.UISize + 12f;
		DiffTipWidth = DifficultyTip.cachedTextGeneratorForLayout.GetPreferredWidth(DifficultyTip.text, generationSettings) / Options.UISize + 8f;
		if (DiffTipHolder.gameObject.activeSelf)
		{
			if (_diffTween != null)
			{
				_diffTween.Kill(true);
			}
			_diffTween = DiffTipHolder.DOSizeDelta(new Vector2(DiffTipWidth, DiffTipHeight), 0.5f, true).OnComplete(delegate
			{
				_diffTween = null;
			});
		}
		else if (_diffTween == null)
		{
			DiffTipHolder.sizeDelta = new Vector2(0f, DiffTipHeight);
		}
	}

	public void ToggleDiffPanel()
	{
		if (_diffTween != null)
		{
			_diffTween.Kill(true);
		}
		if (!DiffTipHolder.gameObject.activeSelf)
		{
			DiffTipHolder.gameObject.SetActive(true);
			_diffTween = DiffTipHolder.DOSizeDelta(new Vector2(DiffTipWidth, DiffTipHeight), 0.5f, true).OnComplete(delegate
			{
				_diffTween = null;
			});
		}
		else
		{
			_diffTween = DiffTipHolder.DOSizeDelta(new Vector2(0f, DiffTipHeight), 0.5f, true).OnComplete(delegate
			{
				DiffTipHolder.gameObject.SetActive(false);
				_diffTween = null;
			});
		}
	}

	public void SetColor(string mapping, Color color)
	{
		if (!mapping.Equals("Skin"))
		{
			_colorsUsed[mapping] = color;
		}
	}

	public Color GetColor(string mapping)
	{
		return _colorsUsed.GetOrDefault(mapping, Color.white);
	}

	public void InitColors(bool clear)
	{
		if (clear)
		{
			_colorsUsed.Clear();
		}
		foreach (ActorBodyItem bodyItem in BodyItems)
		{
			ActorBodyItem.ColorMapping[] colormap = bodyItem.Colormap;
			foreach (ActorBodyItem.ColorMapping colorMapping in colormap)
			{
				SetColor(colorMapping.Mapping, bodyItem.GetColorFromSlot(colorMapping.MaterialSlot));
			}
		}
		UpdateColorButtonColor();
	}

	public void ChangeAnimation()
	{
		Anim.SetActorAnim((Actor.AnimationStates)Animation.Selected);
	}

	public void ApplyColor()
	{
		if (!UsingSkinColor)
		{
			ColorDialog.Apply();
			return;
		}
		ColorDialog.CloseNoEffect();
		GameObject[] deactivateDuringColor = DeactivateDuringColor;
		foreach (GameObject gameObject in deactivateDuringColor)
		{
			if (!GetShouldDisable().Contains(gameObject))
			{
				gameObject.SetActive(true);
			}
		}
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(LogoTexture);
	}

	public void RefreshLogo()
	{
		Logo.Execute(128, LogoTexture, Matrix4x4.identity);
	}

	public void IPOChange()
	{
		IPOSliderLabel.text = (IPOSlider.value / 100f).ToPercent(false);
	}

	private void Start()
	{
		AgeSlider.minValue = Employee.Youngest;
		AgeSlider.maxValue = Employee.RetirementAge - 5;
		PipLight.ForceWhite = false;
		RandomAnim = UnityEngine.Random.Range(5f, 10f);
		Anim.SetFloat("Blend1", 0f);
		Anim.SetFloat("Blend3", 1f);
		AchievementController.Init();
		GameData.LoanAmount = 0;
		LogoParameters = new Dictionary<string, List<SDFCreator.SDFParameterExport>>();
		Logo = SDFCreator.Instance.GetRandomTree("Final").Generate(LogoParameters);
		LogoTexture = new RenderTexture(128, 128, 0, RenderTextureFormat.ARGB32);
		LogoImage.texture = LogoTexture;
		RefreshLogo();
		AdvancedMode = !Options.CustomizationAdvanced;
		ToggleAdvancedMode(true);
		GameObject[] shouldDisable = GetShouldDisable();
		for (int i = 0; i < shouldDisable.Length; i++)
		{
			shouldDisable[i].SetActive(false);
		}
		if (GameData.CampaignMode || GameData.MultiplayerMode)
		{
			StartLabel.text = "Start";
		}
		if (GameData.MultiplayerMode)
		{
			if (GameData.LobbyName != null)
			{
				IPOLabel.SetActive(true);
				IPOSlider.gameObject.SetActive(true);
				PlotAdjacency.gameObject.SetActive(true);
				PlotAdjecencyLabel.gameObject.SetActive(true);
				FurnMods.gameObject.SetActive(true);
				FurnModsLabel.gameObject.SetActive(true);
				CodeMods.gameObject.SetActive(true);
				CodeModsLabel.gameObject.SetActive(true);
				RoundLimit.gameObject.SetActive(true);
				RoundLimitLabel.gameObject.SetActive(true);
				RoundType.gameObject.SetActive(true);
				RoundTypeLabel.gameObject.SetActive(true);
				RoundLimit.UpdateContent(RoundLimits.Select((float x) => (!float.IsInfinity(x)) ? "Minute".LocPlural(Mathf.RoundToInt(x)) : "Unlimited".Loc()));
				RoundType.UpdateContent(Enum.GetValues(typeof(NetworkLobby.RoundLimitType)).OfType<NetworkLobby.RoundLimitType>());
				RoundLimit.Selected = 0;
			}
			else
			{
				GameConfLayout.LastFill = false;
			}
		}
		_initializing = true;
		SkinToneSlider.maxValue = ActorGenerator.Instance.SkinColors - 1;
		SkinToneGraph.SkinColors = ActorGenerator.Instance.SkinColors + 1;
		SpecChart.SpecController = this;
		Instance = this;
		ActorGenerator.Instance.InitShadow(this);
		foreach (Employee.Trait t in Enum.GetValues(typeof(Employee.Trait)).OfType<Employee.Trait>().OrderBy(Employee.TraitOrder))
		{
			if (t == Employee.Trait.None || Employee.Trait.OldSole.HasFlag(t) || !(Employee.Trait.FastLearner | Employee.Trait.BigBrain | Employee.Trait.Capacitor | Employee.Trait.ThisIsFine | Employee.Trait.BornLeader | Employee.Trait.FirmwareInc | Employee.Trait.SuperFocus | Employee.Trait.Detached | Employee.Trait.Stressed | Employee.Trait.BumLeg | Employee.Trait.Forgetful | Employee.Trait.Cupholder | Employee.Trait.NeatFreak | Employee.Trait.SilentButDeadly | Employee.Trait.Watch | Employee.Trait.WalkInstead | Employee.Trait.UnderTheWeather | Employee.Trait.Sunshine | Employee.Trait.Skyscraper | Employee.Trait.RGBThumb | Employee.Trait.FriendMaker | Employee.Trait.Clean | Employee.Trait.Claustrophobic).HasBits(t))
			{
				continue;
			}
			UITrait uITrait = UnityEngine.Object.Instantiate(TraitPrefab);
			uITrait.SetTrait(t);
			uITrait.CanRightClick = false;
			uITrait.OnToggle.AddListener(delegate(UITrait.ToggleState x)
			{
				if (x == UITrait.ToggleState.On)
				{
					_activeTraits.Add(t);
					if (t == Employee.Trait.Watch)
					{
						_watch = ActorGenerator.Instance.SetItem(this, false, "AccessoryWatch");
					}
				}
				else
				{
					_activeTraits.Remove(t);
					if (t == Employee.Trait.Watch)
					{
						_bodyItems.Remove(_watch);
						UnityEngine.Object.Destroy(_watch.gameObject);
					}
				}
				UpdateTraitEnabled();
			});
			uITrait.OnToggleFromDisabled.AddListener(delegate
			{
				TryForceTrait(t);
			});
			uITrait.transform.SetParent(TraitPanel, false);
			_traitToggles[t] = uITrait;
		}
		SSAO.enabled = Options.AmbientOcclusion;
		bloom.enabled = Options.Bloom;
		SSAAScript.multiplier = (float)Options.SSAA / 10f;
		SSAAScript.enabled = Options.SSAA > 10;
		FXAA.enabled = Options.FXAA;
		SMAA.enabled = Options.SMAA;
		GSat.Gamma = Options.Gamma;
		Light[] array = lights;
		for (int num = 0; num < array.Length; num++)
		{
			array[num].shadows = (Options.MoreShadow ? LightShadows.Soft : LightShadows.None);
		}
		string text = (CompanyName.text = CompanyName.text.Loc());
		defaultCompanyName = text;
		Difficulty.UpdateContent(DifficultyValues.Difficulties.Keys);
		Difficulty.SelectedItem = ((SaveGameManager.SaveGames.Count((SaveGame x) => !x.BuildingOnly) > 0) ? "Medium" : "Beginner");
		GenerateSliders();
		GenerateBodyButtons();
		Anim.SetActorAnim(Actor.AnimationStates.Idle);
		ModList.Items = GameData.ModPackages.Cast<object>().ToList();
		StartMoney.maxValue = StartLoans.Length - 1;
		UpdateMoneyDescription();
		Year.UpdateContent(StartYears);
		UpdatePersonalities();
		for (int num2 = 0; num2 < PersonalityChosen.Length; num2++)
		{
			int j = num2;
			PersonalityChosen[num2].OnSelectedChanged.AddListener(delegate
			{
				if (!_founderLoading)
				{
					UpdateIncompatibilities(j);
					UpdateTraits();
					FManager.SelFounder.Personality = PersonalityChosen.SelectInPlace((GUICombobox x) => x.SelectedItemString);
				}
			});
		}
		TutorialSystem.Instance.StartTutorial("Customization");
		UpdateDaysPerMonth();
		Tabs[0].color = ActiveTabColor;
		if (GameData.RestartCompany)
		{
			using (MemoryStream stream = new MemoryStream(GameData.RestartCompanyFounder))
			{
				_forcedFounder = stream.ReadObject<Employee>();
			}
			GameData.RestartCompanyFounder = null;
			FManager.Founders[0] = new FounderManager.FounderDescriptor(_forcedFounder, _forcedFounder.GetAge(new SDateTime(GameData.ActiveYear + 1900)));
		}
		else
		{
			FManager.GenerateInitialFounder(GetMaxSkillSum(20f), PersonalityChosen.SelectInPlace((GUICombobox x) => x.SelectedItemString));
		}
		UpdateLeadFocusCombo();
		LoadFounder(FManager.SelFounder, 0);
		UpdateActiveThumb();
		FManager.RefreshNames();
		_initializing = false;
		FounderPanel.anchoredPosition = new Vector2(Mathf.Min(500f, (float)Screen.width / Options.UISize / 2f - 257f), -46f);
		int num3 = Mathf.RoundToInt(CreativitySlider.value);
		CreativityLabel.text = SoftwareType.GetCreativityLabel(_creativityRanges[num3], false);
	}

	public void OnFocusChange()
	{
		FManager.SelFounder.LeadFocus = LeadFocus.SelectedItemString;
	}

	public void UpdateLeadFocusCombo()
	{
		string bef = null;
		if (LeadFocus.Items != null && LeadFocus.Items.Count > 0)
		{
			bef = LeadFocus.SelectedItemString;
		}
		List<SoftwareType> list = (from x in GameData.AllSoftwareTypes()
			where !x.OneClient
			select x).ToList();
		LeadFocus.UpdateContent(list);
		for (int num = 0; num < FManager.Founders.Length; num++)
		{
			FounderManager.FounderDescriptor f = FManager.Founders[num];
			if (f != null && list.None((SoftwareType x) => x.Name.Equals(f.LeadFocus)))
			{
				f.LeadFocus = "Operating System";
			}
		}
		if (bef != null)
		{
			SoftwareType softwareType = list.FirstOrDefault((SoftwareType x) => x.Name.Equals(bef));
			if (softwareType != null)
			{
				LeadFocus.SelectedItem = softwareType;
			}
		}
	}

	public void ShowColorDialog(Action<Color> action, Color startColor, HashSet<Color> defaults = null)
	{
		PatternPanel.Close();
		ColorDialog.Init(new string[1] { "" }, new Action<Color>[1] { action }, new Color[1] { startColor }, defaults, delegate
		{
			GameObject[] deactivateDuringColor = DeactivateDuringColor;
			foreach (GameObject gameObject in deactivateDuringColor)
			{
				if (!GetShouldDisable().Contains(gameObject))
				{
					gameObject.SetActive(true);
				}
			}
		});
		if (!ColorDialog.Window.Shown)
		{
			ColorDialog.Window.rectTransform.localScale = new Vector3(0f, 1f, 1f);
			ColorDialog.Window.rectTransform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutCubic);
			ColorDialog.Window.Show();
		}
		DeactivateDuringColor.ForEachEnum(delegate(GameObject x)
		{
			x.SetActive(false);
		});
	}

	public void ApplyAge(float age, Color? hairColor)
	{
		float value = ((age >= 50f) ? ((age - 50f) / 10f) : 0f);
		value = Mathf.Clamp01(value);
		ActorBodyItem actorBodyItem = (hairColor.HasValue ? _bodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Hair && x.gameObject.activeSelf) : null);
		if (actorBodyItem != null)
		{
			ActorBodyItem.ColorMapping colorMapping = actorBodyItem.Colormap.FirstOrDefault((ActorBodyItem.ColorMapping x) => x.ColorName.Equals("Hair"));
			if (colorMapping != null)
			{
				actorBodyItem.SetColorDirect(colorMapping.MaterialSlot, Color.Lerp(hairColor.Value, Color.gray, value));
			}
		}
		ActorBodyItem actorBodyItem2 = _bodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head && x.gameObject.activeSelf);
		if (actorBodyItem2 != null)
		{
			actorBodyItem2.rend.material.SetFloat("_Overlay2Factor", value);
			actorBodyItem2.SetBlendValue("Age", ActorGenerator.GetAgeWeight(age) * 100f);
		}
	}

	public void AgeChange()
	{
		AgeLabel.text = ((int)AgeSlider.value).ToString();
		if (!_founderLoading)
		{
			FManager.SelFounder.Age = AgeSlider.value;
			ApplyAge(FManager.SelFounder.Age, null);
			ScaleAllSkillStats();
		}
	}

	public void LoadFounder(FounderManager.FounderDescriptor desc, int idx)
	{
		GameObject[] shouldDisable = GetShouldDisable();
		FounderStylePanel.SetActive(!desc.ReadOnly && !shouldDisable.Contains(FounderStylePanel));
		FounderSkillPanel.SetActive(!desc.ReadOnly && !shouldDisable.Contains(FounderSkillPanel));
		_founderLoading = true;
		Female = desc.Female;
		GenderText.text = (Female ? "Feminine".Loc() : "Masculine".Loc());
		_isSettingName = true;
		FounderName.text = desc.Name;
		_isSettingName = false;
		SpecChart.CustomSpecLevels = desc.Specializations;
		UpdateSpec();
		CreativitySlider.value = GetCreativityIndex(desc.Creativity);
		for (int i = 0; i < Skill.Length; i++)
		{
			Skill[i].value = desc.Skills[i];
		}
		ActorGenerator.Instance.ApplySavedStyle(desc.Style, this);
		ActorBodyItem hair = BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Hair);
		Color? hairColor = null;
		if (hair != null)
		{
			ActorBodyItem.BodyItemObject bodyItemObject = desc.Style.FirstOrDefault((ActorBodyItem.BodyItemObject x) => x.Key.Equals(hair.Key));
			SVector3 value;
			if (bodyItemObject != null && bodyItemObject.Colors.TryGetValue("Hair", out value))
			{
				hairColor = value;
			}
		}
		AgeSlider.value = desc.Age;
		AgeChange();
		ApplyAge(desc.Age, hairColor);
		InitHead();
		InitColors(true);
		UpdateBodyButtons();
		UpdateBodyParts();
		UpdateSliders(BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head));
		if (_activeTraits.Contains(Employee.Trait.Watch))
		{
			_watch = ActorGenerator.Instance.SetItem(this, false, "AccessoryWatch");
		}
		else if (_watch != null)
		{
			_bodyItems.Remove(_watch);
			UnityEngine.Object.Destroy(_watch.gameObject);
		}
		List<string> personalityTraits = GetPersonalities().PersonalityTraits;
		PersonalityChosen[0].UpdateContent(personalityTraits);
		PersonalityChosen[1].UpdateContent(personalityTraits);
		PersonalityChosen[0].SelectedItem = desc.Personality[0];
		PersonalityChosen[1].SelectedItem = desc.Personality[1];
		SoftwareType softwareType = LeadFocus.Items.OfType<SoftwareType>().FirstOrDefault((SoftwareType x) => x.Name.Equals(desc.LeadFocus));
		if (softwareType != null)
		{
			LeadFocus.SelectedItem = softwareType;
		}
		else
		{
			LeadFocus.Selected = 0;
		}
		UpdateIncompatibilities(0);
		UpdateIncompatibilities(1);
		_forcedTraits = GetForcedTraits(desc.Personality, GetPersonalities());
		UpdateTraitsUI();
		_founderLoading = false;
	}

	public void ToggleZoom()
	{
		CurrentCameraPosition = (CurrentCameraPosition + 1) % CameraPositions.Length;
	}

	public static Employee.Trait SelectOptimalTraits(Employee.Trait traits, PersonalityGraph graph)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < 64; i++)
		{
			Employee.Trait trait = (Employee.Trait)(1L << i);
			if (traits.HasBits(trait))
			{
				switch (Employee.TraitOrder(trait))
				{
				case 0:
					num++;
					break;
				case 1:
					num2++;
					break;
				case 2:
					num3++;
					break;
				}
			}
		}
		if ((num != 2 || num3 != 2) && (num != 1 || num3 != 1 || num2 != 1))
		{
			for (int j = 0; j < TraitPriority.Count; j++)
			{
				Employee.Trait trait2 = TraitPriority[j];
				if (traits.HasBits(trait2))
				{
					continue;
				}
				int num4 = Employee.TraitOrder(trait2);
				if ((num4 != 0 || (num != 2 && (num != 1 || num2 != 1))) && (num4 != 1 || (num != 2 && num3 != 2 && num2 != 1)) && (num4 != 2 || (num3 != 2 && (num3 != 1 || num2 != 1))))
				{
					traits |= trait2;
					switch (num4)
					{
					case 0:
						num++;
						break;
					case 1:
						num2++;
						break;
					case 2:
						num3++;
						break;
					}
					if ((num == 2 && num3 == 2) || (num == 1 && num3 == 1 && num2 == 1))
					{
						break;
					}
				}
			}
		}
		return traits;
	}

	public void UpdatePersonalities()
	{
		string[] array = new string[2]
		{
			PersonalityChosen[0].SelectedItemString,
			PersonalityChosen[1].SelectedItemString
		};
		PersonalityGraph personalities = GetPersonalities();
		List<string> personalityTraits = personalities.PersonalityTraits;
		for (int i = 0; i < FManager.Founders.Length; i++)
		{
			if (i == FManager.ActiveFounder)
			{
				continue;
			}
			FounderManager.FounderDescriptor founderDescriptor = FManager.Founders[i];
			if (founderDescriptor == null)
			{
				continue;
			}
			bool flag = true;
			for (int j = 0; j < 2; j++)
			{
				if (!personalityTraits.Contains(founderDescriptor.Personality[j]))
				{
					founderDescriptor.Personality[j] = "";
					founderDescriptor.Personality[j] = personalities.SelectRandom(founderDescriptor.Personality);
					flag = false;
				}
			}
			if (!flag)
			{
				founderDescriptor.SetTraits(SelectOptimalTraits(GetForcedTraits(founderDescriptor.Personality, personalities), personalities));
			}
		}
		PersonalityChosen[0].UpdateContent(personalityTraits);
		PersonalityChosen[1].UpdateContent(personalityTraits);
		for (int k = 0; k < 2; k++)
		{
			string text = array[k] ?? ((k == 0) ? "Optimistic" : "Goofy");
			if (PersonalityChosen[k].Items.Contains(text))
			{
				PersonalityChosen[k].SelectedItem = text;
			}
			else
			{
				PersonalityChosen[k].Selected = 0;
			}
			UpdateIncompatibilities(k);
		}
		UpdateTraits();
	}

	public void UpdateTraitsUI()
	{
		foreach (KeyValuePair<Employee.Trait, UITrait> traitToggle in _traitToggles)
		{
			traitToggle.Value.SetToggle(_activeTraits.Contains(traitToggle.Key) ? UITrait.ToggleState.On : UITrait.ToggleState.None);
		}
		UpdateTraitEnabled();
	}

	private bool CheckValid(Employee.Trait forced)
	{
		for (int i = 0; i < 64; i++)
		{
			Employee.Trait trait = (Employee.Trait)(1L << i);
			if (forced.HasBits(trait) && !_activeTraits.Contains(trait))
			{
				return false;
			}
		}
		return true;
	}

	public static Employee.Trait GetForcedTraits(string[] personality, PersonalityGraph graph)
	{
		Employee.Trait trait = (graph.CombineTraits(personality[0]) | graph.CombineTraits(personality[1])) & (Employee.Trait.FastLearner | Employee.Trait.BigBrain | Employee.Trait.Capacitor | Employee.Trait.ThisIsFine | Employee.Trait.BornLeader | Employee.Trait.FirmwareInc | Employee.Trait.SuperFocus | Employee.Trait.Detached | Employee.Trait.Stressed | Employee.Trait.BumLeg | Employee.Trait.Forgetful | Employee.Trait.Cupholder | Employee.Trait.NeatFreak | Employee.Trait.SilentButDeadly | Employee.Trait.Watch | Employee.Trait.WalkInstead | Employee.Trait.UnderTheWeather | Employee.Trait.Sunshine | Employee.Trait.Skyscraper | Employee.Trait.RGBThumb | Employee.Trait.FriendMaker | Employee.Trait.Clean | Employee.Trait.Claustrophobic);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < 64; i++)
		{
			Employee.Trait trait2 = (Employee.Trait)(1L << i);
			if (!trait.HasBits(trait2))
			{
				continue;
			}
			switch (Employee.TraitOrder(trait2))
			{
			case 0:
				if (num < 2)
				{
					num++;
				}
				else
				{
					trait &= ~trait2;
				}
				break;
			case 1:
				if (num2 == 0)
				{
					num2++;
				}
				else
				{
					trait &= ~trait2;
				}
				break;
			case 2:
				if (num3 < 2)
				{
					num3++;
				}
				else
				{
					trait &= ~trait2;
				}
				break;
			}
		}
		return trait;
	}

	public void TryForceTrait(Employee.Trait tr)
	{
		if (_activeTraits.Contains(tr))
		{
			return;
		}
		int num = Employee.TraitOrder(tr);
		bool flag = false;
		if (num == 1)
		{
			List<Employee.Trait> list = new List<Employee.Trait>();
			int good = 0;
			int bad = 0;
			int neutral = 0;
			int good2 = 0;
			int bad2 = 0;
			int neutral2 = 0;
			foreach (Employee.Trait activeTrait in _activeTraits)
			{
				Employee.IncTraitType(Employee.TraitOrder(activeTrait), ref good2, ref neutral2, ref bad2);
				if (!_forcedTraits.HasBits(activeTrait))
				{
					list.Add(activeTrait);
					Employee.IncTraitType(Employee.TraitOrder(activeTrait), ref good, ref neutral, ref bad);
				}
			}
			if (neutral == 1)
			{
				_activeTraits.Remove(list.First((Employee.Trait x) => (Employee.Trait.NightOwl | Employee.Trait.BornLeader | Employee.Trait.FirmwareInc | Employee.Trait.SuperFocus | Employee.Trait.Unphased | Employee.Trait.JustTheFlu | Employee.Trait.Detached | Employee.Trait.Watch | Employee.Trait.FriendMaker).HasBits(x)));
				_activeTraits.Add(tr);
				flag = true;
			}
			else if (neutral2 == 0 && ((good2 == 2 && good > 0) || good2 < 2) && ((bad2 == 2 && bad > 0) || bad2 < 2))
			{
				if (good2 == 2 && good > 0)
				{
					_activeTraits.Remove(list.First((Employee.Trait x) => (Employee.Trait.FastLearner | Employee.Trait.Independant | Employee.Trait.BigBrain | Employee.Trait.Humble | Employee.Trait.Capacitor | Employee.Trait.WalkItOff | Employee.Trait.ThisIsFine | Employee.Trait.Sunshine | Employee.Trait.Skyscraper | Employee.Trait.RGBThumb | Employee.Trait.Clean).HasBits(x)));
				}
				if (bad2 == 2 && bad > 0)
				{
					_activeTraits.Remove(list.First((Employee.Trait x) => (Employee.Trait.Stressed | Employee.Trait.Hypochondriac | Employee.Trait.SlowEater | Employee.Trait.NervousBladder | Employee.Trait.BumLeg | Employee.Trait.Forgetful | Employee.Trait.Cupholder | Employee.Trait.NeatFreak | Employee.Trait.SilentButDeadly | Employee.Trait.WalkInstead | Employee.Trait.UnderTheWeather | Employee.Trait.Claustrophobic).HasBits(x)));
				}
				_activeTraits.Add(tr);
				flag = true;
			}
		}
		else
		{
			Employee.Trait trait = Employee.Trait.None;
			Employee.Trait trait2 = Employee.Trait.None;
			foreach (Employee.Trait activeTrait2 in _activeTraits)
			{
				if (!_forcedTraits.HasBits(activeTrait2))
				{
					int num2 = Employee.TraitOrder(activeTrait2);
					if (num2 == num)
					{
						trait = activeTrait2;
						break;
					}
					if (num2 == 1)
					{
						trait2 = activeTrait2;
					}
				}
			}
			if (trait == Employee.Trait.None)
			{
				trait = trait2;
			}
			if (trait != Employee.Trait.None)
			{
				_activeTraits.Remove(trait);
				_activeTraits.Add(tr);
				flag = true;
			}
		}
		if (flag)
		{
			UISoundFX.PlaySFX("ToggleClick");
			UpdateTraits();
			UpdateTraitsUI();
		}
	}

	public void UpdateTraits()
	{
		if (_watch != null)
		{
			_bodyItems.Remove(_watch);
			UnityEngine.Object.Destroy(_watch.gameObject);
		}
		PersonalityGraph personalities = GetPersonalities();
		_forcedTraits = GetForcedTraits(PersonalityChosen.SelectInPlace((GUICombobox x) => x.SelectedItemString), personalities);
		if (_activeTraits.Count == 0 || !CheckValid(_forcedTraits))
		{
			_traitToggles.Values.ForEachEnum(delegate(UITrait x)
			{
				x.SetToggle(UITrait.ToggleState.None);
			});
			_activeTraits.Clear();
			foreach (Employee.Trait item in Employee.EnumTraits(SelectOptimalTraits(_forcedTraits, personalities)))
			{
				_traitToggles[item].SetToggle(UITrait.ToggleState.On);
				_activeTraits.Add(item);
			}
		}
		if (_activeTraits.Contains(Employee.Trait.Watch))
		{
			_watch = ActorGenerator.Instance.SetItem(this, false, "AccessoryWatch");
		}
		UpdateTraitEnabled();
	}

	public void UpdateTraitEnabled()
	{
		int good = 0;
		int neutral = 0;
		int bad = 0;
		foreach (Employee.Trait activeTrait in _activeTraits)
		{
			Employee.IncTraitType(Employee.GoodBadNeutral(activeTrait), ref good, ref neutral, ref bad);
		}
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		if (neutral > 0)
		{
			flag2 = false;
			flag = good == 0;
			flag3 = bad == 0;
		}
		else
		{
			if (good > 1 || bad > 1)
			{
				flag2 = false;
			}
			flag = good < 2;
			flag3 = bad < 2;
		}
		foreach (KeyValuePair<Employee.Trait, UITrait> traitToggle in _traitToggles)
		{
			if ((_forcedTraits & traitToggle.Key) != Employee.Trait.None)
			{
				traitToggle.Value.Disabled = true;
				continue;
			}
			if (_activeTraits.Contains(traitToggle.Key))
			{
				traitToggle.Value.Disabled = false;
				continue;
			}
			int num = Employee.GoodBadNeutral(traitToggle.Key);
			traitToggle.Value.Disabled = !(num == 0 && flag) && !(num == 1 && flag2) && !(num == 2 && flag3);
		}
		ScaleSkillStats();
	}

	public void UpdateSpec()
	{
		SpecChart.ResetContent();
	}

	public int GetMaxPoints(Employee.EmployeeRole r, int founder)
	{
		bool forceFull = false;
		FounderManager.FounderDescriptor founderDescriptor = FManager.Founders[founder];
		if (!_initializing && founderDescriptor.Traits.Contains(Employee.Trait.BigBrain))
		{
			if (founderDescriptor.ForcedBrain.HasValue)
			{
				forceFull = r == founderDescriptor.ForcedBrain.Value;
			}
			else
			{
				float num = 0f;
				int num2 = 0;
				for (int i = 0; i < founderDescriptor.Skills.Length; i++)
				{
					if (founderDescriptor.Skills[i] > num)
					{
						num = founderDescriptor.Skills[i];
						num2 = i;
					}
				}
				forceFull = num2 == (int)r;
			}
		}
		return Mathf.RoundToInt((float)GameData.GetMaxSpecPoints(r, forceFull, (founderDescriptor == null) ? AgeSlider.value : founderDescriptor.Age.MapRange(AgeSlider.minValue, AgeSlider.maxValue, 0.5f, 0.8f, true)) * GetDifficulty().MaxSpecPoints);
	}

	public DifficultyValues.DifficultySetting GetDifficulty()
	{
		DifficultyValues.DifficultySetting difficultySetting;
		if (GameData.NetworkSettings == null)
		{
			difficultySetting = _customDifficulty;
			if (difficultySetting == null)
			{
				return DifficultyValues.GetDifficulty(Difficulty.SelectedItemString);
			}
		}
		else
		{
			difficultySetting = GameData.NetworkSettings.Difficulty;
		}
		return difficultySetting;
	}

	public void ChangeGender(bool female)
	{
		Female = female;
		GenderText.text = (Female ? "Feminine".Loc() : "Masculine".Loc());
		FManager.SelFounder.Female = female;
		if (!FManager.SelFounder.HasChangedName)
		{
			_isSettingName = true;
			FounderName.text = GameData.GenerateName(!Female);
			_isSettingName = false;
		}
	}

	private void UpdateIncompatibilities(int i)
	{
		if (DisablePerson)
		{
			return;
		}
		DisablePerson = true;
		object selectedItem = PersonalityChosen[1 - i].SelectedItem;
		PersonalityGraph personalities = GetPersonalities();
		HashSet<string> incompatible = personalities.GetIncompatibilities(PersonalityChosen[i].SelectedItemString);
		List<string> list = personalities.PersonalityTraits.ToList();
		list.RemoveAll((string x) => incompatible.Contains(x));
		PersonalityChosen[1 - i].UpdateContent(list);
		if (PersonalityChosen[1 - i].Items.Contains(selectedItem))
		{
			PersonalityChosen[1 - i].SelectedItem = selectedItem;
		}
		else
		{
			object p2 = PersonalityChosen[i].SelectedItem;
			PersonalityChosen[1 - i].SelectedItem = PersonalityChosen[1 - i].Items.First((object x) => !x.Equals(p2));
		}
		DisablePerson = false;
	}

	private void CacheFaceMeshData()
	{
		if (_faceMeshDirty)
		{
			Mesh mesh = new Mesh();
			(BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head).rend as SkinnedMeshRenderer).BakeMesh(mesh);
			_faceTriangles.Clear();
			_faceVertices.Clear();
			mesh.GetTriangles(_faceTriangles, 0);
			mesh.GetVertices(_faceVertices);
			UnityEngine.Object.Destroy(mesh);
			_faceMeshDirty = false;
		}
	}

	private void Update()
	{
		if (_waitingForHost)
		{
			float receiveMessageProgress = NetworkManager.Instance.GetReceiveMessageProgress(4);
			if (receiveMessageProgress < 0f)
			{
				LoadingPanelLabel.text = "Pleasewait".Loc();
			}
			else
			{
				LoadingPanelLabel.text = "Synchronizing".Loc() + ":\n" + receiveMessageProgress.ToPercent();
			}
			if (GameData.NetworkSaveData != null)
			{
				FrameTransition.StartTransition(true);
				ErrorLogging.FirstOfScene = true;
				ErrorLogging.SceneChanging = true;
				DevConsole.Console.SaveConsole();
				SceneManager.LoadScene("MainScene");
			}
			return;
		}
		if (_styleDirty)
		{
			UpdateActiveThumb();
			SaveActiveStyle();
			_styleDirty = false;
		}
		if (CurrentZoom < 0.8f)
		{
			RandomAnim -= Time.deltaTime;
			if (RandomAnim <= 0f)
			{
				Anim.SetInteger("SubAnim", (Anim.GetInteger("SubAnim") + UnityEngine.Random.Range(1, 4)) % 4);
				Anim.SetTrigger("RandomIdle");
				_changeArms = 0.5f;
				RandomAnim = UnityEngine.Random.Range(10f, 15f);
			}
		}
		if (_changeArms > 0f)
		{
			_changeArms -= Time.deltaTime;
			if (_changeArms <= 0f)
			{
				int num = UnityEngine.Random.Range(0, 2);
				Anim.SetFloat("Blend2", (num == 0) ? 1 : 0);
				Anim.SetFloat("Blend3", (num == 1) ? 1 : 0);
			}
		}
		MainCamera.SetPositionAndRotation(Vector3.Lerp(CameraPositions[0].position, CameraPositions[1].position, CurrentZoom), Quaternion.Lerp(CameraPositions[0].rotation, CameraPositions[1].rotation, CurrentZoom));
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			TargetZoom = Mathf.Clamp01(TargetZoom + Input.mouseScrollDelta.y * 0.1f);
		}
		float currentZoom = CurrentZoom;
		CurrentZoom = Mathf.Lerp(CurrentZoom, TargetZoom, Time.deltaTime * 10f);
		if (currentZoom < 0.8f && CurrentZoom >= 0.8f)
		{
			Anim.Play("Idle", 0, 0f);
			Anim.SetInteger("AnimControl", 0);
			Anim.SetFloat("Blend2", 0f);
			Anim.SetFloat("Blend3", 1f);
			Anim.Update(0f);
		}
		Anim.enabled = CurrentZoom < 0.8f;
		Ray ray = SSAAScript.ScreenPointToRay(Input.mousePosition);
		CastResult.Clear();
		EventSystem.current.RaycastAll(new PointerEventData(EventSystem.current).PopulateDefault(), CastResult);
		bool flag = CastResult.Any((RaycastResult x) => x.gameObject != WindowManager.Instance.BlockPanel);
		ActorBodyItem actorBodyItem = BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
		SkinnedMeshRenderer skinnedMeshRenderer = actorBodyItem.rend as SkinnedMeshRenderer;
		bool flag2 = Physics.RaycastAll(ray, 100f).Any((RaycastHit x) => x.collider.transform == HeadBone);
		string text = null;
		if (!flag && CurrentZoom >= 0.8f && flag2)
		{
			if (!_isMorphDragging)
			{
				CacheFaceMeshData();
				Matrix4x4 mat = Matrix4x4.TRS(skinnedMeshRenderer.transform.position, skinnedMeshRenderer.transform.rotation, Vector3.one);
				Vector3 hit;
				int num2 = Utilities.RaycastTriangle(_faceTriangles, _faceVertices, mat, ray, out hit);
				if (num2 >= 0)
				{
					ActorBodyItem.TriangleBlendHolder triangleBlendHolder = (Female ? ActorGenerator.Instance.FemaleHeadBlendMap : ActorGenerator.Instance.MaleHeadBlendMap)[num2 / 3];
					if (triangleBlendHolder.Blends.Count > 0)
					{
						_currentMorphDrag = new ActorBodyItem.BlendKeys[triangleBlendHolder.Blends.Count];
						_morphStart = new Vector3[triangleBlendHolder.Blends.Count];
						_morphEnd = new Vector3[triangleBlendHolder.Blends.Count];
						int[] array = new int[triangleBlendHolder.Blends.Count];
						Vector4 zero = Vector4.zero;
						int num3 = 0;
						Vector3 to = Vector3.zero;
						bool flag3 = true;
						int num4 = (Input.GetKey(KeyCode.LeftAlt) ? 4 : 2);
						for (int num5 = 0; num5 < triangleBlendHolder.Blends.Count; num5++)
						{
							if (num3 >= num4)
							{
								break;
							}
							ActorBodyItem.TriangleBlend triangleBlend = triangleBlendHolder.Blends[num5];
							string blendName = triangleBlend.BlendName;
							Vector3 vector = mat.MultiplyVector(triangleBlend.Direction);
							if (Vector3.Angle(ray.direction, vector).IsBetween(45f, 135f) && (flag3 || Vector3.Angle(vector, to).IsBetween(45f, 135f)))
							{
								flag3 = false;
								float blendValueNormalized = actorBodyItem.GetBlendValueNormalized(blendName);
								_currentMorphDrag[num3] = actorBodyItem.GetBlendKey(blendName);
								_morphStart[num3] = hit;
								_morphEnd[num3] = hit + vector * 0.05f;
								Vector3 vector2 = _morphEnd[num3] - _morphStart[num3];
								_morphStart[num3] -= vector2 * blendValueNormalized;
								_morphEnd[num3] -= vector2 * blendValueNormalized;
								array[num3] = actorBodyItem.Blends.FindIndex((ActorBodyItem.BlendKeys x) => x.BlendName.Equals(blendName));
								num3++;
								to = vector;
							}
						}
						if (num3 > 2)
						{
							for (int num6 = 2; num6 < 4 && num6 < num3; num6++)
							{
								_currentMorphDrag[num6 - 2] = _currentMorphDrag[num6];
								_morphStart[num6 - 2] = _morphStart[num6];
								_morphEnd[num6 - 2] = _morphEnd[num6];
								array[num6 - 2] = array[num6];
							}
							num3 = 2;
						}
						for (int num7 = 0; num7 < num3; num7++)
						{
							skinnedMeshRenderer.materials[1].SetInt("_TriangleHighlight" + num7, array[num7]);
							zero[num7] = 1f;
						}
						if (num3 > 0)
						{
							skinnedMeshRenderer.materials[1].SetVector("_EnableIndex", zero);
							_currentMorphDrag = _currentMorphDrag.Resize(num3);
							_morphStart = _morphStart.Resize(num3);
							_morphEnd = _morphEnd.Resize(num3);
							BlendIcons[0].sprite = _currentMorphDrag[0].Thumbnail;
							BlendIcons[0].gameObject.SetActive(BlendIcons[0].sprite != null);
							if (_currentMorphDrag.Length == 2)
							{
								BlendIcons[1].sprite = _currentMorphDrag[1].Thumbnail;
								BlendIcons[1].gameObject.SetActive(BlendIcons[1].sprite != null);
								Vector3 vector3 = _morphStart[0] - _morphEnd[0];
								Vector3 vector4 = _morphStart[1] - _morphEnd[1];
								if (Mathf.Abs(vector3.y) > Mathf.Abs(vector4.y))
								{
									_morphEnd[0] = _morphStart[0] - Vector3.up * 0.05f * Mathf.Sign(vector3.y);
									_morphEnd[1] = _morphStart[1] - Vector3.right * 0.05f * Mathf.Sign(vector4.x);
									Sprite sprite = BlendIcons[0].sprite;
									BlendIcons[0].sprite = BlendIcons[1].sprite;
									BlendIcons[1].sprite = sprite;
									BlendIcons[0].gameObject.SetActive(BlendIcons[0].sprite != null);
									BlendIcons[1].gameObject.SetActive(BlendIcons[1].sprite != null);
								}
								else
								{
									_morphEnd[1] = _morphStart[1] - Vector3.up * 0.05f * Mathf.Sign(vector4.y);
									_morphEnd[0] = _morphStart[0] - Vector3.right * 0.05f * Mathf.Sign(vector3.x);
								}
							}
							else
							{
								BlendIcons[1].gameObject.SetActive(false);
							}
							text = "Move";
						}
						else
						{
							BlendIcons[0].gameObject.SetActive(false);
							BlendIcons[1].gameObject.SetActive(false);
							_currentMorphDrag = null;
							_morphStart = null;
							_morphEnd = null;
							skinnedMeshRenderer.materials[1].SetVector("_EnableIndex", Vector4.zero);
						}
					}
				}
				else
				{
					BlendIcons[0].gameObject.SetActive(false);
					BlendIcons[1].gameObject.SetActive(false);
					_currentMorphDrag = null;
					_morphStart = null;
					_morphEnd = null;
					skinnedMeshRenderer.materials[1].SetVector("_EnableIndex", Vector4.zero);
				}
			}
		}
		else if (!_isMorphDragging || CurrentZoom < 0.8f)
		{
			_isMorphDragging = false;
			_currentMorphDrag = null;
			_morphStart = null;
			_morphEnd = null;
			BlendIcons[0].gameObject.SetActive(false);
			BlendIcons[1].gameObject.SetActive(false);
			if (!SliderHover)
			{
				if (flag2 && CurrentZoom < 0.8f)
				{
					skinnedMeshRenderer.materials[1].SetVector("_EnableIndex", new Vector4(0f, 0f, 1f, 0f));
				}
				else
				{
					skinnedMeshRenderer.materials[1].SetVector("_EnableIndex", Vector4.zero);
				}
			}
		}
		if (Input.GetMouseButtonDown(0) && !flag)
		{
			drag = Input.mousePosition.x;
			if (_currentMorphDrag != null)
			{
				_isMorphDragging = true;
				text = "Move";
			}
			else if (flag2 && CurrentZoom < 0.8f)
			{
				TargetZoom = 1f;
			}
			else
			{
				dragNow = true;
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			dragNow = false;
			if (_isMorphDragging)
			{
				skinnedMeshRenderer.materials[1].SetVector("_EnableIndex", Vector4.zero);
				UpdateSliders(actorBodyItem);
			}
			_isMorphDragging = false;
		}
		if (BlendIcons[0].gameObject.activeSelf)
		{
			BlendIcons[0].rectTransform.anchoredPosition = new Vector2(Input.mousePosition.x + 32f, 0f - ((float)Screen.height - Input.mousePosition.y));
		}
		if (BlendIcons[1].gameObject.activeSelf)
		{
			BlendIcons[1].rectTransform.anchoredPosition = new Vector2(Input.mousePosition.x, 0f - ((float)Screen.height - Input.mousePosition.y) + 32f);
		}
		if (_isMorphDragging)
		{
			text = "Move";
			for (int num8 = 0; num8 < _currentMorphDrag.Length; num8++)
			{
				Vector3 vector5 = _morphStart[num8];
				Vector3 vector6 = _morphEnd[num8];
				float magnitude = (vector6 - vector5).magnitude;
				float num9 = Mathf.Clamp01(Utilities.ProjectRayOnRay(t: new Ray(vector5, vector6 - vector5), r: SSAAScript.ScreenPointToRay(Input.mousePosition)) / magnitude);
				ActorBodyItem.BlendKeys blendKeys = _currentMorphDrag[num8];
				float num10 = 0f;
				if (blendKeys.doubleKey)
				{
					num10 = (UnlockBlends.isOn ? blendKeys.Extreme : 1f) * (num9 * 200f - 100f);
					blendKeys.SetBlendValue(num10, skinnedMeshRenderer, actorBodyItem.LOD1Renderer);
				}
				else
				{
					num10 = num9 * (UnlockBlends.isOn ? (blendKeys.Extreme * 100f) : 100f);
					blendKeys.SetBlendValue(num10, skinnedMeshRenderer, actorBodyItem.LOD1Renderer);
				}
				foreach (ActorBodyItem bodyItem in BodyItems)
				{
					SkinnedMeshRenderer skin;
					if (bodyItem != actorBodyItem && bodyItem.rend != null && (object)(skin = bodyItem.rend as SkinnedMeshRenderer) != null)
					{
						ActorBodyItem.BlendKeys blendKey = bodyItem.GetBlendKey(blendKeys.BlendName);
						if (blendKey != null)
						{
							blendKey.SetBlendValue(num10, skin, bodyItem.LOD1Renderer);
						}
					}
				}
				ActorGenerator.ApplyBlendTransforms(this);
			}
		}
		if (flag2 && CurrentZoom < 0.8f && text == null)
		{
			WindowManager.SetCursorOverride("Finger");
		}
		else if (!flag && text == null)
		{
			WindowManager.SetCursorOverride("Rotate");
		}
		else
		{
			WindowManager.SetCursorOverride(text);
		}
		if (dragNow)
		{
			base.transform.rotation = Quaternion.Euler(0f, base.transform.rotation.eulerAngles.y + drag - Input.mousePosition.x, 0f);
			drag = Input.mousePosition.x;
		}
		if (Input.GetKeyUp(KeyCode.Escape) && !WindowManager.HasModal)
		{
			CancelClick();
		}
		Eyes.UpdateMe();
	}

	public void GetAllBlendTranslations(int vertex, ActorBodyItem headbo, Mesh head)
	{
		List<ActorBodyItem.BlendTransform> list = new List<ActorBodyItem.BlendTransform>();
		Vector3[] array = null;
		Vector3 eulerAngle = headbo.rend.transform.localRotation.eulerAngles;
		Quaternion q = Quaternion.Euler(0f, 0f, 90f);
		Matrix4x4 matrix4x = Matrix4x4.Scale(headbo.rend.transform.localScale) * Matrix4x4.Rotate(q);
		ActorBodyItem.BlendKeys[] blends = headbo.Blends;
		foreach (ActorBodyItem.BlendKeys blendKeys in blends)
		{
			array = head.GetBlendVertices(blendKeys.Index, array);
			Vector3 vector = matrix4x.MultiplyVector(array[vertex]);
			if (blendKeys.doubleKey)
			{
				array = head.GetBlendVertices(blendKeys.Index2, array);
				Vector3 vector2 = matrix4x.MultiplyVector(array[vertex]);
				if (vector != Vector3.zero || vector2 != Vector3.zero)
				{
					list.Add(new ActorBodyItem.BlendTransform(blendKeys.BlendName, vector, 1f, vector2, 1f, blendKeys.Reverse));
				}
			}
			else if (vector != Vector3.zero)
			{
				list.Add(new ActorBodyItem.BlendTransform(blendKeys.BlendName, vector, 1f, blendKeys.Reverse));
			}
		}
		FetchedTranslations = list.ToArray();
	}

	public IEnumerable<string> GetPrioritizedSpecs(Employee.EmployeeRole r, string[][] unlocked, IList<SoftwareType> sw)
	{
		switch (r)
		{
		case Employee.EmployeeRole.Programmer:
		case Employee.EmployeeRole.Designer:
		case Employee.EmployeeRole.Artist:
			return unlocked[(int)r].OrderByDescending((string x) => SpecializationChart.SpecDevTime(x, sw));
		case Employee.EmployeeRole.Lead:
			return new string[4] { "HR", "Socialization", "Multitasking", "Automation" };
		case Employee.EmployeeRole.Service:
			return new string[4] { "Support", "Marketing", "Accounting", "Law" };
		default:
			throw new Exception("Tried to get prioritized spec for unknown role: " + r);
		}
	}

	private void OnDrawGizmos()
	{
		if (_currentMorphDrag != null)
		{
			for (int i = 0; i < _currentMorphDrag.Length; i++)
			{
				Vector3 vector = _morphStart[i];
				Vector3 vector2 = _morphEnd[i];
				float magnitude = (vector2 - vector).magnitude;
				float num = Mathf.Clamp01(Utilities.ProjectRayOnRay(t: new Ray(vector, vector2 - vector), r: SSAAScript.ScreenPointToRay(Input.mousePosition)) / magnitude);
				Gizmos.color = Color.red;
				Gizmos.DrawLine(vector, vector2);
				Gizmos.color = Color.cyan;
				Gizmos.DrawSphere(vector + (vector2 - vector) * num, 0.01f);
			}
		}
	}

	public PersonalityGraph GetPersonalities()
	{
		if (!GameData.RestartCompany)
		{
			if (GameData.NetworkSettings == null)
			{
				return GameData.AllPersonalities();
			}
			return GameData.NetworkSettings.Personalities;
		}
		return GameData.RestartCompanyPersonalities;
	}

	public int GetStartYear()
	{
		if (GameData.CampaignMode)
		{
			return 1990;
		}
		if (!GameData.RestartCompany)
		{
			if (GameData.NetworkSettings == null)
			{
				return StartYears.GetClampedIndex(Year.Selected);
			}
			return GameData.NetworkSettings.StartYear;
		}
		return GameData.ActiveYear + 1900;
	}

	public Actor[] GenerateActors()
	{
		PersonalityGraph personalities = GetPersonalities();
		Actor[] array = new Actor[FManager.Founders.Count((FounderManager.FounderDescriptor x) => x != null)];
		for (int num = 0; num < FManager.Founders.Length; num++)
		{
			if (num == 0 && _forcedFounder != null)
			{
				Actor component = UnityEngine.Object.Instantiate(FinalActor).GetComponent<Actor>();
				component.Female = _forcedFounder.Female;
				component.employee = _forcedFounder;
				component.enabled = false;
				UnityEngine.Object.DontDestroyOnLoad(component.gameObject);
				array[num] = component;
				continue;
			}
			FounderManager.FounderDescriptor founderDescriptor = FManager.Founders[num];
			if (founderDescriptor == null)
			{
				break;
			}
			Actor component2 = UnityEngine.Object.Instantiate(FinalActor).GetComponent<Actor>();
			component2.Female = founderDescriptor.Female;
			Employee.Trait trait = Employee.Trait.None;
			foreach (Employee.Trait trait2 in founderDescriptor.Traits)
			{
				trait |= trait2;
			}
			if (!AdvancedMode && !SpecChart.Spent(founderDescriptor.Specializations, num))
			{
				string[][] unlockedSpecializations = GetUnlockedSpecializations();
				List<SoftwareType> sw = GameData.AllSoftwareTypes().ToList();
				for (int num2 = 0; num2 < 5; num2++)
				{
					Employee.EmployeeRole employeeRole = (Employee.EmployeeRole)num2;
					int num3 = Mathf.Min(unlockedSpecializations[num2].Length * 3, GetMaxPoints(employeeRole, num));
					int num4 = founderDescriptor.Specializations[(int)employeeRole].SumSafe((KeyValuePair<string, int> x) => x.Value);
					if (num4 >= num3)
					{
						continue;
					}
					if (employeeRole != Employee.EmployeeRole.Lead)
					{
						foreach (string prioritizedSpec in GetPrioritizedSpecs(employeeRole, unlockedSpecializations, sw))
						{
							int orDefault = founderDescriptor.Specializations[(int)employeeRole].GetOrDefault(prioritizedSpec, 0);
							if (orDefault < 2)
							{
								int num5 = Mathf.Min(2 - orDefault, num3 - num4);
								founderDescriptor.Specializations[(int)employeeRole][prioritizedSpec] = orDefault + num5;
								num4 += num5;
								if (num4 >= num3)
								{
									break;
								}
							}
						}
					}
					foreach (string prioritizedSpec2 in GetPrioritizedSpecs(employeeRole, unlockedSpecializations, sw))
					{
						int orDefault2 = founderDescriptor.Specializations[(int)employeeRole].GetOrDefault(prioritizedSpec2, 0);
						if (orDefault2 < 3)
						{
							int num6 = Mathf.Min(3 - orDefault2, num3 - num4);
							founderDescriptor.Specializations[(int)employeeRole][prioritizedSpec2] = orDefault2 + num6;
							num4 += num6;
							if (num4 >= num3)
							{
								break;
							}
						}
					}
				}
			}
			component2.employee = new Employee(new SDateTime(GetStartYear()), founderDescriptor.Female, founderDescriptor.Name, founderDescriptor.Skills, founderDescriptor.Creativity, founderDescriptor.Personality, trait, founderDescriptor.Specializations, personalities, founderDescriptor.Style, founderDescriptor.Traits.Contains(Employee.Trait.BigBrain) ? founderDescriptor.ForcedBrain : ((Employee.EmployeeRole?)null), (int)founderDescriptor.Age);
			int num7 = ((!GameData.CampaignMode) ? GetCreativityIndex(founderDescriptor.Creativity) : 0);
			component2.employee.SkillCeiling = GetMaxSkill(num7);
			if (num7 > 0)
			{
				component2.employee.LeadSpecPick = founderDescriptor.LeadFocus;
			}
			LeadDesignDemands.Demand[] array2 = _demands[num7];
			for (int num8 = 0; num8 < array2.Length; num8++)
			{
				LeadDesignDemands.DemandChoice choice = LeadDesignDemands.GetChoice(array2[num8]);
				component2.employee.AcceptDemand(choice, choice.GetChoiceIndex(array2[num8]), false);
			}
			component2.enabled = false;
			if (_watch != null)
			{
				BodyItems.Remove(_watch);
			}
			UnityEngine.Object.DontDestroyOnLoad(component2.gameObject);
			array[num] = component2;
		}
		return array;
	}

	public void UpdateEyes()
	{
		ActorBodyItem actorBodyItem = _bodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
		if (actorBodyItem != null)
		{
			Eyes.Face = actorBodyItem.rend.material;
		}
	}

	public void UpdateHairColor(Color col)
	{
	}

	public void UpdateSkinColor(Color col)
	{
		SkinColor = col;
	}

	public void PostUpdate(bool allowHoliday)
	{
	}

	public void ToggleLOD()
	{
		foreach (ActorBodyItem bodyItem in BodyItems)
		{
			if (bodyItem.LOD1Instance != null)
			{
				bodyItem.LOD1Instance.gameObject.SetActive(LODToggle.isOn);
				bodyItem.rend.gameObject.SetActive(!LODToggle.isOn);
			}
		}
	}

	public void SetLOD2Color(string part, Color col)
	{
	}

	public void FounderNameChanged()
	{
		FManager.SelFounder.Name = FounderName.text;
		FManager.RefreshNames();
		FManager.SelFounder.HasChangedName |= !_isSettingName;
	}

	public void UpdateSkillStat(int changed)
	{
		UpdateStat(changed, true);
	}

	public void UpdateSEducationStat(int changed)
	{
		UpdateStat(changed, false);
	}

	private float GetMaxSkill()
	{
		return GetMaxSkill(Mathf.RoundToInt(CreativitySlider.value));
	}

	private float GetMaxSkill(int index)
	{
		if (index != 0)
		{
			return index.MapRange(1f, 2f, 0.5f, 0.25f, true);
		}
		return 1f;
	}

	private int GetCreativityIndex(float creativity)
	{
		if (creativity > _creativityRanges[1])
		{
			return 2;
		}
		if (creativity > _creativityRanges[0])
		{
			return 1;
		}
		return 0;
	}

	private float GetMaxSkill(float creativity)
	{
		return GetMaxSkill(GetCreativityIndex(creativity));
	}

	private float GetMaxSkillSum(float age = -1f)
	{
		return GetDifficulty().MaxSkillPoints * ((age < 0f) ? AgeSlider.value : age).MapRange(AgeSlider.minValue, AgeSlider.maxValue, 1f, 2f, true);
	}

	public void ScaleSkillStats(int changed = -1)
	{
		if (_founderLoading)
		{
			return;
		}
		DisableStat = true;
		float num = Skill.Sum((Slider x) => x.value);
		float maxSkillSum = GetMaxSkillSum();
		for (int num2 = 0; num2 < Skill.Length; num2++)
		{
			Skill[num2].value = Skill[num2].value * (maxSkillSum / num);
		}
		num = Skill.Sum((Slider x) => x.value);
		if (num < maxSkillSum)
		{
			float num3 = maxSkillSum - num;
			for (int num4 = 0; num4 < Skill.Length; num4++)
			{
				float num5 = Mathf.Min(1f - Skill[num4].value, num3);
				if (num5 > 0f)
				{
					Skill[num4].value += num3;
					num3 -= num5;
					if (num3 <= 0f)
					{
						break;
					}
				}
			}
		}
		if (CreativitySlider.value > 0f)
		{
			float maxSkill = GetMaxSkill();
			for (int num6 = 0; num6 < Skill.Length; num6++)
			{
				Skill[num6].value = Mathf.Min(Skill[num6].value, maxSkill);
			}
		}
		if (!_initializing)
		{
			for (int num7 = 0; num7 < Skill.Length; num7++)
			{
				FManager.SelFounder.Skills[num7] = Skill[num7].value;
			}
			if (changed > -1 && _activeTraits.Contains(Employee.Trait.BigBrain) && CreativitySlider.value > 0f)
			{
				float num8 = 0f;
				bool flag = false;
				for (int num9 = 0; num9 < Skill.Length; num9++)
				{
					if (Skill[num9].value > num8)
					{
						flag = false;
						num8 = Skill[num9].value;
					}
					else if (Skill[num9].value == num8 && num8 > 0f)
					{
						flag = true;
					}
				}
				if (flag && Skill[changed].value == num8)
				{
					FManager.SelFounder.ForcedBrain = (Employee.EmployeeRole)changed;
				}
				else
				{
					FManager.SelFounder.ForcedBrain = null;
				}
			}
			else
			{
				FManager.SelFounder.ForcedBrain = null;
			}
		}
		SpecChart.MaintainCounts(SpecChart.CustomSpecLevels, FManager.ActiveFounder);
		DisableStat = false;
	}

	public void ScaleAllSkillStats()
	{
		if (DisableStat || _founderLoading || _initializing)
		{
			return;
		}
		for (int i = 0; i < FManager.Founders.Length; i++)
		{
			FounderManager.FounderDescriptor founderDescriptor = FManager.Founders[i];
			if (founderDescriptor == null)
			{
				break;
			}
			float num = founderDescriptor.Skills.Sum();
			float maxSkillSum = GetMaxSkillSum();
			for (int j = 0; j < founderDescriptor.Skills.Length; j++)
			{
				founderDescriptor.Skills[j] = founderDescriptor.Skills[j] * (maxSkillSum / num);
			}
			num = founderDescriptor.Skills.Sum();
			if (num < maxSkillSum)
			{
				float num2 = maxSkillSum - num;
				for (int k = 0; k < founderDescriptor.Skills.Length; k++)
				{
					float num3 = Mathf.Min(1f - founderDescriptor.Skills[k], num2);
					if (num3 > 0f)
					{
						founderDescriptor.Skills[k] += num2;
						num2 -= num3;
						if (num2 <= 0f)
						{
							break;
						}
					}
				}
			}
			if (founderDescriptor.Creativity > 0.5f)
			{
				float maxSkill = GetMaxSkill(founderDescriptor.Creativity);
				for (int l = 0; l < Skill.Length; l++)
				{
					founderDescriptor.Skills[l] = Mathf.Min(founderDescriptor.Skills[l], maxSkill);
				}
			}
			SpecChart.MaintainCounts(founderDescriptor.Specializations, i);
		}
		DisableStat = true;
		for (int m = 0; m < Skill.Length; m++)
		{
			Skill[m].value = FManager.SelFounder.Skills[m];
		}
		DisableStat = false;
	}

	private void UpdateStat(int changed, bool skills)
	{
		if (DisableStat || _founderLoading)
		{
			return;
		}
		DisableStat = true;
		Slider[] skill = Skill;
		if (CreativitySlider.value > 0f)
		{
			skill[changed].value = Mathf.Min(GetMaxSkill(), skill[changed].value);
		}
		float num = skill.Sum((Slider x) => x.value);
		float num2 = num - skill[changed].value;
		float maxSkillSum = GetMaxSkillSum();
		if (num != maxSkillSum && num2 > 0f)
		{
			float num3 = maxSkillSum - skill[changed].value;
			for (int num4 = 0; num4 < skill.Length; num4++)
			{
				if (num4 != changed)
				{
					skill[num4].value = Mathf.Min(1f, skill[num4].value / num2 * num3);
				}
			}
		}
		float num5 = skill.Sum((Slider x) => x.value);
		if (num5 < maxSkillSum)
		{
			float num6 = maxSkillSum - num5;
			int num7 = skill.Length - 1;
			for (int num8 = 0; num8 < skill.Length; num8++)
			{
				if (num8 != changed)
				{
					float value = skill[num8].value;
					float num9 = num6 / (float)num7;
					skill[num8].value = Mathf.Min(GetMaxSkill(), skill[num8].value + num9);
					num6 -= skill[num8].value - value;
					num7--;
				}
			}
		}
		DisableStat = false;
		if (_activeTraits.Contains(Employee.Trait.BigBrain) || CreativitySlider.value > 0f)
		{
			ScaleSkillStats(skills ? changed : (-1));
		}
		else if (!_initializing)
		{
			for (int num10 = 0; num10 < Skill.Length; num10++)
			{
				FManager.SelFounder.Skills[num10] = Skill[num10].value;
			}
		}
	}

	public void ToggleGender()
	{
		ChangeGender(!Female);
		ActorGenerator.Instance.ApplySavedStyle(ActorGenerator.Instance.GenerateStyle(Female, "Default", 20f), this);
		InitHead();
		InitColors(true);
		UpdateBodyButtons();
		UpdateBodyParts();
		UpdateSliders(BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head));
		if (_activeTraits.Contains(Employee.Trait.Watch))
		{
			_watch = ActorGenerator.Instance.SetItem(this, false, "AccessoryWatch");
		}
		ApplyAge(FManager.SelFounder.Age, null);
	}

	public void InitHead()
	{
		ActorBodyItem actorBodyItem = BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
		Renderer rend = actorBodyItem.rend;
		rend.sharedMaterials = new Material[2]
		{
			rend.sharedMaterials[0],
			new Material(TriangleHighlight)
		};
		rend.materials[1].mainTexture = actorBodyItem.WeightMapTexture;
		rend.materials[1].SetVector("_EnableIndex", Vector4.zero);
	}

	public void UpdateMoneyDescription()
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		double num = GetDifficulty().DefaultStartMoney;
		if (GameData.NetworkData != null)
		{
			num = Math.Max(num, GameData.NetworkData.OldPlayers.GetOrDefault(NetworkManager.LocalPlayerID, 0f));
		}
		if (GameData.RestartCompany)
		{
			num += GameData.RestartCompanyFunds;
		}
		StartMoney.interactable = GetDifficulty().Loans > 0.5f;
		if (StartMoney.value > 0f && GetDifficulty().Loans > 0.5f)
		{
			int num2 = ((GetDifficulty().Loans > 0.5f) ? StartLoans.GetClampedIndex(Mathf.FloorToInt(StartMoney.value)) : 0);
			int num3 = StartLoanMonths;
			double x = num + (double)num2;
			float num4 = (LoanWindow.CalculateInterest(num3, Mathf.FloorToInt((float)num2 / 10000f), 0) * (float)num2 + (float)num2) / (float)num3;
			if (num2 == 0)
			{
				num3 = 0;
			}
			list.AddRange(new string[5]
			{
				"Startingfunds".Loc(),
				"Loan".Loc(),
				"Monthly".Loc(),
				"Deadline".Loc(),
				"Cost".Loc()
			});
			list2.AddRange(new string[5]
			{
				x.Currency(),
				num2.CurrencyInt(),
				num4.Currency(),
				SDateTime.DateDiff(new SDateTime(0, 0, 0), new SDateTime(0, num3, 0)),
				(num4 * (float)num3).Currency()
			});
		}
		else
		{
			list.Add("Startingfunds".Loc());
			list2.Add(num.Currency());
		}
		int num5 = 0;
		for (int i = 0; i < FManager.Founders.Length && FManager.Founders[i] != null; i++)
		{
			num5 = i + 1;
		}
		if (num5 > 1)
		{
			list.Add("SharesIn".Loc());
			list2.Add((1f / (float)num5).ToPercent());
			list.Add("Dividends".Loc());
			list2.Add((((float)num5 - 1f) * GetDifficulty().FounderDividend / (float)num5).ToPercent());
		}
		MoneyDesc.SetData(list.ToArray(), list2.ToArray());
	}

	public void StartGameClick()
	{
		if (string.IsNullOrEmpty(CompanyName.text.Trim()))
		{
			WindowManager.Instance.ShowMessageBox("NoCompanyName".Loc(), true, DialogWindow.DialogType.Error);
		}
		else if (defaultCompanyName != null && defaultCompanyName.Equals(CompanyName.text))
		{
			WindowManager.Instance.ShowMessageBox("CompanyNameWarning".Loc(), true, DialogWindow.DialogType.Warning, CheckTraits);
		}
		else if (GameData.MultiplayerMode && (!NetworkManager.Instance.Layer.FilterName(CompanyName.text) || !NetworkManager.Instance.Layer.FilterName(FManager.Founders[0].Name)))
		{
			WindowManager.Instance.ShowMessageBox("SteamFilterWarning".Loc(), true, DialogWindow.DialogType.Error);
		}
		else
		{
			CheckTraits();
		}
	}

	private void CheckTraits()
	{
		if (!GameData.RestartCompany)
		{
			for (int i = 0; i < FManager.Founders.Length; i++)
			{
				FounderManager.FounderDescriptor founderDescriptor = FManager.Founders[i];
				if (founderDescriptor == null)
				{
					break;
				}
				int bad = 0;
				int neutral = 0;
				int good = 0;
				foreach (Employee.Trait trait in founderDescriptor.Traits)
				{
					Employee.IncTraitType(Employee.GoodBadNeutral(trait), ref good, ref neutral, ref bad);
				}
				if ((bad != 2 || neutral != 0 || good != 2) && (bad != 1 || neutral != 1 || good != 1))
				{
					FManager.SelectFounder(i);
					TutorialSystem.Instance.AddRing(TraitPanel.GetComponent<RectTransform>().ToScreenSpace().center, 256, true);
					WindowManager.Instance.ShowMessageBox("TraitPickWrongError".Loc(), true, DialogWindow.DialogType.Error);
					return;
				}
			}
		}
		CheckSpec();
	}

	private void CheckSpec()
	{
		if (!GameData.CampaignMode && !GameData.RestartCompany && AdvancedMode)
		{
			for (int i = 0; i < FManager.Founders.Length; i++)
			{
				FounderManager.FounderDescriptor founderDescriptor = FManager.Founders[i];
				if (founderDescriptor == null)
				{
					break;
				}
				if (!SpecChart.Spent(founderDescriptor.Specializations, i))
				{
					FManager.SelectFounder(i);
					WindowManager.Instance.ShowMessageBox("MissingSpecPoints".Loc(), true, DialogWindow.DialogType.Warning, StartGame);
					return;
				}
			}
		}
		StartGame();
	}

	public string MakeBobName(string input)
	{
		if (string.IsNullOrWhiteSpace(input))
		{
			return null;
		}
		List<char> list = new List<char>();
		List<int> list2 = new List<int>();
		bool flag = false;
		for (int i = 0; i < input.Length; i++)
		{
			if (Utilities.IsVowel(input[i]))
			{
				list.Add(input[i]);
				list2.Add(i);
			}
			if (input[i] == ' ')
			{
				flag = true;
			}
		}
		list.Shuffle();
		char[] array = input.Select((char x) => x).ToArray();
		for (int num = 0; num < list.Count; num++)
		{
			array[list2[num]] = list[num];
		}
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			bool flag2 = num2 == 0 || array[num2 - 1] == ' ';
			array[num2] = (flag2 ? char.ToUpper(array[num2]) : char.ToLower(array[num2]));
		}
		string text = array.Aggregate("", (string x, char y) => x + y);
		if (!flag)
		{
			text = "MalePreFix".Loc(text);
		}
		return text;
	}

	private void StartGame()
	{
		GameData.ForcedIPO = null;
		if (GameData.MultiplayerMode)
		{
			int loanAmount = ((GetDifficulty().Loans > 0.5f) ? StartLoans.GetClampedIndex(Mathf.FloorToInt(StartMoney.value)) : 0);
			LoadingPanel.SetActive(true);
			Camera.main.Render();
			GameData.CompanyName = CompanyName.text.StripRichTags();
			GameData.StartingMoney = GetDifficulty().DefaultStartMoney;
			if (GameData.NetworkData != null)
			{
				GameData.StartingMoney = Math.Max(GameData.StartingMoney, GameData.NetworkData.OldPlayers.GetOrDefault(NetworkManager.LocalPlayerID, 0f));
			}
			GameData.LoanAmount = loanAmount;
			GameData.CompanyLogo = SDFCreator.SerializeTree(Logo);
			GameData.EditMode = false;
			GameData.CampaignMode = false;
			GameData.Founders = GenerateActors();
			if (GameData.LobbyName != null)
			{
				GameData.SelectedDifficulty = GetDifficulty();
				GameData.ActiveYear = StartYear;
				GameData.ForcedIPO = ((IPOSlider.value > 0f) ? new float?(IPOSlider.value / 100f) : ((float?)null));
				GameData.RoundLimit = RoundLimits[RoundLimit.Selected] * 60f;
				GameData.RoundType = (NetworkLobby.RoundLimitType)RoundType.SelectedItem;
				GameData.PlotAdjacency = PlotAdjacency.isOn;
				GameData.NetworkAllowCodeMods = CodeMods.isOn;
				GameData.NetworkAllowFurnitureMods = FurnMods.isOn;
				if (!CodeMods.isOn)
				{
					ModController.Instance.UnloadAllMods();
				}
				GameSettings.DaysPerMonth = (int)DaysPerMonth.value;
				FrameTransition.StartTransition(true);
				ErrorLogging.FirstOfScene = true;
				ErrorLogging.SceneChanging = true;
				DevConsole.Console.SaveConsole();
				SceneManager.LoadScene("MainScene");
			}
			else
			{
				NetworkMessaging.SendPlayerCompany(NetworkManager.LocalPlayerID, 0u, GameData.CompanyName, GameData.StartingMoney, GameData.CompanyLogo, NetworkMessaging.MessageTarget.Host, 0);
				NetworkMessaging.SendControlStatement(NetworkMessaging.ControlType.ReadyForPlay, NetworkMessaging.MessageTarget.Host, 0);
				_waitingForHost = true;
			}
			GameData.NetworkSettings = null;
			return;
		}
		if (GameData.CampaignMode)
		{
			WindowManager.SpawnInputDialog("NameAFood".Loc(), "", "", delegate(string x)
			{
				LoadingPanel.SetActive(true);
				Camera.main.Render();
				GameData.SelectedDifficulty = DifficultyValues.GetDifficulty("Beginner");
				GameData.CompanyName = CompanyName.text;
				GameData.StartingMoney = 25000.0;
				GameData.ActiveYear = StartYear;
				GameData.LoanAmount = 0;
				GameData.CompanyLogo = SDFCreator.SerializeTree(Logo);
				GameData.EditMode = false;
				GameData.BobName = MakeBobName(x);
				GameSettings.DaysPerMonth = 1;
				FounderManager.FounderDescriptor obj = FManager.Founders[0];
				obj.Skills = CampaignSkills;
				obj.Specializations = CampaignSpecs;
				obj.Creativity = 0.99f;
				GameData.Founders = GenerateActors();
				FrameTransition.StartTransition(true);
				GameData.LoadYear = 1990;
				GameData.DoCampaignInit = true;
				SaveGameManager.LoadGame(SaveGame.LoadGame("Campaign/ParentsGarage", true, false, true), null, default(SDateTime), false, false, true, false);
			});
			return;
		}
		SaveGameManager.Instance.Show(false, false, true, true, delegate(SaveGame save)
		{
			int num = ((GetDifficulty().Loans > 0.5f) ? StartLoans.GetClampedIndex(Mathf.FloorToInt(StartMoney.value)) : 0);
			double num2 = (double)GetDifficulty().DefaultStartMoney + (double)num;
			if (GameData.RestartCompany)
			{
				num2 += GameData.RestartCompanyFunds;
			}
			float num3 = 0f;
			if (save != null)
			{
				if (save.GetBuildMeta()[0] == 1f)
				{
					num3 = save.GetBuildMeta()[2];
				}
			}
			else
			{
				num3 = PlotArea.StartPlotPrice;
			}
			if ((double)num3 > num2)
			{
				WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), true, DialogWindow.DialogType.Error);
			}
			else
			{
				LoadingPanel.SetActive(true);
				Camera.main.Render();
				GameData.SelectedDifficulty = GetDifficulty();
				GameData.CompanyName = CompanyName.text;
				GameData.StartingMoney = GetDifficulty().DefaultStartMoney - num3;
				GameData.LoanAmount = num;
				GameData.EditMode = false;
				GameData.CampaignMode = false;
				GameData.CompanyLogo = SDFCreator.SerializeTree(Logo);
				if (GameData.RestartCompany)
				{
					GameData.StartingMoney += GameData.RestartCompanyFunds;
					GameSettings.DaysPerMonth = GameData.DaysPerMonth;
				}
				else
				{
					GameData.ActiveYear = StartYear;
					GameSettings.DaysPerMonth = (int)DaysPerMonth.value;
				}
				GameData.Founders = GenerateActors();
				if (save != null)
				{
					byte[] companyData = GameData.CompanyData;
					SDateTime companyDate = GameData.CompanyDate;
					FrameTransition.StartTransition(true);
					GameData.LoadYear = GetStartYear();
					SaveGameManager.LoadGame(save, null, default(SDateTime), false, false, true, false);
					if (GameData.RestartCompany)
					{
						GameData.CompanyData = companyData;
						GameData.CompanyDate = companyDate;
						GameData.LoadCompanyOnLoad = true;
					}
				}
				else
				{
					FrameTransition.StartTransition(true);
					ErrorLogging.FirstOfScene = true;
					ErrorLogging.SceneChanging = true;
					DevConsole.Console.SaveConsole();
					SceneManager.LoadScene("MainScene");
				}
			}
		});
		SaveGameManager.Instance.BuildingToggle.isOn = true;
	}

	public static float GetDefaultStartMoney()
	{
		if (Instance != null)
		{
			return Instance.GetDifficulty().DefaultStartMoney;
		}
		if (!GameSettings.Instance.IsReferenceNull())
		{
			return DifficultyValues.Difficulty.DefaultStartMoney;
		}
		return GameData.SelectedDifficulty.DefaultStartMoney;
	}

	public void UpdateDaysPerMonth()
	{
		if (!GameData.RestartCompany)
		{
			GameData.DaysPerMonth = (int)DaysPerMonth.value;
			DaysPerMonthLabel.text = "Day".LocPlural(GameData.DaysPerMonth);
		}
	}

	public void CancelClick()
	{
		WindowManager.Instance.ShowMessageBox("CustomizationExitPrompt".Loc(), true, DialogWindow.DialogType.Question, CancelDirectly);
	}

	public void CancelDirectly()
	{
		if (NetworkManager.IsConnected)
		{
			NetworkMessaging.SendDisconnectPlayer(false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			NetworkMessaging.SendAllNow();
			NetworkManager.Instance.CleanUpEverything(true);
		}
		FrameTransition.StartTransition(true);
		ErrorLogging.FirstOfScene = true;
		ErrorLogging.SceneChanging = true;
		GameData.CampaignMode = false;
		GameData.NetworkData = null;
		if (GameData.RestartCompany)
		{
			GameData.CompanyData = null;
			GameData.LoadCompanyOnLoad = false;
		}
		GameData.RestartCompany = false;
		GameData.ResetLobbyData();
		DevConsole.Console.SaveConsole();
		SceneManager.LoadScene("MainMenu");
	}

	public void PickStyle()
	{
		List<KeyValuePair<string, CustomActor>> styles = GameData.SavedStyles.ToList();
		WindowManager.Instance.MultiWindow.Show("Style", styles.Select((KeyValuePair<string, CustomActor> x) => x.Key), delegate(int i)
		{
			CustomActor value = styles[i].Value;
			ActorGenerator.Instance.ApplySavedStyle(value.BodyItems, this);
			InitHead();
			ChangeGender(value.Female);
			UpdateBodyParts();
			UpdateBodyButtons();
			InitColors(true);
			UpdateSliders(BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head));
			if (_activeTraits.Contains(Employee.Trait.Watch))
			{
				_watch = ActorGenerator.Instance.SetItem(this, false, "AccessoryWatch");
			}
			_isSettingName = true;
			FounderName.text = styles[i].Key;
			_isSettingName = false;
			_founderLoading = true;
			if (value.Skills != null)
			{
				for (int num = 0; num < Skill.Length; num++)
				{
					Skill[num].value = value.Skills[num];
				}
			}
			if (value.Specs != null)
			{
				FManager.SelFounder.Specializations = (SpecChart.CustomSpecLevels = value.Specs.SelectInPlace((Dictionary<string, int> x) => x.ToDictionary((KeyValuePair<string, int> z) => z.Key, (KeyValuePair<string, int> z) => z.Value)));
			}
			if (value.Personality != null)
			{
				PersonalityChosen[0].SelectedItem = value.Personality[0];
				PersonalityChosen[1].SelectedItem = value.Personality[1];
			}
			if (value.Traits != null)
			{
				_traitToggles.ForEachEnum(delegate(KeyValuePair<Employee.Trait, UITrait> x)
				{
					x.Value.SetToggle(UITrait.ToggleState.None);
				});
				_activeTraits.Clear();
				Employee.Trait[] traits = value.Traits;
				foreach (Employee.Trait trait in traits)
				{
					UITrait value2;
					if (_traitToggles.TryGetValue(trait, out value2))
					{
						_activeTraits.Add(trait);
						value2.SetToggle(UITrait.ToggleState.On);
					}
				}
			}
			_founderLoading = false;
			UpdatePersonalities();
			ScaleAllSkillStats();
		}, false, true, true, false, delegate(int i)
		{
			GameData.DeleteStyle(styles[i].Key);
		});
	}

	public void SaveStyle()
	{
		GameData.CreateStyle(Utilities.CleanFileName(FounderName.text), Female, (from x in BodyItems
			where !x.Name.Equals("Watch")
			select x.Save()).ToArray(), Skill.SelectInPlace((Slider x) => x.value), SpecChart.CustomSpecLevels, PersonalityChosen.SelectInPlace((GUICombobox x) => x.SelectedItemString), (from x in _traitToggles
			where x.Value.State == UITrait.ToggleState.On
			select x.Key).ToArray());
	}

	public void SaveActiveStyle()
	{
		if (!_initializing)
		{
			FManager.SelFounder.Style = (from x in BodyItems
				where !x.Name.Equals("Watch")
				select x.Save()).ToArray();
		}
	}

	public void UpdateActiveThumb()
	{
		FManager.UpdateFounderThumb(FManager.ActiveFounder);
	}

	public string[][] GetUnlockedSpecializations()
	{
		if (!GameData.RestartCompany)
		{
			if (GameData.NetworkSettings == null)
			{
				return GameData.GetUnlockedSpecializations(StartYear, true);
			}
			return GameData.NetworkSettings.UnlockedSpecs;
		}
		return GameData.RestartCompanySpecs;
	}

	public int GetMaxPoints(Employee.EmployeeRole r)
	{
		return GetMaxPoints(r, FManager.ActiveFounder);
	}

	public void ToggleAdvancedMode(bool instant)
	{
		AdvancedMode = !AdvancedMode;
		if (Options.CustomizationAdvanced != AdvancedMode)
		{
			Options.CustomizationAdvanced = AdvancedMode;
			Options.SaveToFile();
		}
		SkillHeader.sprite = (AdvancedMode ? null : ObjectDatabase.Instance.GetSprite(true, false, false, true));
		if (instant)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(SpecTrans.parent.parent.GetComponent<RectTransform>());
			SpecTrans.localScale = new Vector3(AdvancedMode ? 1 : 0, 1f, 1f);
			CreaTrans.localScale = new Vector3(1f, AdvancedMode ? 1 : 0, 1f);
			SpecTrans.gameObject.SetActive(AdvancedMode);
			CreaTrans.gameObject.SetActive(AdvancedMode);
			AdvancedTrans.anchoredPosition = new Vector2(AdvancedMode ? 0f : (0f - SpecTrans.rect.width - 1f), 0f);
			return;
		}
		UISoundFX.PlaySFX(AdvancedMode ? "SlideIn2" : "SlideOut2");
		CreaTrans.gameObject.SetActive(true);
		SpecTrans.gameObject.SetActive(true);
		SpecTrans.DOScaleX(AdvancedMode ? 1 : 0, 0.5f).SetEase(Ease.OutCubic).OnComplete(delegate
		{
			SpecTrans.gameObject.SetActive(AdvancedMode);
		});
		CreaTrans.DOScaleY(AdvancedMode ? 1 : 0, 0.5f).SetEase(Ease.OutCubic).OnComplete(delegate
		{
			CreaTrans.gameObject.SetActive(AdvancedMode);
		});
		AdvancedTrans.DOAnchorPos(new Vector2(AdvancedMode ? 0f : (0f - SpecTrans.rect.width - 1f), 0f), 0.5f).SetEase(Ease.OutCubic);
	}

	public void SetCustomDifficulty()
	{
		WindowManager.Instance.SpawnDifficultyDialog(GetDifficulty(), delegate(DifficultyValues.DifficultySetting x)
		{
			_customDifficulty = x;
			Difficulty.SelectedItem = x;
			Difficulty.OnSelectedChanged.Invoke();
		}, null);
	}

	public void WaitThenApplyTransform()
	{
		StartCoroutine(WaitApply());
	}

	private IEnumerator WaitApply()
	{
		yield return new WaitForEndOfFrame();
		ActorGenerator.ApplyBlendTransforms(Instance);
	}

	public void ResetCustomDifficulty()
	{
		if (Difficulty.SelectedItem != null)
		{
			_customDifficulty = null;
		}
	}
}

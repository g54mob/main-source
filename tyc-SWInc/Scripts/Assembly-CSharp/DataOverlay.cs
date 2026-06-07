using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DataOverlay : MonoBehaviour
{
	public class ColorCategory
	{
		public string Name;

		public int[] Colors;

		public Color[] ColorDirect;

		public bool Interpolate;

		public int ColorLength
		{
			get
			{
				if (Colors != null)
				{
					return Colors.Length;
				}
				return ColorDirect.Length;
			}
		}

		public ColorCategory(string name, bool interp, params int[] colors)
		{
			Name = name;
			Colors = colors;
			Interpolate = interp;
		}

		public ColorCategory(string name, params int[] colors)
		{
			Name = name;
			Colors = colors;
			Interpolate = true;
		}

		public ColorCategory(string name, bool interp, params Color[] colors)
		{
			Name = name;
			ColorDirect = colors;
			Interpolate = interp;
		}

		public ColorCategory(string name, params Color[] colors)
		{
			Name = name;
			ColorDirect = colors;
			Interpolate = true;
		}

		public IEnumerable<KeyValuePair<Color, bool>> GetColors()
		{
			if (Colors == null)
			{
				return ColorDirect.Select((Color y) => new KeyValuePair<Color, bool>(y, Interpolate));
			}
			return Colors.Select((int y) => new KeyValuePair<Color, bool>(GetColor(y), Interpolate));
		}
	}

	public class ColorCategoryHolder
	{
		public ColorCategory[] Categories;

		public ColorCategoryHolder(params ColorCategory[] cats)
		{
			Categories = cats;
		}
	}

	public class Overlay
	{
		public Func<Room, Color> Func;

		public Func<Actor, Color> AcFunc;

		public Func<Furniture, Color> FFunc;

		public Func<RoadSegment, Color> RFunc;

		public ColorCategoryHolder Categories;

		public Action CustomAction;

		public string CustomActionName;

		public Overlay(ColorCategoryHolder cats, Func<Room, Color> func)
		{
			Func = func;
			Categories = cats;
		}

		public Overlay(ColorCategoryHolder cats, Func<Room, Color> func, Func<Actor, Color> acFunc)
		{
			Func = func;
			AcFunc = acFunc;
			Categories = cats;
		}

		public Overlay(ColorCategoryHolder cats, Func<Actor, Color> acFunc)
		{
			AcFunc = acFunc;
			Categories = cats;
		}

		public Overlay(ColorCategoryHolder cats, Func<Room, Color> func, Func<Furniture, Color> fFunc = null)
		{
			Func = func;
			FFunc = fFunc;
			Categories = cats;
		}

		public Overlay(ColorCategoryHolder cats, Func<Room, Color> func, Func<Furniture, Color> fFunc, Func<Actor, Color> acFunc)
		{
			Func = func;
			AcFunc = acFunc;
			FFunc = fFunc;
			Categories = cats;
		}

		public Overlay(ColorCategoryHolder cats, Func<Furniture, Color> fFunc = null)
		{
			FFunc = fFunc;
			Categories = cats;
		}

		public Overlay(ColorCategoryHolder cats, Func<RoadSegment, Color> rFunc = null)
		{
			RFunc = rFunc;
			Categories = cats;
		}
	}

	public static Dictionary<string, Overlay> OverlayFuncs = new Dictionary<string, Overlay>
	{
		{
			"Satisfaction",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Bad", 2), new ColorCategory("Good", default(int))), ActorSatisfaction)
		},
		{
			"Effectiveness",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Bad", 2), new ColorCategory("Good", default(int))), ActorEffectiveness)
		},
		{
			"Social",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Bad", 2), new ColorCategory("Good", default(int))), ActorSocial)
		},
		{
			"Stress",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Bad", 2), new ColorCategory("Good", default(int))), ActorStress)
		},
		{
			"AssignedFurniture",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Unassigned", false, 2), new ColorCategory("Assigned", false, default(int))), FurnitureAssigned)
		},
		{
			"Teams",
			new Overlay(new ColorCategoryHolder(new ColorCategory("NotAllowed", false, 2), new ColorCategory("Allowed", false, default(int))), AssignedTeamRoom, AssignedTeamActor)
			{
				CustomAction = delegate
				{
					DataOverlay self = Instance;
					TeamSelectWindow teamSelectWindow = HUD.Instance.TeamSelectWindow;
					Team selectedTeam = self.SelectedTeam;
					teamSelectWindow.Show(true, (selectedTeam != null) ? selectedTeam.Name : null, delegate(string[] y)
					{
						Team selectedTeam2 = ((y.Length != 0) ? GameSettings.GetTeam(y[0]) : null);
						self.SelectedTeam = selectedTeam2;
					}, null);
				},
				CustomActionName = "Team"
			}
		},
		{
			"Lighting",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Bad", 2), new ColorCategory("Good", default(int))), (Room room) => SteppedLerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), 1f - room.DarknessLevel))
		},
		{
			"Temperature",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Too cold", 1), new ColorCategory("Just perfect", default(int)), new ColorCategory("Too hot", 2)), RoomTemperature)
		},
		{
			"Acoustics",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Bad", 2), new ColorCategory("Good", default(int))), (Room room) => SteppedLerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), room.Acoustics))
		},
		{
			"Environment",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Bad", 2), new ColorCategory("Neutral", -1), new ColorCategory("Good", default(int))), Environment, EnvironmentF)
		},
		{
			"Germs",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Clean", default(int)), new ColorCategory("Germs", 2)), RoomGerms, ActorGerms)
		},
		{
			"AirQuality",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Normal", -1), new ColorCategory("Bad", 2), new ColorCategory("Smelly", false, default(int)), new ColorCategory("AirPollution", 2), new ColorCategory("Neutral", -1), new ColorCategory("AirFiltration", default(int))), RoomSmell, FurnitureSmell, ActorSmell)
		},
		{
			"Electricity",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Noconsumption", false, 1), new ColorCategory("LowConsumption", default(int)), new ColorCategory("Highconsumption", 2)), ElectricityUsage)
		},
		{
			"Water",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Noconsumption", false, 1), new ColorCategory("LowConsumption", default(int)), new ColorCategory("Highconsumption", 2)), WaterUsage)
		},
		{
			"Gas",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Noconsumption", false, 1), new ColorCategory("LowConsumption", default(int)), new ColorCategory("Highconsumption", 2)), GasUsage)
		},
		{
			"Maintenance",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Bad", 2), new ColorCategory("Good", default(int))), RoomMaintenance, FurnitureMaintenance)
		},
		{
			"Flammability",
			new Overlay(new ColorCategoryHolder(new ColorCategory("None", false, default(int)), new ColorCategory("Low", 4), new ColorCategory("High", 2)), RoomFlam, FurnitureFlam)
		},
		{
			"FireInspection",
			new Overlay(new ColorCategoryHolder(new ColorCategory("NotProcessed", false, -1), new ColorCategory("Passed", false, default(int)), new ColorCategory("FireAlarm", false, 2), new ColorCategory("Sprinkler", false, 3), new ColorCategory("Escape", false, 1)), RoomFire)
		},
		{
			"Insulation",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Bad", 2), new ColorCategory("Good", 1), new ColorCategory("Great", default(int))), Insulation)
		},
		{
			"AssemblyLines",
			new Overlay(new ColorCategoryHolder(new ColorCategory("AssemblyLine", 2, 0, 1)), AssemblyLine)
		},
		{
			"Room grouping",
			new Overlay(new ColorCategoryHolder(new ColorCategory("No group", false, 2), new ColorCategory("Is grouped", false, default(int))), (Room room) => HUD.GetThemeColor((room.RoomGroup == null) ? 2 : 0))
		},
		{
			"Rent",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Player owned", false, -1), new ColorCategory("CantLease", false, -2), new ColorCategory("CanLease", 2, 0, 1)), Rent)
			{
				CustomAction = delegate
				{
					ShowPlayerOwned = !ShowPlayerOwned;
				},
				CustomActionName = "TogglePlayerOwned"
			}
		},
		{
			"TrafficDensity",
			new Overlay(new ColorCategoryHolder(new ColorCategory("Bad", 2), new ColorCategory("Good", default(int))), Traffic)
		}
	};

	public static bool ShowPlayerOwned = true;

	public static Color Surroundings = new Color(0.7f, 0.7f, 0.7f);

	public static DataOverlay Instance;

	public string ActiveOverlayName;

	public Overlay ActiveOverlay;

	public RectTransform Self;

	public RectTransform TogglePanel;

	public ToggleGroup MainToggleGroup;

	public Toggle TogglePrefab;

	public GradientPanel grPanel;

	public Text DataDesc;

	[NonSerialized]
	public Team SelectedTeam;

	[NonSerialized]
	public Dictionary<string, Toggle> DataToggles = new Dictionary<string, Toggle>();

	public Image ToggleIcon;

	public Sprite OnIcon;

	public Sprite OffIcon;

	public GameObject CustomButton;

	public float MaxWater = 50f;

	public float MaxGas = 50f;

	public float MaxWatt = 50f;

	public float MaxTraffic = 50f;

	public float ActivateTime;

	private bool _shown;

	public static bool HasActive
	{
		get
		{
			if (!Instance.IsReferenceNull())
			{
				return Instance.ActiveOverlay != null;
			}
			return false;
		}
	}

	private static Color AssemblyLine(Furniture f)
	{
		ProductPrinter printer = f.Printer;
		if (printer != null && printer.Group != null)
		{
			return printer.Group.AColor;
		}
		return Color.white;
	}

	private static Color Boosting(Furniture f)
	{
		if (f.CanBoost)
		{
			return SteppedLerp(HUD.GetThemeColor(0), HUD.GetThemeColor(2), f.BoostValue.MapRange(f.MinBoostValue, f.MaxBoostValue, 0f, 1f, true));
		}
		return Color.white;
	}

	private static Color Environment(Room r)
	{
		float environment = r.GetEnvironment();
		if (environment < 1f)
		{
			return SteppedLerp(HUD.GetThemeColor(2), Color.white, environment);
		}
		return SteppedLerp(Color.white, HUD.GetThemeColor(0), environment - 1f);
	}

	private static Color EnvironmentF(Furniture f)
	{
		float environment = f.Environment;
		if (environment < 1f)
		{
			return SteppedLerp(HUD.GetThemeColor(2), Color.white, environment);
		}
		return SteppedLerp(Color.white, HUD.GetThemeColor(0), environment.MapRange(1f, 1.5f, 0f, 1f, true));
	}

	private static Color Traffic(RoadSegment seg)
	{
		return Color.Lerp(HUD.GetThemeColor(0), HUD.GetThemeColor(2), (float)seg.GetTrafficCount() / Instance.MaxTraffic);
	}

	private static Color Rent(Room room)
	{
		if (GameSettings.Instance.RentMode || GameSettings.Instance.EditMode)
		{
			if (!room.Rentable)
			{
				return new Color(0.01f, 0.01f, 0.01f);
			}
			if (!room.PlayerOwned || !ShowPlayerOwned)
			{
				return GetRoomColor(room);
			}
			return Color.white;
		}
		return Color.white;
	}

	private static Color WaterUsage(Furniture furn)
	{
		float? use = furn.GetUse(Furniture.UseType.Water);
		if (!use.HasValue)
		{
			return Color.white;
		}
		if (use.Value != 0f)
		{
			return Color.Lerp(HUD.GetThemeColor(0), HUD.GetThemeColor(2), use.Value / Instance.MaxWater);
		}
		return HUD.GetThemeColor(1);
	}

	private static Color GasUsage(Furniture furn)
	{
		float? use = furn.GetUse(Furniture.UseType.Gas);
		if (!use.HasValue)
		{
			return Color.white;
		}
		if (use.Value != 0f)
		{
			return Color.Lerp(HUD.GetThemeColor(0), HUD.GetThemeColor(2), use.Value / Instance.MaxGas);
		}
		return HUD.GetThemeColor(1);
	}

	private static Color ElectricityUsage(Furniture furn)
	{
		float? use = furn.GetUse(Furniture.UseType.Watt);
		if (!use.HasValue)
		{
			return Color.white;
		}
		if (use.Value != 0f)
		{
			return Color.Lerp(HUD.GetThemeColor(0), HUD.GetThemeColor(2), Mathf.Sqrt(use.Value / Instance.MaxWatt));
		}
		return HUD.GetThemeColor(1);
	}

	private static Color AssignedTeamRoom(Room room)
	{
		if (!room.CompatibleWithTeam(Instance.SelectedTeam))
		{
			return HUD.GetThemeColor(2);
		}
		return HUD.GetThemeColor(0);
	}

	private static Color AssignedTeamActor(Actor ac)
	{
		if (ac.GetTeam() != Instance.SelectedTeam)
		{
			return HUD.GetThemeColor(2);
		}
		return HUD.GetThemeColor(0);
	}

	private static Color Insulation(Room room)
	{
		if (room.Insulation <= 1f)
		{
			return SteppedLerp(HUD.GetThemeColor(0), HUD.GetThemeColor(1), room.Insulation.MapRange(0.5f, 1f, 0f, 1f), 5);
		}
		return SteppedLerp(HUD.GetThemeColor(1), HUD.GetThemeColor(2), room.Insulation - 1f, 5);
	}

	private static Color RoomSatisfaction(Room room)
	{
		if (!room.Occupants.Any((Actor x) => x.AItype == AI.AIType.Employee))
		{
			return HUD.GetThemeColor(1);
		}
		return SteppedLerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), room.Occupants.Where((Actor x) => x.AItype == AI.AIType.Employee).Average((Actor x) => x.employee.JobSatisfaction));
	}

	private static Color ActorSatisfaction(Actor ac)
	{
		return Color.Lerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), ac.employee.JobSatisfaction);
	}

	private static Color RoomEffectiveness(Room room)
	{
		if (!room.Occupants.Any((Actor x) => x.AItype == AI.AIType.Employee))
		{
			return HUD.GetThemeColor(1);
		}
		return SteppedLerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), room.Occupants.Where((Actor x) => x.IsEmployee()).Average((Actor x) => x.Effectiveness));
	}

	private static Color ActorEffectiveness(Actor ac)
	{
		return Color.Lerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), ac.Effectiveness);
	}

	private static Color RoomGerms(Room room)
	{
		return SteppedLerp(HUD.GetThemeColor(0), HUD.GetThemeColor(2), Mathf.Clamp01(room.GermCount * 4f));
	}

	private static Color ActorGerms(Actor ac)
	{
		return Color.Lerp(HUD.GetThemeColor(0), HUD.GetThemeColor(2), Mathf.Clamp01(Mathf.Max(ac.GermAdd * 10f, ac.GermCount * 4f)));
	}

	private static Color RoomSmell(Room room)
	{
		return SteppedLerp(Color.white, HUD.GetThemeColor(2), Mathf.Clamp01(room.Smell));
	}

	private static Color ActorSmell(Actor ac)
	{
		if (!ac.BO)
		{
			return Color.Lerp(HUD.GetThemeColor(2), Color.white, ac.AirQuality);
		}
		return HUD.GetThemeColor(0);
	}

	private static Color FurnitureSmell(Furniture f)
	{
		if (f.AirCleaning != 0f)
		{
			if (!(f.AirCleaning > 0f))
			{
				return HUD.GetThemeColor(2);
			}
			return HUD.GetThemeColor(0);
		}
		return Color.white;
	}

	private static Color RoomSocial(Room room)
	{
		if (!room.Occupants.Any((Actor x) => x.AItype == AI.AIType.Employee))
		{
			return HUD.GetThemeColor(1);
		}
		return SteppedLerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), room.Occupants.Where((Actor x) => x.AItype == AI.AIType.Employee).Average((Actor x) => x.employee.Social));
	}

	private static Color ActorSocial(Actor ac)
	{
		return Color.Lerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), ac.employee.Social);
	}

	private static Color RoomStress(Room room)
	{
		if (!room.Occupants.Any((Actor x) => x.AItype == AI.AIType.Employee))
		{
			return HUD.GetThemeColor(1);
		}
		return SteppedLerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), room.Occupants.Where((Actor x) => x.AItype == AI.AIType.Employee).Average((Actor x) => x.employee.Stress));
	}

	private static Color ActorStress(Actor ac)
	{
		return Color.Lerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), ac.employee.Stress);
	}

	private static Color RoomTemperature(Room room)
	{
		if (room.Temperature > 21f)
		{
			return SteppedLerp(HUD.GetThemeColor(0), HUD.GetThemeColor(2), (room.Temperature - 21f) / 24f, 5);
		}
		return SteppedLerp(HUD.GetThemeColor(0), HUD.GetThemeColor(1), (21f - room.Temperature) / 24f, 5);
	}

	private static Color FurnitureMaintenance(Furniture f)
	{
		if (!f.HasUpg)
		{
			return Color.white;
		}
		return Color.Lerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), f.upg.Quality);
	}

	private static Color FurnitureFlam(Furniture f)
	{
		if (!f.HasUpg || !(f.upg.FireStarter > 0f))
		{
			return Color.white;
		}
		return Color.Lerp(HUD.GetThemeColor(4), HUD.GetThemeColor(2), f.upg.FireStarter * 10f);
	}

	private static Color RoomFlam(Room r)
	{
		if (r.Outdoors || r.Pillar)
		{
			return Color.white;
		}
		float num = r.GetFurnitures().SumSafe((Furniture x) => (!x.HasUpg) ? 0f : x.upg.FireStarter);
		if (!(num > 0f))
		{
			return HUD.GetThemeColor(0);
		}
		return Color.Lerp(HUD.GetThemeColor(4), HUD.GetThemeColor(2), num);
	}

	private static Color RoomFire(Room r)
	{
		if (GameSettings.Instance.ActiveFireReport == null)
		{
			return Color.white;
		}
		if (GameSettings.Instance.ActiveFireReport.AlarmRooms.Contains(r.DID) && !r.AnyFurnitureInAtrium("FireAlarm"))
		{
			return HUD.GetThemeColor(2);
		}
		if (GameSettings.Instance.ActiveFireReport.SprinklerRooms.Contains(r.DID) && !r.AnyFurnitureInAtrium("Sprinkler"))
		{
			return HUD.GetThemeColor(3);
		}
		if (GameSettings.Instance.ActiveFireReport.EscapeRooms.Contains(r.DID))
		{
			return HUD.GetThemeColor(1);
		}
		if (!GameSettings.Instance.ActiveFireReport.Complete)
		{
			return Color.white;
		}
		return HUD.GetThemeColor(0);
	}

	private static Color FurnitureEnvironment(Furniture f)
	{
		if (f.Environment == 1f)
		{
			return Color.white;
		}
		return Color.Lerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), f.Environment);
	}

	private static Color FurnitureAssigned(Furniture f)
	{
		if (!f.CanAssign)
		{
			return Color.white;
		}
		if (!(f.OwnedBy != null))
		{
			return HUD.GetThemeColor(2);
		}
		return HUD.GetThemeColor(0);
	}

	private static Color RoomMaintenance(Room room)
	{
		List<Furniture> furnitures = room.GetFurnitures();
		for (int i = 0; i < furnitures.Count; i++)
		{
			Furniture furniture = furnitures[i];
			if (furniture.HasUpg && furniture.upg.Quality < 0.5f)
			{
				return HUD.GetThemeColor(2);
			}
		}
		return Color.white;
	}

	public static Color GetRoomColor(Room r)
	{
		Room room = r.ParentRoom ?? r;
		Vector3 vector = Utilities.HSVToRGB(Mathf.Abs(room.Center.x * room.Center.y + (float)(room.Floor * 20)) % 360f, 0.75f, 1f);
		return new Color(vector.x, vector.y, vector.z, 1f);
	}

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void Start()
	{
		foreach (string key in OverlayFuncs.Keys)
		{
			Toggle toggle = UnityEngine.Object.Instantiate(TogglePrefab);
			toggle.transform.SetParent(TogglePanel, false);
			toggle.isOn = false;
			toggle.GetComponentInChildren<Text>().text = key.Loc();
			toggle.name = key;
			string overlay1 = key;
			toggle.onValueChanged.AddListener(delegate(bool x)
			{
				if (x)
				{
					ActivateFunc(overlay1);
				}
				else if (!MainToggleGroup.AnyTogglesOn())
				{
					ActivateFunc(null);
				}
			});
			toggle.group = MainToggleGroup;
			DataToggles[key] = toggle;
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public static Color GetColor(int i)
	{
		switch (i)
		{
		case -1:
			return Color.white;
		case -2:
			return Color.black;
		default:
			return HUD.GetThemeColor(i);
		}
	}

	public void CustomAction()
	{
		if (ActiveOverlay != null && ActiveOverlay.CustomAction != null)
		{
			ActiveOverlay.CustomAction();
		}
	}

	private static float GetLineSpacing()
	{
		if (Options.UISize < 1.1f)
		{
			return 1.74f;
		}
		if (Options.UISize < 1.2f)
		{
			return 1.77f;
		}
		if (Options.UISize < 1.5f)
		{
			return 1.79f;
		}
		if (Options.UISize < 1.6f)
		{
			return 1.74f;
		}
		if (Options.UISize < 2f)
		{
			return 1.77f;
		}
		return 1.74f;
	}

	public void ActivateFunc(string func)
	{
		if (ActiveOverlay == null)
		{
			ActivateTime = Time.timeSinceLevelLoad;
		}
		PipLight.ForceWhite = func != null;
		ActiveOverlay = ((func == null) ? null : OverlayFuncs[func]);
		ActiveOverlayName = func;
		FrameTransition.StartTransition(false);
		RoadManager.Instance.ClearDataColor();
		if (ActiveOverlay != null)
		{
			if (ActiveOverlay.CustomAction != null)
			{
				CustomButton.SetActive(true);
				CustomButton.GetComponentInChildren<Text>().text = ActiveOverlay.CustomActionName.Loc();
			}
			else
			{
				CustomButton.SetActive(false);
			}
			CameraScript.Instance.mainCam.SetReplacementShader(CameraScript.Instance.DataShader, "RenderType");
			Toggle orNull = DataToggles.GetOrNull(ActiveOverlayName);
			if (orNull != null)
			{
				orNull.isOn = true;
			}
			grPanel.Gradients = ActiveOverlay.Categories.Categories.SelectMany((ColorCategory x) => x.GetColors()).ToList();
			StringBuilder stringBuilder = new StringBuilder();
			for (int num = 0; num < ActiveOverlay.Categories.Categories.Length; num++)
			{
				ColorCategory colorCategory = ActiveOverlay.Categories.Categories[num];
				if (colorCategory.ColorLength == 1)
				{
					stringBuilder.AppendLine(colorCategory.Name.Loc());
					continue;
				}
				int num2 = colorCategory.ColorLength / 2;
				if (colorCategory.ColorLength % 2 == 0)
				{
					for (int num3 = 0; num3 < num2 - 1; num3++)
					{
						stringBuilder.AppendLine("");
					}
				}
				else
				{
					for (int num4 = 0; num4 < num2; num4++)
					{
						stringBuilder.AppendLine("");
					}
				}
				stringBuilder.AppendLine(colorCategory.Name.Loc());
				for (int num5 = 0; num5 < num2; num5++)
				{
					stringBuilder.AppendLine("");
				}
			}
			DataDesc.text = stringBuilder.ToString();
			DataDesc.lineSpacing = GetLineSpacing();
		}
		else
		{
			CustomButton.SetActive(false);
			CameraScript.Instance.mainCam.ResetReplacementShader();
			grPanel.Gradients.Clear();
			DataDesc.text = "";
			foreach (KeyValuePair<string, Toggle> dataToggle in DataToggles)
			{
				dataToggle.Value.isOn = false;
			}
		}
		grPanel.SetVerticesDirty();
		if (HUD.Instance != null)
		{
			HUD.Instance.RefreshDataoverlayToggle();
		}
	}

	public Color GetColor(Color color)
	{
		if (ActiveOverlay == null)
		{
			return color;
		}
		float num = Mathf.Clamp01((Time.timeSinceLevelLoad - ActivateTime) * 4f);
		if (num == 1f)
		{
			return Surroundings;
		}
		return Color.Lerp(color, Surroundings, num);
	}

	public Color GetColor(Room room, Color defaultColor, Color currentColor)
	{
		if (ActiveOverlay == null)
		{
			return defaultColor;
		}
		return Color.Lerp(currentColor, ActiveOverlay.Func(room), Time.deltaTime * 5f);
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (_shown && (Input.GetMouseButton(0) || Input.GetMouseButton(1)) && !RectTransformUtility.RectangleContainsScreenPoint(Self, Input.mousePosition, UICamSize.GetUICam()))
		{
			Toggle();
		}
		if (!HasActive)
		{
			return;
		}
		for (int i = 0; i < GameSettings.Instance.sRoomManager.AllFurniture.Count; i++)
		{
			Furniture furniture = GameSettings.Instance.sRoomManager.AllFurniture[i];
			if (furniture.Colorable.Count > 0 && furniture.Colorable[0].enabled && furniture.Colorable[0].isVisible)
			{
				furniture.GetBlock().SetColor("_DataColor", (ActiveOverlay.FFunc == null) ? Color.white : ActiveOverlay.FFunc(furniture));
				furniture.UpdateMaterials();
			}
		}
	}

	public void Toggle()
	{
		_shown = !_shown;
		UISoundFX.PlaySFX(_shown ? "SlideIn" : "SlideOut", -1f, -0.5f);
		Self.DOSizeDelta(new Vector2(_shown ? 300 : 0, Mathf.Min((float)Screen.height / Options.UISize - 368f, OverlayFuncs.Count * 24 + 41)), 0.5f, true);
		ToggleIcon.sprite = (_shown ? OnIcon : OffIcon);
	}

	public void Show()
	{
		if (!_shown)
		{
			Toggle();
		}
	}

	private static Color SteppedLerp(Color c1, Color c2, float l, int steps = 10)
	{
		l = Mathf.Round(l * (float)steps) / (float)steps;
		return Color.Lerp(c1, c2, l);
	}
}

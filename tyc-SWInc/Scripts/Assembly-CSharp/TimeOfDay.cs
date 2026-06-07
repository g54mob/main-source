using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Achievements;
using DevConsole;
using SINetworking;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeOfDay : MonoBehaviour
{
	public static TimeOfDay Instance;

	public float Minute;

	public float SunOffset = 25f;

	[NonSerialized]
	private float _lastCleanUp;

	public float RealTimeDayStart;

	public int Hour;

	public int Day;

	public int Month;

	public int Year;

	public AnimationCurve TreeLeaveTempHide;

	public static float LightLevel = 1f;

	public bool IsSkipping;

	public float NetworkFix;

	public GameObject GroundPlane;

	public GameObject GroundPlane2;

	public Renderer GroundTop;

	public Renderer InfPlane;

	public Renderer GrassPlane;

	private bool _materialInit;

	public SkraperGen SkraperPrefab;

	private Material _actualScraperWindow;

	[SerializeField]
	private Material _sideWalkMat;

	[SerializeField]
	private Material _sideWalkMat2;

	[SerializeField]
	private Material _roadMaterial;

	[SerializeField]
	private Material _waterMat;

	[SerializeField]
	private Material _noiseGrassMaterial;

	public Material NormalWater;

	public Material Ice;

	public ReflectionProbe MainProbe;

	public Renderer ProbeGround;

	public Material SkyBoxMat;

	[SerializeField]
	public Material _groundMat;

	[SerializeField]
	public Material _groundMat2;

	public Material ClockMat;

	public Material BeltMat;

	public Material BeltMatNoMove;

	[NonSerialized]
	public Material[] BeltMats;

	public Material GrassMask;

	public AnimationCurve LightOnage;

	private SDateTime currentDate;

	public float targetDate;

	public float Temperature;

	private bool hasUpdatedDate;

	public bool canSkip;

	[NonSerialized]
	public bool DisableSunUpdate = true;

	public ParticleSystem Clouds;

	public Material CloudSystemMat;

	public PAParticleField Snow;

	public PAParticleField Rain;

	[SerializeField]
	private WeatherPreset _currentWeather;

	public AnimationCurve SunAngle;

	[NonSerialized]
	public float RainFactor;

	[NonSerialized]
	public SDateTime? Banktupcy;

	[NonSerialized]
	public List<Actor> Sick = new List<Actor>();

	public ButtonCounter BadServerCounter;

	public AnimationCurve HouseOnage;

	public AnimationCurve CloudVisibility;

	public AnimationCurve Lightning;

	public Material CloudMat;

	public Texture CloudSourceTex;

	public RenderTexture CloudTex;

	public Vector2 Windiness = Vector2.zero;

	public Vector2 Offset = Vector2.zero;

	public float Cloudiness;

	public float WaterSpeed = 0.2f;

	public Light SunLight;

	public Light LightningLight;

	private AudioSource _rainSFX;

	private AudioSource _thunderHighSFX;

	private AudioSource _thunderLowSFX;

	[NonSerialized]
	private float _lightningCountdown;

	[NonSerialized]
	private float _lightningAnim = -1f;

	[NonSerialized]
	private float _thunderCountdown = -1f;

	public float SunEffectiveness;

	public float SunEffectivenessSum;

	private float _carSpawnTimer = 1f;

	public bool GroundTopDirty = true;

	[NonSerialized]
	private bool disableCars;

	public Gradient _dayGrad = new Gradient();

	public Texture SnowMelt;

	public Texture SnowAccum;

	private float _lastSnow;

	private bool _lastSnowUp;

	public float SnowAmount;

	private float _timeInMinutes;

	private float _gameTime;

	private float _gameTimePaused;

	private HashSet<ServerGroup> _fallbackVisit = new HashSet<ServerGroup>();

	private Dictionary<byte, float> _cloudUsage = new Dictionary<byte, float>();

	public const float MinWindSpeed = 0.01f;

	public const float MaxWindSpeed = 0.02f;

	[NonSerialized]
	public SDateTime? DateOverride;

	[NonSerialized]
	public object TimeLock = new object();

	public Material NoiseGrassMaterial
	{
		get
		{
			InitMats();
			return _noiseGrassMaterial;
		}
	}

	public Material GroundMat
	{
		get
		{
			InitMats();
			return _groundMat;
		}
	}

	public Material GroundMat2
	{
		get
		{
			InitMats();
			return _groundMat2;
		}
	}

	public Material WaterMat
	{
		get
		{
			InitMats();
			return _waterMat;
		}
	}

	public Material SideWalkMat
	{
		get
		{
			InitMats();
			return _sideWalkMat;
		}
	}

	public Material SideWalkMat2
	{
		get
		{
			InitMats();
			return _sideWalkMat2;
		}
	}

	public Material RoadMaterial
	{
		get
		{
			InitMats();
			return _roadMaterial;
		}
	}

	public WeatherPreset CurrentWeather
	{
		get
		{
			return _currentWeather;
		}
		set
		{
			_currentWeather = value;
			NoiseGrassMaterial.SetColor("_TipColor", _currentWeather.GrassRoots);
			NoiseGrassMaterial.SetColor("_RootColor", _currentWeather.GrassTips);
			NoiseGrassMaterial.SetFloat("_Noise2Min", _currentWeather.GrassMin);
			NoiseGrassMaterial.SetFloat("_Noise2Max", _currentWeather.GrassMax);
			UpdateSunColorGradient();
		}
	}

	public float TimeInMinutes
	{
		get
		{
			return _timeInMinutes;
		}
	}

	public static event EventHandler OnHourPassed;

	public static event EventHandler OnDayPassed;

	public static event EventHandler OnMonthPassed;

	private static void FireEvent(EventHandler e)
	{
		if (e != null)
		{
			e(Instance, null);
		}
	}

	private void Start()
	{
		AudioSource[] components = GetComponents<AudioSource>();
		RenderSettings.skybox = new Material(RenderSettings.skybox);
		_rainSFX = components[0];
		_thunderHighSFX = components[1];
		_thunderLowSFX = components[2];
		Instance = this;
		GroundTop.sharedMaterial = GroundMat;
		Renderer infPlane = InfPlane;
		Material sharedMaterial = (GroundPlane.GetComponent<Renderer>().sharedMaterial = GroundMat2);
		infPlane.sharedMaterial = sharedMaterial;
		InfPlane.gameObject.SetActive(Options.WorldBackground == 1);
		targetDate = GetDate(true).ToInt();
		RandomizeCloudShadows();
		_lightningCountdown = UnityEngine.Random.Range(60f, 480f);
		CloudMat = new Material(CloudMat);
		CloudSystemMat = new Material(CloudSystemMat);
		Clouds.GetComponent<Renderer>().sharedMaterial = CloudSystemMat;
		NoiseGrassMaterial.SetTexture("_MaskTex", GrassSystem.Instance.Test);
	}

	private void InitMats()
	{
		if (!_materialInit)
		{
			_materialInit = true;
			_sideWalkMat = MaterialFixer.Get(_sideWalkMat);
			_sideWalkMat2 = MaterialFixer.Get(_sideWalkMat2);
			_roadMaterial = MaterialFixer.Get(_roadMaterial);
			_actualScraperWindow = MaterialFixer.Get(SkraperPrefab.MainMaterial);
			_waterMat = new Material(_waterMat);
			_groundMat = new Material(_groundMat);
			_groundMat2 = new Material(_groundMat2);
			_noiseGrassMaterial = new Material(NoiseGrassMaterial);
			GrassPlane.sharedMaterial = _noiseGrassMaterial;
			BeltMats = new Material[3]
			{
				new Material(BeltMat),
				new Material(BeltMat),
				new Material(BeltMat)
			};
			BeltMats[0].name = "Belt0";
		}
	}

	public void UpdateGroundTopMesh()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		List<Furniture> list = new List<Furniture>();
		for (int i = 0; i < GameSettings.Instance.sRoomManager.AllFurniture.Count; i++)
		{
			Furniture furniture = GameSettings.Instance.sRoomManager.AllFurniture[i];
			if (furniture.Parent != null && furniture.Parent.Floor == -1 && furniture.TwoFloors && furniture.MakeHole)
			{
				if (furniture.FinalNav == null)
				{
					furniture.UpdateBoundaryPoints();
				}
				list.Add(furniture);
			}
		}
		Mesh mesh = new Mesh();
		Vector2[] array = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0f, 256f),
			new Vector2(256f, 256f),
			new Vector2(256f, 0f)
		};
		List<Landmark> list2 = RoadManager.Instance.Landmarks.Where((Landmark x) => x.MakeHole()).ToList();
		if (list.Count > 0 || list2.Count > 0)
		{
			ValueTuple<Vector2[], int[]> valueTuple = SwincBooster.Tesselate(array, list.Select((Furniture x) => x.FinalNav).Concat(list2.Select((Landmark x) => x.GetNavMesh())), false);
			mesh.vertices = valueTuple.Item1.SelectInPlace((Vector2 x) => x.ToVector3(0f));
			mesh.triangles = ReverseTriangles(valueTuple.Item2);
		}
		else
		{
			mesh.vertices = array.SelectInPlace((Vector2 x) => x.ToVector3(0f));
			mesh.triangles = new int[6] { 0, 1, 2, 2, 3, 0 };
		}
		Vector3[] vertices = mesh.vertices;
		mesh.normals = Utilities.RepeatValue(Vector3.up, vertices.Length);
		mesh.tangents = Utilities.RepeatValue(new Vector4(1f, 0f, 0f, -1f), vertices.Length);
		mesh.uv = vertices.SelectInPlace((Vector3 x) => new Vector2(x.x, x.z));
		GroundTop.GetComponent<MeshFilter>().sharedMesh = mesh;
	}

	private int[] ReverseTriangles(int[] tris)
	{
		for (int i = 0; i < tris.Length; i += 3)
		{
			int[] array = tris;
			int num = i;
			int[] array2 = tris;
			int num2 = i + 2;
			int num3 = tris[i + 2];
			int num4 = tris[i];
			array[num] = num3;
			array2[num2] = num4;
		}
		return tris;
	}

	public void UpdateExtraLayerColor()
	{
		GroundPlane2.GetComponent<Renderer>().material.color = CurrentWeather.GroundColor;
	}

	public void InitYear(int year)
	{
		Year = year;
		currentDate = new SDateTime(0, year);
		targetDate = GetDate(true).ToInt();
		HUD.Instance.UpdateFurnitureButtons();
	}

	public void RunUpdate()
	{
		bool disableSunUpdate = DisableSunUpdate;
		DisableSunUpdate = false;
		disableCars = true;
		Update();
		disableCars = false;
		DisableSunUpdate = disableSunUpdate;
	}

	private void UpdateSunColorGradient()
	{
		float num = (float)Month + (float)Day / (float)GameSettings.DaysPerMonth;
		num = Mathf.Abs(num - 6f) / 6f;
		GradientColorKey[] array = new GradientColorKey[CurrentWeather.SummerGradient.colorKeys.Length];
		for (int i = 0; i < array.Length; i++)
		{
			GradientColorKey gradientColorKey = CurrentWeather.SummerGradient.colorKeys[i];
			GradientColorKey gradientColorKey2 = CurrentWeather.WinterGradient.colorKeys[i];
			array[i] = new GradientColorKey(Color.Lerp(gradientColorKey.color, gradientColorKey2.color, num), Mathf.Lerp(gradientColorKey.time, gradientColorKey2.time, num));
		}
		_dayGrad.SetKeys(array, new GradientAlphaKey[0]);
	}

	private Color GetDayColor(float Hour, float Minute)
	{
		float num = Hour + Minute / 60f;
		num /= 24f;
		return _dayGrad.Evaluate(num);
	}

	public Color GetSkyColor()
	{
		float[] hUDTime = GetHUDTime(targetDate);
		return GetSkyColor(hUDTime[1], hUDTime[0]);
	}

	private Color GetSkyColor(float Hour, float Minute)
	{
		float num = Hour + Minute / 60f;
		num /= 24f;
		return CurrentWeather.SkyGradient.Evaluate(num);
	}

	private Color GetAmbientColor(float Hour, float Minute)
	{
		float num = Hour + Minute / 60f;
		num /= 24f;
		return CurrentWeather.AmbientGradient.Evaluate(num);
	}

	private Quaternion GetDayRotation(float Hour, float Minute)
	{
		float num = Hour + Minute / 60f;
		return Quaternion.Euler(SunAngle.Evaluate(num), num / 24f * 360f + SunOffset, 0f);
	}

	private void SnowSim()
	{
		SnowAmount = GetSnowTemp(0f);
		if (_lastSnow > SnowAmount)
		{
			if (_lastSnowUp)
			{
				Shader.SetGlobalTexture("_SnowFalloff", SnowMelt);
				_lastSnowUp = false;
			}
		}
		else if (_lastSnow < SnowAmount && !_lastSnowUp)
		{
			Shader.SetGlobalTexture("_SnowFalloff", SnowAccum);
			_lastSnowUp = true;
		}
		_lastSnow = SnowAmount;
		float num = (Options.EnvEffects ? GetSnowTemp(1f / 24f) : 0f);
		bool flag = num > 0f && GameSettings.Instance.ActiveFloor >= 0;
		if (Snow.gameObject.activeSelf != flag)
		{
			Snow.gameObject.SetActive(flag);
		}
		if (Snow.gameObject.activeSelf)
		{
			Snow.particleCountMask = num;
			Snow.SimulationSpeed = Mathf.Min(100f, GameSettings.GameSpeed);
		}
		Color color = DataOverlay.Instance.GetColor(GetGroundColor());
		Color color2 = RoomMaterialController.GetColor(RoomMaterialController.Instance.GroundColorID);
		if (Mathf.Abs(color.r - color2.r) + Mathf.Abs(color.g - color2.g) + Mathf.Abs(color.b - color2.b) > 0.04f)
		{
			RoomMaterialController.WriteColor(RoomMaterialController.Instance.GroundColorID, color);
		}
		GroundMat.color = DataOverlay.Instance.GetColor(CurrentWeather.GroundColor);
		GroundMat2.color = DataOverlay.Instance.GetColor(CurrentWeather.GroundColor);
	}

	public void UpdateProbeState()
	{
		MainProbe.intensity = (Options.SSR ? 0.3f : 0.4f);
		MainProbe.gameObject.SetActive(GameSettings.Instance.ActiveFloor >= 0);
	}

	public Color GetGroundColor()
	{
		return Color.Lerp(CurrentWeather.GroundColor, new Color(0.7f, 0.7f, 0.7f), SnowAmount);
	}

	private void RainSim()
	{
		bool flag = Cloudiness > 0.5f && Temperature > 2f && !Snow.gameObject.activeSelf;
		float num = Time.deltaTime * GameSettings.GameSpeed * 0.01f;
		RainFactor = Mathf.Clamp01(RainFactor + (flag ? num : (0f - num)));
		if (_lightningAnim >= 0f)
		{
			_lightningAnim += Time.deltaTime;
			if (_lightningAnim > 1f)
			{
				_lightningAnim = -1f;
				LightningLight.gameObject.SetActive(false);
			}
			else
			{
				LightningLight.gameObject.SetActive(true);
				LightningLight.intensity = Lightning.Evaluate(_lightningAnim);
			}
		}
		if (_thunderCountdown > 0f)
		{
			_thunderCountdown -= Time.deltaTime;
			if (_thunderCountdown <= 0f)
			{
				_thunderLowSFX.Play();
				_thunderHighSFX.Play();
				_lightningCountdown = UnityEngine.Random.Range(60f, 480f);
			}
		}
		RoadMaterial.SetFloat("_PuddleFactor", RainFactor);
		RoomMaterialController.Instance.StandardRoof.SetFloat("_Glossiness", RainFactor * 0.6f);
		RoomMaterialController.Instance.StandardRoof.SetFloat("_Metallic", RainFactor * 0.5f);
		RoomMaterialController.Instance.MainMat.SetFloat("_Rain", RainFactor * 1.1f);
		bool flag2 = Options.EnvEffects && GameSettings.Instance.ActiveFloor >= 0 && RainFactor > 0f;
		if (Rain.gameObject.activeSelf != flag2)
		{
			Rain.gameObject.SetActive(flag2);
		}
		if (flag2)
		{
			Rain.particleCountMask = RainFactor;
			Rain.SimulationSpeed = Mathf.Min(100f, GameSettings.GameSpeed);
		}
		bool flag3 = flag2 && GameSettings.GameSpeed > 0f;
		if (_rainSFX.isPlaying != flag3)
		{
			if (flag3)
			{
				_rainSFX.volume = 0f;
				_rainSFX.Play();
			}
			else
			{
				_rainSFX.Stop();
			}
		}
		if (!flag3)
		{
			return;
		}
		if (Temperature > 20f && _lightningCountdown > 0f)
		{
			_lightningCountdown -= Time.deltaTime * GameSettings.GameSpeed;
			if (_lightningCountdown <= 0f)
			{
				bool flag4 = UnityEngine.Random.value > 0.75f;
				_thunderCountdown = (flag4 ? 0.5f : ((float)UnityEngine.Random.Range(2, 4)));
				_thunderLowSFX.volume = (flag4 ? 0f : 1f);
				_thunderHighSFX.volume = 1f - _thunderLowSFX.volume;
				LightningLight.transform.rotation = Quaternion.Euler(70f, UnityEngine.Random.Range(0, 360), 0f);
				_lightningAnim = 0f;
			}
		}
		_rainSFX.volume = RainFactor;
	}

	public float GetSnowTemp(float offset)
	{
		float num = YearFloat() + offset;
		if (num > 1f)
		{
			num -= 1f;
		}
		if (num < 0f)
		{
			num = 1f - num;
		}
		return Mathf.Clamp01((0f - CurrentWeather.TempMin.Evaluate(num)) / 2f);
	}

	public float GetYearFloatInMinutes()
	{
		return (float)(((Month * GameSettings.DaysPerMonth + Day) * 24 + Hour) * 60) + Minute;
	}

	private void UpdateTimeInMinutes()
	{
		_timeInMinutes = (float)((((Year * 12 + Month) * GameSettings.DaysPerMonth + Day) * 24 + Hour) * 60) + Minute;
	}

	public float GetMonthFloat(float mid, float range)
	{
		float num = (float)Month + ((float)Hour + Minute / 60f) / 24f;
		num = (num + (11f - mid) + range / 2f) % 12f;
		if (num > range)
		{
			return 0f;
		}
		return 1f - Mathf.Abs(num / range - 0.5f) * 2f;
	}

	private void CarSpawn()
	{
		if (disableCars || !SelectorController.Instance.DoneLoading)
		{
			return;
		}
		_carSpawnTimer -= Time.deltaTime * GameSettings.GameSpeed;
		if (_carSpawnTimer <= 0f)
		{
			if (RoadManager.Instance != null && UnityEngine.Random.value < GameSettings.Instance.Environment.TrafficDensity.Evaluate((float)Hour + Minute / 60f))
			{
				RoadManager.Instance.CreateCar(RoadManager.PickCar(UnityEngine.Random.value > 0.9f), true, true).Init();
			}
			_carSpawnTimer = Mathf.Max(-5f, 1f + _carSpawnTimer);
		}
	}

	private void UpdateWater()
	{
		WaterMat.SetFloat("_HeightFactor", Mathf.Lerp(NormalWater.GetFloat("_HeightFactor"), Ice.GetFloat("_HeightFactor"), SnowAmount));
		WaterMat.SetColor("_HeightColor", Color.Lerp(NormalWater.GetColor("_HeightColor"), Ice.GetColor("_HeightColor"), SnowAmount));
		WaterMat.SetFloat("_Glossiness", Mathf.Lerp(NormalWater.GetFloat("_Glossiness"), Ice.GetFloat("_Glossiness"), SnowAmount));
		WaterMat.SetFloat("_Metallic", Mathf.Lerp(NormalWater.GetFloat("_Metallic"), Ice.GetFloat("_Metallic"), SnowAmount));
		WaterMat.SetColor("_Color", Color.Lerp(NormalWater.GetColor("_Color"), Ice.GetColor("_Color"), SnowAmount));
		WaterMat.SetVector("_LightDir", -base.transform.forward);
		WaterMat.SetColor("_LightColor", SunLight.color);
		if (GameSettings.GameSpeed > 0f)
		{
			Vector4 vector = WaterMat.GetVector("_TimeDelta");
			WaterMat.SetVector("_TimeDelta", vector + new Vector4(Windiness.magnitude * Time.deltaTime * WaterSpeed * GameSettings.GameSpeed, Time.deltaTime * GameSettings.GameSpeed));
		}
	}

	private float GetLightLevel(Color dayColor)
	{
		return Mathf.Min(1f, dayColor.grayscale * 1.5f);
	}

	public void SkipToNextDayNetwork()
	{
		if (NetworkManager.IsHost)
		{
			NetworkManager.Instance.Players.ForEach(delegate(NetworkPlayer x)
			{
				x.Ready = NetworkPlayer.ReadyStatus.NotReady;
			});
		}
		NetworkMessaging.SendPlayerReady(NetworkPlayer.ReadyStatus.NotReady, NetworkMessaging.MessageTarget.Everyone, 0);
		Minute = 0f;
		AddHour(true, 0f);
		UpdateTimeInMinutes();
		GameSettings.ForcePause = false;
		if (NetworkManager.IsHost)
		{
			NetworkMessaging.SendControlStatement(NetworkMessaging.ControlType.SkipToNextDay, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		else if (Day == 0)
		{
			NetworkMessaging.SendControlStatement(NetworkMessaging.ControlType.FixCashflow, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	public void SetupTimeSync()
	{
		Minute = 59.9999f;
		GameSettings.ForcePause = true;
		NetworkMessaging.SendPlayerReady(NetworkPlayer.ReadyStatus.Ready, NetworkMessaging.MessageTarget.Everyone, 0);
		GameSettings.Instance.EnforceTime(0);
		UpdateTimeInMinutes();
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (WaitingOnNetwork() && NetworkManager.Self.IsReady)
		{
			if (NetworkFix >= 0f)
			{
				if (!NetworkManager.Instance.Players.Any((NetworkPlayer x) => !x.Self && !x.IsReady))
				{
					NetworkFix += Time.deltaTime;
					if (NetworkFix > 2f)
					{
						NetworkMessaging.SendPlayerReady(NetworkManager.Self.Ready, NetworkMessaging.MessageTarget.Everyone, 0);
						NetworkFix = -1f;
						Debug.Log("Tried to fix broken multiplayer waiting " + (NetworkManager.IsHost ? "as host" : "as client") + ", status: " + string.Join(", ", NetworkManager.Instance.Players.Select((NetworkPlayer x) => (x.Self ? "+" : "") + x.Ready)));
					}
				}
				else
				{
					NetworkFix = 0f;
				}
			}
		}
		else
		{
			NetworkFix = 0f;
		}
		if (GroundTopDirty)
		{
			UpdateGroundTopMesh();
			GroundTopDirty = false;
		}
		if (DisableSunUpdate)
		{
			return;
		}
		UpdateWater();
		CarSpawn();
		ParticleSystem.MainModule main = Clouds.main;
		main.simulationSpeed = Mathf.Max(1, HUD.Instance.GameSpeed);
		hasUpdatedDate = false;
		Minute += Time.deltaTime * GameSettings.GameSpeed;
		bool flag = false;
		while (Minute >= 60f && !GameSettings.ForcePause)
		{
			if (NetworkManager.IsConnected && Hour == 23)
			{
				SetupTimeSync();
				return;
			}
			Minute -= 60f;
			flag |= AddHour(!flag, 0f);
		}
		UpdateTimeInMinutes();
		targetDate = Mathf.Lerp(targetDate, ToFloat(), 0.1f);
		float[] hUDTime = GetHUDTime(targetDate);
		Color dayColor = GetDayColor(hUDTime[1], hUDTime[0]);
		SunLight.color = ((GameSettings.Instance.ActiveFloor == -1) ? Color.black : dayColor);
		if (CameraScript.Instance.FlyMode)
		{
			RenderSettings.fogDensity = 0.018f / CameraScript.FlyCamDistance;
		}
		else if (GameSettings.Instance.ActiveFloor == -1)
		{
			RenderSettings.fogDensity = 0.001f;
		}
		else
		{
			RenderSettings.fogDensity = Mathf.Lerp(0.001f, 0.004f, CameraScript.Instance.GetZoomLevel().MapRange(0.5f, 1f, 1f, 0f, true) * (1f - SunLight.color.grayscale));
		}
		LightLevel = GetLightLevel(dayColor);
		SnowSim();
		RainSim();
		base.transform.rotation = GetDayRotation(hUDTime[1], hUDTime[0]);
		Color skyColor = GetSkyColor(hUDTime[1], hUDTime[0]);
		CameraScript.Instance.mainCam.backgroundColor = (RenderSettings.fogColor = ((GameSettings.Instance.ActiveFloor == -1) ? Color.black : skyColor));
		RenderSettings.ambientLight = ((GameSettings.Instance.ActiveFloor == -1) ? new Color(0.2f, 0.2f, 0.2f) : GetAmbientColor(hUDTime[1], hUDTime[0]));
		if (DataOverlay.HasActive)
		{
			SunLight.color = Color.white * SunLight.color.grayscale;
			CameraScript.Instance.mainCam.backgroundColor = (RenderSettings.fogColor = Color.white * RenderSettings.fogColor.grayscale);
			RenderSettings.ambientLight = Color.white * RenderSettings.ambientLight.grayscale;
		}
		GameSettings.Instance.LeaveMat.SetFloat("_YearTime", YearFloat());
		if (GameSettings.Instance.EditMode)
		{
			GameSettings.Instance.LeaveMat.SetFloat("_Leaf", 1f);
		}
		else
		{
			float num = GameSettings.Instance.LeaveMat.GetFloat("_Leaf");
			float num2 = TreeLeaveTempHide.Evaluate(CurrentWeather.TempMin.Evaluate((YearFloat() - 0.02f) % 1f));
			GameSettings.Instance.LeaveMat.SetFloat("_Leaf", num2);
			if (GameSettings.GameSpeed > 0f && num2 != num)
			{
				GameSettings.Instance.LeaveMat.SetFloat("_Recovery", (num2 >= num) ? 1 : 0);
			}
		}
		Shader.SetGlobalFloat("_Snow", SnowAmount);
		Shader.SetGlobalFloat("_RainAmount", RainFactor);
		Shader.SetGlobalColor("_SunColor", SunLight.color);
		Shader.SetGlobalVector("_SunDirection", SunLight.transform.forward);
		NoiseGrassMaterial.SetFloat("_Speed", HUD.Instance.GameSpeed);
		UpdateTemperature();
		_gameTime += Time.deltaTime * GameSettings.GameSpeed;
		if (GameSettings.GameSpeed > 0f)
		{
			_gameTimePaused += Time.deltaTime;
		}
		Shader.SetGlobalVector("_GameTime", new Vector4(_gameTime, _gameTimePaused, 1f, 1f));
		Clouds.gameObject.SetActive(Options.Clouds && GameSettings.Instance.ActiveFloor >= 0);
		Offset += Windiness * Time.deltaTime * GameSettings.GameSpeed;
		CloudMat.SetVector("_Props", new Vector4(Offset.x, HUD.Instance.BuildMode ? 0f : (CameraScript.Instance.NormalizedZoom.MapRange(0.1f, 0.4f, 0f, 1f, true) * CloudVisibility.Evaluate(DayFloat())), Cloudiness, Offset.y));
		CloudSystemMat.SetVector("_LightDir", base.transform.forward);
		CloudSystemMat.SetColor("_LightCol", SunLight.color);
		CloudSystemMat.SetColor("_LightCol2", skyColor);
		Graphics.Blit(CloudSourceTex, CloudTex, CloudMat);
		float time = ((float)Hour + Minute / 60f) / 24f;
		float value = LightOnage.Evaluate(time);
		_actualScraperWindow.SetFloat("_WindowOn", value);
		Shader.SetGlobalFloat("_DataOverlayFactor", DataOverlay.HasActive ? 1 : 0);
		ClockMat.SetFloat("_Rot", ((float)Hour + Minute / 60f) % 12f / 12f);
		ClockMat.SetFloat("_Rot2", Minute / 60f);
		for (int num3 = 0; num3 < BeltMats.Length; num3++)
		{
			Material obj = BeltMats[num3];
			Vector2 mainTextureOffset = obj.mainTextureOffset;
			obj.mainTextureOffset = new Vector2(mainTextureOffset.x, (mainTextureOffset.y - Time.deltaTime * GameSettings.GameSpeed * 1.5f * (float)(1 + num3)) % 1f);
		}
		GrassPlane.gameObject.SetActive(Options.GrassQuality > 0 && GameSettings.Instance.ActiveFloor >= 0);
		RenderSettings.skybox.SetVector("_LightDir", -base.transform.forward);
		RenderSettings.skybox.SetColor("_LightColor", SunLight.color);
		RenderSettings.skybox.SetColor("_FogColor", RenderSettings.fogColor);
		if (GameSettings.Instance.ActiveFloor >= 0)
		{
			MainProbe.backgroundColor = RenderSettings.fogColor;
			ProbeGround.material.color = GetGroundColor();
		}
	}

	private void UpdateTemperature()
	{
		float time = YearFloat();
		Temperature = CurrentWeather.TempMin.Evaluate(time) + CurrentWeather.TemperatureCurve.Evaluate(DayFloat()) * CurrentWeather.TempRange.Evaluate(time);
	}

	private float ToFloat()
	{
		return Minute + ((float)Hour + ((float)Day + ((float)Month + (float)Year * 12f) * (float)GameSettings.DaysPerMonth) * 24f) * 60f;
	}

	private float YearFloat()
	{
		return ((float)Month + ((float)Day + ((float)Hour + Minute / 60f) / 24f) / (float)GameSettings.DaysPerMonth) / 12f;
	}

	private float DayFloat()
	{
		return ((float)Hour + Minute / 60f) / 24f;
	}

	private float[] ToTime(float d)
	{
		int num = Mathf.FloorToInt(d);
		return new float[4]
		{
			d % 60f,
			num / 60 % 24,
			num / 1440 % 12,
			num / 17280
		};
	}

	private float[] GetHUDTime(float d)
	{
		float[] array = ToTime(d);
		if (HUD.Instance != null && HUD.Instance.BuildMode)
		{
			float value = HUD.Instance.SunSlider.value;
			array[0] = value * 840f % 60f;
			array[1] = Mathf.Floor(value * 14f);
		}
		return array;
	}

	public void SimulateMinutes(float minuteDelta)
	{
		if (!(minuteDelta > 0f))
		{
			return;
		}
		GameSettings.Instance.ReduceHeat(minuteDelta);
		GameSettings.Instance.SimulateWork(SDateTime.Now(), minuteDelta);
		GameSettings.Instance.UpdateUtilities(minuteDelta, true);
		for (int i = 0; i < GameSettings.Instance.sRoomManager.Rooms.Count; i++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[i];
			if (!room.Outdoors)
			{
				room.RefreshGerms(minuteDelta);
				room.RefreshSmell(minuteDelta);
			}
		}
		GameSettings.Instance.BoxController.AddSkippedMinutes(minuteDelta);
	}

	public bool AddHour(bool canBankrupt, float minuteDelta)
	{
		SimulateMinutes(minuteDelta);
		hasUpdatedDate = false;
		Hour++;
		int month = Month;
		if (Hour == 24)
		{
			Hour = 0;
			AddDay();
		}
		GameSettings.Instance.UtilityTurn(month != Month);
		UpdateTemperature();
		return UpdateHour(canBankrupt);
	}

	public void AddDay()
	{
		RealTimeDayStart = Time.realtimeSinceStartup;
		hasUpdatedDate = false;
		Day++;
		if (Day == GameSettings.DaysPerMonth)
		{
			Day = 0;
			Month++;
			if (Month == 12)
			{
				Month = 0;
				Year++;
				NetworkManager.SetLobbyMetaData("CurrentYear", Year.ToString());
			}
			UpdateDay();
			if (UpdateMonth() && ShouldAutoSave() && GameSettings.Instance.MyCompany.Money > 0.0)
			{
				SaveGameManager.Instance.AutoSave();
			}
		}
		else
		{
			UpdateDay();
			if (ShouldAutoSave() && GameSettings.Instance.MyCompany.Money > 0.0)
			{
				SaveGameManager.Instance.AutoSave();
			}
		}
		if (NetworkManager.IsClient)
		{
			NetworkMessaging.SendPlayerReady(NetworkPlayer.ReadyStatus.OkayToSave, NetworkMessaging.MessageTarget.Host, 0);
		}
	}

	private bool ShouldAutoSave()
	{
		if (Options.ShouldAutoSave)
		{
			if (NetworkManager.IsHost)
			{
				return NetworkManager.Instance.Players.Count == 1;
			}
			return true;
		}
		return false;
	}

	public void UpdateSunEffectiveness()
	{
		SunEffectiveness = (1f - GetSnowTemp(0f)) * GetLightLevel(GetDayColor(Hour, Minute)).MapRange(0.3f, 1f, 0f, 1f, true) * Cloudiness.MapRange(0.1f, 0.8f, 1f, 0.1f, true);
	}

	private void AddServerLoss(IServerItem i, float use, float electricity)
	{
		ILossable lossable;
		if ((lossable = i as ILossable) != null)
		{
			lossable.AddLoss(use * Server.GetISPCost() / 24f / (float)GameSettings.DaysPerMonth, SoftwareProduct.LossType.Hosting, false);
			lossable.AddLoss(electricity, SoftwareProduct.LossType.Server, false);
		}
	}

	private bool UpdateHour(bool canBankrupt)
	{
		if (GameSettings.Instance.MissedSink > 0)
		{
			GameSettings.Instance.MissedSink--;
		}
		UpdateSunEffectiveness();
		SunEffectivenessSum += SunEffectiveness;
		HUD.Instance.complaintWindow.RefreshComplaints();
		if (!BusScript.Present)
		{
			RoadManager.Instance.CreateCar(0).Init();
			BusScript.Present = true;
		}
		for (int i = 0; i < GameSettings.Instance.DDoS.Count; i++)
		{
			KeyValuePair<SoftwareProduct, int> keyValuePair = GameSettings.Instance.DDoS[i];
			if (keyValuePair.Key.DevCompany.IsLocalPlayer || keyValuePair.Key.DevCompany.IsPlayerOwned() || keyValuePair.Key.ExternalHostingActive)
			{
				GameSettings.Instance.DDoS.RemoveAt(i);
				i--;
				continue;
			}
			keyValuePair.Key.HandleLoad((keyValuePair.Value < 0) ? 1f : 0f);
			if (keyValuePair.Value == 12)
			{
				Newspaper.Instance.AddNewStory(SDateTime.Now(), new Newspaper.Story("DDoSNewsTitle".Loc(keyValuePair.Key.DevCompany), "DDoSNewsDesc".Loc(keyValuePair.Key), Newspaper.Section.Industry, null, float.PositiveInfinity), true);
			}
			int num = keyValuePair.Value - 1;
			if (num == -13)
			{
				GameSettings.Instance.DDoS.RemoveAt(i);
				i--;
			}
			else
			{
				GameSettings.Instance.DDoS[i] = new KeyValuePair<SoftwareProduct, int>(keyValuePair.Key, num);
			}
		}
		SDateTime date = GetDate();
		if (date > GameSettings.Instance.NextOnlookerCheck)
		{
			UpdateOnlookerStatus();
		}
		ServerGroup[] array = GameSettings.Instance.GetAllServerGroups().ToArray();
		Dictionary<string, HashSet<ServerGroup>> dictionary = new Dictionary<string, HashSet<ServerGroup>>();
		foreach (ServerGroup serverGroup in array)
		{
			if (serverGroup.PowerSum != 0f || serverGroup.Fallback == null)
			{
				continue;
			}
			_fallbackVisit.Clear();
			ServerGroup serverGroup2 = GameSettings.Instance.GetServerGroup(serverGroup.Fallback);
			while (serverGroup2 != null && serverGroup2.PowerSum == 0f && serverGroup2.Fallback != null && !serverGroup.Name.Equals(serverGroup2.Fallback))
			{
				serverGroup2 = GameSettings.Instance.GetServerGroup(serverGroup2.Fallback);
				if (!_fallbackVisit.Add(serverGroup2))
				{
					serverGroup2 = null;
				}
			}
			if (serverGroup2 != null)
			{
				if (!dictionary.ContainsKey(serverGroup2.Name))
				{
					dictionary[serverGroup2.Name] = new HashSet<ServerGroup>();
				}
				dictionary[serverGroup2.Name].Add(serverGroup);
			}
		}
		float bandwidth = 1f.BandwidthFactor(date);
		int num2 = 0;
		float num3 = 0f;
		float electricityPrice = Furniture.GetElectricityPrice();
		float num4 = Mathf.Clamp01((GameSettings.Instance.LastWattUse > 0f) ? (GameSettings.Instance.LastWattSaved / GameSettings.Instance.LastWattUse) : 0f);
		GameSettings.Instance.LastWattSaved = 0f;
		GameSettings.Instance.LastWattUse = 0f;
		_cloudUsage.Clear();
		foreach (ServerGroup serverGroup3 in array)
		{
			if (serverGroup3.PowerSum == 0f && serverGroup3.Fallback != null)
			{
				serverGroup3.Available = 1f;
				continue;
			}
			byte cloudProvider = serverGroup3.CloudProvider;
			Dictionary<IServerItem, float> dictionary2 = serverGroup3.Items.ToDictionary((IServerItem x) => x, (IServerItem x) => x.GetLoadRequirement() * bandwidth);
			bool flag = serverGroup3.IsCloud;
			HashSet<ServerGroup> value;
			if (dictionary.TryGetValue(serverGroup3.Name, out value))
			{
				foreach (ServerGroup item in value)
				{
					flag |= item.IsCloud;
					foreach (IServerItem item2 in item.Items)
					{
						dictionary2[item2] = item2.GetLoadRequirement() * bandwidth;
					}
				}
			}
			float num5 = 0f;
			float num6 = 0f;
			foreach (KeyValuePair<IServerItem, float> item3 in dictionary2)
			{
				num5 += item3.Value;
				if (cloudProvider > 0)
				{
					_cloudUsage.AddUp(cloudProvider, item3.Value);
				}
				else if (item3.Key.UsesISP)
				{
					num6 += item3.Value;
				}
			}
			float num7 = 0f;
			float num8 = ((serverGroup3.PowerSum == 0f) ? 0f : (num5 / serverGroup3.PowerSum));
			serverGroup3.Available = ((num8 > 1f) ? 0f : (1f - num8));
			serverGroup3.LastUsed = Mathf.Min(serverGroup3.PowerSum, num5);
			float num9 = Mathf.Max(1f, num8 + 0.25f);
			if (!float.IsNaN(num9) && !float.IsInfinity(num9))
			{
				if (cloudProvider > 0)
				{
					num7 += num5 * ((NetworkServer)serverGroup3.Servers.First()).Cost / 24f / (float)GameSettings.DaysPerMonth;
				}
				else
				{
					foreach (Server item4 in serverGroup3.Servers.OfType<Server>())
					{
						if (!item4.furn.IsReferenceNull())
						{
							item4.furn.upg.AtrophyModifier = num9;
							item4.furn.UseModifier = num8;
							num7 += item4.furn.CurrentWattage * 0.03f * electricityPrice;
						}
					}
				}
			}
			if (cloudProvider == 0)
			{
				num7 *= 1f - num4;
			}
			if (dictionary2.Count > 0)
			{
				if (num5 < serverGroup3.PowerSum)
				{
					num3 += num5;
					GameSettings.Instance.ServerCost += num6 * Server.GetISPCost() / 24f / (float)GameSettings.DaysPerMonth;
					foreach (KeyValuePair<IServerItem, float> item5 in dictionary2)
					{
						item5.Key.HandleLoad(1f);
						if (item5.Value > 0f)
						{
							AddServerLoss(item5.Key, (cloudProvider == 0 && item5.Key.UsesISP) ? item5.Value : 0f, num7 * (item5.Value / num5));
						}
					}
				}
				else
				{
					num3 += serverGroup3.PowerSum;
					GameSettings.Instance.ServerCost += Mathf.Min(num6, serverGroup3.PowerSum) * Server.GetISPCost() / 24f / (float)GameSettings.DaysPerMonth;
					num2++;
					float num10 = ((num5 == 0f) ? 1f : Mathf.Clamp01(serverGroup3.PowerSum / num5));
					foreach (KeyValuePair<IServerItem, float> item6 in dictionary2)
					{
						item6.Key.HandleLoad(num10);
						if (item6.Value > 0f)
						{
							AddServerLoss(item6.Key, (cloudProvider == 0 && item6.Key.UsesISP) ? (item6.Value * num10) : 0f, num7 * (item6.Value / num5));
						}
					}
				}
			}
			if (!flag)
			{
				continue;
			}
			float num11 = serverGroup3.PowerSum * serverGroup3.Available;
			for (int num12 = 0; num12 < NetworkManager.Instance.Players.Count; num12++)
			{
				NetworkPlayer networkPlayer = NetworkManager.Instance.Players[num12];
				if (!networkPlayer.Self)
				{
					float power = num11 + serverGroup3.GetLoadFor(networkPlayer.ID) * bandwidth;
					NetworkMessaging.SendUpdateCloudService(NetworkManager.LocalPlayerID, -1f, power, NetworkMessaging.MessageTarget.Specifically, networkPlayer.ID);
				}
			}
		}
		if (GameSettings.Instance.IsNetworkMode)
		{
			for (int num13 = 0; num13 < NetworkManager.Instance.Players.Count; num13++)
			{
				NetworkPlayer networkPlayer2 = NetworkManager.Instance.Players[num13];
				if (networkPlayer2.Self)
				{
					continue;
				}
				Company playerCompany = MarketSimulation.Active.GetPlayerCompany(networkPlayer2.ID);
				if (((playerCompany != null) ? playerCompany.CloudService : null) != null)
				{
					float orDefault = _cloudUsage.GetOrDefault(networkPlayer2.ID, 0f);
					_cloudUsage.Remove(networkPlayer2.ID);
					NetworkMessaging.SendUpdateCloudUsage(NetworkManager.LocalPlayerID, networkPlayer2.ID, orDefault, true, NetworkMessaging.MessageTarget.Host, 0);
					if (orDefault > 0f)
					{
						float num14 = orDefault * playerCompany.CloudService.Cost / 24f / (float)GameSettings.DaysPerMonth;
						GameSettings.Instance.MyCompany.MakeTransaction(0f - num14, Company.TransactionCategory.Bills, true, "CloudService");
						playerCompany.MakeTransaction(num14, Company.TransactionCategory.Contracts, true, "CloudService", true);
					}
				}
			}
			foreach (KeyValuePair<byte, float> item7 in _cloudUsage)
			{
				NetworkMessaging.SendUpdateCloudUsage(NetworkManager.LocalPlayerID, item7.Key, item7.Value, true, NetworkMessaging.MessageTarget.Host, 0);
				Company playerCompany2 = MarketSimulation.Active.GetPlayerCompany(item7.Key);
				if (playerCompany2 != null)
				{
					float num15 = item7.Value * playerCompany2.CloudService.Cost / 24f / (float)GameSettings.DaysPerMonth;
					GameSettings.Instance.MyCompany.MakeTransaction(0f - num15, Company.TransactionCategory.Bills, true, "CloudService");
					playerCompany2.MakeTransaction(num15, Company.TransactionCategory.Contracts, true, "CloudService", true);
				}
			}
		}
		if (array.Length != 0)
		{
			GameSettings.Instance.RegisterStat("ServerBandwidth", num3 / 24f / (float)GameSettings.DaysPerMonth);
			if (num2 > 0)
			{
				GameSettings.Instance.RegisterStat("ServerFailure", num2);
			}
		}
		BadServerCounter.SetNumber(num2);
		IServerItem[] array2 = GameSettings.Instance.UnsupportedServerItems.ToArray();
		for (int num16 = 0; num16 < array2.Length; num16++)
		{
			array2[num16].HandleLoad(0f);
		}
		foreach (Team value3 in GameSettings.Instance.sActorManager.Teams.Values)
		{
			value3.HR.Update(value3);
		}
		GameSettings.Instance.sRoomManager.TempGroups.ForEachEnum(delegate(TemperatureGroup x)
		{
			x.RefreshUseValues();
		});
		float useModifier = Windiness.magnitude.MapRange(0.01f, 0.02f, 0f, 1f, true);
		for (int num17 = 0; num17 < GameSettings.Instance.sRoomManager.AllFurniture.Count; num17++)
		{
			Furniture furniture = GameSettings.Instance.sRoomManager.AllFurniture[num17];
			if (furniture.TurnOffTimer.HasValue && date >= furniture.TurnOffTimer.Value)
			{
				furniture.TurnOffTimer = null;
				furniture.IsOn = false;
			}
			if (furniture.TempControlType != Furniture.TemperatureType.None && furniture.IsOn)
			{
				bool flag2 = furniture.TempControlType == Furniture.TemperatureType.Cooling;
				if (furniture.TemperatureController)
				{
					if (furniture.TempGroup != null)
					{
						AchievementController.SetInteraction(AchievementController.Mechanics.Temperatureregulation);
						float num18 = (flag2 ? furniture.TempGroup.CoolUse : furniture.TempGroup.HeatUse);
						furniture.upg.AtrophyModifier = num18 * furniture.GetTempCapacity().MapRange(1f, 1.5f, 1f, 2f, true);
						furniture.UseModifier = num18;
						furniture.upg.DegradeMonths(1f / 24f / (float)GameSettings.DaysPerMonth);
					}
					else
					{
						furniture.upg.AtrophyModifier = 0f;
						furniture.UseModifier = 0f;
					}
				}
				else if (!furniture.TemperatureOutput)
				{
					if (furniture.TemperatureModifyUsage)
					{
						float num19 = (flag2 ? furniture.Parent.TempCoolDirectUsage : furniture.Parent.TempHeatDirectUsage);
						furniture.upg.AtrophyModifier = num19;
						furniture.UseModifier = num19;
					}
					if (furniture.HasUpg && furniture.upg.ManualDegrade)
					{
						furniture.upg.DegradeMonths(1f / 24f / (float)GameSettings.DaysPerMonth);
					}
				}
			}
			else if (furniture.Type.Equals("Solarpanel") && furniture.IsOn)
			{
				furniture.UseModifier = SunEffectiveness;
			}
			else if (furniture.Type.Equals("WindTurbine") && furniture.IsOn)
			{
				furniture.UseModifier = useModifier;
			}
		}
		for (int num20 = 0; num20 < GameSettings.Instance.sRoomManager.Rooms.Count; num20++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[num20];
			room.ResetTempUsage();
			room.UpdateTemperature(true);
			if (Hour == 0 && Day == 0 && Month == 6)
			{
				room.UpdateAwardValues();
			}
		}
		List<WorkItem> list = GameSettings.Instance.MyCompany.WorkItems.ToList();
		for (int num21 = 0; num21 < list.Count; num21++)
		{
			WorkItem workItem = list[num21];
			workItem.UpdateDealSender();
			SupportWork supportWork;
			LegalWork legalWork;
			if ((supportWork = workItem as SupportWork) != null)
			{
				supportWork.Simulate(date);
			}
			else if ((legalWork = workItem as LegalWork) != null && legalWork.IsLawsuit())
			{
				if (date >= legalWork.Deadline)
				{
					legalWork.Defeat();
				}
				else
				{
					legalWork.UpdateSettleStatus();
				}
			}
		}
		canSkip = CanSkip();
		if (Month == 5 && Day == 0 && Hour == 0 && NetworkManager.NotConnectedOrHost)
		{
			GameSettings.Instance.AwardWinners = AwardTrophy.GetWinners();
			NetworkMessaging.SendAwardWinners(GameSettings.Instance.AwardWinners.SelectInPlace((List<KeyValuePair<Company, string>> x) => x.SelectInPlaceList((KeyValuePair<Company, string> z) => new KeyValuePair<uint, string>(z.Key.ID, z.Value))), NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			NetworkMeta.CheckDirty();
		}
		if (Month == 5 && Day == 0 && Hour == 18 && GameSettings.Instance.AwardWinners != null)
		{
			List<KeyValuePair<Company, string>>[] awardWinners = GameSettings.Instance.AwardWinners;
			GameSettings.Instance.AwardWinners = null;
			StringBuilder stringBuilder = new StringBuilder();
			for (int num22 = 0; num22 < awardWinners.Length; num22++)
			{
				List<KeyValuePair<Company, string>> list2 = awardWinners[num22];
				if (list2.Count > 2)
				{
					AwardTrophy.AwardType awardType = (AwardTrophy.AwardType)num22;
					stringBuilder.AppendLine((awardType.ToString().Loc() + ":").FontBold());
					for (int num23 = 0; num23 < 3; num23++)
					{
						KeyValuePair<Company, string> keyValuePair2 = list2[num23];
						stringBuilder.Append(num23 + 1 + ". ");
						string text = ((keyValuePair2.Key != null) ? keyValuePair2.Key.Name : "NotApplicableAbbr".Loc());
						stringBuilder.AppendLine((keyValuePair2.Value != null) ? "AwardCompanyFor".Loc(text, keyValuePair2.Value) : text);
					}
					stringBuilder.AppendLine();
				}
			}
			Newspaper.Instance.AddNewStory(date, new Newspaper.Story("AwardArticleTitle".Loc(), stringBuilder.ToString().Trim(), Newspaper.Section.Industry, null, 0f));
			if (awardWinners.Any((List<KeyValuePair<Company, string>> x) => x.Any((KeyValuePair<Company, string> z) => z.Key == GameSettings.Instance.MyCompany)))
			{
				Newspaper.Instance.AddReminder(true);
			}
			if (HUD.Instance.awardWindow.Show(awardWinners))
			{
				canSkip = false;
			}
		}
		float num24 = (from x in GameSettings.Instance.sActorManager.Staff
			where x.OnCall
			select x.employee.Salary).Sum();
		if (num24 > 0f)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(0f - num24, Company.TransactionCategory.Staff, true, "On call");
		}
		GameSettings.Instance.UpdateLawsuitQueue();
		if (GameSettings.Instance.NetworkPrintOrders.Count > 0)
		{
			for (int num25 = 0; num25 < GameSettings.Instance.NetworkPrintOrders.List.Count; num25++)
			{
				NetworkPrintDeal networkPrintDeal = GameSettings.Instance.NetworkPrintOrders.List[num25];
				if (networkPrintDeal.Client != NetworkManager.LocalPlayerID)
				{
					continue;
				}
				if (networkPrintDeal.PerDay != 0)
				{
					NetworkMessaging.SendNetworkPrintDealChange(networkPrintDeal.DealID, networkPrintDeal.Target.PhysicalCopies, NetworkMessaging.MessageTarget.Specifically, networkPrintDeal.Printer);
				}
				if (networkPrintDeal.Deadline.HasValue && SDateTime.Now() >= networkPrintDeal.Deadline.Value)
				{
					Company playerCompany3 = MarketSimulation.Active.GetPlayerCompany(networkPrintDeal.Printer);
					if (playerCompany3 != null)
					{
						if (networkPrintDeal.PhysicalCopies < networkPrintDeal.MaxCopies)
						{
							GameSettings.Instance.MyCompany.MakeTransaction(networkPrintDeal.Penalty, Company.TransactionCategory.Contracts, true, "Printjobcopies");
							playerCompany3.MakeTransaction(0f - networkPrintDeal.Penalty, Company.TransactionCategory.Contracts, true, "Printjobcopies");
						}
						else
						{
							GameSettings.Instance.MyCompany.MakeTransaction(0f - networkPrintDeal.OnCompletion, Company.TransactionCategory.Contracts, true, "Printjobcopies");
							playerCompany3.MakeTransaction(networkPrintDeal.OnCompletion, Company.TransactionCategory.Contracts, true, "Printjobcopies", true);
						}
					}
					NotificationManager.AddNotification(new NotificationMessage("FinishedPrintingJob".LocColor(networkPrintDeal), "Box", SDateTime.Now(), NotificationManager.NotificationType.Good));
					networkPrintDeal.Cancel();
					num25--;
				}
				else if (networkPrintDeal.MaxCopies != 0 && networkPrintDeal.PhysicalCopies >= networkPrintDeal.MaxCopies)
				{
					Company playerCompany4 = MarketSimulation.Active.GetPlayerCompany(networkPrintDeal.Printer);
					if (playerCompany4 != null)
					{
						GameSettings.Instance.MyCompany.MakeTransaction(0f - networkPrintDeal.OnCompletion, Company.TransactionCategory.Contracts, true, "Printjobcopies");
						playerCompany4.MakeTransaction(networkPrintDeal.OnCompletion, Company.TransactionCategory.Contracts, true, "Printjobcopies", true);
					}
					NotificationManager.AddNotification(new NotificationMessage("FinishedPrintingJob".LocColor(networkPrintDeal), "Box", SDateTime.Now(), NotificationManager.NotificationType.Good));
					networkPrintDeal.Cancel();
					num25--;
				}
			}
		}
		if (canBankrupt)
		{
			SDateTime? takeOver = GameSettings.Instance.MyCompany.TakeOver;
			if (takeOver.HasValue && SDateTime.Now() > takeOver.Value)
			{
				if (GameSettings.Instance.MyCompany.GetShareWithFounders() < 0.75)
				{
					EndGameNetwork(false);
					NewStock newStock = GameSettings.Instance.MyCompany.NewStock.FirstOrDefault((NewStock x) => !(x.Buyer is FounderShareHolder));
					double startingMoney = 0.0;
					if (newStock != null)
					{
						startingMoney = GameSettings.Instance.MyCompany.GetBuyOutPrice(newStock.Buyer) * GameSettings.Instance.MyCompany.GetShare();
					}
					string text2 = ((newStock == null) ? "" : newStock.BuyerName);
					ShowGameOverMessage("PlayerTakeOverLosePrompt".Loc(text2), false, startingMoney);
					FireEvent(TimeOfDay.OnHourPassed);
					return true;
				}
				WindowManager.Instance.ShowMessageBox("TakeOverAverted".Loc(), true, DialogWindow.DialogType.Information);
				NetworkMessaging.SendBeginTakeover(GameSettings.Instance.MyCompany.ID, 0u, NetworkMessaging.MessageTarget.Everyone, 0);
			}
			if (!Banktupcy.HasValue && GameSettings.Instance.MyCompany.Money < 0.0)
			{
				SDateTime sDateTime = SDateTime.Now();
				Banktupcy = new SDateTime(0, sDateTime.Hour - 1, sDateTime.Day, sDateTime.Month + 1, sDateTime.Year);
				WindowManager.Instance.ShowMessageBox("NewDebtLoss".Loc((Banktupcy.Value + new SDateTime(0, 1, 0, 0, 0)).ToString()), true, DialogWindow.DialogType.Warning);
				FireEvent(TimeOfDay.OnHourPassed);
				return true;
			}
			if (Banktupcy.HasValue)
			{
				SDateTime value2 = SDateTime.Now();
				SDateTime? banktupcy = Banktupcy;
				if (value2 > banktupcy)
				{
					if (GameSettings.Instance.MyCompany.Money < 0.0)
					{
						double max = BankruptcyHandler.GetMax();
						double needs = 0.0 - GameSettings.Instance.MyCompany.Money + 1000.0;
						if (max > needs)
						{
							WindowManager.Instance.ShowMessageBox("BankruptAutoPrompt".Loc(), true, DialogWindow.DialogType.Question, delegate
							{
								string msg = BankruptcyHandler.Execute(needs);
								WindowManager.Instance.ShowMessageBox(msg, true, DialogWindow.DialogType.Information);
								NotificationManager.AddNotification("NewDebtLossPass".Loc(), "Money", NotificationManager.NotificationType.Good);
								Banktupcy = null;
							}, null, delegate
							{
								EndGameNetwork(true);
								ShowGameOverMessage("BankruptLoseMsg".Loc(GameSettings.Instance.MyCompany.Money.Currency()), true, 0.0);
							});
						}
						else
						{
							EndGameNetwork(true);
							ShowGameOverMessage("BankruptLoseMsg".Loc(GameSettings.Instance.MyCompany.Money.Currency()), true, 0.0);
						}
						FireEvent(TimeOfDay.OnHourPassed);
						return true;
					}
					NotificationManager.AddNotification("NewDebtLossPass".Loc(), "Money", NotificationManager.NotificationType.Good);
					Banktupcy = null;
				}
			}
		}
		FireEvent(TimeOfDay.OnHourPassed);
		return false;
	}

	public void ShowGameOverMessage(string message, bool broke, double startingMoney)
	{
		GameSettings.ForcePause = true;
		GameSettings.FreezeGame = true;
		DialogWindow dialogWindow = WindowManager.SpawnDialog();
		List<KeyValuePair<string, Action>> list = new List<KeyValuePair<string, Action>>
		{
			new KeyValuePair<string, Action>("Finances", delegate
			{
				HUD.Instance.financeWindow.Window.Modal = true;
				HUD.Instance.financeWindow.Show();
			})
		};
		if (!GameSettings.Instance.IsNetworkMode && GameSettings.Instance.HasFounder && GameSettings.HasCompletedMission("Mission13"))
		{
			list.Add(new KeyValuePair<string, Action>("NewCompany", delegate
			{
				List<Company> list2 = GameSettings.Instance.MyCompany.GenerateStockCompanyList();
				GameSettings.Instance.MyCompany.BuyOut((list2 == null || list2.Count == 0) ? null : list2, broke, SDateTime.Now(), false);
				GameSettings.Instance.RestartCompany(startingMoney);
			}));
		}
		list.Add(new KeyValuePair<string, Action>("Quit", EndGame));
		dialogWindow.Show(message, false, DialogWindow.DialogType.Error, list.ToArray());
	}

	private void EndGameNetwork(bool broke)
	{
		if (!NetworkManager.IsConnected)
		{
			return;
		}
		foreach (Actor actor in GameSettings.Instance.sActorManager.Actors)
		{
			if (actor.employee.NetworkID != 0)
			{
				NetworkMessaging.MoveLeadDesigner(actor.employee, null, true, true);
			}
		}
		List<Company> list = GameSettings.Instance.MyCompany.GenerateStockCompanyList();
		GameSettings.Instance.MyCompany.BuyOut((list == null || list.Count == 0) ? null : list, broke, SDateTime.Now(), false);
		GameSettings.Instance.ClearBuyouts();
		NetworkMessaging.DisconnectMyself();
		NetworkMessaging.SendAllNow();
		NetworkManager.Instance.CleanUpEverything(true);
	}

	public void EndGame()
	{
		GameSettings.ForcePause = false;
		ErrorLogging.FirstOfScene = true;
		ErrorLogging.SceneChanging = true;
		GameSettings.Instance = null;
		DevConsole.Console.SaveConsole();
		SceneManager.LoadScene("MainMenu");
	}

	private void RandomizeCloudShadows()
	{
		Windiness = new Vector2(UnityEngine.Random.value, UnityEngine.Random.value).normalized * Utilities.RandomGaussClamped(CurrentWeather.AverageWind).MapRange(0f, 1f, 0.01f, 0.02f);
		Offset = Vector2.zero;
		SunLight.cookieSize = UnityEngine.Random.Range(200, 600);
		Cloudiness = Utilities.RandomGaussClamped(0f, 0.4f) * 0.8f;
		SyncRain(NetworkMessaging.MessageTarget.EveryoneButMe, 0);
	}

	public void SyncRain(NetworkMessaging.MessageTarget target = NetworkMessaging.MessageTarget.EveryoneButMe, byte id = 0)
	{
		NetworkMessaging.SendRainSync(Windiness, SunLight.cookieSize, Cloudiness, target, id);
	}

	public void UpdateMarketingPlans()
	{
		foreach (WorkItem workItem in GameSettings.Instance.MyCompany.WorkItems)
		{
			MarketingPlan marketingPlan;
			if ((marketingPlan = workItem as MarketingPlan) != null && marketingPlan.Type == MarketingPlan.TaskType.PostMarket && workItem.GetNetworkDealState() != WorkItem.NetworkDealState.Sender)
			{
				marketingPlan.AddEffect();
			}
		}
	}

	private void UpdateDay()
	{
		GameSettings.Instance.ConferenceController.UpdateTime();
		GameSettings.Instance.FetchGrass();
		while (GameSettings.Instance.ConferenceController.IsRunning)
		{
			Thread.Sleep(10);
		}
		if (Month == 5 && Day == 0)
		{
			ConferenceController.Booth boothOf = GameSettings.Instance.ConferenceController.GetBoothOf(GameSettings.Instance.MyCompany);
			if (boothOf != null)
			{
				boothOf.Attendants.ForEach(delegate(Employee x)
				{
					if (x.MyActor != null && x.MyActor.isActiveAndEnabled)
					{
						x.MyActor.GoHomeNow = true;
					}
				});
			}
			GameSettings.Instance.ConferenceController.StartThread();
		}
		GameSettings.Instance.ConferenceController.UpdateDay();
		if (NetworkManager.NotConnectedOrHost)
		{
			NotificationManager.Instance.RollDay();
		}
		GameSettings.Instance.ResetComputerPower();
		Example.FixComponentCounts(false);
		UpdateSunColorGradient();
		if (NetworkManager.NotConnectedOrHost)
		{
			RandomizeCloudShadows();
		}
		SDateTime date = GetDate();
		if (GameSettings.Instance.Difficulty.Fires > 0f && GameSettings.HasCompletedMission("Security") && !GameSettings.Instance.RentMode && GameSettings.Instance.sActorManager.Actors.Count >= 10 && date.Month == 11 && date.Day == GameSettings.DaysPerMonth - 1)
		{
			GameSettings.Instance.SpawnFireInspectors(true);
			NotificationManager.AddNotification("FireInspectionWarning".Loc(), "Fire", NotificationManager.NotificationType.Neutral);
		}
		if (date.Day == GameSettings.DaysPerMonth - 1)
		{
			foreach (SoftwareWorkItem item in GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>())
			{
				if (!item.AutoDev && item.IsWorkOwner() && !item.WorkAddOn && item.ReleaseDate.HasValue && item.ReleaseDate.Value.EqualsVerySimple(date))
				{
					NotificationManager.AddNotification(new WorkItemNotification(item, "ReleaseDateReminder".Loc(item.SoftwareName), "Software", NotificationManager.NotificationType.Neutral));
				}
			}
		}
		if (NetworkManager.IsHost)
		{
			foreach (Company playerCompany in MarketSimulation.Active.GetPlayerCompanies())
			{
				playerCompany.SimulateFanLoss(date);
			}
		}
		else if (!NetworkManager.IsConnected)
		{
			GameSettings.Instance.MyCompany.SimulateFanLoss(date);
		}
		GameSettings.Instance.ResetUndo();
		if (NetworkManager.NotConnectedOrHost)
		{
			UpdateMarketingPlans();
		}
		GameSettings.Instance.WaterDelta = 0.0;
		GameSettings.Instance.ElectricityDelta = 0.0;
		if (GameSettings.Instance.ElectricityGenerationDelta > 0.0)
		{
			AchievementController.SetInteraction(AchievementController.Mechanics.ElectricityProduced);
		}
		GameSettings.Instance.ElectricityGenerationDelta = 0.0;
		GameSettings.Instance.GasDelta = 0.0;
		float num = 0f;
		for (int num2 = 0; num2 < GameSettings.Instance.sRoomManager.AllFurniture.Count; num2++)
		{
			Furniture furniture = GameSettings.Instance.sRoomManager.AllFurniture[num2];
			if (furniture != null)
			{
				furniture.TurnMonth();
				if (furniture.Capacity > 0 && furniture.RefillCapacity)
				{
					num += furniture.Restock(true, furniture.IsActuallyPlayerControlled());
				}
			}
		}
		if (num > 0f)
		{
			GameSettings.Instance.MyCompany.AddToBill(0f - num, Company.TransactionCategory.Bills, "FoodWaste");
		}
		SunEffectivenessSum = 0f;
		foreach (SoftwareAlpha item2 in GameSettings.Instance.PressBuildQueue)
		{
			if (!item2.Done)
			{
				double quality = item2.GetQuality();
				float months = SDateTime.GetMonths(item2.DevStart, SDateTime.Now());
				float num3 = (item2.ReleaseDate.HasValue ? (0f - SoftwareWorkItem.Lateness(item2.ReleaseDate.Value)) : (item2.DevTime - months));
				int months2 = Mathf.RoundToInt(num3);
				num3 = Mathf.Max(0f, num3) * DifficultyValues.Difficulty.MarketingEndQualityEstimate;
				float num4 = 1f / item2.DevTime / Mathf.Lerp(1f, 2f, item2.CodeArtRatio);
				double num5 = Utilities.Clamp01(quality + (double)(num3 * num4));
				double num6 = Math.Pow(num5 - 0.5, 2.0);
				num6 = ((num5 > 0.5) ? (num6 / 0.25) : (0.0 - num6));
				float rep = item2.GetRep();
				num6 *= (double)rep.WeightOne(0.9f);
				num6 *= (double)item2.PressBuildEffect;
				double perceivedMarketValue = item2.GetPerceivedMarketValue();
				num6 *= perceivedMarketValue;
				float num7 = item2.Followers / (float)item2.MaxFollowers;
				num6 *= (double)Mathf.Clamp01(10f * num7).WeightOne(0.85f);
				double number = SoftwareProduct.CalculateSequelBonus(item2.SequelTo, item2.SWCategory.PerceivedValue(item2.GetFeatures(), item2.TechLevels), item2.CreativityScore, item2.Submarkets, item2.SubscriptionBased, date);
				num6 *= number.WeightOne(0.10000000149011612);
				if (!item2.AddOn)
				{
					num6 *= SoftwareProduct.GetCreativityFactor(item2.CreativityScore, true);
				}
				float pressBuildEffect = item2.PressBuildEffect;
				item2.PressBuildEffect = 0f;
				if (!item2.ReleaseDate.HasValue)
				{
					num6 *= 0.25;
				}
				float followerWish = MarketingPlan.GetFollowerWish(item2.MaxFollowers);
				item2.Followers += (float)(num6 * (double)followerWish * 0.5);
				item2.FollowerChange += (float)(num6 * (double)followerWish * 0.10000000149011612);
				if (!item2.AutoDev && !PublisherDeal.HasDeal(item2, "Marketing"))
				{
					string companyName = item2.GetLocalCompanyOwner().Name;
					item2.FixReviewRep(ref companyName, ref rep);
					Newspaper.GeneratePressbuildReview(new ArticleGenerator.PressBuildReviewData(companyName, item2.SoftwareName, (float)num5, (float)perceivedMarketValue, pressBuildEffect, num7, rep, months2, item2.ReleaseDate));
				}
				item2.MarketingDone();
			}
		}
		GameSettings.Instance.PressBuildQueue.Clear();
		foreach (Deal value in HUD.Instance.dealWindow.AllDeals.Values)
		{
			if (value != null && value.Active)
			{
				float num8 = value.Payout();
				if (num8 > 0f && value.Company != null && value.Client != null)
				{
					string bill = value.Title();
					value.Company.MakeTransaction(num8, Company.TransactionCategory.Deals, true, bill);
					value.Client.MakeTransaction(0f - num8, Company.TransactionCategory.Deals, true, bill);
					value.MadePayment(num8);
				}
				if (value.Company != null)
				{
					float num9 = value.ReputationEffect(false) / (float)GameSettings.DaysPerMonth;
					value.Company.ChangeBusinessRep(num9, value.ReputationCategory());
					value.PerfDiff = num9;
					value.Performance += num9;
				}
			}
		}
		if (GameSettings.Instance.ContentsInsured > 0f)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(GameSettings.Instance.ContentsInsured, Company.TransactionCategory.Legal, true, "ContentInsurance");
			NotificationManager.AddNotification("ContentInsurancePayout".Loc(GameSettings.Instance.ContentsInsured.Currency()), "Umbrella", NotificationManager.NotificationType.Good);
			GameSettings.Instance.ContentsInsured = 0f;
		}
		InsuranceAccount insurance = GameSettings.Instance.Insurance;
		insurance.ActualContentInsurance = insurance.ContentInsurance;
		if (GameSettings.Instance.PassedFireInspection)
		{
			GameSettings.Instance.MyCompany.MakeTransaction((0f - insurance.GetContentBill(true)) / (float)GameSettings.DaysPerMonth, Company.TransactionCategory.Bills, true, "ContentInsurance");
		}
		lock (GameSettings.Instance.PrintOrders)
		{
			for (int num10 = 0; num10 < GameSettings.Instance.PrintOrders.Count; num10++)
			{
				PrintJob printJob = GameSettings.Instance.PrintOrders[num10];
				ContractWork contractWork;
				if (printJob.Hardware && (contractWork = printJob.Target as ContractWork) != null && (date >= contractWork.Deadline || contractWork.PhysicalCopies >= contractWork.Goal))
				{
					HUD.Instance.contractWindow.ContractResults.Items.Add(new ContractResult(contractWork, false));
					GameSettings.Instance.CancelPrintOrder(printJob, false);
					num10--;
				}
			}
		}
		if (!NetworkManager.IsClient)
		{
			GameSettings.Instance.Billboards.Values.ForEachEnum(delegate(BillboardAd x)
			{
				x.UpdateMe();
			});
			GameSettings.Instance.simulation.SimulateMonth(date);
			foreach (SoftwareProduct allProduct in GameSettings.Instance.simulation.GetAllProducts(false))
			{
				allProduct.RunScripts(ScriptSystem.EntryPoint.EndOfDay, ScriptSystem.ProductScope.GetTempScope(allProduct, date));
			}
			GameSettings.Instance.simulation.GetPlayerCompanies().ForEachEnum(delegate(Company x)
			{
				if (!x.LocalPlayer)
				{
					x.LeadBidHappening = false;
				}
			});
		}
		else
		{
			MarketSimulation.Active.ClearForClient(date);
		}
		for (int num11 = 0; num11 < GameSettings.Instance.FollowerSimulation.Count; num11++)
		{
			SoftwareWorkItem softwareWorkItem = GameSettings.Instance.FollowerSimulation[num11];
			if (!softwareWorkItem.Done)
			{
				softwareWorkItem.ReEvaluateMaxFollowers();
			}
		}
		List<WorkItem> list = GameSettings.Instance.MyCompany.WorkItems.ToList();
		for (int num12 = 0; num12 < list.Count; num12++)
		{
			list[num12].HandleUnitPayout();
			AutoDevWorkItem autoDevWorkItem;
			if (!list[num12].HandleNetworkEnding(true) && (autoDevWorkItem = list[num12] as AutoDevWorkItem) != null)
			{
				autoDevWorkItem.UpdateSupportMarket(true);
			}
		}
		HUD.Instance.ApplyProductWindowFilters();
		HUD.Instance.digitalDistributionWindow.Chart.UpdateCachedLines();
		HUD.Instance.digitalDistributionWindow.UpdateDistributionDeals();
		HUD.Instance.distributionWindow.RefreshOrders();
		if (Day != 0)
		{
			HUD.Instance.financeWindow.UpdateSheet(false);
			Newspaper.StoryRollover(date);
		}
		HUD.Instance.UpdateCashflow();
		if (GameSettings.Instance.Vacations.Count > 0)
		{
			NotificationManager.AddNotification(new EmployeeNotification("VacationNotify".LocColor(GameSettings.Instance.Vacations), "MoreEmployees", date, NotificationManager.NotificationType.Neutral, GameSettings.Instance.Vacations.Select((Actor x) => x.employee)));
			GameSettings.Instance.Vacations.Clear();
		}
		HUD.Instance.comingReleaseWindow.CheckRefresh();
		if (Sick.Count > 0)
		{
			NotificationManager.AddNotification(new EmployeeNotification("SickNotify".LocColor(Sick), "Germ", date, NotificationManager.NotificationType.Neutral, Sick.Select((Actor x) => x.employee)));
		}
		Sick.Clear();
		if (!NetworkManager.IsClient)
		{
			GameSettings.Instance.simulation.TurnLoss();
		}
		FireEvent(TimeOfDay.OnDayPassed);
		foreach (ProductDetailWindow item3 in WindowManager.FindWindowTypeEnum<ProductDetailWindow>())
		{
			item3.UpdateMe();
		}
		foreach (CompanyDetailWindow item4 in WindowManager.FindWindowTypeEnum<CompanyDetailWindow>())
		{
			item4.UpdateStocks();
		}
		if (HUD.Instance.PlayerProductWindow.Window.Shown)
		{
			HUD.Instance.PlayerProductWindow.RefreshPlayerItems();
		}
		if (HUD.Instance.digitalDistributionWindow.Window.Shown)
		{
			HUD.Instance.digitalDistributionWindow.UpdateInfo();
		}
		if (GameSettings.Instance.MyCompany.GetPlatforms().Count == 0 && !NotificationManager.CheckAggregate<DigitalDistributionWarning>(null))
		{
			NotificationManager.AddNotification(new DigitalDistributionWarning());
		}
		NetworkMessaging.SendAllIDsNow();
		List<UnlockChecker.UnlockItem> list2 = GameSettings.Instance.UnlockCheck.UpdateMe(false);
		if (list2.Count > 0)
		{
			bool flag = false;
			foreach (Furniture item5 in from x in list2
				where x.Type == UnlockChecker.UnlockType.Furniture
				select ObjectDatabase.Instance.GetFurnitureComponent(x.Name))
			{
				HUD.Instance.SetFurnitureNew(item5, true);
				flag = true;
			}
			if (flag)
			{
				HUD.Instance.RefreshBuildButtons();
			}
			NotificationManager.AddNotification(new NewUnlockNotification(list2));
		}
		CheckFounder();
		NetworkMeta.CheckDirty();
		MarketSimulation.Active.GetAllCompanies().ForEachEnum(delegate(Company x)
		{
			x.MarketEvents.RemoveAll((MarketEvent z) => !z.IsValid());
		});
	}

	private void CheckFounder()
	{
		HashSet<Employee> holders = (from x in GameSettings.Instance.MyCompany.NewStock.Select((NewStock x) => x.Buyer).OfType<FounderShareHolder>()
			select x.Founder).ToHashSet();
		Actor actor = GameSettings.Instance.sActorManager.Actors.FirstOrDefault((Actor x) => x.employee.Founder && !holders.Contains(x.employee));
		bool hasFounder = GameSettings.Instance.HasFounder;
		GameSettings.Instance.HasFounder = actor != null;
		if (hasFounder && !GameSettings.Instance.HasFounder)
		{
			NotificationManager.AddNotification(new MissingFounderNotification());
		}
	}

	public void AddToSick(Actor self)
	{
		Sick.Add(self);
	}

	private bool UpdateMonth()
	{
		bool result = true;
		int workers = Month;
		switch (workers)
		{
		case 0:
			UISoundFX.ChangeMusicState("Spring");
			break;
		case 3:
			UISoundFX.ChangeMusicState("Summer");
			break;
		case 6:
			UISoundFX.ChangeMusicState("Autumn");
			break;
		case 9:
			UISoundFX.ChangeMusicState("Winter");
			break;
		}
		List<SoftwareWorkItem> list = GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>().ToList();
		SDateTime date = GetDate();
		for (int i = 0; i < list.Count; i++)
		{
			SoftwareWorkItem softwareWorkItem = list[i];
			if (softwareWorkItem.contract != null)
			{
				softwareWorkItem.UpdateContract();
			}
		}
		GameSettings.Instance.Billboards.Values.ForEachEnum(delegate(BillboardAd x)
		{
			x.UpdatePrice();
		});
		GameSettings.Instance.ApplicantScore.TurnMonth();
		HUD.Instance.dealWindow.CancelDueWork(NetworkManager.IsClient);
		HUD.Instance.dealWindow.GenerateBid();
		BoxController boxController = GameSettings.Instance.BoxController;
		boxController.BoxesShippedLast = boxController.BoxesShipped;
		boxController.BoxesShipped = 0;
		if (GameSettings.Instance.Difficulty.Burglaries > 0f && GameSettings.HasCompletedMission("Security"))
		{
			GameSettings.Instance.LastBurglarSpawn++;
			float burglarWorth = GameSettings.Instance.GetBurglarWorth();
			if (burglarWorth > 1000f)
			{
				float num = burglarWorth.MapRange(0f, 100000f, 60f, 12f, true);
				if ((float)GameSettings.Instance.LastBurglarSpawn >= num && UnityEngine.Random.value < 0.25f)
				{
					int count = Mathf.RoundToInt(burglarWorth.MapRange(15000f, 100000f, 1f, 4f, true));
					GameSettings.Instance.SpawnBurglar(count, true);
					GameSettings.Instance.LastBurglarSpawn = 0;
				}
			}
		}
		foreach (Actor actor in GameSettings.Instance.sActorManager.Actors)
		{
			if (!actor.IgnoreOffSalary)
			{
				if (actor.TakingCourses)
				{
					GameSettings.Instance.MyCompany.MakeTransaction(0f - actor.GetMonthlySalary(), Company.TransactionCategory.Salaries, true);
				}
				else if (actor.SpecialState == Actor.HomeState.Vacation)
				{
					float benefitValue = actor.GetBenefitValue("Paid vacation");
					if (benefitValue > 0f)
					{
						GameSettings.Instance.MyCompany.MakeTransaction((0f - benefitValue) * actor.GetMonthlySalary(), Company.TransactionCategory.Benefits, true, "Paid vacation");
					}
				}
			}
			if (Month == 0 && !actor.employee.Dismissed)
			{
				float num2 = actor.ChristmasBonus * actor.GetMonthlySalary();
				if (num2 > 0f)
				{
					GameSettings.Instance.MyCompany.MakeTransaction(0f - num2, Company.TransactionCategory.Benefits, true, "Christmas bonus");
				}
				actor.ChristmasBonus = actor.GetBenefitValue("Christmas bonus");
			}
			actor.IgnoreOffSalary = false;
		}
		if (GameSettings.Instance.IdlePay > 0f)
		{
			GameSettings.Instance.MyCompany.AddToBill(0f - GameSettings.Instance.IdlePay, Company.TransactionCategory.Salaries, "Idle");
		}
		GameSettings.Instance.IdlePay = 0f;
		foreach (Team value2 in GameSettings.Instance.sActorManager.Teams.Values)
		{
			value2.HR.SpentLast = value2.HR.Spent;
			value2.HR.Spent = 0f;
		}
		for (int num3 = 0; num3 < GameSettings.Instance.PlayerPlots.Count; num3++)
		{
			PlotArea plotArea = GameSettings.Instance.PlayerPlots[num3];
			if (plotArea.MonthsLeft > 0)
			{
				plotArea.MonthsLeft--;
				GameSettings.Instance.MyCompany.MakeTransaction(0f - plotArea.Monthly, Company.TransactionCategory.Bills, false, "Plot");
				GameSettings.Instance.MyCompany.AddTax(TaxReport.TaxType.Interest, 0f - plotArea.MonthlyInterest);
			}
		}
		HUD.Instance.contractWindow.UpdateContracts(date);
		if (GameSettings.Instance.SalaryDue > 0f)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(0f - GameSettings.Instance.SalaryDue, Company.TransactionCategory.Salaries, true);
			GameSettings.Instance.SalaryDue = 0f;
		}
		if (GameSettings.Instance.NightSalaryDue > 0f)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(0f - GameSettings.Instance.NightSalaryDue, Company.TransactionCategory.Salaries, true, "NightShiftCompensation");
			GameSettings.Instance.NightSalaryDue = 0f;
		}
		if (GameSettings.Instance.StaffSalaryDue > 0f)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(0f - GameSettings.Instance.StaffSalaryDue, Company.TransactionCategory.Staff, true, "Salary");
			GameSettings.Instance.StaffSalaryDue = 0f;
		}
		foreach (Actor actor2 in GameSettings.Instance.sActorManager.Actors)
		{
			if (!actor2.WorksForFree())
			{
				float benefitValue2 = actor2.GetBenefitValue("Pension");
				actor2.RetirementFund += benefitValue2;
				GameSettings.Instance.MyCompany.MakeTransaction(0f - benefitValue2, Company.TransactionCategory.Benefits, true, "Pension");
			}
		}
		if (GameSettings.Instance.ElectricityBill > 0f)
		{
			GameSettings.Instance.MyCompany.MakeTransaction((0f - GameSettings.Instance.ElectricityBill) * Furniture.GetElectricityPrice(), Company.TransactionCategory.Bills, true, "Electricity");
			GameSettings.Instance.ElectricityBill = 0f;
		}
		if (GameSettings.Instance.ElectricityIncome > 0f)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(GameSettings.Instance.ElectricityIncome * Furniture.GetElectricityPrice() * 0.25f, Company.TransactionCategory.Bills, true, "ElectricityToGrid");
			GameSettings.Instance.ElectricityIncome = 0f;
		}
		if (GameSettings.Instance.Waterbill > 0f)
		{
			GameSettings.Instance.MyCompany.MakeTransaction((0f - GameSettings.Instance.Waterbill) * Furniture.GetWaterPrice(), Company.TransactionCategory.Bills, true, "Water");
			GameSettings.Instance.Waterbill = 0f;
		}
		if (GameSettings.Instance.Gasbill > 0f)
		{
			GameSettings.Instance.MyCompany.MakeTransaction((0f - GameSettings.Instance.Gasbill) * Furniture.GetGasPrice(), Company.TransactionCategory.Bills, true, "Gas");
			GameSettings.Instance.Gasbill = 0f;
		}
		if (GameSettings.Instance.ServerCost > 0f)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(0f - GameSettings.Instance.ServerCost, Company.TransactionCategory.Bills, true, "Internet");
			GameSettings.Instance.ServerCost = 0f;
		}
		if (GameSettings.Instance.RentMode)
		{
			float num4 = GameSettings.Instance.sRoomManager.Rooms.Where((Room x) => x.PlayerOwned).SumSafe((Room x) => BuildController.GetRoomCost(x, false, true));
			GameSettings.Instance.MyCompany.MakeTransaction(0f - num4, Company.TransactionCategory.Bills, true, "Rent");
		}
		GameSettings.Instance.PaybackLoan();
		HUD.Instance.loanWindow.UpdateLoans();
		InsuranceAccount insurance = GameSettings.Instance.Insurance;
		double num5 = insurance.Money * InsuranceAccount.MonthlyInterest;
		GameSettings.Instance.Insurance.UpdateAccrued(num5);
		GameSettings.Instance.MyCompany.AddToCashflow(num5, Company.TransactionCategory.Interest);
		GameSettings.Instance.MyCompany.AddTax(TaxReport.TaxType.Investments, num5);
		insurance.Money += num5;
		insurance.UpdateDeposits();
		GameSettings.Instance.simulation.EndDay(date);
		GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>().ForEachEnum(delegate(SoftwareWorkItem x)
		{
			x.LastWorked.Clear();
		});
		foreach (uint subsidiary in GameSettings.Instance.MyCompany.Subsidiaries)
		{
			SimulatedCompany simulatedCompany = GameSettings.Instance.simulation.GetCompany(subsidiary) as SimulatedCompany;
			if (simulatedCompany != null)
			{
				simulatedCompany.CheckSubsidiaryBankruptcy();
			}
		}
		HUD.Instance.UpdateCashflow();
		BiggestGrowth();
		Newspaper.StoryRollover(date);
		List<float> value = null;
		if (GameSettings.Instance.MyCompany.Cashflow.TryGetValue("Balance", out value) && value.Count > 1)
		{
			float num6 = 0f;
			int num7 = 0;
			float num8 = 0f;
			float num9 = 1f;
			for (int num10 = 1; num10 < Mathf.Min(7, value.Count); num10++)
			{
				num6 += (value[value.Count - num10] - value[value.Count - num10 - 1]) * num9;
				num8 += num9;
				num7++;
				num9 = num9 / 3f * 2f;
			}
			HUD.Instance.BankruptcyWarning.SetActive(GameSettings.Instance.MyCompany.Money + GameSettings.Instance.Insurance.Money + (double)(num6 / num8 * (float)num7) < 0.0);
		}
		else
		{
			HUD.Instance.BankruptcyWarning.SetActive(false);
		}
		if (Month == 0 || Month == 3)
		{
			if (Month == 0 && GameSettings.Instance.MyCompany.LastTaxReport != null)
			{
				TaxReport lastTaxReport = GameSettings.Instance.MyCompany.LastTaxReport;
				float salary;
				lastTaxReport.GetWorkersNeeded(out workers, out salary);
				double cost = lastTaxReport.GetCost();
				if (lastTaxReport.IllegalActions || (cost > 0.0 && (double)salary <= cost))
				{
					NotificationManager.AddNotification(new TaxNotification(lastTaxReport.FinalValue(true), cost, GameSettings.Instance.WouldBeAudited(lastTaxReport)));
				}
			}
			HUD.Instance.financeWindow.CheckTaxes();
		}
		if (Month == 11)
		{
			HUD.Instance.wageWindow.List.Items.Clear();
			foreach (Actor actor3 in GameSettings.Instance.sActorManager.Actors)
			{
				actor3.ApplyNewBenefits();
				if (actor3.employee.DemandsRequested != 0 || (!actor3.employee.Dismissed && !actor3.WorksForFree() && (actor3.NegotiateSalary || !(SDateTime.GetMonths(actor3.employee.LastWage, date) < 8f)) && actor3.WageNegotiationNecessary()))
				{
					if (actor3.employee.DemandsRequested == 0 && actor3.Team != null && actor3.GetTeam().Leader != actor3 && actor3.GetTeam().CheckHRLevel(1) && actor3.GetTeam().HR.HandleWages)
					{
						Team team = actor3.GetTeam();
						team.HR.HandleWage(actor3, team);
					}
					else
					{
						HUD.Instance.wageWindow.List.Items.Add(actor3);
					}
				}
			}
			if (HUD.Instance.wageWindow.List.Items.Count > 0)
			{
				HUD.Instance.wageWindow.Show(true);
				result = false;
			}
		}
		else
		{
			foreach (Actor item in GameSettings.Instance.sActorManager.Actors.Where((Actor x) => x.NegotiateSalary || x.employee.DemandsRequested != 0))
			{
				if (item.employee.DemandsRequested == 0 && (item.employee.Dismissed || item.WorksForFree() || !item.WageNegotiationNecessary()))
				{
					item.NegotiateSalary = false;
				}
				else if (item.employee.DemandsRequested == 0 && item.Team != null && item.GetTeam().Leader != item && item.GetTeam().CheckHRLevel(1) && item.GetTeam().HR.HandleWages)
				{
					Team team2 = item.GetTeam();
					team2.HR.HandleWage(item, team2);
				}
				else
				{
					HUD.Instance.wageWindow.List.Items.Add(item);
				}
			}
			if (HUD.Instance.wageWindow.List.Items.Count > 0)
			{
				HUD.Instance.wageWindow.Show(true);
				result = false;
			}
		}
		if (NetworkManager.NotConnectedOrHost)
		{
			bool flag = false;
			for (int num11 = 0; num11 < GameSettings.Instance.StockMarkets.Count; num11++)
			{
				StockMarket s = GameSettings.Instance.StockMarkets[num11];
				s.Simulate(false);
				if (s.Value < 0f)
				{
					GameSettings.Instance.Investments.RemoveAll((Investment x) => x.Stock == s);
					GameSettings.Instance.StockMarkets.RemoveAt(num11);
					num11--;
					flag = true;
				}
			}
			for (int num12 = GameSettings.Instance.StockMarkets.Count; num12 < 5; num12++)
			{
				GameSettings.Instance.GenerateStockMarket();
			}
			for (int num13 = 0; num13 < GameSettings.Instance.MetalMarkets.Count; num13++)
			{
				GameSettings.Instance.MetalMarkets[num13].Simulate(true);
			}
			if (flag)
			{
				HUD.Instance.insuranceWindow.UpdateInvestments();
			}
		}
		if (HUD.Instance.insuranceWindow.Window.Shown && HUD.Instance.insuranceWindow.Stocks.isOn)
		{
			HUD.Instance.insuranceWindow.UpdateStocks();
		}
		GameSettings.Instance.FlipBills();
		HUD.Instance.employeeWindow.UpdateEdNumber();
		HUD.Instance.financeWindow.UpdateSheet(false);
		HUD.Instance.UpdateFurnitureButtons();
		HUD.Instance.eventWindow.UpdateEvents();
		HUD.Instance.researchWindow.UpdateLists();
		HUD.Instance.hireWindow.HireWin.HirePool.ForEachEnum(delegate(KeyValuePair<KeyValuePair<Employee.EmployeeRole, Employee.WageBracket>, List<Employee>> x)
		{
			x.Value.Clear();
		});
		HUD.Instance.hireWindow.HireWin.BonusPool = UnityEngine.Random.Range(0, 25);
		HUD.Instance.dealWindow.CleanUpAllDeals();
		foreach (EmployeeTermination item2 in HUD.Instance.insuranceWindow.Terminations.Items.OfType<EmployeeTermination>().ToList())
		{
			float months = SDateTime.GetMonths(item2.Date, date);
			if (months >= 36f)
			{
				HUD.Instance.insuranceWindow.Terminations.Items.Remove(item2);
			}
			else if (months >= 12f)
			{
				item2.Specs = null;
				item2.Skills = null;
			}
		}
		if (HUD.Instance.hireWindow.Window.Shown)
		{
			HUD.Instance.hireWindow.UpdateCost();
		}
		CalendarWindow.ScheduleRefresh = true;
		GameSettings.Instance.Insurance.UpdateInsuranceRate();
		FireEvent(TimeOfDay.OnMonthPassed);
		if (Month == 0 && NetworkManager.IsClient)
		{
			NetworkMessaging.SendSyncMoney(null, null, NetworkMessaging.MessageTarget.Host, 0);
		}
		return result;
	}

	private float GetCompanyGrowthNumber(Company c)
	{
		List<float> list = c.Cashflow["Balance"];
		List<float> value;
		float num = (c.Cashflow.TryGetValue("Loan", out value) ? value.Last() : 0f);
		if (list.Count <= 5)
		{
			return 0f;
		}
		return list[list.Count - 1] - list[list.Count - 2] - num;
	}

	private void BiggestGrowth()
	{
		Company company = GameSettings.Instance.simulation.GetAllCompanies().MaxInstance(delegate(Company x)
		{
			float companyGrowthNumber2 = GetCompanyGrowthNumber(x);
			return companyGrowthNumber2 * (companyGrowthNumber2 / (float)x.Money);
		});
		float companyGrowthNumber = GetCompanyGrowthNumber(company);
		if (companyGrowthNumber > 10000f && (double)companyGrowthNumber / company.Money > 0.25)
		{
			Newspaper.GenerateGrowth(company, companyGrowthNumber);
		}
	}

	public void SkipTime()
	{
		if (canSkip)
		{
			HashSet<Actor> hashSet = GameSettings.Instance.sActorManager.Others["Guests"];
			List<Actor> list = hashSet.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				Actor actor = list[i];
				if (!(actor != null) || !actor.enabled)
				{
					continue;
				}
				if (actor.MyCar != null)
				{
					actor.MyCar.SpawnPoints[actor.CarSpawnID].Occupants.Remove(actor);
					if (!actor.MyCar.AnyOccupants())
					{
						actor.MyCar.CanDestroy = true;
					}
					actor.MyCar = null;
				}
				actor.DestroyGO();
				hashSet.Remove(actor);
			}
			RoadManager.Instance.Cars.Where((CarScript x) => x.CanDestroy).ToList().ForEach(delegate(CarScript x)
			{
				RoadManager.Instance.DestroyCar(x);
			});
			BusScript.Present = false;
		}
		IsSkipping = true;
		if (canSkip && !GameSettings.ForcePause)
		{
			UISoundFX.PlaySFX("SkipDay");
		}
		bool flag = false;
		while (canSkip && !GameSettings.ForcePause)
		{
			float minuteDelta = 60f - Minute;
			Minute = 0f;
			flag |= AddHour(!flag, minuteDelta);
		}
		if (WaitingOnNetwork())
		{
			float minuteDelta2 = 60f - Minute;
			SimulateMinutes(minuteDelta2);
			SetupTimeSync();
			GameSettings.Instance.wasSkipping = true;
		}
		UpdateTimeInMinutes();
		SyncPlayerTime();
		IsSkipping = false;
		GameSettings.Instance.sActorManager.Others["Parent"].ForEachEnum(delegate(Actor x)
		{
			x.UpdateParentState();
		});
	}

	public static void SyncPlayerTime()
	{
		NetworkMessaging.SendPlayerTime(Instance.Hour, Instance.Minute, GameSettings.GameSpeed, HUD.Instance.BuildMode, AFKChecker.IsAFK(), NetworkMessaging.MessageTarget.EveryoneButMe, 0);
	}

	public bool WaitingOnNetwork()
	{
		if (NetworkManager.IsConnected)
		{
			return Hour == 23;
		}
		return false;
	}

	public bool CanSkip()
	{
		if (WaitingOnNetwork())
		{
			return false;
		}
		if (GameSettings.Instance.IsReferenceNull() || HUD.Instance == null)
		{
			return false;
		}
		if (GameSettings.Instance.MyCompany.LeadBidHappening)
		{
			return false;
		}
		if (GameSettings.Instance.MyCompany.Money < 0.0 && Banktupcy.HasValue && SDateTime.GetHours(SDateTime.Now(), Banktupcy.Value) < 3.5f)
		{
			return false;
		}
		SDateTime? takeOver = GameSettings.Instance.MyCompany.TakeOver;
		if (takeOver.HasValue && GameSettings.Instance.MyCompany.GetShare() < 0.75 && SDateTime.GetHours(SDateTime.Now(), takeOver.Value) < 3.5f)
		{
			return false;
		}
		if (GameSettings.Instance.HasDanger())
		{
			return false;
		}
		if (GameSettings.Instance.sActorManager.ReadyForBus.Count > 0 || GameSettings.Instance.sActorManager.Actors.Any((Actor x) => x != null && x.IsInitialized && x.enabled && x.SpecialState != Actor.HomeState.Sleeping) || GameSettings.Instance.sActorManager.Staff.Any((Actor x) => x != null && x.IsInitialized && x.StaffBlockTimeSkip()) || GameSettings.Instance.sActorManager.Others.Any((KeyValuePair<string, HashSet<Actor>> x) => !x.Key.Equals("Parent") && !x.Key.Equals("Guests") && x.Value.Any((Actor z) => z != null && z.IsInitialized && z.enabled)))
		{
			return false;
		}
		List<Actor> awaiting = GameSettings.Instance.sActorManager.GetAwaiting();
		if (awaiting.Count == 0)
		{
			return false;
		}
		foreach (Actor item in awaiting.Where((Actor x) => x != null && x.AItype != AI.AIType.Parent))
		{
			SDateTime? arriveTime = GameSettings.Instance.sActorManager.GetArriveTime(item);
			if (arriveTime.HasValue && (arriveTime.Value - GetDate()).ToInt() <= 59)
			{
				return false;
			}
		}
		if (RoadManager.Instance.Cars.Any((CarScript x) => x != null && x.AnyDeadOccupants(false)))
		{
			return false;
		}
		return true;
	}

	public void UpdateTime(SDateTime time)
	{
		Minute = time.Minute;
		Hour = time.Hour;
		Day = time.Day;
		Month = time.Month;
		Year = time.Year;
		hasUpdatedDate = false;
		UpdateTimeInMinutes();
	}

	public static SDateTime GetDateLocked()
	{
		if (Instance == null)
		{
			return default(SDateTime);
		}
		if (Instance.DateOverride.HasValue)
		{
			return Instance.DateOverride.Value;
		}
		lock (Instance.TimeLock)
		{
			return Instance.GetDate();
		}
	}

	public SDateTime GetDate(bool forceUpdate = false)
	{
		if (!hasUpdatedDate || forceUpdate)
		{
			currentDate = new SDateTime((int)Minute, Hour, Day, Month, Year);
			hasUpdatedDate = true;
		}
		return currentDate;
	}

	private static void UpdateOnlookerStatus()
	{
		GameSettings.Instance.NextOnlookerCheck = SDateTime.Now() + UnityEngine.Random.Range(0.5f, 1.5f);
		HashSet<Room> visited = new HashSet<Room>();
		foreach (Furniture item in GameSettings.Instance.sRoomManager.GetFurniture("PreciousMetal"))
		{
			if (CheckRoom(item.Parent, visited, true))
			{
				float num = Mathf.Max(0.01f, (1f - GameSettings.Instance.Heat / 10000000f) * 0.5f);
				GameSettings.Instance.AddHeat(num, true);
				NotificationManager.AddNotification(new DismissableIssue("MetalSpotted".Loc(item.GetActualString(), num.ToPercent()), "Money"));
				break;
			}
		}
		for (int i = 0; i < GameSettings.Instance.sRoomManager.Rooms.Count; i++)
		{
			GameSettings.Instance.sRoomManager.Rooms[i].OnlookerVisited = false;
		}
	}

	private static bool CheckRoom(Room r)
	{
		return CheckRoom(r, new HashSet<Room>(), true);
	}

	private static bool CheckRoom(Room r, HashSet<Room> visited, bool cont)
	{
		if (visited.Add(r))
		{
			if (r.Outdoors || r.Outside || r.OnlookerVisited)
			{
				return true;
			}
			if (cont)
			{
				for (int i = 0; i < r.Edges.Count; i++)
				{
					WallEdge wallEdge = r.Edges[i];
					WallEdge wallEdge2 = r.Edges[(i + 1) % r.Edges.Count];
					Room room = wallEdge2.GetRoom(wallEdge);
					HashSet<WallSnap> value;
					if ((room != null && visited.Contains(room)) || (room == null && r.Floor < 0) || !wallEdge.Children.TryGetValue(wallEdge2, out value))
					{
						continue;
					}
					foreach (WallSnap item in value)
					{
						if (!(item.LightAddition > 0f))
						{
							continue;
						}
						if (room == null)
						{
							if (r.Floor >= 0)
							{
								return true;
							}
							break;
						}
						if (CheckRoom(room, visited, false))
						{
							return true;
						}
						break;
					}
				}
			}
			foreach (Room atriumChild in r.GetMainAtriumParentOrSelf().GetAtriumChildren())
			{
				if (CheckRoom(atriumChild, visited, true))
				{
					return true;
				}
			}
		}
		return false;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ConferenceController : MonoBehaviour
{
	public class WayPoint
	{
		public Vector3 Position;

		public List<WayPoint> Connections = new List<WayPoint>();

		public float Score = 1f;

		public int PathCounter = int.MaxValue;

		public Booth Booth;

		public bool Stage;

		public bool Entry;

		public Vector2 StageArea;

		public WayPoint(Vector3 position, bool stage, bool entry, Vector2 stageArea)
		{
			Position = position;
			Stage = stage;
			StageArea = stageArea;
			Entry = entry;
		}

		public WayPoint PickNext(Guest guest, System.Random rng)
		{
			if (Booth != null)
			{
				return guest.CameFrom;
			}
			float num = 0f;
			for (int i = 0; i < Connections.Count; i++)
			{
				WayPoint wayPoint = Connections[i];
				if (wayPoint != guest.CameFrom && !guest.Visited.Contains(wayPoint))
				{
					num += wayPoint.Score;
				}
			}
			if (num == 0f)
			{
				return Connections[0];
			}
			float num2 = rng.NextFloat() * num;
			num = 0f;
			for (int j = 0; j < Connections.Count; j++)
			{
				WayPoint wayPoint2 = Connections[j];
				if (wayPoint2 != guest.CameFrom && !guest.Visited.Contains(wayPoint2))
				{
					num += wayPoint2.Score;
					if (num2 <= num)
					{
						return wayPoint2;
					}
				}
			}
			return Connections[0];
		}
	}

	public class Booth
	{
		public Vector3 Position;

		public WayPoint WayPoint;

		public int Counter;

		public Company Owner;

		public BoothUI UI;

		public string BoothScene;

		public float Rotation;

		public float VisitScore;

		public BoothSize Size;

		public List<IMarketable> Products = new List<IMarketable>();

		public List<Employee> Attendants = new List<Employee>();

		public Booth(WayPoint wayPoint, string boothScene, float boothRotation, float visitScore, BoothSize size)
		{
			WayPoint = wayPoint;
			Position = wayPoint.Position;
			BoothScene = boothScene;
			Rotation = boothRotation;
			Size = size;
			VisitScore = visitScore;
		}

		public void Clear()
		{
			Products.Clear();
			Attendants.Clear();
			Counter = 0;
			Owner = null;
			UI.gameObject.SetActive(true);
		}

		public void CountUp()
		{
			Counter++;
		}

		public float GetPrice()
		{
			SDateTime sDateTime = SDateTime.Now();
			return Mathf.Floor(100000f * VisitScore * (float)GetProductsNeeded(Size) * Mathf.Pow(0.95f, (float)sDateTime.Month + (float)sDateTime.Day / (float)GameSettings.DaysPerMonth) / 100f) * 100f;
		}
	}

	public class Guest
	{
		public Vector3 Position;

		public Vector3 Offset;

		public Vector3 Dir = Vector3.forward;

		public WayPoint Target;

		public WayPoint CameFrom;

		public float Timer;

		public bool Gone;

		public HashSet<WayPoint> Visited = new HashSet<WayPoint>();

		public Guest(Vector3 position, WayPoint target)
		{
			Position = position;
			Target = target;
		}
	}

	public enum ScoreType
	{
		Visit = 0,
		PathScore = 1,
		BoothScore = 2
	}

	public enum BoothSize
	{
		Tiny = 0,
		Small = 1,
		Medium = 2,
		Large = 3
	}

	public const float BoothBasePrice = 100000f;

	public float GuestScale = 0.25f;

	public float BoothScale = 2f;

	public Transform MainTransform;

	public Transform SceneNode;

	public Transform WayPointNode;

	public ConferenceActor GuestPrefab;

	public GUIWindow Window;

	public Mesh GuestMesh;

	public Material GuestMat;

	public Camera Self;

	public Camera BoothCam;

	public BoothUI BoothUIPrefab;

	public RectTransform ConfOverview;

	public VarValueSheet InfoSheet;

	public Vector2 OffsetBounds = new Vector2(-1f, 1f);

	public ConferenceWayPoint[] WayPoints;

	public float MaxConnectionDistance = 2f;

	public float GuestSpeed;

	public ScoreType DisplayType;

	public GameObject ActivePanel;

	public GameObject InActivePanel;

	public GameObject RentButton;

	public GameObject AttendantButton;

	public GameObject ProductButton;

	[NonSerialized]
	private Matrix4x4[] _guestMat = new Matrix4x4[256];

	[NonSerialized]
	private MaterialPropertyBlock _block;

	[NonSerialized]
	private int _guestMatCount;

	[NonSerialized]
	private WayPoint[] _pathGraph;

	[NonSerialized]
	private List<WayPoint> _entries = new List<WayPoint>();

	private WayPoint _stage;

	[NonSerialized]
	private List<Booth> _booths = new List<Booth>();

	[NonSerialized]
	private List<Guest> _guests = new List<Guest>();

	[NonSerialized]
	private float _lastTime;

	[NonSerialized]
	private bool _runThread;

	[NonSerialized]
	private Thread _thread;

	[NonSerialized]
	private System.Random RNG = new System.Random(10);

	[NonSerialized]
	private bool _init = true;

	[NonSerialized]
	public Scene? ActiveBoothScene;

	[NonSerialized]
	private ObjectPool<ConferenceActor> _guestPool;

	[NonSerialized]
	private Booth _activeBooth;

	[NonSerialized]
	private Dictionary<Guest, ConferenceActor> _guestView = new Dictionary<Guest, ConferenceActor>();

	public Texture2D BackTex;

	public Texture2D Depth;

	public Texture2D G2;

	public Material DepthMat;

	private Material _boothDepth;

	private CommandBuffer _mainBuffer;

	private List<Light> _boothLights = new List<Light>();

	[NonSerialized]
	private List<Guest> _removed = new List<Guest>();

	public const float SimDelta = 1f / 60f;

	public bool IsRunning
	{
		get
		{
			return _runThread;
		}
	}

	public Booth ActiveBooth
	{
		get
		{
			return _activeBooth;
		}
	}

	public static int GetEmployeesNeeded(BoothSize size)
	{
		switch (size)
		{
		case BoothSize.Tiny:
			return 1;
		case BoothSize.Small:
			return 1;
		case BoothSize.Medium:
			return 2;
		case BoothSize.Large:
			return 3;
		default:
			throw new ArgumentOutOfRangeException("size", size, null);
		}
	}

	public static int GetProductsNeeded(BoothSize size)
	{
		return GetEmployeesNeeded(size);
	}

	public void SetActiveBooth(Booth booth)
	{
		if (_activeBooth == booth)
		{
			return;
		}
		_activeBooth = booth;
		UpdateBoothInfo();
		if (_boothDepth == null)
		{
			_boothDepth = new Material(DepthMat);
		}
		ConferenceBooth.Booth booth2 = ObjectDatabase.Instance.Booths.First((ConferenceBooth.Booth x) => x.Name.Equals(booth.BoothScene));
		for (int num = 0; num < booth2.Lights.Count; num++)
		{
			ConferenceBooth.BoothLight boothLight = booth2.Lights[num];
			Light light;
			if (num >= _boothLights.Count)
			{
				light = new GameObject("bLight" + num).AddComponent<Light>();
				light.cullingMask = 512;
				light.transform.SetParent(base.transform.parent.parent);
				_boothLights.Add(light);
			}
			else
			{
				light = _boothLights[num];
				light.gameObject.SetActive(true);
			}
			light.type = boothLight.Type;
			light.range = boothLight.Range;
			light.intensity = boothLight.Intensity;
			light.spotAngle = boothLight.Angle;
			light.color = boothLight.Color;
			light.transform.position = boothLight.Position + new Vector3(-256f, 0f, -256f);
			light.transform.rotation = Quaternion.Euler(boothLight.Rotation);
		}
		for (int num2 = booth2.Lights.Count; num2 < _boothLights.Count; num2++)
		{
			_boothLights[num2].gameObject.SetActive(false);
		}
		_boothDepth.mainTexture = booth2.Depth;
		BoothCam.RemoveAllCommandBuffers();
		CommandBuffer commandBuffer = new CommandBuffer();
		RenderTargetIdentifier renderTargetIdentifier = new RenderTargetIdentifier(BoothCam.targetTexture.depthBuffer);
		commandBuffer.SetRenderTarget(renderTargetIdentifier);
		commandBuffer.Blit(null, renderTargetIdentifier, _boothDepth);
		commandBuffer.Blit(booth2.Normal, BuiltinRenderTextureType.GBuffer2);
		BoothCam.AddCommandBuffer(CameraEvent.BeforeGBuffer, commandBuffer);
		commandBuffer = new CommandBuffer();
		renderTargetIdentifier = new RenderTargetIdentifier(BoothCam.targetTexture.colorBuffer);
		commandBuffer.SetRenderTarget(renderTargetIdentifier);
		commandBuffer.Blit(booth2.Color, renderTargetIdentifier);
		BoothCam.AddCommandBuffer(CameraEvent.AfterGBuffer, commandBuffer);
		BoothCam.fieldOfView = booth2.CamFOV;
		BoothCam.farClipPlane = booth2.CamFar;
		BoothCam.nearClipPlane = booth2.CamNear;
		BoothCam.transform.position = booth2.CamPos + new Vector3(-256f, 0f, -256f);
		BoothCam.transform.rotation = Quaternion.Euler(booth2.CamRot);
	}

	public void Show()
	{
		if (Window.ToggleReturn())
		{
			UpdateBoothInfo();
		}
	}

	public void RentBooth()
	{
		if (_activeBooth != null && _activeBooth.Owner == null)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(0f - _activeBooth.GetPrice(), Company.TransactionCategory.Marketing, "Convention");
			_activeBooth.Owner = GameSettings.Instance.MyCompany;
			UpdateBoothInfo();
		}
	}

	public void PickAttendants()
	{
		List<Actor> acts = GameSettings.Instance.sActorManager.Actors.Where((Actor x) => !x.employee.Dismissed).ToList();
		string[] array = acts.SelectInPlace((Actor x) => x.employee.FullName + " (" + x.Team + ")");
		bool[] array2 = new bool[array.Length];
		for (int num = 0; num < _activeBooth.Attendants.Count; num++)
		{
			Employee emp = _activeBooth.Attendants[num];
			int num2 = acts.FindIndex((Actor x) => emp == x.employee);
			if (num2 >= 0)
			{
				array2[num2] = true;
			}
		}
		WindowManager.Instance.MultiWindow.ShowMulti("Employees".Loc(), array, array2, delegate(int[] res)
		{
			_activeBooth.Attendants.Clear();
			_activeBooth.Attendants.AddRange(res.Select((int x) => acts[x].employee));
			UpdateBoothInfo();
		}, true, false, false, false, null, null, GetEmployeesNeeded(_activeBooth.Size));
	}

	public void PickProducts()
	{
		List<IMarketable> ps = GameSettings.Instance.MyCompany.Products.Cast<IMarketable>().ToList();
		ps.AddRange(GameSettings.Instance.MyCompany.AddOns);
		ps.AddRange(GameSettings.Instance.MyCompany.WorkItems.OfType<IMarketable>());
		ps.RemoveAll((IMarketable x) => !x.IsMarketable());
		ps.Sort((IMarketable x, IMarketable y) => y.GetReleaseDate().CompareTo(x.GetReleaseDate()));
		string[] array = ps.SelectInPlace((IMarketable x) => x.GetName() + " (" + x.GetReleaseDate().ToExtraCompactString() + ")");
		bool[] array2 = new bool[array.Length];
		for (int num = 0; num < _activeBooth.Products.Count; num++)
		{
			IMarketable product = _activeBooth.Products[num];
			int num2 = ps.FindIndex((IMarketable x) => product == x);
			if (num2 >= 0)
			{
				array2[num2] = true;
			}
		}
		WindowManager.Instance.MultiWindow.ShowMulti("Products".Loc(), array, array2, delegate(int[] res)
		{
			_activeBooth.Products.Clear();
			_activeBooth.Products.AddRange(res.Select((int x) => ps[x]));
			UpdateBoothInfo();
		}, true, false, false, false, null, null, GetProductsNeeded(_activeBooth.Size));
	}

	public bool IsInBooth(Employee emp)
	{
		return false;
	}

	public bool IsInBooth(Company c, Employee emp)
	{
		return false;
	}

	public void RemoveFromBooth(Company c, Employee emp)
	{
	}

	public Booth GetBoothOf(Company c)
	{
		return null;
	}

	public void UpdateBoothInfo()
	{
		if (!Window.isActiveAndEnabled)
		{
			return;
		}
		if (_activeBooth != null)
		{
			InfoSheet.gameObject.SetActive(true);
			bool flag = SDateTime.Now().Month >= 5;
			RentButton.SetActive(!flag && _activeBooth.Owner == null && _booths.None((Booth x) => x.Owner == GameSettings.Instance.MyCompany));
			bool active = !flag && _activeBooth.Owner == GameSettings.Instance.MyCompany;
			AttendantButton.SetActive(active);
			ProductButton.SetActive(active);
			InfoSheet.Actions = null;
			if (_activeBooth.Owner != null)
			{
				List<string> list = new List<string>(new string[3]
				{
					"Company".Loc(),
					"Size".Loc(),
					"Employees".Loc()
				});
				List<string> list2 = new List<string>(new string[2]
				{
					_activeBooth.Owner.Name,
					_activeBooth.Size.ToString().Loc()
				});
				List<Action> list3 = new List<Action>(new Action[2]
				{
					delegate
					{
						HUD.Instance.companyWindow.ShowCompanyDetails(_activeBooth.Owner);
					},
					null
				});
				if (_activeBooth.Attendants.Count == 0)
				{
					list2.Add("None".Loc());
					list3.Add(null);
				}
				else
				{
					for (int num = 0; num < _activeBooth.Attendants.Count; num++)
					{
						if (num > 0)
						{
							list.Add("");
						}
						Employee att = _activeBooth.Attendants[num];
						list2.Add(att.FullName);
						list3.Add(delegate
						{
							HUD.Instance.DetailWindow.Show(att.MyActor);
						});
					}
				}
				list.Add("Products".Loc());
				if (_activeBooth.Products.Count == 0)
				{
					list2.Add("None".Loc());
					list3.Add(null);
				}
				else
				{
					for (int num2 = 0; num2 < _activeBooth.Products.Count; num2++)
					{
						if (num2 > 0)
						{
							list.Add("");
						}
						IMarketable marketable = _activeBooth.Products[num2];
						list2.Add(marketable.GetName());
						SoftwareProduct sw;
						AddOnProduct add;
						if ((sw = marketable as SoftwareProduct) != null)
						{
							list3.Add(delegate
							{
								HUD.Instance.GetProductWindow(null).ShowProductDetails(sw);
							});
						}
						else if ((add = marketable as AddOnProduct) != null)
						{
							list3.Add(delegate
							{
								HUD.Instance.GetProductWindow(null).ShowAddonDetails(add);
							});
						}
						else
						{
							list3.Add(null);
						}
					}
				}
				InfoSheet.Actions = list3.ToArray();
				InfoSheet.SetData(list.ToArray(), list2.ToArray());
			}
			else
			{
				InfoSheet.SetData(new string[4]
				{
					"Size".Loc(),
					"Cost".Loc(),
					"Employees".Loc(),
					"Products".Loc()
				}, new string[4]
				{
					_activeBooth.Size.ToString().Loc(),
					_activeBooth.GetPrice().Currency(),
					GetEmployeesNeeded(_activeBooth.Size).ToString(),
					GetProductsNeeded(_activeBooth.Size).ToString()
				});
			}
		}
		else
		{
			InfoSheet.gameObject.SetActive(false);
			RentButton.SetActive(false);
			AttendantButton.SetActive(false);
			ProductButton.SetActive(false);
		}
	}

	private IEnumerator LoadScene(string sceneName)
	{
		if (GameSettings.Instance.ConferenceController.ActiveBoothScene.HasValue)
		{
			AsyncOperation del = SceneManager.UnloadSceneAsync(GameSettings.Instance.ConferenceController.ActiveBoothScene.Value);
			GameSettings.Instance.ConferenceController.ActiveBoothScene = null;
			yield return new WaitUntil(() => del.isDone);
		}
		int index = SceneManager.sceneCount;
		AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		yield return new WaitUntil(() => op.isDone);
		Scene sceneAt = SceneManager.GetSceneAt(index);
		GameSettings.Instance.ConferenceController.ActiveBoothScene = sceneAt;
		GameObject[] rootGameObjects = sceneAt.GetRootGameObjects();
		Camera camera = null;
		GameObject[] array = rootGameObjects;
		foreach (GameObject gameObject in array)
		{
			gameObject.transform.position = gameObject.transform.position + new Vector3(-256f, 0f, -256f);
			Camera componentInChildren = gameObject.GetComponentInChildren<Camera>();
			if (componentInChildren != null)
			{
				camera = componentInChildren;
			}
		}
		if (camera != null)
		{
			Camera boothCam = GameSettings.Instance.ConferenceController.BoothCam;
			RenderTexture targetTexture = boothCam.targetTexture;
			int cullingMask = boothCam.cullingMask;
			boothCam.CopyFrom(camera);
			boothCam.transform.position = camera.transform.position;
			boothCam.transform.rotation = camera.transform.rotation;
			boothCam.targetTexture = targetTexture;
			boothCam.cullingMask = cullingMask;
			UnityEngine.Object.DestroyImmediate(camera.gameObject);
		}
	}

	private void Start()
	{
		Init();
	}

	public void UpdateDay()
	{
	}

	public void UpdateActive()
	{
		SDateTime sDateTime = SDateTime.Now();
		bool flag = sDateTime.Month > 5 || (sDateTime.Month == 5 && sDateTime.Day > 0);
		InActivePanel.SetActive(flag);
		ActivePanel.SetActive(!flag);
	}

	public void UnreserveBooth(Company c)
	{
		for (int i = 0; i < _booths.Count; i++)
		{
			Booth booth = _booths[i];
			if (booth.Owner == c)
			{
				booth.Owner = null;
			}
		}
	}

	public void ActivateRender(bool en)
	{
		BoothCam.enabled = en;
		Self.enabled = en;
	}

	private void Init()
	{
	}

	private Dictionary<ConferenceWayPoint, WayPoint> InitMap(bool withUI)
	{
		Dictionary<ConferenceWayPoint, WayPoint> dictionary = new Dictionary<ConferenceWayPoint, WayPoint>();
		_pathGraph = new WayPoint[WayPoints.Length];
		for (int i = 0; i < WayPoints.Length; i++)
		{
			ConferenceWayPoint conferenceWayPoint = WayPoints[i];
			_pathGraph[i] = new WayPoint(conferenceWayPoint.transform.position, conferenceWayPoint.Stage, conferenceWayPoint.Entry, conferenceWayPoint.StageArea);
			dictionary[conferenceWayPoint] = _pathGraph[i];
			if (conferenceWayPoint.Booth)
			{
				Booth booth = new Booth(_pathGraph[i], conferenceWayPoint.BoothScene, conferenceWayPoint.BoothRotation, conferenceWayPoint.BoothScore, conferenceWayPoint.BoothSize);
				_booths.Add(booth);
				_pathGraph[i].Booth = booth;
				if (withUI)
				{
					BoothUI boothUI = UnityEngine.Object.Instantiate(BoothUIPrefab);
					boothUI.Self.SetParent(ConfOverview, false);
					Vector3 vector = Self.WorldToViewportPoint(booth.Position + Vector3.up * 4f);
					boothUI.Self.anchoredPosition = new Vector2(vector.x, 0f - (1f - vector.y)) * ConfOverview.rect.size;
					boothUI.MyBooth = booth;
					booth.UI = boothUI;
				}
			}
			if (conferenceWayPoint.Entry)
			{
				_entries.Add(_pathGraph[i]);
			}
			if (conferenceWayPoint.Stage)
			{
				_stage = _pathGraph[i];
			}
		}
		ConferenceWayPoint[] wayPoints = WayPoints;
		foreach (ConferenceWayPoint conferenceWayPoint2 in wayPoints)
		{
			foreach (ConferenceWayPoint connection in conferenceWayPoint2.Connections)
			{
				dictionary[conferenceWayPoint2].Connections.Add(dictionary[connection]);
				dictionary[connection].Connections.Add(dictionary[conferenceWayPoint2]);
			}
		}
		return dictionary;
	}

	private void SetPathScore(WayPoint from, float score, float strength, bool reset)
	{
		for (int i = 0; i < _pathGraph.Length; i++)
		{
			_pathGraph[i].PathCounter = int.MaxValue;
		}
		PathCounting(from);
		for (int j = 0; j < _pathGraph.Length; j++)
		{
			WayPoint wayPoint = _pathGraph[j];
			float num = Mathf.Pow(1f / (float)wayPoint.PathCounter, strength) * score;
			if (reset)
			{
				wayPoint.Score = num;
			}
			else
			{
				wayPoint.Score += num;
			}
		}
	}

	private void PathCounting(WayPoint p, int counter = 1)
	{
		if (counter < p.PathCounter)
		{
			p.PathCounter = counter;
			for (int i = 0; i < p.Connections.Count; i++)
			{
				PathCounting(p.Connections[i], counter + 1);
			}
		}
	}

	private void OnApplicationQuit()
	{
		_runThread = false;
	}

	private void OnDestroy()
	{
		_runThread = false;
	}

	public void StartThread()
	{
	}

	private void UnsetUntakenBooths()
	{
		for (int i = 0; i < _booths.Count; i++)
		{
			Booth booth = _booths[i];
			if (booth.Owner == null)
			{
				booth.WayPoint.Score = 0f;
			}
		}
	}

	public void StopThread()
	{
		_runThread = false;
	}

	private Vector3 GetRandomOffset()
	{
		return new Vector3(RNG.Range(OffsetBounds.x, OffsetBounds.y), 0f, RNG.Range(OffsetBounds.x, OffsetBounds.y));
	}

	private void OnPreCull()
	{
		Graphics.Blit(BackTex, Self.targetTexture);
		lock (_guests)
		{
			_guestMatCount = _guests.Count;
			for (int i = 0; i < _guests.Count; i++)
			{
				Guest guest = _guests[i];
				_guestMat[i] = Matrix4x4.TRS(guest.Position, Quaternion.identity, Vector3.one * GuestScale);
				if (!_guestView.ContainsKey(guest) && _activeBooth != null && _activeBooth.Position.MaxDist(guest.Position) < 4f)
				{
					ConferenceActor value = _guestPool.Get();
					_guestView[guest] = value;
				}
			}
		}
		if (_activeBooth == null && _guestView.Count > 0)
		{
			foreach (ConferenceActor value2 in _guestView.Values)
			{
				_guestPool.Release(value2);
			}
			_guestView.Clear();
		}
		if (_activeBooth != null)
		{
			Vector3 vector = Quaternion.Euler(0f, _activeBooth.Rotation, 0f) * Vector3.forward;
			vector = new Vector3(vector.x, vector.y, 0f - vector.z);
			Quaternion quaternion = Quaternion.LookRotation(vector);
			foreach (KeyValuePair<Guest, ConferenceActor> item in _guestView)
			{
				if (item.Key.Gone || _activeBooth.Position.MaxDist(item.Key.Position) >= 4f)
				{
					_removed.Add(item.Key);
					continue;
				}
				item.Value.transform.position = quaternion * (item.Key.Position - _activeBooth.Position) * BoothScale - new Vector3(256f, 0f, 256f);
				item.Value.transform.rotation = quaternion * Quaternion.LookRotation(item.Key.Dir);
				item.Value.Anim.SetInteger("State", (item.Key.Timer > 0f) ? 1 : 0);
				item.Value.Anim.speed = GameSettings.GameSpeed;
			}
		}
		if (_removed.Count > 0)
		{
			for (int j = 0; j < _removed.Count; j++)
			{
				Guest key = _removed[j];
				_guestPool.Release(_guestView[key]);
				_guestView.Remove(key);
			}
			_removed.Clear();
		}
		if (_guestMatCount > 0)
		{
			Graphics.DrawMeshInstanced(GuestMesh, 0, GuestMat, _guestMat, _guestMatCount, _block, ShadowCastingMode.On, true, 9, Self);
		}
	}

	private static bool CheckEnd(ConferenceController c, double start, double current)
	{
		if (current >= 1440.0 * ((double)(5 * GameSettings.DaysPerMonth) + 0.95))
		{
			lock (c._guests)
			{
				c._guests.Clear();
			}
			c._runThread = false;
			return true;
		}
		return false;
	}

	private static void RunThread(object controller)
	{
		ConferenceController conferenceController = (ConferenceController)controller;
		double num = conferenceController._lastTime;
		double start = Math.Floor((num + 30.0) / 60.0 / 24.0) * 60.0 * 24.0;
		double num2 = num;
		double num3 = 0.0;
		double spawnCoolDown = 10.0;
		int nextEntry = 0;
		while (conferenceController._runThread)
		{
			Thread.Sleep(16);
			try
			{
				float num4 = conferenceController._lastTime;
				if ((double)num4 < num2)
				{
					num4 += (float)(1440 * GameSettings.DaysPerMonth * 12);
				}
				double num5 = (double)num4 - num;
				num = num4;
				num5 += num3;
				num3 = 0.0;
				if (!(num5 > 0.0))
				{
					continue;
				}
				double num6 = num2 / 60.0 % 24.0;
				if (num6 < 8.0)
				{
					if (num6 + num5 / 60.0 >= 8.0)
					{
						double num7 = num2;
						num2 = Math.Floor(num2 / 60.0 / 24.0) * 60.0 * 24.0 + 480.0;
						num5 = Math.Max(0.0, num5 - (num2 - num7));
					}
					else
					{
						num2 += num5;
						num5 = 0.0;
					}
				}
				while (num5 >= 0.01666666753590107)
				{
					num5 -= 0.01666666753590107;
					lock (conferenceController._guests)
					{
						conferenceController.ThreadLogic(1f / 60f, num2, ref spawnCoolDown, ref nextEntry);
						num2 += 0.01666666753590107;
						if (CheckEnd(conferenceController, start, num2))
						{
							break;
						}
					}
				}
				num3 += num5;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}

	private void ThreadLogic(float delta, double fullTime, ref double spawnCoolDown, ref int nextEntry)
	{
		double num = fullTime / 60.0 % 24.0;
		double value = num + (double)delta / 60.0;
		num = num.Clamp(8.0, 19.0);
		value = value.Clamp(8.0, 19.0);
		double num2 = (value - num) * 60.0;
		if (num2 > 0.0)
		{
			spawnCoolDown -= num2;
			while (spawnCoolDown <= 0.0)
			{
				spawnCoolDown += 10.0;
				WayPoint wayPoint = _entries[nextEntry];
				nextEntry = (nextEntry + 1) % _entries.Count;
				Guest guest = new Guest(wayPoint.Position + GetRandomOffset(), wayPoint.Connections.GetRandom(RNG));
				guest.CameFrom = wayPoint;
				guest.Offset = GetRandomOffset();
				_guests.AddRange(guest);
			}
		}
		if (num < 19.0 && value >= 19.0)
		{
			for (int i = 0; i < _entries.Count; i++)
			{
				SetPathScore(_entries[i], 100f, 6f, i == 0);
			}
			_booths.ForEach(delegate(Booth x)
			{
				x.WayPoint.Score = 0f;
			});
			_stage.Score = 0f;
		}
		if (num < 17.5 && value >= 17.5)
		{
			SetPathScore(_stage, 100f, 6f, true);
			UnsetUntakenBooths();
		}
		if (num < 18.5 && value >= 18.5)
		{
			_pathGraph.ForEachEnum(delegate(WayPoint x)
			{
				x.Score = 1f;
			});
			_stage.Score = 0f;
		}
		for (int num3 = 0; num3 < _guests.Count; num3++)
		{
			Guest guest2 = _guests[num3];
			float num4 = delta;
			while (num4 > 0f)
			{
				if (guest2.CameFrom.Stage && num < 18.5)
				{
					guest2.Timer = 0.001f;
					break;
				}
				if (guest2.Timer > 0f)
				{
					if (num4 >= guest2.Timer)
					{
						num4 -= guest2.Timer;
						guest2.Timer = 0f;
					}
					else
					{
						guest2.Timer -= num4;
						num4 = 0f;
					}
					continue;
				}
				Vector3 vector = guest2.Target.Position + guest2.Offset;
				float magnitude = (guest2.Position - vector).magnitude;
				float num5 = num4 * GuestSpeed;
				if (magnitude <= num5)
				{
					guest2.Position = vector;
					num5 -= magnitude;
				}
				else
				{
					Vector3 vector2 = (vector - guest2.Position) / magnitude;
					guest2.Position += vector2 * num5;
					guest2.Dir = vector2;
					num5 = 0f;
				}
				num4 = num5 / GuestSpeed;
				magnitude = (guest2.Position - vector).magnitude;
				if (magnitude < ((guest2.Target.Booth != null) ? 2f : 0.1f))
				{
					if (guest2.Target.Booth != null)
					{
						guest2.Visited.Add(guest2.Target);
						guest2.Target.Booth.CountUp();
						guest2.Timer = RNG.Range(5f, 15f);
						num4 += (2f - magnitude) / GuestSpeed;
					}
					if (guest2.Target.Entry)
					{
						guest2.Gone = true;
						_guests.RemoveAt(num3);
						num3--;
						break;
					}
					WayPoint target = guest2.Target.PickNext(guest2, RNG);
					guest2.CameFrom = guest2.Target;
					guest2.Target = target;
					if (guest2.Target.Stage)
					{
						Vector2 vector3 = guest2.Target.StageArea * 0.5f;
						guest2.Offset = new Vector3(RNG.Range(0f - vector3.x, vector3.x), 0f, RNG.Range(0f - vector3.y, vector3.y));
					}
					else
					{
						guest2.Offset = ((guest2.Target.Booth != null) ? Vector3.zero : GetRandomOffset());
					}
				}
			}
		}
	}

	public void UpdateTime()
	{
		_lastTime = TimeOfDay.Instance.GetYearFloatInMinutes();
	}

	public static float GetDisplay(Booth b, ScoreType type)
	{
		switch (type)
		{
		case ScoreType.Visit:
			return b.Counter;
		case ScoreType.PathScore:
			return b.WayPoint.Score;
		case ScoreType.BoothScore:
			return b.VisitScore;
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
	}

	private void OnDrawGizmos()
	{
		if (_pathGraph != null)
		{
			float num = _pathGraph.Max((WayPoint x) => x.Score);
			WayPoint[] pathGraph = _pathGraph;
			foreach (WayPoint wayPoint in pathGraph)
			{
				Gizmos.color = Color.Lerp(Color.red, Color.green, wayPoint.Score / num);
				Gizmos.DrawWireSphere(wayPoint.Position, 0.2f);
				Gizmos.color = Color.cyan;
				foreach (WayPoint connection in wayPoint.Connections)
				{
					Gizmos.DrawLine(wayPoint.Position, connection.Position);
				}
			}
			return;
		}
		ConferenceWayPoint[] wayPoints = WayPoints;
		foreach (ConferenceWayPoint conferenceWayPoint in wayPoints)
		{
			if (conferenceWayPoint == null)
			{
				continue;
			}
			Gizmos.color = (conferenceWayPoint.Entry ? Color.magenta : (conferenceWayPoint.Booth ? Color.Lerp(Color.red, Color.green, conferenceWayPoint.BoothScore) : Color.white));
			Gizmos.DrawWireSphere(conferenceWayPoint.transform.position, 0.2f);
			if (conferenceWayPoint.Stage)
			{
				Gizmos.DrawWireCube(conferenceWayPoint.transform.position, conferenceWayPoint.StageArea.ToVector3(0f));
			}
			Gizmos.color = Color.cyan;
			foreach (ConferenceWayPoint connection2 in conferenceWayPoint.Connections)
			{
				if (connection2 != null)
				{
					Gizmos.DrawLine(conferenceWayPoint.transform.position, connection2.transform.position);
				}
			}
			if (conferenceWayPoint.Booth)
			{
				Gizmos.color = Color.red;
				int num3 = ((conferenceWayPoint.BoothSize == BoothSize.Small) ? (-45) : 0);
				Gizmos.DrawLine(conferenceWayPoint.transform.position, conferenceWayPoint.transform.position + Quaternion.Euler(0f, conferenceWayPoint.BoothRotation + (float)num3, 0f) * Vector3.forward);
			}
		}
	}
}

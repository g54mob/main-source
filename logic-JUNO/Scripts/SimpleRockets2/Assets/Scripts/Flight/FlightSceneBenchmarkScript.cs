using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Packages.DevConsole;
using Assets.Scripts.Craft;
using Assets.Scripts.DOTweenPlugins;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.State;
using Assets.Scripts.Web;
using CodeStage.AdvancedFPSCounter;
using DG.Tweening;
using ModApi;
using ModApi.CelestialData;
using ModApi.Craft;
using ModApi.Flight.GameView;
using ModApi.Scenes.Parameters;
using ModApi.Ui;
using UnityEngine;
using UnityEngine.Profiling;

namespace Assets.Scripts.Flight
{
	public class FlightSceneBenchmarkScript : MonoBehaviour
	{
		private class BenchmarkResult
		{
			public FlightSceneBenchmarkType BenchmarkType { get; set; }

			public int FpsAverage { get; set; }

			public int FpsMax { get; set; }

			public int FpsMin { get; set; }

			public long MemoryAllocated { get; set; }

			public uint MemoryCollectionCount { get; set; }

			public long MemoryPeak { get; set; }

			public XElement GenerateXml()
			{
				XElement xElement = new XElement("Benchmark");
				xElement.Add(new XAttribute("BenchmarkType", BenchmarkType.ToString()));
				xElement.Add(new XAttribute("FpsAverage", FpsAverage));
				xElement.Add(new XAttribute("FpsMax", FpsMax));
				xElement.Add(new XAttribute("FpsMin", FpsMin));
				xElement.Add(new XAttribute("MemoryAllocated", MemoryAllocated));
				xElement.Add(new XAttribute("MemoryCollectionCount", MemoryCollectionCount));
				xElement.Add(new XAttribute("MemoryPeak", MemoryPeak));
				return xElement;
			}
		}

		private class BenchmarkScript
		{
			public Queue<FlightSceneBenchmarkType> Benchmarks { get; private set; }

			public string ResultPath { get; private set; }

			public Queue<BenchmarkResult> Results { get; private set; }

			public BenchmarkScript(string resultPath)
			{
				ResultPath = resultPath;
				Benchmarks = new Queue<FlightSceneBenchmarkType>();
				Results = new Queue<BenchmarkResult>();
			}

			public BenchmarkScript(string resultPath, params FlightSceneBenchmarkType[] benchmarks)
				: this(resultPath)
			{
				foreach (FlightSceneBenchmarkType item in benchmarks)
				{
					Benchmarks.Enqueue(item);
				}
			}

			public WebRequest UploadResults()
			{
				XElement xElement = new XElement("Results");
				for (BenchmarkResult benchmarkResult = Results.Dequeue(); benchmarkResult != null; benchmarkResult = ((Results.Count > 0) ? Results.Dequeue() : null))
				{
					xElement.Add(benchmarkResult.GenerateXml());
				}
				XElement xElement2 = new XElement("Quality");
				Game.Instance.Settings.Quality.SaveToXml(xElement2);
				WWWForm wWWForm = new WWWForm();
				wWWForm.AddField("ResultsVersion", "1");
				wWWForm.AddField("Results", xElement.ToString());
				wWWForm.AddField("Platform", Application.platform.ToString());
				wWWForm.AddField("GameVersion", Game.Version.ToString());
				wWWForm.AddField("DeviceModel", SystemInfo.deviceModel);
				wWWForm.AddField("DeviceName", SystemInfo.deviceName);
				wWWForm.AddField("DeviceId", SystemInfo.deviceUniqueIdentifier);
				wWWForm.AddField("Settings", xElement2.ToString());
				wWWForm.AddField("DeviceCaps", Game.Instance.Device.DeviceCaps);
				if (BenchmarkComment != null)
				{
					wWWForm.AddField("Comment", BenchmarkComment);
				}
				return WebRequest.Create("http://jundroo.com/service/Benchmark/Upload", wWWForm);
			}
		}

		private static FlightSceneBenchmarkType[] _atmospheretBenchmarkScript;

		private static BenchmarkScript _currentBenchmarkScript;

		private static FlightSceneBenchmarkType[] _defaultBenchmarkScript;

		private FlightSceneLoadParameters _flightSceneLoadParameters;

		private long _memoryAllocated;

		private uint _memoryCollectionCount;

		private long _memoryLastSize;

		private long _memoryPeak;

		private float _rotationAroundPlanet;

		public static string BenchmarkComment { get; private set; }

		public static int CompletedCount { get; private set; }

		public static FlightSceneBenchmarkScript CurrentBenchmark { get; private set; }

		public static bool IsBenchmarkAllowed => false;

		public FlightSceneBenchmarkType BenchmarkType { get; private set; }

		public Vector3d? CraftStartPosition { get; private set; }

		public bool IsRunning { get; private set; }

		public float PlanetScale { get; private set; }

		static FlightSceneBenchmarkScript()
		{
			_atmospheretBenchmarkScript = new FlightSceneBenchmarkType[4]
			{
				FlightSceneBenchmarkType.PlanetRotateOrbitCubemapHeight,
				FlightSceneBenchmarkType.PlanetRotateOrbitHigh,
				FlightSceneBenchmarkType.PlanetRotateSurface,
				FlightSceneBenchmarkType.PlanetSurfaceSpin
			};
			_currentBenchmarkScript = null;
			_defaultBenchmarkScript = new FlightSceneBenchmarkType[19]
			{
				FlightSceneBenchmarkType.PlanetZoomAndRotate,
				FlightSceneBenchmarkType.PlanetZoom,
				FlightSceneBenchmarkType.PlanetZoom,
				FlightSceneBenchmarkType.PlanetZoom,
				FlightSceneBenchmarkType.PlanetZoomAndRotate,
				FlightSceneBenchmarkType.PlanetZoomAndRotate,
				FlightSceneBenchmarkType.PlanetZoomAndRotate,
				FlightSceneBenchmarkType.PlanetRotateSurface,
				FlightSceneBenchmarkType.PlanetRotateSurface,
				FlightSceneBenchmarkType.PlanetRotateSurface,
				FlightSceneBenchmarkType.PlanetRotateOrbitLow,
				FlightSceneBenchmarkType.PlanetRotateOrbitLow,
				FlightSceneBenchmarkType.PlanetRotateOrbitLow,
				FlightSceneBenchmarkType.PlanetRotateOrbitHigh,
				FlightSceneBenchmarkType.PlanetRotateOrbitHigh,
				FlightSceneBenchmarkType.PlanetRotateOrbitHigh,
				FlightSceneBenchmarkType.PlanetSurfaceSpin,
				FlightSceneBenchmarkType.PlanetSurfaceSpin,
				FlightSceneBenchmarkType.PlanetSurfaceSpin
			};
			if (!IsBenchmarkAllowed)
			{
				return;
			}
			foreach (FlightSceneBenchmarkType benchmark in Enum.GetValues(typeof(FlightSceneBenchmarkType)))
			{
				if (benchmark != FlightSceneBenchmarkType.None)
				{
					DevConsoleApi.RegisterCommand("Benchmark_Flight_" + benchmark, delegate
					{
						Game.Instance.DevConsole.CloseConsole();
						RunBenchmark(benchmark);
					});
				}
			}
			DevConsoleApi.RegisterCommand("Benchmark_Flight_All", delegate
			{
				Game.Instance.DevConsole.CloseConsole();
				RunBenchmarkScriptDefault("Dev Console");
			});
		}

		public static void RunBenchmark(FlightSceneBenchmarkType benchmarkType)
		{
			if (IsBenchmarkAllowed)
			{
				Application.targetFrameRate = 0;
				QualitySettings.vSyncCount = 0;
				if (CurrentBenchmark != null)
				{
					UnityEngine.Object.Destroy(CurrentBenchmark.gameObject);
					CurrentBenchmark = null;
				}
				if (benchmarkType != FlightSceneBenchmarkType.None)
				{
					CurrentBenchmark = new GameObject("FlightSceneBenchmark_" + benchmarkType).AddComponent<FlightSceneBenchmarkScript>();
					UnityEngine.Object.DontDestroyOnLoad(CurrentBenchmark.gameObject);
					CurrentBenchmark.InitializeBenchmarkCommon(benchmarkType);
				}
				float planetScale = CurrentBenchmark.PlanetScale;
				float num = 637100f * planetScale;
				CurrentBenchmark.CraftStartPosition = null;
				switch (benchmarkType)
				{
				case FlightSceneBenchmarkType.PlanetZoom:
				case FlightSceneBenchmarkType.PlanetZoomAndRotate:
					CurrentBenchmark.CraftStartPosition = GetEarthScenarioDefaultStartPosition(num + 600000f);
					break;
				case FlightSceneBenchmarkType.PlanetRotateSurface:
					CurrentBenchmark.CraftStartPosition = GetEarthScenarioDefaultStartPosition(num + 5010f);
					break;
				case FlightSceneBenchmarkType.PlanetRotateOrbitCubemapHeight:
					CurrentBenchmark.CraftStartPosition = GetEarthScenarioDefaultStartPosition(num * 4f + 10000f);
					break;
				case FlightSceneBenchmarkType.PlanetRotateOrbitHigh:
					CurrentBenchmark.CraftStartPosition = GetEarthScenarioDefaultStartPosition(num + 400000f);
					break;
				case FlightSceneBenchmarkType.PlanetRotateOrbitLow:
					CurrentBenchmark.CraftStartPosition = GetEarthScenarioDefaultStartPosition(num + 100000f);
					break;
				case FlightSceneBenchmarkType.PlanetSurfaceSpin:
					CurrentBenchmark.CraftStartPosition = GetEarthScenarioDefaultStartPosition(num + 5010f);
					break;
				}
				LoadFlightScene(CurrentBenchmark._flightSceneLoadParameters);
			}
		}

		public static void RunBenchmarkScriptAtmosphere()
		{
			_currentBenchmarkScript = new BenchmarkScript(GetBenchmarkFilePath("Atmosphere-centric Benchmark Results.txt"), _atmospheretBenchmarkScript);
			RunBenchmark(_currentBenchmarkScript.Benchmarks.Dequeue());
		}

		public static void RunBenchmarkScriptDefault(string commentText)
		{
			BenchmarkComment = commentText;
			_currentBenchmarkScript = new BenchmarkScript(GetBenchmarkFilePath("Flight Scene Benchmark Results.txt"), _defaultBenchmarkScript);
			RunBenchmark(_currentBenchmarkScript.Benchmarks.Dequeue());
		}

		internal void StartBenchmark()
		{
			StartCoroutine(RunBenchmarkCoroutine());
		}

		protected virtual void FixedUpdate()
		{
			UpdateMemoryUsage();
		}

		protected virtual void LateUpdate()
		{
			UpdateMemoryUsage();
		}

		protected virtual void OnDestroy()
		{
			DOTween.KillAll();
		}

		protected virtual void Update()
		{
			if (!Game.InFlightScene)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				CurrentBenchmark = null;
			}
			UpdateMemoryUsage();
		}

		private static string GetBenchmarkFilePath(string name)
		{
			return Path.Combine(Device.IsUnityEditor ? "..\\Builds\\Benchmarks" : (Device.IsAndroidRuntime ? Path.Combine(Game.PersistentDataPath, "Benchmarks") : "..\\..\\..\\Builds\\Benchmarks"), name);
		}

		private static Vector3d GetEarthScenarioDefaultStartPosition(double distanceFromCenter)
		{
			return Quaterniond.Euler(0.0, 50.0, 0.0) * new Vector3d(0.0 - distanceFromCenter, 0.0, 0.0);
		}

		private static void LoadFlightScene(FlightSceneLoadParameters loadParameters = null)
		{
			Game.Instance.SceneManager.LoadFlight(loadParameters ?? FlightSceneLoadParameters.ResumeCraft());
		}

		private Transform CreateCameraTarget()
		{
			IGameCamera gameCamera = FlightSceneScript.Instance.ViewManager.GameView.GameCamera;
			ICraftNode craftNode = FlightSceneScript.Instance.CraftNode;
			Transform transform = new GameObject("CameraTargetRoot").transform;
			transform.SetParent(gameCamera.Transform.parent);
			transform.position = gameCamera.Transform.parent.position;
			transform.forward = -(Vector3)craftNode.Position.normalized;
			transform.right = Vector3.Cross(Vector3.up, transform.forward);
			Transform obj = new GameObject("CameraTarget").transform;
			obj.SetParent(transform);
			obj.SetLocalPositionAndRotation(new Vector3(0f, 0f, 100f), Quaternion.identity);
			Debug.LogWarning("Benchmark needs it's own camera controller");
			return obj;
		}

		private CraftScript HideAndFreezeShip()
		{
			CraftScript craftScript = (CraftScript)((CraftNode)FlightSceneScript.Instance.CraftNode).CraftScript;
			Rigidbody[] componentsInChildren = craftScript.GetComponentsInChildren<Rigidbody>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].isKinematic = true;
			}
			Renderer[] componentsInChildren2 = craftScript.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].enabled = false;
			}
			return craftScript;
		}

		private void InitializeBenchmarkCommon(FlightSceneBenchmarkType benchmarkType)
		{
			BenchmarkType = benchmarkType;
			FlightStateData flightStateData = new FlightStateData(Utilities.CombinePaths(Game.PersistentDataPath, "GameData/FlightStates/", "Benchmark", "FlightState.xml"));
			_flightSceneLoadParameters = new FlightSceneLoadParameters
			{
				FlightStateDataLoader = () => flightStateData,
				ResumeCraftNodeId = 1
			};
			PlanetarySystemFileData planetarySystem = Game.Instance.GameState.LoadFlightStateData().PlanetarySystem;
			XDocument xDocument = Game.Instance.CelestialDatabase.GetFile(planetarySystem.FileId).LoadFileAsXml();
			PlanetScale = ((float?)xDocument.Root.Elements("Scale").Attributes("planetScale").FirstOrDefault()) ?? 1f;
		}

		private IEnumerator MonitorMemoryCoroutine()
		{
			_memoryLastSize = Profiler.GetMonoUsedSizeLong();
			_memoryPeak = Profiler.GetTotalReservedMemoryLong();
			while (IsRunning)
			{
				yield return new WaitForFixedUpdate();
				UpdateMemoryUsage();
				yield return null;
				UpdateMemoryUsage();
				yield return new WaitForEndOfFrame();
				UpdateMemoryUsage();
			}
		}

		private IEnumerator PlanetRotateCoroutine(float planetRotation, float rotationDuration, Transform cameraTarget)
		{
			CraftNode ship = (CraftNode)FlightSceneScript.Instance.CraftNode;
			IReferenceFrame referenceFrame = FlightSceneScript.Instance.ViewManager.GameView.ReferenceFrame;
			_rotationAroundPlanet = 0f;
			Vector3d startPosition = ship.Position;
			yield return DOTween.To(() => _rotationAroundPlanet, delegate(float x)
			{
				_rotationAroundPlanet = x;
			}, planetRotation, rotationDuration).OnUpdate(delegate
			{
				ship.SetStateVectorsAtDefaultTime(Quaterniond.Euler(0.0, _rotationAroundPlanet, 0.0) * startPosition, OrbitNode.MinimumOrbitVelocity);
				ship.RecalculateFrameState(referenceFrame);
				cameraTarget.parent.forward = -(Vector3)ship.Position.normalized;
				cameraTarget.parent.right = Vector3.Cross(Vector3.up, cameraTarget.parent.forward);
			}).SetEase(Ease.Linear)
				.WaitForCompletion();
		}

		private IEnumerator PlanetSurfaceRotateCameraCoroutine(float cameraAngle, float rotationTime, Transform cameraTarget)
		{
			cameraTarget.localPosition = Quaternion.Euler(cameraAngle, 0f, 0f) * cameraTarget.localPosition;
			yield return cameraTarget.parent.DORotate(cameraTarget.parent.rotation.eulerAngles + new Vector3(0f, 0f, 90f), rotationTime / 4f).SetEase(Ease.Linear).WaitForCompletion();
			yield return cameraTarget.parent.DORotate(cameraTarget.parent.rotation.eulerAngles + new Vector3(0f, 0f, 90f), rotationTime / 4f).SetEase(Ease.Linear).WaitForCompletion();
			yield return cameraTarget.parent.DORotate(cameraTarget.parent.rotation.eulerAngles + new Vector3(0f, 0f, 90f), rotationTime / 4f).SetEase(Ease.Linear).WaitForCompletion();
			yield return cameraTarget.parent.DORotate(cameraTarget.parent.rotation.eulerAngles + new Vector3(0f, 0f, 90f), rotationTime / 4f).SetEase(Ease.Linear).WaitForCompletion();
		}

		private IEnumerator PlanetZoomCoroutine(double zoomAltitude, float surfaceCameraAngle, float zoomTime, float cameraAngleTime, Transform cameraTarget)
		{
			CraftNode craftNode = (CraftNode)FlightSceneScript.Instance.CraftNode;
			double radius = FlightSceneScript.Instance.ViewManager.GameView.PlanetNode.PlanetData.Radius;
			Vector3d endPosition = craftNode.Position - craftNode.Position.normalized * (craftNode.Position.magnitude - (radius + zoomAltitude));
			bool flag = craftNode.Position.sqrMagnitude >= endPosition.sqrMagnitude;
			Vector3 eulerAngles = cameraTarget.localRotation.eulerAngles;
			if (flag)
			{
				eulerAngles += new Vector3(0f - surfaceCameraAngle, 0f, 0f);
			}
			cameraTarget.DOLocalMove(Quaternion.AngleAxis(surfaceCameraAngle * (float)((!flag) ? 1 : (-1)), Vector3.right) * cameraTarget.localPosition, cameraAngleTime).SetDelay(flag ? (zoomTime - cameraAngleTime) : 0f).SetEase(Ease.Linear);
			cameraTarget.DOLocalRotate(eulerAngles, cameraAngleTime).SetDelay(flag ? (zoomTime - cameraAngleTime) : 0f).SetEase(Ease.Linear);
			yield return craftNode.DOMove(endPosition, zoomTime).SetEase(Ease.Linear).WaitForCompletion();
		}

		private IEnumerator RunBenchmarkCoroutine()
		{
			yield return null;
			yield return null;
			yield return null;
			yield return new WaitForEndOfFrame();
			if (!IsBenchmarkAllowed)
			{
				yield break;
			}
			GC.Collect();
			Profiler.enabled = true;
			IsRunning = true;
			AFPSCounter counter = AFPSCounter.AddToScene(keepAlive: false);
			counter.OperationMode = OperationMode.Background;
			counter.fpsCounter.AverageSamples = 0;
			counter.fpsCounter.MinMax = true;
			StartCoroutine(MonitorMemoryCoroutine());
			switch (BenchmarkType)
			{
			case FlightSceneBenchmarkType.PlanetZoom:
				yield return RunBenchmarkPlanetZoomCoroutine();
				break;
			case FlightSceneBenchmarkType.PlanetRotateOrbitCubemapHeight:
			case FlightSceneBenchmarkType.PlanetRotateOrbitHigh:
			case FlightSceneBenchmarkType.PlanetRotateOrbitLow:
				yield return RunBenchmarkPlanetRotateOrbitCoroutine();
				break;
			case FlightSceneBenchmarkType.PlanetRotateSurface:
				yield return RunBenchmarkPlanetRotateSurfaceCoroutine();
				break;
			case FlightSceneBenchmarkType.PlanetZoomAndRotate:
				yield return RunBenchmarkPlanetZoomAndRotateCoroutine();
				break;
			case FlightSceneBenchmarkType.PlanetSurfaceSpin:
				yield return RunBenchmarkPlanetSurfaceSpinCoroutine();
				break;
			}
			BenchmarkResult benchmarkResult = new BenchmarkResult
			{
				BenchmarkType = CurrentBenchmark.BenchmarkType,
				FpsAverage = counter.fpsCounter.LastAverageValue,
				FpsMin = counter.fpsCounter.LastMinimumValue,
				FpsMax = counter.fpsCounter.LastMaximumValue,
				MemoryAllocated = _memoryAllocated,
				MemoryCollectionCount = _memoryCollectionCount,
				MemoryPeak = _memoryPeak
			};
			UnityEngine.Object.Destroy(CurrentBenchmark.gameObject);
			CurrentBenchmark = null;
			IsRunning = false;
			CompletedCount++;
			if (_currentBenchmarkScript == null)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.OkayButtonText = "Run Again";
				messageDialogScript.CancelButtonText = "Exit";
				messageDialogScript.MessageText = string.Format("FPS{0}Avg: {1}{0}Min: {2}{0}Max: {3}{0}{0}Memory{0}Peak: {4}{0}Allocated: {5}{0}Collections: {6}", Environment.NewLine, benchmarkResult.FpsAverage, benchmarkResult.FpsMin, benchmarkResult.FpsMax, benchmarkResult.MemoryPeak.ToString("N0"), benchmarkResult.MemoryAllocated.ToString("N0"), benchmarkResult.MemoryCollectionCount);
				messageDialogScript.OkayClicked += delegate
				{
					RunBenchmark(BenchmarkType);
				};
				messageDialogScript.CancelClicked += delegate
				{
					LoadFlightScene();
				};
				yield break;
			}
			_currentBenchmarkScript.Results.Enqueue(benchmarkResult);
			if (_currentBenchmarkScript.Benchmarks.Count > 0)
			{
				RunBenchmark(_currentBenchmarkScript.Benchmarks.Dequeue());
				yield break;
			}
			WebRequest webRequest = _currentBenchmarkScript.UploadResults();
			MessageDialogScript messageDialogScript2 = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			CanvasGroup component = messageDialogScript2.GetComponent<CanvasGroup>();
			if (component != null)
			{
				UnityEngine.Object.Destroy(component);
			}
			messageDialogScript2.CancelButtonText = "CLOSE";
			messageDialogScript2.OkayButtonText = "VIEW";
			messageDialogScript2.MessageText = "Uploading benchmark results...";
			messageDialogScript2.OkayClicked += delegate(MessageDialogScript x)
			{
				if (webRequest.IsDone)
				{
					if (string.IsNullOrWhiteSpace(webRequest.Error))
					{
						Application.OpenURL("http://jundroo.com/service/Benchmark/View/" + webRequest.Text);
						LoadFlightScene();
					}
				}
				else
				{
					x.MessageText = $"Still uploading. Progress: {(int)(webRequest.Progress * 100f)}%";
				}
			};
			if (!string.IsNullOrWhiteSpace(webRequest.Error))
			{
				messageDialogScript2.MessageText = "Benchmark complete, but unfortunately the upload failed: " + webRequest.Error;
			}
			else
			{
				messageDialogScript2.MessageText = "Benchmark complete. Results have been uploaded to the mothership.";
			}
			_currentBenchmarkScript = null;
		}

		private IEnumerator RunBenchmarkPlanetRotateOrbitCoroutine()
		{
			HideAndFreezeShip();
			Transform cameraTarget = CreateCameraTarget();
			yield return PlanetRotateCoroutine(-720f, 30f, cameraTarget);
		}

		private IEnumerator RunBenchmarkPlanetRotateSurfaceCoroutine()
		{
			HideAndFreezeShip();
			Transform cameraTarget = CreateCameraTarget();
			yield return PlanetZoomCoroutine(5000f * PlanetScale, 70f, 1f, 1f, cameraTarget);
			yield return PlanetRotateCoroutine(-90f, 20f, cameraTarget);
		}

		private IEnumerator RunBenchmarkPlanetSurfaceSpinCoroutine()
		{
			HideAndFreezeShip();
			Transform cameraTarget = CreateCameraTarget();
			yield return PlanetSurfaceRotateCameraCoroutine(-65f, 30f, cameraTarget);
		}

		private IEnumerator RunBenchmarkPlanetZoomAndRotateCoroutine()
		{
			HideAndFreezeShip();
			Transform cameraTarget = CreateCameraTarget();
			yield return PlanetZoomCoroutine(5000f * PlanetScale, 65f, 20f, 5f, cameraTarget);
			yield return PlanetRotateCoroutine(-90f, 20f, cameraTarget);
			yield return PlanetZoomCoroutine(600000.0, 65f, 20f, 5f, cameraTarget);
		}

		private IEnumerator RunBenchmarkPlanetZoomCoroutine()
		{
			HideAndFreezeShip();
			Transform cameraTarget = CreateCameraTarget();
			yield return PlanetZoomCoroutine(5000f * PlanetScale, 65f, 20f, 5f, cameraTarget);
			yield return PlanetZoomCoroutine(600000.0, 65f, 20f, 5f, cameraTarget);
		}

		private void UpdateMemoryUsage()
		{
			if (IsRunning)
			{
				long monoUsedSizeLong = Profiler.GetMonoUsedSizeLong();
				if (monoUsedSizeLong < _memoryLastSize)
				{
					_memoryCollectionCount++;
				}
				else if (monoUsedSizeLong > _memoryLastSize)
				{
					_memoryAllocated += monoUsedSizeLong - _memoryLastSize;
				}
				_memoryLastSize = monoUsedSizeLong;
				monoUsedSizeLong = Profiler.GetTotalReservedMemoryLong();
				if (monoUsedSizeLong > _memoryPeak)
				{
					_memoryPeak = monoUsedSizeLong;
				}
			}
		}
	}
}

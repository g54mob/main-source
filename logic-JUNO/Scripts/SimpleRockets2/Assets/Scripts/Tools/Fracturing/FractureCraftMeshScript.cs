using System.Collections.Generic;
using System.Linq;
using Assets.Packages.DevConsole;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Sim;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.Flight.UI;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Tools.Fracturing
{
	public class FractureCraftMeshScript : FractureMeshScript
	{
		[SerializeField]
		private ICraftScript _craftToFracture;

		private GameObject _fractureContainer;

		[Range(0f, 20f)]
		[SerializeField]
		private int _fractureObjectLifeTime = 10;

		private Dictionary<IPartGroupScript, GameObject> _fracturePartGroups;

		private List<IFracturePieceProcessor> _fracturePieceProcessors = new List<IFracturePieceProcessor>();

		private const string EntireCraftPropertyGroup = "Craft";

		[SerializeField]
		private bool _autoSelectPlayerCraft = true;

		[SerializeField]
		private bool _enableFracturedCraftWhenDone;

		[SerializeField]
		private bool _pauseEditorWhenDone;

		private bool _simulatingExplosion;

		private Coroutine _simulatingExplosiosEndRoutine;

		[SerializeField]
		private bool _temporarilyDisableOriginalCraftMeshesWhenDone;

		public bool ExplosionEffectsEnabled { get; private set; }

		public void AddFracturePieceProcessor(IFracturePieceProcessor pieceProcessor)
		{
			_fracturePieceProcessors.Add(pieceProcessor);
		}

		public GameObject EnableCraftFracturing(ICraftScript craftScript, bool removeCurrent)
		{
			StopSimulating();
			if (_fractureContainer != null)
			{
				if (removeCurrent)
				{
					RemoveFracturePieces();
					_fracturePartGroups.Clear();
				}
			}
			else
			{
				_fractureContainer = new GameObject("FractureContainer");
				_fracturePartGroups = new Dictionary<IPartGroupScript, GameObject>();
			}
			PartGroupScript[] componentsInChildren = craftScript.Transform.GetComponentsInChildren<PartGroupScript>();
			foreach (PartGroupScript partGroupScript in componentsInChildren)
			{
				GameObject gameObject = new GameObject(partGroupScript.name);
				gameObject.transform.parent = _fractureContainer.transform;
				gameObject.transform.SetPositionAndRotation(partGroupScript.transform.position, partGroupScript.transform.rotation);
				MeshRenderer[] componentsInChildren2 = partGroupScript.transform.GetComponentsInChildren<MeshRenderer>();
				foreach (MeshRenderer meshRenderer in componentsInChildren2)
				{
					MeshFilter component = meshRenderer.GetComponent<MeshFilter>();
					Mesh mesh = component.mesh;
					if (mesh.bounds.extents.magnitude * meshRenderer.transform.lossyScale.magnitude > base.MinBoundsRadiusInitial)
					{
						int trisPerPiece = FractureMeshScript.CalculateTrisPerPiece(mesh, base.TrisPerPiece, base.TrisBasedOnPercentOfMesh);
						Material sharedMaterial = meshRenderer.sharedMaterial;
						GameObject gameObject2 = FractureMesh.ProcessMeshAndCreateObject(ProcessPiece, mesh, sharedMaterial, base.CreateColliders, trisPerPiece, base.MinBoundsRadiusPiece, base.MaxAngularSpinSpeed, base.MaxVelocity, base.CopyUvData, base.CopyUv2Data, base.CopyNormalData, FractureMesh.CreateMeshTransformInfo(component));
						if (gameObject2 != null)
						{
							gameObject2.transform.parent = gameObject.transform;
						}
					}
				}
				if (gameObject.transform.childCount == 0)
				{
					Object.Destroy(gameObject);
					continue;
				}
				partGroupScript.Disconnected += OnPartGroupDisconnected;
				_fracturePartGroups.Add(partGroupScript, gameObject);
				gameObject.SetActive(_enableFracturedCraftWhenDone);
			}
			return _fractureContainer;
		}

		protected override void Initialize()
		{
			base.Initialize();
			AddFracturePieceProcessor(new FracturePieceParticleEffects());
			DevConsoleApi.RegisterCommand("CraftExplosionSimulate", SimulateExplosionFromDevConsole);
			UpdateEventSubscriptions(subscribe: true);
		}

		protected virtual void OnPlayerCraftScriptInitialized(ICraftScript craftScript)
		{
			if (ExplosionEffectsEnabled)
			{
				EnableCraftFracturing(craftScript, removeCurrent: true);
			}
		}

		protected virtual void SetExplosionQuality(ExplosionsQualitySettings explosionQuality, bool rebuildCache)
		{
			ExplosionEffectsEnabled = explosionQuality.EnableExplosionEffects;
			if (ExplosionEffectsEnabled)
			{
				base.CreateColliders = explosionQuality.Colliders.Value == ExplosionsQualitySettings.CollidersQuality.On;
				_fractureObjectLifeTime = explosionQuality.DebrisLifeTime;
				switch (explosionQuality.PartFracturing.Value)
				{
				case ExplosionsQualitySettings.PartFracturingSizeQuality.Off:
					base.TrisBasedOnPercentOfMesh = 1f;
					break;
				case ExplosionsQualitySettings.PartFracturingSizeQuality.Large:
					base.TrisBasedOnPercentOfMesh = 0.5f;
					break;
				case ExplosionsQualitySettings.PartFracturingSizeQuality.Medium:
					base.TrisBasedOnPercentOfMesh = 1f / 3f;
					break;
				case ExplosionsQualitySettings.PartFracturingSizeQuality.Small:
					base.TrisBasedOnPercentOfMesh = 0.25f;
					break;
				}
				switch (explosionQuality.DebrisRetention.Value)
				{
				case ExplosionsQualitySettings.DebrisRetentionQuality.Low:
					base.MinBoundsRadiusInitial = 3.5f;
					base.MinBoundsRadiusPiece = 1.75f;
					break;
				case ExplosionsQualitySettings.DebrisRetentionQuality.Medium:
					base.MinBoundsRadiusInitial = 3f;
					base.MinBoundsRadiusPiece = 1.5f;
					break;
				case ExplosionsQualitySettings.DebrisRetentionQuality.High:
					base.MinBoundsRadiusInitial = 1.5f;
					base.MinBoundsRadiusPiece = 1f;
					break;
				case ExplosionsQualitySettings.DebrisRetentionQuality.Ultra:
					base.MinBoundsRadiusInitial = 0f;
					base.MinBoundsRadiusPiece = 1f;
					break;
				}
				_fracturePieceProcessors.ForEach(delegate(IFracturePieceProcessor x)
				{
					x.SetQuality(explosionQuality);
				});
				if (rebuildCache)
				{
					EnableCraftFracturing(Game.Instance.FlightScene.CraftNode.CraftScript, removeCurrent: true);
				}
			}
			else
			{
				RemoveFracturePieces();
			}
		}

		private void ActivatePartGroupDebris(IPartGroupScript partGroup)
		{
			if (_fracturePartGroups.ContainsKey(partGroup))
			{
				GameObject obj = _fracturePartGroups[partGroup];
				Transform transform = partGroup.GameObject.transform;
				obj.transform.SetPositionAndRotation(transform.position, transform.rotation);
				obj.SetActive(value: true);
				_fracturePartGroups.Remove(partGroup);
				Object.Destroy(obj, _fractureObjectLifeTime);
				obj.GetComponentInChildren<Rigidbody>().velocity += partGroup.BodyScript.RigidBody.velocity;
			}
		}

		private void OnDestroy()
		{
			UpdateEventSubscriptions(subscribe: false);
		}

		private void OnExplosionsQualityChanged(object sender, SettingsChangedEventArgs<ExplosionsQualitySettings> e)
		{
			Debug.Log("Explosion quality changed...fracturing data rebuilt.");
			SetExplosionQuality(e.Category, rebuildCache: true);
		}

		private void OnPartGroupDisconnected(IPartGroupScript source, bool isExploding)
		{
			if (isExploding)
			{
				ActivatePartGroupDebris(source);
				source.Disconnected -= OnPartGroupDisconnected;
			}
		}

		private void OnPlayerCraftNodeLoadedIntoGameView(IGameViewObject source)
		{
			(source as CraftNode).CraftScript.Initialized += OnPlayerCraftScriptInitialized;
		}

		private void OnReferenceFrameRecentered(IReferenceFrame referenceFrame, Vector3d positionDelta, Vector3d velocityDelta)
		{
			if (_fractureContainer != null)
			{
				_fractureContainer.transform.position += (Vector3)positionDelta;
				Rigidbody[] componentsInChildren = _fractureContainer.GetComponentsInChildren<Rigidbody>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].velocity += (Vector3)velocityDelta;
				}
				ParticleSystem[] componentsInChildren2 = _fractureContainer.GetComponentsInChildren<ParticleSystem>();
				for (int i = 0; i < componentsInChildren2.Length; i++)
				{
					CraftScript.RepositionParticleSystem(componentsInChildren2[i], (Vector3)positionDelta, (Vector3)velocityDelta);
				}
			}
		}

		private void OnTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			if (e.EnteredWarpMode)
			{
				RemoveFracturePieces();
			}
		}

		private void ProcessPiece(GameObject fracturePiece, Vector3? colliderWorldCenter)
		{
			_fracturePieceProcessors.ForEach(delegate(IFracturePieceProcessor x)
			{
				x.ProcessPiece(fracturePiece, colliderWorldCenter);
			});
		}

		private void RemoveFracturePieces()
		{
			StopSimulating();
			if (!(_fractureContainer != null))
			{
				return;
			}
			foreach (Transform item in _fractureContainer.transform)
			{
				_ = _fractureContainer.transform.childCount;
				Object.Destroy(item.gameObject);
			}
		}

		private void UpdateEventSubscriptions(bool subscribe)
		{
			if (!(SceneManager.GetActiveScene().name == "Flight"))
			{
				return;
			}
			ICraftNode craftNode = Game.Instance?.FlightScene?.CraftNode;
			if (craftNode != null)
			{
				if (subscribe)
				{
					craftNode.LoadedIntoGameView += OnPlayerCraftNodeLoadedIntoGameView;
				}
				else
				{
					craftNode.LoadedIntoGameView -= OnPlayerCraftNodeLoadedIntoGameView;
				}
			}
			if (Game.Instance?.FlightScene?.ViewManager?.GameView != null)
			{
				if (subscribe)
				{
					Game.Instance.FlightScene.ViewManager.GameView.ReferenceFrameRecentered += OnReferenceFrameRecentered;
				}
				else
				{
					Game.Instance.FlightScene.ViewManager.GameView.ReferenceFrameRecentered -= OnReferenceFrameRecentered;
				}
			}
			ITimeManager timeManager = Game.Instance?.FlightScene?.TimeManager;
			if (timeManager != null)
			{
				if (subscribe)
				{
					timeManager.TimeMultiplierModeChanged += OnTimeMultiplierModeChanged;
				}
				else
				{
					timeManager.TimeMultiplierModeChanged -= OnTimeMultiplierModeChanged;
				}
			}
		}

		private static void TemporarilyDisableMeshes(MeshRenderer[] meshRenderers, int seconds)
		{
			List<MeshRenderer> renderersToDisable = meshRenderers.Where((MeshRenderer x) => x.enabled).ToList();
			foreach (MeshRenderer item in renderersToDisable)
			{
				item.enabled = false;
			}
			UnityEventDispatcher.Instance.ExecuteWaitForSeconds(delegate
			{
				foreach (MeshRenderer item2 in renderersToDisable)
				{
					item2.enabled = true;
				}
			}, seconds);
		}

		private void CreateCacheEntireCraft()
		{
			if (_craftToFracture == null && _autoSelectPlayerCraft)
			{
				_craftToFracture = Game.Instance.FlightScene.CraftNode.CraftScript;
			}
			if (_craftToFracture != null)
			{
				Object.Destroy(EnableCraftFracturingDesign(_craftToFracture, removeCurrent: true), _fractureObjectLifeTime);
			}
		}

		private GameObject EnableCraftFracturingDesign(ICraftScript craftScript, bool removeCurrent)
		{
			GameObject result = EnableCraftFracturing(craftScript, removeCurrent);
			if (_temporarilyDisableOriginalCraftMeshesWhenDone)
			{
				TemporarilyDisableCraftMesh(_craftToFracture);
			}
			_ = _pauseEditorWhenDone;
			return result;
		}

		private bool IsSimulatingExplosion()
		{
			return _simulatingExplosion;
		}

		private void SimulateExplosionFromDevConsole()
		{
			Game.Instance.DevConsole.CloseConsole();
			IFlightSceneUI flightSceneUi = Game.Instance.FlightScene.FlightSceneUI;
			ICraftScript craftScript = Game.Instance.FlightScene.CraftNode.CraftScript;
			if (_simulatingExplosion)
			{
				EnableCraftFracturingDesign(craftScript, removeCurrent: true);
			}
			_simulatingExplosion = true;
			UnityEventDispatcher.Instance.ExecuteWaitForSeconds(delegate
			{
				foreach (IPartGroupScript item in _fracturePartGroups.Keys.ToList())
				{
					ActivatePartGroupDebris(item);
				}
				flightSceneUi.ShowMessage($"Simulating explosion. Cache will rebuild in DebrisLifeTime seconds ({_fractureObjectLifeTime})");
				_simulatingExplosiosEndRoutine = UnityEventDispatcher.Instance.ExecuteWaitForSeconds(delegate
				{
					if (IsSimulatingExplosion())
					{
						EnableCraftFracturingDesign(craftScript, removeCurrent: true);
						flightSceneUi.ShowMessage("Explosion data rebuilt");
						_simulatingExplosion = false;
					}
				}, _fractureObjectLifeTime);
			}, 2f);
		}

		private void StopSimulating()
		{
			if (IsSimulatingExplosion())
			{
				UnityEventDispatcher.Instance.StopCoroutine(_simulatingExplosiosEndRoutine);
				_simulatingExplosion = false;
			}
		}

		private void TemporarilyDisableCraftMesh(ICraftScript craft)
		{
			TemporarilyDisableMeshes(craft.Transform.GetComponentsInChildren<MeshRenderer>(), _fractureObjectLifeTime);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Environment;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.Flight.AI.ControlSystems;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Input.XR;
using Assets.Scripts.Menu.LevelMenuVR;
using Assets.Scripts.XR.UI.Layout;
using Jundroo.Common.Utils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR.OpenXR.Input;

namespace Assets.Scripts.XR.UI
{
	public class FlightMenuScript : MonoBehaviour
	{
		[Serializable]
		public struct ToggleButton
		{
			public RadialMenuButtonScript button;

			[NonSerialized]
			public bool enabled;

			public ToggleButton(RadialMenuButtonScript btn)
			{
				button = btn;
				enabled = false;
			}
		}

		[Header("Buttons")]
		public ToggleButton[] agButtons = new ToggleButton[8];

		public ToggleButton aiAirButton;

		public ToggleButton aiGroundButton;

		public GameObject aiHostileIcon;

		public GameObject aiNeutralIcon;

		public ToggleButton controlsButton;

		public ToggleButton dynamicWeatherButton;

		public ToggleButton kneeboardButton;

		public ToggleButton launchCatapult;

		public ToggleButton lgButton;

		public ToggleButton pauseButton;

		[FormerlySerializedAs("slowMoButton")]
		public ToggleButton timeControlButton;

		public GameObject timeFastIcon;

		public GameObject timePlayIcon;

		public GameObject timeSlowIcon;

		public ToggleButton weaponsA2A;

		public ToggleButton weaponsA2G;

		[Header("Other Components")]
		public Text targetText;

		public RadialDragArea timeDragArea;

		public RadialMenuTooltipScript tooltipScript;

		public Text weaponText;

		public ControllerLayoutScript controllerLayout;

		[Header("Settings")]
		public GameObject defaultMenu;

		public GameObject disabledDuringChallengeMenu;

		public bool dummyMode;

		public KneeboardScript kneeboard;

		public Vector3 menuOffset;

		public GameObject[] menus;

		public GameObject[] menusDisabledDuringChallenges;

		public Transform trackingSpace;

		private static List<FlightMenuScript> _instances = new List<FlightMenuScript>(2);

		[SerializeField]
		private XRHandType _handType;

		private InputAction _menuInput;

		private GameObject _vrMenuRoot;

		private bool aiHostile;

		private AircraftControls controls;

		private AircraftControls.InputOverride fireGunsOverride = new AircraftControls.InputOverride
		{
			Value = 1f
		};

		private AircraftControls.InputOverride fireWeaponsOverride = new AircraftControls.InputOverride
		{
			Value = 1f
		};

		private bool firingGuns;

		private bool firingWeapons;

		private bool menuOpen;

		private TargetingSystem targetingSystem;

		public static IReadOnlyList<FlightMenuScript> Instances => _instances;

		public bool IsOpen => menuOpen;

		public void CloseMenus()
		{
			launchCatapult.button.transform.parent.gameObject.SetActive(value: false);
			tooltipScript.gameObject.SetActive(value: false);
			menuOpen = false;
			for (int i = 0; i < menus.Length; i++)
			{
				menus[i].SetActive(value: false);
			}
		}

		public void CyclePlaySpeed()
		{
			if (PauseManager.FastForwardEnabled)
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage("Normal Speed");
				PauseManager.SetSlowMotion(enabled: false);
			}
			else if (PauseManager.SlowMotionEnabled)
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage("Fast Forward");
				PauseManager.SetFastForward(enabled: true);
			}
			else
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage("Slow Motion");
				PauseManager.SetSlowMotion(enabled: true);
			}
			UpdateTimeControlIcon();
		}

		public void DespawnAllAi()
		{
			AiManagerScript.Instance.DespawnAllAI();
			FlightSceneScript.Instance.FlightUI.ShowMessage("Removed All AI Airplanes", 3f);
		}

		public void ExitLevel()
		{
			FlightSceneScript.Instance.ExitLevel();
		}

		public RadialMenuButtonScript GetButton(string id)
		{
			GameObject[] array = menus;
			for (int i = 0; i < array.Length; i++)
			{
				RadialMenuButtonScript[] componentsInChildren = array[i].GetComponentsInChildren<RadialMenuButtonScript>(includeInactive: true);
				foreach (RadialMenuButtonScript radialMenuButtonScript in componentsInChildren)
				{
					if (radialMenuButtonScript.Id == id)
					{
						return radialMenuButtonScript;
					}
				}
			}
			return null;
		}

		public void OpenMenu(GameObject menu)
		{
			if (!Game.Instance.CurrentLevel.IsSandbox && menusDisabledDuringChallenges.Contains(menu))
			{
				menu = disabledDuringChallengeMenu;
			}
			menuOpen = menu != null;
			for (int i = 0; i < menus.Length; i++)
			{
				GameObject obj = menus[i];
				obj.SetActive(obj == menu);
			}
		}

		public void OpenVrMenu()
		{
			if (_vrMenuRoot == null)
			{
				PauseManager.RequestPauseChange(paused: true, userInitiated: false);
				UnityEngine.Pose valueOrDefault = Game.Instance.XRDeviceManager.HmdCustomOffset.GetValueOrDefault();
				_vrMenuRoot = new GameObject("LevelMenuVrRootOffset");
				_vrMenuRoot.transform.SetPositionAndRotation(valueOrDefault.position, valueOrDefault.rotation);
				GameObject obj = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Menu/VR/LevelMenuVrRoot"));
				obj.transform.parent = _vrMenuRoot.transform;
				obj.transform.localRotation = Quaternion.identity;
				obj.transform.position = valueOrDefault.position + valueOrDefault.forward * 0.25f;
				LayerUtility.SetLayerRecursive(obj.GetComponentInChildren<Canvas>().gameObject, LayerMask.NameToLayer("WorldSpaceUI"));
				obj.GetComponentInChildren<LevelMenuVRScript>().CloseAction = delegate
				{
					PauseManager.RequestPauseChange(paused: false, userInitiated: false);
					UnityEngine.Object.Destroy(_vrMenuRoot);
					_vrMenuRoot = null;
				};
			}
			else
			{
				PauseManager.RequestPauseChange(paused: false, userInitiated: false);
				UnityEngine.Object.Destroy(_vrMenuRoot);
				_vrMenuRoot = null;
			}
		}

		public void RestartLevel()
		{
			PauseManager.RequestPauseChange(paused: false, userInitiated: false);
			FlightSceneScript.Instance.Environment.OnRestartLevel();
			Game.Instance.SceneManager.LoadFlight(null, Game.Instance.SelectedCraftId);
		}

		public void SetFireGuns(bool on)
		{
			if (controls != null && firingGuns != on)
			{
				firingGuns = on;
				if (on)
				{
					controls.AddRawOverrideInput("FireGuns", fireGunsOverride);
				}
				else
				{
					controls.RemoveRawOverrideInput("FireGuns", fireGunsOverride);
				}
			}
		}

		public void SetFireWeapons(bool on)
		{
			if (controls != null && firingWeapons != on)
			{
				firingWeapons = on;
				if (on)
				{
					controls.AddRawOverrideInput("FireWeapons", fireWeaponsOverride);
				}
				else
				{
					controls.RemoveRawOverrideInput("FireWeapons", fireWeaponsOverride);
				}
			}
		}

		public void SetTime(float time)
		{
			float num = (1f - time) * 24f + 12f;
			if (num > 24f)
			{
				num -= 24f;
			}
			FlightSceneScript.Instance.Environment.UpdateTimeOfDay(num, 0.4f);
		}

		public void SetWeatherPreset(WeatherPreset preset)
		{
			FlightSceneScript.Instance.Environment.UpdateWeather(preset, 5f, ignorePause: true);
		}

		public void SetWeatherPreset(int preset)
		{
			FlightSceneScript.Instance.Environment.UpdateWeather((WeatherPreset)preset, 5f, ignorePause: true);
		}

		public void SpawnPlane(string info)
		{
			int result = 100;
			string[] array = info.Split(';');
			if (array.Length < 2)
			{
				Debug.LogError("Can't spawn with incomplete info (" + info + ")");
			}
			string id = array[0];
			string arg = array[1];
			AiCsSandboxAirTraffic.AiMode result2 = AiCsSandboxAirTraffic.AiMode.Default;
			if (array.Length >= 3)
			{
				result2 = (Enum.TryParse<AiCsSandboxAirTraffic.AiMode>(array[2], out result2) ? result2 : AiCsSandboxAirTraffic.AiMode.Default);
			}
			if (array.Length >= 4)
			{
				result = (int.TryParse(array[3], out result) ? result : 100);
			}
			ushort num = (ushort)(aiHostile ? 1 : Game.Instance.NetworkGameManager.LocalPlayer.TeamId);
			AiSpawnHelper.SpawnPlaneBasic(id, aiHostile, num, result2, result);
			FlightSceneScript.Instance.FlightUI.ShowMessage(string.Format("Spawning {0}on team '{1}':{2}", aiHostile ? "Hostile " : string.Empty, num, arg), 2f);
		}

		public void SpawnRandomPlane()
		{
			string[] array = new string[4] { "Wasp (Simple);Fighter;Default;100", "P-51 (Simple);WW2 Fighter;Default;50", "__aiEscortBomber__;Bomber;Default;65", "Twin Prop (Simple);Civilian Airplane;Land;75" };
			SpawnPlane(array[UnityEngine.Random.Range(0, array.Length)]);
		}

		public void SpawnTanker()
		{
			AiSpawnHelper.SpawnRefuelingTankerAuto();
			FlightSceneScript.Instance.FlightUI.ShowMessage("Spawning Refueling Tanker", 2f);
		}

		public void TargetMove(bool next)
		{
			if (targetingSystem != null)
			{
				if (next)
				{
					targetingSystem.NextTarget();
				}
				else
				{
					targetingSystem.PreviousTarget();
				}
			}
		}

		public void ToggleAG(int ag)
		{
			if (controls != null)
			{
				controls.ActivateGroup(ag);
			}
		}

		public void ToggleAiHostile()
		{
			aiHostile = !aiHostile;
			aiHostileIcon.SetActive(aiHostile);
			aiNeutralIcon.SetActive(!aiHostile);
		}

		public void ToggleAiTraffic(bool isGround)
		{
			if (isGround)
			{
				Game.Instance.Settings.Gameplay.Flight.GroundTrafficEnabled.Value = !Game.Instance.Settings.Gameplay.Flight.GroundTrafficEnabled.Value;
				Game.Instance.Settings.Gameplay.Flight.CommitChanges();
				Game.Instance.Settings.Gameplay.Save();
			}
			else
			{
				AiManagerScript.AiSettings.MaxAiTrafficCount = ((AiManagerScript.AiSettings.MaxAiTrafficCount == 0) ? 2 : 0);
			}
		}

		public void ToggleControllerLayout()
		{
			if (controllerLayout.IsVisible)
			{
				controllerLayout.HideLayouts();
			}
			else
			{
				controllerLayout.ShowLayouts();
			}
		}

		public void ToggleDynamicWeather()
		{
			FlightSceneScript.Instance.Environment.DynamicWeatherEnabled = !FlightSceneScript.Instance.Environment.DynamicWeatherEnabled;
		}

		public void ToggleGear()
		{
			if (controls != null)
			{
				controls.SetLandingGearDown(!controls.LandingGearDown);
			}
		}

		public void ToggleKneeboard()
		{
			kneeboard.Toggle();
		}

		public void TogglePause()
		{
			PauseManager.RequestPauseChange(!PauseManager.Paused, userInitiated: true);
		}

		public void WeaponMode(bool air)
		{
			if (targetingSystem != null)
			{
				TargetingSystem.TargetingSystemMode targetingSystemMode = (air ? TargetingSystem.TargetingSystemMode.AirToAir : TargetingSystem.TargetingSystemMode.AirToGround);
				bool flag = targetingSystem.Mode != targetingSystemMode;
				targetingSystem.Mode = (flag ? targetingSystemMode : TargetingSystem.TargetingSystemMode.Off);
			}
		}

		public void WeaponMove(bool next)
		{
			if (targetingSystem != null)
			{
				if (next)
				{
					targetingSystem.NextWeapon();
				}
				else
				{
					targetingSystem.PreviousWeapon();
				}
			}
		}

		protected virtual void Awake()
		{
			_menuInput = ((_handType == XRHandType.Left) ? XRInputs.Flight.MenuLeft : XRInputs.Flight.MenuRight);
			_menuInput.performed += MenuPerformed;
			if (!dummyMode)
			{
				timeDragArea.OnValueChange += SetTime;
				_instances.Add(this);
				if (_instances.Count > 2)
				{
					Debug.LogWarning($"A FlightMenuScript may have leaked ({_instances.Count} instances currently being tracked).");
				}
			}
		}

		protected virtual void OnDestroy()
		{
			_menuInput.performed -= MenuPerformed;
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerEnteredAircraft -= OnPlayerEnteredAircraft;
				instance.PlayerExitedAircraft -= OnPlayerExitedAircraft;
			}
			bool flag = false;
			for (int i = 0; i < _instances.Count; i++)
			{
				if ((object)this == _instances[i])
				{
					_instances.RemoveAt(i);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Debug.LogWarning("A FlightMenuScript may have leaked (was not removed during destroy).");
			}
		}

		protected virtual void OnEnable()
		{
			CloseMenus();
		}

		protected virtual void Start()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerEnteredAircraft += OnPlayerEnteredAircraft;
				instance.PlayerExitedAircraft += OnPlayerExitedAircraft;
				instance.RaisePlayerEnteredAircraft(OnPlayerEnteredAircraft);
			}
		}

		protected virtual void Update()
		{
			if (dummyMode)
			{
				return;
			}
			SetButton(ref pauseButton, PauseManager.Paused);
			SetButton(ref kneeboardButton, kneeboard.IsVisible);
			SetButton(ref controlsButton, controllerLayout.IsVisible);
			if (controls != null)
			{
				SetButton(ref lgButton, controls.LandingGearDown);
				if (agButtons.Length != 0 && agButtons[0].button.gameObject.activeInHierarchy)
				{
					for (int i = 0; i < agButtons.Length; i++)
					{
						SetButton(ref agButtons[i], controls.GetActivationState(i + 1));
					}
				}
			}
			if (aiAirButton.button.gameObject.activeInHierarchy)
			{
				SetButton(ref aiAirButton, AiManagerScript.AiSettings.MaxAiTrafficCount != 0);
				SetButton(ref aiGroundButton, Game.Instance.Settings.Gameplay.Flight.GroundTrafficEnabled.Value);
			}
			if (dynamicWeatherButton.button.gameObject.activeInHierarchy)
			{
				SetButton(ref dynamicWeatherButton, FlightSceneScript.Instance.Environment.DynamicWeatherEnabled);
			}
			if (weaponsA2A.button.gameObject.activeInHierarchy && targetingSystem != null)
			{
				SetButton(ref weaponsA2A, targetingSystem.Mode == TargetingSystem.TargetingSystemMode.AirToAir);
				SetButton(ref weaponsA2G, targetingSystem.Mode == TargetingSystem.TargetingSystemMode.AirToGround);
				if (targetingSystem.Mode != TargetingSystem.TargetingSystemMode.Off)
				{
					weaponText.text = targetingSystem.SelectedWeaponSystem?.WeaponPartName ?? string.Empty;
					targetText.text = targetingSystem.CurrentTarget?.Name ?? string.Empty;
				}
				else
				{
					weaponText.text = string.Empty;
					targetText.text = string.Empty;
				}
			}
			if (timeDragArea.isActiveAndEnabled && !timeDragArea.IsDragging)
			{
				float num;
				for (num = (FlightSceneScript.Instance.Environment.TargetTimeOfDay - 12f) / 24f; num < 0f; num += 1f)
				{
				}
				timeDragArea.SetValueQuietly(1f - num);
			}
		}

		private void MenuPerformed(InputAction.CallbackContext ctx)
		{
			if (menuOpen)
			{
				CloseMenus();
				return;
			}
			InputDevice device = ctx.control.device;
			UnityEngine.XR.OpenXR.Input.Pose pose = ((!Game.Instance.Device.IsPicoXRBuild) ? device.GetChildControl<InputControl<UnityEngine.XR.OpenXR.Input.Pose>>("pointer").ReadValue() : new UnityEngine.XR.OpenXR.Input.Pose
			{
				position = device.GetChildControl<InputControl<Vector3>>("devicePosition").ReadValue(),
				rotation = device.GetChildControl<InputControl<Quaternion>>("deviceRotation").ReadValue()
			});
			Quaternion quaternion = pose.rotation * HandScriptBase.GetDefaultRotation(device);
			base.transform.SetPositionAndRotation(trackingSpace.TransformPoint(pose.position + quaternion * menuOffset), Quaternion.LookRotation(trackingSpace.rotation * quaternion * Vector3.forward, trackingSpace.transform.up));
			OpenMenu(defaultMenu);
			launchCatapult.button.transform.parent.gameObject.SetActive(value: true);
			tooltipScript.gameObject.SetActive(value: true);
			UpdateTimeControlIcon();
		}

		private void OnPlayerEnteredAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				controls = e.Aircraft.Controls;
				targetingSystem = e.Aircraft.TargetingSystem;
			}
		}

		private void OnPlayerExitedAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				controls = null;
				targetingSystem = null;
			}
		}

		private void SetButton(ref ToggleButton button, bool enabled)
		{
			if (button.enabled != enabled)
			{
				button.enabled = enabled;
				button.button.IsSelected = enabled;
			}
		}

		private void UpdateTimeControlIcon()
		{
			timeSlowIcon.SetActive(!PauseManager.FastForwardEnabled && !PauseManager.SlowMotionEnabled);
			timeFastIcon.SetActive(PauseManager.SlowMotionEnabled);
			timePlayIcon.SetActive(PauseManager.FastForwardEnabled);
		}
	}
}

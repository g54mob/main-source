using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design;
using Assets.Scripts.Flight.Maps;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.GuiNew;
using Assets.Scripts.Input;
using Assets.Scripts.Levels;
using Assets.Scripts.Menu.LevelMenuVR.ListView;
using Assets.Scripts.Mods;
using Assets.Scripts.Storage;
using Assets.Scripts.XR;
using DG.Tweening;
using Jundroo.Common.Coroutines;
using Jundroo.Common.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.LevelMenuVR
{
	public class LevelMenuVRScript : MonoBehaviour
	{
		private class BoundsCalculation
		{
			public Bounds Bounds { get; set; }

			public List<Tuple<PartScript, float>> Parts => new List<Tuple<PartScript, float>>();
		}

		private const string SelectedLevelPlayerPrefKey = "LevelMenuVR.SelectedLevel";

		private static TrackedCraftList.TrackedCraft _opponent;

		[SerializeField]
		private AboutUIScript _aboutUI;

		[SerializeField]
		private Transform _aircraftContainer;

		[SerializeField]
		[FormerlySerializedAs("_aircraftLoading")]
		private GameObject _aircraftLoadingIndicator;

		[SerializeField]
		private Transform _aircraftPlatform;

		[SerializeField]
		private VrControlsScreenScript _controlsScreen;

		private AircraftScript _craft;

		[SerializeField]
		private GameObject[] _disableOnHmdNotFound;

		private bool _displaySelectedCraft;

		private bool _loadingCraftFile;

		[SerializeField]
		private GameObject _mainMenu;

		[SerializeField]
		private GameObject _modsSection;

		private AircraftData _opponentAircraft;

		private bool _queueRefreshLayout;

		private string _requiredAircraft;

		[SerializeField]
		private GameObject _sectionAircraft;

		[SerializeField]
		private GameObject _sectionOpponent;

		[SerializeField]
		private GameObject _sectionRequiredAircraft;

		private SelectCraftModel _selectCraftModel;

		private string _selectedCraftPath;

		private XElement _selectedCraftXml;

		private SelectLevelModel.LevelItemModel _selectedLevel;

		private Vector3 _startingPlatformPosition;

		[SerializeField]
		private TextMeshProUGUI _textCraftName;

		[SerializeField]
		private TextMeshProUGUI _textModeName;

		[SerializeField]
		private TextMeshProUGUI _textOpponentName;

		[SerializeField]
		private TextMeshProUGUI _warning;

		public Action CloseAction { get; set; }

		public TrackedCraftList TrackedCrafts { get; private set; }

		public void OnAboutButtonClicked()
		{
			_aboutUI.gameObject.SetActive(value: true);
			_mainMenu.SetActive(value: false);
		}

		public void OnAccountButtonClicked()
		{
			_mainMenu.SetActive(value: false);
			AccountDialogScript.CreateDialog(base.transform.GetComponent<RectTransform>()).Closed += delegate
			{
				_mainMenu.SetActive(value: true);
			};
		}

		public void OnCloseButtonClicked()
		{
			if (CloseAction != null)
			{
				CloseAction();
				return;
			}
			_mainMenu.SetActive(value: false);
			VRDialogScript vRDialogScript = VRDialogScript.CreateDialog(showOkay: true, showCancel: true, GetComponent<RectTransform>());
			vRDialogScript.MessageText = "Please confirm that you wish to exit.";
			vRDialogScript.OnOkay += delegate(VRDialogScript d)
			{
				d.Close();
				Application.Quit();
			};
			vRDialogScript.OnCancel += delegate(VRDialogScript d)
			{
				d.Close();
				_mainMenu.SetActive(value: true);
			};
		}

		public void OnControlsButtonClick()
		{
			_mainMenu.SetActive(value: false);
			_controlsScreen.Show(show: true);
		}

		public void OnControlsDialogClosed()
		{
			_controlsScreen.Show(show: false);
			_mainMenu.SetActive(value: true);
		}

		public void OnFlyButtonClicked()
		{
			if (_selectedLevel != null && (_selectedCraftXml != null || !_displaySelectedCraft))
			{
				StartCoroutine(LoadLevelAsync(_selectedLevel.LevelInfo, _selectedLevel.StartingLocation));
			}
			else if (_selectedCraftXml == null)
			{
				OnSelectCraftButtonClicked();
			}
			else
			{
				OnSelectLevelButtonClicked();
			}
		}

		public void OnModsButtonClick()
		{
			_mainMenu.SetActive(value: false);
			ListViewScript.CreateListView(new ModsModel(this), base.transform).Closed += delegate
			{
				_mainMenu.SetActive(value: true);
			};
		}

		public void OnSelectCraftButtonClicked()
		{
			ShowSelectCraftListView(TrackedCrafts.Selected?.UrlId, "SELECT PLAYER CRAFT", delegate(TrackedCraftList.TrackedCraft craft)
			{
				SetSelectedCraft(craft);
			});
		}

		public void OnSelectLevelButtonClicked()
		{
			_mainMenu.SetActive(value: false);
			SelectLevelModel selectLevelModel = new SelectLevelModel(this, _selectedLevel?.Id);
			ListViewScript listViewScript = ListViewScript.CreateListView(selectLevelModel, base.transform);
			selectLevelModel.LevelSelected += delegate(SelectLevelModel.LevelItemModel x)
			{
				SetSelectedLevel(x);
			};
			listViewScript.Closed += delegate
			{
				_mainMenu.SetActive(value: true);
			};
		}

		public void OnSelectOpponentButtonClicked()
		{
			ShowSelectCraftListView(_opponent?.UrlId, "SELECT OPPONENT CRAFT", delegate(TrackedCraftList.TrackedCraft craft)
			{
				SetOpponent(craft);
			});
		}

		public void OnSettingsButtonClicked()
		{
			_mainMenu.SetActive(value: false);
		}

		public ListViewScript ShowSelectCraftListView(string urlID, string title, Action<TrackedCraftList.TrackedCraft> callback)
		{
			_mainMenu.SetActive(value: false);
			_selectCraftModel = new SelectCraftModel(TrackedCrafts, urlID, title);
			_selectCraftModel.OnCraftSelected += callback;
			ListViewScript listViewScript = ListViewScript.CreateListView(_selectCraftModel, base.transform);
			listViewScript.Closed += delegate
			{
				_selectCraftModel = null;
				_mainMenu.SetActive(value: true);
			};
			return listViewScript;
		}

		protected virtual void Awake()
		{
			Game.Instance.LevelDatabase.Rebuild(true);
		}

		protected virtual void LateUpdate()
		{
			if (_queueRefreshLayout)
			{
				_queueRefreshLayout = false;
				foreach (ContentSizeFitter item in GetComponentsInChildren<ContentSizeFitter>().Reverse())
				{
					LayoutRebuilder.ForceRebuildLayoutImmediate(item.GetComponent<RectTransform>());
				}
			}
			if (!GameInputs.Instance.LoadClipboardAircraft.GetButtonDownIfEnabled())
			{
				return;
			}
			string text = DesignerScript.FindAircraftUrlId(GUIUtility.systemCopyBuffer);
			Debug.Log("URL ID: " + text);
			if (_selectCraftModel == null)
			{
				ShowSelectCraftListView(text, "SELECT PLAYER AIRCRAFT", delegate(TrackedCraftList.TrackedCraft craft)
				{
					SetSelectedCraft(craft);
				});
			}
			else
			{
				_selectCraftModel.ShowDetailsForCraftWithID(text);
			}
		}

		protected virtual void OnDestroy()
		{
			if (TrackedCrafts != null)
			{
				TrackedCrafts.Prune(200);
				TrackedCrafts.Save();
			}
		}

		protected virtual void Start()
		{
			try
			{
				if (Game.Instance.Device.IsPCVRExclusiveBuild && !Game.Instance.XRDeviceManager.HmdActive)
				{
					Canvas component = base.gameObject.GetComponent<Canvas>();
					component.worldCamera = XRCameraManagerScript.Instance.FlatCameraRig.GetComponentInChildren<Camera>(includeInactive: true);
					GameObject[] disableOnHmdNotFound = _disableOnHmdNotFound;
					foreach (GameObject gameObject in disableOnHmdNotFound)
					{
						if (gameObject != null)
						{
							gameObject.SetActive(value: false);
						}
						else
						{
							Debug.LogError("LevelMenuVR - Cannot disable GameObject b/c reference is null...did the object get deleted/renamed?");
						}
					}
					DialogScript dialogScript = DialogScript.CreateDialog(showCancel: true, component);
					dialogScript.Canvas.gameObject.AddComponent<PointerNotificationScript>().PointerClick += OnHmdFailedToInitializedClicked;
					string text = OpenXRRuntime.Name;
					string text2 = "VR headset not found.  Please connect the headset and try again.";
					string text3 = "<i><color=#ffffffff><a href=button>Click here to open Steam forum help.</a></color></i>";
					string text4 = "Current OpenXR runtime: " + text;
					dialogScript.MessageText = text2 + "\n\n\n" + text3 + "\n" + text4;
					dialogScript.CancelButtonText = "EXIT GAME";
					dialogScript.OkayButtonText = "RETRY";
					dialogScript.OnOkay += delegate(DialogScript x)
					{
						Game.Instance.XRDeviceManager.HmdInitializationFinished += OnHmdInitializationFinished;
						Game.Instance.XRDeviceManager.SetXrActive(active: true);
						x.Close();
					};
					dialogScript.OnCancel += delegate
					{
						Application.Quit();
					};
				}
				else
				{
					_aboutUI.Closed += delegate
					{
						_mainMenu.SetActive(value: true);
					};
					TrackedCrafts = new TrackedCraftList(GameData.GetPath("TrackedCrafts.xml"));
					_startingPlatformPosition = _aircraftPlatform.position;
					UpdateCanvasCamera();
					XRCameraManagerScript.Instance.OnXrCamerasEnabledChanged += delegate
					{
						UpdateCanvasCamera();
					};
					if (Game.Instance.Settings.App.AppVersionLastRun < Game.Version && Game.Instance.Settings.App.AppVersionLastRun > new Version(0, 0, 0, 0))
					{
						NewVersionSinceLastRun(Game.Version, Game.Instance.Settings.App.AppVersionLastRun);
					}
					RestorePreviousSelections();
					string text5 = "ControlsDialogMenu";
					bool flag = !Game.Instance.Settings.App.SeenNotifications.Contains(text5);
					Game.Instance.Settings.App.AddNotification(text5);
					_mainMenu.SetActive(!flag);
					_controlsScreen.Show(flag);
					_modsSection.SetActive(!Game.Instance.Device.IsAndroidVRBuild);
					_displaySelectedCraft = true;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private static void AnimateParts(Transform childContainer, Vector3 localCenterOfMass, float distance, float duration, BoundsCalculation boundsCalculation)
		{
			Bounds bounds = boundsCalculation.Bounds;
			float num = bounds.min.z - bounds.center.z;
			DOTween.SetTweensCapacity(500, 50);
			List<Tuple<PartScript, float>> list = boundsCalculation.Parts.OrderByDescending((Tuple<PartScript, float> x) => x.Item2).ToList();
			int num2 = 0;
			for (num2 = 0; num2 < list.Count && num2 < 350; num2++)
			{
				Transform obj = list[num2].Item1.transform;
				Vector3 localPosition = obj.transform.localPosition;
				Vector3 vector = localPosition - localCenterOfMass;
				float num3 = (localPosition.z - num) / bounds.size.z;
				obj.transform.localPosition = vector * distance;
				obj.transform.DOLocalMove(localPosition, (num3 + 0.05f) * duration + UnityEngine.Random.Range(-0.05f, 0.05f)).SetEase(Ease.OutCubic).SetUpdate(isIndependentUpdate: true);
			}
			List<GameObject> childList = new List<GameObject>();
			for (; num2 < list.Count; num2++)
			{
				Transform transform = list[num2].Item1.transform;
				transform.gameObject.SetActive(value: false);
				childList.Add(transform.gameObject);
			}
			float dummy = 0f;
			DOTween.To(() => dummy, delegate(float x)
			{
				dummy = x;
			}, 1f, duration).OnComplete(delegate
			{
				foreach (GameObject item in childList)
				{
					item.SetActive(value: true);
				}
			});
		}

		private static BoundsCalculation CalculateBounds(GameObject g, AircraftData aircraft)
		{
			Vector3 vector = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			Vector3 vector2 = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			BoundsCalculation boundsCalculation = new BoundsCalculation();
			foreach (PartData part in aircraft.Assembly.Parts)
			{
				MeshRenderer[] componentsInChildren = part.PartScript.GetComponentsInChildren<MeshRenderer>(includeInactive: false);
				float num = 0f;
				MeshRenderer[] array = componentsInChildren;
				foreach (MeshRenderer meshRenderer in array)
				{
					vector = Vector3.Max(vector, meshRenderer.bounds.max);
					vector2 = Vector3.Min(vector2, meshRenderer.bounds.min);
					if (num < meshRenderer.bounds.size.magnitude)
					{
						num = meshRenderer.bounds.size.magnitude;
					}
				}
				boundsCalculation.Parts.Add(new Tuple<PartScript, float>(part.PartScript, num));
			}
			boundsCalculation.Bounds = new Bounds((vector + vector2) * 0.5f, vector - vector2);
			return boundsCalculation;
		}

		private static string CreateCraftTitleText(TrackedCraftList.TrackedCraft craft)
		{
			return craft.Title + ((craft.Author != null) ? (" <color=#ccc>by " + craft.Author) : string.Empty);
		}

		private IEnumerator LoadCraft(ResourceLocation xmlLocation, string xmlPath, Action callback = null)
		{
			_selectedCraftPath = xmlPath;
			_aircraftLoadingIndicator.SetActive(value: true);
			YieldRequest<byte[]> request = new YieldRequest<byte[]>();
			string errorMessage = null;
			_loadingCraftFile = true;
			yield return ListViewUtilities.LoadBytes(xmlLocation, xmlPath, request);
			if (request.Success)
			{
				XElement aircraftElement;
				try
				{
					aircraftElement = Utility.LoadCraftXmlFromBytes(request.Data);
				}
				catch (Exception innerException)
				{
					_loadingCraftFile = false;
					Debug.LogException(new Exception("Unable to load craft.", innerException));
					aircraftElement = null;
					errorMessage = "Failed to load the craft. Check your internet connection and try again.";
				}
				yield return null;
				if (aircraftElement != null)
				{
					try
					{
						_selectedCraftXml = aircraftElement;
						_loadingCraftFile = false;
						if (_craft != null)
						{
							UnityEngine.Object.Destroy(_craft.gameObject);
							_craft = null;
						}
						if (_displaySelectedCraft)
						{
							CrashDetection.SetFlag();
							AircraftData aircraft = new AircraftData(aircraftElement, CraftLoadContext.Menu);
							PartData.PartCreationInfo partCreationInfo = new PartData.PartCreationInfo();
							partCreationInfo.CreateHingeJoints = false;
							partCreationInfo.IsRigidBodyKinematic = true;
							partCreationInfo.CreateRigidBody = false;
							partCreationInfo.EnableWingScript = false;
							GameObject aircraftGameObject = null;
							aircraftGameObject = AircraftData.GenerateGameObjectMultipleFrames(aircraft, partCreationInfo, 0, delegate
							{
								if (xmlPath == _selectedCraftPath)
								{
									aircraftGameObject.name = "Aircraft";
									aircraftGameObject.transform.SetParent(_aircraftContainer, worldPositionStays: false);
									aircraftGameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
									_craft = aircraftGameObject.GetComponent<AircraftScript>();
									aircraftGameObject.transform.position = new Vector3(-1000f, -1000f, -1000f);
									StartCoroutine(RepositionCraft(aircraftGameObject, aircraft));
									_aircraftLoadingIndicator.SetActive(value: false);
									UpdatePerformanceWarning();
								}
								else
								{
									Debug.Log("Another craft was selected before this one finished loading: " + xmlPath + " != " + _selectedCraftPath);
									UnityEngine.Object.Destroy(aircraftGameObject);
								}
							});
						}
					}
					catch (Exception innerException2)
					{
						_loadingCraftFile = false;
						_aircraftLoadingIndicator.SetActive(value: false);
						Debug.LogException(new Exception("Unable to load craft.", innerException2));
						errorMessage = "Failed to load the craft. Check your internet connection and try again.";
					}
					CrashDetection.ClearFlag();
				}
			}
			else
			{
				_loadingCraftFile = false;
				Debug.LogError(request.ErrorMessage);
				errorMessage = "Failed to load the craft. Check your internet connection and try again.";
			}
			if (errorMessage != null)
			{
				VRDialogScript.CreateDialog(showOkay: true, showCancel: false).MessageText = errorMessage;
			}
			callback?.Invoke();
		}

		private IEnumerator LoadLevelAsync(LevelInfo level, StartLocationData startingLocation)
		{
			while (_loadingCraftFile)
			{
				yield return new WaitForEndOfFrame();
			}
			MapBase mapBase = new DefaultMap();
			if (!string.IsNullOrEmpty(level.ModName) && level.MapName != "Default Map")
			{
				MapInfo? mapInfo = Game.Instance.ModManager.AllMaps.Cast<MapInfo?>().FirstOrDefault((MapInfo? x) => x.Value.Mod.Name == level.ModName && x.Value.Name == level.MapName);
				if (!mapInfo.HasValue)
				{
					Debug.LogError($"Could not find mod '{level.ModName}' associated with level '{level.Name}");
				}
				else
				{
					mapBase = new ModMap(mapInfo.Value);
				}
			}
			Game.Instance.CurrentLevel = level;
			Game.Instance.CurrentMap = mapBase;
			if (startingLocation != null)
			{
				Game.Instance.Settings.Cloud.Locations.SetSelectedLocation(mapBase.MapId, startingLocation.Id);
				Game.Instance.Settings.Cloud.Locations.SaveIfNecessary();
			}
			Game.Instance.CraftDatabase.SaveCraft("__vrPlayer__.xml", _selectedCraftXml, backupPreviousFile: false, updateXmlVersion: false);
			yield return new WaitForEndOfFrame();
			yield return Game.Instance.SceneManager.LoadFlight(null, "__vrPlayer__.xml");
		}

		private void NewVersionSinceLastRun(Version newVersion, Version oldVersion)
		{
		}

		private void OnHmdFailedToInitializedClicked(PointerNotificationScript source, PointerEventData eventData)
		{
			Application.OpenURL("https://steamcommunity.com/app/1692700/discussions/0/4328520278441342179/");
		}

		private void OnHmdInitializationFinished(bool active)
		{
			Game.Instance.XRDeviceManager.HmdInitializationFinished -= OnHmdInitializationFinished;
			Game.Instance.SceneManager.LoadMenu();
		}

		private IEnumerator RepositionCraft(GameObject aircraftGameObject, AircraftData aircraft)
		{
			yield return new WaitForEndOfFrame();
			BoundsCalculation boundsCalculation = CalculateBounds(aircraftGameObject, aircraft);
			Bounds bounds = boundsCalculation.Bounds;
			Vector3 vector = bounds.center - new Vector3(0f, bounds.extents.y, 0f);
			Vector3 vector2 = _aircraftContainer.position - vector;
			aircraftGameObject.transform.position += vector2;
			float z = Mathf.Sqrt(bounds.extents.x * bounds.extents.x + bounds.extents.z * bounds.extents.z);
			_aircraftPlatform.position = _startingPlatformPosition + new Vector3(0f, 0f, z);
			Transform child = aircraftGameObject.transform.GetChild(0);
			Vector3 localCenterOfMass = child.InverseTransformPoint(_aircraftPlatform.position);
			AnimateParts(child, localCenterOfMass, 100f, 2f, boundsCalculation);
		}

		private void RestorePreviousSelections()
		{
			SelectLevelModel.LoadLevelItems();
			SelectLevelModel.LevelItemModel levelItemModel = SelectLevelModel.LevelItems.Where((SelectLevelModel.LevelItemModel x) => x.Id == PlayerPrefs.GetString("LevelMenuVR.SelectedLevel")).FirstOrDefault();
			if (levelItemModel == null)
			{
				levelItemModel = SelectLevelModel.DefaultLevelItem;
			}
			bool num = SetSelectedLevel(levelItemModel);
			TrackedCraftList.TrackedCraft trackedCraft = TrackedCrafts.Selected;
			if (trackedCraft == null)
			{
				trackedCraft = TrackedCrafts.Default;
			}
			if (CrashDetection.FlagStatus)
			{
				CrashDetection.ClearFlag();
				trackedCraft = TrackedCrafts.Default;
				VRDialogScript.CreateDialog(showOkay: true, showCancel: false).MessageText = "We detected that the game crashed. Sometimes crafts with a lot of parts can take up too much RAM and cause the game to crash. We have loaded a smaller craft to prevent that from happening again.";
			}
			if (!num)
			{
				SetSelectedCraft(trackedCraft);
			}
		}

		private IEnumerator SaveOpponentXml(ResourceLocation xmlLocation, string xmlPath, string targetCraftID, Action<AircraftData> callback)
		{
			YieldRequest<byte[]> request = new YieldRequest<byte[]>();
			yield return ListViewUtilities.LoadBytes(xmlLocation, xmlPath, request);
			if (request.Success)
			{
				try
				{
					XElement xElement = Utility.LoadCraftXmlFromBytes(request.Data);
					AircraftData obj = new AircraftData(xElement, CraftLoadContext.Menu);
					Game.Instance.CraftDatabase.SaveCraft(targetCraftID, xElement, backupPreviousFile: false, updateXmlVersion: false);
					callback?.Invoke(obj);
				}
				catch (Exception innerException)
				{
					Debug.LogException(new Exception("Unable to load craft.", innerException));
				}
			}
		}

		private void SetOpponent(TrackedCraftList.TrackedCraft craft)
		{
			if (craft == null)
			{
				craft = TrackedCrafts.DefaultOpponent;
			}
			_opponent = craft;
			_textOpponentName.text = "LOADING...";
			_ = craft.XmlPath;
			if (craft.XmlLocation == ResourceLocation.Web)
			{
				Game.GetDownloadAircraftUrl(craft.UrlId, craft.XmlRevision);
			}
			throw new NotImplementedException();
		}

		private bool SetRequiredCraft(string aircraftId)
		{
			bool result = false;
			if (_requiredAircraft != aircraftId)
			{
				_requiredAircraft = aircraftId;
				if (_requiredAircraft != null)
				{
					_sectionAircraft.SetActive(value: false);
					_sectionRequiredAircraft.SetActive(value: true);
					CraftFileInfo craftFileInfo = new CraftFileInfo(aircraftId);
					StartCoroutine(LoadCraft(ResourceLocation.File, craftFileInfo.FullFilePath));
					_queueRefreshLayout = true;
					result = true;
				}
				else
				{
					_sectionAircraft.SetActive(value: true);
					_sectionRequiredAircraft.SetActive(value: false);
					SetSelectedCraft(TrackedCrafts.Selected ?? TrackedCrafts.Default);
					result = true;
				}
			}
			return result;
		}

		private void SetSelectedCraft(TrackedCraftList.TrackedCraft craft)
		{
			TrackedCrafts.Selected = craft;
			craft.LastAccess = DateTime.UtcNow;
			_textCraftName.text = CreateCraftTitleText(craft);
			string xmlPath = craft.XmlPath;
			if (craft.XmlLocation == ResourceLocation.Web)
			{
				xmlPath = craft.XmlUrl;
			}
			StartCoroutine(LoadCraft(craft.XmlLocation, xmlPath));
			_queueRefreshLayout = true;
		}

		private bool SetSelectedLevel(SelectLevelModel.LevelItemModel level)
		{
			bool result = false;
			_selectedLevel = level;
			_textModeName.text = level.DisplayName;
			if (level.LevelInfo != null)
			{
				if (level.RequiresOpponent)
				{
					_sectionOpponent.SetActive(value: true);
					SetOpponent(_opponent);
				}
				else
				{
					_sectionOpponent.SetActive(value: false);
				}
				LevelBase component;
				if (!string.IsNullOrEmpty(level.LevelInfo.ModName))
				{
					result = SetRequiredCraft(null);
				}
				else if ((Resources.Load("Levels/" + level.LevelInfo.Prefab) as GameObject).TryGetComponent<LevelBase>(out component))
				{
					result = (string.IsNullOrEmpty(component.AircraftId) ? SetRequiredCraft(null) : SetRequiredCraft(component.AircraftId));
				}
			}
			PlayerPrefs.SetString("LevelMenuVR.SelectedLevel", level.Id);
			_queueRefreshLayout = true;
			UpdatePerformanceWarning();
			return result;
		}

		private void UpdateCanvasCamera()
		{
			Camera componentInChildren = XRCameraManagerScript.Instance.GetComponentInChildren<Camera>();
			GetComponent<Canvas>().worldCamera = componentInChildren;
		}

		private void UpdatePerformanceWarning()
		{
			int num = ((_opponentAircraft != null) ? ((int)PerformanceCost.CalculateCost(_opponentAircraft)) : 0);
			int num2 = ((_craft?.Aircraft != null) ? ((int)PerformanceCost.CalculateCost(_craft.Aircraft)) : 0);
			string text = null;
			if (_selectedLevel.RequiresOpponent && num2 + num > SelectCraftModel.PerformanceCostThresholdModerateWithOpponents)
			{
				text = "The combined complexity of the player and opponent aircraft may cause poor performance on this device. Choosing simpler aircraft can improve performance.";
			}
			else if (num2 > SelectCraftModel.PerformanceCostThresholdModerate)
			{
				text = "The complexity of the selected aircraft may cause poor performance on this device. Choosing a simpler aircraft can improve performance.";
			}
			if (text != null)
			{
				_warning.text = text;
				_warning.gameObject.SetActive(value: true);
			}
			else
			{
				_warning.text = string.Empty;
				_warning.gameObject.SetActive(value: false);
			}
		}
	}
}

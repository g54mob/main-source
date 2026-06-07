using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.TravelEvents;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DeployCosts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions;
using I2.Loc;
using NGenerics.Extensions;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class LaunchDrone : MonoBehaviour
	{
		public DroneSelectionManager Manager;

		public UITexture Icon;

		public Texture2D SelectIcon;

		public Texture2D LaunchIcon;

		private DroneData _item;

		private DeployCost _cost;

		private UIButton[] _buttons;

		private bool _isVersionCompatible;

		private bool _twoStepSelection;

		private bool _wasInitialized;

		private string _preconditionText;

		[HideInInspector]
		public bool IsReady { get; private set; }

		public void Init(DroneData item)
		{
			if (DroneSelectionManager.HideLaunchButton)
			{
				base.gameObject.SetActive(false);
				return;
			}
			_buttons = GetComponents<UIButton>();
			_twoStepSelection = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDroneSettings.TwoStepDroneSelection;
			List<DronePrecondition> preconditions = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetPreconditions();
			Icon.mainTexture = (_twoStepSelection ? SelectIcon : LaunchIcon);
			_item = item;
			_cost = DeployCostHelper.CalculateDeployCost(_item.NumberOfParts);
			IsReady = preconditions.TrueForAll((DronePrecondition p) => p.Check(_item));
			_preconditionText = "";
			foreach (DronePrecondition item2 in preconditions)
			{
				bool status2;
				string status = item2.GetStatus(_item, out status2);
				if (!status2)
				{
					if (!string.IsNullOrEmpty(_preconditionText))
					{
						_preconditionText += LabelHelper.NewLine;
					}
					_preconditionText += status;
				}
			}
			_isVersionCompatible = _item.IsCompatible();
			if (IsReady && _isVersionCompatible)
			{
				_buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Normal, true);
				});
			}
			else
			{
				_buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Disabled, true);
				});
			}
			_wasInitialized = true;
		}

		public void Update()
		{
			if (_wasInitialized && (!_isVersionCompatible || !IsReady || !SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CanVisitCurrentLocation()))
			{
				_buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Disabled, true);
				});
			}
		}

		public void OnTooltip(bool show)
		{
			if (!_wasInitialized)
			{
				return;
			}
			if (show)
			{
				if (!_isVersionCompatible)
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneHangar/NotCompatible"));
				}
				else if (!IsReady)
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneHangar/RequirementsNotMet"));
				}
				else if (!SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CanVisitCurrentLocation())
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneHangar/NotVisitable"));
				}
				else
				{
					NimbatusToolTip.Show(null);
				}
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}

		public void OnClick()
		{
			if (_wasInitialized && IsReady && _isVersionCompatible && SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CanVisitCurrentLocation())
			{
				StartCoroutine(Deploy());
			}
		}

		public IEnumerator Deploy()
		{
			if (_wasInitialized)
			{
				if (RuntimeGlobals.GameModeSettings.DeployCost && (_cost.Threat > 0f || _cost.ResourceAmount < 0))
				{
					Manager.ShowLaunchPanel(_item, Launch);
					yield break;
				}
				Launch();
				yield return true;
			}
		}

		public void Launch()
		{
			if (RuntimeGlobals.GameModeSettings.DeployCost)
			{
				DeployCostHelper.CommitDeployment(_cost);
			}
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetActiveDrone(_item);
			_item.LastUseTime = DateTime.UtcNow;
			SerializableMonobehaviour<MissionManager, MissionData>.Instance.ResetLocalMissionProgress();
			if (_twoStepSelection)
			{
				NimbatusSceneManager.GoToBookmarkedScene();
			}
			else if (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent != null)
			{
				SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.LoadScene();
			}
			else if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDroneSettings.HasCustomScene)
			{
				NimbatusSceneManager.LoadScene(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDroneSettings.CustomSceneName);
			}
			else if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation != null)
			{
				SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.LaunchDrone();
			}
		}
	}
}

using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Automation;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.Orbits.Chain;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Math;
using ModApi.Scenes;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.UI.Inspector
{
	public class InspectorItemViewModel
	{
		private IChainableOrbit _chainableOrbit;

		private Action _deleteAction;

		private ManeuverNodeScript _maneuverNode;

		private MapOrbitNode _mapOrbitNode;

		private MapViewInspectorScript _mvi;

		private ICameraFocusable _target;

		public string ArrivalTime
		{
			get
			{
				IChainableOrbit chainableOrbit = _chainableOrbit;
				if (chainableOrbit != null && chainableOrbit.TimeToNode.HasValue)
				{
					return Units.GetRelativeTimeString(_chainableOrbit.TimeToNode.Value);
				}
				return "N/A";
			}
		}

		public string BurnAccuracy => GetBurnAccuracyDesc(_maneuverNode.BurnData.BurnAccuracy);

		public string BurnDuration
		{
			get
			{
				double burnTimeRemaining = _maneuverNode.BurnData.BurnTimeRemaining;
				if (!(burnTimeRemaining > 0.0))
				{
					return "N/A";
				}
				return Units.GetRelativeTimeString((float)burnTimeRemaining);
			}
		}

		public bool CanDelete => _deleteAction != null;

		public bool CanLock { get; private set; }

		public bool CanSelectPlayer { get; private set; }

		public bool CanTakeControl { get; private set; }

		public bool CanTarget { get; }

		public IChainableOrbit ChainableOrbit => _chainableOrbit;

		public string DeleteConfirmation
		{
			get
			{
				if (!CanDelete || IsManeuverNode)
				{
					return null;
				}
				return $"Are you sure you want to destroy '{GetMapItem().ItemName}'?";
			}
		}

		public string DeltaV => Units.GetVelocityString((float)_maneuverNode.GetDeltaVToCompleteManeuver().magnitude, Units.UnitPrecisionMode.High);

		public bool IsChainableOrbit => _chainableOrbit != null;

		public bool IsLocked => (_target as IChainableOrbit)?.Locked ?? false;

		public bool IsManeuverNode => _maneuverNode != null;

		public bool IsMapOrbitNode => _mapOrbitNode != null;

		public bool IsPerformingBurn => _maneuverNode.Locked;

		public bool IsTargeted => _target as ITargetableItem == _mvi.NavigationTargetProvider.NavigationTarget;

		public string ItemType { get; private set; }

		public MapOrbitNode MapOrbitNode => _mapOrbitNode;

		public string Name { get; private set; }

		public IOrbit Orbit => (_target as IOrbitInfoProvider)?.OrbitInfo?.OrbitNode?.Orbit;

		public IOrbitNode OrbitNode { get; }

		public bool ShowArrivalTime { get; set; }

		public bool ShowAutoBurn { get; private set; }

		public bool ShowName { get; private set; }

		public bool ShowNodeNavigation { get; private set; }

		public bool ShowNodeNextButton { get; set; }

		public bool ShowNodePrevButton { get; set; }

		public bool ShowNodeRenameButton { get; set; }

		public bool ShowWarpToNext { get; private set; }

		public ICameraFocusable Target => _target;

		private NodeNavigator NodeNavigator => _mvi.PlayerCraft.NodeNavigator;

		public InspectorItemViewModel(ICameraFocusable target, MapViewInspectorScript mapViewInspector)
		{
			_target = target;
			_mvi = mapViewInspector;
			OrbitNode = target.OrbitNode;
			ShowAutoBurn = true;
			ShowWarpToNext = true;
			ShowNodeRenameButton = false;
			_mapOrbitNode = target as MapOrbitNode;
			if (_mapOrbitNode != null)
			{
				Name = _mapOrbitNode?.OrbitInfo?.OrbitNode?.Name;
				ITargetableItem target2 = target as ITargetableItem;
				CanTarget = mapViewInspector.NavigationTargetProvider.IsValidTarget(target2);
				if (_mapOrbitNode.OrbitInfo == mapViewInspector.PlayerCraft?.OrbitInfo)
				{
					Name = "Player Craft - " + Name;
					_chainableOrbit = target as IChainableOrbit;
					ShowNodeNavigation = true;
					ShowNodeRenameButton = true;
					UpdateNodeNavSpinners();
					_mvi.PlayerCraft.ChainNodeManager.NodeListChanged += OnNodeListChanged;
				}
				else if (_mapOrbitNode is MapCraft || (bool)(_mapOrbitNode as MapStaticOrbitItem))
				{
					ItemType = "Craft";
					CanSelectPlayer = true;
					ShowName = true;
					ShowNodeRenameButton = true;
					_deleteAction = delegate
					{
						DeleteCraftNode();
					};
					if (_mapOrbitNode.OrbitInfo.OrbitNode is CraftNode craftNode)
					{
						CanTakeControl = craftNode.HasCommandPod && craftNode.AllowPlayerControl;
					}
					ShowAutoBurn = false;
					ShowWarpToNext = false;
				}
				else if (_mapOrbitNode is MapPlanet)
				{
					ItemType = "Planet";
					CanSelectPlayer = true;
					CanTakeControl = false;
					ShowName = true;
					if (Game.InPlanetStudioScene)
					{
						_deleteAction = delegate
						{
							DeletePlanet();
						};
					}
				}
				else if (_mapOrbitNode is MapSurfaceItem)
				{
					MapSurfaceItem mapSurfaceItem = _mapOrbitNode as MapSurfaceItem;
					ItemType = mapSurfaceItem.StructureTypeName;
					CanSelectPlayer = true;
					CanTakeControl = false;
					ShowName = true;
				}
			}
			else
			{
				if (!(target is IChainableOrbit))
				{
					return;
				}
				_chainableOrbit = target as IChainableOrbit;
				_maneuverNode = target as ManeuverNodeScript;
				CanSelectPlayer = true;
				if (_maneuverNode != null)
				{
					ChainNodeManager chainNodeManager = _mvi.PlayerCraft.ChainNodeManager;
					bool flag = chainNodeManager.FirstManeuverNode == _maneuverNode;
					bool flag2 = chainNodeManager.FirstNonCraftNode as ManeuverNodeScript == _maneuverNode;
					CanLock = flag && flag2;
					_deleteAction = delegate
					{
						DeleteManeuverNode();
					};
				}
				_mvi.PlayerCraft.ChainNodeManager.NodeListChanged += OnNodeListChanged;
				ShowNodeNavigation = true;
				UpdateNodeNavSpinners();
				ShowArrivalTime = true;
				ItemType = string.Empty;
				Name = GetNodeTypeName(target as IChainableOrbit);
			}
		}

		public void Delete()
		{
			_deleteAction();
		}

		public CraftNode GetCraftNode()
		{
			return (_target as IOrbitInfoProvider)?.OrbitInfo?.OrbitNode as CraftNode;
		}

		public MapItem GetMapItem()
		{
			return _target as MapItem;
		}

		public void OnDeselected()
		{
			if (_maneuverNode != null)
			{
				_maneuverNode.OnDeselected();
			}
			if (_mvi.PlayerCraft != null)
			{
				_mvi.PlayerCraft.ChainNodeManager.NodeListChanged -= OnNodeListChanged;
			}
			if (Target != null)
			{
				Target.Destroyed -= OnTargetDestroyed;
			}
		}

		public void OnSelected()
		{
			if (Target != null)
			{
				Target.Destroyed += OnTargetDestroyed;
			}
		}

		public void ToggleLock()
		{
			OrbitChainNodeScript orbitChainNodeScript = _target as OrbitChainNodeScript;
			if (orbitChainNodeScript.Locked)
			{
				orbitChainNodeScript.UnlockNode(userRequested: true);
			}
			else
			{
				orbitChainNodeScript.LockNode();
			}
		}

		public void ToggleTarget()
		{
			ITargetableItem targetableItem = _target as ITargetableItem;
			if (_mvi.NavigationTargetProvider.NavigationTarget == targetableItem)
			{
				targetableItem = null;
			}
			_mvi.NavigationTargetProvider.SetNavigationTarget(targetableItem);
		}

		private static string ClampStringLength(string s, int length)
		{
			if (s != null && s.Length > length)
			{
				return s.Substring(0, length);
			}
			return s;
		}

		private static string GetBurnAccuracyDesc(BurnAccuracy burnAccuracy)
		{
			string result;
			switch (burnAccuracy)
			{
			case Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes.BurnAccuracy.High:
				result = "High";
				break;
			case Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes.BurnAccuracy.Med:
				result = "Med";
				break;
			case Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes.BurnAccuracy.Low:
				result = "Low";
				break;
			case Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes.BurnAccuracy.NotRecommended:
				result = "Not Recommended";
				break;
			default:
				result = burnAccuracy.ToString();
				Debug.LogError($"Unsupported burnAccuracy type: {burnAccuracy}");
				break;
			}
			return result;
		}

		private static string GetNodeTypeName(IChainableOrbit node)
		{
			string result = null;
			if (node is ManeuverNodeScript)
			{
				result = "Planned Burn";
			}
			else if (node is SoiExitNodeScript)
			{
				result = "Exit SOI";
			}
			else if (node is SoiEnterNodeScript)
			{
				result = "Enter SOI";
			}
			else
			{
				Debug.Log("Unknown");
			}
			return result;
		}

		private void DeleteCraftNode()
		{
			CraftNode craftNode = GetCraftNode();
			string name = craftNode.Name;
			if (craftNode.IsLoadedInGameView)
			{
				Game.Instance.FlightScene.ViewManager.GameView.RemoveGameViewObject(craftNode, flightEnd: false);
			}
			craftNode.DestroyCraft();
			string text = $"Destroyed craft: {name}";
			Game.Instance.FlightScene.FlightSceneUI.FlightLog.AddLog(text, FlightLogEntryCategory.Default);
			_mvi.ShowMessage(text);
		}

		private void DeleteManeuverNode()
		{
			_maneuverNode.Delete();
			_mvi.ShowMessage($"Deleted planned burn.");
		}

		private void DeletePlanet()
		{
			(_target as MapPlanet).Delete();
		}

		private void OnNodeListChanged(IChainNodeList source, LinkedListNode<IChainableOrbit> node, NodeListChangeCategory category)
		{
			UpdateNodeNavSpinners();
		}

		private void OnTargetDestroyed(ICameraFocusable source)
		{
			if (Game.Instance.SceneManager.SceneTransitionState != SceneTransitionState.SceneUnloading)
			{
				ICameraFocusable itemToFocusOnWhenDeleted = source.ItemToFocusOnWhenDeleted;
				if (itemToFocusOnWhenDeleted != null)
				{
					_mvi.MapView.SetInspectorFocus(itemToFocusOnWhenDeleted, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
				}
			}
		}

		private void UpdateNodeNavSpinners()
		{
			ShowNodePrevButton = _chainableOrbit.ListNode.Previous != null;
			ShowNodeNextButton = _chainableOrbit.ListNode.Next != null;
		}
	}
}

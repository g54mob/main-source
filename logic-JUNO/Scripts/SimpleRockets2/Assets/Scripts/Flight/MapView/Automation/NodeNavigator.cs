using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Craft;
using Assets.Scripts.DebugScripts;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Flight;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Input;
using ModApi.Ioc;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Automation
{
	public class NodeNavigator
	{
		public enum ManeuverPhase
		{
			HeadingLock = 0,
			BurnPrep = 1,
			Burning = 2,
			Complete = 3
		}

		private const double DefaultWarpSpeed = 0.25;

		private static bool _achievementUnlockedAutoburn = false;

		private static float _timeWhenWarpCanIncreaseAgain = -1f;

		private bool _autoBurn;

		private float _autoburnSpoolDownEndTime;

		private bool _autoburnSpooldownStarted;

		private float _autoburnSpoolDownStartTime;

		private float _autoburnTime;

		private IChainNodeList _chainNodeList;

		private IMapViewCoordinateConverter _coordinateConverter;

		private ICraftInfo _craftInfo;

		private CraftNode _craftNode;

		private Vector3d _initialDeltaV;

		private float _initialTimeAtFullBurn;

		private IGameInputs _inputs;

		private double _lowestDvToComplete;

		private INavSphere _navSphere;

		private IMapOptions _options;

		private ITimeManager _timeManager;

		private double _warpBufferTime;

		public bool AutoBurn
		{
			get
			{
				return _autoBurn;
			}
			set
			{
				if (_autoBurn != value)
				{
					_autoBurn = value;
					OnAutoBurnChanged(value);
				}
			}
		}

		public bool AutoBurnInProgress => NextPhase == ManeuverPhase.Burning;

		public ManeuverNodeScript AutoBurnNode { get; private set; }

		public bool IsWarping => NodeToWarpTo != null;

		public ManeuverPhase NextPhase { get; private set; }

		public IChainableOrbit NodeToWarpTo { get; private set; }

		public float Progress { get; private set; }

		public NodeNavigator(IIocContainer ioc, ICraftContext craftContext, INavSphere navSphere, ITimeManager timeManager)
		{
			IMapViewContext context = ioc.Resolve<IMapViewContext>(craftContext);
			_coordinateConverter = ioc.Resolve<IMapViewCoordinateConverter>(context);
			_chainNodeList = ioc.Resolve<IChainNodeList>(craftContext);
			_craftInfo = ioc.Resolve<ICraftInfo>(craftContext);
			_options = ioc.Resolve<IMapOptions>();
			_craftNode = _craftInfo.OrbitInfo.OrbitNode as CraftNode;
			_navSphere = navSphere;
			_timeManager = timeManager;
			_inputs = Game.Instance.Inputs;
			_craftNode.ChangedSoI += OnCraftChangedSoi;
			_craftNode.CraftScript.FlightData.ActiveEnginesChanged += OnActiveEnginesChanged;
			_craftNode.CraftScript.CraftStructureChanged += OnCraftStructureChanged;
			ResetAutoBurn(resetThrottle: false);
		}

		public static ITimeMultiplierMode GetMaxMultiplierMode(ITimeManager timeManager, double timeToPoint, double bufferSeconds, double warpSpeedModifier)
		{
			double maxWarpMultiplier = (timeToPoint - bufferSeconds) * warpSpeedModifier;
			IEnumerable<ITimeMultiplierMode> source = timeManager.Modes.Where((ITimeMultiplierMode x) => x.TimeMultiplier >= 1.0 && x.TimeMultiplier < maxWarpMultiplier);
			if (source.Count() > 0)
			{
				return source.OrderByDescending((ITimeMultiplierMode x) => x.TimeMultiplier).First();
			}
			return timeManager.RealTime;
		}

		public static bool WarpToPosition(ITimeManager timeManager, double timeToPosition, double bufferSeconds, bool onlyReduce, double warpSpeedModifier)
		{
			timeToPosition = Mathd.Clamp(timeToPosition, 0.01, double.MaxValue);
			ITimeMultiplierMode maxMultiplierMode = GetMaxMultiplierMode(timeManager, timeToPosition, bufferSeconds, warpSpeedModifier);
			if (maxMultiplierMode != null && (!onlyReduce || timeManager.CurrentMode.TimeMultiplier > maxMultiplierMode.TimeMultiplier) && !Utilities.CompareDoubles(maxMultiplierMode.TimeMultiplier, timeManager.CurrentMode.TimeMultiplier))
			{
				if (maxMultiplierMode.TimeMultiplier > timeManager.CurrentMode.TimeMultiplier)
				{
					if (Time.time >= _timeWhenWarpCanIncreaseAgain)
					{
						timeManager.IncreaseTimeMultiplier();
						_timeWhenWarpCanIncreaseAgain = Time.time + 0.15f;
					}
				}
				else
				{
					timeManager.DecreaseTimeMultiplier();
				}
			}
			if (maxMultiplierMode.TimeMultiplier <= 1.0)
			{
				return maxMultiplierMode.TimeMultiplier == timeManager.CurrentMode.TimeMultiplier;
			}
			return false;
		}

		public void Dispose()
		{
			if (_craftNode != null)
			{
				_craftNode.ChangedSoI -= OnCraftChangedSoi;
				if (_craftNode.CraftScript != null)
				{
					_craftNode.CraftScript.FlightData.ActiveEnginesChanged -= OnActiveEnginesChanged;
				}
			}
		}

		public void OnCraftStructureChanged()
		{
			ResetAutoBurn(resetThrottle: false);
		}

		public void OnNextManeuverNodeLocked(ManeuverNodeScript maneuverNodeScript)
		{
			Progress = 0f;
		}

		public void ResetAutoBurn(bool resetThrottle = true)
		{
			_timeWhenWarpCanIncreaseAgain = -1f;
			NextPhase = ManeuverPhase.HeadingLock;
			_initialDeltaV = Vector3d.zero;
			_initialTimeAtFullBurn = 0f;
			_lowestDvToComplete = double.MaxValue;
			_autoburnSpooldownStarted = false;
			_autoburnTime = 0f;
			_autoburnSpoolDownStartTime = 0f;
			_autoburnSpoolDownEndTime = 0f;
			if (resetThrottle)
			{
				_craftNode.Controls.Throttle = 0f;
			}
		}

		public void Update(ManeuverNodeScript maneuverNode, ChainNodeManager chainNodeManager)
		{
			AutoBurnNode = maneuverNode;
			if (AutoBurnInProgress && _inputs.KillThrottle.GetButtonDownIfEnabled() && AutoBurn)
			{
				IFlightScene flightScene = Game.Instance.FlightScene;
				flightScene.TimeManager.RequestPauseChange(paused: true, userInitiated: false);
				flightScene.FlightSceneUI.ShowMessage("Auto-burn interrupted by " + _inputs.KillThrottle.Id + " command.  Unpause and re-enable auto-burn to resume.");
				AutoBurn = false;
			}
			if (_timeManager.Paused)
			{
				return;
			}
			if (maneuverNode != null)
			{
				if (AutoBurn)
				{
					UpdateAutoBurn(maneuverNode, chainNodeManager);
				}
				else
				{
					UpdateManualBurn(maneuverNode, chainNodeManager);
				}
			}
			if (NextPhase == ManeuverPhase.Complete)
			{
				ResetAutoBurn();
				_navSphere.LockCurrentHeading();
				maneuverNode.OnManeuverNodeExecutionComplete();
				Debug.Log("Maneuver node execution complete");
				if (_options.NodeNav.AutoDeleteManeuverNodes)
				{
					Debug.Log("Auto deleting completed maneuver node");
					maneuverNode.Delete();
				}
				CheckAndPerformAutoWarp();
			}
			if (NodeToWarpTo == null)
			{
				return;
			}
			if (NodeToWarpTo == _chainNodeList.FirstNonCraftNode)
			{
				if (WarpToPosition(_timeManager, _chainNodeList.TimeToNextNode.Value, _warpBufferTime, onlyReduce: false, _options.NodeNav.WarpSpeedModifier))
				{
					if (NodeToWarpTo is ManeuverNodeScript maneuverNodeScript && Utilities.CompareDoubles(maneuverNodeScript.DeltaVMag, 0.0))
					{
						maneuverNodeScript.Delete();
					}
					NodeToWarpTo = null;
					Debug.Log("Warp complete");
				}
			}
			else
			{
				AbortWarp();
				Debug.Log("Node changed while warping to it...aborting.");
			}
		}

		public IChainableOrbit WarpToNextNode()
		{
			IChainableOrbit firstNonCraftNode = _chainNodeList.FirstNonCraftNode;
			if (firstNonCraftNode != null)
			{
				if (Game.Instance.FlightScene.TimeManager.Paused)
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Unpause game to begin warp.");
				}
				WarpToNode(firstNonCraftNode);
			}
			return firstNonCraftNode;
		}

		public void WarpToNode(IChainableOrbit node)
		{
			if (node != null)
			{
				_ = _chainNodeList.FirstNonCraftNode;
			}
			if (node != null)
			{
				NodeToWarpTo = node;
				if (NodeToWarpTo is ManeuverNodeScript)
				{
					ManeuverNodeScript maneuverNodeScript = NodeToWarpTo as ManeuverNodeScript;
					_warpBufferTime = maneuverNodeScript.BurnData.TimeToInitiateBurn + _options.NodeNav.WarpBufferSeconds;
				}
				else
				{
					_warpBufferTime = 5.0;
				}
			}
		}

		private void AbortAutoBurn()
		{
			ResetAutoBurn();
		}

		private void AbortWarp()
		{
			_timeManager.SetMode(_timeManager.RealTime);
			NodeToWarpTo = null;
		}

		private void CheatBurn(ManeuverNodeScript maneuverNode)
		{
			if (maneuverNode.BurnData.TimeToNode < 0.10000000149011612)
			{
				CraftScript obj = (_craftInfo.OrbitInfo.OrbitNode as CraftNode).CraftScript as CraftScript;
				Vector3 velocity = Game.Instance.FlightScene.ViewManager.GameView.ReferenceFrame.PlanetToFrameVelocity(maneuverNode.OrbitInfo.OrbitNode.Velocity);
				obj.SetVelocity(velocity);
				CompleteBurnPhase();
			}
		}

		private void CheckAndPerformAutoWarp()
		{
			if (_options.NodeNav.AutoWarpToNextNode)
			{
				Debug.Log("Auto warping to next node");
				WarpToNextNode();
			}
		}

		private void CompleteBurnPhase()
		{
			NextPhase = ManeuverPhase.Complete;
			_craftNode.Controls.Throttle = 0f;
			_craftInfo.ScheduleChainUpdate();
		}

		private void DoInitialTurnPhase(ManeuverNodeScript maneuverNode)
		{
			Debug.Log($"{Time.frameCount}: locking maneuver node heading.");
			_navSphere.LockedIndicator = NavSphereIndicatorType.ManeuverNode;
			NextPhase = ManeuverPhase.BurnPrep;
		}

		private float GetThrottle(CraftNode craftNode, double deltaVRemaining, double burnTimeRemaining, float currentThrottle)
		{
			float result = 1f;
			ICraftFlightData flightData = craftNode.CraftScript.FlightData;
			float mass = craftNode.CraftScript.Mass;
			float maxActiveEngineThrust = flightData.MaxActiveEngineThrust;
			float currentEngineThrust = flightData.CurrentEngineThrust;
			_ = currentEngineThrust / mass;
			float num = maxActiveEngineThrust / mass;
			float num2 = (float)deltaVRemaining;
			float num3 = Mathf.Max(0.5f, flightData.WeightedThrottleResponseTime);
			float num4 = MathUtils.CalculateBurnDuration(currentEngineThrust, mass, num2);
			if (_autoburnSpooldownStarted || (currentEngineThrust > 0f && num4 < num3))
			{
				if (!_autoburnSpooldownStarted)
				{
					_autoburnSpooldownStarted = true;
					_autoburnSpoolDownStartTime = _autoburnTime;
					_autoburnSpoolDownEndTime = _autoburnTime + num3 * 2f;
				}
				float num5 = _autoburnSpoolDownEndTime - _autoburnSpoolDownStartTime;
				float t = Mathf.Clamp01((num5 - (_autoburnTime - _autoburnSpoolDownStartTime)) / num5);
				result = Mathf.Max(0.05f, num2 * 0.95f / Mathf.Lerp(0.25f, num3, t)) / num;
			}
			else if (_initialTimeAtFullBurn < num3)
			{
				result = (float)_initialDeltaV.magnitude * mass / num3 / maxActiveEngineThrust;
			}
			return result;
		}

		private bool IsBurnAchieveable(ManeuverNodeScript maneuverNode)
		{
			bool result = true;
			double magnitude = maneuverNode.GetDeltaVToCompleteManeuver().magnitude;
			if (magnitude < _lowestDvToComplete)
			{
				_lowestDvToComplete = magnitude;
			}
			if (magnitude > _lowestDvToComplete + 5.0)
			{
				result = false;
			}
			return result;
		}

		private void OnActiveEnginesChanged(object sender, EventArgs e)
		{
			ResetAutoBurn(resetThrottle: false);
		}

		private void OnAutoBurnChanged(bool value)
		{
			if (!value && AutoBurnInProgress)
			{
				OnInProgressAutoBurnPaused();
			}
			if (value && _craftNode.CraftScript.FlightData.MaxActiveEngineThrust <= 0f)
			{
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Warning: Craft is not capable of producing thrust in its current stage.");
			}
		}

		private void OnCraftChangedSoi(IOrbitNode source)
		{
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate(int? x)
			{
				if (x == 0)
				{
					CheckAndPerformAutoWarp();
				}
			}, 2);
		}

		private void OnInProgressAutoBurnPaused()
		{
			Debug.Log("Pausing auto-burn");
			_craftNode.Controls.Throttle = 0f;
		}

		private void OnManeuverNodeBeingBurnedDeleted(ManeuverNodeScript source)
		{
			source.Deleted -= OnManeuverNodeBeingBurnedDeleted;
			AbortAutoBurn();
		}

		private void PrepAndStartBurnPhase(ManeuverNodeScript maneuverNode)
		{
			if (!maneuverNode.Locked)
			{
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Auto-burn aborted: Node is not locked");
				return;
			}
			if (maneuverNode.BurnData.TimeToNode < 0.0)
			{
				Debug.LogWarning("Starting a burn for a maneuver node which is in the past...accuracy will be reduced");
			}
			maneuverNode.Deleted += OnManeuverNodeBeingBurnedDeleted;
			NextPhase = ManeuverPhase.Burning;
			ICraftScript craftScript = _craftNode.CraftScript;
			_initialDeltaV = maneuverNode.DeltaV;
			_initialTimeAtFullBurn = MathUtils.CalculateBurnDuration(craftScript.FlightData.MaxActiveEngineThrust, craftScript.Mass, (float)_initialDeltaV.magnitude);
			_autoburnTime = 0f;
			_autoburnSpoolDownStartTime = 0f;
			_autoburnSpoolDownEndTime = 0f;
			Debug.Log($"{Time.frameCount}: burn prep");
		}

		private void UpdateAutoBurn(ManeuverNodeScript maneuverNode, ChainNodeManager chainNodeManager)
		{
			if (NextPhase == ManeuverPhase.HeadingLock)
			{
				if (maneuverNode.BurnData.ShouldInitiateTurn())
				{
					DoInitialTurnPhase(maneuverNode);
				}
			}
			else if (NextPhase == ManeuverPhase.BurnPrep && maneuverNode.CanStartAutoBurn)
			{
				if (maneuverNode.BurnData.ShouldInitiateBurn())
				{
					PrepAndStartBurnPhase(maneuverNode);
				}
			}
			else
			{
				if (NextPhase != ManeuverPhase.Burning)
				{
					return;
				}
				if (!_options.NodeNav.CheatAutoBurns)
				{
					UpdateBurn(maneuverNode);
					if (_options.NodeNav.ShowAutoBurnVectors)
					{
						UpdateAutoBurnVectorLines(maneuverNode);
					}
				}
				else
				{
					CheatBurn(maneuverNode);
				}
			}
		}

		private void UpdateAutoBurnVectorLines(ManeuverNodeScript maneuverNode)
		{
			float num = (float)_initialDeltaV.magnitude;
			Vector3 origin = (Vector3)_coordinateConverter.ConvertSolarToMapView(_craftNode.SolarPosition);
			DebugGizmos.DrawRay("DvRemaining", new Ray(origin, (Vector3)maneuverNode.BurnData.DeltaVRemaining), (float)maneuverNode.BurnData.DeltaVRemaining.magnitude / num, Color.red, maneuverNode.gameObject.layer);
			DebugGizmos.DrawRay("DvApplied", new Ray(origin, (Vector3)maneuverNode.BurnData.DeltaVApplied), (float)maneuverNode.BurnData.DeltaVApplied.magnitude / num, Color.green, maneuverNode.gameObject.layer);
			DebugGizmos.DrawRay("TargetDv", new Ray(origin, (Vector3)_initialDeltaV), (float)_initialDeltaV.magnitude / num, Color.blue, maneuverNode.gameObject.layer);
		}

		private void UpdateBurn(ManeuverNodeScript maneuverNode)
		{
			_autoburnTime += Time.deltaTime;
			float num = 0f;
			if (_craftNode.Controls != null)
			{
				if (_initialDeltaV.sqrMagnitude > 0.0)
				{
					num = GetThrottle(_craftNode, maneuverNode.BurnData.DeltaVMagRemaining, maneuverNode.BurnData.BurnTimeRemaining, _craftNode.Controls.Throttle);
				}
				else
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Aborting auto-burn with zero dv");
				}
			}
			else
			{
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Cannot perform an auto-burn using a craft without controls");
			}
			bool flag = IsBurnAchieveable(maneuverNode);
			double num2 = Vector3d.Dot(maneuverNode.BurnData.DeltaVRemaining, _initialDeltaV);
			if (num2 < 0.0 || num == 0f || !flag)
			{
				if (!flag)
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Aborting: auto-burn not achievable");
				}
				else if (!_achievementUnlockedAutoburn)
				{
					_achievementUnlockedAutoburn = true;
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.FirstPlannedBurn);
				}
				CompleteBurnPhase();
			}
			else
			{
				_craftNode.Controls.Throttle = num;
			}
			Progress = 1f - (float)(maneuverNode.BurnData.DeltaVRemaining.magnitude / _initialDeltaV.magnitude);
			if (NextPhase == ManeuverPhase.Complete)
			{
				Debug.LogFormat($"Phase: {NextPhase.ToString()}, dvApplied: {maneuverNode.BurnData.DeltaVApplied.magnitude}, dvInitial: {_initialDeltaV.magnitude}, dvRemaining: {maneuverNode.BurnData.DeltaVMagRemaining}, throttle: {_craftNode.Controls.Throttle}, dvToTargetVsInitial: {num2}");
			}
		}

		private void UpdateManualBurn(ManeuverNodeScript maneuverNode, ChainNodeManager chainNodeManager)
		{
			if (maneuverNode.Locked)
			{
				Progress = 1f - (float)(maneuverNode.BurnData.DeltaVRemaining.magnitude / maneuverNode.DeltaV.magnitude);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Input;
using Assets.Scripts.Craft.Parts.Modifiers.Mfd;
using Assets.Scripts.Flight.GameView;
using Assets.Scripts.Flight.GameView.Cameras;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using ModApi.Audio;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Program;
using ModApi.Craft.Program.Craft;
using ModApi.Expressions;
using ModApi.Expressions.Tokens;
using ModApi.Flight;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Ioc;
using ModApi.Planet;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Vizzy.Craft
{
	public class CraftService : ICraftService
	{
		private class VizzyNumberVariableToken : VizzyVariableTokenBase<double>
		{
			public VizzyNumberVariableToken(FlightProgramScript script, string varName)
				: base(script, varName)
			{
			}

			public override Expression GetExpression(Context context, ParameterExpression dataSlots)
			{
				FlightProgramScript script = base.Script;
				string name = base.VarName;
				return ((Expression<Func<double>>)(() => script.GetVariableValueAsDoubleAndThrow(name))).Body;
			}

			public override Func<double[], double> GetFunc(Context context)
			{
				FlightProgramScript script = base.Script;
				string name = base.VarName;
				return (double[] _) => script.GetVariableValueAsDoubleAndThrow(name);
			}
		}

		private abstract class VizzyVariableTokenBase<T> : Token<T>
		{
			public override bool IsFinal => true;

			protected FlightProgramScript Script { get; set; }

			protected string VarName { get; set; }

			public VizzyVariableTokenBase(FlightProgramScript script, string varName)
			{
				Script = script;
				VarName = varName;
			}

			public abstract override Expression GetExpression(Context context, ParameterExpression dataSlots);

			public abstract override Func<double[], T> GetFunc(Context context);
		}

		private class VizzyVectorVariableToken : VizzyVariableTokenBase<Vector3d>
		{
			public VizzyVectorVariableToken(FlightProgramScript script, string varName)
				: base(script, varName)
			{
			}

			public override Expression GetExpression(Context context, ParameterExpression dataSlots)
			{
				FlightProgramScript script = base.Script;
				string name = base.VarName;
				return ((Expression<Func<Vector3d>>)(() => script.GetVariableValueAsVectorAndThrow(name))).Body;
			}

			public override Func<double[], Vector3d> GetFunc(Context context)
			{
				FlightProgramScript script = base.Script;
				string name = base.VarName;
				return (double[] _) => script.GetVariableValueAsVectorAndThrow(name);
			}
		}

		private ICommandPod _commandPod;

		private ICraftScript _craftScript;

		private FlightProgramScript _flightProgramScript;

		private IFlightScene _flightScene;

		private Dictionary<Delegate, InputControllerExpression> _inputControllerInputs = new Dictionary<Delegate, InputControllerExpression>();

		private ILogService _logService;

		private MfdScript _mfd;

		private double _soundTimer;

		private UserInputRequest _userInputRequest;

		public ICraftScript CraftScript => _craftScript;

		public ICraftFlightData Data => _craftScript.FlightData;

		public PartData ExecutingPart => _flightProgramScript.PartScript.Data;

		public double FrameDeltaTime { get; set; }

		public ICraftInputs Inputs { get; private set; }

		public INavSphere NavSphere => _flightScene.FlightSceneUI.NavSphere;

		public Vector3d PidGainsPitch => ((Vector3d?)_commandPod?.Part?.GetModifier<CommandPodData>()?.PidGainPitch) ?? Vector3d.zero;

		public Vector3d PidGainsRoll => ((Vector3d?)_commandPod?.Part?.GetModifier<CommandPodData>()?.PidGainRoll) ?? Vector3d.zero;

		public TimeModeType TimeMode
		{
			get
			{
				return (TimeModeType)_flightScene.TimeManager.ModeIndex;
			}
			set
			{
				string failReason = null;
				if (_flightScene.TimeManager.CanSetTimeMultiplierMode((int)value, out failReason))
				{
					_flightScene.TimeManager.SetMode((int)value);
				}
				else
				{
					_logService.LogError(failReason);
				}
			}
		}

		public double TimeSinceLaunch { get; set; }

		public double TotalTime => _flightScene.FlightState.Time;

		private MfdScript Mfd
		{
			get
			{
				if (_mfd == null)
				{
					_mfd = _flightProgramScript.PartScript.GetModifier<MfdScript>();
				}
				return _mfd;
			}
		}

		public CraftService(FlightProgramScript flightProgramScript, IFlightScene flightScene, ILogService logService)
		{
			_logService = logService;
			_flightProgramScript = flightProgramScript;
			_flightScene = flightScene;
			OnCraftChanged();
		}

		public void ActivateNextStage()
		{
			_commandPod.ActivateStage();
		}

		public void BroadcastMessage(BroadcastScope scope, string messageName, ExpressionResult data)
		{
			_flightProgramScript.BroadcastMessage(scope, messageName, data);
		}

		public Vector3d ConvertLatLongAglToPlanetPosition(Vector3d latLongAgl)
		{
			if (double.IsNaN(latLongAgl.x) || double.IsNaN(latLongAgl.y) || double.IsNaN(latLongAgl.z))
			{
				return Vector3d.zero;
			}
			IPlanetNode parent = _craftScript.CraftNode.Parent;
			Vector3d surfacePosition = parent.GetSurfacePosition(latLongAgl.x * 0.01745329, latLongAgl.y * 0.01745329, AltitudeType.AboveGroundLevel, latLongAgl.z);
			return parent.SurfaceVectorToPlanetVector(surfacePosition);
		}

		public Vector3d ConvertLatLongAslToPlanetPosition(Vector3d latLongAsl)
		{
			if (double.IsNaN(latLongAsl.x) || double.IsNaN(latLongAsl.y) || double.IsNaN(latLongAsl.z))
			{
				return Vector3d.zero;
			}
			IPlanetNode parent = _craftScript.CraftNode.Parent;
			Vector3d surfacePosition = parent.GetSurfacePosition(latLongAsl.x * 0.01745329, latLongAsl.y * 0.01745329, AltitudeType.AboveSeaLevel, latLongAsl.z);
			return parent.SurfaceVectorToPlanetVector(surfacePosition);
		}

		public Vector3d ConvertLocalToPCI(IPartScript part, Vector3 local)
		{
			Vector3 frameVector = part?.Transform.TransformDirection(local) ?? _craftScript.CenterOfMass.TransformDirection(local);
			return _craftScript.ReferenceFrame.FrameToPlanetVector(frameVector);
		}

		public Vector3 ConvertPCIToLocal(IPartScript part, Vector3d pci)
		{
			Vector3 direction = _craftScript.ReferenceFrame.PlanetToFrameVector(pci);
			return part?.Transform.InverseTransformDirection(direction) ?? _craftScript.CenterOfMass.InverseTransformDirection(direction);
		}

		public Vector3d ConvertPlanetPositionToLatLongAgl(Vector3d position)
		{
			if (double.IsNaN(position.x) || double.IsNaN(position.y) || double.IsNaN(position.z))
			{
				return Vector3d.zero;
			}
			IPlanetNode parent = _craftScript.CraftNode.Parent;
			Vector3d surfacePosition = parent.PlanetVectorToSurfaceVector(position);
			parent.GetSurfaceCoordinates(surfacePosition, out var latitude, out var longitude);
			double num = parent.GetTerrainHeight(position);
			if (parent.PlanetData.HasWater && num < (double)parent.PlanetData.SeaLevel)
			{
				num = parent.PlanetData.SeaLevel;
			}
			return new Vector3d(latitude * 57.29578, longitude * 57.29578, position.magnitude - (parent.PlanetData.Radius + num));
		}

		public Vector3d ConvertPlanetPositionToLatLongAsl(Vector3d position)
		{
			IPlanetNode parent = _craftScript.CraftNode.Parent;
			Vector3d surfacePosition = parent.PlanetVectorToSurfaceVector(position);
			parent.GetSurfaceCoordinates(surfacePosition, out var latitude, out var longitude);
			return new Vector3d(latitude * 57.29578, longitude * 57.29578, position.magnitude - parent.PlanetData.Radius);
		}

		public IMfdWidget CreateMfdWidget(MfdWidgetType widgetType, string name, string icon)
		{
			try
			{
				IMfdWidget mfdWidget = Mfd.CreateWidget(widgetType, name);
				if (!string.IsNullOrWhiteSpace(icon) && mfdWidget is ISpriteWidget spriteWidget)
				{
					spriteWidget.Icon = icon;
				}
				return mfdWidget;
			}
			catch (Exception ex)
			{
				_logService.LogError(ex.ToString());
				return null;
			}
		}

		public void DisplayMessage(string message, float duration)
		{
			ICraftScript craftScript = CraftScript;
			if (craftScript != null && craftScript.CraftNode?.IsPlayer == true)
			{
				_flightScene.FlightSceneUI.ShowMessage(message, devlog: false, duration);
			}
		}

		public bool GetActivationGroupState(int activationGroup)
		{
			bool result = false;
			if (activationGroup >= 1 && activationGroup <= _commandPod.ActivationGroupNames.Count)
			{
				result = _commandPod.GetActivationGroupState(activationGroup);
			}
			else
			{
				_logService.LogError($"Activation Group {activationGroup} is outside of allowable range: 1-{_commandPod.ActivationGroupNames.Count}");
			}
			return result;
		}

		public ICraftNode GetCraftNode(int craftNodeId)
		{
			return _flightScene.FlightState.CraftNodes.Where((ICraftNode x) => x.NodeId == craftNodeId).FirstOrDefault();
		}

		public ICraftNode GetCraftNodeByName(string craftName)
		{
			if (string.IsNullOrEmpty(craftName))
			{
				return _craftScript.CraftNode;
			}
			return _flightScene.FlightState.CraftNodes.Where((ICraftNode x) => string.Compare(x.Name, craftName, ignoreCase: true) == 0).FirstOrDefault();
		}

		public Delegate GetInputExpression(string text)
		{
			var (inputControllerExpression, obj) = InputControllerExpression.CreateAnyType(text, delegate(Context c)
			{
				c.VariableResolve += CustomResolve;
				c.AddFunction<Func<string, int>>("listLen", _flightProgramScript.GetListLengthAndThrow);
				c.AddFunction<Func<string, int, double>>("listNum", _flightProgramScript.GetListValueAsDoubleAndThrow);
				c.AddFunction<Func<string, int, bool>>("listBool", _flightProgramScript.GetListValueAsBooleanAndThrow);
				c.AddFunction<Func<string, int, string>>("listStr", _flightProgramScript.GetListValueAsStringAndThrow);
				c.AddFunction<Func<string, int, Vector3d>>("listVec", _flightProgramScript.GetListValueAsVectorAndThrow);
			});
			inputControllerExpression.RefreshInput(_flightProgramScript.PartScript);
			_inputControllerInputs.Add(obj, inputControllerExpression);
			return obj;
			Token CustomResolve(string name)
			{
				if (name.StartsWith("v:"))
				{
					return new VizzyVectorVariableToken(_flightProgramScript, name.Substring(2));
				}
				return new VizzyNumberVariableToken(_flightProgramScript, name);
			}
		}

		public IEnumerable<IMfdWidget> GetMfdChildWidgets(string parentName)
		{
			return _mfd.GetMfdChildWidgets(parentName);
		}

		public IMfdWidget GetMfdWidget(string widgetName)
		{
			return Mfd?.GetWidget(widgetName);
		}

		public IPlanetNode GetPlanet(string planetName)
		{
			return _flightScene.FlightState.RootNode.FindPlanet(planetName);
		}

		public Vector3d GetTerrainColor(Vector3d latLong)
		{
			if (double.IsNaN(latLong.x) || double.IsNaN(latLong.y))
			{
				return Vector3d.zero;
			}
			IPlanetNode parent = _craftScript.CraftNode.Parent;
			Vector3d normalized = parent.GetSurfacePosition(latLong.x * 0.01745329, latLong.y * 0.01745329, AltitudeType.AboveSeaLevel, 0.0).normalized;
			ITerrainGenerator terrainGenerator = parent.TerrainGenerator;
			bool hasWater = parent.PlanetData.HasWater;
			float num = (hasWater ? terrainGenerator.SeaLevel : 0f);
			PlanetVertexData planetVertexData = terrainGenerator.GetVertexData(VertexDataRequestType.HeightAndBiomeData, normalized);
			if (hasWater && planetVertexData.Height < (double)num)
			{
				planetVertexData = terrainGenerator.GetVertexDataWaterPass();
			}
			return new Vector3d(planetVertexData.Color.r, planetVertexData.Color.g, planetVertexData.Color.b);
		}

		public double GetTerrainHeight(Vector3d latLong)
		{
			if (double.IsNaN(latLong.x) || double.IsNaN(latLong.y))
			{
				return 0.0;
			}
			IPlanetNode parent = _craftScript.CraftNode.Parent;
			Vector3d normalized = parent.GetSurfacePosition(latLong.x * 0.01745329, latLong.y * 0.01745329, AltitudeType.AboveSeaLevel, 0.0).normalized;
			return parent.TerrainGenerator.GetHeight(normalized);
		}

		public void OnCraftChanged()
		{
			ICommandPod commandPod = _flightProgramScript.PartScript.GetModifier<CommandPodScript>();
			if (commandPod == null)
			{
				commandPod = _flightProgramScript.PartScript.CommandPod;
			}
			if (commandPod != null)
			{
				_commandPod = commandPod;
				Inputs = new CraftInputs(_commandPod.Controls);
				_craftScript = _commandPod.Part.PartScript.CraftScript;
			}
			else
			{
				Debug.LogErrorFormat("Cannot find a command pod for the part {0} (id={1})", _flightProgramScript?.PartScript?.Data?.Name, _flightProgramScript?.PartScript?.Data?.Id);
			}
		}

		public void PlayBeepSound(float pitch, float volume, float duration)
		{
			AudioSource audioSource = _flightProgramScript.gameObject.GetComponent<AudioSource>();
			if (audioSource == null)
			{
				audioSource = Game.Instance.AudioPlayer.CreateAudioSource(AudioLibrary.Vizzy.Beep, _flightProgramScript.gameObject, userInterfaceSound: false);
				audioSource.dopplerLevel = 0f;
				audioSource.spatialBlend = 1f;
				audioSource.loop = true;
			}
			audioSource.pitch = pitch / 1000f;
			audioSource.volume = Mathf.Clamp01(volume);
			if (!audioSource.isPlaying)
			{
				audioSource.Play();
			}
			_soundTimer = duration;
		}

		public void ReleaseInputExpression(Delegate func)
		{
			if ((object)func != null && _inputControllerInputs.ContainsKey(func))
			{
				_inputControllerInputs.Remove(func);
			}
		}

		public UserInputRequest RequestUserInput(string message, string content = null)
		{
			if (_userInputRequest == null && !Game.Instance.UserInterface.AnyDialogsOpen)
			{
				_userInputRequest = new UserInputRequest();
				InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
				inputDialogScript.Modal = false;
				inputDialogScript.MessageText = ExecutingPart?.Name + " part is requesting input.\n" + message;
				if (!string.IsNullOrEmpty(content))
				{
					inputDialogScript.InputText = content;
				}
				inputDialogScript.OkayClicked += delegate(InputDialogScript d)
				{
					d.Close();
					_userInputRequest.IsComplete = true;
					_userInputRequest.Result = d.InputText;
					_userInputRequest = null;
				};
				inputDialogScript.CancelClicked += delegate(InputDialogScript d)
				{
					d.Close();
					_userInputRequest.IsComplete = true;
					_userInputRequest.IsCanceled = true;
					_userInputRequest.Result = string.Empty;
					_userInputRequest = null;
				};
				return _userInputRequest;
			}
			return null;
		}

		public void SetActivationGroupState(int activationGroup, bool state)
		{
			if (activationGroup >= 1 && activationGroup <= _commandPod.ActivationGroupNames.Count)
			{
				_commandPod.SetActivationGroupState(activationGroup, state);
			}
			else
			{
				_logService.LogError($"Activation Group {activationGroup} is outside of allowable range: 1-{_commandPod.ActivationGroupNames.Count}");
			}
		}

		public void SetCameraProperty(CameraProperty cameraProperty, ExpressionResult value)
		{
			_ = _flightScene.ViewManager.GameView.GameCamera;
			CameraManagerScript cameraControllerManager = (_flightScene.ViewManager.GameView as GameViewScript).CameraControllerManager;
			CameraController currentCameraController = cameraControllerManager.CurrentCameraController;
			switch (cameraProperty)
			{
			case CameraProperty.CameraMode:
			{
				CameraMode cameraMode2 = cameraControllerManager.CameraModes.FirstOrDefault((CameraMode x) => string.CompareOrdinal(x.Name, value.TextValue) == 0);
				if (cameraMode2 != null)
				{
					cameraControllerManager.SelectCameraMode(cameraMode2);
				}
				break;
			}
			case CameraProperty.CameraModeIndex:
			{
				int index = (int)(value.NumberValue - 1.0) % cameraControllerManager.CameraModes.Count;
				CameraMode cameraMode = cameraControllerManager.CameraModes[index];
				if (cameraMode != null)
				{
					cameraControllerManager.SelectCameraMode(cameraMode);
				}
				break;
			}
			case CameraProperty.RotationX:
				currentCameraController.CurrentRotation = new Vector2((float)value.NumberValue, currentCameraController.CurrentRotation.y);
				break;
			case CameraProperty.RotationY:
				currentCameraController.CurrentRotation = new Vector2(currentCameraController.CurrentRotation.x, (float)value.NumberValue);
				break;
			case CameraProperty.Tilt:
				currentCameraController.CurrentTilt = (float)value.NumberValue;
				break;
			case CameraProperty.Zoom:
				currentCameraController.CurrentZoom = (float)value.NumberValue;
				break;
			}
		}

		public void SetPartFuelTransfer(IPartScript part, FuelTransferMode fuelTransfer)
		{
			FuelTankScript modifier = part.GetModifier<FuelTankScript>();
			if (modifier != null)
			{
				modifier.FuelTransferMode = fuelTransfer;
			}
		}

		public void SetPidGainsPitch(Vector3 pid)
		{
			CommandPodData commandPodData = CraftScript.ActiveCommandPod?.Part?.GetModifier<CommandPodData>();
			if (commandPodData != null && CraftScript.ActiveCommandPod?.AutoPilot != null)
			{
				commandPodData.PidGainPitch = pid;
				CraftScript.ActiveCommandPod.AutoPilot.PidGainsPitch = pid;
			}
		}

		public void SetPidGainsRoll(Vector3 pid)
		{
			CommandPodData commandPodData = CraftScript.ActiveCommandPod?.Part?.GetModifier<CommandPodData>();
			if (commandPodData != null && CraftScript.ActiveCommandPod?.AutoPilot != null)
			{
				commandPodData.PidGainRoll = pid;
				CraftScript.ActiveCommandPod.AutoPilot.PidGainsRoll = pid;
			}
		}

		public void SetTargetNode(string name)
		{
			IIocContainer iocContainer = Game.Instance.FlightScene.IocContainer;
			IMapViewContext context = (Game.Instance.FlightScene.ViewManager.MapViewManager.MapView as MapViewScript).Context;
			IItemRegistry itemRegistry = iocContainer.Resolve<IItemRegistry>(context);
			ITargetableItem targetableItem = null;
			if (!string.IsNullOrWhiteSpace(name))
			{
				foreach (MapItem item in itemRegistry.Items)
				{
					if (item is ITargetableItem && string.Compare(item?.OrbitInfo?.OrbitNode?.Name, name, ignoreCase: true) == 0)
					{
						targetableItem = item as ITargetableItem;
					}
				}
				if (targetableItem == null)
				{
					_logService.LogError("CraftService.SetTarget could not find target with name {0}");
				}
			}
			iocContainer.Resolve<INavigationTargetProvider>(context).SetNavigationTarget(targetableItem);
		}

		public void SetTargetVector(Vector3d position)
		{
			IIocContainer iocContainer = Game.Instance.FlightScene.IocContainer;
			IMapViewContext context = (Game.Instance.FlightScene.ViewManager.MapViewManager.MapView as MapViewScript).Context;
			iocContainer.Resolve<INavigationTargetProvider>(context).SetNavSphereTarget(new PositionTarget
			{
				Position = position,
				Parent = _craftScript?.CraftNode?.Parent
			});
		}

		public void StopSound()
		{
			_soundTimer = 0.0;
		}

		public void SwitchToCraftNode(ICraftNode craftNode)
		{
			if (!craftNode.IsPlayer)
			{
				bool flag = false;
				if (craftNode.CraftScript != null && _flightScene.ChangePlayersActiveCommandPodImmediate(craftNode.CraftScript.ActiveCommandPod, craftNode))
				{
					flag = true;
				}
				if (!flag)
				{
					_flightScene.ChangePlayersActiveCraftNode(craftNode);
					Debug.Log("Reloading scene to switch craft nodes.");
				}
			}
		}

		public void Update(double deltaTimeWorld, float deltaTimeUnscaled)
		{
			if (!(_soundTimer >= 0.0))
			{
				return;
			}
			_soundTimer -= deltaTimeWorld;
			if (_soundTimer <= 0.0)
			{
				_soundTimer = -1.0;
				AudioSource component = _flightProgramScript.GetComponent<AudioSource>();
				if (component != null)
				{
					component.volume = 0f;
				}
			}
		}

		public void UpdateInputs(IPartScript partScript)
		{
			foreach (InputControllerExpression value in _inputControllerInputs.Values)
			{
				value.RefreshInput(partScript);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Vizzy.Craft;
using ModApi;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Program;
using ModApi.Craft.Program.Craft;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class FlightProgramScript : PartModifierScript<FlightProgramData>, IFlightStart, IGameLoopItem, IFlightUpdate
	{
		public class ThreadInfo
		{
			public string CurrentInstruction
			{
				get
				{
					if (Thread?.Context?.NextInstruction != null)
					{
						return Thread?.Context?.NextInstruction.GetType().Name.Replace("Instruction", string.Empty);
					}
					return "None";
				}
			}

			public int Index { get; set; }

			public string Status
			{
				get
				{
					if (Thread?.Context?.NextInstruction != null)
					{
						return "Running...";
					}
					return "Stopped.";
				}
			}

			public Thread Thread { get; set; }

			public ThreadInfo(Thread thread, int index)
			{
				Thread = thread;
				Index = index;
			}
		}

		private static float _batteryMessageTime;

		private IFuelSource _battery;

		private EventMigrator<ICommandPod> _craftControlsChangedMigrator;

		private CraftService _craftService;

		private bool _eventsInitialized;

		private LogModel _logModel = new LogModel();

		private IInspectorPanel _logPanel;

		private LogService _logService;

		private float _powerConsumption;

		private bool _powered;

		private Process _process;

		private ThreadInfo _threadInfo;

		private int _viewThreadIndex;

		public FlightProgram FlightProgram { get; private set; }

		public void BroadcastMessage(BroadcastScope scope, string messageName, ExpressionResult data)
		{
			switch (scope)
			{
			case BroadcastScope.Program:
				OnReceiveMessage(messageName, data);
				break;
			case BroadcastScope.Craft:
			{
				foreach (FlightProgramScript flightProgramScript in (base.PartScript.CraftScript as CraftScript).FlightProgramScripts)
				{
					flightProgramScript.OnReceiveMessage(messageName, data);
				}
				break;
			}
			case BroadcastScope.AllCrafts:
				if (_battery != null && base.Data.BroadcastPowerConsumptionPerByte != 0f)
				{
					_powerConsumption += base.Data.BroadcastPowerConsumptionPerByte * (float)(data.TextValue.Length + messageName.Length) * 0.001f;
				}
				{
					foreach (CraftNode item in Game.Instance.FlightScene.ViewManager.GameView.PlanetNode.DynamicNodes.OfType<CraftNode>())
					{
						if (!item.IsLoadedInGameView)
						{
							continue;
						}
						foreach (FlightProgramScript flightProgramScript2 in (item.CraftScript as CraftScript).FlightProgramScripts)
						{
							flightProgramScript2.OnReceiveMessage(messageName, data);
						}
					}
					break;
				}
			}
		}

		public override void FlightEnd()
		{
			base.FlightEnd();
			UpdateCraftEventSubscription(subscribe: false, base.PartScript.CraftScript);
		}

		public void FlightStart(in FlightFrameData frame)
		{
			if (base.Data.FlightProgramXml != null)
			{
				UpdateCraftEventSubscription(subscribe: true, base.PartScript.CraftScript);
				base.PartScript.MovedToNewCraft += OnMovedToNewCraft;
				StartProgram();
			}
		}

		public void FlightUpdate(in FlightFrameData frame)
		{
			_powerConsumption = 0f;
			base.Data.TimeSinceLaunch += frame.DeltaTimeWorld;
			if (_process == null || (!base.PartScript.Data.Activated && base.PartScript.Data.Config.SupportsActivation && base.Data.PowerConsumptionPerInstruction != 0f))
			{
				return;
			}
			_craftService.FrameDeltaTime = frame.DeltaTimeWorld;
			_craftService.TimeSinceLaunch = base.Data.TimeSinceLaunch;
			IFuelSource battery = _battery;
			if ((battery != null && !battery.IsEmpty) || base.Data.PowerConsumptionPerInstruction == 0f)
			{
				int num = _process.Update(frame.DeltaTimeWorld, base.Data.MaxInstructionsPerFrame);
				_powered = true;
				if (base.Data.PowerConsumptionPerInstruction != 0f)
				{
					_powerConsumption = base.Data.PowerConsumptionPerInstruction * (float)num * 0.001f;
					_battery.RemoveFuel(_powerConsumption * Time.deltaTime);
				}
			}
			else if (_powered)
			{
				_powered = false;
				if (_batteryMessageTime < Time.unscaledTime)
				{
					_batteryMessageTime = Time.unscaledTime + 20f;
					string text = "Your vizzy program has ran out of juice, charge your batteries for it to resume its program.";
					Game.Instance.FlightScene.FlightSceneUI.FlightLog.AddLog(text, FlightLogEntryCategory.Default);
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage(text, devlog: true);
				}
			}
			_craftService.Update(frame.DeltaTimeWorld, frame.DeltaTimeUnscaled);
		}

		public double? GetGlobalValueAsDouble(string name)
		{
			return _process?.GlobalVariables?.GetVariable(name)?.Value?.NumberValue;
		}

		public Vector3d? GetGlobalValueAsVector(string name)
		{
			return _process?.GlobalVariables?.GetVariable(name)?.Value?.VectorValue;
		}

		public ExpressionResult GetGlobalVariable(string name)
		{
			Variable variable = _process?.GlobalVariables?.GetVariable(name);
			if (variable != null)
			{
				ExpressionResult expressionResult = new ExpressionResult();
				expressionResult.Set(variable.Value);
				return expressionResult;
			}
			return null;
		}

		public double GetVariableValueAsDoubleAndThrow(string name)
		{
			try
			{
				return GetVariable(name).Value.NumberValue;
			}
			catch (NullReferenceException)
			{
				throw new ProgramException("Could not find Vizzy variable in local or global scope: " + name);
			}
		}

		public ExpressionListItem GetListValueAndThrow(string name, int index)
		{
			Variable obj = GetVariable(name) ?? throw new ProgramException("Could not find Vizzy variable in local or global scope: " + name);
			if (!obj.IsList)
			{
				throw new ProgramException("Vizzy variable '" + name + "' is not a list, but was accessed via the listNum function");
			}
			IReadOnlyList<ExpressionListItem> listValue = obj.Value.ListValue;
			if (index > listValue.Count || index <= 0)
			{
				throw new ProgramException($"Vizzy list variable access for '{name}' was out of range (tried to access index {index} in a list with length {listValue.Count})");
			}
			return listValue[index - 1];
		}

		public int GetListLengthAndThrow(string name)
		{
			Variable obj = GetVariable(name) ?? throw new ProgramException("Could not find Vizzy variable in local or global scope: " + name);
			if (!obj.IsList)
			{
				throw new ProgramException("Vizzy variable '" + name + "' is not a list, but was accessed via the listNum function");
			}
			return obj.Value.ListValue.Count;
		}

		public double GetListValueAsDoubleAndThrow(string name, int index)
		{
			return GetListValueAndThrow(name, index).NumberValue;
		}

		public Vector3d GetListValueAsVectorAndThrow(string name, int index)
		{
			return GetListValueAndThrow(name, index).VectorValue;
		}

		public string GetListValueAsStringAndThrow(string name, int index)
		{
			return GetListValueAndThrow(name, index).StringValue;
		}

		public bool GetListValueAsBooleanAndThrow(string name, int index)
		{
			return GetListValueAndThrow(name, index).BooleanValue;
		}

		public Vector3d GetVariableValueAsVectorAndThrow(string name)
		{
			try
			{
				return GetVariable(name).Value.VectorValue;
			}
			catch (NullReferenceException)
			{
				throw new ProgramException("Could not find Vizzy variable in local or global scope: " + name);
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			_battery = base.PartScript.BatteryFuelSource;
			if (_craftService != null)
			{
				_craftService.OnCraftChanged();
				if (!_eventsInitialized)
				{
					InitializeEvents();
				}
				_craftService.UpdateInputs(base.PartScript);
			}
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			_craftService?.UpdateInputs(base.PartScript);
			_battery = base.PartScript.BatteryFuelSource;
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			GroupModel groupModel = new GroupModel("Flight Program");
			model.AddGroup(groupModel);
			groupModel.Add(new ToggleModel("Output Dev Console", () => base.Data.OutputToDevConsole, delegate(bool x)
			{
				SetOutputToDevConsole(x);
			}));
			groupModel.Add(new TextModel("Power Usage", () => Units.GetPowerString(_powerConsumption * 1000f)));
			groupModel.Add(new TextModel("Threads", () => _process?.Threads.Count.ToString()));
			SpinnerModel spinnerModel = new SpinnerModel(() => $"Thread {_threadInfo?.Index}");
			ViewThread(0);
			spinnerModel.NextClicked = delegate
			{
				ViewThread(1);
			};
			spinnerModel.PrevClicked = delegate
			{
				ViewThread(-1);
			};
			groupModel.Add(spinnerModel);
			groupModel.Add(new TextModel(string.Empty, () => (base.PartScript.Data.Activated || !base.PartScript.Data.Config.SupportsActivation || !(base.Data.PowerConsumptionPerInstruction > 0f)) ? (_powered ? _threadInfo?.Status : "Out of battery.") : "Paused."));
			groupModel.Add(new TextModel(string.Empty, () => ((!_powered || !base.PartScript.Data.Activated) && base.PartScript.Data.Config.SupportsActivation && base.Data.PowerConsumptionPerInstruction != 0f) ? "..." : _threadInfo?.CurrentInstruction));
			groupModel.Add(new TextButtonModel("View Log", delegate
			{
				CreateLogPanel();
			}));
		}

		public void OnReceiveMessage(string messageName, ExpressionResult data)
		{
			_process?.EventHandler.OnReceiveMessage(messageName, data);
		}

		public void StartProgram()
		{
			XElement flightProgramXml = base.Data.FlightProgramXml;
			try
			{
				if (flightProgramXml != null)
				{
					ProgramSerializer programSerializer = new ProgramSerializer();
					FlightProgram = programSerializer.DeserializeFlightProgram(flightProgramXml);
					CreateProcess(FlightProgram);
				}
			}
			catch (Exception ex)
			{
				FlightProgram = null;
				Debug.LogError("Unable to load flight program from XML: " + ex.ToString());
			}
		}

		public void UpdateXml()
		{
			new ProgramSerializer();
			if (_process != null)
			{
				base.Data.ProcessXml = _process.Serialize();
			}
		}

		public override void ValidatePart(ValidationResult result)
		{
			if (base.Data.PowerConsumptionPerInstruction > 0f || base.Data.BroadcastPowerConsumptionPerByte > 0f)
			{
				if (_battery == null)
				{
					_battery = base.PartScript.BatteryFuelSource;
				}
				result.ValidatFuel(this, _battery);
			}
		}

		private void ClearLog()
		{
			_logModel?.Clear();
		}

		private void CreateLogPanel()
		{
			if (_logPanel == null)
			{
				InspectorModel inspectorModel = new InspectorModel("Log", $"Log - {base.PartScript.Data.Name} #{base.PartScript.Data.Id}");
				inspectorModel.Add(new TextButtonModel("Clear Log", delegate
				{
					ClearLog();
				}));
				inspectorModel.Add(_logModel);
				InspectorPanelCreationInfo inspectorPanelCreationInfo = new InspectorPanelCreationInfo();
				inspectorPanelCreationInfo.StartPosition = InspectorPanelCreationInfo.InspectorStartPosition.UpperLeft;
				inspectorPanelCreationInfo.StartOffset = new Vector2(0f, -80f);
				inspectorPanelCreationInfo.PanelWidth = (Device.IsMobileBuild ? 480 : 640);
				inspectorPanelCreationInfo.Resizable = !Device.IsMobileBuild;
				inspectorPanelCreationInfo.PanelMaxHeight = 0f;
				_logPanel = Game.Instance.UserInterface.CreateInspectorPanel(inspectorModel, inspectorPanelCreationInfo);
				_logPanel.Closed += OnLogPanelClosed;
			}
		}

		private void CreateProcess(FlightProgram flightProgram)
		{
			_logService = new LogService();
			_logService.LogAdded += OnLogMessageAdded;
			_craftService = new CraftService(this, Game.Instance.FlightScene, _logService);
			_process = new Process(FlightProgram, _logService, _craftService, base.Data.MaxThreads);
			_process.MaxCallStackSize = base.Data.MaxCallStackSize;
			if (base.Data.ProcessXml != null)
			{
				_process.Deserialize(base.Data.ProcessXml);
			}
			else
			{
				_process.Start();
			}
		}

		private Variable GetVariable(string name)
		{
			return _process.ActiveThread?.Context?.GetLocalVariable(name) ?? _process.GlobalVariables.GetVariable(name);
		}

		private void InitializeEvents()
		{
			_eventsInitialized = true;
			_craftControlsChangedMigrator = new EventMigrator<ICommandPod>(() => base.PartScript.CommandPod, delegate(ICommandPod commandPod)
			{
				commandPod.ControlsChanged += OnCommandPodControlsChanged;
			}, delegate(ICommandPod commandPod)
			{
				commandPod.ControlsChanged -= OnCommandPodControlsChanged;
			});
			_craftControlsChangedMigrator.AddMigrationTrigger(() => base.PartScript, delegate(EventMigrator<ICommandPod> migrator, IPartScript partScript)
			{
				partScript.CommandPodChanged += migrator.MigrateEvent;
			}, delegate(EventMigrator<ICommandPod> migrator, IPartScript partScript)
			{
				partScript.CommandPodChanged -= migrator.MigrateEvent;
			});
			base.PartScript.MovedToNewCraft += OnMovedToNewCraft;
		}

		private void OnCommandPodControlsChanged(ICommandPod source, bool adjustControlsToCom)
		{
			_craftService?.UpdateInputs(base.PartScript);
		}

		private void OnCraftNodeChangedSoI(IOrbitNode source)
		{
			_process?.EventHandler.OnChangeSoi(source.Parent.Name);
		}

		private void OnCraftPartCollisionEnter(IPartFlightCollision partCollision)
		{
			_process?.EventHandler.OnPartCollision(partCollision);
		}

		private void OnCraftPartExploded(PartData part)
		{
			_process?.EventHandler.OnPartExploded(part);
		}

		private void OnDockComplete(string playerCraftName, int playerNodeId, string otherCraftName, int otherNodeId)
		{
			_process?.EventHandler.OnCraftDocked(playerCraftName, otherCraftName);
		}

		private void OnLogMessageAdded(LogMessage log)
		{
			_logModel?.AddMessage(log.ToString());
			if (base.Data.OutputToDevConsole)
			{
				if (log.Error)
				{
					Debug.LogError(log.ToString());
				}
				else
				{
					Debug.Log(log.ToString());
				}
			}
		}

		private void OnLogPanelClosed(IInspectorPanel panel)
		{
			_logPanel = null;
		}

		private void OnMovedToNewCraft(ICraftScript oldCraft, ICraftScript newCraft)
		{
			UpdateCraftEventSubscription(subscribe: false, oldCraft);
			UpdateCraftEventSubscription(subscribe: true, newCraft);
			_craftService?.UpdateInputs(base.PartScript);
		}

		private void SetOutputToDevConsole(bool enabled)
		{
			base.Data.OutputToDevConsole = enabled;
		}

		private void UpdateCraftEventSubscription(bool subscribe, ICraftScript craft)
		{
			if (craft == null)
			{
				return;
			}
			if (subscribe)
			{
				craft.PartCollisionEnter += OnCraftPartCollisionEnter;
				craft.PartExploded += OnCraftPartExploded;
				craft.DockComplete += OnDockComplete;
				if (craft.CraftNode != null)
				{
					craft.CraftNode.ChangedSoI += OnCraftNodeChangedSoI;
				}
			}
			else
			{
				craft.PartCollisionEnter -= OnCraftPartCollisionEnter;
				craft.PartExploded -= OnCraftPartExploded;
				craft.DockComplete -= OnDockComplete;
				if (craft.CraftNode != null)
				{
					craft.CraftNode.ChangedSoI -= OnCraftNodeChangedSoI;
				}
			}
		}

		private void ViewThread(int advance)
		{
			Process process = _process;
			if (process != null && process.Threads.Count > 0)
			{
				_viewThreadIndex += advance;
				if (_viewThreadIndex < 0)
				{
					_viewThreadIndex = _process.Threads.Count - 1;
				}
				_viewThreadIndex %= _process.Threads.Count;
				_threadInfo = new ThreadInfo(_process?.Threads[_viewThreadIndex], _viewThreadIndex);
			}
			else
			{
				_threadInfo = new ThreadInfo(null, 0);
			}
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			FlightStart(in frame);
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			FlightUpdate(in frame);
		}
	}
}

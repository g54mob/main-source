using System;
using Restory.Data.Remapping;
using Rewired;
using UnityEngine;

namespace Restory.Remapping
{
	public sealed class InputRemapping
	{
		private int playerId;

		private ControllerType controllerType;

		private int controllerid;

		private Restory.Data.Remapping.InputAction inputAction;

		private AxisRange axisRange;

		private IInputUserData input;

		private readonly InputMapper inputMapper = new InputMapper();

		public int PlayerId => playerId;

		public ControllerType ControllerType => controllerType;

		public int Controllerid => controllerid;

		public Restory.Data.Remapping.InputAction InputAction => inputAction;

		public AxisRange AxisRange => axisRange;

		public InputMapper.Status Status => inputMapper.status;

		public InputMapper.Options Options => inputMapper.options;

		public event Action StartedEvent;

		public event Action StoppedEvent;

		public event Action<string> CanceledEvent;

		public event Action InputMappedEvent;

		public event Action<string> ErrorEvent;

		public event Action TimedOutEvent;

		public InputRemapping(IInputUserData input, int playerId, ControllerType controllerType, int controllerid)
		{
			this.input = input;
			this.playerId = playerId;
			this.controllerType = controllerType;
			this.controllerid = controllerid;
			inputMapper.StartedEvent += InputMapper_StartedEvent;
			inputMapper.StoppedEvent += InputMapper_StoppedEvent;
			inputMapper.CanceledEvent += InputMapper_CanceledEvent;
			inputMapper.ErrorEvent += InputMapper_ErrorEvent;
			inputMapper.TimedOutEvent += InputMapper_TimedOutEvent;
			inputMapper.InputMappedEvent += InputMapper_InputMappedEvent;
			inputMapper.ConflictFoundEvent += InputMapper_ConflictFoundEvent;
		}

		~InputRemapping()
		{
			inputMapper.Clear();
		}

		public bool Start(Restory.Data.Remapping.InputAction inputAction, AxisRange axisRange)
		{
			this.inputAction = inputAction;
			this.axisRange = axisRange;
			if (GetContext(out var context))
			{
				return inputMapper.Start(context);
			}
			return false;
		}

		public void Stop()
		{
			inputMapper.Stop();
		}

		private bool GetContext(out InputMapper.Context context)
		{
			if (input.ActionsDependencyMap.GetRewiredFirstActionElementMap(playerId, controllerType, controllerid, inputAction, axisRange, out var actionElementMap))
			{
				context = new InputMapper.Context
				{
					actionId = actionElementMap.actionId,
					actionRange = axisRange,
					controllerMap = actionElementMap.controllerMap,
					actionElementMapToReplace = actionElementMap
				};
				return true;
			}
			context = null;
			return false;
		}

		private void InputMapper_ConflictFoundEvent(InputMapper.ConflictFoundEventData data)
		{
			string text = "<color=yellow>Assignment: </color>\n  " + $"<color=yellow>Action: {data.assignment.action.descriptiveName}({data.assignment.action.id}), " + $"KeyCode: {data.assignment.keyCode}, " + "Map: " + data.assignment.controllerMap.name + "</color>";
			string text2 = $"<color=yellow>Conflicts {data.conflicts.Count}: </color>";
			foreach (ElementAssignmentConflictInfo conflict in data.conflicts)
			{
				text2 = text2 + "\n   <color=yellow>" + $"Map: id{conflict.controllerMapId}, " + $"MapCategoryId: {conflict.controllerMap.categoryId}, " + "ElementMap: " + conflict.elementMap.elementIdentifierName + ", " + $"Action: {conflict.action.descriptiveName}({conflict.action.id})" + "</color>";
			}
			Debug.Log(string.Concat(string.Concat("<color=yellow>[InputRemapping] Rewired: Several actions mapped to same button!</color>" + "\n" + text, "\n", text2), $"\n<color=yellow>isProtected: {data.isProtected}</color>") ?? "");
			_ = string.Empty;
			data.responseCallback(InputMapper.ConflictResponse.Add);
			Debug.Log("<color=yellow>[InputRemapping] Rewired Result: Action buttons have been added</color>");
		}

		private void InputMapper_InputMappedEvent(InputMapper.InputMappedEventData data)
		{
			InputButtonData inputButtonData = new InputButtonData
			{
				elementIdentifierId = data.actionElementMap.elementIdentifierId,
				keyboardKeyCode = data.actionElementMap.keyCode
			};
			input.SetInputButtonData(playerId, controllerType, controllerid, inputAction, axisRange, inputButtonData);
			this.InputMappedEvent?.Invoke();
		}

		private void InputMapper_StartedEvent(InputMapper.StartedEventData data)
		{
			this.StartedEvent?.Invoke();
		}

		private void InputMapper_StoppedEvent(InputMapper.StoppedEventData data)
		{
			this.StoppedEvent?.Invoke();
		}

		private void InputMapper_CanceledEvent(InputMapper.CanceledEventData data)
		{
			this.CanceledEvent?.Invoke(data.message);
		}

		private void InputMapper_ErrorEvent(InputMapper.ErrorEventData data)
		{
			this.ErrorEvent?.Invoke(data.message);
		}

		private void InputMapper_TimedOutEvent(InputMapper.TimedOutEventData data)
		{
			this.TimedOutEvent?.Invoke();
		}
	}
}

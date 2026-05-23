using System;
using System.Collections.Generic;
using Presentation.CameraView;
using UnityEngine;

namespace Commands
{
	public class CommandManagerUndoStack
	{
		public class Value
		{
			public ICommandUndo Command;

			public Vector3 CameraPosition;

			public float CameraZoomPercentage;

			public float CameraTargetYaw;

			public float CameraTargetPitch;

			public Value(ICommandUndo command, CameraView cameraView)
			{
				Command = command;
				CameraPosition = cameraView.OriginPosition;
				CameraZoomPercentage = cameraView.CurrentZoomPercentage;
				CameraTargetYaw = cameraView.OriginYawRotation;
				CameraTargetPitch = cameraView.CameraPitchRotation;
			}

			public override string ToString()
			{
				return Command.GetType().Name;
			}
		}

		public Action<int> OnStackSizeUpdated = delegate
		{
		};

		private const int Capacity = 50;

		private readonly List<Value> _commands = new List<Value>(50);

		public int Count => _commands.Count;

		public void Push(Value command)
		{
			if (_commands.Count == 50)
			{
				_commands.RemoveAt(0);
			}
			_commands.Add(command);
			OnStackSizeUpdated(_commands.Count);
		}

		public Value Peek()
		{
			List<Value> commands = _commands;
			return commands[commands.Count - 1];
		}

		public Value Pop()
		{
			List<Value> commands = _commands;
			Value value = commands[commands.Count - 1];
			_commands.Remove(value);
			OnStackSizeUpdated(_commands.Count);
			return value;
		}

		public void Clear()
		{
			_commands.Clear();
			if (OnStackSizeUpdated != null)
			{
				OnStackSizeUpdated(0);
			}
		}
	}
}

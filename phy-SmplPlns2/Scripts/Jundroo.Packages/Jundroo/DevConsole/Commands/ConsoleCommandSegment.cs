using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Jundroo.DevConsole.Commands
{
	internal class ConsoleCommandSegment
	{
		public string CommandText { get; set; }

		public ConsoleCommandSegmentType CommandType { get; set; }

		public bool Evaluated { get; set; }

		public static ConsoleCommandSegment Create(string commandText, ConsoleCommandSegmentType type)
		{
			ConsoleCommandSegment consoleCommandSegment = null;
			switch (type)
			{
			case ConsoleCommandSegmentType.FindAllChildGameObjects:
			case ConsoleCommandSegmentType.FindChildGameObjects:
				consoleCommandSegment = new GameObjectListCommandSegment();
				break;
			case ConsoleCommandSegmentType.FindChildComponents:
			case ConsoleCommandSegmentType.FindAllChildComponents:
				consoleCommandSegment = new ComponentListCommandSegment();
				break;
			case ConsoleCommandSegmentType.FindMembers:
			case ConsoleCommandSegmentType.FindAllMembers:
				consoleCommandSegment = new MemberListCommandSegment();
				break;
			case ConsoleCommandSegmentType.GameObjectSelector:
				consoleCommandSegment = new GameObjectCommandSegment();
				break;
			case ConsoleCommandSegmentType.ComponentSelector:
				consoleCommandSegment = new ComponentCommandSegment();
				break;
			case ConsoleCommandSegmentType.MemberSelector:
				consoleCommandSegment = new MemberCommandSegment();
				break;
			case ConsoleCommandSegmentType.Command:
				consoleCommandSegment = new CustomCommandSegment();
				break;
			case ConsoleCommandSegmentType.Argument:
				consoleCommandSegment = new ConsoleCommandSegment();
				break;
			default:
				consoleCommandSegment = new ConsoleCommandSegment();
				break;
			}
			if (consoleCommandSegment != null)
			{
				consoleCommandSegment.CommandText = commandText;
				consoleCommandSegment.CommandType = type;
				consoleCommandSegment.Evaluated = false;
			}
			return consoleCommandSegment;
		}

		public static List<Component> GetComponentList(ConsoleCommandSegment command)
		{
			if (command is ComponentListCommandSegment componentListCommandSegment)
			{
				return componentListCommandSegment.Components;
			}
			return null;
		}

		public static GameObject GetGameObject(ConsoleCommandSegment command)
		{
			if (command is GameObjectCommandSegment gameObjectCommandSegment)
			{
				return gameObjectCommandSegment.GameObject;
			}
			if (command is ComponentCommandSegment componentCommandSegment)
			{
				if (!(componentCommandSegment.Component == null))
				{
					return componentCommandSegment.Component.gameObject;
				}
				return null;
			}
			return null;
		}

		public static List<GameObject> GetGameObjectList(ConsoleCommandSegment command)
		{
			if (command is GameObjectListCommandSegment gameObjectListCommandSegment)
			{
				return gameObjectListCommandSegment.GameObjects;
			}
			return null;
		}

		public static List<MemberInfo> GetMemberList(ConsoleCommandSegment command)
		{
			if (command is MemberListCommandSegment memberListCommandSegment)
			{
				return memberListCommandSegment.Members;
			}
			return null;
		}

		public static Object GetObject(ConsoleCommandSegment command)
		{
			if (command is GameObjectCommandSegment gameObjectCommandSegment)
			{
				return gameObjectCommandSegment.GameObject;
			}
			if (command is ComponentCommandSegment componentCommandSegment)
			{
				return componentCommandSegment.Component;
			}
			return null;
		}

		public virtual ConsoleCommandSegment Clone(bool needsReevaluated)
		{
			return new ConsoleCommandSegment
			{
				CommandText = CommandText,
				CommandType = CommandType,
				Evaluated = (!needsReevaluated && Evaluated)
			};
		}
	}
}

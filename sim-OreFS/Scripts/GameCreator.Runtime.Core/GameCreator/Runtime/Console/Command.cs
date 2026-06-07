using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Console
{
	public abstract class Command
	{
		private const string ERR_PARAM_NOT_FOUND = "Unable to find parameter '{0}'";

		private readonly Dictionary<PropertyName, IAction> m_Actions;

		public abstract string Name { get; }

		public abstract string Description { get; }

		public virtual bool IsHidden => false;

		internal IEnumerable<IAction> Actions => m_Actions.Values;

		protected Command()
		{
			m_Actions = new Dictionary<PropertyName, IAction>();
		}

		protected Command(IEnumerable<IAction> actions)
			: this()
		{
			foreach (IAction action in actions)
			{
				m_Actions[action.Name] = action;
			}
		}

		public virtual Output[] Run(Input input)
		{
			return RunDefault(input, null);
		}

		protected Output[] RunDefault(Input input, Func<GameObject, Output> function)
		{
			List<Output> list = new List<Output>();
			Parameter[] parameters = input.Parameters;
			for (int i = 0; i < parameters.Length; i++)
			{
				Parameter parameter = parameters[i];
				if (m_Actions.TryGetValue(parameter.Name, out var value))
				{
					Output output;
					if (!(value is ActionOutput actionOutput))
					{
						if (value is ActionGameObject actionGameObject)
						{
							GameObject arg = actionGameObject.Run(parameter.Value);
							output = function?.Invoke(arg);
						}
						else
						{
							output = Output.Error("Undefined Action type");
						}
					}
					else
					{
						output = actionOutput.Run(parameter.Value);
					}
					list.Add(output);
					if (output.IsError)
					{
						return list.ToArray();
					}
					continue;
				}
				Output item = Output.Error($"Unable to find parameter '{parameter.Name}'", showHelp: true);
				list.Add(item);
				return list.ToArray();
			}
			return list.ToArray();
		}
	}
}

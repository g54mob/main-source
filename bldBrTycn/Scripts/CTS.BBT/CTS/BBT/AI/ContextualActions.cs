using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CTS.BBT.AI
{
	[RequireComponent(typeof(IContextActor))]
	internal sealed class ContextualActions : MonoBehaviour
	{
		[field: SerializeReference]
		public List<ContextualAction> Actions { get; set; } = new List<ContextualAction>();

		private void Awake()
		{
			IContextActor component = GetComponent<IContextActor>();
			foreach (ContextualAction action in Actions)
			{
				action.SetActor(component);
				action.Setup();
			}
		}

		public bool HasActionOfType<TAction>() where TAction : ContextualAction
		{
			return Actions.OfType<TAction>().Any();
		}

		public bool HasActionOfType(Type type)
		{
			foreach (ContextualAction action in Actions)
			{
				if (action.GetType() == type)
				{
					return true;
				}
			}
			return false;
		}
	}
}

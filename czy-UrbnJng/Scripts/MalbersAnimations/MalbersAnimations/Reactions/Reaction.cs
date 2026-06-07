using System;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	public abstract class Reaction
	{
		public static MonoBehaviour Delay;

		[Tooltip("Enable or Disable the Reaction")]
		[HideInInspector]
		public bool Active = true;

		public LocalComponet localComponent;

		[HideInInspector]
		[Min(0f)]
		public float delay;

		public abstract Type ReactionType { get; }

		protected abstract bool _TryReact(Component reactor);

		public void React(Component component)
		{
			TryReact(localComponent.useLocal ? localComponent.component : component);
		}

		public void React(GameObject go)
		{
			TryReact(go.transform);
		}

		public Component VerifyComponent(Component component)
		{
			if (component == null)
			{
				return null;
			}
			Component component2;
			if (ReactionType.IsAssignableFrom(component.GetType()))
			{
				component2 = component;
			}
			else
			{
				component2 = component.GetComponent(ReactionType);
				if (component2 == null)
				{
					component2 = component.GetComponentInParent(ReactionType);
				}
				if (component2 == null)
				{
					component2 = component.GetComponentInChildren(ReactionType);
				}
			}
			return component2;
		}

		public bool TryReact(Component component)
		{
			if (Application.isPlaying && Active)
			{
				component = VerifyComponent(localComponent.useLocal ? localComponent.component : component);
				if (component == null)
				{
					Debug.Log("Component is null. Ignoring the Reaction. <b>[" + ReactionType.Name + "] </b>");
					return false;
				}
				if (delay > 0f)
				{
					if (Delay == null)
					{
						Delay = new GameObject("Reaction Delay").AddComponent<UnityUtils>();
						Delay.hideFlags = HideFlags.HideInInspector;
						Debug.Log("Creating Delay Reaction GameObject for Delay Reactions. Created by [" + ReactionType.Name + "]", component);
					}
					Delay.Delay_Action(delay, delegate
					{
						_TryReact(component);
					});
					return true;
				}
				return _TryReact(component);
			}
			return false;
		}

		public bool TryReact(params Component[] components)
		{
			if (Active && components != null && components.Length != 0)
			{
				foreach (Component component in components)
				{
					Component reactor = VerifyComponent(component);
					_TryReact(reactor);
				}
			}
			return true;
		}
	}
}

using System;
using System.Collections.Generic;
using UltimateReplay.Core.StatePreparer;
using UnityEngine;

namespace UltimateReplay.Core
{
	public class DefaultReplayPreparer : IReplayPreparer
	{
		private HashSet<ComponentPreparer> preparers = new HashSet<ComponentPreparer>();

		private static readonly Type[] skipTypes = new Type[5]
		{
			typeof(ReplayObject),
			typeof(ReplayBehaviour),
			typeof(Camera),
			typeof(AudioSource),
			typeof(ParticleSystem)
		};

		public DefaultReplayPreparer()
		{
			Type[] types = typeof(ReplayManager).Assembly.GetTypes();
			foreach (Type type in types)
			{
				if (!type.IsDefined(typeof(ReplayComponentPreparerAttribute), inherit: false))
				{
					continue;
				}
				ReplayComponentPreparerAttribute attribute = type.GetCustomAttributes(typeof(ReplayComponentPreparerAttribute), inherit: false)[0] as ReplayComponentPreparerAttribute;
				if (!typeof(ComponentPreparer).IsAssignableFrom(type))
				{
					Debug.LogWarning($"Custom replay component preparer '{type}' must inherit from ComponentPreparer<>");
					continue;
				}
				ComponentPreparer componentPreparer = null;
				try
				{
					componentPreparer = (ComponentPreparer)Activator.CreateInstance(type);
				}
				catch
				{
					Debug.LogWarning($"Failed to create an instance of custom replay component preparer '{type}'. Make sure the type has a default constructor");
					continue;
				}
				componentPreparer.Attribute = attribute;
				preparers.Add(componentPreparer);
			}
		}

		public virtual void PrepareForPlayback(ReplayObject replayObject)
		{
			Component[] componentsInChildren = replayObject.GetComponentsInChildren<Component>();
			foreach (Component component in componentsInChildren)
			{
				if (component == null)
				{
					break;
				}
				bool flag = false;
				Type[] array = skipTypes;
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j].IsInstanceOfType(component))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Type type = component.GetType();
					FindPreparer(type)?.InvokePrepareForPlayback(component);
				}
			}
		}

		public virtual void PrepareForGameplay(ReplayObject replayObject)
		{
			Component[] componentsInChildren = replayObject.GetComponentsInChildren<Component>();
			foreach (Component component in componentsInChildren)
			{
				if (component == null)
				{
					break;
				}
				bool flag = false;
				Type[] array = skipTypes;
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j].IsInstanceOfType(component))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Type type = component.GetType();
					FindPreparer(type)?.InvokePrepareForGameplay(component);
				}
			}
		}

		private ComponentPreparer FindPreparer(Type componentType)
		{
			foreach (ComponentPreparer preparer in preparers)
			{
				if (preparer.Attribute.componentType.IsAssignableFrom(componentType))
				{
					return preparer;
				}
			}
			return null;
		}
	}
}

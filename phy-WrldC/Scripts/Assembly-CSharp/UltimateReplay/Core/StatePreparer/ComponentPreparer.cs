using System.Collections.Generic;
using UnityEngine;

namespace UltimateReplay.Core.StatePreparer
{
	internal abstract class ComponentPreparer
	{
		private ReplayComponentPreparerAttribute attribute;

		internal ReplayComponentPreparerAttribute Attribute
		{
			get
			{
				return attribute;
			}
			set
			{
				attribute = value;
			}
		}

		internal abstract void InvokePrepareForPlayback(Component component);

		internal abstract void InvokePrepareForGameplay(Component component);
	}
	internal abstract class ComponentPreparer<T> : ComponentPreparer where T : Component
	{
		private Dictionary<int, ReplayState> componentData = new Dictionary<int, ReplayState>();

		public abstract void PrepareForPlayback(T component, ReplayState additionalData);

		public abstract void PrepareForGameplay(T component, ReplayState additionalData);

		internal override void InvokePrepareForPlayback(Component component)
		{
			if (!(component is T))
			{
				return;
			}
			ReplayState replayState = new ReplayState();
			PrepareForPlayback(component as T, replayState);
			if (replayState.Size > 0)
			{
				int instanceID = component.GetInstanceID();
				if (componentData.ContainsKey(instanceID))
				{
					componentData[instanceID] = replayState;
				}
				else
				{
					componentData.Add(instanceID, replayState);
				}
			}
		}

		internal override void InvokePrepareForGameplay(Component component)
		{
			if (component is T)
			{
				ReplayState replayState = null;
				int instanceID = component.GetInstanceID();
				if (componentData.ContainsKey(instanceID))
				{
					replayState = componentData[instanceID];
				}
				if (replayState == null)
				{
					replayState = new ReplayState();
				}
				replayState.PrepareForRead();
				PrepareForGameplay(component as T, replayState);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Mystery.Graphing
{
	public abstract class ComponentMonitorBase : MonoBehaviour
	{
		public enum MemberTypes
		{
			Field = 0,
			Property = 1
		}

		public enum SampleTimes
		{
			Update = 0,
			FixedUpdate = 1,
			LateUpdate = 2
		}

		[Serializable]
		public class WatchVariable
		{
			public Component ParentComponent;

			public string Name;

			public Type VariableType;

			public MemberTypes MemberType;

			public GraphConsoleFactory.Toggle[] Toggles;

			private IGraphConsole Console;

			public WatchVariable(Component component, string name, Type variableType, MemberTypes memberType)
			{
				ParentComponent = component;
				Name = name;
				VariableType = variableType;
				MemberType = memberType;
				InitToggles();
			}

			private void InitToggles()
			{
				Toggles = GraphConsoleFactory.CreateToggles(VariableType);
			}

			private void Init(GameObject parent, Type componentType)
			{
				string consoleName = parent.name + " " + componentType.Name + "." + Name;
				Console = GraphConsoleFactory.Create(consoleName, VariableType);
				DebugGraph.AddCustomGraph(Console);
			}

			public bool Update(GameObject parent)
			{
				if (ParentComponent == null)
				{
					return false;
				}
				Type type = ParentComponent.GetType();
				object obj = null;
				switch (MemberType)
				{
				case MemberTypes.Field:
				{
					FieldInfo field = type.GetField(Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if ((object)field == null)
					{
						return false;
					}
					VariableType = field.FieldType;
					obj = field.GetValue(ParentComponent);
					break;
				}
				case MemberTypes.Property:
				{
					PropertyInfo property = type.GetProperty(Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if ((object)property == null)
					{
						return false;
					}
					VariableType = property.PropertyType;
					obj = property.GetValue(ParentComponent, null);
					break;
				}
				}
				if (obj == null)
				{
					return false;
				}
				if (Console == null)
				{
					Init(parent, type);
				}
				else
				{
					DebugGraph.AddCustomGraph(Console);
				}
				GraphConsoleFactory.Push(Console, VariableType, obj, Time.realtimeSinceStartup, Toggles);
				DebugGraph.UpdateTimeRange(Time.realtimeSinceStartup);
				return true;
			}

			public void DeleteConsole()
			{
				if (Console != null)
				{
					DebugGraph.RemoveCustomGraph(Console);
				}
			}
		}

		public List<WatchVariable> WatchVariables = new List<WatchVariable>();

		public SampleTimes SampleTime = SampleTimes.LateUpdate;

		private void FixedUpdate()
		{
			if (SampleTime != SampleTimes.FixedUpdate)
			{
				return;
			}
			foreach (WatchVariable watchVariable in WatchVariables)
			{
				watchVariable.Update(base.gameObject);
			}
		}

		private void Update()
		{
			if (SampleTime != SampleTimes.Update)
			{
				return;
			}
			foreach (WatchVariable watchVariable in WatchVariables)
			{
				watchVariable.Update(base.gameObject);
			}
		}

		private void LateUpdate()
		{
			if (SampleTime != SampleTimes.LateUpdate)
			{
				return;
			}
			foreach (WatchVariable watchVariable in WatchVariables)
			{
				watchVariable.Update(base.gameObject);
			}
		}
	}
}

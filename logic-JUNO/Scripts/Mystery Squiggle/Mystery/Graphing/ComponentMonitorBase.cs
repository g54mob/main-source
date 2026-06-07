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
		public class Toggle
		{
			public bool Value;

			public string Name;

			public Color Color;

			public Toggle(string name, Color color)
			{
				Value = true;
				Name = name;
				Color = color;
			}
		}

		[Serializable]
		public class WatchVariable
		{
			public Component ParentComponent;

			public string Name;

			public Type VariableType;

			public MemberTypes MemberType;

			public Toggle[] Toggles;

			private IGraphConsole Console;

			public WatchVariable(Component component, string name, Type variableType, MemberTypes memberType)
			{
				ParentComponent = component;
				Name = name;
				VariableType = variableType;
				MemberType = memberType;
				InitColors();
			}

			private void InitColors()
			{
				if ((object)VariableType == typeof(float) || (object)VariableType == typeof(double) || (object)VariableType == typeof(int) || (object)VariableType == typeof(long) || (object)VariableType == typeof(short) || (object)VariableType == typeof(byte) || (object)VariableType == typeof(bool) || VariableType.IsEnum)
				{
					Toggles = new Toggle[1]
					{
						new Toggle("", DebugGraph.DefaultBlue)
					};
				}
				else if ((object)VariableType == typeof(Vector2))
				{
					Toggles = new Toggle[2]
					{
						new Toggle("X", DebugGraph.DefaultRed),
						new Toggle("Y", DebugGraph.DefaultGreen)
					};
				}
				else if ((object)VariableType == typeof(Vector3))
				{
					Toggles = new Toggle[3]
					{
						new Toggle("X", DebugGraph.DefaultRed),
						new Toggle("Y", DebugGraph.DefaultGreen),
						new Toggle("Z", DebugGraph.DefaultBlue)
					};
				}
				else if ((object)VariableType == typeof(Color) || (object)VariableType == typeof(Color32))
				{
					Toggles = new Toggle[0];
				}
				else
				{
					Toggles = new Toggle[0];
				}
			}

			private void Init(GameObject parent, Type componentType)
			{
				string name = parent.name + " " + componentType.Name + "." + Name;
				if ((object)VariableType == typeof(float) || (object)VariableType == typeof(double))
				{
					Console = new SingleGraphConsole<float, double>(name, new FloatingPointLinearPlottableGraph());
				}
				else if ((object)VariableType == typeof(int) || (object)VariableType == typeof(long) || (object)VariableType == typeof(short) || (object)VariableType == typeof(byte))
				{
					Console = new SingleGraphConsole<float, long>(name, new IntegerLinearPlottableGraph());
				}
				else if ((object)VariableType == typeof(bool))
				{
					Console = new SingleGraphConsole<float, bool>(name, new BooleanLinearPlottableGraph());
				}
				else if ((object)VariableType == typeof(Vector2) || (object)VariableType == typeof(Vector3))
				{
					Console = new MultiGraphConsole<float, double>(name, (Type newGraphType) => new FloatingPointLinearPlottableGraph());
					if ((object)VariableType == typeof(Vector2))
					{
						Console.ValueNames = DebugGraph.Vector2ValueNames;
					}
					if ((object)VariableType == typeof(Vector3))
					{
						Console.ValueNames = DebugGraph.Vector3ValueNames;
					}
				}
				else if ((object)VariableType == typeof(Color))
				{
					Console = new ColorGraphConsole<double>(name, (Type newGraphType) => new FloatingPointLinearPlottableGraph());
					Console.ValueNames = DebugGraph.ColorValueNames;
				}
				else if ((object)VariableType == typeof(Color32))
				{
					Console = new ColorGraphConsole<long>(name, (Type newGraphType) => new IntegerLinearPlottableGraph());
					Console.ValueNames = DebugGraph.ColorValueNames;
				}
				else if (VariableType.IsEnum)
				{
					Console = new SingleGraphConsole<float, long>(name, new EnumLinearPlottableGraph(VariableType));
				}
				else
				{
					Console = new StringGraphConsole(name, new StringLinearPlottableGraph());
				}
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
				if ((object)VariableType == typeof(float) || (object)VariableType == typeof(double))
				{
					((SingleGraphConsole<float, double>)Console).Push(Time.realtimeSinceStartup, Convert.ToDouble(obj), Toggles[0].Color);
				}
				else if ((object)VariableType == typeof(int) || (object)VariableType == typeof(long) || (object)VariableType == typeof(short) || (object)VariableType == typeof(byte))
				{
					((SingleGraphConsole<float, long>)Console).Push(Time.realtimeSinceStartup, Convert.ToInt64(obj), Toggles[0].Color);
				}
				else if ((object)VariableType == typeof(bool))
				{
					((SingleGraphConsole<float, bool>)Console).Push(Time.realtimeSinceStartup, (bool)obj, Toggles[0].Color);
				}
				else if ((object)VariableType == typeof(Vector2))
				{
					Vector2 vector = (Vector2)obj;
					if (Toggles[0].Value)
					{
						((MultiGraphConsole<float, double>)Console).Push(Time.realtimeSinceStartup, vector.x, Toggles[0].Color, DebugGraph.Vector2ValueNames[0]);
					}
					if (Toggles[1].Value)
					{
						((MultiGraphConsole<float, double>)Console).Push(Time.realtimeSinceStartup, vector.y, Toggles[1].Color, DebugGraph.Vector2ValueNames[1]);
					}
				}
				else if ((object)VariableType == typeof(Vector3))
				{
					Vector3 vector2 = (Vector3)obj;
					if (Toggles[0].Value)
					{
						((MultiGraphConsole<float, double>)Console).Push(Time.realtimeSinceStartup, vector2.x, Toggles[0].Color, DebugGraph.Vector3ValueNames[0]);
					}
					if (Toggles[1].Value)
					{
						((MultiGraphConsole<float, double>)Console).Push(Time.realtimeSinceStartup, vector2.y, Toggles[1].Color, DebugGraph.Vector3ValueNames[1]);
					}
					if (Toggles[2].Value)
					{
						((MultiGraphConsole<float, double>)Console).Push(Time.realtimeSinceStartup, vector2.z, Toggles[2].Color, DebugGraph.Vector3ValueNames[2]);
					}
				}
				else if ((object)VariableType == typeof(Color))
				{
					Color color = (Color)obj;
					((MultiGraphConsole<float, double>)Console).Push(Time.realtimeSinceStartup, color.r, Color.red, DebugGraph.ColorValueNames[0]);
					((MultiGraphConsole<float, double>)Console).Push(Time.realtimeSinceStartup, color.g, Color.green, DebugGraph.ColorValueNames[1]);
					((MultiGraphConsole<float, double>)Console).Push(Time.realtimeSinceStartup, color.b, Color.blue, DebugGraph.ColorValueNames[2]);
					((MultiGraphConsole<float, double>)Console).Push(Time.realtimeSinceStartup, color.a, Color.black, DebugGraph.ColorValueNames[3]);
				}
				else if ((object)VariableType == typeof(Color32))
				{
					Color32 color2 = (Color32)obj;
					((MultiGraphConsole<float, long>)Console).Push(Time.realtimeSinceStartup, color2.r, Color.red, DebugGraph.ColorValueNames[0]);
					((MultiGraphConsole<float, long>)Console).Push(Time.realtimeSinceStartup, color2.g, Color.green, DebugGraph.ColorValueNames[1]);
					((MultiGraphConsole<float, long>)Console).Push(Time.realtimeSinceStartup, color2.b, Color.blue, DebugGraph.ColorValueNames[2]);
					((MultiGraphConsole<float, long>)Console).Push(Time.realtimeSinceStartup, color2.a, Color.black, DebugGraph.ColorValueNames[3]);
				}
				else if (VariableType.IsEnum)
				{
					((SingleGraphConsole<float, long>)Console).Push(Time.realtimeSinceStartup, Convert.ToInt64(obj, null), Toggles[0].Color);
				}
				else
				{
					((StringGraphConsole)Console).Push(Time.realtimeSinceStartup, obj.ToString());
				}
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

using System;
using UnityEngine;

namespace Mystery.Graphing
{
	public static class GraphConsoleFactory
	{
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

		public static IGraphConsole Create<T>(string consoleName)
		{
			return Create(consoleName, typeof(T));
		}

		public static IGraphConsole Create(string consoleName, Type variableType)
		{
			IGraphConsole graphConsole = null;
			if ((object)variableType == typeof(float) || (object)variableType == typeof(double))
			{
				graphConsole = new SingleGraphConsole<float, double>(consoleName, new FloatingPointLineGraphOverTime());
			}
			else if ((object)variableType == typeof(int) || (object)variableType == typeof(long) || (object)variableType == typeof(short) || (object)variableType == typeof(byte))
			{
				graphConsole = new SingleGraphConsole<float, long>(consoleName, new IntegerLineGraphOverTime());
			}
			else if ((object)variableType == typeof(bool))
			{
				graphConsole = new SingleGraphConsole<float, bool>(consoleName, new BooleanLineGraphOverTime());
			}
			else if ((object)variableType == typeof(Vector2) || (object)variableType == typeof(Vector3))
			{
				graphConsole = new MultiGraphConsole<float, double>(consoleName, (Type newGraphType) => new FloatingPointLineGraphOverTime());
				if ((object)variableType == typeof(Vector2))
				{
					graphConsole.ValueNames = DebugGraph.Vector2ValueNames;
				}
				if ((object)variableType == typeof(Vector3))
				{
					graphConsole.ValueNames = DebugGraph.Vector3ValueNames;
				}
			}
			else if ((object)variableType == typeof(Color))
			{
				graphConsole = new ColorGraphConsole<double>(consoleName, (Type newGraphType) => new FloatingPointLineGraphOverTime());
				graphConsole.ValueNames = DebugGraph.ColorValueNames;
			}
			else if ((object)variableType != typeof(Color32))
			{
				graphConsole = ((!variableType.IsEnum) ? ((SingleGraphConsole)new StringGraphConsole(consoleName, new StringLineGraphOverTime())) : ((SingleGraphConsole)new SingleGraphConsole<float, long>(consoleName, new EnumLineGraphOverTime(variableType))));
			}
			else
			{
				graphConsole = new ColorGraphConsole<long>(consoleName, (Type newGraphType) => new IntegerLineGraphOverTime());
				graphConsole.ValueNames = DebugGraph.ColorValueNames;
			}
			return graphConsole;
		}

		public static void Push(IGraphConsole console, object value, float time, Toggle[] toggles = null)
		{
			Push(console, value.GetType(), value, time, toggles);
		}

		public static void Push(IGraphConsole console, Type variableType, object value, float time, Toggle[] toggles = null)
		{
			if ((object)variableType == typeof(float) || (object)variableType == typeof(double))
			{
				((SingleGraphConsole<float, double>)console).Push(time, Convert.ToDouble(value), (toggles == null) ? DebugGraph.DefaultBlue : toggles[0].Color);
			}
			else if ((object)variableType == typeof(int) || (object)variableType == typeof(long) || (object)variableType == typeof(short) || (object)variableType == typeof(byte))
			{
				((SingleGraphConsole<float, long>)console).Push(time, Convert.ToInt64(value), (toggles == null) ? DebugGraph.DefaultBlue : toggles[0].Color);
			}
			else if ((object)variableType == typeof(bool))
			{
				((SingleGraphConsole<float, bool>)console).Push(time, (bool)value, (toggles == null) ? DebugGraph.DefaultBlue : toggles[0].Color);
			}
			else if ((object)variableType == typeof(Vector2))
			{
				Vector2 vector = (Vector2)value;
				if (toggles == null || toggles[0].Value)
				{
					((MultiGraphConsole<float, double>)console).Push(time, vector.x, (toggles == null) ? DebugGraph.DefaultRed : toggles[0].Color, DebugGraph.Vector2ValueNames[0]);
				}
				if (toggles == null || toggles[1].Value)
				{
					((MultiGraphConsole<float, double>)console).Push(time, vector.y, (toggles == null) ? DebugGraph.DefaultGreen : toggles[1].Color, DebugGraph.Vector2ValueNames[1]);
				}
			}
			else if ((object)variableType == typeof(Vector3))
			{
				Vector3 vector2 = (Vector3)value;
				if (toggles == null || toggles[0].Value)
				{
					((MultiGraphConsole<float, double>)console).Push(time, vector2.x, (toggles == null) ? DebugGraph.DefaultRed : toggles[0].Color, DebugGraph.Vector3ValueNames[0]);
				}
				if (toggles == null || toggles[1].Value)
				{
					((MultiGraphConsole<float, double>)console).Push(time, vector2.y, (toggles == null) ? DebugGraph.DefaultGreen : toggles[1].Color, DebugGraph.Vector3ValueNames[1]);
				}
				if (toggles == null || toggles[2].Value)
				{
					((MultiGraphConsole<float, double>)console).Push(time, vector2.z, (toggles == null) ? DebugGraph.DefaultBlue : toggles[2].Color, DebugGraph.Vector3ValueNames[2]);
				}
			}
			else if ((object)variableType == typeof(Color))
			{
				Color color = (Color)value;
				((ColorGraphConsole<double>)console).Push(time, color.r, Color.red, DebugGraph.ColorValueNames[0]);
				((ColorGraphConsole<double>)console).Push(time, color.g, Color.green, DebugGraph.ColorValueNames[1]);
				((ColorGraphConsole<double>)console).Push(time, color.b, Color.blue, DebugGraph.ColorValueNames[2]);
				((ColorGraphConsole<double>)console).Push(time, color.a, Color.black, DebugGraph.ColorValueNames[3]);
			}
			else if ((object)variableType == typeof(Color32))
			{
				Color32 color2 = (Color32)value;
				((ColorGraphConsole<long>)console).Push(time, color2.r, Color.red, DebugGraph.ColorValueNames[0]);
				((ColorGraphConsole<long>)console).Push(time, color2.g, Color.green, DebugGraph.ColorValueNames[1]);
				((ColorGraphConsole<long>)console).Push(time, color2.b, Color.blue, DebugGraph.ColorValueNames[2]);
				((ColorGraphConsole<long>)console).Push(time, color2.a, Color.black, DebugGraph.ColorValueNames[3]);
			}
			else if (variableType.IsEnum)
			{
				((SingleGraphConsole<float, long>)console).Push(time, Convert.ToInt64(value, null), (toggles == null) ? DebugGraph.DefaultBlue : toggles[0].Color);
			}
			else
			{
				((StringGraphConsole)console).Push(time, value.ToString());
			}
		}

		public static Toggle[] CreateToggles(Type variableType)
		{
			if ((object)variableType == typeof(float) || (object)variableType == typeof(double) || (object)variableType == typeof(int) || (object)variableType == typeof(long) || (object)variableType == typeof(short) || (object)variableType == typeof(byte) || (object)variableType == typeof(bool) || variableType.IsEnum)
			{
				return new Toggle[1]
				{
					new Toggle("", DebugGraph.DefaultBlue)
				};
			}
			if ((object)variableType == typeof(Vector2))
			{
				return new Toggle[2]
				{
					new Toggle("X", DebugGraph.DefaultRed),
					new Toggle("Y", DebugGraph.DefaultGreen)
				};
			}
			if ((object)variableType == typeof(Vector3))
			{
				return new Toggle[3]
				{
					new Toggle("X", DebugGraph.DefaultRed),
					new Toggle("Y", DebugGraph.DefaultGreen),
					new Toggle("Z", DebugGraph.DefaultBlue)
				};
			}
			if ((object)variableType != typeof(Color))
			{
				_ = typeof(Color32);
			}
			return new Toggle[0];
		}
	}
}

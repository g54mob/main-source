using System;
using System.Globalization;
using UnityEngine;

namespace DV.Telemetry
{
	public static class TelemetryFieldHandlers
	{
		public class Vector2 : ITelemetryFieldHandler
		{
			public int ColumnCount => 2;

			public bool CanAccept(Type t)
			{
				return t == typeof(UnityEngine.Vector2);
			}

			public string GetColumnData(object data, int column)
			{
				UnityEngine.Vector2 vector = (UnityEngine.Vector2)data;
				switch (column)
				{
				case 0:
					return vector.x.ToString(CultureInfo.InvariantCulture);
				case 1:
					return vector.y.ToString(CultureInfo.InvariantCulture);
				default:
					return "?";
				}
			}

			public string GetColumnName(int index)
			{
				switch (index)
				{
				case 0:
					return "X";
				case 1:
					return "Y";
				default:
					return "?";
				}
			}
		}

		public class Vector2Int : ITelemetryFieldHandler
		{
			public int ColumnCount => 2;

			public bool CanAccept(Type t)
			{
				return t == typeof(UnityEngine.Vector2Int);
			}

			public string GetColumnData(object data, int column)
			{
				UnityEngine.Vector2Int vector2Int = (UnityEngine.Vector2Int)data;
				switch (column)
				{
				case 0:
					return vector2Int.x.ToString(CultureInfo.InvariantCulture);
				case 1:
					return vector2Int.y.ToString(CultureInfo.InvariantCulture);
				default:
					return "?";
				}
			}

			public string GetColumnName(int index)
			{
				switch (index)
				{
				case 0:
					return "X";
				case 1:
					return "Y";
				default:
					return "?";
				}
			}
		}

		public class Vector3 : ITelemetryFieldHandler
		{
			public int ColumnCount => 3;

			public bool CanAccept(Type t)
			{
				return t == typeof(UnityEngine.Vector3);
			}

			public string GetColumnData(object data, int column)
			{
				UnityEngine.Vector3 vector = (UnityEngine.Vector3)data;
				switch (column)
				{
				case 0:
					return vector.x.ToString(CultureInfo.InvariantCulture);
				case 1:
					return vector.y.ToString(CultureInfo.InvariantCulture);
				case 2:
					return vector.z.ToString(CultureInfo.InvariantCulture);
				default:
					return "?";
				}
			}

			public string GetColumnName(int index)
			{
				switch (index)
				{
				case 0:
					return "X";
				case 1:
					return "Y";
				case 2:
					return "Z";
				default:
					return "?";
				}
			}
		}

		public class Vector4 : ITelemetryFieldHandler
		{
			public int ColumnCount => 2;

			public bool CanAccept(Type t)
			{
				return t == typeof(UnityEngine.Vector4);
			}

			public string GetColumnData(object data, int column)
			{
				UnityEngine.Vector4 vector = (UnityEngine.Vector4)data;
				switch (column)
				{
				case 0:
					return vector.x.ToString(CultureInfo.InvariantCulture);
				case 1:
					return vector.y.ToString(CultureInfo.InvariantCulture);
				case 2:
					return vector.z.ToString(CultureInfo.InvariantCulture);
				case 3:
					return vector.w.ToString(CultureInfo.InvariantCulture);
				default:
					return "?";
				}
			}

			public string GetColumnName(int index)
			{
				switch (index)
				{
				case 0:
					return "X";
				case 1:
					return "Y";
				case 2:
					return "Z";
				case 3:
					return "W";
				default:
					return "?";
				}
			}
		}

		public class Quaternion : ITelemetryFieldHandler
		{
			public int ColumnCount => 4;

			public bool CanAccept(Type t)
			{
				return t == typeof(UnityEngine.Quaternion);
			}

			public string GetColumnData(object data, int column)
			{
				UnityEngine.Quaternion quaternion = (UnityEngine.Quaternion)data;
				switch (column)
				{
				case 0:
					return quaternion.w.ToString(CultureInfo.InvariantCulture);
				case 1:
					return quaternion.x.ToString(CultureInfo.InvariantCulture);
				case 2:
					return quaternion.y.ToString(CultureInfo.InvariantCulture);
				case 3:
					return quaternion.z.ToString(CultureInfo.InvariantCulture);
				default:
					return "?";
				}
			}

			public string GetColumnName(int index)
			{
				switch (index)
				{
				case 0:
					return "W";
				case 1:
					return "X";
				case 2:
					return "Y";
				case 3:
					return "Z";
				default:
					return "?";
				}
			}
		}

		public class Float : ITelemetryFieldHandler
		{
			public int ColumnCount => 1;

			public bool CanAccept(Type t)
			{
				return t == typeof(float);
			}

			public string GetColumnData(object data, int column)
			{
				return ((float)data).ToString(CultureInfo.InvariantCulture);
			}

			public string GetColumnName(int index)
			{
				return "";
			}
		}

		public class Double : ITelemetryFieldHandler
		{
			public int ColumnCount => 1;

			public bool CanAccept(Type t)
			{
				return t == typeof(double);
			}

			public string GetColumnData(object data, int column)
			{
				return ((double)data).ToString(CultureInfo.InvariantCulture);
			}

			public string GetColumnName(int index)
			{
				return "";
			}
		}

		public class Int : ITelemetryFieldHandler
		{
			public int ColumnCount => 1;

			public bool CanAccept(Type t)
			{
				return t == typeof(int);
			}

			public string GetColumnData(object data, int column)
			{
				return ((int)data).ToString(CultureInfo.InvariantCulture);
			}

			public string GetColumnName(int index)
			{
				return "";
			}
		}

		public class Bool : ITelemetryFieldHandler
		{
			public int ColumnCount => 1;

			public bool CanAccept(Type t)
			{
				return t == typeof(bool);
			}

			public string GetColumnData(object data, int column)
			{
				return ((bool)data).ToString(CultureInfo.InvariantCulture);
			}

			public string GetColumnName(int index)
			{
				return "";
			}
		}

		public class String : ITelemetryFieldHandler
		{
			public int ColumnCount => 1;

			public bool CanAccept(Type t)
			{
				return t == typeof(string);
			}

			public string GetColumnData(object data, int column)
			{
				return (string)data;
			}

			public string GetColumnName(int index)
			{
				return "";
			}
		}

		public class Generic : ITelemetryFieldHandler
		{
			public int ColumnCount => 1;

			public bool CanAccept(Type t)
			{
				return true;
			}

			public string GetColumnData(object data, int column)
			{
				if (data == null)
				{
					return "[NULL]";
				}
				return data.ToString();
			}

			public string GetColumnName(int index)
			{
				return "";
			}
		}

		private static readonly ITelemetryFieldHandler[] Handlers = new ITelemetryFieldHandler[11]
		{
			new Vector2(),
			new Vector2Int(),
			new Vector3(),
			new Vector4(),
			new Quaternion(),
			new Int(),
			new Bool(),
			new Float(),
			new Double(),
			new String(),
			new Generic()
		};

		public static ITelemetryFieldHandler GetFor(Type t)
		{
			for (int i = 0; i < Handlers.Length; i++)
			{
				if (Handlers[i].CanAccept(t))
				{
					return Handlers[i];
				}
			}
			return null;
		}
	}
}

using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Doozy.Engine.Touchy
{
	public class SimulatedTouch
	{
		private const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.NonPublic;

		private static readonly Dictionary<string, FieldInfo> Fields;

		private readonly object m_touch;

		public bool WasModified { get; set; }

		public int FingerId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Vector2 Position
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 RawPosition
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 DeltaPosition
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public float DeltaTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int TapCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public TouchPhase Phase
		{
			get
			{
				return default(TouchPhase);
			}
			set
			{
			}
		}

		public float Pressure
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaximumPossiblePressure
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public TouchType Type
		{
			get
			{
				return default(TouchType);
			}
			set
			{
			}
		}

		public float AltitudeAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AzimuthAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RadiusVariance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		static SimulatedTouch()
		{
		}

		public Touch Get()
		{
			return default(Touch);
		}
	}
}

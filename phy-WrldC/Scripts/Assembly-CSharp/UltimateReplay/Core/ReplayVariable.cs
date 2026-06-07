using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace UltimateReplay.Core
{
	public sealed class ReplayVariable : IReplaySerialize
	{
		private static readonly Dictionary<Type, Func<object, object, float, object>> interpolators = new Dictionary<Type, Func<object, object, float, object>>
		{
			{
				typeof(byte),
				InterpolateByte
			},
			{
				typeof(short),
				InterpolateShort
			},
			{
				typeof(int),
				InterpolateInt
			},
			{
				typeof(long),
				InterpolateLong
			},
			{
				typeof(float),
				InterpolateFloat
			},
			{
				typeof(double),
				InterpolateDouble
			},
			{
				typeof(Vector2),
				InterpolateVec2
			},
			{
				typeof(Vector3),
				InterpolateVec3
			},
			{
				typeof(Vector4),
				InterpolateVec4
			},
			{
				typeof(Quaternion),
				InterpolateQuat
			},
			{
				typeof(Color),
				InterpolateColor
			},
			{
				typeof(Color32),
				InterpolateColor32
			}
		};

		private ReplayBehaviour owner;

		private ReplayVarAttribute attribute;

		private FieldInfo field;

		private bool isInterpolationSupported;

		private object last;

		private object next;

		public GameObject gameObject => owner.gameObject;

		public object Value
		{
			get
			{
				return field.GetValue(owner);
			}
			set
			{
				field.SetValue(owner, value);
			}
		}

		public ReplayVarAttribute Attribute => attribute;

		public string Name => field.Name;

		public bool IsInterpolated => attribute.interpolate;

		public bool IsInterpolationSupported => isInterpolationSupported;

		public ReplayVariable(ReplayBehaviour owner, FieldInfo field, ReplayVarAttribute attribute)
		{
			this.owner = owner;
			this.field = field;
			this.attribute = attribute;
			isInterpolationSupported = CanInterpolate(field.FieldType);
		}

		public void OnReplaySerialize(ReplayState state)
		{
			try
			{
				state.TryWriteObject(Value);
			}
			catch
			{
			}
		}

		public void OnReplayDeserialize(ReplayState state)
		{
			try
			{
				object value = Value;
				object obj = state.TryReadObject();
				if (obj != null)
				{
					Value = obj;
					UpdateValueRange(value, obj);
				}
			}
			catch
			{
			}
		}

		public void UpdateValueRange(object last, object next)
		{
			this.last = last;
			this.next = next;
		}

		public void Interpolate(float delta)
		{
			if (IsInterpolationSupported && IsInterpolated && last != null && next != null)
			{
				Value = InterpolateValue(last, next, delta);
			}
		}

		public static object InterpolateValue(object last, object next, float delta)
		{
			Type type = last.GetType();
			Type type2 = next.GetType();
			if (type != type2)
			{
				return null;
			}
			if (interpolators.ContainsKey(type))
			{
				try
				{
					return interpolators[type](last, next, delta);
				}
				catch (Exception arg)
				{
					Debug.LogError($"An exception occured when invoking the interpolator for type '{type}': {arg}");
				}
			}
			return null;
		}

		public static bool CanInterpolate(Type type)
		{
			return interpolators.ContainsKey(type);
		}

		public static void RegisterCustomInterpolator<T>(Func<object, object, float, object> interpolatorFunc)
		{
			if (!interpolators.ContainsKey(typeof(T)))
			{
				interpolators.Add(typeof(T), interpolatorFunc);
			}
			else
			{
				Debug.LogWarning($"Failed to register custom interpolater because there is already an interpolator for '{typeof(T)}'");
			}
		}

		public static object InterpolateByte(object last, object next, float delta)
		{
			return (byte)Mathf.Lerp((int)(byte)last, (int)(byte)next, delta);
		}

		public static object InterpolateShort(object last, object next, float delta)
		{
			return (short)Mathf.Lerp((short)last, (short)next, delta);
		}

		public static object InterpolateInt(object last, object next, float delta)
		{
			return (int)Mathf.Lerp((int)last, (int)next, delta);
		}

		public static object InterpolateLong(object last, object next, float delta)
		{
			return (long)Mathf.Lerp((long)last, (long)next, delta);
		}

		public static object InterpolateFloat(object last, object next, float delta)
		{
			return Mathf.Lerp((float)last, (float)next, delta);
		}

		public static object InterpolateDouble(object last, object next, float delta)
		{
			return (double)Mathf.Lerp((float)last, (float)next, delta);
		}

		public static object InterpolateVec2(object last, object next, float delta)
		{
			return Vector2.Lerp((Vector2)last, (Vector2)next, delta);
		}

		public static object InterpolateVec3(object last, object next, float delta)
		{
			return Vector3.Lerp((Vector3)last, (Vector3)next, delta);
		}

		public static object InterpolateVec4(object last, object next, float delta)
		{
			return Vector4.Lerp((Vector4)last, (Vector4)next, delta);
		}

		public static object InterpolateQuat(object last, object next, float delta)
		{
			return Quaternion.Lerp((Quaternion)last, (Quaternion)next, delta);
		}

		public static object InterpolateColor(object last, object next, float delta)
		{
			return Color.Lerp((Color)last, (Color)next, delta);
		}

		public static object InterpolateColor32(object last, object next, float delta)
		{
			return Color32.Lerp((Color32)last, (Color32)next, delta);
		}
	}
}

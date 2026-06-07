using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FractureField.Managers;
using UnityEngine;

namespace FractureField
{
	public static class ExtensionUtilities
	{
		[CompilerGenerated]
		private sealed class _003CAwaitTaskCoroutine_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Task task;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CAwaitTaskCoroutine_003Ed__25(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public static bool IsNullOrEmpty(this string value)
		{
			return false;
		}

		public static bool IsBetween(this int value, int minInclusive, int maxInclusive)
		{
			return false;
		}

		public static bool IsBetweenDelta(this float value, float compareValue, float delta)
		{
			return false;
		}

		public static bool IsBetween(this float value, float minInclusive, float maxInclusive)
		{
			return false;
		}

		public static bool IsBetweenDelta(this int value, int compareValue, int delta)
		{
			return false;
		}

		public static bool IsBetween(this int value, float minInclusive, float maxInclusive)
		{
			return false;
		}

		public static void DestroyAllChildren(this Transform transform)
		{
		}

		public static void DestroyImmediateAllChildren(this Transform transform)
		{
		}

		public static void DeactivateAllChildren(this Transform transform)
		{
		}

		public static Vector3 IncreaseZ(this Vector3 position, float addZ)
		{
			return default(Vector3);
		}

		public static void Deactivate(this MonoBehaviour obj)
		{
		}

		public static void OffAndOn(this MonoBehaviour obj)
		{
		}

		public static void OffAndOn(this GameObject obj)
		{
		}

		public static void OffAndOn(this Transform obj)
		{
		}

		public static float SumParentZ(this RectTransform rect)
		{
			return 0f;
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
		}

		public static T GetRandomItem<T>(this List<T> list, RandomManager random)
		{
			return default(T);
		}

		public static Dictionary<T, U> Clone<T, U>(this Dictionary<T, U> original)
		{
			return null;
		}

		public static string Format<T>(this T value) where T : Enum
		{
			return null;
		}

		public static T GetNextEnumValue<T>(this T value) where T : Enum
		{
			return default(T);
		}

		public static void ForEach<T>(this T value, Action<T> action, bool includeDefault = false, List<T> exclude = null) where T : Enum
		{
		}

		public static T GetRandom<T>(this T value, RandomManager randomManager, List<T> exclude = null) where T : Enum
		{
			return default(T);
		}

		public static string GetFullPath(this GameObject obj)
		{
			return null;
		}

		public static Color Darken(this Color color, float percentage)
		{
			return default(Color);
		}

		public static Coroutine AwaitTask(this MonoBehaviour monoBehaviour, Task task)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAwaitTaskCoroutine_003Ed__25))]
		private static IEnumerator AwaitTaskCoroutine(Task task)
		{
			return null;
		}
	}
}

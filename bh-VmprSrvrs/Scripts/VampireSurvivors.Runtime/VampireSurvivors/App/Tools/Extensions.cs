using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using Unity.Burst;
using Unity.IL2CPP.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.App.Tools
{
	[BurstCompile]
	public static class Extensions
	{
		[CompilerGenerated]
		private sealed class _003CSplitList_003Ed__3<T> : IEnumerable<List<T>>, IEnumerable, IEnumerator<List<T>>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private List<T> _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private List<T> locations;

			public List<T> _003C_003E3__locations;

			private int nSize;

			public int _003C_003E3__nSize;

			private int _003Ci_003E5__2;

			List<T> IEnumerator<List<T>>.Current
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
			public _003CSplitList_003Ed__3(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<List<T>> IEnumerable<List<T>>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public static void Shuffle<T>(this IList<T> list)
		{
		}

		public static void Shuffle<T>(this IList<T> list, Unity.Mathematics.Random random)
		{
		}

		public static string Shuffle(this string str)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSplitList_003Ed__3<>))]
		public static IEnumerable<List<T>> SplitList<T>(this List<T> locations, int nSize = 30)
		{
			return null;
		}

		public static void SetPivot(this RectTransform rectTransform, Vector2 pivot)
		{
		}

		public static Vector2 GetSize(this RectTransform rTrans)
		{
			return default(Vector2);
		}

		public static Rect RectTransformToScreenSpace(this RectTransform transform, Camera cam, bool cutDecimals = false)
		{
			return default(Rect);
		}

		public static Rect GetWorldRect(this RectTransform rectTransform)
		{
			return default(Rect);
		}

		public static Vector3 GetLocalAnchorPosInParent(this RectTransform rectTransform, RectTransform parent)
		{
			return default(Vector3);
		}

		public static T PickRnd<T>(this T[] array)
		{
			return default(T);
		}

		public static T PickRnd<T>(this IList<T> list)
		{
			return default(T);
		}

		public static void RemoveWhere<T>(this ICollection<T> collection, Func<T, bool> condition)
		{
		}

		public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
		{
			return null;
		}

		public static void RefreshLayoutGroupsImmediateAndRecursive(this RectTransform g)
		{
		}

		public static Vector2 GetProperSize(this RectTransform rectTransform)
		{
			return default(Vector2);
		}

		public static bool AnyDown(this Player self)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public static bool ContainsFast(this ref Rect rect, float x, float y)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public static bool ContainsFast(this Rect rect, float2 position)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public static float2 Restrict(this ref Rect rect, float2 position)
		{
			return default(float2);
		}

		public static void SetNavigationUp(this Selectable origin, Selectable target = null)
		{
		}

		public static void SetNavigationDown(this Selectable origin, Selectable target = null)
		{
		}

		public static void SetNavigationLeft(this Selectable origin, Selectable target = null)
		{
		}

		public static void SetNavigationRight(this Selectable origin, Selectable target = null)
		{
		}

		public static void SetNavigationMode(this Selectable origin, Navigation.Mode mode)
		{
		}

		public static void ClearNavigation(this Selectable s)
		{
		}

		public static string FirstCharToUpper(this string input)
		{
			return null;
		}

		public static Vector3 GetScreenPosFromAnchorPos(this RectTransform r)
		{
			return default(Vector3);
		}

		public static void SetCurveLinear(this AnimationCurve curve)
		{
		}
	}
}

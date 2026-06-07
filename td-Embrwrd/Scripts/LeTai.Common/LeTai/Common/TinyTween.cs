using System;
using System.Collections.Generic;
using UnityEngine;

namespace LeTai.Common
{
	public class TinyTween : MonoBehaviour
	{
		[Serializable]
		public struct Spring
		{
			public float stiffness;

			public float damping;

			public float approxDuration;

			public float overshoot;

			public static readonly Spring DEFAULT;

			private Spring(float stiffness, float damping, float approxDuration, float overshoot)
			{
				this.stiffness = 0f;
				this.damping = 0f;
				this.approxDuration = 0f;
				this.overshoot = 0f;
			}

			public static Spring DurationOvershoot(float approxDuration, float overshoot)
			{
				return default(Spring);
			}
		}

		private static class Ops<TValue>
		{
			public static readonly Func<TValue, TValue, TValue> ADD;

			public static readonly Func<TValue, TValue, TValue> SUB;

			public static readonly Func<TValue, float, TValue> MUL;

			public static readonly Func<TValue, bool> IS_NEAR_ZERO;

			static Ops()
			{
			}
		}

		private static class Ops
		{
			public static T Add<T>(T a, T b)
			{
				return default(T);
			}

			public static T Sub<T>(T a, T b)
			{
				return default(T);
			}

			public static T Mul<T>(T a, float s)
			{
				return default(T);
			}

			public static bool IsNearZero<T>(T v)
			{
				return false;
			}
		}

		private abstract class Tween
		{
			protected Spring spring;

			public abstract bool MaybeRetarget(object newContext, Delegate newOnUpdate, object newTarget);

			public abstract bool Tick(float dt);

			public abstract void Reset();
		}

		private class Tween<TCtx, TVal> : Tween where TCtx : class
		{
			private TCtx _context;

			private Action<TCtx, TVal> _onUpdate;

			private TVal _target;

			private TVal _current;

			private TVal _velocity;

			public void Setup(TCtx ctx, TVal from, TVal to, Spring spring, Action<TCtx, TVal> update)
			{
			}

			public override bool MaybeRetarget(object newContext, Delegate newOnUpdate, object newTarget)
			{
				return false;
			}

			public override bool Tick(float dt)
			{
				return false;
			}

			public override void Reset()
			{
			}
		}

		private static readonly Dictionary<Type, Stack<Tween>> TWEEN_POOLS;

		private static TinyTween instance;

		private readonly List<Tween> _activeTweens;

		private static readonly Action<RectTransform, Vector3> MOVE;

		public static void Animate<TCtx, TVal>(TCtx context, TVal from, TVal to, Action<TCtx, TVal> onUpdate, Spring? spring = null) where TCtx : class
		{
		}

		private void Update()
		{
		}

		private static void SwapAndPop<T>(List<T> list, int index)
		{
		}

		public static void Move(RectTransform rt, Vector2 to, Spring? spring = null)
		{
		}
	}
}

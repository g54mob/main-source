using System;
using System.Collections.Generic;
using UnityEngine;

namespace Animancer
{
	public abstract class CustomFade : Key, IUpdatable, Key.IListItem
	{
		private readonly struct NodeWeight
		{
			public readonly AnimancerNode Node;

			public readonly float StartingWeight;

			public NodeWeight(AnimancerNode node)
			{
				Node = node;
				StartingWeight = node.Weight;
			}
		}

		private class Curve : CustomFade
		{
			private AnimationCurve _Curve;

			public static Curve Acquire(AnimationCurve curve)
			{
				if (curve == null)
				{
					return null;
				}
				Curve curve2 = ObjectPool<Curve>.Acquire();
				curve2._Curve = curve;
				return curve2;
			}

			protected override float CalculateWeight(float progress)
			{
				return _Curve.Evaluate(progress);
			}

			protected override void Release()
			{
				ObjectPool<Curve>.Release(this);
			}
		}

		private class Delegate : CustomFade
		{
			private Func<float, float> _CalculateWeight;

			public static Delegate Acquire(Func<float, float> calculateWeight)
			{
				if (calculateWeight == null)
				{
					return null;
				}
				Delegate obj = ObjectPool<Delegate>.Acquire();
				obj._CalculateWeight = calculateWeight;
				return obj;
			}

			protected override float CalculateWeight(float progress)
			{
				return _CalculateWeight(progress);
			}

			protected override void Release()
			{
				ObjectPool<Delegate>.Release(this);
			}
		}

		private float _Time;

		private float _FadeSpeed;

		private NodeWeight _Target;

		private AnimancerLayer _Layer;

		private int _CommandCount;

		private readonly List<NodeWeight> FadeOutNodes = new List<NodeWeight>();

		protected void Apply(AnimancerState state)
		{
			Apply((AnimancerNode)state);
			IPlayableWrapper parent = state.Parent;
			for (int num = parent.ChildCount - 1; num >= 0; num--)
			{
				AnimancerNode child = parent.GetChild(num);
				if (child != state && child.FadeSpeed != 0f)
				{
					child.FadeSpeed = 0f;
					FadeOutNodes.Add(new NodeWeight(child));
				}
			}
		}

		protected void Apply(AnimancerNode node)
		{
			_Time = 0f;
			_Target = new NodeWeight(node);
			_FadeSpeed = node.FadeSpeed;
			_Layer = node.Layer;
			_CommandCount = _Layer.CommandCount;
			node.FadeSpeed = 0f;
			FadeOutNodes.Clear();
			node.Root.RequirePreUpdate(this);
		}

		protected abstract float CalculateWeight(float progress);

		protected abstract void Release();

		void IUpdatable.Update()
		{
			if (!_Target.Node.IsValid() || _Layer != _Target.Node.Layer || _CommandCount != _Layer.CommandCount)
			{
				FadeOutNodes.Clear();
				_Layer.Root.CancelPreUpdate(this);
				Release();
				return;
			}
			_Time += AnimancerPlayable.DeltaTime * _Layer.Speed * _FadeSpeed;
			if (_Time < 1f)
			{
				float num = CalculateWeight(_Time);
				_Target.Node.SetWeight(Mathf.LerpUnclamped(_Target.StartingWeight, _Target.Node.TargetWeight, num));
				_Target.Node.ApplyWeight();
				num = 1f - num;
				for (int num2 = FadeOutNodes.Count - 1; num2 >= 0; num2--)
				{
					NodeWeight nodeWeight = FadeOutNodes[num2];
					nodeWeight.Node.SetWeight(nodeWeight.StartingWeight * num);
					nodeWeight.Node.ApplyWeight();
				}
			}
			else
			{
				_Time = 1f;
				ForceFinishFade(_Target.Node);
				for (int num3 = FadeOutNodes.Count - 1; num3 >= 0; num3--)
				{
					ForceFinishFade(FadeOutNodes[num3].Node);
				}
				FadeOutNodes.Clear();
				_Layer.Root.CancelPreUpdate(this);
				Release();
			}
		}

		private static void ForceFinishFade(AnimancerNode node)
		{
			float targetWeight = node.TargetWeight;
			node.SetWeight(targetWeight);
			node.ApplyWeight();
			if (targetWeight == 0f)
			{
				node.Stop();
			}
		}

		public static void Apply(AnimancerComponent animancer, AnimationCurve curve)
		{
			Apply(animancer.States.Current, curve);
		}

		public static void Apply(AnimancerPlayable animancer, AnimationCurve curve)
		{
			Apply(animancer.States.Current, curve);
		}

		public static void Apply(AnimancerState state, AnimationCurve curve)
		{
			Curve.Acquire(curve).Apply(state);
		}

		public static void Apply(AnimancerNode node, AnimationCurve curve)
		{
			Curve.Acquire(curve).Apply(node);
		}

		public static void Apply(AnimancerComponent animancer, Func<float, float> calculateWeight)
		{
			Apply(animancer.States.Current, calculateWeight);
		}

		public static void Apply(AnimancerPlayable animancer, Func<float, float> calculateWeight)
		{
			Apply(animancer.States.Current, calculateWeight);
		}

		public static void Apply(AnimancerState state, Func<float, float> calculateWeight)
		{
			Delegate.Acquire(calculateWeight).Apply(state);
		}

		public static void Apply(AnimancerNode node, Func<float, float> calculateWeight)
		{
			Delegate.Acquire(calculateWeight).Apply(node);
		}

		public static void Apply(AnimancerComponent animancer, Easing.Function function)
		{
			Apply(animancer.States.Current, function);
		}

		public static void Apply(AnimancerPlayable animancer, Easing.Function function)
		{
			Apply(animancer.States.Current, function);
		}

		public static void Apply(AnimancerState state, Easing.Function function)
		{
			Delegate.Acquire(function.GetDelegate()).Apply(state);
		}

		public static void Apply(AnimancerNode node, Easing.Function function)
		{
			Delegate.Acquire(function.GetDelegate()).Apply(node);
		}
	}
}

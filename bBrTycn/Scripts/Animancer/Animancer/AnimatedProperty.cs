using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Animations;

namespace Animancer
{
	public abstract class AnimatedProperty<TJob, TValue> : AnimancerJob<TJob>, IDisposable where TJob : struct, IAnimationJob where TValue : struct
	{
		protected NativeArray<PropertyStreamHandle> _Properties;

		protected NativeArray<TValue> _Values;

		public TValue Value => this[0];

		public TValue this[int index] => _Values[index];

		public AnimatedProperty(IAnimancerComponent animancer, int propertyCount, NativeArrayOptions options = NativeArrayOptions.ClearMemory)
		{
			_Properties = new NativeArray<PropertyStreamHandle>(propertyCount, Allocator.Persistent, options);
			_Values = new NativeArray<TValue>(propertyCount, Allocator.Persistent);
			CreateJob();
			AnimancerPlayable playable = animancer.Playable;
			CreatePlayable(playable);
			playable.Disposables.Add(this);
		}

		public AnimatedProperty(IAnimancerComponent animancer, string propertyName)
			: this(animancer, 1, NativeArrayOptions.UninitializedMemory)
		{
			Animator animator = animancer.Animator;
			_Properties[0] = animator.BindStreamProperty(animator.transform, typeof(Animator), propertyName);
		}

		public AnimatedProperty(IAnimancerComponent animancer, params string[] propertyNames)
			: this(animancer, propertyNames.Length, NativeArrayOptions.UninitializedMemory)
		{
			int num = propertyNames.Length;
			Animator animator = animancer.Animator;
			Transform transform = animator.transform;
			for (int i = 0; i < num; i++)
			{
				InitializeProperty(animator, i, transform, typeof(Animator), propertyNames[i]);
			}
		}

		public void InitializeProperty(Animator animator, int index, string name)
		{
			InitializeProperty(animator, index, animator.transform, typeof(Animator), name);
		}

		public void InitializeProperty(Animator animator, int index, Transform transform, Type type, string name)
		{
			_Properties[index] = animator.BindStreamProperty(transform, type, name);
		}

		protected abstract void CreateJob();

		public static implicit operator TValue(AnimatedProperty<TJob, TValue> properties)
		{
			return properties[0];
		}

		public TValue GetValue(int index)
		{
			return _Values[index];
		}

		public void GetValues(ref TValue[] values)
		{
			AnimancerUtilities.SetLength(ref values, _Values.Length);
			_Values.CopyTo(values);
		}

		public TValue[] GetValues()
		{
			TValue[] array = new TValue[_Values.Length];
			_Values.CopyTo(array);
			return array;
		}

		void IDisposable.Dispose()
		{
			Dispose();
		}

		protected virtual void Dispose()
		{
			if (_Properties.IsCreated)
			{
				_Properties.Dispose();
				_Values.Dispose();
			}
		}

		public override void Destroy()
		{
			Dispose();
			base.Destroy();
		}
	}
}

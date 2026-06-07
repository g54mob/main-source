using System;
using System.Reflection;
using Coherence.Entities;
using Coherence.Interpolation;
using Coherence.SimulationFrame;
using UnityEngine;

namespace Coherence.Toolkit.Bindings
{
	public abstract class ValueBinding<T> : Binding
	{
		private BindingInterpolator<T> interpolator;

		private FieldInfo fieldInfo;

		private PropertyInfo propertyInfo;

		private FieldInfo componentFieldInfo;

		private FieldInfo componentFieldSimulationFrameInfo;

		private Type valueType;

		private MethodInfo cachedCallback;

		private T lastSentCompressed;

		private T lastCheckedForDirty;

		private bool performedInitialSync;

		protected T valueSyncOld;

		protected T valueSyncNew;

		protected bool valueSyncPrepared;

		private bool stopped;

		public virtual T Value { get; set; }

		public override object UntypedValue => null;

		public override string SignatureRichText => null;

		public override string SignaturePlainText => null;

		public BindingInterpolator<T> Interpolator => null;

		public override MemberInfo GetMemberInfo()
		{
			return null;
		}

		protected ValueBinding()
		{
		}

		public ValueBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		internal override bool Activate()
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override void CloneTo(Binding binding)
		{
		}

		private Type GetValueType()
		{
			return null;
		}

		private Type GetValueTypeOrNull()
		{
			return null;
		}

		private FieldInfo GetFieldInfo()
		{
			return null;
		}

		private PropertyInfo GetPropertyInfo()
		{
			return null;
		}

		protected object GetValueUsingReflection()
		{
			return null;
		}

		protected void SetValueUsingReflection(object value)
		{
		}

		public override void SetToLastSample()
		{
		}

		public override void ResetLastSentData()
		{
		}

		private FieldInfo GetComponentDataFieldInfo(ICoherenceComponentData componentData)
		{
			return null;
		}

		private FieldInfo GetComponentDataFieldSimulationFrameInfo(ICoherenceComponentData componentData)
		{
			return null;
		}

		public override void ReceiveComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame clientFrame, Vector3 floatingOriginDelta)
		{
		}

		public void ReceiveSampleFromNetwork(T data, bool stopped, AbsoluteSimulationFrame sampleFrame, AbsoluteSimulationFrame clientFrame)
		{
		}

		internal T PeekComponentData(ICoherenceComponentData coherenceComponent)
		{
			return default(T);
		}

		protected virtual (T, AbsoluteSimulationFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
		{
			return default((T, AbsoluteSimulationFrame));
		}

		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
		{
			return null;
		}

		internal override bool IsReadyToSample(double currentTime)
		{
			return false;
		}

		public override void SampleValue()
		{
		}

		public override void Interpolate(double time)
		{
		}

		public override void RemoveOutdatedSamples(double time)
		{
		}

		protected virtual T ClampToRange(in T value, long minRange, long maxRange)
		{
			return default(T);
		}

		protected T Interpolate(double time, T currentValue)
		{
			return default(T);
		}

		public T GetInterpolatedAt(double time)
		{
			return default(T);
		}

		protected MethodInfo GetCallbackMethodInfo()
		{
			return null;
		}

		private void PrepareValueSyncCallback(T currentValue, T newValue)
		{
		}

		public override void InvokeValueSyncCallback()
		{
		}

		public override void ValidateNotBound()
		{
		}

		public override void IsDirty(AbsoluteSimulationFrame simulationFrame, out bool dirty, out bool justStopped)
		{
			dirty = default(bool);
			justStopped = default(bool);
		}

		public override void MarkAsReadyToSend()
		{
		}

		protected abstract bool DiffersFrom(T first, T second);

		protected virtual T GetCompressedValue(T value)
		{
			return default(T);
		}

		internal override void ResetInterpolation()
		{
		}
	}
}

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Coherence.Entities;
using Coherence.Interpolation;
using Coherence.Log;
using Coherence.SimulationFrame;
using UnityEngine;

namespace Coherence.Toolkit.Bindings
{
	[Serializable]
	public abstract class Binding : IDisposable
	{
		[SerializeReference]
		protected Descriptor descriptor;

		[SerializeField]
		public MessageTarget routing;

		[SerializeField]
		protected SyncMode syncMode;

		[Obsolete("Please use predictionMode instead.")]
		[Deprecated("17/01/2024", 1, 2, 0, Reason = "Replaced by predictionMode.")]
		public bool isPredicted;

		public PredictionMode predictionMode;

		public string guid;

		[SerializeField]
		internal BindingArchetypeData archetypeData;

		public Component unityComponent;

		public CoherenceSync coherenceSync;

		[InterpolationPicker]
		public InterpolationSettings interpolationSettings;

		private Coherence.Log.Logger logger;

		protected double lastSampledTime;

		private Type coherenceComponentType;

		public string Name => null;

		public virtual string MemberNameInComponentData => null;

		public virtual string MemberNameInUnityComponent => null;

		public string FullName => null;

		public Type MonoAssemblyRuntimeType => null;

		public virtual Type CoherenceComponentType => null;

		public virtual string CoherenceComponentName => null;

		public virtual string CoherenceComponentNamespace => null;

		public virtual string CoherenceComponentAssemblyName => null;

		public virtual bool EmitSchemaComponentDefinition => false;

		public string SchemaFieldName => null;

		public string SchemaFieldSimulationFrameName => null;

		public virtual uint FieldMask => 0u;

		public string BakedSyncScriptCSharpType => null;

		public virtual string BakedSyncScriptGetter => null;

		public virtual string BakedSyncScriptSetter => null;

		public virtual bool OverrideSetter => false;

		public virtual bool OverrideGetter => false;

		public Component UnityComponent => null;

		public bool IsValid => false;

		public bool IsMethod => false;

		public bool EnforcesLODingWhenFieldsOverriden => false;

		public virtual object UntypedValue => null;

		public virtual string SignatureRichText => null;

		public virtual string SignaturePlainText => null;

		public string Signature => null;

		public SyncMode SyncMode => default(SyncMode);

		internal BindingArchetypeData BindingArchetypeData => null;

		public Descriptor Descriptor => null;

		protected Coherence.Log.Logger Logger => null;

		public event Action<object, bool, long> OnNetworkSampleReceived
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected Binding()
		{
		}

		public Binding(Descriptor descriptor, Component unityComponent)
		{
		}

		public void Dispose()
		{
		}

		internal void AssignComponent(Component component)
		{
		}

		internal bool EnsureGuid()
		{
			return false;
		}

		internal virtual bool Activate()
		{
			return false;
		}

		internal Type GetUnityComponentType()
		{
			return null;
		}

		public virtual void CloneTo(Binding clone)
		{
		}

		public Binding Clone(Component c)
		{
			return null;
		}

		internal bool CreateArchetypeData(SchemaType schemaType, int maxLods)
		{
			return false;
		}

		public virtual bool IsCurrentlyPredicted()
		{
			return false;
		}

		internal virtual bool IsReadyToSample(double currentTime)
		{
			return false;
		}

		internal void ClearSampleTime()
		{
		}

		internal virtual void ResetInterpolation()
		{
		}

		public virtual void OnConnectedEntityChanged()
		{
		}

		public virtual ICoherenceComponentData CreateComponentData()
		{
			return null;
		}

		protected void RaiseNetworkSampleReceived(object data, bool stopped, AbsoluteSimulationFrame sampleFrame)
		{
		}

		public virtual void SampleValue()
		{
		}

		public virtual void Interpolate(double time)
		{
		}

		public virtual void RemoveOutdatedSamples(double time)
		{
		}

		public virtual void InvokeValueSyncCallback()
		{
		}

		public virtual ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
		{
			return null;
		}

		public virtual void ReceiveComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame clientFrame, Vector3 floatingOriginDelta)
		{
		}

		public virtual MemberInfo GetMemberInfo()
		{
			return null;
		}

		public virtual void SetToLastSample()
		{
		}

		public virtual void ResetLastSentData()
		{
		}

		public virtual void ValidateNotBound()
		{
		}

		public abstract void IsDirty(AbsoluteSimulationFrame simulationFrame, out bool dirty, out bool justStopped);

		public abstract void MarkAsReadyToSend();

		protected virtual void OnBindingCloned()
		{
		}

		internal virtual (bool, string) IsBindingValid()
		{
			return default((bool, string));
		}
	}
}

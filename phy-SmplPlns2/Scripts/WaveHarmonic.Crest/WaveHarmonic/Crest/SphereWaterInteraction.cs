using System;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Sphere Water Interaction")]
	public sealed class SphereWaterInteraction : ManagedBehaviour<WaterRenderer>
	{
		private static class ShaderIDs
		{
			public static readonly int s_Velocity = Shader.PropertyToID("_Crest_Velocity");

			public static readonly int s_Weight = Shader.PropertyToID("_Crest_Weight");

			public static readonly int s_Radius = Shader.PropertyToID("_Crest_Radius");

			public static readonly int s_InnerSphereOffset = Shader.PropertyToID("_Crest_InnerSphereOffset");

			public static readonly int s_InnerSphereMultiplier = Shader.PropertyToID("_Crest_InnerSphereMultiplier");

			public static readonly int s_LargeWaveMultiplier = Shader.PropertyToID("_Crest_LargeWaveMultiplier");
		}

		private sealed class Input : ILodInput
		{
			private readonly SphereWaterInteraction _Input;

			public bool Enabled => _Input.enabled;

			public bool IsCompute => true;

			public int Queue => 0;

			public int Pass => -1;

			public Rect Rect => _Input.Rect;

			public MonoBehaviour Component => _Input;

			public Input(SphereWaterInteraction input)
			{
				_Input = input;
			}

			public float Filter(WaterRenderer water, int slice)
			{
				return 1f;
			}

			public void Draw(Lod lod, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slice = -1)
			{
				_Input.Draw(lod, buffer, target, pass, weight, slice);
			}
		}

		[Tooltip("Radius of the sphere that is modelled from which the interaction forces are calculated.")]
		[SerializeField]
		internal float _Radius = 1f;

		[Tooltip("Intensity of the forces.\n\nCan be set negative to invert.")]
		[SerializeField]
		private float _Weight = 1f;

		[Tooltip("Intensity of the forces from vertical motion of the sphere.\n\nScales ripples generated from a sphere moving up or down.")]
		[SerializeField]
		private float _WeightVerticalMultiplier = 0.5f;

		[Tooltip("Model parameter that can be used to modify the shape of the interaction.\n\nInternally the interaction is modelled by a pair of nested spheres. The forces from the two spheres combine to create the final effect. This parameter scales the effect of the inner sphere and can be tweaked to adjust the shape of the result.")]
		[SerializeField]
		private float _InnerSphereMultiplier = 1.55f;

		[Tooltip("Model parameter that can be used to modify the shape of the interaction.\n\nThis parameter controls the size of the inner sphere and can be tweaked to give further control over the result.")]
		[SerializeField]
		private float _InnerSphereOffset = 0.109f;

		[Tooltip("Offset in direction of motion to help ripples appear in front of sphere.\n\nThere is some latency between applying a force to the wave simualtion and the resulting waves appearing. Applying this offset can help to ensure the waves do not lag behind the sphere.")]
		[SerializeField]
		internal float _VelocityOffset = 0.04f;

		[Tooltip("How much to correct the position for horizontal wave displacement.\n\nIf set to 0, the input will always be applied at a fixed position before any horizontal displacement from waves. If waves are large then their displacement may cause the interactive waves to drift away from the object. This parameter can be increased to compensate for this displacement and combat this issue. However increasing too far can cause a feedback loop which causes strong 'ring' artifacts to appear in the dynamic waves. This parameter can be tweaked to balance this two effects.")]
		[SerializeField]
		private float _CompensateForWaveMotion = 0.45f;

		[Tooltip("Whether to improve visibility in larger LODs.\n\nIf the dynamic waves are not visible far enough in the distance from the camera, this can be used to boost the output.")]
		[SerializeField]
		private bool _BoostLargeWaves;

		[Header("Limits")]
		[Tooltip("Teleport speed (km/h).\n\nIf the calculated speed is larger than this amount, the object is deemed to have teleported and the computed velocity is discarded.")]
		[SerializeField]
		private float _TeleportSpeed = 500f;

		[Tooltip("Outputs a warning to the console on teleport.")]
		[SerializeField]
		private bool _WarnOnTeleport;

		[Tooltip("Maximum speed clamp (km/h).\n\nUseful for controlling/limiting wake.")]
		[SerializeField]
		private float _MaximumSpeed = 100f;

		[Tooltip("Outputs a warning to the console on speed clamp.")]
		[SerializeField]
		private bool _WarnOnSpeedClamp;

		[Header("Debug")]
		[Tooltip("Draws debug lines at each substep position. Editor only.")]
		[SerializeField]
		private bool _DebugSubsteps;

		internal Vector3 _Velocity;

		private Vector3 _VelocityClamped;

		private Vector3 _PreviousPosition;

		private Vector3 _RelativeVelocity;

		private Vector3 _Displacement;

		private float _WeightThisFrame;

		private readonly SampleCollisionHelper _SampleHeightHelper = new SampleCollisionHelper();

		private readonly SampleFlowHelper _SampleFlowHelper = new SampleFlowHelper();

		private Input _Input;

		private static ComputeShader ComputeShader => ScriptableSingleton<WaterResources>.Instance.Compute._SphereWaterInteraction;

		private Rect Rect => new Rect(base.transform.position.XZ() - _Displacement.XZ() * _CompensateForWaveMotion - Vector2.one * (_Radius * 4f * 0.5f), Vector2.one * (_Radius * 4f));

		private protected override Action<WaterRenderer> OnUpdateMethod => OnUpdate;

		public bool BoostLargeWaves
		{
			get
			{
				return _BoostLargeWaves;
			}
			set
			{
				_BoostLargeWaves = value;
			}
		}

		public float CompensateForWaveMotion
		{
			get
			{
				return _CompensateForWaveMotion;
			}
			set
			{
				_CompensateForWaveMotion = value;
			}
		}

		public float InnerSphereMultiplier
		{
			get
			{
				return _InnerSphereMultiplier;
			}
			set
			{
				_InnerSphereMultiplier = value;
			}
		}

		public float InnerSphereOffset
		{
			get
			{
				return _InnerSphereOffset;
			}
			set
			{
				_InnerSphereOffset = value;
			}
		}

		public float MaximumSpeed
		{
			get
			{
				return _MaximumSpeed;
			}
			set
			{
				_MaximumSpeed = value;
			}
		}

		public float Radius
		{
			get
			{
				return _Radius;
			}
			set
			{
				_Radius = value;
			}
		}

		public float TeleportSpeed
		{
			get
			{
				return _TeleportSpeed;
			}
			set
			{
				_TeleportSpeed = value;
			}
		}

		public float VelocityOffset
		{
			get
			{
				return _VelocityOffset;
			}
			set
			{
				_VelocityOffset = value;
			}
		}

		public bool WarnOnSpeedClamp
		{
			get
			{
				return _WarnOnSpeedClamp;
			}
			set
			{
				_WarnOnSpeedClamp = value;
			}
		}

		public bool WarnOnTeleport
		{
			get
			{
				return _WarnOnTeleport;
			}
			set
			{
				_WarnOnTeleport = value;
			}
		}

		public float Weight
		{
			get
			{
				return _Weight;
			}
			set
			{
				_Weight = value;
			}
		}

		public float WeightVerticalMultiplier
		{
			get
			{
				return _WeightVerticalMultiplier;
			}
			set
			{
				_WeightVerticalMultiplier = value;
			}
		}

		private void OnUpdate(WaterRenderer water)
		{
			_SampleHeightHelper.SampleDisplacement(base.transform.position, out _Displacement, 2f * _Radius);
			LateUpdateComputeVel(water);
			_RelativeVelocity = _VelocityClamped;
			_SampleFlowHelper.Sample(base.transform.position, out var flow, 2f * _Radius);
			_RelativeVelocity -= new Vector3(flow.x, 0f, flow.y);
			_RelativeVelocity.y *= _WeightVerticalMultiplier;
			_WeightThisFrame = 3.75f * _Weight;
			float waterHeight = _Displacement.y + water.SeaLevel;
			LateUpdateSphereWeight(waterHeight, ref _WeightThisFrame);
			float num = Mathf.Sqrt(water._DynamicWavesLod.Settings._GravityMultiplier) / 5f;
			_WeightThisFrame *= num;
			_PreviousPosition = base.transform.position;
		}

		private void LateUpdateComputeVel(WaterRenderer water)
		{
			_Velocity = (base.transform.position - _PreviousPosition) / water.DeltaTime;
			if (water.DeltaTime < 0.0001f)
			{
				_Velocity = Vector3.zero;
			}
			float num = _Velocity.magnitude * 3.6f;
			if (num > _TeleportSpeed)
			{
				_Velocity *= 0f;
				if (_WarnOnTeleport)
				{
					Debug.LogWarning("Crest: Teleport detected (speed = " + num + "), velocity discarded.", this);
				}
				num = _Velocity.magnitude * 3.6f;
			}
			if (num > _MaximumSpeed)
			{
				_VelocityClamped = _Velocity * _MaximumSpeed / num;
				if (_WarnOnSpeedClamp)
				{
					Debug.LogWarning("Crest: Speed (" + num + ") exceeded max limited, clamped.", this);
				}
			}
			else
			{
				_VelocityClamped = _Velocity;
			}
		}

		private void LateUpdateSphereWeight(float waterHeight, ref float weight)
		{
			float num = waterHeight - base.transform.position.y;
			if (num >= 0f)
			{
				float num2 = num / _Radius;
				num2 *= 0.5f;
				weight *= Mathf.Exp((0f - num2) * num2);
			}
			else
			{
				float num3 = 0f - num;
				float f = 1f - Mathf.Clamp01(num3 / _Radius);
				weight *= Mathf.Sqrt(f);
			}
		}

		private protected override void Initialize()
		{
			base.Initialize();
			if (_Input == null)
			{
				_Input = new Input(this);
			}
			ILodInput.Attach(_Input, DynamicWavesLod.s_Inputs);
			_PreviousPosition = base.transform.position;
		}

		private protected override void OnDisable()
		{
			base.OnDisable();
			ILodInput.Detach(_Input, DynamicWavesLod.s_Inputs);
		}

		private void Draw(Lod simulation, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slices = -1)
		{
			float timeLeftToSimulate = (simulation as DynamicWavesLod).TimeLeftToSimulate;
			PropertyWrapperCompute propertyWrapperCompute = new PropertyWrapperCompute(buffer, ComputeShader, 0);
			Vector3 vector = _Velocity * (timeLeftToSimulate - _VelocityOffset);
			Vector3 vector2 = _Displacement.XNZ() * _CompensateForWaveMotion;
			propertyWrapperCompute.SetVector(WaveHarmonic.Crest.ShaderIDs.s_Position, base.transform.position - vector - vector2);
			propertyWrapperCompute.SetFloat(ShaderIDs.s_Radius, _Radius * 1.1f);
			propertyWrapperCompute.SetFloat(ShaderIDs.s_Weight, _WeightThisFrame);
			propertyWrapperCompute.SetFloat(ShaderIDs.s_InnerSphereOffset, _InnerSphereOffset);
			propertyWrapperCompute.SetFloat(ShaderIDs.s_InnerSphereMultiplier, _InnerSphereMultiplier);
			propertyWrapperCompute.SetFloat(ShaderIDs.s_LargeWaveMultiplier, _BoostLargeWaves ? 2f : 1f);
			propertyWrapperCompute.SetVector(ShaderIDs.s_Velocity, _RelativeVelocity);
			propertyWrapperCompute.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, target);
			int num = simulation.Resolution / 8;
			propertyWrapperCompute.Dispatch(num, num, slices);
		}
	}
}

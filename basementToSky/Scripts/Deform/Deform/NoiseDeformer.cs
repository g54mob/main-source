using Unity.Jobs;
using UnityEngine;

namespace Deform
{
	public abstract class NoiseDeformer : Deformer, IFactor
	{
		[SerializeField]
		[HideInInspector]
		private NoiseMode mode;

		[SerializeField]
		[HideInInspector]
		private float magnitudeScalar;

		[SerializeField]
		[HideInInspector]
		private Vector3 magnitudeVector = Vector3.one;

		[SerializeField]
		[HideInInspector]
		private float frequencyScalar = 2f;

		[SerializeField]
		[HideInInspector]
		private Vector3 frequencyVector = Vector3.one;

		[SerializeField]
		[HideInInspector]
		private Vector4 offsetVector;

		[SerializeField]
		[HideInInspector]
		private float offsetSpeedScalar = 1f;

		[SerializeField]
		[HideInInspector]
		private Vector4 offsetSpeedVector = new Vector4(0f, 0f, 0f);

		[SerializeField]
		[HideInInspector]
		private Transform axis;

		protected Vector4 speedOffset;

		public float Factor
		{
			get
			{
				return MagnitudeScalar;
			}
			set
			{
				MagnitudeScalar = value;
			}
		}

		public NoiseMode Mode
		{
			get
			{
				return mode;
			}
			set
			{
				mode = value;
			}
		}

		public float MagnitudeScalar
		{
			get
			{
				return magnitudeScalar;
			}
			set
			{
				magnitudeScalar = value;
			}
		}

		public Vector3 MagnitudeVector
		{
			get
			{
				return magnitudeVector;
			}
			set
			{
				magnitudeVector = value;
			}
		}

		public float FrequencyScalar
		{
			get
			{
				return frequencyScalar;
			}
			set
			{
				frequencyScalar = value;
			}
		}

		public Vector3 FrequencyVector
		{
			get
			{
				return frequencyVector;
			}
			set
			{
				frequencyVector = value;
			}
		}

		public Vector4 OffsetVector
		{
			get
			{
				return offsetVector;
			}
			set
			{
				offsetVector = value;
			}
		}

		public float OffsetSpeedScalar
		{
			get
			{
				return offsetSpeedScalar;
			}
			set
			{
				offsetSpeedScalar = value;
			}
		}

		public Vector4 OffsetSpeedVector
		{
			get
			{
				return offsetSpeedVector;
			}
			set
			{
				offsetSpeedVector = value;
			}
		}

		public Transform Axis
		{
			get
			{
				if (axis == null)
				{
					axis = base.transform;
				}
				return axis;
			}
			set
			{
				axis = value;
			}
		}

		public override DataFlags DataFlags => DataFlags.Vertices;

		public Vector3 GetActualMagnitude()
		{
			return MagnitudeVector * MagnitudeScalar;
		}

		public Vector3 GetActualFrequency()
		{
			return FrequencyVector * FrequencyScalar;
		}

		public Vector4 GetActualOffset()
		{
			return speedOffset + OffsetVector;
		}

		protected virtual void Update()
		{
			speedOffset += OffsetSpeedVector * (OffsetSpeedScalar * Time.deltaTime);
		}

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			if (GetActualMagnitude() == Vector3.zero)
			{
				return dependency;
			}
			return Mode switch
			{
				NoiseMode.Directional => CreateDirectionalNoiseJob(data, dependency), 
				NoiseMode.Normal => CreateNormalNoiseJob(data, dependency), 
				NoiseMode.Spherical => CreateSphericalNoiseJob(data, dependency), 
				NoiseMode.Color => CreateColorNoiseJob(data, dependency), 
				_ => Create3DNoiseJob(data, dependency), 
			};
		}

		protected abstract JobHandle Create3DNoiseJob(MeshData data, JobHandle dependency = default(JobHandle));

		protected abstract JobHandle CreateDirectionalNoiseJob(MeshData data, JobHandle dependency = default(JobHandle));

		protected abstract JobHandle CreateNormalNoiseJob(MeshData data, JobHandle dependency = default(JobHandle));

		protected abstract JobHandle CreateSphericalNoiseJob(MeshData data, JobHandle dependency = default(JobHandle));

		protected abstract JobHandle CreateColorNoiseJob(MeshData data, JobHandle dependency = default(JobHandle));
	}
}

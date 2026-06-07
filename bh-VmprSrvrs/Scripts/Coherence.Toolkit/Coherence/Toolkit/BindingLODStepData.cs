using System;
using UnityEngine;

namespace Coherence.Toolkit
{
	[Serializable]
	internal class BindingLODStepData
	{
		internal struct Overrides
		{
			public FloatCompression compression;

			public double precision;

			public int bits;
		}

		internal const int FLOAT_DEFAULT_BITS = 32;

		internal const double FLOAT_MIN_PRECISION = 0.1;

		internal const double FLOAT_DEFAULT_PRECISION = 0.001;

		internal const int FLOAT64_DEFAULT_BITS = 64;

		[SerializeField]
		private SchemaType type;

		[SerializeField]
		private int bits;

		[SerializeField]
		private double precision;

		[SerializeField]
		private FloatCompression floatCompression;

		private int level;

		public SchemaType SchemaType
		{
			get
			{
				return default(SchemaType);
			}
			internal set
			{
			}
		}

		internal bool IsFloatType => false;

		public int Bits => 0;

		public double Precision => 0.0;

		internal FloatCompression FloatCompression => default(FloatCompression);

		public int TotalBits => 0;

		internal bool IsOverriding => false;

		internal BindingLODStepData(BindingArchetypeData data, int level)
		{
		}

		internal BindingLODStepData(BindingLODStepData other, BindingArchetypeData data)
		{
		}

		internal void CopyFrom(BindingLODStepData other, BindingArchetypeData data)
		{
		}

		private void SetToData(BindingArchetypeData data, int level)
		{
		}

		internal void SetDefaultOverrides(SchemaType type)
		{
		}

		private static Overrides DefaultFloatOverride()
		{
			return default(Overrides);
		}

		private static Overrides DefaultFloat64Override()
		{
			return default(Overrides);
		}

		internal static Overrides GetDefaultOverrides(SchemaType type)
		{
			return default(Overrides);
		}

		internal static int GetDefaultBits(SchemaType type)
		{
			return 0;
		}

		internal bool SetPrecision(double precision)
		{
			return false;
		}

		internal void SetFloatCompression(FloatCompression floatCompression)
		{
		}

		internal void SetBits(int bits)
		{
		}

		internal void Verify(long minRange, long maxRange)
		{
		}

		private void VerifyQuaternion()
		{
		}

		private void VerifyColor()
		{
		}

		private void VerifyFloat(long minRange, long maxRange)
		{
		}

		internal void UpdateModel(BindingArchetypeData model, int level, bool forceUpdate = false)
		{
		}
	}
}

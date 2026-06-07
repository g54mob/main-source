using System;
using System.Collections.Generic;
using UnityEngine;

namespace Coherence.Toolkit
{
	[Serializable]
	internal class BindingArchetypeData
	{
		public readonly bool IsMethod;

		[SerializeField]
		protected SchemaType type;

		[SerializeField]
		protected long minRange;

		[SerializeField]
		protected long maxRange;

		[SerializeField]
		protected float sampleRate;

		[SerializeField]
		internal FloatCompression floatCompression;

		[SerializeField]
		protected List<BindingLODStepData> fields;

		internal bool IsFloatType => false;

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

		public List<BindingLODStepData> Fields => null;

		public long MinRange => 0L;

		public long MaxRange => 0L;

		public ulong TotalRange => 0uL;

		public float SampleRate => 0f;

		internal FloatCompression FloatCompression => default(FloatCompression);

		internal bool CanOverride => false;

		public BindingArchetypeData(SchemaType type, Type valueType, bool isMethod)
		{
		}

		internal bool IsRangeType()
		{
			return false;
		}

		internal static bool IsBitsBased(SchemaType type)
		{
			return false;
		}

		internal static bool IsFloatBased(SchemaType type)
		{
			return false;
		}

		internal void SetRange(long minRange, long maxRange)
		{
		}

		internal void SetSampleRate(float sampleRate)
		{
		}

		internal void SetFloatCompression(FloatCompression floatCompression)
		{
		}

		internal virtual void CopyFrom(BindingArchetypeData other)
		{
		}

		internal bool Update(SchemaType type, Type valueType, int lodsteps)
		{
			return false;
		}

		internal void SetRangesToDefaultValues(Type valueType)
		{
		}

		public int GetTotalBitsOfLOD(int lodStep)
		{
			return 0;
		}

		internal BindingLODStepData GetLODstep(int lodStep)
		{
			return null;
		}

		internal bool AddLODStep(int lodStep)
		{
			return false;
		}

		private bool InstantiateFieldsList()
		{
			return false;
		}

		internal void RemoveLODLevel(int lodStep, int maxLods)
		{
		}

		internal void ResetValuesToDefault(Type bindingValueType, bool resetRanges, bool resetBitsAndPrecision)
		{
		}

		internal (long, long) GetRangeByLODs()
		{
			return default((long, long));
		}

		internal void ResetRanges(Type bindingValueType)
		{
		}

		private void ResetBitsAndPrecision()
		{
		}

		internal bool FixSerializedDataInFields()
		{
			return false;
		}
	}
}

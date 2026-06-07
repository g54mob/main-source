using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace AK.Wwise
{
	[Serializable]
	public abstract class BaseType
	{
		[HideInInspector]
		[SerializeField]
		[FormerlySerializedAs("ID")]
		private int idInternal;

		[HideInInspector]
		[SerializeField]
		[FormerlySerializedAs("valueGuid")]
		private byte[] valueGuidInternal;

		public abstract WwiseObjectReference ObjectReference { get; set; }

		public abstract WwiseObjectType WwiseObjectType { get; }

		public virtual string Name => null;

		public uint Id => 0u;

		public static uint InvalidId => 0u;

		[Obsolete("This functionality is deprecated as of Wwise v2018.1.2 and will be removed in a future release.")]
		public int ID => 0;

		[Obsolete("This functionality is deprecated as of Wwise v2018.1.6 and will be removed in a future release.")]
		public byte[] valueGuid => null;

		public static int CombineHashCodes(int[] hashCodes)
		{
			return 0;
		}

		public virtual bool IsValid()
		{
			return false;
		}

		public bool Validate()
		{
			return false;
		}

		protected void Verify(AKRESULT result)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}

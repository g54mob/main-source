using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace AK.Wwise
{
	[Serializable]
	public abstract class BaseGroupType : BaseType
	{
		[HideInInspector]
		[SerializeField]
		[FormerlySerializedAs("groupID")]
		private int groupIdInternal;

		[HideInInspector]
		[SerializeField]
		[FormerlySerializedAs("groupGuid")]
		private byte[] groupGuidInternal;

		public WwiseObjectReference GroupWwiseObjectReference => null;

		public abstract WwiseObjectType WwiseObjectGroupType { get; }

		public uint GroupId => 0u;

		[Obsolete("This functionality is deprecated as of Wwise v2018.1.2 and will be removed in a future release.")]
		public int groupID => 0;

		[Obsolete("This functionality is deprecated as of Wwise v2018.1.6 and will be removed in a future release.")]
		public byte[] groupGuid => null;

		public override bool IsValid()
		{
			return false;
		}
	}
}

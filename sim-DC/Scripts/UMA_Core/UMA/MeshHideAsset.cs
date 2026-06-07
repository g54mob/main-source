using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class MeshHideAsset : ScriptableObject, ISerializationCallbackReceiver
	{
		[Serializable]
		public class serializedFlags
		{
			public int[] flags;

			public int Count;

			public serializedFlags(int count)
			{
			}
		}

		[SerializeField]
		private SlotDataAsset _asset;

		[SerializeField]
		private string _assetSlotName;

		private BitArray[] _triangleFlags;

		[SerializeField]
		private serializedFlags[] _serializedFlags;

		public SlotDataAsset asset
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool HasReference => false;

		public string AssetSlotName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BitArray[] triangleFlags => null;

		public int SubmeshCount => 0;

		public int TriangleCount => 0;

		public int HiddenCount => 0;

		public void FreeReference()
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		[ExecuteInEditMode]
		public void Initialize()
		{
		}

		[ExecuteInEditMode]
		public void SetTriangleFlag(int triangleIndex, bool flag, int submesh = 0)
		{
		}

		[ExecuteInEditMode]
		public void SaveSelection(BitArray selection)
		{
		}

		public static BitArray[] GenerateMask(List<MeshHideAsset> assets)
		{
			return null;
		}

		public static BitArray[] CombineTriangleFlags(List<BitArray[]> flags)
		{
			return null;
		}
	}
}

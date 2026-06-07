using System;
using System.Collections.Generic;
using Libs;
using UnityEngine;

namespace SaveData
{
	[Serializable]
	public class PlayOutGameShopData : ISerializationCallbackReceiver
	{
		[SerializeField]
		private JDictionary<eOutGameShopId, OutGameShopUnlockData> _outGameShopDict;

		public JDictionary<eOutGameShopId, OutGameShopUnlockData> OutGameShopDict
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<eOutGameShopId> purchasedOutShopIds => null;

		public List<eOutGameShopId> enabledOutShopIds => null;

		public void AddNewOutShopData(eOutGameShopId id)
		{
		}

		public void AddNewOutShopData(MstOutGameShopEntities entity)
		{
		}

		public void PurchaseGreaterKnowledgeProcess(eOutGameShopId id)
		{
		}

		public void ResetGreaterKnowledgeProcess(eOutGameShopId id)
		{
		}

		public void SetEnable(eOutGameShopId id, bool enable)
		{
		}

		private void SetEnableAncestors(eOutGameShopId id, bool enable)
		{
		}

		private void SetEnableDescendants(eOutGameShopId id, bool enable)
		{
		}

		public bool IsPurchased(eOutGameShopId id)
		{
			return false;
		}

		public bool? GetEnable(eOutGameShopId id)
		{
			return null;
		}

		public bool IsEnable(eOutGameShopId id)
		{
			return false;
		}

		public void OnAfterDeserialize()
		{
		}

		public void OnBeforeSerialize()
		{
		}
	}
}

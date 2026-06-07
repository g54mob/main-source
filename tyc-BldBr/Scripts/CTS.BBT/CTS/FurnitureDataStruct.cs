using System;
using CTS.BBT;
using UnityEngine.AddressableAssets;

namespace CTS
{
	[Serializable]
	public class FurnitureDataStruct : AbsBalancingDataStruct
	{
		public string Id;

		public int Price;

		public float Influence;

		public int PrestigePoint;

		public float PrestigeByPrice;

		public override int SaveBalancingDataUpdated(bool p_clearSO)
		{
			if (p_clearSO)
			{
				return 0;
			}
			Addressables.LoadAssetAsync<FurnitureSO>("Assets/Scriptables/Furnitures/Prefabs/" + Id + ".asset").WaitForCompletion().SetNewValues(this);
			return 1;
		}
	}
}

using System;
using UnityEngine.AddressableAssets;

namespace CTS
{
	[Serializable]
	public class CustomerDataStruct : AbsBalancingDataStruct
	{
		public string Id;

		public int MinStartMoney;

		public int MaxStartMoney;

		public int Credibility;

		public override int SaveBalancingDataUpdated(bool p_clearSO)
		{
			if (p_clearSO)
			{
				return 0;
			}
			Addressables.LoadAssetAsync<CustomerParameters>("Assets/Scriptables/Customers/" + Id).WaitForCompletion().SetNewValues(this);
			return 1;
		}
	}
}

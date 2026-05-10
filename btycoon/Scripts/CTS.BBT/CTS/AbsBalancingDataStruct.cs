using UnityEngine;

namespace CTS
{
	public abstract class AbsBalancingDataStruct : MonoBehaviour
	{
		public bool expanded;

		public abstract int SaveBalancingDataUpdated(bool p_clearSO);
	}
}

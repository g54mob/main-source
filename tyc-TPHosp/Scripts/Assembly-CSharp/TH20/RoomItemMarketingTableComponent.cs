using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemMarketingTableComponent : MonoBehaviour
	{
		[SerializeField]
		private GameObject _tableItems;

		private void Awake()
		{
			EnableItems(enable: false);
		}

		public void EnableItems(bool enable)
		{
			GameObjectUtils.SetActive(_tableItems, enable);
		}
	}
}

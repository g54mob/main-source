using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class AccessToExteriorCondition : MonoCondition
	{
		[SerializeField]
		private EAccess _accessCondition;

		public override bool IsConditionValid()
		{
			return _accessCondition.HasFlagNonAlloc(MonoSingleton<BuildingRoomsContainerManager>.Instance.AllRoomHaveExteriorAccess);
		}
	}
}

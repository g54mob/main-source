using CTS.Core;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class ConstructionSystemOpenCondition : MonoCondition
	{
		[SerializeField]
		private bool _validWhenOpen;

		public override bool IsConditionValid()
		{
			if (_validWhenOpen)
			{
				return MonoSingleton<UI_ConstructionSystem>.Instance.IsOpen;
			}
			return !MonoSingleton<UI_ConstructionSystem>.Instance.IsOpen;
		}
	}
}

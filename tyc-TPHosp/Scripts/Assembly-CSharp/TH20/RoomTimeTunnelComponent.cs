using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomTimeTunnelComponent : EntityTickComponent
	{
		private IllnessEraType _eraType;

		private float _eraSwitchTimer;

		private void Initialise()
		{
			Array values = Enum.GetValues(typeof(IllnessEraType));
			_eraType = (IllnessEraType)values.GetValue(UnityEngine.Random.Range(1, values.Length));
			_eraSwitchTimer = 0f;
		}

		public bool IsEraTypeValid(IllnessEraType eraType)
		{
			if (_eraSwitchTimer == 0f)
			{
				return _eraType == eraType;
			}
			return false;
		}

		public bool SwitchEra(IllnessEraType eraType, float switchTime)
		{
			if (_eraType == eraType || _eraSwitchTimer > 0f)
			{
				return false;
			}
			_eraType = eraType;
			_eraSwitchTimer = switchTime;
			return true;
		}

		public bool IsSwitchingEra()
		{
			return _eraSwitchTimer > 0f;
		}

		public override void Tick()
		{
			base.Tick();
			if (_eraType == IllnessEraType.None)
			{
				Initialise();
			}
			if (_eraSwitchTimer > 0f)
			{
				_eraSwitchTimer = Mathf.Max(_eraSwitchTimer - Time.deltaTime, 0f);
			}
		}
	}
}

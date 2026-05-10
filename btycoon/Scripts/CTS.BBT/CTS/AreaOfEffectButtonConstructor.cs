using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Powers/Button - AOE")]
	public class AreaOfEffectButtonConstructor : ActionButtonConstructor
	{
		[SerializeField]
		private AreaOfEffectPowerData _data;

		public override void ConstructButton(ActionButton obj)
		{
			AreaOfEffectPower areaOfEffectPower = obj.gameObject.AddComponent<AreaOfEffectPower>();
			areaOfEffectPower.enabled = false;
			areaOfEffectPower.Setup(_data);
		}
	}
}

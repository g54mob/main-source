using UnityEngine;

namespace Gh.Tk
{
	public class DamageTint : Tint
	{
		private DamageStat _damageStat;

		private DamageStat DamageStat => null;

		public override void EnableTint(bool enable)
		{
		}

		protected override Color GetColor()
		{
			return default(Color);
		}

		private void OnDamageValueChanged(object sender, ValueChangedEventArgs<float> e)
		{
		}
	}
}

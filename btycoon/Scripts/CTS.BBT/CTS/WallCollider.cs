using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class WallCollider : CTSBehaviour
	{
		[Inject(false)]
		private BoxCollider _boxCollider;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			WallHideButton.ValueChanged += OnValueChanged;
			OnValueChanged(WallHideButton.CurrentValue);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			WallHideButton.ValueChanged -= OnValueChanged;
		}

		private void OnValueChanged(float value)
		{
			value = 2.5f * value;
			_boxCollider.size = _boxCollider.size.SetY(value);
			_boxCollider.center = _boxCollider.center.SetY(value * 0.5f);
		}
	}
}

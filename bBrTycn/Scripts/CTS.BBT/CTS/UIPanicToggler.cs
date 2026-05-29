using CTS.Core;
using UnityEngine;
using UnityEngine.Events;

namespace CTS
{
	public class UIPanicToggler : CTSBehaviour
	{
		[SerializeField]
		private UnityEvent<bool> _panicEnabled;

		[SerializeField]
		private UnityEvent<bool> _panicDisabled;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			PanicCounter.PanicActive += OnPanicChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			PanicCounter.PanicActive -= OnPanicChanged;
		}

		private void OnPanicChanged(bool active)
		{
			_panicEnabled.Invoke(active);
			_panicDisabled.Invoke(!active);
		}
	}
}

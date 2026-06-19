using Loxodon.Framework.Binding.Reflection;
using UnityEngine.Events;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public class UnityPropertyProxy<TValue> : PropertyTargetProxy
	{
		private UnityEvent<TValue> unityEvent;

		public override BindingMode DefaultMode => BindingMode.TwoWay;

		public UnityPropertyProxy(object target, IProxyPropertyInfo propertyInfo, UnityEvent<TValue> unityEvent)
			: base(target, propertyInfo)
		{
			this.unityEvent = unityEvent;
		}

		protected override void DoSubscribeForValueChange(object target)
		{
			if (unityEvent != null && target != null)
			{
				unityEvent.AddListener(OnValueChanged);
			}
		}

		protected override void DoUnsubscribeForValueChange(object target)
		{
			if (unityEvent != null)
			{
				unityEvent.RemoveListener(OnValueChanged);
			}
		}

		private void OnValueChanged(TValue value)
		{
			RaiseValueChanged();
		}
	}
}

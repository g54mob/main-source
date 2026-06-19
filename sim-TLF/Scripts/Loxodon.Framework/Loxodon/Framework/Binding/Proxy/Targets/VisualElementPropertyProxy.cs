using Loxodon.Framework.Binding.Reflection;
using UnityEngine.UIElements;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public class VisualElementPropertyProxy<TValue> : PropertyTargetProxy
	{
		private readonly INotifyValueChanged<TValue> notifyValueChanged;

		public override BindingMode DefaultMode => BindingMode.TwoWay;

		public VisualElementPropertyProxy(object target, IProxyPropertyInfo propertyInfo)
			: base(target, propertyInfo)
		{
			if (target is INotifyValueChanged<TValue>)
			{
				notifyValueChanged = (INotifyValueChanged<TValue>)target;
			}
			else
			{
				notifyValueChanged = null;
			}
		}

		protected override void DoSubscribeForValueChange(object target)
		{
			if (notifyValueChanged != null && target != null)
			{
				notifyValueChanged.RegisterValueChangedCallback(OnValueChanged);
			}
		}

		protected override void DoUnsubscribeForValueChange(object target)
		{
			if (notifyValueChanged != null)
			{
				notifyValueChanged.UnregisterValueChangedCallback(OnValueChanged);
			}
		}

		private void OnValueChanged(ChangeEvent<TValue> e)
		{
			RaiseValueChanged();
		}
	}
}

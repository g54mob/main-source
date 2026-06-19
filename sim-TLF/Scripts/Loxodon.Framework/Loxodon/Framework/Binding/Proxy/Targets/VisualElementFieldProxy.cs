using Loxodon.Framework.Binding.Reflection;
using UnityEngine.UIElements;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public class VisualElementFieldProxy<TValue> : FieldTargetProxy
	{
		private readonly INotifyValueChanged<TValue> notifyValueChanged;

		public override BindingMode DefaultMode => BindingMode.TwoWay;

		public VisualElementFieldProxy(object target, IProxyFieldInfo fieldInfo)
			: base(target, fieldInfo)
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

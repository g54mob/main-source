using UnityEngine.Events;

namespace SettingScripts
{
	public static class SettingSubscriber
	{
		public static TValue SubscribeTo<TSetting, TValue>(this TSetting setting, UnityAction<TValue, TValue> act, bool invokeNow = false) where TSetting : Setting<TValue>
		{
			setting.OnValueChangeWithPrecedent.AddListener(act);
			if (invokeNow)
			{
				act(setting.val, setting.val);
			}
			return setting.val;
		}

		public static TValue SubscribeTo<TSetting, TValue>(this TSetting setting, UnityAction<TValue> act, bool invokeNow = false) where TSetting : Setting<TValue>
		{
			setting.OnValueChange.AddListener(act);
			if (invokeNow)
			{
				act(setting.val);
			}
			return setting.val;
		}

		public static TValue SubscribeTo<TSetting, TValue>(this TSetting setting, UnityAction act, bool invokeNow = false) where TSetting : Setting<TValue>
		{
			setting.OnChange.AddListener(act);
			if (invokeNow)
			{
				act();
			}
			return setting.val;
		}

		public static void UnSubscribeTo<TSetting, TValue>(this TSetting setting, UnityAction<TValue, TValue> act) where TSetting : Setting<TValue>
		{
			setting.OnValueChangeWithPrecedent.RemoveListener(act);
		}

		public static void UnSubscribeTo<TSetting, TValue>(this TSetting setting, UnityAction<TValue> act) where TSetting : Setting<TValue>
		{
			setting.OnValueChange.RemoveListener(act);
		}

		public static void UnSubscribeTo<TSetting, TValue>(this TSetting setting, UnityAction act) where TSetting : Setting<TValue>
		{
			setting.OnChange.RemoveListener(act);
		}
	}
}

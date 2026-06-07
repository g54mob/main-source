namespace Assets.Scripts.Multiplayer.ActivityFramework.Events
{
	public class NetworkedActivitySettingValueChangedEventArgs<TValue> : NetworkedActivitySettingEventArgs
	{
		public TValue CurrentValue { get; }

		public TValue PreviousValue { get; }

		public NetworkedActivitySettingValueChangedEventArgs(NetworkedActivitySetting setting, TValue previousValue, TValue currentValue)
			: base(setting)
		{
			PreviousValue = previousValue;
			CurrentValue = currentValue;
		}
	}
}

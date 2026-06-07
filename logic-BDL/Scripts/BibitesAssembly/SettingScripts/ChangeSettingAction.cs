using ManagementScripts;
using ScriptHelpers;

namespace SettingScripts
{
	public class ChangeSettingAction<TSetting, TType> : IRevertableAction where TSetting : Setting<TType>
	{
		private TSetting setting;

		private TType previousValue;

		private TType newValue;

		public ChangeSettingAction(TSetting changedSetting, TType from, TType to, bool addToStack = true)
		{
			setting = changedSetting;
			previousValue = from;
			newValue = to;
			if (addToStack && !SerializationHelper.loadingSettings)
			{
				UINavigationManager.AddRevertableActionToStack(this);
			}
		}

		public void Revert()
		{
			setting.SetValue(previousValue);
		}

		public void ReDo()
		{
			setting.SetValue(newValue);
		}
	}
}

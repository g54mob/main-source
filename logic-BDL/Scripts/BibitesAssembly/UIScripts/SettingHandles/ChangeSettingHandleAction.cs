using ManagementScripts;
using SettingScripts;

namespace UIScripts.SettingHandles
{
	public class ChangeSettingHandleAction<TSetting, TType> : IRevertableAction where TSetting : Setting<TType>
	{
		private SettingHandle<TSetting, TType> handle;

		private TType previousValue;

		private TType newValue;

		public ChangeSettingHandleAction(SettingHandle<TSetting, TType> changedHandle, TType from, TType to, bool addToStack = true)
		{
			handle = changedHandle;
			previousValue = from;
			newValue = to;
		}

		public void Revert()
		{
			ChangeHandle(previousValue);
		}

		public void ReDo()
		{
			ChangeHandle(newValue);
		}

		private void ChangeHandle(TType value)
		{
			bool changeIsRevertable = handle.changeIsRevertable;
			handle.changeIsRevertable = false;
			handle.SetValue(value);
			handle.changeIsRevertable = changeIsRevertable;
		}
	}
}

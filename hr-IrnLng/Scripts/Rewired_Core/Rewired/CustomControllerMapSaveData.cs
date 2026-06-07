namespace Rewired
{
	public sealed class CustomControllerMapSaveData : ControllerMapSaveData
	{
		public CustomController customController
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return _controller as CustomController;
			}
		}

		public CustomControllerMap customControllerMap
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return _map as CustomControllerMap;
			}
		}

		public int customControllerSourceId
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1;
				}
				return customController.sourceControllerId;
			}
		}

		internal CustomControllerMapSaveData(CustomController customController, CustomControllerMap map)
			: base(customController, map)
		{
		}
	}
}

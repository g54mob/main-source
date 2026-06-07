namespace Rewired
{
	public struct InputActionSourceData
	{
		private Controller frSJxBhFNALntnzeNKOcTHuHKsS;

		private ControllerMap fcPcTXdclCfFXHGkwVhNNBHdQNBk;

		private ActionElementMap kQnXAZJcJBvkgdeNQHxbeWHoUQE;

		public Controller controller => frSJxBhFNALntnzeNKOcTHuHKsS;

		public ControllerType controllerType => frSJxBhFNALntnzeNKOcTHuHKsS.type;

		public ControllerMap controllerMap => fcPcTXdclCfFXHGkwVhNNBHdQNBk;

		public ActionElementMap actionElementMap => kQnXAZJcJBvkgdeNQHxbeWHoUQE;

		public string elementIdentifierName => kQnXAZJcJBvkgdeNQHxbeWHoUQE.elementIdentifierName;

		internal InputActionSourceData(Controller controller, ControllerMap controllerMap, ActionElementMap actionElementMap)
		{
			frSJxBhFNALntnzeNKOcTHuHKsS = controller;
			fcPcTXdclCfFXHGkwVhNNBHdQNBk = controllerMap;
			kQnXAZJcJBvkgdeNQHxbeWHoUQE = actionElementMap;
		}

		internal InputActionSourceData(PASInWXkNNmEwyEmMgFltCXsgqq working)
		{
			frSJxBhFNALntnzeNKOcTHuHKsS = working.FKtcxmBappHTSHGoccIYREwbpfog;
			fcPcTXdclCfFXHGkwVhNNBHdQNBk = working.nuUgjEKzUuMYBIiHUtitJvzUOOl;
			kQnXAZJcJBvkgdeNQHxbeWHoUQE = working.PgtyCGUpZbAlPcnBMkOdtmXxupEd;
		}
	}
}

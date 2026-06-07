public class CreationKeyListController : BaseController<CreationKeyListView, CreationModel>
{
	public CreationKeyListController(CreationKeyListView view, CreationModel model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		view.ClearAllKeyGroups();
		foreach (BlockModel item in model.GetAllBlockModel())
		{
			foreach (BlockBodyModel allBlockBodyModel in item.GetAllBlockBodyModels())
			{
				foreach (DefaultKeyIO allDefaultKeyIO in allBlockBodyModel.GetAllDefaultKeyIOs())
				{
					if (allDefaultKeyIO.Direction != DefaultKeyIODirection.Output && !allDefaultKeyIO.IsInputWithoutKey)
					{
						view.AddNewKey(allDefaultKeyIO);
					}
				}
			}
		}
		foreach (LogicKeyData allKeysFromInstruction in model.LogicSystemModel.GetAllKeysFromInstructions())
		{
			view.AddNewLogicKey(allKeysFromInstruction);
		}
		string[] allKeysGroupLabelKeys = model.GetAllKeysGroupLabelKeys();
		foreach (string keyId in allKeysGroupLabelKeys)
		{
			string keysGroupLabel = model.GetKeysGroupLabel(keyId);
			view.UpdateKeyGroupLabel(keyId, keysGroupLabel);
		}
		view.SetKeyListCompactStatus(view.GetKeyListCompactToggleValue());
		view.UpdateWindowStatus();
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "CreationKeyListView.MouseOverUIEvent")
		{
			bool flag = (bool)data[0];
			bool flag2 = (bool)data[1];
			GameManager.Instance.CameraManager.OrbitCamera.SetZoomActive(!(flag && flag2));
		}
	}
}

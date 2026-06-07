using System.Collections;
using UnityEngine;

public class QuickKeysController : BaseController<QuickKeysView, CreationModel>
{
	public bool IsKeyboardInUse { get; private set; }

	public QuickKeysController(QuickKeysView view, CreationModel model)
		: base(view, model, false)
	{
		GameManager.Instance.MainCreationsManager.AttackerCreationController.OnModelChanged += delegate(CreationModel newModel, CreationModel lastModel)
		{
			SetModel(newModel);
		};
		IsKeyboardInUse = false;
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
						view.AddNewKeySlot(allDefaultKeyIO);
					}
				}
			}
		}
		UpdateKeysGroupLabels();
		view.UpdateWindowStatus();
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "CreationModel.ChangedBlocksCountEvent":
		case "CreationModel.AddMotorJointEvent":
		case "CreationModel.AddSteerableJointEvent":
		case "CreationModel.AddStepperJointEvent":
		case "CreationModel.RemoveHingeJointEvent":
		case "CreationModel.RemoveSpecializedJointsEvent":
			view.RefreshKeySlots(model.GetAllDefaultKeyIOs());
			view.UpdateWindowStatus();
			break;
		case "CreationModel.UpdateDefaultKeyEvent":
		{
			DefaultKeyIO defaultKeyIO = data[0] as DefaultKeyIO;
			view.UpdateKeySlot(defaultKeyIO);
			break;
		}
		case "CreationModel.UpdateMotorJointEvent":
		{
			HingeJointModel hingeJointModel = data[0] as HingeJointModel;
			view.UpdateKeySlot(hingeJointModel.MotorJointModel.DefaultForward);
			view.UpdateKeySlot(hingeJointModel.MotorJointModel.DefaultBackward);
			view.UpdateKeySlot(hingeJointModel.MotorJointModel.DefaultBrake);
			break;
		}
		case "CreationModel.UpdateSteerableJointEvent":
		{
			HingeJointModel hingeJointModel = data[0] as HingeJointModel;
			view.UpdateKeySlot(hingeJointModel.SteerableJointModel.DefaultForward);
			view.UpdateKeySlot(hingeJointModel.SteerableJointModel.DefaultBackward);
			break;
		}
		case "CreationModel.UpdateStepperJointEvent":
		{
			HingeJointModel hingeJointModel = data[0] as HingeJointModel;
			view.UpdateKeySlot(hingeJointModel.StepperJointModel.DefaultForward);
			view.UpdateKeySlot(hingeJointModel.StepperJointModel.DefaultBackward);
			break;
		}
		case "CreationModel.UpdateDefaultKeysControlledByLogicEvent":
			view.RefreshKeysControlledByLogicIcons();
			break;
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "QuickKeysView.KeyAssignedEvent":
		{
			int blockId = (int)data[0];
			int bodyIndex = (int)data[1];
			string keyName = (string)data[2];
			KeyCode keyValue = (KeyCode)data[3];
			AxisCode axisValue = (AxisCode)data[4];
			model.UpdateDefaultKey(blockId, bodyIndex, keyName, keyValue, axisValue);
			break;
		}
		case "QuickKeysView.KeysGroupLabelErasedEvent":
		{
			string keyId = (string)data[0];
			model.RemoveKeysGroupLabel(keyId);
			break;
		}
		case "QuickKeysView.KeysGroupLabelChangedEvent":
		{
			string keyId = (string)data[0];
			string text = (string)data[1];
			if (!string.IsNullOrEmpty(text))
			{
				model.AddKeysGroupLabel(keyId, text);
			}
			break;
		}
		case "QuickKeysView.KeysGroupLabelRefreshEvent":
			UpdateKeysGroupLabels();
			break;
		case "QuickKeysView.IsKeyboardInUsingEvent":
			if ((bool)data[0])
			{
				IsKeyboardInUse = true;
				GameManager.Instance.CameraManager.OrbitCamera.SetKeyboardTranslationActive(value: false);
				GameManager.Instance.CameraManager.OrbitCamera.SetKeyboardVerticalTranslationActive(isActive: false);
			}
			else
			{
				GameManager.Instance.StartCoroutine(SetDelayedKeyEndingAssignment());
			}
			break;
		case "QuickKeysView.CloseButtonEvent":
			view.SetVisibility(isVisible: false);
			view.ConstructionToolsView.SetQuickKeysToggleStatus(isSelected: false);
			break;
		case "QuickKeysView.MouseOverUIEvent":
		{
			bool flag = (bool)data[0];
			bool flag2 = (bool)data[1];
			GameManager.Instance.CameraManager.OrbitCamera.SetZoomActive(!(flag && flag2));
			break;
		}
		}
	}

	private void UpdateKeysGroupLabels()
	{
		string[] allKeysGroupLabelKeys = model.GetAllKeysGroupLabelKeys();
		foreach (string keyId in allKeysGroupLabelKeys)
		{
			string keysGroupLabel = model.GetKeysGroupLabel(keyId);
			view.UpdateQuickKeysGroupLabel(keyId, keysGroupLabel);
		}
	}

	private IEnumerator SetDelayedKeyEndingAssignment()
	{
		yield return new WaitForEndOfFrame();
		IsKeyboardInUse = false;
		yield return new WaitForSeconds(0.5f);
		GameManager.Instance.CameraManager.OrbitCamera.SetKeyboardTranslationActive(value: true);
		GameManager.Instance.CameraManager.OrbitCamera.SetKeyboardVerticalTranslationActive(isActive: true);
	}
}

using UnityEngine;

public class ComponentPropertiesController : BaseController<ComponentPropertiesView>
{
	public bool IsKeyboardInUse { get; private set; }

	public ComponentPropertiesController(ComponentPropertiesView view)
		: base(view)
	{
		IsKeyboardInUse = false;
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "ComponentPropertiesView.ChangeComponentKeyEvent":
		{
			int blockId = (int)data[0];
			int bodyIndex = (int)data[1];
			string keyName = (string)data[2];
			KeyCode keyValue = (KeyCode)data[3];
			AxisCode axisValue = (AxisCode)data[4];
			GameManager.Instance.MainCreationController.model.UpdateDefaultKey(blockId, bodyIndex, keyName, keyValue, axisValue);
			break;
		}
		case "ComponentPropertiesView.ChangeOverridablePropertyEvent":
		{
			OverridablePropertyModel property = data[0] as OverridablePropertyModel;
			string newValue = (string)data[1];
			GameManager.Instance.MainCreationController.model.UpdateOverriblaProperty(property, newValue);
			break;
		}
		case "ComponentPropertiesView.IsKeyboardInUsingEvent":
			IsKeyboardInUse = (bool)data[0];
			GameManager.Instance.CameraManager.OrbitCamera.SetKeyboardTranslationActive(!IsKeyboardInUse);
			GameManager.Instance.CameraManager.OrbitCamera.SetKeyboardVerticalTranslationActive(!IsKeyboardInUse);
			break;
		case "ComponentPropertiesView.IsMouseOverScrollEvent":
		{
			bool flag = (bool)data[0];
			GameManager.Instance.CameraManager.OrbitCamera.SetZoomActive(!flag);
			break;
		}
		case "ComponentPropertiesView.CloseWindowEvent":
			ComponentPropertiesState.Instance.UnSelectButton3D();
			break;
		}
	}
}

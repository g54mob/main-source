using System;
using UnityEngine;

public class HingeEditorDragAndDropEvents
{
	private MouseDragAndDropEvents mouseDragAndDropEvents;

	private LineComponent lineComponent;

	private Button3D firstButton3D;

	private Button3D secondButton3D;

	private Button3D lastSecondButton3D;

	public event Action<HingeJointModel, BlockBodyModel> OnCanConnectMotorToHingeJoint;

	public event Action<HingeJointModel> OnDisconnectHingeJointFromMotor;

	public event Func<bool> OnOverRestrictedZone;

	public HingeEditorDragAndDropEvents(GameManager GAME)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(GAME.hingeEditorLinePrefab);
		lineComponent = gameObject.GetComponent<LineComponent>();
		lineComponent.Initialize(GAME.effectsFolder.transform, GAME.CameraManager.OrbitCamera.transform.GetChild(0).transform);
		lineComponent.SetVisibility(isVisible: false);
		mouseDragAndDropEvents = new MouseDragAndDropEvents(LayerNames.Button3DMask);
		mouseDragAndDropEvents.OnMouseStartDrag += MouseStartDragHandler;
		mouseDragAndDropEvents.OnMouseDragging += MouseDraggingHandler;
		mouseDragAndDropEvents.OnMouseEndDrop += MouseEndDropHandler;
		mouseDragAndDropEvents.OnMouseValidDrop += MouseValidDropHandler;
		mouseDragAndDropEvents.OnOverRestrictedZone += MouseOverRestrictedZoneHandler;
	}

	public bool Run()
	{
		return mouseDragAndDropEvents.Run();
	}

	public void Stop()
	{
		mouseDragAndDropEvents.Stop();
	}

	private void MouseStartDragHandler(GameObject firstGameObject, Vector3 lineStartPoint)
	{
		firstButton3D = firstGameObject.GetComponent<Button3D>();
		firstButton3D.SetHighlightedColor();
		if (firstButton3D is HingeJointButton3D)
		{
			HingeJointButton3D hingeJointButton3D = firstButton3D as HingeJointButton3D;
			if (hingeJointButton3D.HingeJointModel.MotorBlockBodyModel != null && this.OnDisconnectHingeJointFromMotor != null)
			{
				this.OnDisconnectHingeJointFromMotor(hingeJointButton3D.HingeJointModel);
			}
		}
		lineComponent.SetVisibility(isVisible: true);
	}

	private void MouseDraggingHandler(GameObject firstGameObject, GameObject secondGameObject, Vector3 lineStartPoint, Vector3 lineCurrentPoint)
	{
		Vector3 position = firstGameObject.transform.position;
		Vector3 vector = lineCurrentPoint;
		if (secondGameObject != null)
		{
			secondButton3D = secondGameObject.GetComponent<Button3D>();
			if (secondButton3D != lastSecondButton3D && lastSecondButton3D != null)
			{
				lastSecondButton3D.SetOriginalColor();
			}
			if (CanConnectHingeJointToMotor(firstButton3D, secondButton3D))
			{
				secondButton3D.SetHighlightedColor();
				vector = secondGameObject.transform.position;
				lastSecondButton3D = secondButton3D;
			}
		}
		else if (secondButton3D != null)
		{
			secondButton3D.SetOriginalColor();
		}
		if (firstButton3D is HingeJointButton3D)
		{
			lineComponent.SetPositions(position, vector);
		}
		else
		{
			lineComponent.SetPositions(vector, position);
		}
	}

	private void MouseValidDropHandler(GameObject firstGameObject, GameObject secondGameObject)
	{
		firstButton3D = firstGameObject.GetComponent<Button3D>();
		secondButton3D = secondGameObject.GetComponent<Button3D>();
		CanConnectHingeJointToMotor(firstButton3D, secondButton3D, delegate(HingeJointButton3D hingeJointButton3D, BlockBodyModelButton3D blockBodyModelButton3D)
		{
			if (this.OnCanConnectMotorToHingeJoint != null)
			{
				this.OnCanConnectMotorToHingeJoint(hingeJointButton3D.HingeJointModel, blockBodyModelButton3D.BlockBodyModel);
			}
		});
	}

	private void MouseEndDropHandler()
	{
		if (firstButton3D != null)
		{
			firstButton3D.SetOriginalColor();
		}
		if (secondButton3D != null)
		{
			secondButton3D.SetOriginalColor();
		}
		firstButton3D = null;
		secondButton3D = null;
		lineComponent.SetVisibility(isVisible: false);
	}

	private bool MouseOverRestrictedZoneHandler()
	{
		if (this.OnOverRestrictedZone != null)
		{
			return this.OnOverRestrictedZone();
		}
		return false;
	}

	private bool CanConnectHingeJointToMotor(Button3D firstButton3D, Button3D secondButton3D, Action<HingeJointButton3D, BlockBodyModelButton3D> actionToExecuteWhenTrue = null)
	{
		if (firstButton3D.Id != secondButton3D.Id)
		{
			HingeJointButton3D hingeJointButton3D = GetHingeJointButton3D(firstButton3D, secondButton3D);
			BlockBodyModelButton3D blockBodyModelButton3D = GetBlockBodyModelButton3D(firstButton3D, secondButton3D);
			if (hingeJointButton3D != null && blockBodyModelButton3D != null && hingeJointButton3D.HingeJointModel.MotorBlockBodyModel == null)
			{
				ComponentModel componentModel = blockBodyModelButton3D.BlockBodyModel.GetComponentModel(ComponentType.Motor);
				if (componentModel != null)
				{
					int num = (componentModel.InternalProperties[MotorModel.Name] as MotorModel).HingeJointsCount();
					int propertyAsInt = componentModel.Properties.GetPropertyAsInt("maxJoints");
					if (num < propertyAsInt)
					{
						actionToExecuteWhenTrue?.Invoke(hingeJointButton3D, blockBodyModelButton3D);
						return true;
					}
				}
			}
		}
		return false;
	}

	private HingeJointButton3D GetHingeJointButton3D(Button3D firstButton3D, Button3D secondButton3D)
	{
		if (firstButton3D is HingeJointButton3D)
		{
			return firstButton3D as HingeJointButton3D;
		}
		if (secondButton3D is HingeJointButton3D)
		{
			return secondButton3D as HingeJointButton3D;
		}
		return null;
	}

	private BlockBodyModelButton3D GetBlockBodyModelButton3D(Button3D firstButton3D, Button3D secondButton3D)
	{
		if (firstButton3D is BlockBodyModelButton3D)
		{
			return firstButton3D as BlockBodyModelButton3D;
		}
		if (secondButton3D is BlockBodyModelButton3D)
		{
			return secondButton3D as BlockBodyModelButton3D;
		}
		return null;
	}
}

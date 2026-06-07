using System;
using UnityEngine;

public class BlockVisualizationMouseOverEvents
{
	private MouseOverObjectEvents mouseOverBlock;

	private MouseOverObjectEvents mouseOverConnector;

	private GameObject currentBlockBodyObject;

	public event Action<GameObject> OnMouseEnterBlockBodyObject;

	public event Action<GameObject> OnMouseOverBlockBodyObject;

	public event Action<GameObject> OnMouseExitBlockBodyObject;

	public event Action<GameObject, Vector3, Quaternion, Vector3> OnMouseEnterConnector;

	public event Action<GameObject, Vector3, Quaternion, Vector3> OnMouseOverConnector;

	public event Action OnMouseExitConnector;

	public BlockVisualizationMouseOverEvents(Camera camera)
	{
		mouseOverBlock = new MouseOverObjectEvents(LayerNames.BlockVisualizationMask, "BlockModel")
		{
			Camera = camera
		};
		mouseOverConnector = new MouseOverObjectEvents(LayerNames.ConnectorMask, "Connector")
		{
			Camera = camera
		};
		mouseOverBlock.OnMouseEnterObject += MouseEnterBlockBodyHandler;
		mouseOverBlock.OnMouseOverObject += MouseOverBlockBodyHandler;
		mouseOverBlock.OnMouseExitObject += MouseExitBlockBodyHandler;
		mouseOverConnector.OnMouseEnterObject += MouseEnterConnectorHandler;
		mouseOverConnector.OnMouseOverObject += MouseOverConnectorHandler;
		mouseOverConnector.OnMouseExitObject += MouseExitConnectorHandler;
	}

	public void Run()
	{
		mouseOverBlock.Run();
	}

	public void Stop()
	{
		mouseOverConnector.Stop();
		mouseOverBlock.Stop();
	}

	private void MouseEnterBlockBodyHandler(RaycastHit objectRaycastHit)
	{
		currentBlockBodyObject = objectRaycastHit.collider.gameObject;
		this.OnMouseEnterBlockBodyObject?.Invoke(currentBlockBodyObject);
	}

	private void MouseOverBlockBodyHandler(RaycastHit objectRaycastHit)
	{
		mouseOverConnector.Run();
		this.OnMouseOverBlockBodyObject?.Invoke(objectRaycastHit.collider.gameObject);
	}

	private void MouseExitBlockBodyHandler(GameObject blockBodyObject)
	{
		this.OnMouseExitBlockBodyObject?.Invoke(blockBodyObject);
		mouseOverConnector.Stop();
	}

	private void MouseEnterConnectorHandler(RaycastHit objectRaycastHit)
	{
		GameObject gameObject = objectRaycastHit.collider.gameObject;
		Vector3 position = gameObject.transform.position;
		Quaternion rotation = gameObject.transform.rotation;
		this.OnMouseEnterConnector?.Invoke(currentBlockBodyObject, position, rotation, objectRaycastHit.normal);
	}

	private void MouseOverConnectorHandler(RaycastHit objectRaycastHit)
	{
		GameObject gameObject = objectRaycastHit.collider.gameObject;
		Vector3 position = gameObject.transform.position;
		Quaternion rotation = gameObject.transform.rotation;
		this.OnMouseOverConnector?.Invoke(currentBlockBodyObject, position, rotation, objectRaycastHit.normal);
	}

	private void MouseExitConnectorHandler(GameObject connectorObject)
	{
		this.OnMouseExitConnector?.Invoke();
	}
}

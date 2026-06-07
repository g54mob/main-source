using System;
using UnityEngine;

public class ConstructionMouseOverEvents
{
	private MouseOverObjectEvents mouseOverLevel;

	private MouseOverObjectEvents mouseOverBlock;

	private MouseOverObjectEvents mouseOverConnector;

	private GameObject currentBlockBodyObject;

	private bool skipFrameWhenBlockChanged;

	public event Action<GameObject, Vector3, Vector3> OnMouseEnterLevelObject;

	public event Action<GameObject, Vector3, Vector3> OnMouseOverLevelObject;

	public event Action<GameObject> OnMouseExitLevelObject;

	public event Func<bool> OnOverRestrictedZoneForLevel;

	public event Action<GameObject> OnMouseEnterBlockBodyObject;

	public event Action<GameObject> OnMouseOverBlockBodyObject;

	public event Action<GameObject> OnMouseExitBlockBodyObject;

	public event Func<bool> OnOverRestrictedZoneForBlock;

	public event Action<GameObject, Vector3, Quaternion, Vector3> OnMouseEnterConnector;

	public event Action<GameObject, Vector3, Quaternion, Vector3> OnMouseOverConnector;

	public event Action OnMouseExitConnector;

	public ConstructionMouseOverEvents()
	{
		mouseOverLevel = new MouseOverObjectEvents(LayerNames.LevelMask | LayerNames.BlockMask, "Level");
		mouseOverBlock = new MouseOverObjectEvents(LayerNames.BlockMask, "Block");
		mouseOverConnector = new MouseOverObjectEvents(LayerNames.ConnectorMask | LayerNames.BlockMask, "Connector");
		mouseOverLevel.OnMouseEnterObject += MouseEnterLevelHandler;
		mouseOverLevel.OnMouseOverObject += MouseOverLevelHandler;
		mouseOverLevel.OnMouseExitObject += MouseExitLevelHandler;
		mouseOverLevel.OnOverRestrictedZone += MouseOverRestrictedZoneForLevelHandler;
		mouseOverBlock.OnMouseEnterObject += MouseEnterBlockBodyHandler;
		mouseOverBlock.OnMouseOverObject += MouseOverBlockBodyHandler;
		mouseOverBlock.OnMouseExitObject += MouseExitBlockBodyHandler;
		mouseOverBlock.OnOverRestrictedZone += MouseOverRestrictedZoneForBlockHandler;
		mouseOverConnector.OnMouseEnterObject += MouseEnterConnectorHandler;
		mouseOverConnector.OnMouseOverObject += MouseOverConnectorHandler;
		mouseOverConnector.OnMouseExitObject += MouseExitConnectorHandler;
		skipFrameWhenBlockChanged = false;
	}

	public void Run()
	{
		mouseOverBlock.Run();
		mouseOverLevel.Run();
	}

	public void Stop()
	{
		mouseOverConnector.Stop();
		mouseOverBlock.Stop();
		mouseOverLevel.Stop();
	}

	private void MouseEnterLevelHandler(RaycastHit objectRaycastHit)
	{
		this.OnMouseEnterLevelObject?.Invoke(objectRaycastHit.collider.gameObject, objectRaycastHit.point, objectRaycastHit.normal);
	}

	private void MouseOverLevelHandler(RaycastHit objectRaycastHit)
	{
		this.OnMouseOverLevelObject?.Invoke(objectRaycastHit.collider.gameObject, objectRaycastHit.point, objectRaycastHit.normal);
	}

	private void MouseExitLevelHandler(GameObject levelObject)
	{
		this.OnMouseExitLevelObject?.Invoke(levelObject);
	}

	private bool MouseOverRestrictedZoneForLevelHandler()
	{
		if (this.OnOverRestrictedZoneForLevel != null)
		{
			return this.OnOverRestrictedZoneForLevel();
		}
		return false;
	}

	private void MouseEnterBlockBodyHandler(RaycastHit objectRaycastHit)
	{
		currentBlockBodyObject = objectRaycastHit.collider.gameObject;
		this.OnMouseEnterBlockBodyObject?.Invoke(currentBlockBodyObject);
		skipFrameWhenBlockChanged = true;
	}

	private void MouseOverBlockBodyHandler(RaycastHit objectRaycastHit)
	{
		if (!skipFrameWhenBlockChanged)
		{
			mouseOverConnector.Run();
		}
		else
		{
			mouseOverConnector.Stop();
		}
		skipFrameWhenBlockChanged = false;
		this.OnMouseOverBlockBodyObject?.Invoke(objectRaycastHit.collider.gameObject);
	}

	private void MouseExitBlockBodyHandler(GameObject blockBodyObject)
	{
		this.OnMouseExitBlockBodyObject?.Invoke(blockBodyObject);
		mouseOverConnector.Stop();
	}

	private bool MouseOverRestrictedZoneForBlockHandler()
	{
		if (this.OnOverRestrictedZoneForBlock != null)
		{
			return this.OnOverRestrictedZoneForBlock();
		}
		return false;
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

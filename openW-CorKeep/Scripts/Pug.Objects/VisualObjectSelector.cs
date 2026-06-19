using System.Collections.Generic;
using Pug.Sprite;
using UnityEngine;

public class VisualObjectSelector : MonoBehaviour
{
	private struct DisplayedObject
	{
		public GameObject GameObject;

		public PoolableSimple PoolableComponent;

		public IFlyingVisual FlyingVisual;

		public EntityMonoBehaviour EntityMonoBehaviour;

		public List<SpriteObject> SpriteObjects;
	}

	private ObjectID _displayedObjectID;

	private int _displayedVariation;

	private DisplayedObject _displayedObject;

	private List<IEntityMonoBehaviourDataPreview> _cachedPreviewList = new List<IEntityMonoBehaviourDataPreview>();

	public void DisplayObject(ObjectInfo objectInfo)
	{
		if (objectInfo.prefabInfos.Count == 0)
		{
			return;
		}
		ObjectID objectID = objectInfo.objectID;
		int variation = objectInfo.variation;
		if (objectID == _displayedObjectID && variation == _displayedVariation)
		{
			return;
		}
		HideObject();
		_displayedObject.GameObject = Manager.memory.GetFreeComponent(objectInfo.prefabInfos[0].prefab.GetType(), deferOnOccupied: true, deferReparent: true).gameObject;
		EntityMonoBehaviour component = _displayedObject.GameObject.GetComponent<EntityMonoBehaviour>();
		_displayedObject.PoolableComponent = _displayedObject.GameObject.GetComponent<PoolableSimple>();
		_displayedObject.SpriteObjects = component.spriteObjects;
		_displayedObject.FlyingVisual = component as IFlyingVisual;
		_displayedObject.EntityMonoBehaviour = component;
		component.ResetVisuals();
		Transform obj = _displayedObject.GameObject.transform;
		obj.parent = base.transform;
		obj.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
		_displayedObject.GameObject.GetComponents(_cachedPreviewList);
		_displayedObjectID = objectID;
		_displayedVariation = variation;
		foreach (IEntityMonoBehaviourDataPreview cachedPreview in _cachedPreviewList)
		{
			cachedPreview.UpdateGraphicsFromObjectInfo(objectInfo);
		}
	}

	public void HideObject()
	{
		if (_displayedObjectID != ObjectID.None)
		{
			_displayedObjectID = ObjectID.None;
			_displayedVariation = 0;
			_displayedObject.PoolableComponent.Free();
			_displayedObject = default(DisplayedObject);
			_cachedPreviewList.Clear();
		}
	}

	public void PlayAnimation(int animationID, int orientationHash)
	{
		if (_displayedObject.SpriteObjects == null)
		{
			return;
		}
		foreach (SpriteObject spriteObject in _displayedObject.SpriteObjects)
		{
			if (spriteObject.HasAnimation(animationID))
			{
				spriteObject.PlayAnimation(animationID);
			}
			spriteObject.SetVariant(orientationHash);
		}
	}

	public void SetFlipped(bool flipX)
	{
		if (!(_displayedObject.EntityMonoBehaviour?.XScaler == null))
		{
			_displayedObject.EntityMonoBehaviour.XScaler.localScale = new Vector3((!flipX) ? 1 : (-1), 1f, 1f);
		}
	}

	public void DisplayOnGround(bool displayOnGround)
	{
		_displayedObject.FlyingVisual?.DisplayOnGround(displayOnGround);
	}
}

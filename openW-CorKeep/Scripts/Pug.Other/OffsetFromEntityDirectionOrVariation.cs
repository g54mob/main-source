using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Pug.ECS.Hybrid;
using Pug.UnityExtensions;
using Unity.Entities;
using UnityEngine;

public class OffsetFromEntityDirectionOrVariation : MonoBehaviour, IGraphicalSpawn, ISerializationCallbackReceiver
{
	public enum DirectionSetting
	{
		None = 0,
		Up = 1,
		Right = 2,
		Down = 3,
		Left = 4
	}

	public enum VariationSetting
	{
		Zero = 0,
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4
	}

	public enum OffsetType
	{
		Direction = 0,
		Variation = 1
	}

	[Serializable]
	public class GameObjectOffset
	{
		public Vector3 localPosition;

		public Quaternion localRotation;

		public bool active;

		public GameObjectOffset(Vector3 localPosition, Quaternion localRotation, bool active)
		{
			this.localPosition = localPosition;
			this.localRotation = localRotation;
			this.active = active;
		}
	}

	[Serializable]
	public class ObjectOffset
	{
		public GameObject gameObject;

		[SerializeField]
		[HideInInspector]
		public GameObject prevGameObject;

		[SerializeField]
		[HideInInspector]
		public GameObjectOffset midOffset;

		[SerializeField]
		[HideInInspector]
		public GameObjectOffset downOffset;

		[SerializeField]
		[HideInInspector]
		public GameObjectOffset upOffset;

		[SerializeField]
		[HideInInspector]
		public GameObjectOffset rightOffset;

		[SerializeField]
		[HideInInspector]
		public GameObjectOffset leftOffset;

		public void UpdateOffset(int variation, bool shareDownOffsetWithUpOffset, bool shareRightOffsetWithLeftOffset, bool isDirectionType)
		{
			if (!isDirectionType)
			{
				variation--;
			}
			GameObjectOffset offset = variation switch
			{
				-1 => midOffset, 
				0 => shareDownOffsetWithUpOffset ? downOffset : upOffset, 
				1 => rightOffset, 
				2 => downOffset, 
				3 => shareRightOffsetWithLeftOffset ? rightOffset : leftOffset, 
				_ => downOffset, 
			};
			UpdatePositionAndRotation(gameObject, offset);
		}
	}

	public OffsetType offsetType;

	[ShowIf("offsetType", OffsetType.Direction)]
	[AllowNesting]
	public DirectionSetting directionToEdit;

	[ShowIf("offsetType", OffsetType.Variation)]
	[AllowNesting]
	public VariationSetting variationToEdit;

	[ShowIf("offsetType", OffsetType.Direction)]
	public bool shareDownOffsetWithUpOffset;

	[ShowIf("offsetType", OffsetType.Direction)]
	public bool shareRightOffsetWithLeftOffset;

	[SerializeField]
	[HideInInspector]
	public int prevValueToEdit;

	public List<ObjectOffset> objectsToOffset;

	public void Spawn(Entity entity, EntityManager entityManager)
	{
		if (objectsToOffset.Count == 0)
		{
			return;
		}
		int variation = 0;
		bool isDirectionType = false;
		if (entityManager.HasComponent<DirectionCD>(entity))
		{
			variation = DirectionBasedOnVariationCD.GetVariationFromDirection(entityManager.GetComponentData<DirectionCD>(entity).direction.RoundToInt2());
			isDirectionType = true;
		}
		else if (entityManager.HasComponent<ObjectDataCD>(entity))
		{
			variation = entityManager.GetComponentData<ObjectDataCD>(entity).variation;
		}
		else
		{
			Debug.LogError($"{base.name} has {typeof(OffsetFromEntityDirectionOrVariation)}, but the entity has no {typeof(DirectionCD)} or {typeof(ObjectDataCD)}.");
		}
		foreach (ObjectOffset item in objectsToOffset)
		{
			item.UpdateOffset(variation, shareDownOffsetWithUpOffset, shareRightOffsetWithLeftOffset, isDirectionType);
		}
	}

	public void OnBeforeSerialize()
	{
		if (objectsToOffset == null)
		{
			return;
		}
		foreach (ObjectOffset item in objectsToOffset)
		{
			if (item.gameObject == null)
			{
				item.prevGameObject = null;
			}
			else if (item.gameObject != item.prevGameObject)
			{
				item.prevGameObject = item.gameObject;
				ApplyObject(item, applyAll: true);
			}
		}
		UpdatePreview();
	}

	public void SetPreview(int newValue)
	{
		if (offsetType == OffsetType.Direction)
		{
			directionToEdit = (DirectionSetting)newValue;
		}
		else
		{
			variationToEdit = (VariationSetting)newValue;
		}
		UpdatePreview();
	}

	private void UpdatePreview()
	{
		if (objectsToOffset == null)
		{
			return;
		}
		bool flag = offsetType == OffsetType.Direction;
		if ((!flag || prevValueToEdit == (int)directionToEdit) && (flag || prevValueToEdit == (int)variationToEdit))
		{
			return;
		}
		prevValueToEdit = (flag ? ((int)directionToEdit) : ((int)variationToEdit));
		foreach (ObjectOffset item in objectsToOffset)
		{
			GameObject gameObject = item.gameObject;
			if ((flag && directionToEdit == DirectionSetting.None) || (!flag && variationToEdit == VariationSetting.Zero))
			{
				UpdatePositionAndRotation(gameObject, item.midOffset);
			}
			else if ((flag && directionToEdit == DirectionSetting.Up) || (!flag && variationToEdit == VariationSetting.One))
			{
				UpdatePositionAndRotation(gameObject, (flag && shareDownOffsetWithUpOffset) ? item.downOffset : item.upOffset);
			}
			else if ((flag && directionToEdit == DirectionSetting.Right) || (!flag && variationToEdit == VariationSetting.Two))
			{
				UpdatePositionAndRotation(gameObject, item.rightOffset);
			}
			else if ((flag && directionToEdit == DirectionSetting.Down) || (!flag && variationToEdit == VariationSetting.Three))
			{
				UpdatePositionAndRotation(gameObject, item.downOffset);
			}
			else if ((flag && directionToEdit == DirectionSetting.Left) || (!flag && variationToEdit == VariationSetting.Four))
			{
				UpdatePositionAndRotation(gameObject, (flag && shareRightOffsetWithLeftOffset) ? item.rightOffset : item.leftOffset);
			}
			if (flag)
			{
				SpriteVariationFromEntityDirection component = GetComponent<SpriteVariationFromEntityDirection>();
				if (component != null)
				{
					component.SetDirection(DirectionBasedOnVariationCD.GetDirectionFromVariation(prevValueToEdit - 1));
				}
			}
			else
			{
				SpriteVariationFromEntityVariation component2 = GetComponent<SpriteVariationFromEntityVariation>();
				if (component2 != null)
				{
					component2.SetVariation(prevValueToEdit);
				}
			}
		}
	}

	public void Apply()
	{
		foreach (ObjectOffset item in objectsToOffset)
		{
			ApplyObject(item);
		}
	}

	public void ApplyObject(ObjectOffset objectToOffset, bool applyAll = false)
	{
		Transform transform = objectToOffset.gameObject.transform;
		GameObjectOffset gameObjectOffset = new GameObjectOffset(transform.localPosition, transform.localRotation, objectToOffset.gameObject.activeSelf);
		if (offsetType == OffsetType.Direction)
		{
			if (directionToEdit == DirectionSetting.None || applyAll)
			{
				objectToOffset.midOffset = gameObjectOffset;
			}
			if ((shareDownOffsetWithUpOffset && directionToEdit == DirectionSetting.Up) || directionToEdit == DirectionSetting.Down || applyAll)
			{
				objectToOffset.downOffset = gameObjectOffset;
			}
			if ((shareDownOffsetWithUpOffset && directionToEdit == DirectionSetting.Down) || directionToEdit == DirectionSetting.Up || applyAll)
			{
				objectToOffset.upOffset = gameObjectOffset;
			}
			if ((shareRightOffsetWithLeftOffset && directionToEdit == DirectionSetting.Left) || directionToEdit == DirectionSetting.Right || applyAll)
			{
				objectToOffset.rightOffset = gameObjectOffset;
			}
			if ((shareRightOffsetWithLeftOffset && directionToEdit == DirectionSetting.Right) || directionToEdit == DirectionSetting.Left || applyAll)
			{
				objectToOffset.leftOffset = gameObjectOffset;
			}
		}
		else
		{
			if (variationToEdit == VariationSetting.Zero || applyAll)
			{
				objectToOffset.midOffset = gameObjectOffset;
			}
			if (variationToEdit == VariationSetting.One || applyAll)
			{
				objectToOffset.upOffset = gameObjectOffset;
			}
			if (variationToEdit == VariationSetting.Two || applyAll)
			{
				objectToOffset.rightOffset = gameObjectOffset;
			}
			if (variationToEdit == VariationSetting.Three || applyAll)
			{
				objectToOffset.downOffset = gameObjectOffset;
			}
			if (variationToEdit == VariationSetting.Four || applyAll)
			{
				objectToOffset.leftOffset = gameObjectOffset;
			}
		}
	}

	public bool HasAnyChanges()
	{
		if (objectsToOffset == null)
		{
			return false;
		}
		foreach (ObjectOffset item in objectsToOffset)
		{
			if (item.gameObject == null)
			{
				continue;
			}
			GameObject gameObject = item.gameObject;
			if (offsetType == OffsetType.Direction)
			{
				if ((directionToEdit == DirectionSetting.None && IsDifferent(gameObject, item.midOffset)) || (directionToEdit == DirectionSetting.Down && (IsDifferent(gameObject, item.downOffset) || (shareDownOffsetWithUpOffset && IsDifferent(gameObject, item.upOffset)))) || (directionToEdit == DirectionSetting.Up && (IsDifferent(gameObject, item.upOffset) || (shareDownOffsetWithUpOffset && IsDifferent(gameObject, item.downOffset)))) || (directionToEdit == DirectionSetting.Right && (IsDifferent(gameObject, item.rightOffset) || (shareRightOffsetWithLeftOffset && IsDifferent(gameObject, item.leftOffset)))) || (directionToEdit == DirectionSetting.Left && (IsDifferent(gameObject, item.leftOffset) || (shareRightOffsetWithLeftOffset && IsDifferent(gameObject, item.rightOffset)))))
				{
					return true;
				}
			}
			else if ((variationToEdit == VariationSetting.Zero && IsDifferent(gameObject, item.midOffset)) || (variationToEdit == VariationSetting.One && IsDifferent(gameObject, item.upOffset)) || (variationToEdit == VariationSetting.Two && IsDifferent(gameObject, item.rightOffset)) || (variationToEdit == VariationSetting.Three && IsDifferent(gameObject, item.downOffset)) || (variationToEdit == VariationSetting.Four && IsDifferent(gameObject, item.leftOffset)))
			{
				return true;
			}
		}
		return false;
	}

	public void OnAfterDeserialize()
	{
	}

	public static void UpdatePositionAndRotation(GameObject gameObject, GameObjectOffset offset)
	{
		gameObject.transform.localPosition = offset.localPosition;
		gameObject.transform.localRotation = offset.localRotation;
		gameObject.SetActive(offset.active);
	}

	public bool IsDifferent(GameObject gameObject, GameObjectOffset offset)
	{
		if (gameObject.activeSelf == offset.active && !((gameObject.transform.localPosition - offset.localPosition).magnitude > Mathf.Epsilon))
		{
			return gameObject.transform.localRotation != offset.localRotation;
		}
		return true;
	}
}

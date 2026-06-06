using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacedObject : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	private ObjectSO objectSO;

	private Vector2Int size;

	private Vector3Int cellPosition;

	private GridPlacementManager.Dir dir;

	private Transform placedObjectTransform;

	private bool hasVariant;

	private int variantIndex;

	private Transform potVisual;

	private int score;

	private int ID;

	private Tweener tweener;

	public static PlacedObject Create(Vector3 worldPosition, Vector3Int cellPosition, GridPlacementManager.Dir dir, ObjectSO objectSO, Transform prefab, Vector2Int size, bool hasVariant, int variantIndex, Transform potVisual, int score, int ID)
	{
		Transform transform = Object.Instantiate(prefab, worldPosition, Quaternion.Euler(0f, GridPlacementManager.Instance.GetRotationAngle(dir), 0f));
		PlacedObject component = transform.GetComponent<PlacedObject>();
		component.objectSO = objectSO;
		component.size = size;
		component.cellPosition = cellPosition;
		component.dir = dir;
		component.placedObjectTransform = transform;
		component.ID = ID;
		if (hasVariant)
		{
			component.hasVariant = hasVariant;
			component.variantIndex = variantIndex;
		}
		component.score = score;
		if (potVisual != null)
		{
			component.potVisual = potVisual;
			Object.Instantiate(potVisual, transform);
		}
		component.PlayParticleEffect();
		component.Animate();
		return component;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!GridPlacementManager.Instance.IsBuilding())
		{
			GridPlacementManager.Instance.TryToMoveObject();
		}
	}

	private void PlayParticleEffect()
	{
		ParticleSystem componentInChildren = GetComponentInChildren<ParticleSystem>();
		if (componentInChildren != null)
		{
			componentInChildren.Play();
		}
	}

	private void Animate()
	{
		tweener = placedObjectTransform.DOScale(0.9f, 0.05f).SetEase(Ease.InOutSine).OnComplete(delegate
		{
			placedObjectTransform.DOScale(1.1f, 0.1f).SetEase(Ease.InOutSine).OnComplete(delegate
			{
				placedObjectTransform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine);
			});
		});
	}

	public List<Vector2Int> GetGridPositionList()
	{
		return GridPlacementManager.Instance.GetGridPositionList(size, new Vector2Int(cellPosition.x, cellPosition.z), dir);
	}

	public ObjectSO GetObjectSO()
	{
		return objectSO;
	}

	public GridPlacementManager.Dir GetDir()
	{
		return dir;
	}

	public void DestroySelf()
	{
		if (tweener != null)
		{
			tweener.Kill();
		}
		Object.Destroy(base.gameObject);
	}

	public Transform GetTransform()
	{
		return placedObjectTransform;
	}

	public int GetScore()
	{
		return score;
	}

	public int GetID()
	{
		return ID;
	}

	public bool HasVariant()
	{
		return hasVariant;
	}

	public int GetVariantIndex()
	{
		return variantIndex;
	}

	public Transform GetPotVisual()
	{
		return potVisual;
	}

	public Vector3Int GetCellPosition()
	{
		return cellPosition;
	}
}

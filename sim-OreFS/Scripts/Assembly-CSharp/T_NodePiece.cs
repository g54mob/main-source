using UnityEngine;

public class T_NodePiece : MonoBehaviour
{
	[Header("Identity")]
	public int pieceIndex;

	public int collectAmount;

	[Header("VFX")]
	[Tooltip("VFX'lerin spawn olacağı nokta. Boşsa transform.position kullanılır.")]
	public Transform vfxSpawnPoint;

	[Header("References")]
	private T_Item parentItem;

	private Collider col;

	private Renderer pieceRenderer;

	private MaterialPropertyBlock propertyBlock;

	[Header("Crack Shader")]
	private static readonly int DamageRangeProperty = Shader.PropertyToID("_DamageRange");

	[Header("State")]
	private bool isBroken;

	private bool isInitialized;

	public void Initialize(T_Item parent, int index, int collectAmt)
	{
		parentItem = parent;
		pieceIndex = index;
		collectAmount = collectAmt;
		col = GetComponent<Collider>();
		pieceRenderer = GetComponent<Renderer>();
		if (pieceRenderer == null)
		{
			pieceRenderer = GetComponentInChildren<Renderer>();
		}
		propertyBlock = new MaterialPropertyBlock();
		isInitialized = true;
	}

	public int GetPieceIndex()
	{
		return pieceIndex;
	}

	public bool IsBroken()
	{
		return isBroken;
	}

	public T_Item GetParentItem()
	{
		return parentItem;
	}

	public Vector3 GetVFXPosition()
	{
		if (!(vfxSpawnPoint != null))
		{
			return base.transform.position;
		}
		return vfxSpawnPoint.position;
	}

	public void OnHealthChanged(int newHealth, int maxHealth)
	{
		if (isInitialized && !(pieceRenderer == null) && maxHealth > 0)
		{
			float value = (float)(maxHealth - newHealth) / (float)maxHealth;
			pieceRenderer.GetPropertyBlock(propertyBlock);
			propertyBlock.SetFloat(DamageRangeProperty, value);
			pieceRenderer.SetPropertyBlock(propertyBlock);
		}
	}

	public void Break()
	{
		if (!isBroken)
		{
			isBroken = true;
			if (col != null)
			{
				col.enabled = false;
			}
			Object.Destroy(base.gameObject);
		}
	}

	public void PlayHitVFXLocal()
	{
		if (!(GameManager.Instance == null) && !(GameManager.Instance.poolingManager == null) && !(parentItem == null) && !(parentItem.so == null))
		{
			Vector3 vFXPosition = GetVFXPosition();
			LayerVFX nodeHitVFX = parentItem.so.nodeHitVFX;
			GameObject pooledObjectByType = GameManager.Instance.poolingManager.GetPooledObjectByType(nodeHitVFX);
			if (pooledObjectByType != null)
			{
				pooledObjectByType.transform.position = vFXPosition;
				pooledObjectByType.transform.rotation = Quaternion.identity;
				pooledObjectByType.SetActive(value: true);
			}
			LayerSFX nodeHitSFX = parentItem.so.nodeHitSFX;
			if (SoundManager.Instance != null)
			{
				SoundManager.Instance.PlaySFXAtPosition(nodeHitSFX, vFXPosition);
			}
		}
	}

	public void PlayMiningVFXLocal()
	{
		if (!(parentItem == null) && !(parentItem.so == null) && !(parentItem.so.MiningVFX == null))
		{
			Vector3 vFXPosition = GetVFXPosition();
			Object.Destroy(Object.Instantiate(parentItem.so.MiningVFX, vFXPosition, Quaternion.identity), 3f);
		}
	}
}

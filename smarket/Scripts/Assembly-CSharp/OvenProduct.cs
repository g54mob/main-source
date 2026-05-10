using Lean.Pool;
using UnityEngine;

public class OvenProduct : MonoBehaviour, IPoolable
{
	public bool IsFrozen;

	public int BakedProductSO_ID;

	private Vector3 m_defaultScale;

	public Product Product;

	private void Start()
	{
	}

	public void IncreaseSize(Vector3 targetScale, float duration)
	{
	}

	public void ResetSize()
	{
	}

	public void OnSpawn()
	{
	}

	public void OnDespawn()
	{
	}
}

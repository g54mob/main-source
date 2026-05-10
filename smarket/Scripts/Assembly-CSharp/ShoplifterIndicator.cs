using UnityEngine;

public class ShoplifterIndicator : MonoBehaviour
{
	[SerializeField]
	private float m_MinScale;

	[SerializeField]
	private Vector3 m_Offset;

	[SerializeField]
	private float m_Scale;

	[SerializeField]
	private float m_Speed;

	private Transform m_Player;

	private Shoplifter m_Shoplifter;

	private Transform _targetShoplifterTransform;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Setup(Shoplifter shoplifter)
	{
	}

	public void Setup_Multiplayer(Transform shoplifter)
	{
	}

	public void Despawn()
	{
	}
}

using UnityEngine;

public class FurnitureSaleItemGamepadUIAdjuster : MonoBehaviour
{
	[SerializeField]
	private RectTransform m_AddCartRectTransform;

	[SerializeField]
	private RectTransform m_productCountTransform;

	[SerializeField]
	private Vector2 m_addCartDefaultPos;

	[SerializeField]
	private Vector2 m_addCartGpPos;

	[SerializeField]
	private Vector2 m_addCartDefaultSize;

	[SerializeField]
	private Vector2 m_addCartGpSize;

	[SerializeField]
	private Vector2 m_productCountDefaultPos;

	[SerializeField]
	private Vector2 m_productCountGpPos;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}
}

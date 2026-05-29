using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Product", menuName = "Scriptable Objects/Product/Weighted")]
public class WeightedProductSO : ProductSO
{
	[Serializable]
	public struct TransformData
	{
		public Vector3 Position;

		public Vector3 Rotation;
	}

	[Tooltip("Per product weight in kilograms")]
	public float Weight;

	public ushort Code;

	public TransformData[] CachedTransformData;

	[SerializeField]
	private Product m_CheckoutGraphics;

	public Vector2 BasePurchaseWeightRange;

	public override float BoxPrice => 0f;

	public override Product CreateCheckoutGraphics(int shoppingCartProduct)
	{
		return null;
	}
}

using MyBox;
using UnityEngine;

[CreateAssetMenu(fileName = "New Checkout", menuName = "Scriptable Objects/Furniture/Checkout")]
public class CheckoutSO : FurnitureSO
{
	[Separator("Shelf Setup", false)]
	public CheckoutType CheckoutType;
}

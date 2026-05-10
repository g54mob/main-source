using MyBox;
using UnityEngine;

[CreateAssetMenu(fileName = "New Display", menuName = "Scriptable Objects/Furniture/Display")]
public class DisplaySO : FurnitureSO
{
	[Separator("Shelf Setup", false)]
	public DisplayType DisplayType;
}

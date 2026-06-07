using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent/Diet")]
public class DietProperties : ScriptableObject
{
	[Tooltip("List of all the items that can be consumed for this diet.\nThe first item in this list will be preferred by agents.")]
	public List<ItemProperties> DietaryItems = new List<ItemProperties>();
}

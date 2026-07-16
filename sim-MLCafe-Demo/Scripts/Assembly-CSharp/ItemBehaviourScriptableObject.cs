using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Behaviour", menuName = "Item Behaviour", order = 1)]
public class ItemBehaviourScriptableObject : ScriptableObject
{
	public List<ItemBehaviour> behaviourList;
}

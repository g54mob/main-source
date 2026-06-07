using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Buildable/House Properties")]
public class HouseProperties : ScriptableObject
{
	[Tooltip("The total capacity of agents that can live in this type of house.")]
	public int Capacity = 5;
}

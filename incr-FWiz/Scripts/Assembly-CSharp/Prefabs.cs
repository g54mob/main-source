using UnityEngine;

public class Prefabs : MonoBehaviour
{
	public static Prefabs Instance { get; private set; }

	[field: SerializeField]
	public ConstructionUI ConstructionUI { get; private set; }

	private void Awake()
	{
	}
}

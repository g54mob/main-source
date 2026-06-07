using UnityEngine;

public class Storable : MonoBehaviour
{
	[SerializeField]
	protected StorableData storableData;

	public StorableData StorableData => storableData;
}

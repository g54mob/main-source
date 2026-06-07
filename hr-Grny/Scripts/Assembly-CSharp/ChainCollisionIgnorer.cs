using UnityEngine;

public class ChainCollisionIgnorer : MonoBehaviour
{
	[Header("Target Settings")]
	[Tooltip("Taggen på det objekt vars kollision ska ignoreras (Måste vara Granny's GameObject).")]
	public string targetTag;

	[Tooltip("Söker alla barnobjekt under denna kedja efter Colliders.")]
	public bool searchInChildren;

	private void Start()
	{
	}
}

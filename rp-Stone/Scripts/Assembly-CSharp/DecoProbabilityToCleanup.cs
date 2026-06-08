using UnityEngine;

[RequireComponent(typeof(Decoration))]
public class DecoProbabilityToCleanup : MonoBehaviour
{
	public float probabilityToCleanup;

	private void Start()
	{
		if (probabilityToCleanup > 0f && Random.Range(0f, 1f) < probabilityToCleanup)
		{
			GetComponent<Decoration>().Die(Character.DeathReason.DecorationCleanup);
		}
	}
}

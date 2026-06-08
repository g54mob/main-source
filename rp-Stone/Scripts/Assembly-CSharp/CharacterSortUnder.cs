using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterSortUnder : MonoBehaviour
{
	private void Update()
	{
		GetComponent<Character>().sortTiebreaker = -9999;
		base.enabled = false;
	}
}

using UnityEngine;

public class DeckArrowRoot : MonoBehaviour
{
	public enum Kind
	{
		Deck = 0,
		Chart = 1
	}

	public Kind kind;

	public Material material;

	public int numPointsPerSegment = 10;

	public Folio folio;
}

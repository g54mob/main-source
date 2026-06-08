using UnityEngine;

public class BoundsTestableItem : MonoBehaviour
{
	public BaryCentricDistance closestPointCalculator { get; private set; }

	private void Awake()
	{
		closestPointCalculator = new BaryCentricDistance(base.gameObject.GetComponentInChildren<MeshFilter>());
	}
}

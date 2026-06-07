using UnityEngine;

public class ScreenHeightDependentOffset : MonoBehaviour
{
	public float HeightPct;

	[NamedArray(typeof(CardinalDir))]
	public bool[] OffsetSides;

	private void Awake()
	{
	}
}

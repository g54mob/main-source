using UnityEngine;

public class UnitySiblingFix : MonoBehaviour
{
	public int Index;

	private void Reset()
	{
		Index = base.transform.GetSiblingIndex();
	}

	private void Start()
	{
		base.transform.SetSiblingIndex(Index);
		Object.Destroy(this);
	}
}

using UnityEngine;

public class DummyBoxGenerator : NoktaSingleton<DummyBoxGenerator>
{
	[SerializeField]
	private Box[] m_OpenBoxPrefabs;

	[SerializeField]
	private Box[] m_ClosedBoxPrefabs;

	public Box GenerateBox(bool openBox, BoxSize boxSize, Vector3 position, Quaternion rotation, Transform parent = null)
	{
		return null;
	}
}

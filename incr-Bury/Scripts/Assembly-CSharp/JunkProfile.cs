using System.Collections.Generic;
using UnityEngine;

public class JunkProfile : MonoBehaviour
{
	[SerializeField]
	private JunkIdentity junkIdentity;

	[SerializeField]
	private Sprite junkSprite;

	[SerializeField]
	private List<GameObject> junkPrefabs;

	public Sprite GetJunkSprite()
	{
		return junkSprite;
	}

	public JunkIdentity GetJunkIdentity()
	{
		return junkIdentity;
	}

	public GameObject GetRandomJunkPrefabVariant()
	{
		int index = Random.Range(0, junkPrefabs.Count);
		return junkPrefabs[index];
	}
}

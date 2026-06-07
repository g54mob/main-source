using UnityEngine;

public class gib : MonoBehaviour
{
	private void Awake()
	{
		Dungeon.Instance.animationManager.gibCount++;
	}

	private void OnDestroy()
	{
		Dungeon.Instance.animationManager.gibCount--;
	}

	private void Update()
	{
	}
}

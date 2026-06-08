using UnityEngine;

public class BurstAndGatherTest : MonoBehaviour
{
	public bool play;

	private void Update()
	{
		if (play)
		{
			play = false;
			BurstAndGatherEmitter[] componentsInChildren = GetComponentsInChildren<BurstAndGatherEmitter>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].Emit();
			}
		}
	}
}

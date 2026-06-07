using UnityEngine;

public class ProjGib : MonoBehaviour
{
	public bool alt;

	private void Awake()
	{
		if (alt)
		{
			Dungeon.Instance.animationManager.projGibsAlt++;
		}
		else
		{
			Dungeon.Instance.animationManager.projGibs++;
		}
	}

	private void OnDestroy()
	{
		if (alt)
		{
			Dungeon.Instance.animationManager.projGibsAlt--;
		}
		else
		{
			Dungeon.Instance.animationManager.projGibs--;
		}
	}
}

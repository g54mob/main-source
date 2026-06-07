using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
	private Bounds worldBounds;

	public bool containsPlayer
	{
		get
		{
			return worldBounds.Contains(Player.instance.transform.position);
		}
	}

	private void Start()
	{
		worldBounds = new Bounds(base.transform.position, base.transform.lossyScale);
	}
}

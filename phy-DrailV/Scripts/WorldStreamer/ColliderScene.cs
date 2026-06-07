using UnityEngine;

public class ColliderScene : MonoBehaviour
{
	public string sceneName;

	private void Start()
	{
		GameObject.FindGameObjectWithTag(ColliderStreamerManager.COLLIDERSTREAMERMANAGERTAG).GetComponent<ColliderStreamerManager>().AddColliderScene(this);
		WorldMover worldMover = Object.FindObjectOfType<WorldMover>();
		if ((bool)worldMover)
		{
			worldMover.AddObjectToMove(base.transform);
		}
	}
}

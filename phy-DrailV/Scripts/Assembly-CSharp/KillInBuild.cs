using UnityEngine;

public class KillInBuild : MonoBehaviour
{
	public Behaviour killThis;

	public bool killThisGameObject;

	public bool disableInsteadOfDestroy;

	private void Awake()
	{
		if (!killThisGameObject && killThis == null)
		{
			Debug.LogWarning("MonoBehaviour to kill wasn't assigned", base.gameObject);
		}
		if (disableInsteadOfDestroy)
		{
			if (killThisGameObject)
			{
				base.gameObject.SetActive(value: false);
			}
			else if ((bool)killThis)
			{
				killThis.enabled = false;
			}
		}
		else if (killThisGameObject)
		{
			Object.Destroy(base.gameObject);
		}
		else if ((bool)killThis)
		{
			Object.Destroy(killThis);
		}
		Object.Destroy(this);
	}
}

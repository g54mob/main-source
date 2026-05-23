using UnityEngine;
using UnityEngine.Events;

public class FakeChildTo : MonoBehaviour
{
	[SerializeField]
	private Transform fakeParent;

	[SerializeField]
	private bool unparentAtStart = true;

	[SerializeField]
	private bool disableThisComponentAfterStart;

	[SerializeField]
	private bool destroyWhenParentIsDestroyed = true;

	public UnityEvent onDestroy;

	private Vector3 offset;

	private void Start()
	{
		offset = base.transform.localPosition;
		if (unparentAtStart)
		{
			base.transform.SetParent(null);
		}
		if (disableThisComponentAfterStart)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (!fakeParent)
		{
			onDestroy.Invoke();
			if (destroyWhenParentIsDestroyed)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				Object.Destroy(this);
			}
		}
		else
		{
			base.transform.position = fakeParent.position + offset;
		}
	}
}

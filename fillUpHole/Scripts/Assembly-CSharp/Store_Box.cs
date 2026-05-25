using UnityEngine;

public class Store_Box : MonoBehaviour
{
	public Store_MiniGame ParentStore;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnMouseDown()
	{
		if (ParentStore != null)
		{
			ParentStore.BoxClick();
		}
	}
}

using UnityEngine;

public class ExistingObjectUnlockGUI : Indicator
{
	public GameObject previewHolder;

	private float movTime = 2f;

	private float currentTime;

	private Segment currentEase;

	private Inchworm inchwormRef;

	private void Update()
	{
		currentTime += Time.deltaTime;
		if (currentTime >= movTime)
		{
			Object.Destroy(base.transform.root.gameObject);
		}
		UpdateIndicator();
	}

	private void OnDestroy()
	{
		if (currentEase != null)
		{
			inchwormRef.CancelEase(ref currentEase);
			currentEase = null;
		}
	}

	public void SetUnlockedObject(InventoryItem item, Vector3 pos)
	{
	}

	private void SetChildrenLayers(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			SetChildrenLayers(obj.transform.GetChild(i).gameObject, newLayer);
		}
	}
}

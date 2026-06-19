using UnityEngine;

public class TossButton : StandardGUIElementLoader
{
	public override void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		if (currentEase != null)
		{
			inchwormRef.CancelAndFinishEase(ref currentEase);
			currentEase = null;
		}
		Clickable component = GetComponent<Clickable>();
		if (component != null)
		{
			component.Unload();
			Object.Destroy(component);
		}
		callback = unloadCallback;
		currentEase = inchwormRef.RequestEaseToScale(base.gameObject, Vector3.zero, scaleOutTime, Inchworm.EaseStyle.QuadraticOut, OnUnloadComplete);
	}

	protected override void OnLoadComplete()
	{
		base.OnLoadComplete();
		Clickable clickable = base.gameObject.AddComponent<Clickable>();
		clickable.SetClickCallbacks(TossItem);
		clickable.SetClickCallbackTime(Clickable.CallbackTime.CLICK_START);
	}

	private void TossItem()
	{
		base.transform.root.GetComponentInChildren<InventoryCore>().TossSelectedItem();
	}
}

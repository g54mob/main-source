using System.Collections;
using UnityEngine;

public class PanelSwatches : MonoBehaviour
{
	public Transform propertiesPanel;

	private void Awake()
	{
		Panel.SetTarget(base.transform);
		Swatches.swatchList = Panel.CreateComponent("list", "list", new Hashtable
		{
			{ "height", 90 },
			{
				"template",
				Resources.Load<Transform>("Interface/Prefabs/ItemSwatch")
			}
		}).GetComponent<ComponentList>();
		EventManager.StartListening("ChangeSwatch", DisplayUpdate);
	}

	private void OnEnable()
	{
		ControlVertexSnap.instance.Disable();
		Tips.Show("swatches");
		DisplayUpdate();
	}

	public void DisplayUpdate()
	{
		propertiesPanel.gameObject.SetActive(Swatches.swatch != null);
		if (Swatches.swatchList != null)
		{
			Swatches.swatchList.UpdateElements();
		}
	}
}

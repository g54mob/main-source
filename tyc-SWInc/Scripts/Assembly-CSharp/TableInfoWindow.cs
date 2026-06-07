using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TableInfoWindow : MonoBehaviour
{
	public Button ButtonPrefab;

	public GUIWindow Window;

	public VarValueSheet Sheet;

	public GUIPieChart Pie;

	public Text Header;

	public GameObject ManufacturingButton;

	public Transform MainPanel;

	[NonSerialized]
	private IManufacturable _cat;

	[NonSerialized]
	private List<FeatureBase> _features;

	[NonSerialized]
	private List<uint> _factors;

	public void Init(string title, string header, string[] var, string[] value, string ID, Dictionary<string, float> pie, IManufacturable cat, List<FeatureBase> features, List<uint> factors, IEnumerable<SoftwareWorkItem> addons)
	{
		Sheet.SetData(var, value);
		Window.NonLocTitle = title;
		Header.text = header;
		if (pie != null)
		{
			Pie.Colors = HUD.GetThemeColors().ToList();
			Pie.Values = pie.Values.ToList();
			Pie.SetLabels(pie.Keys.Select((string x) => x.LocTry()));
			Pie.UpdateCachedPie();
			Pie.gameObject.SetActive(true);
		}
		ManufacturingButton.SetActive(cat != null);
		if (cat != null)
		{
			_cat = cat;
			_features = features;
			_factors = factors;
		}
		if (ID != null)
		{
			Window.OnClose = delegate
			{
				WindowManager.DeregisterTableInfoWindow(ID);
			};
		}
		if (addons == null)
		{
			return;
		}
		foreach (SoftwareWorkItem add in addons)
		{
			Button button = UnityEngine.Object.Instantiate(ButtonPrefab);
			Text componentInChildren = button.GetComponentInChildren<Text>();
			UnityEngine.Object.Destroy(componentInChildren.GetComponent<TextLoc>());
			componentInChildren.text = add.AddonType.GetPrettyName();
			button.onClick.AddListener(delegate
			{
				GUIWorkItem.SpawnDevInfoWindow(add, add is DesignDocument);
			});
			button.transform.SetParent(MainPanel, false);
			button.gameObject.AddComponent<LayoutElement>().preferredHeight = 24f;
		}
	}

	public void ShowManufacturing()
	{
		HUD.Instance.ManufacturingWindow.Show(_cat, _features, _factors);
	}
}

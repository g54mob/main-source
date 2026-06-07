using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SWToolPanel : MonoBehaviour
{
	public Text Label;

	public Text ToolLabel;

	[NonSerialized]
	public SoftwareProduct PickedProduct;

	[NonSerialized]
	public string Tool;

	[NonSerialized]
	private SoftwareType _type;

	[NonSerialized]
	private IList<FeatureBase> _features;

	[NonSerialized]
	private Dictionary<string, TechLevel> _techs;

	[NonSerialized]
	private Action _onChanged;

	public void Init(string tool, SoftwareType type, IList<FeatureBase> features, Dictionary<string, TechLevel> techs, Action onChanged)
	{
		Tool = tool;
		Label.text = Tool.LocSW();
		PickedProduct = null;
		ToolLabel.text = "ToolNotChosen".Loc();
		_type = type;
		_features = features;
		_techs = techs;
		_onChanged = onChanged;
	}

	public void SetProduct(SoftwareProduct p)
	{
		if (p != null)
		{
			PickedProduct = p;
			ToolLabel.text = p.Name;
		}
		else
		{
			PickedProduct = null;
			ToolLabel.text = "ToolNotChosen".Loc();
		}
		if (_onChanged != null)
		{
			_onChanged();
		}
	}

	public void PickTool()
	{
		string[] specsFromNeed = _type.GetSpecsFromNeed(Tool, _features);
		ProductWindow productWindow = HUD.Instance.GetProductWindow("DesignDoc");
		productWindow.SetFilters(true, false);
		productWindow.Show(true, "ProductChooseGeneric".Loc(Tool.LocSW()), delegate(SoftwareProduct[] x)
		{
			SetProduct((x.Length != 0) ? x[0] : null);
		}, false, false, true);
		productWindow.CheckSupport(_techs, specsFromNeed);
		productWindow.WithMock = false;
		productWindow.LimitTech = true;
		productWindow.SetType(Tool);
	}
}

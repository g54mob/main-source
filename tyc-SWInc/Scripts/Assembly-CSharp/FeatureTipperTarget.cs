using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeatureTipperTarget : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
{
	[NonSerialized]
	public SoftwareCategory SWCat;

	[NonSerialized]
	public FeatureBase Feature;

	public string Warning;

	[NonSerialized]
	public List<KeyValuePair<string, float>> Boosts = new List<KeyValuePair<string, float>>();

	public void OnPointerEnter(PointerEventData d)
	{
		FeatureTipper.Instance.Set(GetComponent<RectTransform>(), SWCat.Parent, SWCat, Feature, Warning, Boosts, HUD.Instance.docWindow.CurrentPage == 0 || HUD.Instance.docWindow.IsDistribution());
	}
}

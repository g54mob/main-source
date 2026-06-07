using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AutoDevDetailWindow : MonoBehaviour
{
	public GUIWindow Window;

	public GUIListView WorkItemList;

	public GUIListView FeatureList;

	public GUIListView LicenseList;

	public Text MainDesc;

	public Text LicenseCost;

	[NonSerialized]
	public AutoDevWorkItem workItem;

	[NonSerialized]
	public SoftwareWorkItem lastProj;

	private void Start()
	{
		Window.NonLocTitle = workItem.GetDevTeams().First().Name + "Automation".Loc();
	}

	private void Update()
	{
		bool flag = false;
		string arg = null;
		string sw = null;
		string cat = null;
		LicenseCost.text = this.workItem.LastLicensePaid.Currency();
		List<SoftwareProduct> source = new List<SoftwareProduct>();
		bool flag2 = true;
		if (flag2)
		{
			UpdateFeatures();
		}
		if (flag2 && flag)
		{
			MainDesc.text = string.Format("AutoDevProjDetails2".Loc(), arg, sw.LocSW(), cat.LocSWC(sw));
		}
		else if (flag2)
		{
			string text = "NotApplicableAbbr".Loc();
			MainDesc.text = string.Format("AutoDevProjDetails2".Loc(), text, text, text);
		}
		for (int i = 0; i < WorkItemList.Items.Count; i++)
		{
			WorkItem workItem = WorkItemList.Items[i] as WorkItem;
			if (workItem != null && workItem.Done)
			{
				WorkItemList.Items.RemoveAt(i);
				i--;
			}
		}
		if (flag2)
		{
			LicenseList.Items.Clear();
			LicenseList.Items.AddRange(source.Distinct().Cast<object>());
		}
	}

	private void UpdateFeatures()
	{
	}

	private void UpdateListWith(uint w)
	{
		WorkItem w2 = GameSettings.Instance.MyCompany.WorkItems.FirstOrDefault((WorkItem x) => x.ID == w);
		UpdateListWith(w2);
	}

	private void UpdateListWith(WorkItem w)
	{
		if (w != null && !WorkItemList.Items.Contains(w))
		{
			WorkItemList.Items.Add(w);
		}
	}
}

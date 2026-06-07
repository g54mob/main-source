using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PublisherDealWindow : MonoBehaviour
{
	public Toggle TogglePrefab;

	public RectTransform TogglePanel;

	public RectTransform DealPanel;

	public PublisherDealUI DealPrefab;

	public GUIWindow Window;

	private Toggle[] DealToggles;

	private SoftwareCategory _cat;

	private float _devTime;

	private float _artRatio;

	private Action<PublisherDeal> _onAccept;

	private bool _allowRelease;

	private bool _allowFunding;

	private SDateTime _devStart;

	private void Start()
	{
		DealToggles = new Toggle[PublisherDeal.DealRoyalty.Count((KeyValuePair<string, float> x) => x.Value > 0f)];
		int num = 0;
		foreach (KeyValuePair<string, float> item in PublisherDeal.DealRoyalty)
		{
			if (item.Value > 0f)
			{
				Toggle toggle = UnityEngine.Object.Instantiate(TogglePrefab);
				toggle.name = item.Key;
				toggle.GetComponentInChildren<Text>().text = item.Key.Loc();
				toggle.transform.SetParent(TogglePanel, false);
				toggle.onValueChanged.AddListener(delegate
				{
					RefreshDeals();
				});
				DealToggles[num] = toggle;
				num++;
			}
		}
	}

	public void Show(SoftwareCategory cat, float devtime, float artRatio, bool allowFunding, bool allowRelease, SDateTime devStart, Action<PublisherDeal> onAccept)
	{
		if (!(GameSettings.Instance.Difficulty.Publisher < 0.5f))
		{
			_cat = cat;
			_devTime = devtime;
			_artRatio = artRatio;
			_onAccept = onAccept;
			_allowFunding = allowFunding;
			_allowRelease = allowRelease;
			_devStart = devStart;
			DealToggles.ForEachEnum(delegate(Toggle x)
			{
				x.isOn = false;
			});
			DealToggles.First((Toggle x) => x.name.Equals("Funding")).gameObject.SetActive(_allowFunding && GameSettings.Instance.MyCompany.BusinessStars > 0);
			DealToggles.First((Toggle x) => x.name.Equals("Printing")).gameObject.SetActive(!cat.Hardware);
			RefreshDeals();
			Window.Show();
		}
	}

	private void ClearDeals()
	{
		for (int num = DealPanel.childCount - 1; num >= 0; num--)
		{
			UnityEngine.Object.Destroy(DealPanel.GetChild(num).gameObject);
		}
	}

	public void RefreshDeals()
	{
		ClearDeals();
		foreach (PublisherDeal.DealPackage item in FetchDeals(_cat, _devTime, _artRatio).OrderByDescending((PublisherDeal.DealPackage x) =>
		{
			SimulatedCompany simulatedCompany;
			return ((simulatedCompany = x.Publisher as SimulatedCompany) == null) ? 0f : simulatedCompany.PlayerRelationship;
		}).ThenByDescending((PublisherDeal.DealPackage x) => x.Publisher.GetReputation(x.Cat)).ThenBy((PublisherDeal.DealPackage x) => x.Royalty))
		{
			PublisherDealUI publisherDealUI = UnityEngine.Object.Instantiate(DealPrefab);
			publisherDealUI.Init(item, this, _allowRelease, _devStart);
			publisherDealUI.transform.SetParent(DealPanel, false);
		}
	}

	public List<PublisherDeal.DealPackage> FetchDeals(SoftwareCategory cat, float devtime, float artRatio)
	{
		List<PublisherDeal.DealPackage> list = new List<PublisherDeal.DealPackage>();
		SHashSet<string> sHashSet = (from x in DealToggles
			where x.isOn
			select x.name).ToSHashSet();
		if (sHashSet.Count > 0)
		{
			foreach (SimulatedCompany value in MarketSimulation.Active.Companies.Values)
			{
				if (!value.IsSubsidiary())
				{
					PublisherDeal.DealPackage? dealPackage = PublisherDeal.GetDealPackage(sHashSet, cat, GameSettings.Instance.MyCompany, value, _devStart, devtime, artRatio, _allowFunding, _allowRelease);
					if (dealPackage.HasValue)
					{
						list.Add(dealPackage.Value);
					}
				}
			}
		}
		return list;
	}

	public float GetPublishingAvailable()
	{
		int businessStars = GameSettings.Instance.MyCompany.BusinessStars;
		if (businessStars == 0)
		{
			return 0f;
		}
		float num = PublisherDeal.EstimateProjectCost(_devTime, _artRatio);
		return businessStars.MapRange(1f, 6f, 0.5f, 2f) * num;
	}

	public void CancelClick()
	{
		Window.Close();
	}

	public void OnAccept(PublisherDeal deal)
	{
		if (_onAccept != null)
		{
			_onAccept(deal);
			_onAccept = null;
		}
		ClearDeals();
		Window.Close();
	}
}

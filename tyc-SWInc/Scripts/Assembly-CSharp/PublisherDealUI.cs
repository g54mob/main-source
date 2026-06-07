using System;
using UnityEngine;
using UnityEngine.UI;

public class PublisherDealUI : MonoBehaviour
{
	public RawImage Logo;

	public Text CompanyName;

	public Text RoyaltyLabel;

	public Text InfoLabel;

	public GUIProgressBar Relationship;

	public IconFillBar Recognition;

	[NonSerialized]
	private PublisherDealWindow _parent;

	[NonSerialized]
	private PublisherDeal.DealPackage _deal;

	public void Init(PublisherDeal.DealPackage deal, PublisherDealWindow parent, bool allowRelease, SDateTime devStart)
	{
		_deal = deal;
		_parent = parent;
		Logo.uvRect = LogoController.Instance.GetLogoRect(deal.Publisher);
		CompanyName.text = deal.Publisher.Name;
		Recognition.Values[1] = deal.Publisher.GetReputation(deal.Cat) * 6f;
		SimulatedCompany simulatedCompany;
		if ((simulatedCompany = deal.Publisher as SimulatedCompany) != null)
		{
			Relationship.gameObject.SetActive(true);
			Relationship.Value = simulatedCompany.PlayerRelationship;
		}
		else
		{
			Relationship.gameObject.SetActive(false);
		}
		if (deal.Recoup > 0f)
		{
			RoyaltyLabel.text = deal.Royalty.ToPercent() + " -> " + deal.PostRoyalty.ToPercent() + " " + "AfterRecoup".Loc(deal.Recoup.XTimes());
		}
		else
		{
			RoyaltyLabel.text = deal.Royalty.ToPercent();
		}
		InfoLabel.text = (allowRelease ? ("Releasedate".Loc() + ": " + (devStart + deal.Deadline).ToCompactString() + " (" + SDateTime.DateDiff(Mathf.FloorToInt(deal.Deadline * (float)GameSettings.DaysPerMonth), false) + ")") : "");
		if (deal.Funding > 0f)
		{
			Text infoLabel = InfoLabel;
			infoLabel.text = infoLabel.text + "\n" + "Funding".Loc() + ": " + deal.Funding.Currency();
		}
		if (deal.Deals.Contains("OSExclusivity"))
		{
			Text infoLabel2 = InfoLabel;
			infoLabel2.text = infoLabel2.text + "\n" + "OSExclusivity".Loc();
		}
	}

	public void ShowCompanyInfo()
	{
		UISoundFX.PlaySFX("ButtonClick");
		GUIWindow gUIWindow = HUD.Instance.companyWindow.ShowCompanyDetails(_deal.Publisher);
		if (gUIWindow != null)
		{
			gUIWindow.SetParentWindow(_parent.Window);
			gUIWindow.Modal = true;
			gUIWindow.Show(true);
		}
	}

	public void AcceptDeal()
	{
		Company publisher = _deal.Publisher;
		if (!publisher.Bankrupt && !publisher.IsSubsidiary())
		{
			_parent.OnAccept(new PublisherDeal(_deal));
		}
	}
}

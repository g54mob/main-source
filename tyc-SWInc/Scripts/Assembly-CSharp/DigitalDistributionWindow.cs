using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class DigitalDistributionWindow : MonoBehaviour
{
	public GUIWindow Window;

	public GUIListView DistDealList;

	public GUIListView PlatformList;

	public GUILineChart Chart;

	public Slider RevCut;

	public Text RevCutText;

	public Text Reach;

	public GameObject ManageStorePanel;

	public Transform SatisfactionBarPanel;

	public Toggle OpenStore;

	public Toggle AutoAccept;

	public Toggle AutoSignup;

	public List<GUIProgressBar> Bars = new List<GUIProgressBar>();

	[NonSerialized]
	public float _cutChanged = -1f;

	private bool _wasBound;

	private void Start()
	{
		Chart.ToolTipFunc = (int j, int i, float f) => (SDateTime.Now() - new SDateTime(0, 0, 20 - i, 0, 0)).ToCompactString2() + ": " + (f * 100f).ToString("N2") + "%";
		string[] array = new string[4]
		{
			"Quality".Loc(),
			"Features".Loc(),
			"Techlevels".Loc(),
			"Stability".Loc()
		};
		for (int num = 0; num < array.Length - 1; num++)
		{
			GUIProgressBar gUIProgressBar = UnityEngine.Object.Instantiate(Bars[0]);
			gUIProgressBar.transform.SetParent(SatisfactionBarPanel, false);
			Bars.Add(gUIProgressBar);
		}
		Bars[0].MySprite = ObjectDatabase.Instance.GetSprite(true, false, false, true);
		Bars.Last().MySprite = ObjectDatabase.Instance.GetSprite(false, true, true, false);
		for (int num2 = 0; num2 < 4; num2++)
		{
			Bars[num2].GetComponentInChildren<Text>().text = array[num2];
		}
		PlatformList["PlatformAccepted"].ToggleActive(false, GameSettings.Instance.IsNetworkMode);
	}

	private void Bind()
	{
		if (_wasBound)
		{
			return;
		}
		PlatformList.Items = MarketSimulation.Active.DistributionPlatforms.Cast<object>().ToList();
		MarketSimulation.Active.DistributionPlatforms.OnChange = delegate
		{
			MarketSimulation.Active.DistributionPlatforms.Update(PlatformList.Items);
		};
		_wasBound = true;
		Window.OnClose = delegate
		{
			if (_cutChanged >= 0f)
			{
				DistributionPlatform distribution = GameSettings.Instance.MyCompany.Distribution;
				if (distribution != null)
				{
					distribution.SetCut(distribution.GetCut());
				}
				_cutChanged = -1f;
			}
		};
	}

	private void Update()
	{
		if (!(_cutChanged >= 0f))
		{
			return;
		}
		_cutChanged -= Time.deltaTime;
		if (_cutChanged < 0f)
		{
			DistributionPlatform distribution = GameSettings.Instance.MyCompany.Distribution;
			if (distribution != null)
			{
				distribution.SetCut(distribution.GetCut());
			}
		}
	}

	public void ToggleOpenStore()
	{
		DistributionPlatform distribution = GameSettings.Instance.MyCompany.Distribution;
		if (distribution != null)
		{
			distribution.Open = OpenStore.isOn;
			NetworkMessaging.SendDistributionState(distribution.Software.ID, distribution.Open, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			if (!OpenStore.isOn)
			{
				foreach (Company allCompany in MarketSimulation.Active.GetAllCompanies())
				{
					if (distribution.HasToPay(allCompany))
					{
						allCompany.SignPlatform(distribution, false);
						allCompany.MarkInterested(distribution.Owner, false, 0);
					}
				}
			}
			RevCut.value = distribution.GetCut() * 100f;
		}
		Toggle autoAccept = AutoAccept;
		bool interactable = (RevCut.interactable = distribution != null);
		autoAccept.interactable = interactable;
		UpdateDistributionDeals();
	}

	public void ToggleAutoAccept()
	{
		DistributionPlatform distribution = GameSettings.Instance.MyCompany.Distribution;
		if (distribution != null)
		{
			distribution.SetAutoAcceptClients(AutoAccept.isOn);
		}
	}

	public void ToggleAutoSignup()
	{
		GameSettings.Instance.MyCompany.SetAutoAcceptPlatforms(AutoSignup.isOn);
	}

	public bool RefreshRevCutColor()
	{
		DistributionPlatform pd = GameSettings.Instance.MyCompany.Distribution;
		bool flag = pd != null && MarketSimulation.Active.Companies.Values.Any((SimulatedCompany x) => !x.IsPlayerOwned() && x.IsSigned(pd) && x.GetMaxPlayerCut(pd) < pd.GetCut());
		RevCutText.color = (flag ? new Color32(200, 0, 0, byte.MaxValue) : new Color32(50, 50, 50, byte.MaxValue));
		return flag;
	}

	public static float GetCut()
	{
		return HUD.Instance.digitalDistributionWindow.RevCut.value / 100f;
	}

	public void RevCutChange()
	{
		float num = RevCut.value / 100f;
		DistributionPlatform distribution = GameSettings.Instance.MyCompany.Distribution;
		RevCutText.text = num.ToPercent();
		_cutChanged = 1f;
		if (distribution != null)
		{
			distribution.SetCut(num, true);
		}
		if (RefreshRevCutColor())
		{
			Text revCutText = RevCutText;
			revCutText.text = revCutText.text + " (" + "DistDealCancelLikely".Loc() + ")";
		}
	}

	public void Show(bool force)
	{
		Show(force, null);
	}

	public void Show(bool force, DistributionPlatform platform)
	{
		if (force)
		{
			Window.Show();
		}
		else
		{
			Window.Toggle();
		}
		if (Window.Shown)
		{
			RevCut.maxValue = MarketSimulation.DistributionStandardCut * 100f;
			Chart.Values = new List<List<float>> { GameSettings.Instance.simulation.PlayerDigitalShare };
			Chart.UpdateCachedLines();
			UpdateDistributionDeals();
			UpdateStoreButton();
			AutoSignup.isOn = GameSettings.Instance.MyCompany.AutoAcceptPlatforms;
			Toggle autoAccept = AutoAccept;
			DistributionPlatform distribution = GameSettings.Instance.MyCompany.Distribution;
			autoAccept.isOn = distribution == null || distribution.AutoAcceptClients;
			Bind();
			UpdateInfo();
			if (platform != null)
			{
				PlatformList.Select(platform);
			}
		}
	}

	public void OpenDistribution()
	{
		if (GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>().None((SoftwareWorkItem x) => x.Type == MarketSimulation.Active.DigitalDistSoft))
		{
			HUD.Instance.docWindow.ShowOverride(MarketSimulation.Active.DigitalDistSoft, MarketSimulation.Active.DigitalDistSoft.Categories.Values.First());
		}
	}

	public static void CancelAllJobs()
	{
		if (GameSettings.Instance.MyCompany.Distribution != null)
		{
			SoftwareProduct sw = GameSettings.Instance.MyCompany.Distribution.Software;
			SupportWork supportWork = GameSettings.Instance.MyCompany.WorkItems.OfType<SupportWork>().FirstOrDefault((SupportWork x) => x.TargetProduct == sw);
			if (supportWork != null)
			{
				supportWork.Kill();
			}
			MarketingPlan marketingPlan = GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>().FirstOrDefault((MarketingPlan x) => x.TargetProduct == sw);
			if (marketingPlan != null)
			{
				marketingPlan.Kill();
			}
			SoftwareUpdate softwareUpdate = GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareUpdate>().FirstOrDefault((SoftwareUpdate x) => x.Target == sw);
			if (softwareUpdate != null)
			{
				softwareUpdate.Kill();
			}
		}
	}

	public void CloseDistribution()
	{
		if (GameSettings.Instance.MyCompany.Distribution != null)
		{
			WindowManager.Instance.ShowMessageBox("OnlineStoreCloseConfirmation".Loc(), true, DialogWindow.DialogType.Question, delegate
			{
				CancelAllJobs();
				GameSettings.Instance.DeregisterServerItem(GameSettings.Instance.MyCompany.Distribution);
				MarketSimulation.Active.ClosePlatform(GameSettings.Instance.MyCompany.Distribution);
				UpdateStoreButton();
				UpdateDistributionDeals();
			});
		}
	}

	public void UpdateStore()
	{
		if (GameSettings.Instance.MyCompany.Distribution != null)
		{
			HUD.Instance.updateWindow.Show(GameSettings.Instance.MyCompany.Distribution.Software);
		}
	}

	public void UpdateStoreButton()
	{
		ManageStorePanel.SetActive(GameSettings.Instance.MyCompany.Distribution != null);
		OpenStore.interactable = GameSettings.Instance.MyCompany.Distribution != null;
		OpenStore.isOn = OpenStore.interactable && GameSettings.Instance.MyCompany.Distribution.Open;
		RevCut.value = ((GameSettings.Instance.MyCompany.Distribution != null) ? (GameSettings.Instance.MyCompany.Distribution.GetCut() * 100f) : 5f);
		AutoAccept.interactable = GameSettings.Instance.MyCompany.Distribution != null;
		RevCutChange();
	}

	public void UpdateDistributionDeals()
	{
		if (Window.Shown)
		{
			DistDealList.Items = (from x in GameSettings.Instance.simulation.GetAllCompanies()
				where !x.IsLocalPlayer && !x.IsPlayerOwned() && x.WantLocalPlayerDistribution()
				select x).Cast<object>().ToList();
		}
	}

	public void UpdateInfo()
	{
		Reach.text = "Consumerreach".Loc() + ": " + ((float)MarketSimulation.Active.EvalutateDistributionSums(GameSettings.Instance.MyCompany.GetPlatforms()) / (float)MarketSimulation.Population).ToPercent();
		RefreshRevCutColor();
		if (GameSettings.Instance.MyCompany.Distribution != null)
		{
			DistributionPlatform distribution = GameSettings.Instance.MyCompany.Distribution;
			Bars[0].Value = distribution.GetQualityScore();
			Bars[1].Value = distribution.GetFeatScore();
			Bars[2].Value = distribution.GetTechScore();
			Bars[3].Value = distribution.GetStabilityScore();
		}
	}
}

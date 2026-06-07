using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FinalReviewWindow : MonoBehaviour
{
	public Text Label;

	public Text OrderCost;

	public Text MTeamLabel;

	public GUIWindow Window;

	public ReviewerPanel[] Reviewers;

	public RectTransform CloseButton;

	public RectTransform FadePanel;

	public RectTransform Logo;

	public RectTransform LogoBack;

	public RawImage LogoImage;

	public float ShowSpeed = 1f;

	public AudioClip[] StarBlips;

	public AudioClip[] StarEndBlips;

	public AudioClip KeyboardSFX;

	public AudioClip Stamp;

	public AudioClip Slide;

	public AudioClip Launch;

	private Sequence _activeSequence;

	private float _skipTo;

	public InputField MarketingBudget;

	public InputField OrderAmount;

	public InputField PrintMax;

	public Toggle MarketingToggle;

	public Toggle OrderToggle;

	public Toggle PrintToggle;

	public GameObject MarketingPanel;

	public GameObject CopyOrderPanel;

	public GameObject PrintPanel;

	[NonSerialized]
	private IStockable _target;

	private uint? _maxCopy;

	private uint _orderCopy;

	private float _marketingBudget;

	private bool _disableUpdate;

	[NonSerialized]
	private List<KeyValuePair<IStockable, FinalReviewGenerator.Review[]>> _queue = new List<KeyValuePair<IStockable, FinalReviewGenerator.Review[]>>();

	[NonSerialized]
	private HashSet<string> _marketingTeams = new HashSet<string>();

	[NonSerialized]
	public SimulatedCompany _companyWorker;

	public void SelectMarketingTeams()
	{
		HUD.Instance.TeamSelectWindow.Show(_marketingTeams, _companyWorker, delegate(string[] ts, SimulatedCompany c)
		{
			_marketingTeams.Clear();
			if (c != null)
			{
				_companyWorker = c;
			}
			else
			{
				_companyWorker = null;
				_marketingTeams.AddRange(ts);
			}
			UpdateTeamLabel();
		}, "Marketing", "Market", "MarketingPlan");
	}

	public void UpdateTeamLabel()
	{
		MTeamLabel.text = ((_companyWorker != null) ? _companyWorker.Name : _marketingTeams.GetListAbbrev("Team"));
	}

	public void Close(bool applyActions)
	{
		if (applyActions)
		{
			if (OrderToggle.isOn && _orderCopy != 0)
			{
				float num = (float)_orderCopy * _target.GetPrintPrice();
				if (!GameSettings.Instance.MyCompany.CanMakeTransaction(0f - num))
				{
					WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), false, DialogWindow.DialogType.Error, Window);
					return;
				}
				GameSettings.Instance.MyCompany.MakeTransaction(0f - num, Company.TransactionCategory.Distribution, true, "Copy order");
				_target.PhysicalCopies += _orderCopy;
				_target.AddLoss(num, SoftwareProduct.LossType.Copies, true);
				UISoundFX.PlaySFX("Kaching");
			}
			if (PrintToggle.isOn && GameSettings.Instance.GetPrintJob(_target) == null)
			{
				PrintJob printJob = new PrintJob(_target);
				printJob.Maximum = _maxCopy;
				GameSettings.Instance.AddPrintOrder(printJob, false);
				if (printJob.Hardware)
				{
					GameSettings.Instance.PromptPrintAssignment(printJob);
				}
				HUD.Instance.distributionWindow.Show(printJob);
			}
			if (MarketingToggle.isOn)
			{
				DoMarketing(_marketingTeams, _companyWorker);
			}
		}
		HardwareDesignRenderer.Release(LogoImage.texture);
		UnityEngine.Object.Destroy(LogoImage.texture);
		LogoImage.texture = null;
		GameSettings.ForcePause = false;
		Window.Close();
		if (_queue.Count > 0)
		{
			KeyValuePair<IStockable, FinalReviewGenerator.Review[]> keyValuePair = _queue[0];
			_queue.RemoveAt(0);
			Show(keyValuePair.Key, keyValuePair.Value);
		}
	}

	private void DoMarketing(IEnumerable<string> teams, SimulatedCompany companyWorker)
	{
		MarketingPlan marketingPlan = GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>().FirstOrDefault((MarketingPlan x) => x.TargetProduct == _target);
		if (marketingPlan != null)
		{
			foreach (AutoDevWorkItem item in GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>())
			{
				if (item.TakeOverTask(marketingPlan))
				{
					marketingPlan.MaxBudget = _marketingBudget;
					if (companyWorker == null)
					{
						marketingPlan.SetDevTeams(teams.ToList());
					}
					else
					{
						marketingPlan.CompanyWorker = companyWorker;
					}
					break;
				}
			}
			return;
		}
		MarketingPlan marketingPlan2 = new MarketingPlan(_marketingBudget, _target as IMarketable);
		if (companyWorker == null)
		{
			marketingPlan2.AddDevTeams(teams);
		}
		else
		{
			marketingPlan2.CompanyWorker = companyWorker;
		}
		GameSettings.Instance.MyCompany.AddWorkItem(marketingPlan2);
	}

	public void BudgetChange()
	{
		_disableUpdate = true;
		_marketingBudget = 0f;
		try
		{
			_marketingBudget = Mathf.Max(0f, (float)Convert.ToDouble(MarketingBudget.text.Replace(",", ""))).FromCurrency();
		}
		catch (Exception)
		{
		}
		MarketingBudget.text = _marketingBudget.Currency(false);
		_disableUpdate = false;
	}

	public void OrderAmountLive()
	{
		try
		{
			uint orderCopy = Convert.ToUInt32(OrderAmount.text.Replace(",", ""));
			_orderCopy = orderCopy;
		}
		catch (Exception)
		{
		}
		OrderCost.text = ((float)_orderCopy * _target.GetPrintPrice()).Currency();
	}

	public void OrderAmountChange()
	{
		_disableUpdate = true;
		_orderCopy = 0u;
		try
		{
			_orderCopy = Convert.ToUInt32(OrderAmount.text.Replace(",", ""));
		}
		catch (Exception)
		{
		}
		OrderAmount.text = _orderCopy.ToString("N0");
		OrderCost.text = ((float)_orderCopy * _target.GetPrintPrice()).Currency();
		_disableUpdate = false;
	}

	public void PrintMaxChange()
	{
		_disableUpdate = true;
		_maxCopy = null;
		try
		{
			if (PrintMax.text.Equals("-1"))
			{
				_maxCopy = null;
			}
			else
			{
				_maxCopy = Convert.ToUInt32(PrintMax.text.Replace(",", ""));
			}
		}
		catch (Exception)
		{
		}
		PrintMax.text = (_maxCopy.HasValue ? _maxCopy.Value.ToString("N0") : "-1");
		_disableUpdate = false;
	}

	public void ToggleMarketing(bool on)
	{
		MarketingBudget.interactable = on;
	}

	public void ToggleOrderCopy(bool on)
	{
		OrderAmount.interactable = on;
	}

	public void TogglePrintCopy(bool on)
	{
		PrintMax.interactable = on;
	}

	private bool CheckMarketing()
	{
		IMarketable marketable = _target as IMarketable;
		if (marketable == null || !PublisherDeal.HasDeal(marketable, "Marketing"))
		{
			MarketingPanel.SetActive(true);
			MarketingBudget.text = "0";
			MarketingToggle.isOn = true;
			BudgetChange();
			return true;
		}
		MarketingToggle.isOn = false;
		MarketingPanel.SetActive(false);
		return false;
	}

	private bool CheckOrder()
	{
		IMarketable marketable = _target as IMarketable;
		if (marketable == null || !PublisherDeal.HasDeal(marketable, "Printing"))
		{
			CopyOrderPanel.SetActive(true);
			OrderAmount.text = CopyOrderWindow.ApproximateOrderSizeGuess(SimulatedCompany.SimulateProductDistribution(_target, GameSettings.Instance.MyCompany.Money * 0.20000000298023224, false)).ToString("N0");
			if (_target is AddOnProduct)
			{
				AddOnProduct addOnProduct = (AddOnProduct)_target;
				if (addOnProduct.Forced)
				{
					int num = OrderAmount.text.ConvertToIntDef(0);
					if (addOnProduct.Parent.PhysicalCopies > _target.PhysicalCopies + num)
					{
						OrderAmount.text = (addOnProduct.Parent.PhysicalCopies - _target.PhysicalCopies).ToString("N0");
					}
				}
			}
			OrderAmountChange();
			OrderToggle.isOn = true;
			return true;
		}
		OrderToggle.isOn = false;
		CopyOrderPanel.SetActive(false);
		return false;
	}

	private bool CanPrint()
	{
		if (_target.Manufacturing.IsHardware())
		{
			return GameSettings.Instance.GetAssemblyLines().Any((AssemblyLine x) => x.IsCompatible(_target.Manufacturing, _target.HardwareMask, _target.HardwareInputMask) > 0);
		}
		return GameSettings.Instance.ProductPrinters.Any((ProductPrinter x) => x.Type == ProductPrinter.PrinterType.Product);
	}

	private bool CheckPrint()
	{
		IMarketable marketable = _target as IMarketable;
		if ((marketable == null || !PublisherDeal.HasDeal(marketable, "Printing")) && CanPrint() && GameSettings.Instance.GetPrintJob(_target) == null)
		{
			PrintPanel.SetActive(true);
			PrintMax.text = "-1";
			PrintToggle.isOn = true;
			PrintMaxChange();
			return true;
		}
		PrintToggle.isOn = false;
		PrintPanel.SetActive(false);
		return false;
	}

	private void Update()
	{
		if (_activeSequence != null && _activeSequence.IsPlaying() && _activeSequence.fullPosition < _skipTo && Input.GetMouseButton(0))
		{
			_activeSequence.Goto(_skipTo, true);
			_activeSequence = null;
		}
	}

	public void Show(IStockable p, FinalReviewGenerator.Review[] reviews)
	{
		if (Window.Shown)
		{
			_queue.Add(new KeyValuePair<IStockable, FinalReviewGenerator.Review[]>(p, reviews));
			return;
		}
		_marketingTeams.Clear();
		_marketingTeams.AddRange(GameSettings.Instance.GetDefaultTeams("Market"));
		_companyWorker = null;
		UpdateTeamLabel();
		LogoImage.texture = HardwareDesignRenderer.Instance.RenderProduct(p as IDisplayable, 256, true);
		_target = p;
		Label.text = p.GetName() + " released!";
		Window.rectTransform.sizeDelta = Vector2.zero;
		CloseButton.sizeDelta = Vector2.zero;
		FadePanel.sizeDelta = Vector2.zero;
		for (int i = 0; i < Reviewers.Length; i++)
		{
			Reviewers[i].ClearReview();
		}
		reviews.Shuffle();
		Logo.localScale = Vector3.zero;
		LogoBack.localScale = Vector3.zero;
		Window.rectTransform.localScale = Vector3.zero;
		Window.rectTransform.sizeDelta = new Vector2(512f, 500f);
		_activeSequence = DOTween.Sequence();
		float num = Mathf.Min(1f, (float)Screen.height / Options.UISize / 700f);
		_activeSequence.Append(Window.rectTransform.DOScale(Vector3.one * num, ShowSpeed).SetEase(Ease.OutBounce));
		Sequence s = DOTween.Sequence();
		s.Append(Logo.DOScale(Vector3.one, ShowSpeed * 3f).SetEase(Ease.OutElastic));
		s.Join(LogoBack.DOScale(Vector3.one, ShowSpeed * 2f).SetEase(Ease.OutElastic));
		for (int j = 0; j < Reviewers.Length; j++)
		{
			_activeSequence.AppendCallback(delegate
			{
				UISoundFX.PlaySFX(Stamp, 0.75f, UnityEngine.Random.Range(0.95f, 1.05f));
			});
			Reviewers[j].SetReview(reviews[j], _activeSequence);
		}
		_activeSequence.AppendInterval(0.25f);
		_activeSequence.AppendCallback(delegate
		{
			UISoundFX.PlaySFX(KeyboardSFX, 0.75f);
		});
		for (int num2 = 0; num2 < Reviewers.Length; num2++)
		{
			Reviewers[num2].DoReview(num2 == 0, _activeSequence);
		}
		_activeSequence.AppendInterval(0.25f);
		for (int num3 = 0; num3 < Reviewers.Length; num3++)
		{
			Reviewers[num3].DoStar(reviews[num3].Score, _activeSequence, StarBlips, StarEndBlips);
			_activeSequence.AppendInterval(0.5f);
		}
		int num4 = 32;
		bool flag = false;
		_skipTo = _activeSequence.Duration();
		if (CheckMarketing())
		{
			num4 += 50;
			flag = true;
		}
		if (CheckOrder())
		{
			num4 += 50;
			flag = true;
		}
		if (CheckPrint())
		{
			num4 += 50;
			flag = true;
		}
		if (flag)
		{
			_activeSequence.AppendCallback(delegate
			{
				UISoundFX.PlaySFX(Slide);
			});
			_activeSequence.Append(FadePanel.DOSizeDelta(new Vector2(0f, 32f), 0.1f, true));
			_activeSequence.Join(Window.rectTransform.DOSizeDelta(new Vector2(512f, 500 + num4), 1f, true).SetEase(Ease.OutCubic));
			_activeSequence.Append(FadePanel.DOSizeDelta(new Vector2(0f, 0f), 0.5f, true));
			_activeSequence.Join(CloseButton.DOSizeDelta(new Vector2(0f, 32f), 0.5f, true).SetEase(Ease.OutCubic));
		}
		else
		{
			_activeSequence.Join(Window.rectTransform.DOSizeDelta(new Vector2(512f, 500 + num4), 0.5f, true).SetEase(Ease.OutCubic));
			_activeSequence.Append(CloseButton.DOSizeDelta(new Vector2(0f, 32f), 0.5f, true).SetEase(Ease.OutCubic));
		}
		Window.Show();
		Window.rectTransform.anchoredPosition = new Vector2(0f, 316f * num);
		GameSettings.ForcePause = true;
		GameSettings.FreezeGame = true;
		UISoundFX.PlaySFX(Launch);
	}
}

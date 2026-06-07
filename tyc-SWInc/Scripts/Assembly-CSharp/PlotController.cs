using System;
using System.Collections.Generic;
using System.Linq;
using Achievements;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class PlotController : MonoBehaviour
{
	public static PlotController Instance;

	public List<Transform> ArrowPool = new List<Transform>();

	private int _arrowCount;

	public RectTransform rect;

	public GameObject PlotPanel;

	public GameObject CancelButton;

	public GameObject PaymentPanel;

	public Image Header;

	public Text ButtonLabel;

	public Button ActionButton;

	public Slider UpfrontSlider;

	public Slider MonthSlider;

	public VarValueSheet Info;

	[NonSerialized]
	private HashSet<PlotArea> _networkWait = new HashSet<PlotArea>();

	[NonSerialized]
	private PlotArea _currentPlot;

	private bool _changingSliders;

	public PlotArea CurrentPlot
	{
		get
		{
			return _currentPlot;
		}
		set
		{
			if (_currentPlot != null && _currentPlot.PlotObject != null)
			{
				_currentPlot.PlotObject.UpdatePlayerOwned();
			}
			ClearArrows();
			_currentPlot = value;
			if (CurrentPlot != null && GameSettings.Instance.PlotAdjacency)
			{
				if (CurrentPlot.Neighbors == null)
				{
					GameSettings.Instance.CalculatePlotNeighbors();
				}
				Vector3 vector = CurrentPlot.Center.ToVector3();
				foreach (uint neighbor in CurrentPlot.Neighbors)
				{
					PlotArea plot = GameSettings.Instance.GetPlot(neighbor);
					Transform arrow = GetArrow();
					arrow.position = vector;
					Vector3 forward = plot.Center - vector;
					float magnitude = forward.magnitude;
					arrow.localScale = new Vector3(1f, magnitude / 2f, magnitude);
					arrow.rotation = Quaternion.LookRotation(forward);
				}
			}
			if (_currentPlot != null && _currentPlot.PlotObject != null)
			{
				_currentPlot.PlotObject.Renderer.material.color = _currentPlot.PlotColor.ToColor().Alpha(1f);
			}
		}
	}

	public Transform GetArrow()
	{
		Transform transform;
		if (_arrowCount < ArrowPool.Count)
		{
			transform = ArrowPool[_arrowCount];
		}
		else
		{
			transform = UnityEngine.Object.Instantiate(ArrowPool[0]);
			transform.transform.SetParent(base.transform);
			ArrowPool.Add(transform);
		}
		transform.gameObject.SetActive(true);
		_arrowCount++;
		return transform;
	}

	public void ClearArrows()
	{
		ArrowPool.ForEach(delegate(Transform x)
		{
			x.gameObject.SetActive(false);
		});
		_arrowCount = 0;
	}

	public void EnableCancelButton(bool enable)
	{
		if (!_changingSliders)
		{
			CancelButton.SetActive(enable);
		}
	}

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(Instance);
		}
		Instance = this;
		base.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public static List<Room> FindDestroyedRooms(PlotArea plot)
	{
		List<Room> list = new List<Room>();
		foreach (Room room in GameSettings.Instance.sRoomManager.Rooms)
		{
			if (!GameSettings.Instance.PlayerOwnedArea(room.Edges.Select((WallEdge x) => x.Pos).ToList(), true, plot))
			{
				list.Add(room);
			}
		}
		return list;
	}

	private void SellPlot(PlotArea plot, List<Room> destroyed)
	{
		if (plot.MonthsLeft == 0)
		{
			UISoundFX.PlaySFX("Kaching");
			GameSettings.Instance.MyCompany.MakeTransaction(plot.Price, Company.TransactionCategory.Construction, false, "Plot");
			List<UndoObject.UndoAction> list = GameSettings.Instance.SellPlot(plot, destroyed, true);
			if (!GameSettings.Instance.IsNetworkMode)
			{
				list.Insert(0, new UndoObject.UndoAction(plot, plot.Price));
				GameSettings.Instance.AddUndo(list.ToArray());
			}
			else
			{
				GameSettings.Instance.ResetUndo();
			}
		}
		else
		{
			float num = plot.Price - (float)plot.MonthsLeft * plot.Monthly;
			if (GameSettings.Instance.MyCompany.CanMakeTransaction(num))
			{
				UISoundFX.PlaySFX("Kaching");
				GameSettings.Instance.MyCompany.MakeTransaction(num, Company.TransactionCategory.Construction, false, "Plot");
				List<UndoObject.UndoAction> list2 = GameSettings.Instance.SellPlot(plot, destroyed, true);
				if (!GameSettings.Instance.IsNetworkMode)
				{
					list2.Insert(0, new UndoObject.UndoAction(plot, num));
					GameSettings.Instance.AddUndo(list2.ToArray());
				}
				else
				{
					GameSettings.Instance.ResetUndo();
				}
				plot.MonthsLeft = 0;
			}
			else
			{
				HUD.FlashMoney();
				UISoundFX.PlaySFX("BuildError");
			}
		}
		GameSettings.Instance.TransmitExtraWorth();
	}

	public void ActualBuy(PlotArea plot, float fullPrice, float upFront, float addon)
	{
		List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
		UISoundFX.PlaySFX("Kaching");
		GameSettings.Instance.MyCompany.MakeTransaction(0f - upFront, Company.TransactionCategory.Construction, false, "Plot");
		GameSettings.Instance.MyCompany.AddTax(TaxReport.TaxType.Depreciation, 0f - addon);
		float num = fullPrice - upFront;
		if (num > 0f)
		{
			float interest = GetInterest();
			float num2 = MonthSlider.value * 6f;
			plot.MonthsLeft = (int)num2;
			plot.Monthly = num / num2 * (1f + interest);
			plot.MonthlyInterest = num / num2 * interest;
		}
		list.AddRange(GameSettings.Instance.BuyPlot(plot, true));
		if (!GameSettings.Instance.IsNetworkMode)
		{
			list.Add(new UndoObject.UndoAction(plot, upFront, addon));
			GameSettings.Instance.AddUndo(list.ToArray());
		}
		else
		{
			GameSettings.Instance.ResetUndo();
		}
		GameSettings.Instance.TransmitExtraWorth();
	}

	public void Buy()
	{
		if (CurrentPlot != null)
		{
			if (CurrentPlot.PlayerOwned)
			{
				List<Room> destroyed = FindDestroyedRooms(CurrentPlot);
				if (destroyed.Count == 0)
				{
					SellPlot(CurrentPlot, destroyed);
				}
				else
				{
					PlotArea p = CurrentPlot;
					WindowManager.Instance.ShowMessageBox("SellPlotWarning".Loc(), true, DialogWindow.DialogType.Warning, delegate
					{
						SellPlot(p, destroyed);
					}, "SellPlotWarningQ");
				}
			}
			else if (CurrentPlot.Owner > 0)
			{
				PlotArea plot = CurrentPlot;
				NetworkPlayer pl = NetworkManager.GetPlayer(plot.Owner);
				if (CurrentPlot.PlayerStarterPlot)
				{
					if (NetworkManager.IsHost && (pl == null || !pl.Connected))
					{
						Company playerCompany = MarketSimulation.Active.GetPlayerCompany(plot.Owner);
						if (playerCompany != null)
						{
							List<Company> list = playerCompany.GenerateStockCompanyList();
							playerCompany.BuyOut((list == null || list.Count == 0) ? null : list, false, SDateTime.Now(), false);
							GameSettings.Instance.ClearBuyouts();
							UpdateText();
						}
					}
				}
				else if (pl != null)
				{
					NetworkManager.Instance.TradeController.CreateOffer(pl, plot.Price, (uint id, float offer) => new PlotTrade(id, NetworkManager.Self, pl, plot, offer), plot);
				}
			}
			else
			{
				float price = CurrentPlot.Price;
				float addon = CurrentPlot.AddonCost;
				float fullPrice = price + addon;
				float upFront = fullPrice;
				if (UpfrontSlider.value < 1f)
				{
					upFront = fullPrice * UpfrontSlider.value;
				}
				if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - upFront))
				{
					PlotArea p2 = CurrentPlot;
					NetworkMessaging.VerifiedNetworkMessage(NetworkMessaging.SyncType.Plot, CurrentPlot.ID, CurrentPlot.Owner, NetworkManager.LocalPlayerID, delegate(bool x)
					{
						_networkWait.Remove(p2);
						if (x)
						{
							ActualBuy(p2, fullPrice, upFront, addon);
						}
						UpdateText();
					}, null, delegate
					{
						_networkWait.Add(p2);
						UpdateText();
					});
				}
				else
				{
					HUD.FlashMoney();
					UISoundFX.PlaySFX("BuildError");
				}
			}
			EnableCancelButton(false);
		}
		UpdateText();
	}

	public void Toggle()
	{
		base.gameObject.SetActive(!base.gameObject.activeSelf);
	}

	private void OnEnable()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			if (GameSettings.Instance.RentMode)
			{
				base.gameObject.SetActive(false);
				return;
			}
			foreach (PlotArea plot in GameSettings.Instance.GetPlots())
			{
				plot.PlotObject.EdgeRenderer.enabled = true;
			}
		}
		if (BuildController.Instance != null)
		{
			BuildController.Instance.ClearBuild(false, false, true);
			HUD.Instance.BuildModeMainButtons[4].GetComponent<Button>().ChangeMainColor(HUD.GetThemeColor(0), true);
			HUD.Instance.BuildModeMainButtons[4].GetComponentsInChildren<Image>()[1].color = Color.white;
			AchievementController.SetInteraction(AchievementController.Mechanics.Plots);
		}
	}

	private void OnDisable()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (PlotPanel != null)
		{
			PlotPanel.SetActive(false);
		}
		CurrentPlot = null;
		foreach (PlotArea plot in GameSettings.Instance.GetPlots())
		{
			if (plot.PlotObject != null)
			{
				plot.PlotObject.EdgeRenderer.enabled = false;
			}
		}
		if (HUD.Instance != null)
		{
			HUD.Instance.UpdateBorderOverlay();
			HUD.Instance.BuildModeMainButtons[4].GetComponent<Button>().ChangeMainColor(Color.white, true);
			HUD.Instance.BuildModeMainButtons[4].GetComponentsInChildren<Image>()[1].color = new Color(0.2f, 0.2f, 0.2f);
		}
	}

	public void UpdateText()
	{
		if (CurrentPlot == null)
		{
			return;
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		list.AddRange("Plotarea".Loc(), "Price".Loc());
		list2.AddRange(CurrentPlot.Area.ToString("N0") + " m2", CurrentPlot.Price.Currency());
		if (CurrentPlot.AddonCost > 0f)
		{
			list.Add("Addedvaluation".Loc());
			list2.Add(CurrentPlot.AddonCost.Currency());
		}
		ButtonLabel.text = (CurrentPlot.PlayerOwned ? "Sell".Loc() : "Buy".Loc());
		ActionButton.interactable = true;
		if (CurrentPlot.PlayerOwned)
		{
			PaymentPanel.SetActive(false);
			if (CurrentPlot.MonthsLeft > 0)
			{
				list.AddRange("Monthly".Loc(), "Monthsleft".Loc(), "Balance".Loc());
				list2.AddRange(CurrentPlot.Monthly.Currency(), CurrentPlot.MonthsLeft.ToString(), (CurrentPlot.Price - (float)CurrentPlot.MonthsLeft * CurrentPlot.Monthly).Currency());
			}
		}
		else if (CurrentPlot.Owner != 0)
		{
			PaymentPanel.SetActive(false);
			NetworkPlayer player = NetworkManager.GetPlayer(CurrentPlot.Owner);
			list.Add("Ownedby".Loc());
			list2.Add((player == null) ? "AnotherPlayer".Loc() : player.Name);
		}
		else
		{
			PaymentPanel.SetActive(!_networkWait.Contains(CurrentPlot));
			if (UpfrontSlider.value < 1f)
			{
				float num = CurrentPlot.Price + CurrentPlot.AddonCost;
				float num2 = num * UpfrontSlider.value;
				float num3 = num - num2;
				float interest = GetInterest();
				float num4 = MonthSlider.value * 6f;
				float num5 = num3 / num4 * (1f + interest);
				list.AddRange("Downpayment".Loc(), "Monthly".Loc(), "Months".Loc(), "Total".Loc());
				list2.AddRange(num2.Currency(), num5.Currency(), num4.ToString("N0"), (num4 * num5 + num2).Currency());
			}
		}
		if (GameSettings.Instance.IsNetworkMode && CurrentPlot.PlayerStarterPlot)
		{
			if (NetworkManager.IsHost && CurrentPlot.Owner > 0 && !CurrentPlot.PlayerOwned)
			{
				NetworkPlayer player2 = NetworkManager.GetPlayer(CurrentPlot.Owner);
				if (player2 == null || !player2.Connected)
				{
					ActionButton.interactable = true;
					ButtonLabel.text = "KickPlayer".Loc();
					PaymentPanel.SetActive(true);
				}
			}
			else
			{
				ActionButton.interactable = false;
				PaymentPanel.SetActive(false);
			}
		}
		else if (!CurrentPlot.PlayerOwned && GameSettings.Instance.PlotAdjacency && !GameSettings.Instance.CanReachPlot(CurrentPlot))
		{
			list.Add("NoAdjacentPlot".Loc().FontColor(Color.red));
			list2.Add("");
			ActionButton.interactable = false;
			PaymentPanel.SetActive(false);
		}
		Info.SetData(list.ToArray(), list2.ToArray());
	}

	private float GetInterest()
	{
		return 0.06f + Mathf.Pow(MonthSlider.value / 12f, 1.2f) / 2f;
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (GameSettings.FreezeGame)
		{
			CurrentPlot = null;
			PlotPanel.SetActive(false);
			return;
		}
		if (!CameraScript.WasDragging && Input.GetMouseButtonUp(1))
		{
			base.gameObject.SetActive(false);
			return;
		}
		if (CurrentPlot != null && CancelButton.activeSelf)
		{
			MoveWindow(CurrentPlot);
			return;
		}
		if (CurrentPlot != null && RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition, UICamSize.GetUICam()))
		{
			GUICheck.OverGUI = false;
			MoveWindow(CurrentPlot);
			return;
		}
		Vector2 mouseProj = HUD.Instance.GetMouseProj();
		if (CurrentPlot != null && Utilities.IsInside(mouseProj, CurrentPlot.Polygon))
		{
			MoveWindow(CurrentPlot);
			return;
		}
		foreach (PlotArea plot in GameSettings.Instance.GetPlots())
		{
			if (Utilities.IsInside(mouseProj, plot.Polygon))
			{
				Header.color = plot.PlotColor;
				MoveWindow(plot);
				if (plot != CurrentPlot)
				{
					UISoundFX.PlaySFX("HighlightTick");
				}
				CurrentPlot = plot;
				_changingSliders = true;
				MonthSlider.value = 10f;
				float price = plot.Price;
				UpfrontSlider.value = (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - price) ? 1f : ((float)Utilities.Clamp01(GameSettings.Instance.MyCompany.Money * 0.25 / (double)plot.Price)));
				_changingSliders = false;
				UpdateText();
				PlotPanel.SetActive(true);
				return;
			}
		}
		CurrentPlot = null;
		CancelButton.SetActive(false);
		PlotPanel.SetActive(false);
	}

	private void MoveWindow(PlotArea plot)
	{
		Vector3 vector = CameraScript.Instance.SSAScript.WorldToScreenPoint(plot.Center + Vector3.up * ((float)GameSettings.Instance.ActiveFloor * 2f)) * (1f / Options.UISize);
		float num = rect.rect.height / 2f;
		float x = HUD.Instance.MainContentPanel.offsetMin.x;
		rect.anchoredPosition = new Vector2(Mathf.Clamp(vector.x - x, 128f, (float)Screen.width / Options.UISize - 128f), Mathf.Clamp((float)(-Screen.height) / Options.UISize + vector.y, (float)(-Screen.height) / Options.UISize + 256f + num, -48f - num));
	}
}

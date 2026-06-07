using Localization;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesView : ActiveComponent
{
	[SceneBind("DayProgressBack/DayProgress")]
	private Image _dayProgress;

	[SceneBind("DayBtn/DayText")]
	private Text _dayText;

	[SceneBind("DayBtn/DayTextCh")]
	private Text _dayTextCh;

	[SceneBind("CreditLayer/CreditText")]
	private Text CreditText;

	[SceneBind("CreditLayer")]
	private CreditsController Credit;

	[SceneBind("DayBtn/WeekText")]
	private Text weekText;

	[SceneBind("DayBtn/WeekTextCh")]
	private Text weekTextCh;

	[SceneBind("AddMoney")]
	private Button addMoney;

	[SceneBind("MoneyText")]
	private Text _moneyText;

	[SceneBind("SubscribersText")]
	private Text _subscribersText;

	[SceneBind("Buggle/UnitPrev")]
	private Image unitPrev;

	[SceneBind("Buggle/UnitPlayer")]
	private Image unitPlayer;

	[SceneBind("Buggle/UnitNext")]
	private Image unitNext;

	public double _drawedMoney;

	public long maxDrawedMoney;

	private double _drawedSubscribers;

	private float _moneySpeed = 1f;

	private float _subscribersSpeed;

	private const float DRAW_TIME = 2f;

	private long _money;

	private long _subscribers;

	private bool startDrawMoney;

	public void AddMoneyClick()
	{
		ActiveComponent.Model.P.Money += 10000L;
		Redraw();
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		addMoney.onClick.AddListener(AddMoneyClick);
		addMoney.gameObject.SetActive(value: false);
		Credit.Init();
		if (ActiveComponent.Model.globalSaves.lang == 2 || ActiveComponent.Model.globalSaves.lang == 3)
		{
			weekText.gameObject.SetActive(value: false);
			_dayText.gameObject.SetActive(value: false);
		}
		else
		{
			weekTextCh.gameObject.SetActive(value: false);
			_dayTextCh.gameObject.SetActive(value: false);
		}
	}

	public void InitRedraw()
	{
		_drawedMoney = ActiveComponent.Model.P.Money;
		Redraw();
	}

	public void CreditRedraw()
	{
		if (ActiveComponent.Model.P.credits.Count == 0)
		{
			Credit.gameObject.SetActive(value: false);
			return;
		}
		Credit.gameObject.SetActive(value: true);
		Credit.Redraw();
	}

	public void Redraw()
	{
		weekText.text = TextResources.GetString("WEEK") + " " + ActiveComponent.Model.P.Weeks;
		_dayTextCh.text = TextResources.GetString("WEEK_DAY_" + (ActiveComponent.Model.P.Days % 7 + 1));
		weekTextCh.text = TextResources.GetString("WEEK_CH").Replace("#NUM", ActiveComponent.Model.P.Weeks.ToString());
		_dayText.text = TextResources.GetString("DAY") + " " + (ActiveComponent.Model.P.Days % 7 + 1) + " / 7";
		if (ActiveComponent.Model.drawedMoneySpeed > 0f && (int)_drawedMoney >= 0)
		{
			_moneyText.text = Logic.ColorTransform("MONEY", (int)_drawedMoney + "$");
		}
		else
		{
			_moneyText.text = Logic.ColorTransform("BAD", (int)_drawedMoney + "$");
		}
	}

	private void Update()
	{
		if (ActiveComponent.Model == null || ActiveComponent.Model.P == null)
		{
			return;
		}
		ActiveComponent.Model.drawnMoney = (int)_drawedMoney;
		if ((int)_drawedMoney != ActiveComponent.Model.P.Money)
		{
			if (!startDrawMoney)
			{
				_moneySpeed = Mathf.Abs((float)((double)ActiveComponent.Model.P.Money - _drawedMoney) / 2f);
				ActiveComponent.Model.drawedMoneySpeed = (float)((double)ActiveComponent.Model.P.Money - _drawedMoney) / 2f;
			}
			startDrawMoney = true;
			_drawedMoney = UnityUtils.MoveTowards(_drawedMoney, ActiveComponent.Model.P.Money, _moneySpeed * Time.deltaTime);
			ActiveComponent.Model.drawnMoney = (int)_drawedMoney;
		}
		else
		{
			ActiveComponent.Model.drawedMoneySpeed = 1f;
			startDrawMoney = false;
		}
		Redraw();
		if (maxDrawedMoney != ActiveComponent.Model.P.Money)
		{
			maxDrawedMoney = ActiveComponent.Model.P.Money;
			ActiveComponent.Model.drawedMoneySpeed = 1f;
			startDrawMoney = false;
		}
	}
}

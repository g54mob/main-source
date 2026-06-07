using I2.Loc;
using UnityEngine.UI;

public class WorkerUI : OverlayUI
{
	public static WorkerUI I;

	public CoolButton BtnClose;

	public GridLayoutGroup WorkerGrid;

	public CoolButtonGroup WorkerGrp;

	public GridSection WorkerGridSection;

	private WorkerItem _selectedItem;

	public SerializedObjectPool<WorkerItem> ItemPool;

	public LocalizationParamsManager ParamsNumWorkers;

	public CoolButton BtnSendOut;

	private CharMetaInst _pendingWorkerRemoval;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void RefreshNav()
	{
	}

	private void OnResolutionChanged()
	{
	}

	public override void Activate()
	{
	}

	public override void Deactivate()
	{
	}

	protected override void OnEntryComplete()
	{
	}

	protected override void MyUpdate()
	{
	}

	private void SelectBtnWithChar(CharMetaInst c)
	{
	}

	public void RefreshList()
	{
	}

	private void OnWorkersChanged()
	{
	}

	public int GetNumActiveWorkers()
	{
		return 0;
	}

	private void OnCloseClicked()
	{
	}

	public override void OnUnderlayClicked()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	public void SelectItem(WorkerItem w)
	{
	}

	private void OnSendOutClicked()
	{
	}

	private void OnGrpEntered(CoolButton btn)
	{
	}

	private void OnGrpNav(CoolButton btnPrev, CoolButton btnNext)
	{
	}

	private void OnGrpExited(CoolButton btn)
	{
	}
}

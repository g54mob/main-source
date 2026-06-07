using TMPro;
using UnityEngine;

public class WorkerInteractUIScreen : CSingleton<WorkerInteractUIScreen>
{
	public ControllerScreenUIExtension m_ControllerScreenUIExtension;

	public GameObject m_ScreenGrp;

	public WorkerOptionUIScreen m_WorkerOptionUIScreen;

	public WorkerOptionSetPriceUIScreen m_WorkerOptionSetPriceUIScreen;

	public WorkerSetPrimarySecondaryTaskScreen m_WorkerSetPrimarySecondaryTaskScreen;

	public WorkerSetPackOpenerTypeOptionScreen m_WorkerSetPackOpenerTypeOptionScreen;

	public TextMeshProUGUI m_CurrentTaskText;

	public TextMeshProUGUI m_SecondaryTaskText;

	public TextMeshProUGUI m_CheckoutSpeedText;

	public TextMeshProUGUI m_RestockSpeedText;

	public TextMeshProUGUI m_SalaryCostText;

	private Worker m_Worker;

	private EWorkerTask m_TaskToSet;

	public static void OpenScreen(Worker worker)
	{
		CSingleton<WorkerInteractUIScreen>.Instance.m_Worker = worker;
		CSingleton<WorkerInteractUIScreen>.Instance.m_CurrentTaskText.text = WorkerManager.GetTaskName(CSingleton<WorkerInteractUIScreen>.Instance.m_Worker.m_PrimaryTask);
		CSingleton<WorkerInteractUIScreen>.Instance.m_SecondaryTaskText.text = WorkerManager.GetTaskName(CSingleton<WorkerInteractUIScreen>.Instance.m_Worker.m_SecondaryTask);
		CSingleton<WorkerInteractUIScreen>.Instance.m_CheckoutSpeedText.text = CSingleton<WorkerInteractUIScreen>.Instance.m_Worker.GetWorkerData().GetCheckoutSpeedText();
		CSingleton<WorkerInteractUIScreen>.Instance.m_RestockSpeedText.text = CSingleton<WorkerInteractUIScreen>.Instance.m_Worker.GetWorkerData().GetRestockSpeedText();
		CSingleton<WorkerInteractUIScreen>.Instance.m_SalaryCostText.text = CSingleton<WorkerInteractUIScreen>.Instance.m_Worker.GetWorkerData().GetSalaryCostText();
		CSingleton<WorkerInteractUIScreen>.Instance.m_ScreenGrp.SetActive(value: true);
		SoundManager.GenericMenuOpen();
		ControllerScreenUIExtManager.OnOpenScreen(CSingleton<WorkerInteractUIScreen>.Instance.m_ControllerScreenUIExtension);
	}

	public void CloseScreen()
	{
		m_ScreenGrp.SetActive(value: false);
		SoundManager.GenericMenuClose();
		ControllerScreenUIExtManager.OnCloseScreen(CSingleton<WorkerInteractUIScreen>.Instance.m_ControllerScreenUIExtension);
	}

	public void SetTaskAsPrimaryOrSecondary(bool isPrimary)
	{
		m_ScreenGrp.SetActive(value: true);
		EWorkerTask taskToSet = m_TaskToSet;
		m_Worker.SetTaskSettingPrimarySecondary(isPrimary);
		if (m_TaskToSet == EWorkerTask.RestockShelf)
		{
			m_WorkerOptionUIScreen.OpenScreen(m_Worker, (int)taskToSet);
			CloseScreen();
			return;
		}
		if (m_TaskToSet == EWorkerTask.SetPrice)
		{
			m_WorkerOptionSetPriceUIScreen.OpenScreen(m_Worker);
			CloseScreen();
			return;
		}
		if (m_TaskToSet == EWorkerTask.RefillCardOpener)
		{
			m_WorkerSetPackOpenerTypeOptionScreen.OpenScreen(m_Worker);
			CloseScreen();
			return;
		}
		if (isPrimary)
		{
			m_Worker.SetTask(m_TaskToSet);
			m_Worker.SetLastTask(m_TaskToSet);
		}
		else
		{
			m_Worker.SetSecondaryTask(m_TaskToSet);
		}
		SoundManager.GenericConfirm();
		m_Worker.OnPressStopInteract();
		CloseScreen();
	}

	public void OnPressAssignTask(int taskIndex)
	{
		m_TaskToSet = (EWorkerTask)taskIndex;
		m_WorkerSetPrimarySecondaryTaskScreen.OpenScreen();
		CloseScreen();
	}

	public void OnPressFire()
	{
		m_Worker.FireWorker();
		SoundManager.GenericConfirm();
		m_Worker.OnPressStopInteract();
		CloseScreen();
	}

	public void OnPressCancel()
	{
		m_Worker.OnPressStopInteract();
		SoundManager.GenericCancel();
		CloseScreen();
	}
}

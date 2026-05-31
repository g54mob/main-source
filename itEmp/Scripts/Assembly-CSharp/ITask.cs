using System.Collections.Generic;
using UnityEngine;

public interface ITask
{
	void SetTaskID(string _taskID);

	string GetTitle();

	string GetDescription();

	string GetTip();

	List<ChapterTask> GetChapterCompletedName();

	bool[] GetChapterCompleted();

	string[] GetAwardsName();

	string[] GetPenaltiesName();

	TaskDataOrderData GetOrderData();

	void SetOrderData(TaskDataOrderData _orderData);

	void SetParameters(Object[] _parameters);

	void PrepareChapterTask();

	void BeforeTask();

	bool Verify();

	void TaskComplet(bool timeExpired);

	void TaskPenaltie();

	void SetFirstShift();

	string SaveTask();

	void LoadTask(string json);
}

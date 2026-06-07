using System;
using System.Collections.Generic;
using MessagePipe;
using R3;
using UnityEngine;

public class OperationsView : MonoBehaviour
{
	[SerializeField]
	private RectTransform operationContainer;

	[SerializeField]
	private OperationVisualizer operationPrefab;

	[SerializeField]
	private RectTransform progressContainer;

	[SerializeField]
	private OperationProgressBar progressPrefab;

	private readonly Queue<OperationProgressBar> _availableProgressBars = new Queue<OperationProgressBar>();

	private readonly Dictionary<string, OperationProgressBar> _operationProgressMap = new Dictionary<string, OperationProgressBar>();

	private void Awake()
	{
		InitializeOperations();
		InitializeProgressBars();
		Database.Modifiers.ObserveAsInt(ModifierType.OperationConcurrentAmount).Subscribe(HandleOperationConcurrency).AddTo(this);
		EventHub.Scene.For().Subscribe(delegate
		{
			InitializeProgressBars();
		}, Array.Empty<MessageHandlerFilter<Prestiged>>()).Build(this);
	}

	public void UpdateOperationProgress(OperationInstance instance)
	{
		FetchProgressBar(instance)?.UpdateProgress(instance);
	}

	public void ClearOperationProgress(OperationInstance instance)
	{
		if (_operationProgressMap.TryGetValue(instance.Guid, out var value))
		{
			value.ClearProgress();
			_operationProgressMap.Remove(instance.Guid);
			_availableProgressBars.Enqueue(value);
			value.transform.SetAsLastSibling();
		}
	}

	private OperationProgressBar FetchProgressBar(OperationInstance instance)
	{
		if (_operationProgressMap.TryGetValue(instance.Guid, out var value))
		{
			return value;
		}
		if (!_availableProgressBars.TryDequeue(out value))
		{
			return null;
		}
		_operationProgressMap[instance.Guid] = value;
		value.AssignProgress(instance);
		return value;
	}

	private void InitializeOperations()
	{
		foreach (Transform item in operationContainer)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		foreach (Operation item2 in EnumUtility.GetValuesSkipNone<Operation>())
		{
			UnityEngine.Object.Instantiate(operationPrefab, operationContainer).Setup(item2.Data());
		}
	}

	private void InitializeProgressBars()
	{
		foreach (Transform item in progressContainer)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		_availableProgressBars.Clear();
		_operationProgressMap.Clear();
		for (int i = 0; i < ModifierType.OperationConcurrentAmount.Int(); i++)
		{
			_availableProgressBars.Enqueue(UnityEngine.Object.Instantiate(progressPrefab, progressContainer));
		}
	}

	private void HandleOperationConcurrency(int amount)
	{
		if (amount < progressContainer.childCount)
		{
			Debug.LogWarning("Operation concurrent amount dropped, this should be handled if it ever happens.");
		}
		for (int i = progressContainer.childCount; i < amount; i++)
		{
			_availableProgressBars.Enqueue(UnityEngine.Object.Instantiate(progressPrefab, progressContainer));
		}
	}
}

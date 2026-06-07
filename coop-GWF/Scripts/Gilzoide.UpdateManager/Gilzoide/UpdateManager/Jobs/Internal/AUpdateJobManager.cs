using System;
using System.Collections.Generic;
using Gilzoide.UpdateManager.Extensions;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Gilzoide.UpdateManager.Jobs.Internal
{
	public abstract class AUpdateJobManager<TData, TDataProvider, TJobData> : IJobManager, IUpdatable, IManagedObject, IDisposable where TData : struct where TDataProvider : IInitialJobDataProvider<TData> where TJobData : UpdateJobData<TData, TDataProvider>, new()
	{
		protected readonly Dictionary<TDataProvider, int> _providerIndexMap = new Dictionary<TDataProvider, int>();

		protected readonly List<TDataProvider> _dataProviders = new List<TDataProvider>();

		protected readonly HashSet<TDataProvider> _dataProvidersToAdd = new HashSet<TDataProvider>();

		protected readonly ReversedSortedList<int> _dataProvidersToRemove = new ReversedSortedList<int>();

		protected readonly HashSet<IJobDataSynchronizer<TData>> _dataProvidersToSyncEveryFrame = new HashSet<IJobDataSynchronizer<TData>>();

		protected readonly HashSet<IJobDataSynchronizer<TData>> _dataProvidersToSyncOnce = new HashSet<IJobDataSynchronizer<TData>>();

		protected readonly List<IJobDataSynchronizer<TData>> _hashSetFrozenIterator = new List<IJobDataSynchronizer<TData>>();

		protected readonly TJobData _jobData = new TJobData();

		protected JobHandle _jobHandle;

		protected static readonly bool IsJobBurstCompiled = UpdateJobOptions.GetIsBurstCompiled<TData>();

		private readonly IJobManager[] _dependencyManagers;

		private NativeArray<JobHandle> _dependencyJobHandles;

		private int _lastProcessedFrame;

		private int _dependenciesScheduledCount;

		private bool _isPendingUpdate;

		protected bool HavePendingProviderChanges
		{
			get
			{
				if (_dataProvidersToAdd.Count <= 0)
				{
					return _dataProvidersToRemove.Count > 0;
				}
				return true;
			}
		}

		public event Action<JobHandle> OnJobScheduled;

		protected abstract JobHandle ScheduleJob(JobHandle dependsOn);

		public AUpdateJobManager()
		{
			_dependencyManagers = UpdateJobOptions.GetDependsOnManagers<TData>();
			Application.quitting += Dispose;
		}

		~AUpdateJobManager()
		{
			Application.quitting -= Dispose;
			Dispose();
		}

		public void ManagedUpdate()
		{
			_jobHandle.Complete();
			SynchronizeJobData();
			if (HavePendingProviderChanges)
			{
				RefreshProviders();
			}
			if (_dataProviders.Count == 0)
			{
				Dispose();
				return;
			}
			_jobData.BackupData();
			_isPendingUpdate = false;
			ScheduleJobIfDependenciesMet();
		}

		public void Register(TDataProvider provider)
		{
			Register(provider, syncEveryFrame: false);
		}

		public void Register(TDataProvider provider, bool syncEveryFrame)
		{
			if (syncEveryFrame && provider is IJobDataSynchronizer<TData> item)
			{
				_dataProvidersToSyncEveryFrame.Add(item);
				_dataProvidersToSyncOnce.Remove(item);
			}
			if ((!_providerIndexMap.TryGetValue(provider, out var value) || _dataProvidersToRemove.Contains(value)) && _dataProvidersToAdd.Add(provider) && _dataProviders.Count == 0 && _dataProvidersToAdd.Count == 1)
			{
				StartUpdating();
			}
		}

		public void Unregister(TDataProvider provider)
		{
			_dataProvidersToAdd.Remove(provider);
			if (_providerIndexMap.TryGetValue(provider, out var value))
			{
				_dataProvidersToRemove.Add(value);
			}
			UnregisterSynchronization(provider);
		}

		public void UnregisterSynchronization(TDataProvider provider)
		{
			if (provider is IJobDataSynchronizer<TData> item)
			{
				_dataProvidersToSyncEveryFrame.Remove(item);
				_dataProvidersToSyncOnce.Remove(item);
			}
		}

		public bool IsRegistered(TDataProvider provider)
		{
			if (!_dataProvidersToAdd.Contains(provider))
			{
				if (_providerIndexMap.TryGetValue(provider, out var value))
				{
					return !_dataProvidersToRemove.Contains(value);
				}
				return false;
			}
			return true;
		}

		public TData GetData(TDataProvider provider)
		{
			if (!_providerIndexMap.TryGetValue(provider, out var value))
			{
				return provider.InitialJobData;
			}
			return _jobData[value];
		}

		public void SynchronizeJobDataOnce(TDataProvider provider)
		{
			if (IsRegistered(provider) && provider is IJobDataSynchronizer<TData> item && !_dataProvidersToSyncEveryFrame.Contains(item))
			{
				_dataProvidersToSyncOnce.Add(item);
			}
		}

		public void Dispose()
		{
			_jobHandle.Complete();
			_jobData.Dispose();
			_providerIndexMap.Clear();
			_dataProviders.Clear();
			_dataProvidersToAdd.Clear();
			_dataProvidersToRemove.Clear();
			_dataProvidersToSyncEveryFrame.Clear();
			_dataProvidersToSyncOnce.Clear();
			StopUpdating();
		}

		private void RefreshProviders()
		{
			RemovePendingProviders();
			int newSize = _dataProviders.Count + _dataProvidersToAdd.Count;
			_jobData.EnsureCapacity(newSize);
			AddPendingProviders();
		}

		private void RemovePendingProviders()
		{
			if (_dataProvidersToRemove.Count == 0)
			{
				return;
			}
			foreach (int item in _dataProvidersToRemove)
			{
				_providerIndexMap.Remove(_dataProviders[item]);
				_dataProviders.RemoveAtSwapBack(item, out var swappedValue);
				if (swappedValue != null)
				{
					_providerIndexMap[swappedValue] = item;
				}
				_jobData.RemoveAtSwapBack(item);
			}
			_dataProvidersToRemove.Clear();
		}

		private void AddPendingProviders()
		{
			if (_dataProvidersToAdd.Count == 0)
			{
				return;
			}
			foreach (TDataProvider item in _dataProvidersToAdd)
			{
				int count = _dataProviders.Count;
				_jobData.Add(item, count);
				_providerIndexMap[item] = count;
				_dataProviders.Add(item);
			}
			_dataProvidersToAdd.Clear();
		}

		private void SynchronizeJobData()
		{
			SynchronizeJobData(_dataProvidersToSyncEveryFrame);
			SynchronizeJobData(_dataProvidersToSyncOnce);
			_dataProvidersToSyncOnce.Clear();
		}

		private void SynchronizeJobData(HashSet<IJobDataSynchronizer<TData>> synchronizers)
		{
			if (synchronizers.Count == 0)
			{
				return;
			}
			_hashSetFrozenIterator.AddRange(synchronizers);
			foreach (IJobDataSynchronizer<TData> item in _hashSetFrozenIterator)
			{
				if (_providerIndexMap.TryGetValue((TDataProvider)item, out var value))
				{
					try
					{
						item.SyncJobData(ref _jobData.DataRef.ItemRefAt(value));
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			_hashSetFrozenIterator.Clear();
		}

		private void StartUpdating()
		{
			_isPendingUpdate = true;
			NativeArrayExtensions.DisposeIfCreated(ref _dependencyJobHandles);
			_dependencyJobHandles = new NativeArray<JobHandle>(_dependencyManagers.Length, Allocator.Persistent);
			for (int i = 0; i < _dependencyManagers.Length; i++)
			{
				_dependencyManagers[i].OnJobScheduled += ScheduleJobIfDependenciesMet;
			}
			UpdateManager.Instance.Register(this);
		}

		private void StopUpdating()
		{
			UpdateManager.Instance.Unregister(this);
			for (int i = 0; i < _dependencyManagers.Length; i++)
			{
				_dependencyManagers[i].OnJobScheduled -= ScheduleJobIfDependenciesMet;
			}
			NativeArrayExtensions.DisposeIfCreated(ref _dependencyJobHandles);
		}

		private void ScheduleJobIfDependenciesMet()
		{
			if (AreAllDependenciesFulfilled())
			{
				_isPendingUpdate = true;
				_jobHandle = ScheduleJob(JobHandle.CombineDependencies(_dependencyJobHandles));
				this.OnJobScheduled?.Invoke(_jobHandle);
			}
		}

		private void ScheduleJobIfDependenciesMet(JobHandle dependecyJobHandle)
		{
			MarkDependencyMet();
			_dependencyJobHandles[_dependenciesScheduledCount - 1] = dependecyJobHandle;
			ScheduleJobIfDependenciesMet();
		}

		private bool AreAllDependenciesFulfilled()
		{
			if (!_isPendingUpdate)
			{
				return _dependenciesScheduledCount >= _dependencyJobHandles.Length;
			}
			return false;
		}

		private void MarkDependencyMet()
		{
			int frameCount = Time.frameCount;
			if (frameCount != _lastProcessedFrame)
			{
				_dependenciesScheduledCount = 0;
				_lastProcessedFrame = frameCount;
			}
			_dependenciesScheduledCount++;
		}
	}
}

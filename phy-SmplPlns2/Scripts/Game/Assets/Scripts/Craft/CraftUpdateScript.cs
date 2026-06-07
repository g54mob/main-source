using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Craft.Parts;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class CraftUpdateScript : MonoBehaviour
	{
		private readonly struct OneTimeExecutionKey : IEquatable<OneTimeExecutionKey>
		{
			public readonly CraftUpdateFlags Flags;

			public readonly MethodInfo Method;

			public readonly UnityEngine.Object Object;

			public OneTimeExecutionKey(UnityEngine.Object obj, MethodInfo method, CraftUpdateFlags flags)
			{
				Object = obj;
				Method = method;
				Flags = flags;
			}

			public bool Equals(OneTimeExecutionKey other)
			{
				if (Object == other.Object && Method == other.Method)
				{
					return Flags == other.Flags;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is OneTimeExecutionKey oneTimeExecutionKey)
				{
					if (Object == oneTimeExecutionKey.Object && Method == oneTimeExecutionKey.Method)
					{
						return Flags == oneTimeExecutionKey.Flags;
					}
					return false;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return Object.GetHashCode() ^ Method.GetHashCode() ^ (int)Flags;
			}
		}

		private struct PausedRigidBodyData
		{
			public Vector3 AngularVelocity;

			public bool IsKinematic;

			public Vector3 Velocity;
		}

		private readonly struct UpdateGroupKey : IEquatable<UpdateGroupKey>, IComparable<UpdateGroupKey>
		{
			public readonly int ExecutionOrder;

			public readonly CraftUpdateFlags Flags;

			public readonly MethodInfo TargetMethod;

			public UpdateGroupKey(MethodInfo targetMethod, CraftUpdateFlags flags, int executionOrder)
			{
				TargetMethod = targetMethod;
				Flags = flags;
				ExecutionOrder = executionOrder;
			}

			public int CompareTo(UpdateGroupKey other)
			{
				if (ExecutionOrder < other.ExecutionOrder)
				{
					return -1;
				}
				if (ExecutionOrder > other.ExecutionOrder)
				{
					return 1;
				}
				return 0;
			}

			public override bool Equals(object obj)
			{
				if (obj is UpdateGroupKey updateGroupKey)
				{
					if (TargetMethod == updateGroupKey.TargetMethod && Flags == updateGroupKey.Flags)
					{
						return ExecutionOrder == updateGroupKey.ExecutionOrder;
					}
					return false;
				}
				return false;
			}

			public bool Equals(UpdateGroupKey other)
			{
				if (TargetMethod == other.TargetMethod && Flags == other.Flags)
				{
					return ExecutionOrder == other.ExecutionOrder;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (int)((uint)TargetMethod.GetHashCode() ^ (uint)Flags) ^ ExecutionOrder;
			}
		}

		private struct UpdateItem
		{
			public readonly CraftUpdateDelegate Delegate;

			public readonly UnityEngine.Object Object;

			public readonly int ObjectId;

			public readonly ProfilerMarker ProfilerMarker;

			public UpdateItem(UnityEngine.Object obj, CraftUpdateDelegate updateDelegate)
			{
				Object = obj;
				ObjectId = obj.GetInstanceID();
				Delegate = updateDelegate;
				ProfilerMarker = default(ProfilerMarker);
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker<int> BodyScriptFixedUpdate = new ProfilerMarker<int>("BodyScript.OnFixedUpdate", "Script Count");

			public static readonly ProfilerMarker<int> BodyScriptUpdate = new ProfilerMarker<int>("BodyScript.OnUpdate", "Script Count");

			public static readonly ProfilerMarker CraftScriptFixedUpdate = new ProfilerMarker("AircraftScript.OnFixedUpdate");

			public static readonly ProfilerMarker CraftScriptLateUpdate = new ProfilerMarker("AircraftScript.OnLateUpdate");

			public static readonly ProfilerMarker CraftScriptUpdate = new ProfilerMarker("AircraftScript.OnUpdate");

			public static readonly ProfilerMarker<int> PartMaterialScriptLateUpdate = new ProfilerMarker<int>("PartMaterialScript.OnLateUpdate", "Script Count");

			public static readonly ProfilerMarker<int> PartScriptFixedUpdate = new ProfilerMarker<int>("PartScript.OnFixedUpdate", "Script Count");

			public static readonly ProfilerMarker<int> PartScriptLateUpdate = new ProfilerMarker<int>("PartScript.OnLateUpdate", "Script Count");
		}

		private class UpdateGroup
		{
			public readonly UpdateGroupCollection Collection;

			public readonly int ExecutionOrder;

			public readonly CraftUpdateFlags Flags;

			public readonly Dictionary<int, int> IndexLookup;

			public readonly ProfilerMarker<int> ProfilerMarker;

			public readonly MethodInfo TargetMethod;

			public UpdateItem[] Items;

			private int _count;

			public int Count => _count;

			public UpdateGroupKey Key => new UpdateGroupKey(TargetMethod, Flags, ExecutionOrder);

			public UpdateGroup(UpdateGroupCollection collection, MethodInfo targetMethod, CraftUpdateFlags flags, int executionOrder)
			{
				Collection = collection;
				TargetMethod = targetMethod;
				Flags = flags;
				ExecutionOrder = executionOrder;
				Items = new UpdateItem[10];
				IndexLookup = new Dictionary<int, int>();
				ProfilerMarker = new ProfilerMarker<int>(targetMethod.DeclaringType.Name + "." + targetMethod.Name, "Script Count");
			}

			public void Add(UpdateItem item)
			{
				if (_count == Items.Length)
				{
					Array.Resize(ref Items, Items.Length * 2);
				}
				Items[_count] = item;
				IndexLookup[item.ObjectId] = _count;
				_count++;
			}

			public void Remove(int objectId)
			{
				if (IndexLookup.TryGetValue(objectId, out var value))
				{
					_count--;
					if (value != _count)
					{
						UpdateItem updateItem = Items[_count];
						int objectId2 = updateItem.ObjectId;
						Items[value] = updateItem;
						IndexLookup[objectId2] = value;
					}
					Items[_count] = default(UpdateItem);
					IndexLookup.Remove(objectId);
				}
				else
				{
					Debug.LogError($"Failed to remove update item with id {objectId} from an update group.");
				}
			}
		}

		private class UpdateGroupCollection
		{
			private bool _refreshOrder;

			private Dictionary<UpdateGroupKey, UpdateGroup> _updateGroupsByKey;

			private UpdateGroup[] _updateGroupsByOrder;

			private Dictionary<int, List<UpdateGroup>> _updateGroupsByTargetObjectId;

			public UpdateGroup[] UpdateGroupsByOrder
			{
				get
				{
					if (_refreshOrder)
					{
						_refreshOrder = false;
						_updateGroupsByOrder = _updateGroupsByKey.Values.OrderBy((UpdateGroup x) => x.ExecutionOrder).ToArray();
					}
					return _updateGroupsByOrder;
				}
			}

			public CraftUpdateType UpdateType { get; }

			public UpdateGroupCollection(CraftUpdateType updateType)
			{
				UpdateType = updateType;
				_updateGroupsByKey = new Dictionary<UpdateGroupKey, UpdateGroup>();
				_updateGroupsByTargetObjectId = new Dictionary<int, List<UpdateGroup>>();
				_refreshOrder = true;
			}

			public void Clear()
			{
				_updateGroupsByKey.Clear();
				_updateGroupsByTargetObjectId.Clear();
				_updateGroupsByOrder = null;
				_refreshOrder = true;
			}

			public void RegisterItem(UnityEngine.Object obj, CraftUpdateDelegate updateDelegate, CraftUpdateFlags flags, int executionOrder)
			{
				UpdateItem item = new UpdateItem(obj, updateDelegate);
				UpdateGroupKey key = new UpdateGroupKey(updateDelegate.Method, flags, executionOrder);
				UpdateGroup orCreateUpdateGroup = GetOrCreateUpdateGroup(key);
				orCreateUpdateGroup.Add(item);
				if (!_updateGroupsByTargetObjectId.TryGetValue(item.ObjectId, out var value))
				{
					value = new List<UpdateGroup>();
					_updateGroupsByTargetObjectId.Add(item.ObjectId, value);
				}
				value.Add(orCreateUpdateGroup);
			}

			public void UnregisterItem(UnityEngine.Object obj)
			{
				if (_updateGroupsByTargetObjectId.Count == 0)
				{
					return;
				}
				int instanceID = obj.GetInstanceID();
				if (!_updateGroupsByTargetObjectId.TryGetValue(instanceID, out var value))
				{
					return;
				}
				foreach (UpdateGroup item in value)
				{
					item.Remove(instanceID);
					if (item.Count == 0)
					{
						RemoveGroup(item.Key);
					}
				}
				_updateGroupsByTargetObjectId.Remove(instanceID);
			}

			private void AddGroup(UpdateGroupKey key, UpdateGroup group)
			{
				_updateGroupsByKey.Add(key, group);
				_refreshOrder = true;
			}

			private UpdateGroup GetOrCreateUpdateGroup(UpdateGroupKey key)
			{
				if (!_updateGroupsByKey.TryGetValue(key, out var value))
				{
					value = new UpdateGroup(this, key.TargetMethod, key.Flags, key.ExecutionOrder);
					AddGroup(key, value);
				}
				return value;
			}

			private void RemoveGroup(UpdateGroupKey key)
			{
				_updateGroupsByKey.Remove(key);
				_refreshOrder = true;
			}
		}

		private CraftUpdateFrameData _currentFrameData;

		private CraftUpdateFlags _currentFrameFlags;

		private HashSet<OneTimeExecutionKey> _firstFrameLateUpdateExecutions;

		private bool _isPaused;

		private List<PartScript> _partScripts;

		private Dictionary<int, PausedRigidBodyData> _pausedRigidBodyData = new Dictionary<int, PausedRigidBodyData>();

		private HashSet<OneTimeExecutionKey> _startMethodExecutions;

		private List<BodyScript> _tempBodyScriptList;

		private UpdateGroupCollection[] _updateCollections;

		[field: SerializeField]
		public AircraftScript CraftScript { get; private set; }

		public bool IsPaused => _isPaused;

		public void OnFixedUpdateBodyScripts()
		{
			if (_isPaused)
			{
				return;
			}
			CraftUpdateFrameData frame = _currentFrameData;
			if (frame.IsRemoteCraft)
			{
				return;
			}
			try
			{
				foreach (BodyScript body in CraftScript.Bodies)
				{
					try
					{
						body.OnFixedUpdate(in frame);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			finally
			{
			}
		}

		public void OnFixedUpdateCraftScripts()
		{
			if (_isPaused)
			{
				return;
			}
			CraftUpdateFrameData frame = _currentFrameData;
			try
			{
				CraftScript.OnFixedUpdate(in frame);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
			}
		}

		public void OnFixedUpdateModifierScripts()
		{
			if (!_isPaused)
			{
				PerformUpdate(CraftUpdateType.FixedUpdate, _currentFrameFlags, in _currentFrameData);
			}
		}

		public void OnFixedUpdatePartScripts()
		{
			if (_isPaused)
			{
				return;
			}
			CraftUpdateFrameData frame = _currentFrameData;
			if (frame.CraftLoadContext != CraftLoadContext.Flight || frame.Paused || frame.IsRemoteCraft)
			{
				return;
			}
			try
			{
				foreach (PartScript partScript in _partScripts)
				{
					try
					{
						partScript.OnFixedUpdate(in frame);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			finally
			{
			}
		}

		public void OnFixedUpdateStart()
		{
			if (!_isPaused)
			{
				UpdateCurrentFrameData();
				PerformOneTimeUpdate(CraftUpdateType.Start, _currentFrameFlags, in _currentFrameData, _startMethodExecutions);
			}
		}

		public void OnLateUpdateBodyScripts()
		{
		}

		public void OnLateUpdateCraftScripts()
		{
			if (_isPaused)
			{
				return;
			}
			CraftUpdateFrameData frame = _currentFrameData;
			try
			{
				CraftScript.OnLateUpdate(in frame);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
			}
		}

		public void OnLateUpdateModifierScripts()
		{
			if (!_isPaused)
			{
				PerformUpdate(CraftUpdateType.LateUpdate, _currentFrameFlags, in _currentFrameData);
			}
		}

		public void OnLateUpdatePartMaterialScripts()
		{
			if (_isPaused)
			{
				return;
			}
			CraftUpdateFrameData frame = _currentFrameData;
			if (frame.IsRemoteCraft || frame.IsAICraft)
			{
				return;
			}
			try
			{
				foreach (PartScript partScript in _partScripts)
				{
					try
					{
						partScript.PartMaterialScript.OnLateUpdate(in frame);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			finally
			{
			}
		}

		public void OnLateUpdatePartScripts()
		{
			if (_isPaused)
			{
				return;
			}
			CraftUpdateFrameData frame = _currentFrameData;
			if (frame.CraftLoadContext != CraftLoadContext.Flight || frame.Paused || frame.IsRemoteCraft)
			{
				return;
			}
			try
			{
				foreach (PartScript partScript in _partScripts)
				{
					try
					{
						partScript.OnLateUpdate(in frame);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			finally
			{
			}
		}

		public void OnLateUpdateStart()
		{
			if (!_isPaused)
			{
				UpdateCurrentFrameData();
				PerformOneTimeUpdate(CraftUpdateType.Start, _currentFrameFlags, in _currentFrameData, _startMethodExecutions);
				PerformOneTimeUpdate(CraftUpdateType.FirstFrameLateUpdate, _currentFrameFlags, in _currentFrameData, _firstFrameLateUpdateExecutions);
			}
		}

		public void OnSceneTransitionCleanup()
		{
		}

		public void OnStart()
		{
			UpdateCurrentFrameData();
			PerformOneTimeUpdate(CraftUpdateType.Start, _currentFrameFlags, in _currentFrameData, _startMethodExecutions);
		}

		public void OnUpdateBodyScripts()
		{
			if (_isPaused)
			{
				return;
			}
			CraftUpdateFrameData frame = _currentFrameData;
			try
			{
				_tempBodyScriptList.Clear();
				_tempBodyScriptList.AddRange(CraftScript.Bodies);
				foreach (BodyScript tempBodyScript in _tempBodyScriptList)
				{
					if (tempBodyScript.isActiveAndEnabled)
					{
						try
						{
							tempBodyScript.OnUpdate(in frame);
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
						}
					}
				}
			}
			finally
			{
				_tempBodyScriptList.Clear();
			}
		}

		public void OnUpdateCraftScripts()
		{
			if (_isPaused)
			{
				return;
			}
			CraftUpdateFrameData frame = _currentFrameData;
			try
			{
				CraftScript.OnUpdate(in frame);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
			}
		}

		public void OnUpdateModifierScripts()
		{
			if (!_isPaused)
			{
				PerformUpdate(CraftUpdateType.Update, _currentFrameFlags, in _currentFrameData);
			}
		}

		public void OnUpdatePartScripts()
		{
		}

		public void OnUpdateStart()
		{
			if (!_isPaused)
			{
				UpdateCurrentFrameData();
				PerformOneTimeUpdate(CraftUpdateType.Start, _currentFrameFlags, in _currentFrameData, _startMethodExecutions);
			}
		}

		public void Register(PartScript partScript)
		{
			_partScripts.Add(partScript);
		}

		public void RegisterUpdate(CraftUpdateType type, UnityEngine.Object obj, CraftUpdateDelegate updateDelegate, CraftUpdateFlags flags = CraftUpdateFlags.Default, int executionOrder = 0)
		{
			HashSet<OneTimeExecutionKey> hashSet = type switch
			{
				CraftUpdateType.Start => _startMethodExecutions, 
				CraftUpdateType.FirstFrameLateUpdate => _firstFrameLateUpdateExecutions, 
				_ => null, 
			};
			if (hashSet == null || !hashSet.Contains(new OneTimeExecutionKey(obj, updateDelegate.Method, flags)))
			{
				_updateCollections[(int)type].RegisterItem(obj, updateDelegate, flags, executionOrder);
			}
		}

		public void SetCraftPausedState(bool paused)
		{
			if (paused == _isPaused)
			{
				return;
			}
			if (paused)
			{
				_pausedRigidBodyData.Clear();
				foreach (BodyScript body in CraftScript.Bodies)
				{
					_pausedRigidBodyData.Add(body.Id, new PausedRigidBodyData
					{
						Velocity = body.RigidBody.velocity,
						AngularVelocity = body.RigidBody.angularVelocity,
						IsKinematic = body.RigidBody.isKinematic
					});
					body.RigidBody.isKinematic = true;
				}
			}
			else
			{
				foreach (BodyScript body2 in CraftScript.Bodies)
				{
					if (_pausedRigidBodyData.TryGetValue(body2.Id, out var value))
					{
						body2.RigidBody.isKinematic = value.IsKinematic;
						body2.RigidBody.velocity = value.Velocity;
						body2.RigidBody.angularVelocity = value.AngularVelocity;
					}
					else
					{
						body2.RigidBody.isKinematic = false;
					}
				}
				_pausedRigidBodyData.Clear();
			}
			_isPaused = paused;
		}

		public void Unregister(PartScript partScript)
		{
			_partScripts.Remove(partScript);
			UnregisterUpdate(partScript);
		}

		public void UnregisterUpdate(UnityEngine.Object obj)
		{
			UpdateGroupCollection[] updateCollections = _updateCollections;
			for (int i = 0; i < updateCollections.Length; i++)
			{
				updateCollections[i].UnregisterItem(obj);
			}
		}

		public void UpdatePausedVelocity(int bodyId, Vector3 value)
		{
			if (_pausedRigidBodyData.TryGetValue(bodyId, out var value2))
			{
				value2.Velocity = value;
				_pausedRigidBodyData[bodyId] = value2;
			}
		}

		protected virtual void Awake()
		{
			CraftScript = GetComponentInParent<AircraftScript>(includeInactive: true);
			_partScripts = new List<PartScript>();
			_tempBodyScriptList = new List<BodyScript>();
			_startMethodExecutions = new HashSet<OneTimeExecutionKey>();
			_firstFrameLateUpdateExecutions = new HashSet<OneTimeExecutionKey>();
			_updateCollections = new UpdateGroupCollection[5]
			{
				new UpdateGroupCollection(CraftUpdateType.Start),
				new UpdateGroupCollection(CraftUpdateType.Update),
				new UpdateGroupCollection(CraftUpdateType.FixedUpdate),
				new UpdateGroupCollection(CraftUpdateType.LateUpdate),
				new UpdateGroupCollection(CraftUpdateType.FirstFrameLateUpdate)
			};
		}

		protected virtual void OnDisable()
		{
			Game.Instance.CraftUpdateManager.Unregister(this);
		}

		protected virtual void OnEnable()
		{
			Game.Instance.CraftUpdateManager.Register(this);
		}

		private void PerformOneTimeUpdate(CraftUpdateType updateType, CraftUpdateFlags flags, in CraftUpdateFrameData frame, HashSet<OneTimeExecutionKey> singleExecutionHashSet)
		{
			UpdateGroupCollection updateGroupCollection = _updateCollections[(int)updateType];
			UpdateGroup[] updateGroupsByOrder = updateGroupCollection.UpdateGroupsByOrder;
			if (updateGroupsByOrder.Length != 0)
			{
				updateGroupCollection.Clear();
			}
			UpdateGroup[] array = updateGroupsByOrder;
			foreach (UpdateGroup updateGroup in array)
			{
				if ((updateGroup.Flags & flags) != flags)
				{
					continue;
				}
				UpdateItem[] items = updateGroup.Items;
				int count = updateGroup.Count;
				singleExecutionHashSet.EnsureCapacity(singleExecutionHashSet.Count + count);
				try
				{
					for (int j = 0; j < count; j++)
					{
						UpdateItem updateItem = items[j];
						try
						{
							updateItem.Delegate(in frame);
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
						}
						finally
						{
							singleExecutionHashSet.Add(new OneTimeExecutionKey(updateItem.Object, updateItem.Delegate.Method, updateGroup.Flags));
						}
					}
				}
				finally
				{
				}
			}
		}

		private void PerformUpdate(CraftUpdateType updateType, CraftUpdateFlags flags, in CraftUpdateFrameData frame)
		{
			UpdateGroup[] updateGroupsByOrder = _updateCollections[(int)updateType].UpdateGroupsByOrder;
			foreach (UpdateGroup updateGroup in updateGroupsByOrder)
			{
				if ((updateGroup.Flags & flags) != flags)
				{
					continue;
				}
				UpdateItem[] items = updateGroup.Items;
				int count = updateGroup.Count;
				try
				{
					for (int j = 0; j < count; j++)
					{
						UpdateItem updateItem = items[j];
						try
						{
							updateItem.Delegate(in frame);
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
						}
					}
				}
				finally
				{
				}
			}
		}

		private void UpdateCurrentFrameData()
		{
			_currentFrameData = new CraftUpdateFrameData(CraftScript);
			CraftUpdateFlags craftUpdateFlags = (CraftUpdateFlags)((CraftScript.LoadContext switch
			{
				CraftLoadContext.Default => 1, 
				CraftLoadContext.Menu => 8, 
				CraftLoadContext.Designer => 4, 
				CraftLoadContext.Flight => 2, 
				CraftLoadContext.Studio => 16, 
				_ => throw new NotImplementedException($"Load Context Not Supported: {CraftScript.LoadContext}"), 
			}) | (_currentFrameData.Paused ? 256 : 128));
			craftUpdateFlags = (CraftUpdateFlags)((int)craftUpdateFlags | (_currentFrameData.IsRemoteCraft ? 64 : 32));
			_currentFrameFlags = craftUpdateFlags;
		}
	}
}

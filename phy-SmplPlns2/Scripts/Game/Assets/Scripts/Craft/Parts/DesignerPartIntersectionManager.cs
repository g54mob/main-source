using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class DesignerPartIntersectionManager : MonoBehaviour
	{
		private static class Profile
		{
			public const string Prefix = "DesignerPartIntersectionManager";

			public static readonly ProfilerMarker LateUpdate = new ProfilerMarker("DesignerPartIntersectionManager.LateUpdate");

			public static readonly ProfilerMarker Update = new ProfilerMarker("DesignerPartIntersectionManager.Update");

			public static readonly ProfilerMarker WaitForJobCompletion = new ProfilerMarker("DesignerPartIntersectionManager.LateUpdate.WaitForJobCompletion");
		}

		private NativeArray<OverlapBoxCommand> _colliderQueryCommands;

		private List<PartIntersectionReceiver> _colliderQueryReceivers;

		private JobHandle? _colliderQueryJob;

		private NativeArray<ColliderHit> _colliderQueryResults;

		private int _colliderQueryResultSize = 10;

		private HashSet<PartIntersectionReceiver> _receivers;

		public bool IsDestroyed { get; private set; }

		public void RegisterReceiver(PartIntersectionReceiver receiver)
		{
			_receivers.Add(receiver);
		}

		public void UnregisterReceiver(PartIntersectionReceiver receiver)
		{
			if (!_receivers.Remove(receiver))
			{
				Debug.LogError("Attempting to remove a part intersection receiver but the receiver could not be found in the intersection manager.");
			}
		}

		public void OnCraftReposition()
		{
			foreach (PartIntersectionReceiver receiver in _receivers)
			{
				receiver.OnUpdate();
			}
		}

		protected virtual void Awake()
		{
			_receivers = new HashSet<PartIntersectionReceiver>();
			_colliderQueryReceivers = new List<PartIntersectionReceiver>();
		}

		protected virtual void LateUpdate()
		{
			using (Profile.LateUpdate.Auto())
			{
				if (!_colliderQueryJob.HasValue)
				{
					return;
				}
				_colliderQueryJob.Value.Complete();
				_colliderQueryJob = null;
				int num = 0;
				for (int i = 0; i < _colliderQueryReceivers.Count; i++)
				{
					PartIntersectionReceiver partIntersectionReceiver = _colliderQueryReceivers[i];
					if (!_receivers.Contains(partIntersectionReceiver))
					{
						continue;
					}
					partIntersectionReceiver.OnBeforeRecieveHits();
					int num2 = 0;
					int num3 = i * _colliderQueryResultSize;
					for (int j = 0; j < _colliderQueryResultSize; j++)
					{
						ColliderHit colliderHit = _colliderQueryResults[num3 + j];
						if (colliderHit.instanceID == 0)
						{
							break;
						}
						num2++;
						if (colliderHit.collider != null)
						{
							partIntersectionReceiver.RecieveHit(colliderHit.collider);
						}
					}
					partIntersectionReceiver.OnAfterRecieveHits();
					num = Math.Max(num, num2);
				}
				_colliderQueryResultSize = Math.Max(10, num * 2);
				_colliderQueryCommands.Dispose();
				_colliderQueryResults.Dispose();
			}
		}

		protected virtual void OnDestroy()
		{
			IsDestroyed = true;
		}

		protected virtual void OnDisable()
		{
			if (_colliderQueryJob.HasValue)
			{
				_colliderQueryJob.Value.Complete();
				_colliderQueryJob = null;
				_colliderQueryCommands.Dispose();
				_colliderQueryResults.Dispose();
			}
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
			using (Profile.Update.Auto())
			{
				if (_receivers.Count == 0)
				{
					_colliderQueryJob = null;
					return;
				}
				_colliderQueryReceivers.Clear();
				foreach (PartIntersectionReceiver receiver in _receivers)
				{
					receiver.OnUpdate();
					if (receiver.Enabled)
					{
						_colliderQueryReceivers.Add(receiver);
					}
				}
				_colliderQueryCommands = new NativeArray<OverlapBoxCommand>(_colliderQueryReceivers.Count, Allocator.TempJob);
				int length = _receivers.Count * _colliderQueryResultSize;
				_colliderQueryResults = new NativeArray<ColliderHit>(length, Allocator.TempJob);
				for (int i = 0; i < _colliderQueryReceivers.Count; i++)
				{
					PartIntersectionReceiver partIntersectionReceiver = _colliderQueryReceivers[i];
					var (center, halfExtents, orientation) = partIntersectionReceiver.GetBox();
					_colliderQueryCommands[i] = new OverlapBoxCommand(center, halfExtents, orientation, new QueryParameters
					{
						layerMask = partIntersectionReceiver.LayerMask
					});
				}
				_colliderQueryJob = OverlapBoxCommand.ScheduleBatch(_colliderQueryCommands, _colliderQueryResults, 1, _colliderQueryResultSize);
				JobHandle.ScheduleBatchedJobs();
			}
		}
	}
}

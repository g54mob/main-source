using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class ReservationManager : MonoSingleton<ReservationManager>
	{
		private readonly struct ExclusiveReservationInfo
		{
			private readonly IGoapAgentOwner reserver;

			private readonly bool hasLimitedTime;

			private readonly float timeLimit;

			public IGoapAgentOwner Reserver => reserver;

			public bool HasLimitedTime => hasLimitedTime;

			public float TimeLimit => timeLimit;

			public ExclusiveReservationInfo(IGoapAgentOwner reserver, float timeLimit)
			{
				this.reserver = reserver;
				this.timeLimit = timeLimit;
				hasLimitedTime = timeLimit > 0.001f;
			}

			public ExclusiveReservationInfo(IGoapAgentOwner reserver)
			{
				this = default(ExclusiveReservationInfo);
				this.reserver = reserver;
			}
		}

		private const float ExclusiveReservationAutoReleaseTickTime = 0.65f;

		private readonly object mainLock = new object();

		private readonly Dictionary<IReservable, List<IGoapAgentOwner>> reservedDict = new Dictionary<IReservable, List<IGoapAgentOwner>>();

		private readonly Dictionary<IGoapAgentOwner, IReservable> preferedReservable = new Dictionary<IGoapAgentOwner, IReservable>();

		private readonly Dictionary<IGoapAgentOwner, IReservable> lastReleasedReservable = new Dictionary<IGoapAgentOwner, IReservable>();

		private readonly Dictionary<IReservable, ExclusiveReservationInfo> exclusiveReservations = new Dictionary<IReservable, ExclusiveReservationInfo>();

		private float exclusiveTickAccumulator;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			foreach (List<IGoapAgentOwner> value in reservedDict.Values)
			{
				value.Clear();
			}
			reservedDict.Clear();
			preferedReservable.Clear();
			lastReleasedReservable.Clear();
			exclusiveReservations.Clear();
		}

		public bool TryReserveObject(IReservable reservableObject, IGoapAgentOwner reserverAgent)
		{
			bool isEnabled;
			if (reserverAgent == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ReservationManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to reserve ");
					messageBuilder.AppendFormatted(reservableObject);
					messageBuilder.AppendLiteral(" with null reserver agent");
				}
				Log.Error(messageBuilder);
				return false;
			}
			if (reserverAgent.HasDisposed)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(46, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ReservationManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to reserve ");
					messageBuilder.AppendFormatted(reservableObject);
					messageBuilder.AppendLiteral(" with disposed reserver agent");
				}
				Log.Error(messageBuilder);
				return false;
			}
			lock (mainLock)
			{
				if (!CanReserve(reservableObject, reserverAgent))
				{
					return false;
				}
				List<IGoapAgentOwner> list = GetReserversUnsafe(reservableObject);
				bool flag = false;
				if (list == null)
				{
					list = ListPool<IGoapAgentOwner>.Get(2);
					reservableObject.OnDisposedEvent += OnReservableDisposed;
					reservedDict[reservableObject] = list;
					flag = true;
				}
				if (!list.Contains(reserverAgent))
				{
					list.Add(reserverAgent);
					flag = true;
				}
				if (flag)
				{
					MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThread(delegate
					{
						reservableObject.OnReservationChanged(isReserved: true, reserverAgent);
					});
				}
				if (preferedReservable.ContainsKey(reserverAgent) && preferedReservable[reserverAgent] == reservableObject)
				{
					preferedReservable.Remove(reserverAgent);
				}
			}
			FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(29, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ReservationManager.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Reserve object '");
				messageBuilder2.AppendFormatted(reservableObject);
				messageBuilder2.AppendLiteral("' by agent '");
				messageBuilder2.AppendFormatted(reserverAgent);
				messageBuilder2.AppendLiteral("'");
			}
			Log.Trace(messageBuilder2);
			return true;
		}

		public bool TryToExclusiveReservation(IReservable reservableObject, IGoapAgentOwner reserverAgent, float exclusivityTime = -1f)
		{
			if (reservableObject == null || reservableObject.HasDisposed || reserverAgent == null || reserverAgent.HasDisposed)
			{
				return false;
			}
			lock (mainLock)
			{
				if (exclusiveReservations.TryGetValue(reservableObject, out var value))
				{
					if (value.Reserver != reserverAgent)
					{
						return false;
					}
					exclusiveReservations[reservableObject] = new ExclusiveReservationInfo(reserverAgent, exclusivityTime);
					return true;
				}
				List<IGoapAgentOwner> reserversUnsafe = GetReserversUnsafe(reservableObject);
				if (reserversUnsafe != null)
				{
					if (reserversUnsafe.Count == 1 && !reserversUnsafe.Contains(reserverAgent))
					{
						ReleaseAll(reservableObject);
					}
					else if (reserversUnsafe.Count > 1)
					{
						foreach (IGoapAgentOwner item in reserversUnsafe.Where((IGoapAgentOwner item) => item != reserverAgent))
						{
							ReleaseObject(reservableObject, item);
						}
					}
				}
				exclusiveReservations[reservableObject] = new ExclusiveReservationInfo(reserverAgent, exclusivityTime);
			}
			return true;
		}

		public bool HasExclusiveReservation(IReservable reservable, IGoapAgentOwner reserver)
		{
			lock (mainLock)
			{
				if (exclusiveReservations.TryGetValue(reservable, out var value))
				{
					return value.Reserver == reserver;
				}
			}
			return false;
		}

		public bool CanReserve(IReservable reservableObject, IGoapAgentOwner agent)
		{
			if (reservableObject == null || reservableObject.GetMaxReservers() == 0 || reservableObject.HasDisposed || agent == null || agent.HasDisposed)
			{
				return false;
			}
			lock (mainLock)
			{
				if (exclusiveReservations.TryGetValue(reservableObject, out var value) && value.Reserver != agent)
				{
					return false;
				}
				List<IGoapAgentOwner> reserversUnsafe = GetReserversUnsafe(reservableObject);
				if (reserversUnsafe == null)
				{
					return true;
				}
				return reserversUnsafe.Count < reservableObject.GetMaxReservers() || reserversUnsafe.Contains(agent);
			}
		}

		public void ReleaseObject(IReservable reservableObject, IGoapAgentOwner reserverAgent)
		{
			if (reservableObject == null)
			{
				return;
			}
			lock (mainLock)
			{
				List<IGoapAgentOwner> reserversUnsafe = GetReserversUnsafe(reservableObject);
				if (reserversUnsafe == null)
				{
					return;
				}
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(29, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ReservationManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Release object '");
					messageBuilder.AppendFormatted(reservableObject);
					messageBuilder.AppendLiteral("' by agent '");
					messageBuilder.AppendFormatted(reserverAgent);
					messageBuilder.AppendLiteral("'");
				}
				Log.Trace(messageBuilder);
				if (reserverAgent != null)
				{
					if (reserversUnsafe.Remove(reserverAgent))
					{
						MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThread(delegate
						{
							reservableObject.OnReservationChanged(isReserved: false, reserverAgent);
						});
						lastReleasedReservable[reserverAgent] = reservableObject;
					}
					return;
				}
				foreach (IGoapAgentOwner item in reserversUnsafe.IterateInReverseDynamic())
				{
					if (MonoSingleton<ThreadingJobSystem>.IsInstantiated())
					{
						IGoapAgentOwner agent1 = item;
						MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThread(delegate
						{
							reservableObject.OnReservationChanged(isReserved: false, agent1);
						});
					}
					lastReleasedReservable[item] = reservableObject;
				}
				reserversUnsafe.Clear();
			}
		}

		public void ReleaseAll(IReservable reservableObject)
		{
			ReleaseObject(reservableObject, null);
		}

		public void ReleaseAll(IGoapAgentOwner reserver)
		{
			if (reserver == null)
			{
				return;
			}
			lock (mainLock)
			{
				List<IReservable> list = null;
				foreach (KeyValuePair<IReservable, List<IGoapAgentOwner>> item in reservedDict)
				{
					if (IsReservedBy(item.Key, reserver))
					{
						list = list ?? ListPool<IReservable>.Get();
						list.Add(item.Key);
					}
				}
				if (list != null)
				{
					foreach (IReservable item2 in list)
					{
						ReleaseObject(item2, reserver);
					}
				}
				ListPool<IReservable>.Return(list);
			}
		}

		public void ReleaseExclusiveReservation(IReservable reservableObject)
		{
			lock (mainLock)
			{
				if (reservableObject != null && exclusiveReservations.ContainsKey(reservableObject))
				{
					exclusiveReservations.Remove(reservableObject);
				}
			}
		}

		public IGoapAgentOwner GetSingleReserver(IReservable reservable)
		{
			lock (mainLock)
			{
				return GetReserversUnsafe(reservable)?[0];
			}
		}

		public List<IGoapAgentOwner> GetReservers(IReservable reservable)
		{
			lock (mainLock)
			{
				List<IGoapAgentOwner> reserversUnsafe = GetReserversUnsafe(reservable);
				if (reserversUnsafe == null || reserversUnsafe.Count == 0)
				{
					return null;
				}
				List<IGoapAgentOwner> list = ListPool<IGoapAgentOwner>.Get();
				for (int i = 0; i < reserversUnsafe.Count; i++)
				{
					list.Add(reserversUnsafe[i]);
				}
				return list;
			}
		}

		public int GetReserversCount(IReservable reservable)
		{
			lock (mainLock)
			{
				List<IGoapAgentOwner> reserversUnsafe = GetReserversUnsafe(reservable);
				if (reserversUnsafe == null || reserversUnsafe.Count == 0)
				{
					return 0;
				}
				return reserversUnsafe.Count;
			}
		}

		public List<IReservable> GetReservedBy(IGoapAgentOwner agent)
		{
			List<IReservable> list = new List<IReservable>();
			lock (mainLock)
			{
				foreach (KeyValuePair<IReservable, List<IGoapAgentOwner>> item in reservedDict)
				{
					if (item.Value.Contains(agent))
					{
						list.Add(item.Key);
					}
				}
				return list;
			}
		}

		public BedComponentInstance GetReservedBed(IGoapAgentOwner agentOwner)
		{
			lock (mainLock)
			{
				foreach (IReservable item in GetReservedBy(agentOwner))
				{
					if (item is BedComponentInstance result)
					{
						return result;
					}
				}
				return null;
			}
		}

		public IReservable GetLastReleased(IGoapAgentOwner agent)
		{
			lock (mainLock)
			{
				return (!lastReleasedReservable.ContainsKey(agent)) ? null : lastReleasedReservable[agent];
			}
		}

		public bool IsReserved(IReservable reservable)
		{
			lock (mainLock)
			{
				if (!reservedDict.TryGetValue(reservable, out var value))
				{
					return false;
				}
				return value != null && value.Count > 0;
			}
		}

		public bool IsReservedBy(IReservable reservable, IGoapAgentOwner reserverAgent)
		{
			lock (mainLock)
			{
				return GetReserversUnsafe(reservable)?.Contains(reserverAgent) ?? false;
			}
		}

		public void SetPreferedReservable(IGoapAgentOwner reserverAgent, IReservable reservable)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(50, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ReservationManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("SetPreferredReservable for agent '");
				messageBuilder.AppendFormatted(reserverAgent);
				messageBuilder.AppendLiteral("', reservable '");
				messageBuilder.AppendFormatted(reservable);
				messageBuilder.AppendLiteral("'");
			}
			Log.Trace(messageBuilder);
			lock (mainLock)
			{
				if (!preferedReservable.ContainsKey(reserverAgent) && reservable != null)
				{
					preferedReservable.Add(reserverAgent, reservable);
				}
				else if (reservable == null)
				{
					preferedReservable.Remove(reserverAgent);
				}
				else
				{
					preferedReservable[reserverAgent] = reservable;
				}
			}
		}

		public void ClearPreferedReservable(IGoapAgentOwner reserverAgent)
		{
			lock (mainLock)
			{
				if (preferedReservable.ContainsKey(reserverAgent))
				{
					preferedReservable.Remove(reserverAgent);
				}
			}
		}

		public IReservable GetPreferedReservable(IGoapAgentOwner reserverAgent)
		{
			lock (mainLock)
			{
				return preferedReservable.GetValueOrDefault(reserverAgent);
			}
		}

		public void ForEachReserver(IReservable reservable, Action<IGoapAgentOwner> callback)
		{
			lock (mainLock)
			{
				List<IGoapAgentOwner> reserversUnsafe = GetReserversUnsafe(reservable);
				if (reserversUnsafe == null)
				{
					return;
				}
				foreach (IGoapAgentOwner item in reserversUnsafe)
				{
					callback?.Invoke(item);
				}
			}
		}

		private void OnReservableDisposed(IGameDisposable disposable)
		{
			IReservable reservable = (IReservable)disposable;
			lock (mainLock)
			{
				ReleaseExclusiveReservation(reservable);
				if (reservedDict.ContainsKey(reservable))
				{
					ReleaseAll(reservable);
					ListPool<IGoapAgentOwner>.Return(reservedDict[reservable]);
					reservedDict.Remove(reservable);
					lastReleasedReservable.RemoveAll((KeyValuePair<IGoapAgentOwner, IReservable> item) => item.Value == disposable);
					preferedReservable.RemoveAll((KeyValuePair<IGoapAgentOwner, IReservable> item) => item.Value == disposable);
				}
			}
		}

		private List<IGoapAgentOwner> GetReserversUnsafe(IReservable reservable)
		{
			if (reservable == null || !reservedDict.ContainsKey(reservable))
			{
				return null;
			}
			List<IGoapAgentOwner> list = reservedDict[reservable];
			if (list.Count <= 0)
			{
				return null;
			}
			return list;
		}

		private void Update()
		{
			float deltaTime = Time.deltaTime;
			if (deltaTime <= 0.0001f)
			{
				return;
			}
			exclusiveTickAccumulator += deltaTime;
			if (exclusiveTickAccumulator < 0.65f)
			{
				return;
			}
			if (exclusiveReservations.Count == 0)
			{
				exclusiveTickAccumulator = 0f;
				return;
			}
			lock (mainLock)
			{
				foreach (KeyValuePair<IReservable, ExclusiveReservationInfo> item in exclusiveReservations.ToList())
				{
					ExclusiveReservationInfo value = item.Value;
					if (value.HasLimitedTime)
					{
						float num = value.TimeLimit - exclusiveTickAccumulator;
						if (num <= 0.001f)
						{
							ReleaseExclusiveReservation(item.Key);
						}
						else
						{
							exclusiveReservations[item.Key] = new ExclusiveReservationInfo(value.Reserver, num);
						}
					}
				}
			}
			exclusiveTickAccumulator = 0f;
		}
	}
}

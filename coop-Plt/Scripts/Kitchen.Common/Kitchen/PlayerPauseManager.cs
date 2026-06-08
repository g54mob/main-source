using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class PlayerPauseManager : GenericSystemBase
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SPlayerPauseRequest : IComponentData
		{
		}

		private const float AnyoneCanUnpauseTimeout = 10f;

		private HashSet<int> RequestPauseSet = new HashSet<int>();

		private HashSet<int> TempSet = new HashSet<int>();

		private float PauseTime;

		private EntityQuery Players;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SPlayerPauseRequest_7;

		protected override void Initialise()
		{
			base.Initialise();
			Players = GetEntityQuery(typeof(CPlayer));
		}

		public void RequestPause(int source_identifier)
		{
			RequestPauseSet.Add(source_identifier);
		}

		public void RequestUnpause(int source_identifier)
		{
			RequestPauseSet.Remove(source_identifier);
		}

		private void SetPausedState(bool paused)
		{
			Entity singletonEntity = _SingletonEntityQuery_SPlayerPauseRequest_7.GetSingletonEntity();
			if (HasComponent<CGamePauseRequest>(singletonEntity))
			{
				if (!paused)
				{
					base.EntityManager.RemoveComponent<CGamePauseRequest>(singletonEntity);
				}
			}
			else if (paused)
			{
				PauseTime = base.Time.TotalTime;
				base.EntityManager.AddComponent<CGamePauseRequest>(singletonEntity);
			}
		}

		protected override void OnUpdate()
		{
			if (!HasSingleton<SPlayerPauseRequest>())
			{
				base.EntityManager.CreateEntity(typeof(SPlayerPauseRequest));
			}
			PrunePausePlayers();
			SetPausedState(RequestPauseSet.Count != 0);
		}

		private void PrunePausePlayers()
		{
			NativeArray<CPlayer> nativeArray = Players.ToComponentDataArray<CPlayer>(Allocator.Temp);
			TempSet.Clear();
			foreach (CPlayer item in nativeArray)
			{
				if (RequestPauseSet.Contains(item.InputSource))
				{
					TempSet.Add(item.InputSource);
				}
			}
			HashSet<int> tempSet = TempSet;
			HashSet<int> requestPauseSet = RequestPauseSet;
			RequestPauseSet = tempSet;
			TempSet = requestPauseSet;
			nativeArray.Dispose();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SPlayerPauseRequest_7 = GetEntityQuery(ComponentType.ReadOnly<SPlayerPauseRequest>());
		}
	}
}

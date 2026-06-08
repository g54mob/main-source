using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class PauseBlocker : GenericSystemBase
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SPauseScreenDim : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CPreventPauseScreenDim : IComponentData
		{
		}

		private EntityQuery BlockPrevents;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SPauseScreenDim_0;

		protected override void Initialise()
		{
			base.Initialise();
			BlockPrevents = GetEntityQuery(typeof(CPreventPauseScreenDim));
			Entity entity = base.EntityManager.CreateEntity(typeof(CPosition), typeof(SPauseScreenDim), typeof(CRequiresView), typeof(CPersistThroughSceneChanges));
			base.EntityManager.SetComponentData(entity, new CRequiresView
			{
				Type = ViewType.PauseBlocker,
				ViewMode = ViewMode.Screen
			});
			base.EntityManager.SetComponentData(entity, new CPosition(new Vector3(0.5f, 0.5f, 0f)));
		}

		protected override void OnUpdate()
		{
			bool flag = base.Time.IsPaused && BlockPrevents.IsEmpty;
			Entity singletonEntity = _SingletonEntityQuery_SPauseScreenDim_0.GetSingletonEntity();
			if (HasComponent<CHideView>(singletonEntity))
			{
				if (flag)
				{
					base.EntityManager.RemoveComponent<CHideView>(singletonEntity);
				}
			}
			else if (!flag)
			{
				base.EntityManager.AddComponent<CHideView>(singletonEntity);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SPauseScreenDim_0 = GetEntityQuery(ComponentType.ReadOnly<SPauseScreenDim>());
		}
	}
}

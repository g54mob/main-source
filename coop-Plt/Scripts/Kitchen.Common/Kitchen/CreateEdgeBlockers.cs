using System.Runtime.InteropServices;
using Unity.Entities;

namespace Kitchen
{
	public class CreateEdgeBlockers : GenericSystemBase
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SLeftBlocker : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SRightBlocker : IComponentData
		{
		}

		protected override void OnUpdate()
		{
			if (!Has<SLeftBlocker>())
			{
				Create();
			}
			if (!Has<SRightBlocker>())
			{
				Create(is_right: true);
			}
		}

		private void Create(bool is_right = false)
		{
			Entity entity = base.EntityManager.CreateEntity();
			base.EntityManager.AddComponentData(entity, new CPosition(is_right ? 1 : 0, 0.5f));
			base.EntityManager.AddComponentData(entity, new CRequiresView
			{
				ViewMode = ViewMode.Screen,
				Type = (is_right ? ViewType.RightUIBlocker : ViewType.LeftUIBlocker)
			});
			base.EntityManager.AddComponent<CPersistThroughSceneChanges>(entity);
			if (is_right)
			{
				base.EntityManager.AddComponent<SRightBlocker>(entity);
			}
			if (!is_right)
			{
				base.EntityManager.AddComponent<SLeftBlocker>(entity);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}

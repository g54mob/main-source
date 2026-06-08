using System.Runtime.InteropServices;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateVersionOverlay : GenericSystemBase
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SVersionOverlay : IComponentData
		{
		}

		protected override void OnUpdate()
		{
			if (!HasSingleton<SVersionOverlay>())
			{
				Entity entity = base.EntityManager.CreateEntity();
				base.EntityManager.AddComponentData(entity, default(SVersionOverlay));
				base.EntityManager.AddComponentData(entity, new CPosition(new Vector3(1f, 0f, 0f)));
				base.EntityManager.AddComponentData(entity, new CRequiresView
				{
					ViewMode = ViewMode.Screen,
					Type = ViewType.VersionOverlay
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}

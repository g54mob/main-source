using System.Runtime.InteropServices;
using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateRerollTrigger : NightSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SRerollTrigger : IComponentData
		{
		}

		protected override void OnUpdate()
		{
			if (!HasSingleton<SRerollTrigger>() && GetOrDefault<SDay>().Day > 0)
			{
				Vector3 rerollTile = GetRerollTile();
				Entity entity = base.EntityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(SRerollTrigger));
				base.EntityManager.SetComponentData(entity, new CCreateAppliance
				{
					ID = AssetReference.ShopRerollTrigger
				});
				base.EntityManager.SetComponentData(entity, new CPosition(rerollTile));
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}

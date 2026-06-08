using System.Runtime.InteropServices;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class CreatePracticeTrigger : NightSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SPracticeTrigger : IComponentData
		{
		}

		protected override void OnUpdate()
		{
			if (!HasSingleton<SPracticeTrigger>())
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(SPracticeTrigger));
				base.EntityManager.SetComponentData(entity, new CCreateAppliance
				{
					ID = AssetReference.PracticeModeTrigger
				});
				base.EntityManager.SetComponentData(entity, new CPosition(GetPracticeTile()));
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}

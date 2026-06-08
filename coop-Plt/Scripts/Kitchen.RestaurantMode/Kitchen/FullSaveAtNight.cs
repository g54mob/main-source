using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class FullSaveAtNight : NightSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SHasSaved : IComponentData
		{
		}

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SHasSaved_16;

		protected override void OnUpdate()
		{
			if (HasSingleton<SIsNightFirstUpdate>() && HasSingleton<SHasSaved>())
			{
				base.EntityManager.DestroyEntity(_SingletonEntityQuery_SHasSaved_16.GetSingletonEntity());
			}
			else if (!HasSingleton<SHasSaved>() && !base.Time.IsPaused)
			{
				Debug.LogWarning("Performing a full save");
				base.World.Add<SHasSaved>();
				base.World.Add(new CRequestSave
				{
					SaveType = SaveType.AutoFull
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SHasSaved_16 = GetEntityQuery(ComponentType.ReadOnly<SHasSaved>());
		}
	}
}

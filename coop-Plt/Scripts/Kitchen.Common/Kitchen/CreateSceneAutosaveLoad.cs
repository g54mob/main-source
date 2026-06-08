using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(ChangeModeGroup))]
	public class CreateSceneAutosaveLoad : GenericSystemBase
	{
		private EntityQuery Views;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SCreateScene_5;

		protected override void Initialise()
		{
			base.Initialise();
			Views = GetEntityQuery(typeof(CLinkedView));
			RequireSingletonForUpdate<SCreateScene>();
		}

		protected override void OnUpdate()
		{
			if (_SingletonEntityQuery_SCreateScene_5.GetSingleton<SCreateScene>().Type != SceneType.LoadFullAutosave)
			{
				return;
			}
			try
			{
				NativeArray<CLinkedView> nativeArray = Views.ToComponentDataArray<CLinkedView>(Allocator.Temp);
				foreach (CLinkedView item in nativeArray)
				{
					base.Router.BroadcastUpdate(item.Identifier, default(DestroyViewData), MessageType.DestroyView);
				}
				nativeArray.Dispose();
				if (!TryGetSingleton<SSelectedLocation>(out var value) || !value.Valid || !Persistence.FullWorld.Load(base.World.EntityManager, value.Selected.Slot))
				{
					Debug.LogWarning("Failed to load disc backup, returning to lobby");
					Session.ResetGame();
				}
				else
				{
					Set(value);
					MarkTransitionStageCompleted();
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				Session.ResetGame();
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SCreateScene_5 = GetEntityQuery(ComponentType.ReadOnly<SCreateScene>());
		}
	}
}

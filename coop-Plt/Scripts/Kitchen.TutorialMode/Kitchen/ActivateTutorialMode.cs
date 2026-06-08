using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class ActivateTutorialMode : InteractionSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct STutorialModePopup : IComponentData
		{
		}

		private bool ShouldPerformLoad;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_STutorialModePopup_0;

		protected override bool IsPossible(ref InteractionData data)
		{
			return HasComponent<CTriggerTutorial>(data.Target);
		}

		protected override void Perform(ref InteractionData data)
		{
			ShouldPerformLoad = true;
		}

		protected override bool BeforeRun()
		{
			base.BeforeRun();
			ShouldPerformLoad = false;
			if (HasSingleton<STutorialModePopup>())
			{
				Entity singletonEntity = _SingletonEntityQuery_STutorialModePopup_0.GetSingletonEntity();
				switch (GetComponent<CGenericChoicePopup>(singletonEntity).Decision)
				{
				case GenericChoiceDecision.Accept:
				{
					SetComponent(singletonEntity, new CPopup
					{
						Dismiss = true
					});
					Entity entity = base.EntityManager.CreateEntity(typeof(SPerformSceneTransition), typeof(CDoNotPersist));
					base.EntityManager.SetComponentData(entity, new SPerformSceneTransition
					{
						NextScene = SceneType.Tutorial
					});
					break;
				}
				case GenericChoiceDecision.Cancel:
					SetComponent(singletonEntity, new CPopup
					{
						Dismiss = true
					});
					break;
				}
				return false;
			}
			return true;
		}

		protected override void AfterRun()
		{
			base.AfterRun();
			if (ShouldPerformLoad)
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(CPopup), typeof(CGenericChoicePopup), typeof(CPosition), typeof(CRequiresView), typeof(CCaptureInput), typeof(STutorialModePopup));
				base.EntityManager.SetComponentData(entity, new CPopup
				{
					Priority = PopupPriority.LoadSave
				});
				base.EntityManager.SetComponentData(entity, new CGenericChoicePopup
				{
					Type = GenericChoiceType.AcceptOrCancel,
					TextSet = PopupType.StartTutorial
				});
				base.EntityManager.SetComponentData(entity, new CPosition(new Vector3(0.5f, 0.5f, 0f)));
				base.EntityManager.SetComponentData(entity, new CRequiresView
				{
					ViewMode = ViewMode.Screen,
					Type = ViewType.GenericChoicePopup
				});
				base.EntityManager.SetComponentData(entity, new CCaptureInput
				{
					AllUsers = true
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_STutorialModePopup_0 = GetEntityQuery(ComponentType.ReadOnly<STutorialModePopup>());
		}
	}
}

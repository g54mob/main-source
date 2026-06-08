using System.Runtime.InteropServices;
using KitchenData;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	public class StartPracticePopup : GenericChoicePopupManager
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		[MessagePackObject(false)]
		public struct CRequest : IManagedPopupData, IComponentData
		{
		}

		public override PopupType ManagedType => PopupType.EnterPracticeMode;

		public override Entity CreateNewPopup(Entity request)
		{
			base.World.Add(new CRequestSave
			{
				SaveType = SaveType.AutoFull
			});
			return base.PopupUtilities.CreateGenericPopup<CRequest>(GenericChoiceType.AcceptOrCancel, PopupType.EnterPracticeMode, PopupLocation.Centre);
		}

		protected override bool HandleDecision(Entity popup, GenericChoiceDecision decision)
		{
			if (decision == GenericChoiceDecision.Accept)
			{
				Set<SPracticeMode>();
				Set<StartNewDay.STriggerStartDay>();
			}
			return true;
		}

		public override void AfterLoading(SaveSystemType system_type)
		{
			base.AfterLoading(system_type);
			base.EntityManager.DestroyEntity(GetEntityQuery(typeof(CRequest)));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}

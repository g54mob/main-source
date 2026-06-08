using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class StartPracticeMode : ApplianceInteractionSystem
	{
		private bool ShouldPrompt;

		private EntityQuery CarriedAppliances;

		private EntityQuery Popups;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SStartDayWarnings_42;

		protected override void Initialise()
		{
			base.Initialise();
			CarriedAppliances = GetEntityQuery(typeof(CHeldAppliance));
			Popups = GetEntityQuery(typeof(StartPracticePopup.CRequest));
		}

		protected override bool BeforeRun()
		{
			ShouldPrompt = false;
			return Popups.IsEmpty;
		}

		protected override void AfterRun()
		{
			base.AfterRun();
			if (ShouldPrompt)
			{
				Set<CRequestPracticeMode>();
			}
		}

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!HasComponent<CTriggerPracticeMode>(data.Target))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			ShouldPrompt = true;
		}

		protected override void OnUpdate()
		{
			base.OnUpdate();
			if (Has<CRequestPracticeMode>())
			{
				if (!HasSingleton<SStartDayWarnings>())
				{
					Debug.LogWarning("Has No Singleton SStartDayWarnings");
					return;
				}
				PopupType type = ((_SingletonEntityQuery_SStartDayWarnings_42.GetSingleton<SStartDayWarnings>().PostUnopened.IsBlocking() || !CarriedAppliances.IsEmpty) ? PopupType.PracticeBlockedByParcelOrHolding : PopupType.EnterPracticeMode);
				base.PopupUtilities.RequestManagedPopup(type);
			}
			Clear<CRequestPracticeMode>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SStartDayWarnings_42 = GetEntityQuery(ComponentType.ReadOnly<SStartDayWarnings>());
		}
	}
}

using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using Events.FactoryFloor;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class OverclockStationEffectsView : FactoryBehaviorView<OverclockStationBehaviour>
	{
		[SerializeField]
		private GameObject _overclockActiveEffect;

		protected override void Init()
		{
			base.Init();
			DisableActiveEffects();
		}

		protected override void PreviewInit(int objectId, BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
		{
			base.PreviewInit(objectId, blueprintViewEventDto, element);
			DisableActiveEffects();
		}

		public override void SetFactoryObject(FactoryObject factoryObject, bool isGameLoading = false)
		{
			base.SetFactoryObject(factoryObject, isGameLoading);
			_behaviour.OnOverclockActivationStart.RegisterMainThread(EnableActiveEffects);
			_behaviour.OnOverclockActivationEnd.RegisterMainThread(DisableActiveEffects);
			if (_behaviour.IsOverclockActive)
			{
				EnableActiveEffects();
			}
			else
			{
				DisableActiveEffects();
			}
		}

		protected override void ResetFactoryObject()
		{
			if (_behaviour != null)
			{
				_behaviour.OnOverclockActivationStart.UnRegisterMainThread(EnableActiveEffects);
				_behaviour.OnOverclockActivationEnd.UnRegisterMainThread(DisableActiveEffects);
			}
			base.ResetFactoryObject();
		}

		private void EnableActiveEffects()
		{
			_overclockActiveEffect.SetActive(value: true);
		}

		private void DisableActiveEffects()
		{
			_overclockActiveEffect.SetActive(value: false);
		}
	}
}

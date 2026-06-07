using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Drones;
using Data.FactoryFloor.Resources;
using Events;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews
{
	public class SupplyTankRecipientView : FactoryBehaviorView<SupplyTankRecipientBehaviour>
	{
		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private SupplyTankCapsuleView _capsuleView;

		[Space]
		[SerializeField]
		private GameObject _highlightEffect;

		[SerializeField]
		private BaseEvent _showSupplyTankRecipientHighlight;

		[SerializeField]
		private BaseEvent _hideSupplyTankRecipientHighlight;

		[SerializeField]
		private Canvas _canvas;

		private ReferenceFactoryObjectBehaviour _referenceFactoryObjectBehaviour;

		private bool _isShowingHighlight;

		protected override void Init()
		{
			base.Init();
			_referenceFactoryObjectBehaviour = _behaviour.FactoryObject.GetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>();
			_behaviour.OnReceiveCapsule.RegisterMainThread(ReceiveCapsule);
			_behaviour.OnConsumeCapsule.RegisterMainThread(ConsumeCapsule);
			_behaviour.OnCapsuleFillPercChanged.RegisterMainThread(CapsuleFillPercChanged);
			_showSupplyTankRecipientHighlight.Register(ShowHighlight);
			_hideSupplyTankRecipientHighlight.Register(HideHighlight);
			if (_behaviour.HasCapsule)
			{
				ReceiveCapsule(_behaviour.NeededResourceData);
			}
		}

		protected override void ResetFactoryObject()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnReceiveCapsule.UnRegisterMainThread(ReceiveCapsule);
				_behaviour.OnConsumeCapsule.UnRegisterMainThread(ConsumeCapsule);
				_behaviour.OnCapsuleFillPercChanged.UnRegisterMainThread(CapsuleFillPercChanged);
			}
			_showSupplyTankRecipientHighlight.UnRegister(ShowHighlight);
			_hideSupplyTankRecipientHighlight.UnRegister(HideHighlight);
			base.ResetFactoryObject();
		}

		private void ShowHighlight()
		{
			if (!_isShowingHighlight && _referenceFactoryObjectBehaviour.ReferencedObjects.Count <= 0)
			{
				_isShowingHighlight = true;
				_highlightEffect.SetActive(value: true);
				_canvas.gameObject.SetActive(value: true);
			}
		}

		private void HideHighlight()
		{
			if (_isShowingHighlight)
			{
				_isShowingHighlight = false;
				_highlightEffect.SetActive(value: false);
				_canvas.gameObject.SetActive(value: false);
			}
		}

		private void ReceiveCapsule(ResourceDataSO capsuleResourceData)
		{
			_capsuleView.SetLiquidToResource(capsuleResourceData);
			_capsuleView.SetLiquidFillPercentage(1f);
			if (_animator != null)
			{
				_animator.SetTrigger("Receive");
			}
		}

		private void ConsumeCapsule()
		{
			if (_animator != null)
			{
				_animator.SetTrigger("Consume");
			}
		}

		private void CapsuleFillPercChanged(float perc)
		{
			_capsuleView.SetLiquidFillPercentage(perc);
		}
	}
}

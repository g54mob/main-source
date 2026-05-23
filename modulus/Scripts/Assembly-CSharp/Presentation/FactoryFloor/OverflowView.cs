using Data.FactoryFloor.Behaviours;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class OverflowView : FactoryResourceHolderView<OverflowBehavior>
	{
		[SerializeField]
		private Animator _overflowAnimator;

		private static readonly int TriggerOnOff = Animator.StringToHash("TriggerOnOff");

		private static readonly int TurnOnOff = Animator.StringToHash("TurnOnOff");

		private bool _mainOutputWasFree = true;

		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
			_behaviour.OnMainOutputFreeUpdated.RegisterMainThread(AnimatePiston);
		}

		protected override void ResetFactoryObject()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
				_behaviour.OnMainOutputFreeUpdated.UnRegisterMainThread(AnimatePiston);
			}
			base.ResetFactoryObject();
		}

		private void AnimatePiston(bool mainOutputIsFree)
		{
			if (mainOutputIsFree != _mainOutputWasFree)
			{
				_overflowAnimator.SetBool(TurnOnOff, mainOutputIsFree);
				_overflowAnimator.SetTrigger(TriggerOnOff);
				if (mainOutputIsFree)
				{
					_audioManagerLocator.AudioManager.PlayOverflowSplitterGreen(base.transform.position);
				}
				else
				{
					_audioManagerLocator.AudioManager.PlayOverflowSplitterRed(base.transform.position);
				}
				_mainOutputWasFree = mainOutputIsFree;
			}
		}
	}
}

using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using FMODUnity;
using Presentation.FactoryFloor.FactoryObjectViews;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class PainterView : FactoryResourceHolderView<PainterBehaviour>
	{
		[SerializeField]
		private EventReference _fillPaintSFX;

		[SerializeField]
		private PainterCallFakeAnimOnMat _fillPaintAnim;

		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
			_behaviour.OnColorAdded.RegisterMainThread(HandleOnColorAdded);
			_behaviour.OnHasPaintChanged.RegisterMainThread(ShowHasPaintChanged);
		}

		private void ShowHasPaintChanged(bool hasPaint)
		{
			AnimatePaint(hasPaint);
			if (hasPaint)
			{
				_audioManagerLocator.AudioManager.PlayFactoryBehaviourViewOneShot(_fillPaintSFX, _objectView.transform.position, _objectView.FactoryObject.FactoryObjectData.ObjectSize);
			}
		}

		private void AnimatePaint(bool goUp)
		{
			_fillPaintAnim.SetGoingUp(goUp);
			_fillPaintAnim.PlayAnimation();
		}

		private void HandleOnColorAdded(ColorResource colorResource)
		{
			_fillPaintAnim.SetColor(colorResource.ColorValue);
		}

		protected override void ResetFactoryObject()
		{
			ResetView();
			base.ResetFactoryObject();
		}

		protected override void OnDestroy()
		{
			ResetView();
			base.OnDestroy();
		}

		private void ResetView()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
				_behaviour.OnColorAdded.UnRegisterMainThread(HandleOnColorAdded);
				_behaviour.OnHasPaintChanged.UnRegisterMainThread(ShowHasPaintChanged);
			}
		}
	}
}

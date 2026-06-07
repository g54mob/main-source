using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using NaughtyAttributes;
using Presentation.FactoryFloor.FactoryObjectViews;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class MonotonerView : FactoryResourceHolderView<MonotonerBehaviour>
	{
		[SerializeField]
		private GameObject _whiteMonotoner;

		[SerializeField]
		private GameObject _blackMonotoner;

		[SerializeField]
		private Color _whiteCol;

		[SerializeField]
		private Color _blackCol;

		[SerializeField]
		private PainterCallFakeAnimOnMat _fakeAnimPaint;

		protected override void Init()
		{
			base.Init();
			ChangePaintColor(_behaviour.IsPaintingBlack);
			_behaviour.OnOutputResource.RegisterMainThread(PassNewResource);
			_behaviour.OnChangedPaintMode.RegisterMainThread(ChangePaintColor);
		}

		private void ChangePaintColor(bool isBlackPaint)
		{
			_whiteMonotoner.gameObject.SetActive(!isBlackPaint);
			_blackMonotoner.gameObject.SetActive(isBlackPaint);
			_fakeAnimPaint.SetColor(isBlackPaint ? _blackCol : _whiteCol);
		}

		[Button(null, EButtonEnableMode.Always)]
		public void ToggleColor()
		{
			_behaviour.ToggleColor();
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
				_behaviour.OnOutputResource.UnRegisterMainThread(PassNewResource);
				_behaviour.OnChangedPaintMode.UnRegisterMainThread(ChangePaintColor);
			}
			_whiteMonotoner.gameObject.SetActive(value: false);
			_blackMonotoner.gameObject.SetActive(value: true);
		}

		private void PassNewResource(Resource resource, int outputIndex)
		{
			_fakeAnimPaint.PlayAnimation();
			PassResource(resource, outputIndex);
		}
	}
}

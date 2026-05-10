using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public abstract class UI_MachineMgr_FeatureMinusPlus<TFurniture> : UI_MachineMgr_MachinePanelFeature<TFurniture> where TFurniture : class
	{
		[SerializeField]
		private ClickAndHoldButton _plusButton;

		[SerializeField]
		private ClickAndHoldButton _minusButton;

		[SerializeField]
		private TMP_Text _textContainer;

		private readonly LockToggle _plusLock = new LockToggle();

		private readonly LockToggle _minusLock = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_plusButton.HeldTick += OnPlusButtonTick;
			_minusButton.HeldTick += OnMinusButtonTick;
			_plusLock.Add(_plusButton);
			_minusLock.Add(_minusButton);
		}

		protected void OnDestroy()
		{
			_plusButton.HeldTick -= OnPlusButtonTick;
			_minusButton.HeldTick -= OnMinusButtonTick;
		}

		protected abstract void OnPlusButtonTick();

		protected abstract void OnMinusButtonTick();

		protected abstract bool IsPlusButtonLocked(TFurniture current);

		protected abstract bool IsMinusButtonLocked(TFurniture current);

		protected abstract string RepaintText(TFurniture current);

		protected override void OnRepaint()
		{
			if (base._furniture is TFurniture current)
			{
				_plusLock.SetLock(IsPlusButtonLocked(current));
				_minusLock.SetLock(IsMinusButtonLocked(current));
				_textContainer.text = RepaintText(current);
			}
		}
	}
}

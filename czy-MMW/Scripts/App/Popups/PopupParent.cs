using Factory;
using Factory.Pools;
using Motorways;
using UnityEngine;

namespace Popups
{
	public class PopupParent : MonoBehaviour, IReusable
	{
		[SerializeField]
		private float _fullBlurStrengthDay;

		[SerializeField]
		private float _fullBlurStrengthNight;

		[SerializeField]
		private float _fullBlurRangeDay;

		[SerializeField]
		private float _fullBlurRangeNight;

		[SerializeField]
		private float _fullBlurOffsetDay;

		[SerializeField]
		private float _fullBlurOffsetNight;

		[SerializeField]
		private float _tweenDuration;

		[SerializeField]
		private float _firstPopupDelay;

		[Dependency]
		private MotorwaysThemeDatabase _themeDatabase;

		private bool _hasTempRange;

		private float _tempBlurOffsetDay;

		private float _tempBlurOffsetNight;

		public float FullBlurStrength
		{
			get
			{
				if (!_themeDatabase.IsInNightMode)
				{
					return _fullBlurStrengthDay;
				}
				return _fullBlurStrengthNight;
			}
		}

		public float FullBlurRange
		{
			get
			{
				if (!_themeDatabase.IsInNightMode)
				{
					return _fullBlurRangeDay;
				}
				return _fullBlurRangeNight;
			}
		}

		public float TweenDuration => _tweenDuration;

		public float FirstPopupDelay => _firstPopupDelay;

		public float FullBlurOffset()
		{
			if (_themeDatabase.IsInNightMode)
			{
				if (!_hasTempRange)
				{
					return _fullBlurOffsetNight;
				}
				return _tempBlurOffsetNight;
			}
			if (!_hasTempRange)
			{
				return _fullBlurOffsetDay;
			}
			return _tempBlurOffsetDay;
		}

		public void SetTempOffset(float day, float night)
		{
			_tempBlurOffsetDay = day;
			_tempBlurOffsetNight = night;
			_hasTempRange = true;
		}

		public void ClearTempRange()
		{
			_tempBlurOffsetDay = _fullBlurOffsetDay;
			_tempBlurOffsetNight = _fullBlurOffsetNight;
			_hasTempRange = false;
		}

		public void Reset()
		{
		}
	}
}

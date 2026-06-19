using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class TickSlider : Slider
	{
		public GameObject _tickObject;

		public RectTransform _tickContainer;

		private float _minValue;

		private float _maxValue;

		private List<GameObject> _ticks = new List<GameObject>();

		protected override void Update()
		{
			if (Application.isPlaying && (!_minValue.Equals(base.minValue) || !_maxValue.Equals(base.maxValue)))
			{
				DestroyTicks();
				CreateTicks();
			}
		}

		private void CreateTicks()
		{
			_minValue = base.minValue;
			_maxValue = base.maxValue;
			Canvas.ForceUpdateCanvases();
			if (_tickObject != null)
			{
				int num = (int)(base.maxValue - base.minValue);
				float num2 = _tickContainer.rect.width / (float)num;
				for (int i = 0; i < num + 1; i++)
				{
					GameObject gameObject = Object.Instantiate(_tickObject.gameObject, _tickContainer.transform, worldPositionStays: true);
					gameObject.GetComponent<RectTransform>().localPosition = new Vector3((float)i * num2, 0f, 0f);
					_ticks.Add(gameObject);
				}
				_tickObject.SetActive(value: false);
			}
		}

		private void DestroyTicks()
		{
			if (_tickObject != null)
			{
				_tickObject.SetActive(value: true);
				_ticks.ClearAndDestroyImmediate();
				GameObjectUtils.DestroyChildrenImmediate(_tickContainer.gameObject);
			}
		}

		protected override void OnDestroy()
		{
			DestroyTicks();
			base.OnDestroy();
		}
	}
}

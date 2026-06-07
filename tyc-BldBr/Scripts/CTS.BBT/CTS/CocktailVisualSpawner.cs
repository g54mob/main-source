using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class CocktailVisualSpawner : MonoSingleton<CocktailVisualSpawner>
	{
		[SerializeField]
		private Transform _cameraPoint;

		[SerializeField]
		private CocktailVisualElement[] _glassElement;

		private Color? liquid;

		private int currentDecoIdx = -1;

		private int _currentGlass;

		private Transform currentDeco_A;

		private void Start()
		{
			CocktailCrafter.OnItemListchanged += OnItemlistChanged;
			CocktailCrafter.OnCrafterOpen += OnCrafterOpen;
			HideAll();
		}

		private void OnCrafterOpen(bool open)
		{
			if (open)
			{
				SetCamera();
			}
			else
			{
				PhotoCamera.instance.SetCameraActived(p_acitveCamera: true);
			}
		}

		private void OnItemlistChanged(List<StockItemSO> items)
		{
		}

		public void HideAll()
		{
			for (int i = 0; i < _glassElement.Length; i++)
			{
				_glassElement[i].HideAll();
			}
		}

		private void Update()
		{
			base.transform.Rotate(Vector3.up * 3f * Time.unscaledDeltaTime);
		}

		[Button(null, EButtonEnableMode.Always)]
		public void SetCamera()
		{
			PhotoCamera.instance.SetParent(_cameraPoint);
			PhotoCamera.instance.SetCameraActived(p_acitveCamera: true);
			_currentGlass = 0;
			UpdateGlassVisual();
		}

		[Button(null, EButtonEnableMode.Always)]
		public void NextGlass()
		{
			_currentGlass++;
			if (_currentGlass >= _glassElement.Length)
			{
				_currentGlass = 0;
			}
			UpdateGlassVisual();
		}

		[Button(null, EButtonEnableMode.Always)]
		public void PreviousGlass()
		{
			_currentGlass--;
			if (_currentGlass < 0)
			{
				_currentGlass = _glassElement.Length - 1;
			}
			UpdateGlassVisual();
		}

		private void UpdateGlassVisual()
		{
			for (int i = 0; i < _glassElement.Length; i++)
			{
				if (i == _currentGlass)
				{
					_glassElement[i].Show(liquid, currentDecoIdx);
				}
				else
				{
					_glassElement[i].HideAll();
				}
			}
		}

		protected override void OnSingletonDestroy()
		{
		}

		protected override void SingletonAwake()
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.GridSystem
{
	public class GridsManager : MonoBehaviour
	{
		[SerializeField]
		private List<GridLayer> _layers;

		[SerializeField]
		private int _baseLayer;

		private bool _gridsAreShown;

		public int CurrentLayer { get; private set; }

		public static GridLayer CurrentGridLayer { get; private set; }

		public static event Action<GridLayer> LayerChanged;

		private void Start()
		{
			HideAllLayers();
		}

		private void OnEnable()
		{
			FurnitureShop.FurnitureShopStatusChanged += ShowCurrentLayer;
			FloorChangeInputsObserver.NextFloorInputPressed += NextLayer;
			FloorChangeInputsObserver.PreviousFloorInputPressed += PreviousLayer;
			if (_layers.Count != 0 && CurrentLayer < _layers.Count)
			{
				CurrentGridLayer = _layers[CurrentLayer];
			}
		}

		private void OnDisable()
		{
			FurnitureShop.FurnitureShopStatusChanged -= ShowCurrentLayer;
			FloorChangeInputsObserver.NextFloorInputPressed -= NextLayer;
			FloorChangeInputsObserver.PreviousFloorInputPressed -= PreviousLayer;
			CurrentGridLayer = null;
		}

		public GridLayer GetLayer(int p_layerID)
		{
			if (p_layerID >= 0 && p_layerID < _layers.Count)
			{
				return _layers[p_layerID];
			}
			return null;
		}

		public void HideAllLayers()
		{
			_gridsAreShown = false;
			foreach (GridLayer layer in _layers)
			{
				layer.ShowLayer(p_value: false);
			}
		}

		public void ShowCurrentLayer(bool p_value)
		{
			HideAllLayers();
			if (CurrentLayer < _layers.Count)
			{
				_gridsAreShown = p_value;
				_layers[CurrentLayer].ShowLayer(p_value);
			}
		}

		public void PreviousLayer()
		{
			if (CurrentLayer > 0)
			{
				CurrentLayer--;
				GridsManager.LayerChanged?.Invoke(_layers[CurrentLayer]);
				if (_gridsAreShown)
				{
					ShowCurrentLayer(p_value: true);
				}
			}
		}

		public void NextLayer()
		{
			if (CurrentLayer < _layers.Count - 1)
			{
				CurrentLayer++;
				GridsManager.LayerChanged?.Invoke(_layers[CurrentLayer]);
				if (_gridsAreShown)
				{
					ShowCurrentLayer(p_value: true);
				}
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void AutoFillLayers()
		{
			_layers.Clear();
			foreach (Transform child in base.transform.GetChildren())
			{
				GridController[] componentsInChildren = child.GetComponentsInChildren<GridController>();
				_layers.Add(new GridLayer(componentsInChildren.ToList()));
			}
		}

		public void SetLayers(List<GridLayer> p_gridLayers)
		{
			_layers = p_gridLayers;
		}
	}
}

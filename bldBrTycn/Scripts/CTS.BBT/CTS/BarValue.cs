using System;
using CTS.BBT;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class BarValue : CTSSingleton<BarValue>
	{
		[ShowNonSerializedField]
		private float _totalFurnituresValue;

		[ShowNonSerializedField]
		private float _totalSuperficyValue;

		[ShowNonSerializedField]
		private float _totalBuildableValue;

		[ShowNonSerializedField]
		private float _totalPaintValue;

		[field: SerializeField]
		public BarValueData Data { get; private set; }

		public float TotalFurnituresValue
		{
			get
			{
				return _totalFurnituresValue;
			}
			private set
			{
				float totalFurnituresValue = _totalFurnituresValue;
				_totalFurnituresValue = Mathf.Max(0f, value);
				if (totalFurnituresValue != _totalFurnituresValue)
				{
					BarValue.TotalValueChanged?.Invoke(TotalValue);
				}
			}
		}

		public float TotalSuperficyValue
		{
			get
			{
				return _totalSuperficyValue;
			}
			private set
			{
				float totalSuperficyValue = _totalSuperficyValue;
				_totalSuperficyValue = Mathf.Max(0f, value);
				if (totalSuperficyValue != _totalSuperficyValue)
				{
					BarValue.TotalValueChanged?.Invoke(TotalValue);
				}
			}
		}

		public float TotalBuildableValue
		{
			get
			{
				return _totalBuildableValue;
			}
			private set
			{
				float totalBuildableValue = _totalBuildableValue;
				_totalBuildableValue = Mathf.Max(0f, value);
				if (totalBuildableValue != _totalBuildableValue)
				{
					BarValue.TotalValueChanged?.Invoke(TotalValue);
				}
			}
		}

		public float TotalPaintValue
		{
			get
			{
				return _totalPaintValue;
			}
			private set
			{
				float totalPaintValue = _totalPaintValue;
				_totalPaintValue = Mathf.Max(0f, value);
				if (totalPaintValue != _totalPaintValue)
				{
					BarValue.TotalValueChanged?.Invoke(TotalValue);
				}
			}
		}

		public float TotalValue => TotalFurnituresValue + TotalSuperficyValue + TotalBuildableValue + TotalPaintValue;

		public static event Action<float> TotalValueChanged;

		protected override void OnDisabled()
		{
			Furniture.FurnitureAdded -= OnFurnitureAdded;
			Furniture.FurnitureRemoved -= OnFurnitureRemoved;
			ConstructionSystem.OnConstructionGenerated -= OnConstructionGenerated;
			SurfaceObjectPaintingSystem.OnPaintingChanged -= OnPaintingChanged;
			BuildablePlacementSystem.OnBuildablePlaced -= OnBuildableAdded;
			BuildableElement.Destroyed -= OnBuildableRemoved;
			MapEditor.LevelLoaded -= UpdateSuperficyAndPaint;
		}

		protected override void OnEnabled()
		{
			Furniture.FurnitureAdded += OnFurnitureAdded;
			Furniture.FurnitureRemoved += OnFurnitureRemoved;
			ConstructionSystem.OnConstructionGenerated += OnConstructionGenerated;
			SurfaceObjectPaintingSystem.OnPaintingChanged += OnPaintingChanged;
			BuildablePlacementSystem.OnBuildablePlaced += OnBuildableAdded;
			BuildableElement.Destroyed += OnBuildableRemoved;
			MapEditor.LevelLoaded += UpdateSuperficyAndPaint;
		}

		private void UpdateSuperficyAndPaint()
		{
			UpdateSuperficy();
			UpdatePaint();
		}

		private void UpdateSuperficy()
		{
			TotalSuperficyValue = (float)MonoSingleton<ConstructionSystem>.Instance.GetTotalInteriorCells * Data.ValuePerSquareMeter;
		}

		private void UpdatePaint()
		{
			TotalPaintValue = MonoSingleton<ConstructionSystem>.Instance.GetTotalStyleValue;
		}

		private void OnConstructionGenerated(int arg1, int arg2, int arg3)
		{
			UpdateSuperficyAndPaint();
		}

		private void OnFurnitureRemoved(Furniture furniture)
		{
			TotalFurnituresValue -= furniture.Parameters.PurchasePrice;
		}

		private void OnFurnitureAdded(Furniture furniture)
		{
			TotalFurnituresValue += furniture.Parameters.PurchasePrice;
		}

		private void OnBuildableRemoved(BuildableElement element)
		{
			TotalBuildableValue -= element.BuildableElementSO.PurchasePrice;
		}

		private void OnBuildableAdded(BuildableElement element)
		{
			TotalBuildableValue += element.BuildableElementSO.PurchasePrice;
		}

		private void OnPaintingChanged(SurfaceData oldData, SurfaceData newData)
		{
			UpdatePaint();
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}

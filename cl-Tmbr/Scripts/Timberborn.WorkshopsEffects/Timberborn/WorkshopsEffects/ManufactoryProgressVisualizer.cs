using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.InventorySystem;
using Timberborn.Workshops;

namespace Timberborn.WorkshopsEffects
{
	internal class ManufactoryProgressVisualizer : BaseComponent, IAwakableComponent, IFinishedStateListener
	{
		private Manufactory _manufactory;

		private ManufactoryProgressVisualizerSpec _manufactoryProgressVisualizerSpec;

		private readonly List<ProgressStep> _progressSteps = new List<ProgressStep>();

		public void Awake()
		{
			_manufactory = GetComponent<Manufactory>();
			_manufactoryProgressVisualizerSpec = GetComponent<ManufactoryProgressVisualizerSpec>();
			_manufactory.ProductionProgressed += OnProductionProgressed;
			_manufactory.ProductionFinished += OnProductionFinished;
			_manufactory.RecipeChanged += OnProductionRecipeChanged;
			_manufactory.Inventory.InventoryStockChanged += OnInventoryStockChanged;
			DisableComponent();
			InitializeProgressSteps();
			UpdateVisualization();
		}

		public void OnEnterFinishedState()
		{
			EnableComponent();
			UpdateVisualization();
		}

		public void OnExitFinishedState()
		{
			DisableComponent();
			UpdateVisualization();
		}

		private void OnProductionProgressed(object sender, ProductionProgressedEventArgs e)
		{
			UpdateVisualization();
		}

		private void OnProductionFinished(object sender, EventArgs e)
		{
			UpdateVisualization();
		}

		private void OnProductionRecipeChanged(object sender, EventArgs e)
		{
			UpdateVisualization();
		}

		private void OnInventoryStockChanged(object sender, InventoryAmountChangedEventArgs e)
		{
			UpdateVisualization();
		}

		private void InitializeProgressSteps()
		{
			ImmutableArray<ProgressStepSpec>.Enumerator enumerator = _manufactoryProgressVisualizerSpec.ProgressSteps.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ProgressStepSpec current = enumerator.Current;
				_progressSteps.Add(ProgressStep.Create(current, base.GameObject));
			}
		}

		private void UpdateVisualization()
		{
			float productionProgress = GetProductionProgress();
			bool flag = false;
			for (int num = _progressSteps.Count - 1; num >= 0; num--)
			{
				ProgressStep progressStep = _progressSteps[num];
				bool flag2 = productionProgress >= progressStep.Threshold && !flag;
				if (flag2)
				{
					progressStep.ShowStep();
				}
				else
				{
					progressStep.HideStep();
				}
				flag = flag || flag2;
			}
		}

		private float GetProductionProgress()
		{
			float num = (base.Enabled ? _manufactory.ProductionProgress : 0f);
			if (num == 0f && _manufactory.HasCurrentRecipe && !_manufactory.HasUnreservedCapacityForCurrentProducts())
			{
				return 1f;
			}
			return num;
		}
	}
}

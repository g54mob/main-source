using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor.Resources;
using Data.Variables.Recipes;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class DataCenterView : RecipeOperatorView
	{
		[SerializeField]
		private Renderer _renderer;

		[SerializeField]
		private SerializedDictionary<ResourceDataSO, Color> _lineColors;

		private MaterialPropertyBlock _propertyBlock;

		private static readonly int GlowColor = Shader.PropertyToID("_GlowColor");

		protected override void Init()
		{
			base.Init();
			_propertyBlock = new MaterialPropertyBlock();
			_behaviour.OnChangedRecipe.RegisterMainThread(ChangedRecipe);
			ChangedRecipe(_behaviour.CurrentRecipe);
		}

		protected override void ResetView()
		{
			base.ResetView();
			if ((bool)_behaviour)
			{
				_behaviour.OnChangedRecipe.UnRegisterMainThread(ChangedRecipe);
			}
		}

		private void ChangedRecipe(ResourceRecipe recipe)
		{
			foreach (ResourceRecipe.Output output in recipe.Outputs)
			{
				foreach (KeyValuePair<ResourceDataSO, Color> lineColor in _lineColors)
				{
					if (lineColor.Key == output.resourceDataSO)
					{
						SetLineColor(lineColor.Value);
						return;
					}
				}
			}
		}

		private void SetLineColor(Color color)
		{
			_propertyBlock.SetColor(GlowColor, color);
			_renderer.SetPropertyBlock(_propertyBlock);
		}
	}
}

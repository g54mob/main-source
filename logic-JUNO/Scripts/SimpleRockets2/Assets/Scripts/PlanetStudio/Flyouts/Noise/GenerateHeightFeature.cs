using System;
using ModApi.Planet.Modifiers.VertexData;
using ModApi.Ui.Inspector;

namespace Assets.Scripts.PlanetStudio.Flyouts.Noise
{
	public class GenerateHeightFeature : TerrainFeature
	{
		private GenerateHeight _modifier;

		public GenerateHeightFeature(GenerateHeight modifier)
		{
			_modifier = modifier;
		}

		public override void CreateModel(InspectorModel model, Action rebuildModel)
		{
			base.CreateModel(model, rebuildModel);
			model.Add(new NumericInputModel("Min Height", () => _modifier.MinHeight, delegate(double x)
			{
				_modifier.MinHeight = x;
			}));
			model.Add(new NumericInputModel("Max Height", () => _modifier.MaxHeight, delegate(double x)
			{
				_modifier.MaxHeight = x;
			}));
		}
	}
}

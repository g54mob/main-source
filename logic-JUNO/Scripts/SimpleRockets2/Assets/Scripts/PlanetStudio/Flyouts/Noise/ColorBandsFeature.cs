using System;
using Assets.Scripts.Ui.Inspector;
using ModApi;
using ModApi.Planet.Modifiers.VertexData;
using ModApi.Ui.Inspector;

namespace Assets.Scripts.PlanetStudio.Flyouts.Noise
{
	public class ColorBandsFeature : TerrainFeature
	{
		private ColorBands _modifier;

		public ColorBandsFeature(ColorBands modifier)
		{
			_modifier = modifier;
		}

		public override void CreateModel(InspectorModel model, Action rebuildModel)
		{
			base.CreateModel(model, rebuildModel);
			model.Add(new TextButtonModel("Generate Color Bands", delegate
			{
				_modifier.GenerateRandomBands();
				RefreshPlanet();
			})).Style = ButtonModel.ButtonStyle.Primary;
			ObjectInspector objectInspector = new ObjectInspector("Color Bands", _modifier);
			objectInspector.RebuildModel = rebuildModel;
			objectInspector.BuildModelForProperty(Utilities.GetProperty(() => _modifier.RandomColorBandsInput), model.AddGroup(new GroupModel(null)), _modifier, "Random Color Bands");
		}
	}
}

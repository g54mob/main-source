using System;
using ModApi.Planet.Modifiers.VertexData;
using ModApi.Ui.Inspector;

namespace Assets.Scripts.PlanetStudio.Flyouts.Noise
{
	public class VertexDataNoiseFeature : TerrainFeature
	{
		private VertexDataNoise _modifier;

		public VertexDataNoiseFeature(VertexDataNoise modifier)
		{
			_modifier = modifier;
		}

		public override void CreateModel(InspectorModel model, Action rebuildModel)
		{
			base.CreateModel(model, rebuildModel);
			model.Add(new NumericInputModel("Seed", () => _modifier.Seed, delegate(double x)
			{
				_modifier.Seed = (int)x;
			}));
			model.AddAndBuild(new SliderModel("Strength", () => (float)_modifier.Strength, delegate(float x)
			{
				_modifier.Strength = x;
			}, 0.01f, 2.5f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => x.ToString("n2");
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "The amplitude of the noise.";
			});
			model.AddAndBuild(new SliderModel("Frequency", () => (float)_modifier.Frequency, delegate(float x)
			{
				_modifier.Frequency = x;
			}, 1f, 250f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => x.ToString("n1");
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "The number of cycles per unit length.";
			});
			model.AddAndBuild(new SliderModel("Octaves", () => _modifier.Octaves, delegate(float x)
			{
				_modifier.Octaves = (int)x;
			}, 1f, 16f, wholeNumbers: true)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => x.ToString("n0");
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "The number of times to run the noise, each time modifying its frequency by lacunarity and its strength by gain. More octaves can improve visuals, but also reduce runtime performance.";
			});
			model.AddAndBuild(new SliderModel("Lacunarity", () => (float)_modifier.Lacunarity, delegate(float x)
			{
				_modifier.Lacunarity = x;
			}, 0.1f, 4f)).Build(delegate(SliderModel m)
			{
				m.DetermineVisibility = () => _modifier.Octaves > 1;
			}).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => x.ToString("n1");
			})
				.Build(delegate(SliderModel m)
				{
					m.Tooltip = "A multiplier that determines how the frequency changes for each successive octave.";
				});
			model.AddAndBuild(new SliderModel("Gain", () => (float)_modifier.Gain, delegate(float x)
			{
				_modifier.Gain = x;
			}, 0.01f, 2.5f)).Build(delegate(SliderModel m)
			{
				m.DetermineVisibility = () => _modifier.Octaves > 1;
			}).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => x.ToString("n2");
			})
				.Build(delegate(SliderModel m)
				{
					m.Tooltip = "A multiplier that determines how the strength changes with each successive octave.";
				});
		}
	}
}

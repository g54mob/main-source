using System;
using System.Collections.Generic;
using System.Linq;
using ModApi.Planet.Modifiers.VertexData;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts.Noise
{
	public class CratersFastFeature : TerrainFeature
	{
		private CratersFast _cratersFast;

		private float _frequency = 10f;

		private float _gain = 0.75f;

		private float _lacunarity = 1.5f;

		private float _maxDepth = 100f;

		private int _octaves;

		private float _randomness = 0.85f;

		public CratersFastFeature(CratersFast cratersFast)
		{
			_cratersFast = cratersFast;
			_octaves = cratersFast.CraterPasses.Length;
			if (_cratersFast.CraterPasses.Length != 0)
			{
				int num = _cratersFast.CraterPasses.Length;
				CratersFast.CraterPass craterPass = cratersFast.CraterPasses.First();
				CratersFast.CraterPass craterPass2 = cratersFast.CraterPasses.Last();
				_maxDepth = craterPass.MaxDepth;
				_frequency = craterPass.Frequency;
				_lacunarity = Mathf.Pow((float)craterPass2.Frequency / ((craterPass.Frequency == 0) ? float.Epsilon : ((float)craterPass.Frequency)), 1f / ((float)num - 1f));
				_gain = Mathf.Pow(craterPass2.MaxDepth / ((craterPass.MaxDepth == 0f) ? float.Epsilon : craterPass.MaxDepth), 1f / ((float)num - 1f));
				_randomness = (float)_cratersFast.CraterPasses.Average((CratersFast.CraterPass x) => x.Randomness);
			}
		}

		public override void CreateModel(InspectorModel model, Action rebuildModel)
		{
			base.CreateModel(model, rebuildModel);
			model.Add(new CurveModel("Crater Shape", () => _cratersFast.Curve, delegate(AnimationCurve x)
			{
				_cratersFast.Curve = x;
			}));
			GroupModel orCreateGroup = model.GetOrCreateGroup(null);
			orCreateGroup.AddAndBuild(new SliderModel("Frequency", () => _frequency, delegate(float x)
			{
				_frequency = x;
			}, 1f, 500f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => x.ToString("n1");
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "The number of craters per unit length in the first octave.";
			});
			orCreateGroup.AddAndBuild(new SliderModel("Crater Depth", () => _maxDepth, delegate(float x)
			{
				_maxDepth = x;
			}, 100f, 10000f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => x.ToString("n1") + " m";
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "The depth of the craters in the first octave.";
			});
			orCreateGroup.AddAndBuild(new SliderModel("Randomness", () => _randomness, delegate(float x)
			{
				_randomness = x;
			})).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => x.ToString("n2");
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "The amount of randomness to apply to the position of a crater within its noise boundaries. Higher values can make craters smaller. Smaller values can make craters look more grid like in their position.";
			});
			orCreateGroup.AddAndBuild(new SliderModel("Octaves", () => _octaves, delegate(float x)
			{
				_octaves = (int)x;
			}, 1f, 20f, wholeNumbers: true)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => x.ToString("n0");
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "The number of times to run the noise, each time modifying its frequency by lacunarity and its strength by gain. More octaves can improve visuals, but also reduce runtime performance.";
			});
			orCreateGroup.AddAndBuild(new SliderModel("Lacunarity", () => _lacunarity, delegate(float x)
			{
				_lacunarity = x;
			}, 0.1f, 4f)).Build(delegate(SliderModel m)
			{
				m.DetermineVisibility = () => _octaves > 1;
			}).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => x.ToString("n2");
			})
				.Build(delegate(SliderModel m)
				{
					m.Tooltip = "A multiplier that determines how the frequency changes for each successive octave.";
				});
			orCreateGroup.AddAndBuild(new SliderModel("Gain", () => _gain, delegate(float x)
			{
				_gain = x;
			}, 0.01f, 2.5f)).Build(delegate(SliderModel m)
			{
				m.DetermineVisibility = () => _octaves > 1;
			}).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => x.ToString("n2");
			})
				.Build(delegate(SliderModel m)
				{
					m.Tooltip = "A multiplier that determines how the crater depth changes for each successive octave.";
				});
			foreach (ItemModel item in orCreateGroup.Items)
			{
				if (!(item is IValueChanged valueChanged))
				{
					continue;
				}
				valueChanged.ValueChangedByUserInput += delegate(ItemModel m, string name, bool finished)
				{
					if (finished)
					{
						GenerateCraters();
					}
				};
			}
		}

		private void GenerateCraters()
		{
			float num = _maxDepth;
			float num2 = _frequency;
			int num3 = 0;
			List<CratersFast.CraterPass> list = new List<CratersFast.CraterPass>();
			float num4 = 0f;
			for (int i = 0; i < _octaves; i++)
			{
				if (_cratersFast.HasDualNoiseInputs)
				{
					num4 = Mathf.InverseLerp(0f, _octaves - 1, i);
				}
				CratersFast.CraterPass item = new CratersFast.CraterPass
				{
					Enabled = true,
					Frequency = (int)num2,
					Randomness = _randomness,
					MaxDepth = num,
					NoiseLerp = num4,
					Seed = num3,
					NoiseStrength = 1.0,
					RotationAngle = UnityEngine.Random.Range(0f, 1f),
					RotationAxis = new Vector3(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value),
					CustomCurve = new CratersFast.PassCurve
					{
						Enabled = false
					}
				};
				num *= _gain;
				num2 *= _lacunarity;
				num3++;
				list.Add(item);
			}
			_cratersFast.CraterPasses = list.ToArray();
		}
	}
}

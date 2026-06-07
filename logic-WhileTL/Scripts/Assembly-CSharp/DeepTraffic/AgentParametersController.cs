using System;
using UnityEngine;
using UnityEngine.UI;

namespace DeepTraffic
{
	public class AgentParametersController : ActiveComponent
	{
		[SceneBind("PopulationSizeField")]
		private TextFieldSliderSync populationSizeScript;

		[SceneBind("MutationRateField")]
		private TextFieldSliderSync mutationRateScript;

		[SceneBind("RandomSeedField/InputField")]
		public InputField randomSeedInputField;

		[SceneBind("RandomSeedField/NewRandomSeedButton")]
		public Button newRandomSeedButton;

		[SceneBind("IterationToEvaluateField/InputField")]
		private InputField iterationToEvaluateInputField;

		[SceneBind("ParentsPercentileField")]
		private TextFieldSliderSync parentsPercentileScript;

		[SceneBind("SpeciesMutationProbabilityField")]
		private TextFieldSliderSync speciesMutationProbabilityScript;

		[SceneBind("GeneMutationProbabilityField")]
		private TextFieldSliderSync geneMutationProbabilityScript;

		[SceneBind("CrossoverField/Toggle")]
		private Toggle crossoverToggle;

		[SceneBind("KillParentsField/Toggle")]
		private Toggle killParentsToggle;

		[SceneBind("ImageLock")]
		private Image imageLock;

		private int? populationSizeMax;

		private int? trainStepsMax;

		private string x;

		private Vector3[] corners = new Vector3[4];

		public int? PopulationSize
		{
			get
			{
				return Mathf.RoundToInt(populationSizeScript.Value);
			}
			set
			{
				if (!value.HasValue)
				{
					SetActiveParent(populationSizeScript.SliderTransform);
					return;
				}
				SetActiveParent(populationSizeScript.SliderTransform, flag: true);
				populationSizeScript.Value = value.Value;
			}
		}

		public int? PopulationSizeMax
		{
			get
			{
				return populationSizeMax;
			}
			set
			{
				populationSizeMax = value;
				if (populationSizeMax < 1)
				{
					populationSizeMax = 1;
				}
				if (PopulationSize.HasValue)
				{
					PopulationSize = Mathf.Max(PopulationSize.Value, populationSizeMax ?? int.MaxValue);
				}
				populationSizeScript.maxValue = value.Value;
			}
		}

		public float? MutationRate
		{
			get
			{
				return Mathf.Pow(10f, mutationRateScript.Value);
			}
			set
			{
				if (!value.HasValue)
				{
					SetActiveParent(mutationRateScript.SliderTransform);
					return;
				}
				SetActiveParent(mutationRateScript.SliderTransform, flag: true);
				float value2 = Mathf.Log10(value.GetValueOrDefault());
				mutationRateScript.Value = value2;
			}
		}

		public int? ParentsNumber
		{
			get
			{
				return Math.Max(2, (int)((float)PopulationSize.Value * parentsPercentileScript.Value));
			}
			set
			{
				if (!value.HasValue)
				{
					SetActiveParent(parentsPercentileScript.SliderTransform);
					return;
				}
				SetActiveParent(parentsPercentileScript.SliderTransform, flag: true);
				float value2 = (float)value.Value / (float)PopulationSize.Value;
				parentsPercentileScript.Value = value2;
			}
		}

		public double? ChromosomeMutationProbability
		{
			get
			{
				return speciesMutationProbabilityScript.Value;
			}
			set
			{
				if (!value.HasValue)
				{
					SetActiveParent(speciesMutationProbabilityScript.SliderTransform);
					return;
				}
				SetActiveParent(speciesMutationProbabilityScript.SliderTransform, flag: true);
				speciesMutationProbabilityScript.Value = (float)value.Value;
			}
		}

		public double? GeneMutationProbability
		{
			get
			{
				return geneMutationProbabilityScript.Value;
			}
			set
			{
				if (!value.HasValue)
				{
					SetActiveParent(geneMutationProbabilityScript.SliderTransform);
					return;
				}
				SetActiveParent(geneMutationProbabilityScript.SliderTransform, flag: true);
				geneMutationProbabilityScript.Value = (float)value.Value;
			}
		}

		public bool? Crossover
		{
			get
			{
				return crossoverToggle.isOn;
			}
			set
			{
				if (!value.HasValue)
				{
					SetActiveParent(crossoverToggle.transform);
					return;
				}
				SetActiveParent(crossoverToggle.transform, flag: true);
				crossoverToggle.isOn = value.Value;
			}
		}

		public bool? KillParents
		{
			get
			{
				return killParentsToggle.isOn;
			}
			set
			{
				if (!value.HasValue)
				{
					SetActiveParent(killParentsToggle.transform);
					return;
				}
				SetActiveParent(killParentsToggle.transform, flag: true);
				killParentsToggle.isOn = value.Value;
			}
		}

		public int? RandomSeed
		{
			get
			{
				int result = 0;
				if (int.TryParse(randomSeedInputField.text, out result))
				{
					return result;
				}
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					SetActiveParent(randomSeedInputField.transform);
					return;
				}
				SetActiveParent(randomSeedInputField.transform, flag: true);
				randomSeedInputField.text = Math.Max(0, value.Value).ToString();
			}
		}

		public int? TrainSteps
		{
			get
			{
				int result = 0;
				if (int.TryParse(iterationToEvaluateInputField.text, out result))
				{
					return result;
				}
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					SetActiveParent(iterationToEvaluateInputField.transform);
					return;
				}
				SetActiveParent(iterationToEvaluateInputField.transform, flag: true);
				iterationToEvaluateInputField.text = Math.Max(1, value.Value).ToString();
			}
		}

		public int? TrainStepsMax
		{
			get
			{
				return trainStepsMax;
			}
			set
			{
				trainStepsMax = value;
				if (trainStepsMax < 1)
				{
					trainStepsMax = 1;
				}
				if (TrainSteps.HasValue)
				{
					TrainSteps = Mathf.Max(TrainSteps.Value, trainStepsMax ?? int.MaxValue);
				}
			}
		}

		public float Width { get; private set; }

		private string PercentileToPercent(float value)
		{
			return value.ToString("p0");
		}

		public void Init(CarSliderParamsBounds carSliderParamsBounds)
		{
			base.Init();
			populationSizeScript.Init((float x) => x.ToString(), (carSliderParamsBounds.populationSize != "-") ? carSliderParamsBounds.GetPopulationSizes() : null);
			populationSizeScript.maxValue = PopulationSizeMax ?? 2;
			geneMutationProbabilityScript.Init(PercentileToPercent, (carSliderParamsBounds.geneMutationProbability != "-") ? carSliderParamsBounds.GetGeneMutationProbabilities() : null);
			speciesMutationProbabilityScript.Init(PercentileToPercent, (carSliderParamsBounds.chromosomeMutationProbability != "-") ? carSliderParamsBounds.GetChromosomeMutationProbabilities() : null);
			parentsPercentileScript.Init(PercentileToPercent, (carSliderParamsBounds.selectionPercentile != "-") ? carSliderParamsBounds.GetSelectionPercentiles() : null);
			mutationRateScript.Init(delegate(float x)
			{
				float num = Mathf.Pow(10f, x);
				int num2 = (int)Mathf.Max(1f, x + 1f);
				return num.ToString("f" + Mathf.Max(0, 4 - num2).ToString("d"));
			}, (carSliderParamsBounds.mutationRate != "-") ? carSliderParamsBounds.GetMutationRates() : null);
		}

		protected override void OnInit()
		{
			base.OnInit();
			SceneBindContainer.BindObjects(this, base.transform);
			populationSizeScript.Init((float x) => x.ToString());
			parentsPercentileScript.Init(PercentileToPercent);
			speciesMutationProbabilityScript.Init(PercentileToPercent);
			geneMutationProbabilityScript.Init(PercentileToPercent);
			mutationRateScript.Init(delegate(float x)
			{
				Mathf.Pow(10f, x);
				float num = Mathf.Max(1f, x + 1f);
				return x.ToString("f" + Mathf.Max(0f, 4f - num).ToString("d"));
			});
			crossoverToggle.onValueChanged.AddListener(delegate(bool x)
			{
				if (!x && killParentsToggle.isOn)
				{
					killParentsToggle.isOn = false;
				}
			});
			killParentsToggle.onValueChanged.AddListener(delegate(bool x)
			{
				if (x && !crossoverToggle.isOn)
				{
					crossoverToggle.isOn = true;
				}
			});
			randomSeedInputField.onEndEdit.AddListener(delegate(string s)
			{
				CheckValueIsNonNegative(s, randomSeedInputField);
			});
			iterationToEvaluateInputField.onEndEdit.AddListener(delegate(string s)
			{
				CheckValueIsPositive(s, iterationToEvaluateInputField);
			});
			iterationToEvaluateInputField.onEndEdit.AddListener(delegate(string s)
			{
				UpperBound(s, iterationToEvaluateInputField, TrainStepsMax);
			});
			newRandomSeedButton.onClick.AddListener(delegate
			{
				RandomSeed = UnityEngine.Random.Range(1, 100000000);
			});
			SetReadonly(value: false);
			base.gameObject.GetComponent<RectTransform>().GetWorldCorners(corners);
			Width = corners[2].x - corners[1].x;
		}

		private void CheckValueIsNonNegative(string x, InputField field)
		{
			if (Convert.ToDouble(x) < 0.0)
			{
				field.text = "0";
			}
		}

		private void CheckValueIsPositive(string x, InputField field)
		{
			if (Convert.ToDouble(x) < 1.0)
			{
				field.text = "1";
			}
		}

		private void UpperBound<T>(string x, InputField field, T? bound) where T : struct, IComparable
		{
			double num = Convert.ToDouble(x);
			if (bound.HasValue && Convert.ToDouble(bound) < num)
			{
				field.text = bound.ToString();
			}
		}

		public void SetReadonly(bool value)
		{
			imageLock.gameObject.SetActive(value);
		}

		private void SetActiveParent(Transform tr, bool flag = false)
		{
			tr.parent.gameObject.SetActive(flag);
		}
	}
}

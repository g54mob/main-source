using System.Collections.Generic;
using System.Linq;
using SettingScripts;
using SettingsScripts;
using SimulationScripts;
using TMPro;
using UIScripts.SettingHandles.References;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public class SimulationMetricHandle : MonoBehaviour
	{
		private SimulationMetric simulationMetric;

		public SettingDropdownReference metricDropdownRef;

		public ChoiceSettingDropdown<ChoiceSetting<SimMetric>, SimMetric> metricDropdown;

		public TMP_Dropdown argumentDropdown;

		public TextLineReference argumentFieldRef;

		public StringFieldHandle argumentField;

		public GameObject placeholder;

		public TooltipTrigger argumentTooltip;

		private List<string> options = new List<string>();

		private SimMetricTargetType targetType;

		private bool hasInit;

		private SimMetric prevMetric;

		public void Initialize(SimulationMetric metric)
		{
			simulationMetric = metric;
			metricDropdown = new ChoiceSettingDropdown<ChoiceSetting<SimMetric>, SimMetric>(simulationMetric.metric, metricDropdownRef);
			argumentField = new StringFieldHandle(simulationMetric.argument, argumentFieldRef);
			argumentDropdown.onValueChanged.AddListener(SetArgumentFromDropdown);
			simulationMetric.metric.Subscribe(OnMetricChanged);
			simulationMetric.argument.Subscribe(OnArgumentChanged);
			OnMetricChanged(simulationMetric.metric.val);
			OnArgumentChanged(simulationMetric.argument.val);
			hasInit = true;
		}

		public void OnMetricChanged(SimMetric metric)
		{
			if (!metric.MetricHasArgument())
			{
				argumentDropdown.gameObject.SetActive(value: false);
				argumentFieldRef.gameObject.SetActive(value: false);
				placeholder.SetActive(value: true);
				targetType = metric.TargetOfMetric();
				prevMetric = metric;
				return;
			}
			placeholder.SetActive(value: false);
			if (metric.MetricHasArgumentList())
			{
				argumentDropdown.gameObject.SetActive(value: true);
				argumentFieldRef.gameObject.SetActive(value: false);
				ReloadArgumentList(metric);
			}
			else
			{
				argumentDropdown.gameObject.SetActive(value: false);
				argumentFieldRef.gameObject.SetActive(value: true);
				if (metric == SimMetric.Constant)
				{
					argumentFieldRef.lineField.contentType = TMP_InputField.ContentType.DecimalNumber;
					argumentTooltip.UpdateText("Type out the value", "");
					if (hasInit && prevMetric != SimMetric.Constant)
					{
						simulationMetric.argument.SetValue("0");
					}
				}
			}
			prevMetric = metric;
			targetType = metric.TargetOfMetric();
		}

		private void OnEnable()
		{
			if (hasInit)
			{
				ReloadArgumentList(prevMetric);
			}
		}

		private void ReloadArgumentList(SimMetric metric)
		{
			if (!argumentDropdown.gameObject.activeSelf)
			{
				return;
			}
			options.Clear();
			if ((metric == SimMetric.MaterialCount || metric == SimMetric.MaterialBiomass) && targetType != SimMetricTargetType.Pellets)
			{
				MatterMaterialManager.PhysicalMaterials.ForEach(delegate(MatterMaterial m)
				{
					options.Add(m.Name);
				});
			}
			else if (metric == SimMetric.TagCount || metric == SimMetric.TagBiomass)
			{
				if (ScenarioSettings.Instance.isChallenge)
				{
					options.Add("Champion");
				}
				DefaultBibitesPanel.instance.bibiteItems.ForEach(delegate(BibiteSettingsHandle i)
				{
					switch (i.settings.tagging.val)
					{
					case Tagging.SpeciesTagging:
						options.Add(i.template.speciesName);
						break;
					case Tagging.CustomTagging:
						options.Add(i.settings.customTag.val);
						break;
					}
				});
			}
			argumentDropdown.options = options.Select((string o) => new TMP_Dropdown.OptionData(o)).ToList();
			if (hasInit && prevMetric != metric)
			{
				simulationMetric.argument.SetValue(argumentDropdown.options[0].text);
			}
		}

		private void SetArgumentFromDropdown(int val)
		{
			simulationMetric.argument.SetValue(argumentDropdown.options[argumentDropdown.value].text);
		}

		private void OnArgumentChanged(string arg)
		{
			if (simulationMetric.metric.val.MetricHasArgumentList())
			{
				int num = argumentDropdown.options.FindIndex((TMP_Dropdown.OptionData o) => o.text == arg);
				if (num < 0)
				{
					argumentDropdown.value = 0;
				}
				else if (argumentDropdown.value != num)
				{
					argumentDropdown.value = num;
				}
			}
		}

		private void OnDestroy()
		{
			if (hasInit)
			{
				simulationMetric.metric.UnSubscribe(OnMetricChanged);
				simulationMetric.argument.UnSubscribe(OnArgumentChanged);
			}
		}
	}
}

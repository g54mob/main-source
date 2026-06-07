using System;
using UnityEngine;

public class EnableByFeatureToggle : MonoBehaviour
{
	[StringEnumSearch(typeof(Feature))]
	[SerializeField]
	private string _ifFeatureIsEnabled = Feature.OptionsDebugMenu.ToString();

	[SerializeField]
	private bool _isEnabledFromFeature = true;

	[SerializeField]
	private GameObject[] _targets;

	protected void OnEnable()
	{
		if (Enum.TryParse<Feature>(_ifFeatureIsEnabled, out var result))
		{
			bool active = ((!FeatureToggle.IsFeatureEnabled(result)) ? (!_isEnabledFromFeature) : _isEnabledFromFeature);
			GameObject[] targets = _targets;
			for (int i = 0; i < targets.Length; i++)
			{
				targets[i].SetActive(active);
			}
		}
	}
}

using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval
{
	public class TreeLeavesWindSpeed : MonoBehaviour
	{
		[SerializeField]
		private WindZone windZone;

		[SerializeField]
		private float speedMultiplier = 1f;

		private void Start()
		{
			MonoSingleton<GlobalShaderVariables>.Instance.EnvironmentUpdateEvent += UpdateWindSpeed;
		}

		private void OnDestroy()
		{
			if (MonoSingleton<GlobalShaderVariables>.IsInstantiated())
			{
				MonoSingleton<GlobalShaderVariables>.Instance.EnvironmentUpdateEvent -= UpdateWindSpeed;
			}
		}

		private void UpdateWindSpeed(Dictionary<string, float> values)
		{
			windZone.windMain = values["WindIntensity"] * speedMultiplier;
		}
	}
}

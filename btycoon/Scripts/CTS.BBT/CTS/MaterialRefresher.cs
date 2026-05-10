using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class MaterialRefresher : CTSBehaviour
	{
		[SerializeField]
		private Shader _shaderToFix;

		[Button(null, EButtonEnableMode.Always)]
		private void FixAll()
		{
		}
	}
}

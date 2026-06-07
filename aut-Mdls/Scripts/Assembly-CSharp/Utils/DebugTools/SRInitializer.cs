using Data.FeatureFlags.Validators;
using UnityEngine;

namespace Utils.DebugTools
{
	public class SRInitializer : MonoBehaviour
	{
		[SerializeField]
		private EnableSRDebuggerValidator _validator;

		private void Awake()
		{
			if (_validator.IsEnabledFeatureFlag())
			{
				SRDebug.Init();
			}
		}
	}
}

using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class GenerationPreference : MonoBehaviour
	{
		public bool useLargeModel;

		public string staffBodyModelVariant;

		public string pyjamaKey;

		public List<GameObject> excludeFromPyjamaModel;

		public void ApplySleepingModelExclusionScripts()
		{
		}
	}
}

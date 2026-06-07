using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class AlteregoDLSSConnection : ConnectionWithOptions<string>
	{
		protected List<string> _labels;

		private static bool currentValue;

		public bool CheckForCameraMarker = true;

		protected List<int> _enumOptionsAsIntegers = new List<int>(6);

		public static bool CurrentValue => currentValue;

		public AlteregoDLSSConnection()
		{
			Logger.LogWarning("AlteregoDLSSConnection: Alterego DLSS is not yet set up. Please add DLSS as a post processing effect and install the NVIDIA package. Please contact Alterego Games for more info and support.");
		}

		public bool IsSupported()
		{
			currentValue = false;
			return false;
		}

		public override List<string> GetOptionLabels()
		{
			Logger.LogWarning("AlteregoDLSSConnection: Alterego DLSS is not yet set up. Please add DLSS as a post processing effect and install the NVIDIA package. Please contact Alterego Games for more info and support.");
			return _labels;
		}

		protected List<int> getOptionsEnumList()
		{
			Logger.LogWarning("AlteregoDLSSConnection: Alterego DLSS is not yet set up. Please add DLSS as a post processing effect and install the NVIDIA package. Please contact Alterego Games for more info and support.");
			return _enumOptionsAsIntegers;
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			if (optionLabels == null || optionLabels.Count != 4)
			{
				Debug.LogError("Invalid new labels. Need to be four.");
			}
			else
			{
				_labels = optionLabels;
			}
		}

		public override void RefreshOptionLabels()
		{
			_labels = null;
			GetOptionLabels();
		}

		public override int Get()
		{
			Logger.LogWarning("AlteregoDLSSConnection: Alterego DLSS is not yet set up. Please add DLSS as a post processing effect and install the NVIDIA package. Please contact Alterego Games for more info and support.");
			return 0;
		}

		public override void Set(int index)
		{
			NotifyListenersIfChanged(index);
		}
	}
}

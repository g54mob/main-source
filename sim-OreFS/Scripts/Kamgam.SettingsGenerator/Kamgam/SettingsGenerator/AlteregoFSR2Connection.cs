using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class AlteregoFSR2Connection : ConnectionWithOptions<string>
	{
		protected List<string> _labels;

		public AlteregoFSR2Connection()
		{
			Logger.LogWarning("AlteregoFSRConnection: Alterego FSR is not yet set up. Please consult the Alterego Games Manual for more info and support.");
		}

		public bool IsSupported()
		{
			return false;
		}

		public override List<string> GetOptionLabels()
		{
			Logger.LogWarning("AlteregoFSR2Connection: Alterego FSR is not yet set up. Please consult the Alterego Games Manual for more info and support.");
			return _labels;
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
			Logger.LogWarning("AlteregoFSR2Connection: Alterego FSR2 is not yet set up. Please consult the Alterego Games Manual for more info and support.");
			return 0;
		}

		public override void Set(int index)
		{
			NotifyListenersIfChanged(index);
		}
	}
}

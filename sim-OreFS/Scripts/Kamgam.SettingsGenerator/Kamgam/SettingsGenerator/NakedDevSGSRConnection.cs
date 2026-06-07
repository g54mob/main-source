using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class NakedDevSGSRConnection : ConnectionWithOptions<string>
	{
		protected List<string> _labels;

		public NakedDevSGSRConnection()
		{
			Logger.LogWarning("NakedDevSGSRConnection: SGSR is not yet set up. Please consult The Naked Dev Games Manual for more info and support. https://docs.google.com/document/d/1s8tQYdpSMZRLf1gndRSekam-t9FYGE_e9QLgVJAbeH8");
		}

		public bool IsSupported()
		{
			return false;
		}

		public override List<string> GetOptionLabels()
		{
			Logger.LogWarning("NakedDevSGSRConnection: The Naked Dev SGSR is not yet set up. Please consult the Naked Dev Manual for more info and support. https://docs.google.com/document/d/1s8tQYdpSMZRLf1gndRSekam-t9FYGE_e9QLgVJAbeH8");
			return _labels;
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			if (optionLabels == null)
			{
				Debug.LogError("Invalid new labels.");
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
			Logger.LogWarning("NakedDevSGSRConnection: The Naked Dev SGSR is not yet set up. Please consult the Alterego Games Manual for more info and support. https://docs.google.com/document/d/1s8tQYdpSMZRLf1gndRSekam-t9FYGE_e9QLgVJAbeH8");
			return 0;
		}

		public override void Set(int index)
		{
			NotifyListenersIfChanged(index);
		}
	}
}

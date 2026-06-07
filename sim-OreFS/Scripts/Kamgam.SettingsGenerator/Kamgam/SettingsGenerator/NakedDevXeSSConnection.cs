using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class NakedDevXeSSConnection : ConnectionWithOptions<string>
	{
		protected List<string> _labels;

		public NakedDevXeSSConnection()
		{
			Logger.LogWarning("NakedDevXeSSConnection: XeSS is not yet set up. Please consult The Naked Dev Games Manual for more info and support. https://docs.google.com/document/d/1nb1cdNNc9zzmvbDbwPERKm21g_Cp8o9V2sjVV1JsQNM");
		}

		public bool IsSupported()
		{
			return false;
		}

		public override List<string> GetOptionLabels()
		{
			Logger.LogWarning("NakedDevXeSSConnection: The Naked Dev XeSS is not yet set up. Please consult the Naked Dev Manual for more info and support. https://docs.google.com/document/d/1nb1cdNNc9zzmvbDbwPERKm21g_Cp8o9V2sjVV1JsQNM");
			return _labels;
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			if (optionLabels == null)
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
			Logger.LogWarning("NakedDevXeSSConnection: The Naked Dev XeSS is not yet set up. Please consult the The Naked Dev Manual for more info and support. https://docs.google.com/document/d/1nb1cdNNc9zzmvbDbwPERKm21g_Cp8o9V2sjVV1JsQNM");
			return 0;
		}

		public override void Set(int index)
		{
			NotifyListenersIfChanged(index);
		}
	}
}

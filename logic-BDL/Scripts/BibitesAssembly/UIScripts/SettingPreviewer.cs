using System.Collections.Generic;
using SettingScripts;
using UnityEngine;

namespace UIScripts
{
	public class SettingPreviewer : MonoBehaviour
	{
		protected List<ChangingSetting> settings;

		protected bool initialized;

		public virtual void InitializePreview()
		{
			if (!initialized)
			{
				settings.ForEach(delegate(ChangingSetting s)
				{
					s.OnChange.AddListener(UpdatePreview);
				});
				UpdatePreview();
				initialized = true;
			}
		}

		protected virtual void UpdatePreview()
		{
		}

		private void OnDestroy()
		{
			settings.ForEach(delegate(ChangingSetting s)
			{
				s.OnChange.RemoveListener(UpdatePreview);
			});
		}
	}
}

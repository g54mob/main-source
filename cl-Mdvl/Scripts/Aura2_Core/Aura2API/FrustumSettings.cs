using System;
using UnityEngine;

namespace Aura2API
{
	[Serializable]
	public class FrustumSettings
	{
		public AuraBaseSettings baseSettings;

		public AuraQualitySettings qualitySettings;

		public AuraBaseSettings BaseSettings
		{
			get
			{
				if (baseSettings == null)
				{
					baseSettings = ScriptableObject.CreateInstance<AuraBaseSettings>();
					baseSettings.name = "New Aura Base Settings";
				}
				return baseSettings;
			}
			set
			{
				baseSettings = value;
			}
		}

		public AuraQualitySettings QualitySettings
		{
			get
			{
				if (qualitySettings == null)
				{
					qualitySettings = ScriptableObject.CreateInstance<AuraQualitySettings>();
					qualitySettings.name = "Default Aura Quality Settings";
				}
				return qualitySettings;
			}
			set
			{
				qualitySettings = value;
				RaiseOnQualityChanged();
			}
		}

		public event Action OnFrustumQualityChanged;

		public void LoadBaseSettings(AuraBaseSettings baseSettings)
		{
			BaseSettings = baseSettings;
		}

		public void LoadQualitySettings(AuraQualitySettings qualitySettings)
		{
			QualitySettings = qualitySettings;
		}

		public void RaiseOnQualityChanged()
		{
			if (this.OnFrustumQualityChanged != null)
			{
				this.OnFrustumQualityChanged();
			}
		}
	}
}

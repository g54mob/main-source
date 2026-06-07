using Coffee.UIParticleInternal;
using UnityEngine;

namespace Coffee.UIExtensions
{
	public class UIParticleProjectSettings : PreloadedProjectSettings<UIParticleProjectSettings>
	{
		[Header("Setting")]
		[SerializeField]
		internal bool m_EnableLinearToGamma = true;

		[Header("Editor")]
		[Tooltip("Hide the automatically generated objects.\n  - UIParticleRenderer\n  - UIParticle BakingCamera")]
		[SerializeField]
		private bool m_HideGeneratedObjects = true;

		public static bool enableLinearToGamma
		{
			get
			{
				return PreloadedProjectSettings<UIParticleProjectSettings>.instance.m_EnableLinearToGamma;
			}
			set
			{
				PreloadedProjectSettings<UIParticleProjectSettings>.instance.m_EnableLinearToGamma = value;
			}
		}

		public static HideFlags globalHideFlags
		{
			get
			{
				if (!PreloadedProjectSettings<UIParticleProjectSettings>.instance.m_HideGeneratedObjects)
				{
					return HideFlags.DontSave | HideFlags.NotEditable;
				}
				return HideFlags.HideAndDontSave | HideFlags.HideInInspector;
			}
		}
	}
}

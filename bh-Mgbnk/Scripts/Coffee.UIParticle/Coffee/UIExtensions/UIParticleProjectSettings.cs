using Coffee.UIParticleInternal;
using UnityEngine;

namespace Coffee.UIExtensions
{
	public class UIParticleProjectSettings : PreloadedProjectSettings<UIParticleProjectSettings>
	{
		[Header("Setting")]
		[SerializeField]
		internal bool m_EnableLinearToGamma;

		[Header("Editor")]
		[Tooltip("Hide the automatically generated objects.\n  - UIParticleRenderer\n  - UIParticle BakingCamera")]
		[SerializeField]
		private bool m_HideGeneratedObjects;

		public static bool enableLinearToGamma
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static HideFlags globalHideFlags => default(HideFlags);
	}
}

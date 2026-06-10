using UnityEngine;

namespace FMODUnity
{
	public class PlatformGroup : Platform
	{
		[SerializeField]
		private string displayName;

		[SerializeField]
		private Legacy.Platform legacyIdentifier;

		public override string DisplayName => null;

		public override void DeclareRuntimePlatforms(Settings settings)
		{
		}
	}
}

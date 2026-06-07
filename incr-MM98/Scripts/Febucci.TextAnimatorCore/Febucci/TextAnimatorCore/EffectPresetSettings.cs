using System;

namespace Febucci.TextAnimatorCore
{
	[Serializable]
	public struct EffectPresetSettings
	{
		public float delayBeforePersistant;

		public float timeToSyncPersistant;

		public bool bakeCurves;
	}
}

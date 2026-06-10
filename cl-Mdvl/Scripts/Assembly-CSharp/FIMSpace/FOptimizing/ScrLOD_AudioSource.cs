using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public sealed class ScrLOD_AudioSource : ScrLOD_Base
	{
		[SerializeField]
		private LODI_AudioSource settings;

		public override ILODInstance GetLODInstance()
		{
			return settings;
		}

		public ScrLOD_AudioSource()
		{
			settings = new LODI_AudioSource();
		}

		public override ScrLOD_Base GetScrLODInstance()
		{
			return ScriptableObject.CreateInstance<ScrLOD_AudioSource>();
		}

		public override ScrLOD_Base CreateNewScrCopy()
		{
			ScrLOD_AudioSource scrLOD_AudioSource = ScriptableObject.CreateInstance<ScrLOD_AudioSource>();
			scrLOD_AudioSource.settings = settings.GetCopy() as LODI_AudioSource;
			return scrLOD_AudioSource;
		}

		public override ScriptableLODsController GenerateLODController(Component target, ScriptableOptimizer optimizer)
		{
			AudioSource audioSource = target as AudioSource;
			if (!audioSource)
			{
				audioSource = target.GetComponentInChildren<AudioSource>();
			}
			if ((bool)audioSource && !optimizer.ContainsComponent(audioSource))
			{
				return new ScriptableLODsController(optimizer, audioSource, -1, "Audio Source", this);
			}
			return null;
		}
	}
}

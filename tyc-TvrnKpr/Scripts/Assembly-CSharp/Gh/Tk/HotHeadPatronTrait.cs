using LitJson;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[UnlockableTrait]
	[TraitRarityConfig(0f, "elf")]
	[TraitRarityConfig(0.005f, "halfling")]
	[TraitRarityConfig(0.01f, null)]
	[TraitRarityConfig(0.03f, "orc")]
	public class HotHeadPatronTrait : PatronTrait
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		private PatienceStat _patienceStat;

		private const float _secondsBeforeShowingEventCam = 15f;

		[JsonIgnore]
		private string _eventCamId;

		[JsonIgnore]
		private EventCameraSettings _eventCamSettings;

		[PersistenceOptIn]
		private bool IsEffectActive { get; set; }

		[Preserve]
		protected HotHeadPatronTrait()
		{
		}

		public HotHeadPatronTrait(Patron owner)
		{
		}

		public override void Init()
		{
		}

		public override void Update()
		{
		}

		private void UpdateEffectTimings()
		{
		}

		private void UpdateEventCameraCountdown()
		{
		}

		private void SetEffectActive(bool active)
		{
		}
	}
}

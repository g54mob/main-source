using TH20.Timeline;

namespace TH20
{
	public class MetagameEventBehaviour : EventBehaviour
	{
		private MetagameMap _metagameMap;

		public void Initialise(MetagameMap metagameMap)
		{
			_metagameMap = metagameMap;
		}

		public override void OnClipStart(string eventName, string eventTag)
		{
			if (!(_metagameMap == null) && eventName == "RaiseHospital")
			{
				MetagameHospitalVisual cutsceneAnimatable = _metagameMap.CutsceneManager.GetCutsceneAnimatable(eventTag);
				if (cutsceneAnimatable != null)
				{
					cutsceneAnimatable.SetIsUnlocked(isUnlocked: true, instant: false);
				}
			}
		}
	}
}

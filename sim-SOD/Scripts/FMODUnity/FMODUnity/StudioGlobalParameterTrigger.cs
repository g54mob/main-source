using FMOD;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.Serialization;

namespace FMODUnity
{
	[AddComponentMenu("FMOD Studio/FMOD Studio Global Parameter Trigger")]
	public class StudioGlobalParameterTrigger : EventHandler
	{
		[FormerlySerializedAs("parameter")]
		[ParamRef]
		public string Parameter;

		public EmitterGameEvent TriggerEvent;

		[FormerlySerializedAs("value")]
		public float Value;

		private PARAMETER_DESCRIPTION parameterDescription;

		public PARAMETER_DESCRIPTION ParameterDesctription => default(PARAMETER_DESCRIPTION);

		private RESULT Lookup()
		{
			return default(RESULT);
		}

		private void Awake()
		{
		}

		protected override void HandleGameEvent(EmitterGameEvent gameEvent)
		{
		}

		public void TriggerParameters()
		{
		}
	}
}

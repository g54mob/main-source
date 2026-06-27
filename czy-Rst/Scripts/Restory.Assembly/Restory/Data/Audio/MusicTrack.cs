using System;
using System.Collections.Generic;
using Restory.Audio;
using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.Audio
{
	[CreateAssetMenu(fileName = "MusicTrack", menuName = "Restory/Audio/Music Track", order = 5)]
	public class MusicTrack : RestoryEntityInfoBase
	{
		[Serializable]
		public struct ParameterValues
		{
			public string ParameterName;

			public float OnParameterValue;

			public float OffParameterValue;

			public float FadeInDuration;

			public float FadeOutDuration;
		}

		[SerializeField]
		private MusicSoundEvent musicSoundEvent;

		[SerializeField]
		private ParameterValues[] parametersValues = Array.Empty<ParameterValues>();

		public MusicSoundEvent MusicSoundEvent => musicSoundEvent;

		public IReadOnlyList<ParameterValues> ParametersValues => parametersValues;
	}
}

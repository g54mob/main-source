using System;
using Libs;
using UnityEngine;

namespace SaveData
{
	[Serializable]
	public class PlayChallengeData : ISerializationCallbackReceiver
	{
		[SerializeField]
		private JDictionary<eChallengeId, ChallengeData> _challengeDict;

		public JDictionary<eChallengeId, ChallengeData> ChallengeDict
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void AddChallengeData(MstChallengeDataEntities entity)
		{
		}

		public void ClearProcess(eChallengeId challengeId, eWriterId writerId)
		{
		}

		public void RegisterWaveCount(eChallengeId challengeId, eWriterId writerId, int waveCount)
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public bool IsAllAnyClear()
		{
			return false;
		}
	}
}

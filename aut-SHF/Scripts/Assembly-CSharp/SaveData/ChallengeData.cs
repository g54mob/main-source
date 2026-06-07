using System;
using System.Collections.Generic;

namespace SaveData
{
	[Serializable]
	public class ChallengeData
	{
		[Serializable]
		public class ChallengeWriterData
		{
			public eWriterId writerId;

			public int clearWave;

			public bool clear;

			public int maxScore;
		}

		public eChallengeId challengeId;

		public bool isEndless;

		public List<ChallengeWriterData> challengeWriterDatas;

		public ChallengeData(MstChallengeDataEntities entity)
		{
		}

		public void Clear(eWriterId writer, bool isClear = true)
		{
		}

		public void RegisterScore(eWriterId writer, int score)
		{
		}

		public void ClearWave(eWriterId writer, int waveCount)
		{
		}

		public int GetClearWave(eWriterId writer)
		{
			return 0;
		}

		public bool IsClear(eWriterId writer)
		{
			return false;
		}

		public bool IsAnyClear()
		{
			return false;
		}
	}
}

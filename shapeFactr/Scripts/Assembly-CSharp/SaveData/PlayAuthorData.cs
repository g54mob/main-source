using System;
using Libs;
using UnityEngine;

namespace SaveData
{
	[Serializable]
	public class PlayAuthorData : ISerializationCallbackReceiver
	{
		[SerializeField]
		private JDictionary<eWriterId, AuthorUnlockData> _authorDict;

		public JDictionary<eWriterId, AuthorUnlockData> AuthorDict
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool ClearWriterProcess(eWriterId id, eModeType mode, bool clearLastStage = false)
		{
			return false;
		}

		public void AllOffWaitAscensionEvent()
		{
		}

		public void AllApplyMaxScore()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void OnBeforeSerialize()
		{
		}
	}
}

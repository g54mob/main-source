using System.Collections.Generic;
using UnityEngine.Events;

namespace UI
{
	public class SelectMasterDialogParam
	{
		public List<eWriterId> writerIds;

		public UnityAction<eWriterId> onSelectAction;

		public UnityAction onCancelAction;

		public eChallengeId challengeId;

		public SelectMasterDialogParam(List<eWriterId> writerIds, UnityAction<eWriterId> onSelectAction, UnityAction onCancelAction, eChallengeId challengeId = eChallengeId.None)
		{
		}
	}
}

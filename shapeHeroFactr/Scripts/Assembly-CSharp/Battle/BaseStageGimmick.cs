using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

namespace Battle
{
	public abstract class BaseStageGimmick : MonoBehaviour
	{
		public virtual SortingGroup[] GetDecorationPoints()
		{
			return null;
		}

		public virtual void SetFirstGimmick()
		{
		}

		public virtual Sequence PlayBattleGimmick()
		{
			return null;
		}

		public virtual Sequence PreMoveBossBattleGimmick()
		{
			return null;
		}

		public virtual Sequence PlayBossBattleGimmick()
		{
			return null;
		}

		public virtual Sequence GetFirstStageSequence()
		{
			return null;
		}
	}
}

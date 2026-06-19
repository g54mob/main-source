using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LevelProgressTotalStars : LevelProgressPrerequisite
	{
		[SerializeField]
		private int _totalStars = 1;

		public override bool IsComplete(Metagame metagame)
		{
			return metagame.TotalStars() >= _totalStars;
		}

		public override string RequiredDescription()
		{
			return ScriptLocalization.Tooltip.LevelPrerequisite_TotalStars_CS.Replace("{[COUNT]}", _totalStars.ToString());
		}
	}
}

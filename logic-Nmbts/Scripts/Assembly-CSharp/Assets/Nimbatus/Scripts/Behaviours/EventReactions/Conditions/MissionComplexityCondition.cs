using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class MissionComplexityCondition : NimbatusCondition
	{
		public EIntegerCompareType CompareType;

		public EMissionComplexity Value;

		private EMissionComplexity _complexity;

		protected override void OnInit()
		{
			_complexity = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.MissionComplexity;
		}

		public override bool IsTrue()
		{
			return NumberCompare.Compare((int)_complexity, CompareType, (int)Value);
		}
	}
}

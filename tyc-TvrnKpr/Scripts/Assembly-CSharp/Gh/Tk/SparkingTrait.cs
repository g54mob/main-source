using System.Collections.Generic;

namespace Gh.Tk
{
	public class SparkingTrait : GameObjectXTrait
	{
		private readonly List<GameObjectX> _surroundingFlammableObjects;

		private SparksGenerator _sparksGenerator;

		private TooltipData _breakdownTooltipData;

		public const float SPARKS_DANGER_THRESHOLD = 0.6f;

		[PersistenceOptIn]
		private bool _errorInfoSet;

		public SparksGenerator SparksGenerator => null;

		protected SparkingTrait()
		{
		}

		public SparkingTrait(GameObjectX owner)
		{
		}

		public override void Init()
		{
		}

		public void UpdateSurroundingFlammableObjects()
		{
		}

		private void ClearSurroundingFlammableObjects()
		{
		}

		private void DamageStat_ValueChanged(object sender, ValueChangedEventArgs<float> e)
		{
		}

		public override void OnRemoving()
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		public virtual void Spark(string transformName = null)
		{
		}

		protected override string GetTooltipTextKey()
		{
			return null;
		}

		private string GetSparkChanceLabel(SparkChance sparkChance)
		{
			return null;
		}

		public override void Update()
		{
		}
	}
}

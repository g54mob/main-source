using Data.SaveData.PersistentSOs;
using UnityEngine;

namespace Data.TechTree.Validators
{
	[CreateAssetMenu(menuName = "Tech Tree/Validators/Require X DataShard Amount", fileName = "RequireDataShardAmount")]
	public class DataShardsValidator : AbstractTechTreeNodeValidator
	{
		[SerializeField]
		private CurrencyPersistentSO _currencySO;

		public override bool CanBuy(TechTreeNodeSO node)
		{
			return _currencySO.HasEnoughResources(node.Cost);
		}

		public override void Buy(TechTreeNodeSO node)
		{
			_currencySO.TryBuy(node.Cost);
		}
	}
}

using NaughtyAttributes;
using UnityEngine;

public class AbsInfluentBuyableItemSO : AbsBuyableItemSO
{
	[field: Header("Influence / Prestige")]
	[field: SerializeField]
	[field: BoxGroup("Influence")]
	public float Influence { get; protected set; }

	[field: SerializeField]
	[field: BoxGroup("Influence")]
	public EBarStyle Style { get; protected set; }

	[field: SerializeField]
	[field: BoxGroup("Prestige")]
	[field: MinValue(0f)]
	public int PrestigePoint { get; protected set; }

	[field: SerializeField]
	[field: BoxGroup("Prestige")]
	[field: MinValue(0f)]
	public float PrestigeByPrice { get; protected set; }

	public float PrestigeValue => (float)PrestigePoint + (float)base.PurchasePrice * PrestigeByPrice;
}

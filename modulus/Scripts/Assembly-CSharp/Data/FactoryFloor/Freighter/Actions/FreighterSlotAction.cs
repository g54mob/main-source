using Data.FactoryFloor.FactoryObjectBehaviours;
using UnityEngine;

namespace Data.FactoryFloor.Freighter.Actions
{
	[CreateAssetMenu(fileName = "FreighterSlotAction", menuName = "Factory/FactoryBehaviour/Freighter/SlotAction/Empty")]
	public class FreighterSlotAction : ScriptableObject
	{
		[SerializeField]
		private int _databaseIndex;

		[Header("Dropdown Option")]
		[SerializeField]
		[LocaKey]
		private string _localizedName;

		[SerializeField]
		private Sprite _icon;

		[SerializeField]
		private Color _color = Color.white;

		[SerializeField]
		private Color _colorVariant = Color.white;

		public int DatabaseIndex => _databaseIndex;

		public string LocalizedName => LocalizationUtility.GetLocalizedText(_localizedName);

		public Sprite Icon => _icon;

		public Color Color => _color;

		public Color ColorVariant => _colorVariant;

		public virtual void Apply(FreightHubBehaviour freightHub, int slotIndex, ref FreightHubBehaviour.FreightHubSlot freighterSlot)
		{
		}
	}
}

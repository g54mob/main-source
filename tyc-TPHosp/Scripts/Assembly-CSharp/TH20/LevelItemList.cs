using FullInspector;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Level Item List", order = 1115)]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LevelItemList : BaseScriptableObject
	{
		[SerializeField]
		[FormerlySerializedAs("BlacklistedItems")]
		private SharedInstance<RoomItemDefinition>[] m_items;

		public SharedInstance<RoomItemDefinition>[] ItemList => m_items;

		public bool ContainsRoomItem(IRoomItemDefinition item)
		{
			SharedInstance<RoomItemDefinition>[] itemList = ItemList;
			for (int i = 0; i < itemList.Length; i++)
			{
				if (itemList[i].Instance == item)
				{
					return true;
				}
			}
			return false;
		}
	}
}

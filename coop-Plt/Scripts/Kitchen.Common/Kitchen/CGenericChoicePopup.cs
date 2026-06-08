using System;
using KitchenData;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct CGenericChoicePopup : IComponentData
	{
		[Key(0)]
		public GenericChoiceType Type;

		[Key(1)]
		public GenericChoiceDecision Decision;

		[Key(2)]
		public PopupType TextSet;
	}
}

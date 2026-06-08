using Controllers;
using JetBrains.Annotations;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	[TypeHash.ForcedHashSurrogate(13096953241551921456uL)]
	[UsedImplicitly]
	public struct HueyCInputDataSurrogate : IComponentData, TypeHash.IExtendedSurrogate
	{
		[Key(1)]
		public HueyInputState State;

		[Key(2)]
		public bool IsCaptured;

		[Key(3)]
		public bool IsDisconnected;

		public void Convert(EntityManager em, Entity ent)
		{
			CInputData componentData = new CInputData
			{
				State = new InputState
				{
					InteractAction = State.InteractAction,
					GrabAction = State.GrabAction,
					SecondaryAction1 = State.SecondaryAction1,
					SecondaryAction2 = State.SecondaryAction2,
					Movement = State.SerializableMovement.ToVector2(),
					StopMoving = State.StopMoving,
					MenuTrigger = State.MenuTrigger,
					MenuUp = State.MenuUp,
					MenuDown = State.MenuDown,
					MenuLeft = State.MenuLeft,
					MenuRight = State.MenuRight,
					MenuSelect = State.MenuSelect,
					MenuCancel = State.MenuCancel,
					Request = State.Request
				},
				IsDisconnected = IsDisconnected,
				IsCaptured = IsCaptured
			};
			em.RemoveComponent<HueyCInputDataSurrogate>(ent);
			em.AddComponentData(ent, componentData);
		}
	}
}

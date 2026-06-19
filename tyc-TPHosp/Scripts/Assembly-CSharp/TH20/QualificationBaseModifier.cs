using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class QualificationBaseModifier : CharacterModifier
	{
		[SerializeField]
		protected float _modifier;

		[SerializeField]
		protected SharedInstance<RoomDefinition>[] _validRooms;

		public float Calculate(Room room)
		{
			if (room == null || _validRooms == null || _validRooms.Length == 0)
			{
				return _modifier;
			}
			for (int i = 0; i < _validRooms.Length; i++)
			{
				if (_validRooms[i].NotNull() && _validRooms[i].Instance == room.Definition)
				{
					return _modifier;
				}
			}
			return 0f;
		}
	}
}

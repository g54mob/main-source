using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Core.Equipping.Framework
{
	public class FPEquippedItem : MonoBehaviour
	{
		[SerializeField]
		[Header("Events")]
		private UnityEvent OnEquip;

		[SerializeField]
		private UnityEvent OnUnequip;

		protected IEquippedItemHandler _handler { get; private set; }

		public virtual void Equip(IEquippedItemHandler handler, IEquippablePlayerUser playerUser)
		{
		}

		protected virtual void Unequip()
		{
		}
	}
}

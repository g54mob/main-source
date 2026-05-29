using ScheduleOne.Interaction;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.ItemFramework
{
	[RequireComponent(typeof(InteractableObject))]
	public class ItemPickup : MonoBehaviour
	{
		public ItemDefinition ItemToGive;

		public bool DestroyOnPickup;

		public bool ConditionallyActive;

		public Condition ActiveCondition;

		[Header("References")]
		public InteractableObject IntObj;

		public UnityEvent onPickup;

		protected virtual void Awake()
		{
		}

		private void Start()
		{
		}

		private void Init()
		{
		}

		protected virtual void Hovered()
		{
		}

		private void Interacted()
		{
		}

		protected virtual bool CanPickup()
		{
			return false;
		}

		protected virtual void Pickup()
		{
		}

		public void Destroy()
		{
		}
	}
}

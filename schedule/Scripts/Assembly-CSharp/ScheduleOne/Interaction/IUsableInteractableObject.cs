using ScheduleOne.Management;
using UnityEngine;

namespace ScheduleOne.Interaction
{
	public class IUsableInteractableObject : InteractableObject
	{
		[SerializeReference]
		private MonoBehaviour _iUsableMonoBehaviour;

		private string _defaultMessage;

		private IUsable _iUsable;

		private void Awake()
		{
		}

		public override void Hovered()
		{
		}
	}
}

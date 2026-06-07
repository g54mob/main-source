using System.Collections.Generic;
using Events.UI.Overlays;
using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/NarrationDialogQueueSO", fileName = "NarrationDialogQueueSO", order = 0)]
	public class NarrationDialogQueueSO : ScriptableObject
	{
		private readonly Queue<NarrationDto> _narratorQueue = new Queue<NarrationDto>();

		[HideInInspector]
		public bool NarrationIsOpen;

		public Queue<NarrationDto> NarratorQueue => _narratorQueue;
	}
}

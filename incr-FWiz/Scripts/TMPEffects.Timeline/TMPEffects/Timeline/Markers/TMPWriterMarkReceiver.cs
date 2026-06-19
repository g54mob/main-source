using TMPEffects.Components;
using UnityEngine;
using UnityEngine.Playables;

namespace TMPEffects.Timeline.Markers
{
	[RequireComponent(typeof(TMPWriter))]
	public class TMPWriterMarkReceiver : MonoBehaviour, INotificationReceiver
	{
		private TMPWriter writer;

		public void OnNotify(Playable origin, INotification notification, object context)
		{
		}
	}
}

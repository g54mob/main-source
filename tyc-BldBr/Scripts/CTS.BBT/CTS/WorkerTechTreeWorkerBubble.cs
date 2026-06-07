using CTS.BBT.AI;
using CTS.Emotes;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class WorkerTechTreeWorkerBubble : MonoBehaviour
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Feedback Settings")]
		private string _emoteRef;

		[SerializeField]
		[BoxGroup("Feedback Settings")]
		private float _emoteSize;

		[SerializeField]
		[BoxGroup("Feedback Settings")]
		private Color _emoteBackgroundColor;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private Transform _bubbleAnchor;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private Agent _agent;

		public void DisplayBubble(int points)
		{
			EmoteManager.Play<EmoteBBT>(_bubbleAnchor.transform.position, $"<size={_emoteSize}%>{_emoteRef} <size=100%>+{points}").SetBackgroundColor(_emoteBackgroundColor);
		}
	}
}

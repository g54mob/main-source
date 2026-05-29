using UnityEngine;

namespace CTS
{
	public class SituationnalFeedbackPersonna : ScriptableObject
	{
		[field: SerializeField]
		public EActors actors { get; private set; }
	}
}

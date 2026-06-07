using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal sealed class ManagedGameObject : MonoBehaviour
	{
		[field: SerializeField]
		public Component Owner { get; set; }
	}
}

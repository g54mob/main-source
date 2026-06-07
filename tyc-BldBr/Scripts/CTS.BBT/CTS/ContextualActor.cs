using CTS.BBT;
using UnityEngine;

namespace CTS
{
	public class ContextualActor : MonoBehaviour, IContextActor
	{
		[field: SerializeField]
		public ContextActorData ContextActorData { get; private set; }
	}
}

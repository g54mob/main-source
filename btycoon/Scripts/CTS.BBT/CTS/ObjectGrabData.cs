using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class ObjectGrabData : MonoBehaviour
	{
		[field: SerializeReference]
		public GrabData GrabData { get; private set; }

		public void GrabWith(Agent agent)
		{
			agent.ProceduralAnimator.EnableGrab(GrabData);
		}
	}
}

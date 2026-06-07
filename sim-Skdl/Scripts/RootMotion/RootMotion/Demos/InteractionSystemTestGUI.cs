using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	public class InteractionSystemTestGUI : MonoBehaviour
	{
		[Tooltip("The object to interact to")]
		public InteractionObject interactionObject;

		[Tooltip("The effectors to interact with")]
		public FullBodyBipedEffector[] effectors;

		private InteractionSystem interactionSystem;

		private void Awake()
		{
		}

		private void OnGUI()
		{
		}
	}
}

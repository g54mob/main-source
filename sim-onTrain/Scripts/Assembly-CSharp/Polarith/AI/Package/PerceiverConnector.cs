using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Perceiver Connector")]
	public sealed class PerceiverConnector : MonoBehaviour
	{
		public string PerceiverName = "Steering Perceiver";

		private void Start()
		{
			AIMSteeringFilter component = GetComponent<AIMSteeringFilter>();
			if (!(component == null))
			{
				component.SteeringPerceiver = GameObject.Find(PerceiverName).GetComponent<AIMSteeringPerceiver>();
			}
		}
	}
}

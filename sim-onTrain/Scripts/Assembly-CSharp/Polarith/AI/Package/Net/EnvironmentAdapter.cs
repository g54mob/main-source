using Mirror;
using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Package.Net
{
	[AddComponentMenu("Polarith AI » Examples/Network/Environment Adapter")]
	public sealed class EnvironmentAdapter : NetworkBehaviour
	{
		[Tooltip("This tag is used to find the player environment on StartLocalPlayer.")]
		public string EnvironmentName = "PlayerEnvironment";

		public override void OnStartLocalPlayer()
		{
			GameObject gameObject = GameObject.Find(EnvironmentName);
			if (gameObject != null)
			{
				AIMEnvironment component = gameObject.GetComponent<AIMEnvironment>();
				if (component != null)
				{
					component.GameObjects.Add(base.gameObject);
				}
				else
				{
					Debug.LogWarning(base.gameObject.name + " EnvironmentAdapter: Environment does not exist.");
				}
			}
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}

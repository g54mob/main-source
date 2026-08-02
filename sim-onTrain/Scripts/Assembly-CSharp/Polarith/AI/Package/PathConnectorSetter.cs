using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Path Connector Setter")]
	public sealed class PathConnectorSetter : MonoBehaviour
	{
		[Tooltip("Is assigned to all 'AIMFollowWaypoints' instances of this object and its children on Start.")]
		public AIMPathConnector Path;

		private void Start()
		{
			AIMFollowWaypoints[] componentsInChildren = base.gameObject.GetComponentsInChildren<AIMFollowWaypoints>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].PathConnector = Path;
			}
		}
	}
}

using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Tools/UpVector Transform")]
	public class UpVectorTransform : MonoBehaviour
	{
		public GameObjectReference source;

		private IGravity upVector;

		private void Start()
		{
			if (source != null)
			{
				upVector = source.Value.GetComponentInChildren<IGravity>();
			}
		}

		private void Update()
		{
			if (upVector != null)
			{
				base.transform.up = upVector.UpVector;
			}
		}
	}
}

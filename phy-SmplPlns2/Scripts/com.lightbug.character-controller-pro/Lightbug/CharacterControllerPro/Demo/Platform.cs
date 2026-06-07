using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public abstract class Platform : MonoBehaviour
	{
		public RigidbodyComponent RigidbodyComponent { get; protected set; }

		protected virtual void Awake()
		{
			RigidbodyComponent = RigidbodyComponent.CreateInstance(base.gameObject);
			if (RigidbodyComponent == null)
			{
				Debug.Log("(2D/3D)Rigidbody component not found! \nDynamic platforms must have a Rigidbody component associated.");
				base.enabled = false;
			}
		}
	}
}

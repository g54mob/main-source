using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	[AddComponentMenu("Character Controller Pro/Core/Character Body")]
	public class CharacterBody : MonoBehaviour
	{
		[HelpBox("This component will automatically assign a Rigidbody component and a CapsuleCollider component at runtime.", HelpBoxMessageType.Info)]
		[SerializeField]
		[BooleanButton("Physics", "3D", "2D", false)]
		private bool is2D;

		[SerializeField]
		[BreakVector2("Width", "Height")]
		private Vector2 bodySize = new Vector2(1f, 2f);

		[SerializeField]
		private float mass = 50f;

		private CharacterActor characterActor;

		public bool Is2D => is2D;

		public RigidbodyComponent RigidbodyComponent { get; private set; }

		public ColliderComponent ColliderComponent { get; private set; }

		public float Mass => mass;

		public Vector2 BodySize => bodySize;

		private void Awake()
		{
			if (Is2D)
			{
				ColliderComponent = base.gameObject.AddComponent<CapsuleColliderComponent2D>();
				RigidbodyComponent = base.gameObject.AddComponent<RigidbodyComponent2D>();
			}
			else
			{
				ColliderComponent = base.gameObject.AddComponent<CapsuleColliderComponent3D>();
				RigidbodyComponent = base.gameObject.AddComponent<RigidbodyComponent3D>();
			}
		}

		private void OnValidate()
		{
			if (characterActor == null)
			{
				characterActor = GetComponent<CharacterActor>();
			}
			bodySize = new Vector2(Mathf.Max(bodySize.x, 0f), Mathf.Max(bodySize.y, bodySize.x + 0.1f));
			if (characterActor != null)
			{
				characterActor.OnValidate();
			}
		}
	}
}

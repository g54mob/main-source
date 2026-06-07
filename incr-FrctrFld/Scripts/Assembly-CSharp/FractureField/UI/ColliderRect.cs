using UnityEngine;

namespace FractureField.UI
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class ColliderRect : MonoBehaviour
	{
		private BoxCollider2D _collider;

		private RectTransform _rect;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnRectTransformDimensionsChange()
		{
		}

		private void SetColliderSize()
		{
		}
	}
}

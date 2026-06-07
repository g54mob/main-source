using FractureField.Quarry;
using UnityEngine;

namespace FractureField.Controllers
{
	[RequireComponent(typeof(Collider2D))]
	public class QuarryBoundsController : MonoBehaviour
	{
		[Header("Visual Settings")]
		public bool showBounds;

		public Color boundsColor;

		private Collider2D _boundsCollider;

		private QuarryBounds _bounds;

		private void Awake()
		{
		}

		private void Setup()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}

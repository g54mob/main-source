using Brewery.Minigames;
using UnityEngine;

namespace Brewery.Controls3D
{
	[RequireComponent(typeof(Collider))]
	public class DialHint3D : MonoBehaviour
	{
		[Tooltip("The Dial3D to control when this hint is clicked.")]
		[SerializeField]
		private Dial3D targetDial;

		[Tooltip("The dial value to snap to (0-1).")]
		[SerializeField]
		[Range(0f, 1f)]
		private float snapValue;

		[Header("Direction Arrow (optional)")]
		[Tooltip("The DirectionArrow3D to control when this hint is clicked.")]
		[SerializeField]
		private DirectionArrow3D targetArrow;

		[Tooltip("The direction to snap the arrow to.")]
		[SerializeField]
		private SortDirection snapDirection;

		[Header("Element Dial (optional)")]
		[Tooltip("The ElementDial3D to control when this hint is clicked.")]
		[SerializeField]
		private ElementDial3D targetElementDial;

		[Tooltip("The element index to snap to (0-3).")]
		[SerializeField]
		[Range(0f, 3f)]
		private int snapElementIndex;

		private Collider col;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}

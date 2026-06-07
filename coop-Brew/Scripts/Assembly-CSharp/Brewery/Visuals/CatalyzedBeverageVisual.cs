using Brewery.Items;
using UnityEngine;

namespace Brewery.Visuals
{
	public class CatalyzedBeverageVisual : MonoBehaviour
	{
		[SerializeField]
		private Renderer liquidRenderer;

		private Material _materialInstance;

		private bool _applied;

		private static readonly int BaseColorId;

		private static readonly int ColorId;

		private static readonly int EmissionColorId;

		private void Start()
		{
		}

		public void TryApplyFromParent()
		{
		}

		public void ApplyFromSnapshot(BeerDataSnapshot snapshot)
		{
		}

		public void ResetVisual()
		{
		}

		private void OnDestroy()
		{
		}
	}
}

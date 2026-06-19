using UnityEngine;

namespace Water2D
{
	[ExecuteAlways]
	[RequireComponent(typeof(SpriteRenderer))]
	public class WaterSortingLayerSetter : MonoBehaviour
	{
		[SerializeField]
		private string layer;

		[SerializeField]
		private int order;

		private void OnEnable()
		{
		}

		private int GetSortingOrder(string layer)
		{
			return 0;
		}

		private void SRSetup()
		{
		}
	}
}

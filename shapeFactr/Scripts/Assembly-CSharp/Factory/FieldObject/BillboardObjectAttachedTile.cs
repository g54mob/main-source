using UnityEngine;
using UnityEngine.EventSystems;

namespace Factory.FieldObject
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class BillboardObjectAttachedTile : MonoBehaviour, ITemporaryBillboardCamera, IEventSystemHandler
	{
		private SpriteRenderer sprRenderer;

		[SerializeField]
		private bool isParallelToTile;

		private Transform parentCache;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void SetParallelToTile(bool parallelToTile)
		{
		}

		public void OnChangeCamera(Camera cm)
		{
		}
	}
}

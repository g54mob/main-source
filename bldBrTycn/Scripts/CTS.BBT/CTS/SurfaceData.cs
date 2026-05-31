using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "New Floor Data", menuName = "BBT/Floor Data")]
	public class SurfaceData : AbsInfluentBuyableItemSO
	{
		[field: SerializeField]
		[field: BoxGroup("Surface Data")]
		public ESurfaceType SurfaceType { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Surface Data")]
		[field: ShowAssetPreview(64, 64)]
		public Material MaterialData { get; private set; }
	}
}

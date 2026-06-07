using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UMA
{
	[ExecuteInEditMode]
	public class OverlayViewer : MonoBehaviour
	{
		public TextureMerge TextureMergePrefab;

		public SlotDataAsset SlotDataAsset;

		public OverlayDataAsset BaseOverlay;

		public List<OverlayDataAsset> Overlays;

		public RawImage ImageViewer;

		public GameObject AnnoyingPanel;
	}
}

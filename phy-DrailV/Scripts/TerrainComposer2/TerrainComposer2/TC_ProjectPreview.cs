using UnityEngine;

namespace TerrainComposer2
{
	[ExecuteInEditMode]
	public class TC_ProjectPreview : MonoBehaviour
	{
		public static TC_ProjectPreview instance;

		public Material matProjector;

		private void Awake()
		{
			instance = this;
		}

		private void OnEnable()
		{
			instance = this;
		}

		private void OnDestroy()
		{
			instance = null;
		}

		public void SetPreview(TC_ItemBehaviour item)
		{
			matProjector.SetTexture("_MainTex", item.rtDisplay);
		}
	}
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CurvedUI
{
	[ExecuteInEditMode]
	public class CurvedUITMPSubmesh : MonoBehaviour
	{
		private VertexHelper vh;

		private Mesh straightMesh;

		private Mesh curvedMesh;

		private CurvedUIVertexEffect crvdVE;

		private TMP_SubMeshUI TMPsub;

		private TextMeshProUGUI TMPtext;

		public void UpdateSubmesh(bool tesselate, bool curve)
		{
			if (TMPsub == null)
			{
				TMPsub = base.gameObject.GetComponent<TMP_SubMeshUI>();
			}
			if (!(TMPsub == null))
			{
				if (TMPtext == null)
				{
					TMPtext = GetComponentInParent<TextMeshProUGUI>();
				}
				if (crvdVE == null)
				{
					crvdVE = base.gameObject.AddComponentIfMissing<CurvedUIVertexEffect>();
				}
				if (tesselate || straightMesh == null || vh == null || !Application.isPlaying)
				{
					vh = new VertexHelper(TMPsub.mesh);
					straightMesh = new Mesh();
					vh.FillMesh(straightMesh);
					curve = true;
				}
				if (curve)
				{
					vh = new VertexHelper(straightMesh);
					crvdVE.ModifyMesh(vh);
					curvedMesh = new Mesh();
					vh.FillMesh(curvedMesh);
					crvdVE.CurvingRequired = true;
				}
				TMPsub.canvasRenderer.SetMesh(curvedMesh);
				if (TMPtext != null && TMPtext.textInfo.materialCount < 2)
				{
					TMPsub.enabled = false;
					TMPsub.enabled = true;
				}
			}
		}
	}
}

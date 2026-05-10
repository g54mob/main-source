using UnityEngine;

namespace LVA.Puppeteers.Humanoid
{
	public class COMTransformControl : MonoBehaviour
	{
		private const float rkh = 1.1567f;

		private const float rki = 3f;

		private const float rkj = 20f;

		[SerializeField]
		private AnimationCurve m_surfaceNormalLimitationCurve;

		[SerializeField]
		private AnimationCurve m_angleToDistanceToGroundRelationCurve;

		private const float rkk = 30f;

		private float rkl;

		private const float rkm = 20f;

		private const float rkn = 1.5f;

		private int rko;

		private RaycastHit? rkp;

		private Transform rkq;

		private HumanoidPuppeteerRuntimeData rkr;

		private qx rks;

		public void gks(HumanoidPuppeteerRuntimeData a, HumanoidPuppeteer b, qx c)
		{
		}

		public void gkt(Vector3 a)
		{
		}

		public void gku()
		{
		}

		public void gkv()
		{
		}

		public void gkw(Quaternion a)
		{
		}

		private void gkx(Vector3 a)
		{
		}

		private float gky(Vector3 a, Vector3 b)
		{
			return 0f;
		}

		private float gkz(Vector3 a)
		{
			return 0f;
		}
	}
}

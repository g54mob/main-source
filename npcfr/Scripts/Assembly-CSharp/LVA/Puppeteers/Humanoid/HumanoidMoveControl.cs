using System.Runtime.CompilerServices;
using UnityEngine;

namespace LVA.Puppeteers.Humanoid
{
	public class HumanoidMoveControl : MonoBehaviour
	{
		private HumanoidPuppeteerRuntimeData rkt;

		private bav rku;

		private qt rkv;

		private Animator rkw;

		private rg rkx;

		private bool rky;

		private float rkz;

		private bool rla;

		[SerializeField]
		private AnimationCurve m_balanceDampCurve;

		private const float rlb = 2.05f;

		private float rlc;

		private float rld;

		private Vector3 rle;

		private float rlf;

		private const float rlg = 30f;

		private float rlh;

		private float rli;

		private bool rlj;

		[SerializeField]
		private AnimationCurve m_rotMultInfluenceOnBalanceCurve;

		private const float rlk = 0.65f;

		private Vector3 rll;

		private const float rlm = 1f;

		private const float rln = 0.7f;

		[SerializeField]
		private AnimationCurve m_animationSpeedTCurve;

		private float rlo;

		private float rlp;

		private Vector3 rlq;

		private const float rlr = 9f;

		public Vector3 rls
		{
			[CompilerGenerated]
			get
			{
				return default(Vector3);
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public void glc(HumanoidPuppeteerRuntimeData a, HumanoidAnimationReferences b, qx c)
		{
		}

		public void gld()
		{
		}

		public void gle()
		{
		}

		private void glf(HumanoidAnimationReferences a)
		{
		}

		private float glg(Vector3 a)
		{
			return 0f;
		}

		private float glh(float a)
		{
			return 0f;
		}

		private Vector3 gli(Quaternion a, xf b)
		{
			return default(Vector3);
		}

		private Vector3 glj(Vector3 a, float b, Vector3 c)
		{
			return default(Vector3);
		}

		private void glk(float a, float b, Vector3 c)
		{
		}

		private bool gll(float a, float b, float c)
		{
			return false;
		}

		private float glm(float a, float b)
		{
			return 0f;
		}

		private float gln()
		{
			return 0f;
		}

		private void glo(float a, Vector3 b, float c)
		{
		}

		private Vector3 glp(float a)
		{
			return default(Vector3);
		}

		private void glq(float a, float b)
		{
		}

		private void glr()
		{
		}

		private void gls()
		{
		}

		private void glt(float a)
		{
		}
	}
}

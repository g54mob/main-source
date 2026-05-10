using UnityEngine;

namespace VFX.Shaders.Liquid
{
	public class Wobble : MonoBehaviour
	{
		private const string pvo = "_Up";

		private const string pvp = "_WobbleZ";

		private const string pvq = "_WobbleX";

		private const float pvr = 2f;

		private const float pvs = 3.5f;

		private const float pvt = 10f;

		[SerializeField]
		private Renderer m_renderer;

		[SerializeField]
		private float m_maxWobble;

		[SerializeField]
		private bool m_unscaledDeltaTime;

		[SerializeField]
		private float m_velocityInfluence;

		[SerializeField]
		private float m_rotationInfluence;

		private Vector3 pvu;

		private Vector3 pvv;

		private Vector3 pvw;

		private Vector3 pvx;

		private Quaternion pvy;

		private Vector3 pvz;

		private float pwa;

		private float pwb;

		private float pwc;

		private float pwd;

		private float pwe;

		private float pwf;

		private int pwg;

		private int pwh;

		private int pwi;

		private MaterialPropertyBlock pwj;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void dxt(float a)
		{
		}

		private void dxu()
		{
		}
	}
}

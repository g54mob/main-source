using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace RootMotion.FinalIK
{
	public class InteractionSystem : MonoBehaviour
	{
		public delegate void InteractionDelegate(FullBodyBipedEffector effectorType, bms interactionObject);

		public delegate void InteractionEventDelegate(FullBodyBipedEffector effectorType, bms interactionObject, bms.InteractionEvent interactionEvent);

		public string targetTag;

		public float fadeInTime;

		public float speed;

		public float switchInteractionSpeed;

		public float resetToDefaultsSpeed;

		[FormerlySerializedAs("collider")]
		public Collider characterCollider;

		[FormerlySerializedAs("camera")]
		public Transform FPSCamera;

		public LayerMask camRaycastLayers;

		public float camRaycastDistance;

		private List<bmu> uas;

		private List<int> uat;

		public InteractionDelegate OnInteractionStart;

		public InteractionDelegate OnInteractionPause;

		public InteractionDelegate OnInteractionPickUp;

		public InteractionDelegate OnInteractionResume;

		public InteractionDelegate OnInteractionStop;

		public InteractionEventDelegate OnInteractionEvent;

		public RaycastHit raycastHit;

		[Space(10f)]
		[SerializeField]
		private bmi fullBody;

		public InteractionLookAt lookAt;

		private InteractionEffector[] uau;

		private Collider uaw;

		private Collider uax;

		private float uay;

		public bool xsj => false;

		public bmi xsk
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<bmu> uar
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public bool uav
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		private void ksg()
		{
		}

		private void ksh()
		{
		}

		private void ksi()
		{
		}

		private void ksj()
		{
		}

		private void ksk()
		{
		}

		private void ksl()
		{
		}

		private void ksm()
		{
		}

		private void ksn()
		{
		}

		public bool ksp(FullBodyBipedEffector a)
		{
			return false;
		}

		public bool ksq(FullBodyBipedEffector a)
		{
			return false;
		}

		public bool ksr()
		{
			return false;
		}

		public bool kss()
		{
			return false;
		}

		public bool kst(FullBodyBipedEffector a, bms b, bool c)
		{
			return false;
		}

		public bool ksu(FullBodyBipedEffector a, bms b, bool c)
		{
			return false;
		}

		private int ksv(FullBodyBipedEffector a, bms b)
		{
			return 0;
		}

		public bool ksw(FullBodyBipedEffector a, bms b, bmt c, bool d)
		{
			return false;
		}

		public bool ksx(FullBodyBipedEffector a)
		{
			return false;
		}

		public bool ksy(FullBodyBipedEffector a)
		{
			return false;
		}

		public bool ksz(FullBodyBipedEffector a)
		{
			return false;
		}

		public void kta()
		{
		}

		public void ktb()
		{
		}

		public void ktc()
		{
		}

		public bms ktd(FullBodyBipedEffector a)
		{
			return null;
		}

		public float kte(FullBodyBipedEffector a)
		{
			return 0f;
		}

		public float ktf()
		{
			return 0f;
		}

		public bool ktg(int a, bool b)
		{
			return false;
		}

		public bool kth(int a, bool b, out bms c)
		{
			c = null;
			return false;
		}

		public bool kti(int a, bool b, out bmt c)
		{
			c = null;
			return false;
		}

		public bmu.Range ktj()
		{
			return null;
		}

		public bms ktk()
		{
			return null;
		}

		public bmt ktl()
		{
			return null;
		}

		public bms[] ktm()
		{
			return null;
		}

		public bmt[] ktn()
		{
			return null;
		}

		public bool kto(int a)
		{
			return false;
		}

		public bmu.Range ktp(int a)
		{
			return null;
		}

		public int ktq()
		{
			return 0;
		}

		public void ktr()
		{
		}

		public void Start()
		{
		}

		private void kty(FullBodyBipedEffector a, bms b)
		{
		}

		private void ktz(FullBodyBipedEffector a, bms b)
		{
		}

		private void kua(FullBodyBipedEffector a, bms b)
		{
		}

		private void kub(FullBodyBipedEffector a, bms b)
		{
		}

		public void OnTriggerEnter(Collider c)
		{
		}

		public void OnTriggerExit(Collider c)
		{
		}

		private bool kuc(int a, out int b)
		{
			b = default(int);
			return false;
		}

		private void OnDrawGizmosSelected()
		{
		}

		public void Update()
		{
		}

		private void kud()
		{
		}

		private void kue()
		{
		}

		private void OnEnable()
		{
		}

		private void kuf()
		{
		}

		private void kug()
		{
		}

		private void kuh()
		{
		}

		private void kui()
		{
		}

		private void OnDestroy()
		{
		}

		private bool kuj(bool a)
		{
			return false;
		}

		private bool kuk(int a)
		{
			return false;
		}
	}
}

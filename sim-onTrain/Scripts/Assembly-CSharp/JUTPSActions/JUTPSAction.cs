using JUTPS;
using UnityEngine;

namespace JUTPSActions
{
	public class JUTPSAction : MonoBehaviour
	{
		protected JUCharacterController TPSCharacter;

		protected Animator anim;

		protected Rigidbody rb;

		protected Collider coll;

		protected Camera cam;

		public virtual void Awake()
		{
			TPSCharacter = GetComponent<JUCharacterController>();
			rb = GetComponent<Rigidbody>();
			anim = GetComponent<Animator>();
			coll = GetComponent<Collider>();
			GetCamera();
			Invoke("GetCamera", 0.001f);
		}

		private void GetCamera()
		{
			if (TPSCharacter != null)
			{
				cam = ((TPSCharacter.MyPivotCamera != null) ? TPSCharacter.MyPivotCamera.mCamera : null);
			}
		}
	}
}

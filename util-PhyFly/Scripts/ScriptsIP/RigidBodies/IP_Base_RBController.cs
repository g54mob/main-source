using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SPACE_IP
{
	public class IP_Base_RBController : MonoBehaviour
	{
		[SerializeField] protected Rigidbody rb;
		[SerializeField] protected float mass = 100;
		[SerializeField] protected Transform cogTr;

		private void Start()
		{
			this.rb.mass = mass;
		}

		private void FixedUpdate()
		{
			// customized externally >>
			this.HandlePhysics();
			// << customized externally
		}

		#region override externally API
		protected virtual void HandlePhysics()
		{
			//
		}
		#endregion
	}

}
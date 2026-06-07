using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE_UTIL;

namespace SPACE_IP
{
	public class IPBaseHeliInputs : MonoBehaviour
	{
		[Header("base input properties, just to log")]
		[SerializeField] protected float horizontal = 0f;
		[SerializeField] protected float vertical = 0f;

		[SerializeField] public float throttleInput = 0f;
		[SerializeField] public float pedalInput = 0f;
		[SerializeField] public float collectiveInput = 0f;
		[SerializeField] public Vector2 cyclicInput = new Vector2(0, 0);

		// if same Update() method were ever called insde its one of leaf, the main Anscestor Update() -> UnityLifeCycle, wont be executed
		private void Update()
		{
			this.HandleInput(); // customised externally
		}

		#region override(called externally) API
		protected virtual void HandleInput()
		{
			// customized externally
		}
		#endregion
	}
}
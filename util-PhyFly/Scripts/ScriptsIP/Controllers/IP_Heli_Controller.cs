using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SPACE_IP
{
	public class IP_Heli_Controller : IP_Base_RBController
	{
		[SerializeField] List<IP_Heli_Engine> _engines;
		[SerializeField] IPBaseHeliInputs _input;

		protected override void HandlePhysics()
		{
			// base.HandlePhysics();
			this.HandleEngine();
			this.HandlePhysics();
		}

		protected virtual void HandleEngine()
		{
			for (int i0 = 0; i0 < this._engines.Count; i0 += 1)
				_engines[i0].UpdateEngine(this._input.throttleInput);
		}

		protected virtual void HandleCharacteristics()
		{

		}
	}

}
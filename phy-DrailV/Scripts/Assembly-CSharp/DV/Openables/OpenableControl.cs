using DV.CabControls;
using UnityEngine;

namespace DV.Openables
{
	public class OpenableControl : MonoBehaviour
	{
		public bool closedAtZero = true;

		private ControlImplBase control;

		public bool IsOpen
		{
			get
			{
				if (closedAtZero)
				{
					if (control.Value >= 0.1f)
					{
						return true;
					}
				}
				else if (control.Value <= 0.9f)
				{
					return true;
				}
				return false;
			}
		}

		public void Init()
		{
			control = base.gameObject.GetComponent<ControlImplBase>();
			if (control == null)
			{
				Debug.LogError("Unexpected state: Couldn't extract ControlImplBase on OpenableControl! Destroying self");
				Object.Destroy(this);
			}
		}
	}
}

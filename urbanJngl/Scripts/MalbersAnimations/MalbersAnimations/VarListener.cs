using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	public abstract class VarListener : MonoBehaviour
	{
		[HideInInspector]
		public bool ShowEvents;

		[Tooltip("ID value is used on the AI Brain to know which Var Listener is picked, in case there more than one on one Game Object")]
		public IntReference ID;

		[Tooltip("The Events will be invoked when the Listener Value changes.\nIf is set to false, call Invoke() to invoke the events manually")]
		public bool Auto = true;

		[Tooltip("Invokes the current value on Enable")]
		public bool InvokeOnEnable = true;

		public string Description = "";

		[HideInInspector]
		public bool ShowDescription;

		public bool debug;

		public bool Enable
		{
			get
			{
				if (base.gameObject.activeInHierarchy)
				{
					return base.enabled;
				}
				return false;
			}
		}

		[ContextMenu("Show Description")]
		internal void EditDescription()
		{
			ShowDescription = !ShowDescription;
		}
	}
}

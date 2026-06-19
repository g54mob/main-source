using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public abstract class SMB_ParameterSync : StateMachineBehaviour
	{
		[FullInspector.InspectorName("Sync Param Name")]
		public string _outParamName;

		public virtual void OnParameterSynced(Animator slave, Animator master)
		{
		}
	}
}

using NSMedieval.Goap;
using UnityEngine;

namespace NSMedieval.View
{
	public interface IAgentView
	{
		Quaternion TargetRotation { get; set; }

		Agent GetAgent();

		IGoapAgentOwner GetAgentOwner();
	}
}

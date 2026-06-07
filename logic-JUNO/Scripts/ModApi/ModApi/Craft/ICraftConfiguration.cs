using ModApi.Craft.Parts;
using UnityEngine;

namespace ModApi.Craft
{
	public interface ICraftConfiguration
	{
		Vector3 DefaultPilotOrientation { get; }

		string Name { get; }

		Vector3 PartPulloutRotation { get; }

		CrafConfigurationType Type { get; }

		void OnDesignerPartPullout(IPartScript partScript, Assembly assembly);
	}
}

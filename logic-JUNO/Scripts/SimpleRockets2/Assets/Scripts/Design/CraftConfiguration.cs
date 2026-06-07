using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class CraftConfiguration : ICraftConfiguration
	{
		public Vector3 DefaultPilotOrientation { get; private set; }

		public string Name { get; private set; }

		public Vector3 PartPulloutRotation { get; private set; }

		public CrafConfigurationType Type { get; private set; }

		public CraftConfiguration(CrafConfigurationType type, string name, Vector3 defaultPilotOrientation, Vector3 partPulloutRotation)
		{
			Type = type;
			Name = name;
			DefaultPilotOrientation = defaultPilotOrientation;
			PartPulloutRotation = partPulloutRotation;
		}

		public void OnDesignerPartPullout(IPartScript partScript, Assembly assembly)
		{
			if (assembly.Parts.Count == 1 && partScript.Data.PartType.AllowDesignerReorientationOnPullout)
			{
				partScript.Transform.Rotate(PartPulloutRotation, Space.World);
			}
		}
	}
}

using Assets.Scripts.Craft.Parts.Modifiers.XR;
using Jundroo.Common.Utils;
using RootMotion.FinalIK;

namespace Assets.Scripts.Craft.Parts.Modifiers.Character
{
	public class IKTargetScript : PartModifierScript
	{
		private IKTargetData _data;

		public IKTargetData Data => _data;

		public string Path => _data.Path;

		public float PositionWeight => _data.PositionWeight;

		public float RotationWeight => _data.RotationWeight;

		public IKTargetType Type => _data.Type;

		public void Initialize(IKTargetData data)
		{
			_data = data;
		}

		public void OnTargeted(FullBodyBipedIK bipedIk)
		{
			if (TryGetComponent<InterpolatedPoseScript>(out var component))
			{
				component.OriginTransform = ((!(bipedIk != null)) ? null : Utilities.FindFirstGameObjectMyselfOrChildren(component.OriginBoneName, bipedIk.gameObject)?.transform);
			}
			PosedGripScript[] componentsInChildren = base.PartScript.GetComponentsInChildren<PosedGripScript>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].OnTargeted(bipedIk);
			}
		}
	}
}

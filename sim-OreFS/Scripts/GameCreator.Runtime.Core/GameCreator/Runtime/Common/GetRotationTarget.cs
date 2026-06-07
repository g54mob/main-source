using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Target Rotation")]
	[Category("Game Objects/Target Rotation")]
	[Image(typeof(IconTarget), ColorTheme.Type.Yellow)]
	[Description("Rotation of the targeted game object in local or world space")]
	[HideLabelsInEditor(true)]
	public class GetRotationTarget : PropertyTypeGetRotation
	{
		[SerializeField]
		private RotationSpace m_Space = RotationSpace.Global;

		public static PropertyGetRotation Create => new PropertyGetRotation(new GetRotationTarget());

		public override string String => $"{m_Space} Target";

		public override Quaternion Get(Args args)
		{
			if (!(args.Target != null))
			{
				return default(Quaternion);
			}
			if (m_Space != RotationSpace.Global)
			{
				return args.Target.transform.localRotation;
			}
			return args.Target.transform.rotation;
		}
	}
}

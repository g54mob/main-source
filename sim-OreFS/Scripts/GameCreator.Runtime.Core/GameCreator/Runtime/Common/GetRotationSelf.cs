using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Self Rotation")]
	[Category("Game Objects/Self Rotation")]
	[Image(typeof(IconSelf), ColorTheme.Type.Yellow)]
	[Description("Rotation of the game object making the call in local or world space")]
	[HideLabelsInEditor(true)]
	public class GetRotationSelf : PropertyTypeGetRotation
	{
		[SerializeField]
		private RotationSpace m_Space = RotationSpace.Global;

		public static PropertyGetRotation Create => new PropertyGetRotation(new GetRotationSelf());

		public override string String => $"{m_Space} Self";

		public override Quaternion Get(Args args)
		{
			if (!(args.Self != null))
			{
				return default(Quaternion);
			}
			if (m_Space != RotationSpace.Global)
			{
				return args.Self.transform.localRotation;
			}
			return args.Self.transform.rotation;
		}
	}
}

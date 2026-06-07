using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Self Scale")]
	[Category("Game Objects/Self Scale")]
	[Image(typeof(IconSelf), ColorTheme.Type.Yellow)]
	[Description("Scale of the caller in local or world space")]
	[HideLabelsInEditor(true)]
	public class GetScaleSelf : PropertyTypeGetScale
	{
		[SerializeField]
		private ScaleSpace m_Space;

		public static PropertyGetScale Create => new PropertyGetScale(new GetScaleSelf());

		public override string String => $"{m_Space} Self";

		public override Vector3 Get(Args args)
		{
			return GetScale(args.Self);
		}

		public override Vector3 Get(GameObject gameObject)
		{
			return GetScale(gameObject);
		}

		private Vector3 GetScale(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Vector3.one;
			}
			return m_Space switch
			{
				ScaleSpace.Local => gameObject.transform.localScale, 
				ScaleSpace.Global => gameObject.transform.lossyScale, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}

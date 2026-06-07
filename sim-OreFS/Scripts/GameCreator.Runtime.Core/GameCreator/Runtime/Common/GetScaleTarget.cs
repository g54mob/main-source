using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Target Scale")]
	[Category("Game Objects/Target Scale")]
	[Image(typeof(IconTarget), ColorTheme.Type.Yellow)]
	[Description("Scale of the targeted game object in local or world space")]
	[HideLabelsInEditor(true)]
	public class GetScaleTarget : PropertyTypeGetScale
	{
		[SerializeField]
		private ScaleSpace m_Space;

		public static PropertyGetScale Create => new PropertyGetScale(new GetScaleTarget());

		public override string String => $"{m_Space} Target";

		public override Vector3 Get(Args args)
		{
			return GetScale(args.Target);
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

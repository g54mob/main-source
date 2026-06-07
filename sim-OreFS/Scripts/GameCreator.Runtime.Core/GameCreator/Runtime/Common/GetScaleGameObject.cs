using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Game Object Scale")]
	[Category("Game Objects/Game Object Scale")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]
	[Description("Scale of the targeted game object in local or world space")]
	public class GetScaleGameObject : PropertyTypeGetScale
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = GetGameObjectInstance.Create();

		[SerializeField]
		private ScaleSpace m_Space;

		public static PropertyGetScale Create => new PropertyGetScale(new GetScaleGameObject());

		public override string String => $"{m_Space} {m_GameObject}";

		public override Vector3 Get(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
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

using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Game Object Rotation")]
	[Category("Game Objects/Game Object Rotation")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]
	[Description("Rotation of the Game Object in local or world space")]
	public class GetRotationGameObject : PropertyTypeGetRotation
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = new PropertyGetGameObject();

		[SerializeField]
		private RotationSpace m_Space = RotationSpace.Global;

		public static PropertyGetRotation Create => new PropertyGetRotation(new GetRotationGameObject());

		public override string String => $"{m_Space} {m_GameObject}";

		public override Quaternion Get(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return default(Quaternion);
			}
			return m_Space switch
			{
				RotationSpace.Local => gameObject.transform.localRotation, 
				RotationSpace.Global => gameObject.transform.rotation, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}

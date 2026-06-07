using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("Shot")]
	[Category("Cameras/Shot")]
	[Description("Reference to the game object with a Shot component")]
	[Image(typeof(IconCameraShot), ColorTheme.Type.Yellow)]
	public class GetGameObjectShot : PropertyTypeGetGameObject
	{
		[SerializeField]
		private ShotCamera m_Shot;

		public static PropertyGetGameObject Create => new PropertyGetGameObject(new GetGameObjectShot());

		public override string String
		{
			get
			{
				if (!(m_Shot != null))
				{
					return "(none)";
				}
				return m_Shot.gameObject.name;
			}
		}

		public override GameObject EditorValue
		{
			get
			{
				if (!(m_Shot != null))
				{
					return null;
				}
				return m_Shot.gameObject;
			}
		}

		public override GameObject Get(Args args)
		{
			if (!(m_Shot != null))
			{
				return null;
			}
			return m_Shot.gameObject;
		}

		public override GameObject Get(GameObject gameObject)
		{
			if (!(m_Shot != null))
			{
				return null;
			}
			return m_Shot.gameObject;
		}

		public override T Get<T>(Args args)
		{
			if (typeof(T) == typeof(ShotCamera))
			{
				return m_Shot as T;
			}
			return base.Get<T>(args);
		}
	}
}

using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("Camera")]
	[Category("Cameras/Camera")]
	[Description("Reference to the game object with a Camera component")]
	[Image(typeof(IconCamera), ColorTheme.Type.Green)]
	public class GetGameObjectCamera : PropertyTypeGetGameObject
	{
		[SerializeField]
		private Camera m_Camera;

		public static PropertyGetGameObject Create => new PropertyGetGameObject(new GetGameObjectCamera());

		public override string String
		{
			get
			{
				if (!(m_Camera != null))
				{
					return "(none)";
				}
				return m_Camera.gameObject.name;
			}
		}

		public override GameObject EditorValue
		{
			get
			{
				if (!(m_Camera != null))
				{
					return null;
				}
				return m_Camera.gameObject;
			}
		}

		public override GameObject Get(Args args)
		{
			if (!(m_Camera != null))
			{
				return null;
			}
			return m_Camera.gameObject;
		}

		public override GameObject Get(GameObject gameObject)
		{
			if (!(m_Camera != null))
			{
				return null;
			}
			return m_Camera.gameObject;
		}

		public override T Get<T>(Args args)
		{
			if (typeof(T) == typeof(Camera))
			{
				return m_Camera as T;
			}
			return base.Get<T>(args);
		}
	}
}

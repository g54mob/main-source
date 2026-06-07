using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Marker")]
	[Category("Navigation/Marker")]
	[Image(typeof(IconMarker), ColorTheme.Type.Yellow)]
	[Description("Reference to a scene Marker game object")]
	[HideLabelsInEditor(true)]
	public class GetGameObjectNavigationMarker : PropertyTypeGetGameObject
	{
		[SerializeField]
		private Marker m_Marker;

		public override string String
		{
			get
			{
				if (!(m_Marker != null))
				{
					return "(none)";
				}
				return m_Marker.gameObject.name;
			}
		}

		public override GameObject EditorValue
		{
			get
			{
				if (!(m_Marker != null))
				{
					return null;
				}
				return m_Marker.gameObject;
			}
		}

		public override GameObject Get(Args args)
		{
			if (!(m_Marker != null))
			{
				return null;
			}
			return m_Marker.gameObject;
		}

		public override GameObject Get(GameObject gameObject)
		{
			if (!(m_Marker != null))
			{
				return null;
			}
			return m_Marker.gameObject;
		}

		public override T Get<T>(Args args)
		{
			if (typeof(T) == typeof(Marker))
			{
				return m_Marker as T;
			}
			return base.Get<T>(args);
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectNavigationMarker());
		}
	}
}

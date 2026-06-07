using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Hotspot")]
	[Category("Visual Scripting/Hotspot")]
	[Image(typeof(IconHotspot), ColorTheme.Type.Yellow)]
	[Description("A Hotspot component reference")]
	[HideLabelsInEditor(true)]
	public class GetGameObjectHotspot : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected Hotspot m_Hotspot;

		public override string String
		{
			get
			{
				if (!(m_Hotspot != null))
				{
					return "(none)";
				}
				return m_Hotspot.gameObject.name;
			}
		}

		public override GameObject EditorValue
		{
			get
			{
				if (!(m_Hotspot != null))
				{
					return null;
				}
				return m_Hotspot.gameObject;
			}
		}

		public override GameObject Get(Args args)
		{
			if (!(m_Hotspot != null))
			{
				return null;
			}
			return m_Hotspot.gameObject;
		}

		public override GameObject Get(GameObject gameObject)
		{
			if (!(m_Hotspot != null))
			{
				return null;
			}
			return m_Hotspot.gameObject;
		}

		public override T Get<T>(Args args)
		{
			if (typeof(T) == typeof(Hotspot))
			{
				return m_Hotspot as T;
			}
			return base.Get<T>(args);
		}

		public GetGameObjectHotspot()
		{
		}

		public GetGameObjectHotspot(GameObject gameObject)
			: this()
		{
			m_Hotspot = gameObject.Get<Hotspot>();
		}

		public GetGameObjectHotspot(Hotspot hotspot)
			: this()
		{
			m_Hotspot = hotspot;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectHotspot());
		}
	}
}

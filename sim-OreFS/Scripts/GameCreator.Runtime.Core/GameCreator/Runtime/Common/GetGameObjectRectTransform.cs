using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Rect Transform")]
	[Category("Transforms/Rect Transform")]
	[Image(typeof(IconRectTransform), ColorTheme.Type.Green)]
	[Description("A Rect Transform scene reference or prefab")]
	[HideLabelsInEditor(true)]
	public class GetGameObjectRectTransform : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected RectTransform m_RectTransform;

		public override string String
		{
			get
			{
				if (!(m_RectTransform != null))
				{
					return "(none)";
				}
				return m_RectTransform.name;
			}
		}

		public override GameObject EditorValue
		{
			get
			{
				if (!(m_RectTransform != null))
				{
					return null;
				}
				return m_RectTransform.gameObject;
			}
		}

		public override GameObject Get(Args args)
		{
			if (!(m_RectTransform != null))
			{
				return null;
			}
			return m_RectTransform.gameObject;
		}

		public override GameObject Get(GameObject gameObject)
		{
			if (!(m_RectTransform != null))
			{
				return null;
			}
			return m_RectTransform.gameObject;
		}

		public GetGameObjectRectTransform()
		{
		}

		public GetGameObjectRectTransform(RectTransform rectTransform)
			: this()
		{
			m_RectTransform = rectTransform;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectRectTransform());
		}

		public static PropertyGetGameObject Create(RectTransform rectTransform)
		{
			return new PropertyGetGameObject(new GetGameObjectRectTransform
			{
				m_RectTransform = rectTransform
			});
		}
	}
}

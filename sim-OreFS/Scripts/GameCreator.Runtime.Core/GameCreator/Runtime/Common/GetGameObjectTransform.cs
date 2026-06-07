using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Transform")]
	[Category("Transforms/Transform")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green)]
	[Description("A Transform scene reference or prefab")]
	[HideLabelsInEditor(true)]
	public class GetGameObjectTransform : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected Transform m_Transform;

		public override string String
		{
			get
			{
				if (!(m_Transform != null))
				{
					return "(none)";
				}
				return m_Transform.name;
			}
		}

		public override GameObject EditorValue
		{
			get
			{
				if (!(m_Transform != null))
				{
					return null;
				}
				return m_Transform.gameObject;
			}
		}

		public override GameObject Get(Args args)
		{
			if (!(m_Transform != null))
			{
				return null;
			}
			return m_Transform.gameObject;
		}

		public override GameObject Get(GameObject gameObject)
		{
			if (!(m_Transform != null))
			{
				return null;
			}
			return m_Transform.gameObject;
		}

		public override T Get<T>(Args args)
		{
			if (typeof(T) == typeof(Transform))
			{
				return m_Transform as T;
			}
			return base.Get<T>(args);
		}

		public GetGameObjectTransform()
		{
		}

		public GetGameObjectTransform(Transform transform)
			: this()
		{
			m_Transform = transform;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectTransform());
		}

		public static PropertyGetGameObject Create(Transform transform)
		{
			return new PropertyGetGameObject(new GetGameObjectTransform
			{
				m_Transform = transform
			});
		}
	}
}

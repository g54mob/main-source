using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Game Object")]
	[Category("Game Objects/Game Object")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]
	[Description("A Game Object scene reference or prefab")]
	[HideLabelsInEditor(true)]
	public class GetGameObjectInstance : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected GameObject m_GameObject;

		public override string String
		{
			get
			{
				if (!(m_GameObject != null))
				{
					return "(none)";
				}
				return m_GameObject.name;
			}
		}

		public override GameObject EditorValue => m_GameObject;

		public override GameObject Get(Args args)
		{
			return m_GameObject;
		}

		public override GameObject Get(GameObject gameObject)
		{
			return m_GameObject;
		}

		public GetGameObjectInstance()
		{
		}

		public GetGameObjectInstance(GameObject gameObject)
			: this()
		{
			m_GameObject = gameObject;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectInstance());
		}

		public static PropertyGetGameObject Create(GameObject gameObject)
		{
			return new PropertyGetGameObject(new GetGameObjectInstance
			{
				m_GameObject = gameObject
			});
		}

		public static PropertyGetGameObject Create(Transform transform)
		{
			return Create((transform != null) ? transform.gameObject : null);
		}
	}
}

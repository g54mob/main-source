using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Actions")]
	[Category("Visual Scripting/Actions")]
	[Image(typeof(IconInstructions), ColorTheme.Type.Blue)]
	[Description("An Actions component reference")]
	[HideLabelsInEditor(true)]
	public class GetGameObjectActions : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected Actions m_Actions;

		public override string String
		{
			get
			{
				if (!(m_Actions != null))
				{
					return "(none)";
				}
				return m_Actions.gameObject.name;
			}
		}

		public override GameObject EditorValue
		{
			get
			{
				if (!(m_Actions != null))
				{
					return null;
				}
				return m_Actions.gameObject;
			}
		}

		public override GameObject Get(Args args)
		{
			if (!(m_Actions != null))
			{
				return null;
			}
			return m_Actions.gameObject;
		}

		public override GameObject Get(GameObject gameObject)
		{
			if (!(m_Actions != null))
			{
				return null;
			}
			return m_Actions.gameObject;
		}

		public override T Get<T>(Args args)
		{
			if (typeof(T) == typeof(Actions))
			{
				return m_Actions as T;
			}
			return base.Get<T>(args);
		}

		public GetGameObjectActions()
		{
		}

		public GetGameObjectActions(GameObject gameObject)
			: this()
		{
			m_Actions = gameObject.Get<Actions>();
		}

		public GetGameObjectActions(Actions actions)
			: this()
		{
			m_Actions = actions;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectActions());
		}

		public static PropertyGetGameObject Create(GameObject gameObject)
		{
			return new PropertyGetGameObject(new GetGameObjectActions
			{
				m_Actions = ((gameObject != null) ? gameObject.Get<Actions>() : null)
			});
		}

		public static PropertyGetGameObject Create(Actions actions)
		{
			return new PropertyGetGameObject(new GetGameObjectActions
			{
				m_Actions = actions
			});
		}
	}
}

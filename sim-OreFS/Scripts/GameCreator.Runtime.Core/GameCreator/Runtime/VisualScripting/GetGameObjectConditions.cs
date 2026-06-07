using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Conditions")]
	[Category("Visual Scripting/Conditions")]
	[Image(typeof(IconConditions), ColorTheme.Type.Green)]
	[Description("A Conditions component reference")]
	[HideLabelsInEditor(true)]
	public class GetGameObjectConditions : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected Conditions m_Conditions;

		public override string String
		{
			get
			{
				if (!(m_Conditions != null))
				{
					return "(none)";
				}
				return m_Conditions.gameObject.name;
			}
		}

		public override GameObject EditorValue
		{
			get
			{
				if (!(m_Conditions != null))
				{
					return null;
				}
				return m_Conditions.gameObject;
			}
		}

		public override GameObject Get(Args args)
		{
			if (!(m_Conditions != null))
			{
				return null;
			}
			return m_Conditions.gameObject;
		}

		public override GameObject Get(GameObject gameObject)
		{
			if (!(m_Conditions != null))
			{
				return null;
			}
			return m_Conditions.gameObject;
		}

		public override T Get<T>(Args args)
		{
			if (typeof(T) == typeof(Conditions))
			{
				return m_Conditions as T;
			}
			return base.Get<T>(args);
		}

		public GetGameObjectConditions()
		{
		}

		public GetGameObjectConditions(GameObject gameObject)
			: this()
		{
			m_Conditions = gameObject.Get<Conditions>();
		}

		public GetGameObjectConditions(Conditions Conditions)
			: this()
		{
			m_Conditions = Conditions;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectConditions());
		}

		public static PropertyGetGameObject Create(GameObject gameObject)
		{
			return new PropertyGetGameObject(new GetGameObjectConditions
			{
				m_Conditions = ((gameObject != null) ? gameObject.Get<Conditions>() : null)
			});
		}

		public static PropertyGetGameObject Create(Conditions Conditions)
		{
			return new PropertyGetGameObject(new GetGameObjectConditions
			{
				m_Conditions = Conditions
			});
		}
	}
}

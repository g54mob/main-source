using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Trigger")]
	[Category("Visual Scripting/Trigger")]
	[Image(typeof(IconTriggers), ColorTheme.Type.Yellow)]
	[Description("A Trigger component reference")]
	[HideLabelsInEditor(true)]
	public class GetGameObjectTrigger : PropertyTypeGetGameObject
	{
		[SerializeField]
		protected Trigger m_Trigger;

		public override string String
		{
			get
			{
				if (!(m_Trigger != null))
				{
					return "(none)";
				}
				return m_Trigger.gameObject.name;
			}
		}

		public override GameObject EditorValue
		{
			get
			{
				if (!(m_Trigger != null))
				{
					return null;
				}
				return m_Trigger.gameObject;
			}
		}

		public override GameObject Get(Args args)
		{
			if (!(m_Trigger != null))
			{
				return null;
			}
			return m_Trigger.gameObject;
		}

		public override GameObject Get(GameObject gameObject)
		{
			if (!(m_Trigger != null))
			{
				return null;
			}
			return m_Trigger.gameObject;
		}

		public override T Get<T>(Args args)
		{
			if (typeof(T) == typeof(Trigger))
			{
				return m_Trigger as T;
			}
			return base.Get<T>(args);
		}

		public GetGameObjectTrigger()
		{
		}

		public GetGameObjectTrigger(GameObject gameObject)
			: this()
		{
			m_Trigger = gameObject.Get<Trigger>();
		}

		public GetGameObjectTrigger(Trigger trigger)
			: this()
		{
			m_Trigger = trigger;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectTrigger());
		}

		public static PropertyGetGameObject Create(GameObject gameObject)
		{
			return new PropertyGetGameObject(new GetGameObjectTrigger
			{
				m_Trigger = ((gameObject != null) ? gameObject.Get<Trigger>() : null)
			});
		}

		public static PropertyGetGameObject Create(Trigger trigger)
		{
			return new PropertyGetGameObject(new GetGameObjectTrigger
			{
				m_Trigger = trigger
			});
		}
	}
}

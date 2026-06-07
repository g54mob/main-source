using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Component in Children")]
	[Category("Transforms/Component in Children")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow, typeof(OverlayArrowDown))]
	[Description("Finds a child game object with a component starting from a chosen object")]
	public class GetGameObjectFindComponentInChildren : PropertyTypeGetGameObject
	{
		[SerializeField]
		private PropertyGetGameObject m_From = GetGameObjectNone.Create();

		[SerializeField]
		private TypeReferenceComponent m_Component = new TypeReferenceComponent();

		public override string String => $"{m_From}/{m_Component}";

		public override GameObject Get(Args args)
		{
			GameObject gameObject = m_From.Get(args);
			Type type = m_Component.Type;
			if (type == null)
			{
				return null;
			}
			if (gameObject == null)
			{
				if (!(UnityEngine.Object.FindAnyObjectByType(type) is Component component))
				{
					return null;
				}
				return component.gameObject;
			}
			Component componentInChildren = gameObject.GetComponentInChildren(type);
			if (!(componentInChildren != null))
			{
				return null;
			}
			return componentInChildren.gameObject;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectFindComponentInChildren());
		}
	}
}

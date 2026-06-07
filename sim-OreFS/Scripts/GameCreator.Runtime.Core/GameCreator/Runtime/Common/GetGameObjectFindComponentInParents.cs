using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Component in Parents")]
	[Category("Transforms/Component in Parents")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow, typeof(OverlayArrowUp))]
	[Description("Finds a parent game object with a component starting from a chosen object")]
	public class GetGameObjectFindComponentInParents : PropertyTypeGetGameObject
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
			Component componentInParent = gameObject.GetComponentInParent(type);
			if (!(componentInParent != null))
			{
				return null;
			}
			return componentInParent.gameObject;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectFindComponentInParents());
		}
	}
}

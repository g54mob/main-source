using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Parent")]
	[Category("Transforms/Parent")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green, typeof(OverlayArrowUp))]
	[Description("The parent game object of the specified game object")]
	public class GetGameObjectParent : PropertyTypeGetGameObject
	{
		[SerializeField]
		private PropertyGetGameObject m_Transform = GetGameObjectInstance.Create();

		public override string String => $"Parent of {m_Transform}";

		public override GameObject EditorValue
		{
			get
			{
				GameObject editorValue = m_Transform.EditorValue;
				if (editorValue == null)
				{
					return null;
				}
				Transform parent = editorValue.transform.parent;
				if (!(parent != null))
				{
					return null;
				}
				return parent.gameObject;
			}
		}

		public override GameObject Get(Args args)
		{
			GameObject gameObject = m_Transform.Get(args);
			if (gameObject == null)
			{
				return null;
			}
			Transform parent = gameObject.transform.parent;
			if (!(parent != null))
			{
				return null;
			}
			return parent.gameObject;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectParent());
		}
	}
}

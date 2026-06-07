using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Root")]
	[Category("Transforms/Root")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green, typeof(OverlayArrowUp))]
	[Description("The root game object in the hierarchy of the specified object")]
	public class GetGameObjectRoot : PropertyTypeGetGameObject
	{
		[SerializeField]
		private PropertyGetGameObject m_Transform = GetGameObjectInstance.Create();

		public override string String => $"Root of {m_Transform}";

		public override GameObject EditorValue
		{
			get
			{
				GameObject editorValue = m_Transform.EditorValue;
				if (!(editorValue != null))
				{
					return null;
				}
				return GetRoot(editorValue);
			}
		}

		public override GameObject Get(Args args)
		{
			GameObject gameObject = m_Transform.Get(args);
			if (!(gameObject != null))
			{
				return null;
			}
			return GetRoot(gameObject);
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectRoot());
		}

		private static GameObject GetRoot(GameObject gameObject)
		{
			while (gameObject.transform.parent != null)
			{
				gameObject = gameObject.transform.parent.gameObject;
			}
			return gameObject;
		}
	}
}

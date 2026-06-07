using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Game Object Child Path")]
	[Category("Transforms/Game Object Child Path")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green, typeof(OverlayArrowDown))]
	[Description("The child of a game object found in its hierarchy identified by its name")]
	public class GetGameObjectChildByPath : PropertyTypeGetGameObject
	{
		[SerializeField]
		private PropertyGetGameObject m_Transform = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetString m_Path = GetStringString.Create;

		public override string String => $"{m_Transform}/{m_Path}";

		public override GameObject EditorValue
		{
			get
			{
				GameObject editorValue = m_Transform.EditorValue;
				if (editorValue == null)
				{
					return null;
				}
				Transform transform = editorValue.transform.Find(m_Path.ToString());
				if (!(transform != null))
				{
					return null;
				}
				return transform.gameObject;
			}
		}

		public override GameObject Get(Args args)
		{
			GameObject gameObject = m_Transform.Get(args);
			if (gameObject == null)
			{
				return null;
			}
			Transform transform = gameObject.transform.Find(m_Path.Get(args));
			if (!(transform != null))
			{
				return null;
			}
			return transform.gameObject;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectChildByPath());
		}
	}
}

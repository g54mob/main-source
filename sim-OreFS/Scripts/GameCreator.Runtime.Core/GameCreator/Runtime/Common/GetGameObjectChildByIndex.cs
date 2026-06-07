using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Game Object Child Index")]
	[Category("Transforms/Game Object Child Index")]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green, typeof(OverlayDot))]
	[Description("The N-th child of a game object")]
	public class GetGameObjectChildByIndex : PropertyTypeGetGameObject
	{
		[SerializeField]
		private PropertyGetGameObject m_Transform = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetInteger m_Index = GetDecimalInteger.Create(0);

		public override string String => $"{m_Transform}/{m_Index}";

		public override GameObject EditorValue
		{
			get
			{
				GameObject editorValue = m_Transform.EditorValue;
				if (editorValue == null)
				{
					return null;
				}
				if (!int.TryParse(m_Index.ToString(), out var result))
				{
					return null;
				}
				result = Math.Clamp(result, 0, editorValue.transform.childCount - 1);
				if (result >= editorValue.transform.childCount)
				{
					return null;
				}
				return editorValue.transform.GetChild(result).gameObject;
			}
		}

		public override GameObject Get(Args args)
		{
			GameObject gameObject = m_Transform.Get(args);
			if (gameObject == null)
			{
				return null;
			}
			int index = (int)Math.Clamp(m_Index.Get(args), 0.0, gameObject.transform.childCount - 1);
			Transform child = gameObject.transform.GetChild(index);
			if (!(child != null))
			{
				return null;
			}
			return child.gameObject;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectChildByIndex());
		}
	}
}

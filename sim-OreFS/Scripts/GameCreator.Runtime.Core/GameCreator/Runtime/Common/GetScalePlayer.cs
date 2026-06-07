using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Player Scale")]
	[Category("Characters/Player Scale")]
	[Image(typeof(IconPlayer), ColorTheme.Type.Green)]
	[Description("Scale of the Player character in local or world space")]
	[HideLabelsInEditor(true)]
	public class GetScalePlayer : PropertyTypeGetScale
	{
		[SerializeField]
		private ScaleSpace m_Space;

		public static PropertyGetScale Create => new PropertyGetScale(new GetScalePlayer());

		public override string String => $"{m_Space} Player";

		public override Vector3 Get(Args args)
		{
			return GetScale();
		}

		public override Vector3 Get(GameObject gameObject)
		{
			return GetScale();
		}

		private Vector3 GetScale()
		{
			if (ShortcutPlayer.Instance == null)
			{
				return Vector3.one;
			}
			return m_Space switch
			{
				ScaleSpace.Local => ShortcutPlayer.Transform.localScale, 
				ScaleSpace.Global => ShortcutPlayer.Transform.lossyScale, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}

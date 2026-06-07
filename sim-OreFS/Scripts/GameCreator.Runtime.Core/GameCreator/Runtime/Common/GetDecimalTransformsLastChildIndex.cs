using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Last Child Index")]
	[Category("Transforms/Last Child Index")]
	[Image(typeof(IconHanger), ColorTheme.Type.Yellow, typeof(OverlayArrowDown))]
	[Description("Returns the last child's index of the referenced game object")]
	[Keywords(new string[] { "Float", "Decimal", "Double" })]
	public class GetDecimalTransformsLastChildIndex : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetGameObject m_Transform = GetGameObjectPlayer.Create();

		public override string String => $"{m_Transform} Last Child Index";

		public override double Get(Args args)
		{
			GameObject gameObject = m_Transform.Get(args);
			return (gameObject != null) ? Math.Max(0, gameObject.transform.childCount - 1) : 0;
		}

		public GetDecimalTransformsLastChildIndex()
		{
		}

		public GetDecimalTransformsLastChildIndex(Transform transform)
			: this()
		{
			m_Transform = GetGameObjectInstance.Create((transform != null) ? transform.gameObject : null);
		}

		public static PropertyGetDecimal Create(Transform transform = null)
		{
			return new PropertyGetDecimal(new GetDecimalTransformsLastChildIndex(transform));
		}
	}
}

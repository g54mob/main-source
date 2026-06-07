using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Child Count")]
	[Category("Transforms/Child Count")]
	[Image(typeof(IconHanger), ColorTheme.Type.Yellow, typeof(OverlayArrowDown))]
	[Description("The number of child game objects hanging from the referenced game object")]
	[Keywords(new string[] { "Float", "Decimal", "Double" })]
	public class GetDecimalTransformsChildCount : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetGameObject m_Transform = GetGameObjectPlayer.Create();

		public override string String => $"{m_Transform} Child Count";

		public override double Get(Args args)
		{
			GameObject gameObject = m_Transform.Get(args);
			return (gameObject != null) ? gameObject.transform.childCount : 0;
		}

		public GetDecimalTransformsChildCount()
		{
		}

		public GetDecimalTransformsChildCount(Transform transform)
			: this()
		{
			m_Transform = GetGameObjectInstance.Create((transform != null) ? transform.gameObject : null);
		}

		public static PropertyGetDecimal Create(Transform transform = null)
		{
			return new PropertyGetDecimal(new GetDecimalTransformsChildCount(transform));
		}
	}
}

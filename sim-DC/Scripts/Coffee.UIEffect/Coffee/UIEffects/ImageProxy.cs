using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	internal sealed class ImageProxy : GraphicProxy
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeOnLoad()
		{
		}

		protected override bool IsValid(Graphic graphic)
		{
			return false;
		}

		public override bool IsText(Graphic graphic)
		{
			return false;
		}

		public override Vector4 ModifyExpandSize(Graphic graphic, Vector4 expandSize)
		{
			return default(Vector4);
		}
	}
}

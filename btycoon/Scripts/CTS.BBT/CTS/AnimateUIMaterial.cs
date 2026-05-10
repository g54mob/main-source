using CTS.Core;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(UIImageMaterialInstance))]
	public abstract class AnimateUIMaterial : CTSBehaviour
	{
		[Inject(false)]
		private UIImageMaterialInstance _image;

		protected Material Material => _image.MaterialInstance;
	}
}

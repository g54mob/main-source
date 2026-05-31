using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	[Constructor("Construct")]
	public class UIImageMaterialInstance : MaterialReference
	{
		[SerializeField]
		[Inject(false)]
		private Image _image;

		private void Construct(Image imageRef)
		{
			if (_image == null)
			{
				_image = imageRef;
			}
			base.MaterialInstance = new Material(_image.material);
			_image.material = base.MaterialInstance;
		}
	}
}

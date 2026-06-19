using UnityEngine;
using UnityEngine.Rendering;

namespace Michsky.DreamOS
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class UIManagerBlur : MonoBehaviour
	{
		[SerializeField]
		private UIManager UIManagerAsset;

		private void OnEnable()
		{
			if (GraphicsSettings.defaultRenderPipeline != null && base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(value: false);
			}
			else if (UIManagerAsset != null && !UIManagerAsset.enableUIBlur && base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(value: false);
			}
			else if (GraphicsSettings.defaultRenderPipeline == null && UIManagerAsset != null && UIManagerAsset.enableUIBlur && !base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(value: true);
			}
		}
	}
}

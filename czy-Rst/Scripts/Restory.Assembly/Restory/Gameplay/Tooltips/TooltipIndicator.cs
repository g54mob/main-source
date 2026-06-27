using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.Gameplay.Tooltips
{
	public class TooltipIndicator : MonoBehaviour
	{
		[SerializeField]
		private Image indicatorImage;

		private TooltipIndicatorsService registry;

		private Camera gameCamera;

		[Inject]
		private void Construct(TooltipIndicatorsService registry)
		{
			this.registry = registry;
			if (base.isActiveAndEnabled)
			{
				registry.RegisterTooltipIndicator(this);
			}
		}

		private void OnEnable()
		{
			registry?.RegisterTooltipIndicator(this);
		}

		private void OnDisable()
		{
			registry?.UnregisterTooltipIndicator(this);
			UnblockIndicatorVisibility();
		}

		public void BlockIndicatorVisibility()
		{
			indicatorImage.gameObject.SetActive(value: false);
		}

		public void UnblockIndicatorVisibility()
		{
			indicatorImage.gameObject.SetActive(value: true);
		}

		private void LateUpdate()
		{
			if (!gameCamera)
			{
				gameCamera = Camera.main;
			}
			else
			{
				base.transform.LookAt(gameCamera.transform.position, Vector3.up);
			}
		}
	}
}

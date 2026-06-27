using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_RingPointer : UIBehaviour
	{
		[SerializeField]
		private Image ringImage;

		[SerializeField]
		[Tooltip("Maps ring height ratio (X) to ring line width percentage (Y). For example, X=0.5 Y=0.4 means ring line width is 0.4% of canvas height, when ring height is half of the screen height.")]
		private AnimationCurve heightToPercentageCurve = AnimationCurve.Linear(0f, 0.5f, 1f, 1f);

		private static readonly int InnerRadiusId = Shader.PropertyToID("_InnerRadius");

		private static readonly int OuterRadiusId = Shader.PropertyToID("_OuterRadius");

		private float gameCanvasHeight;

		private Material materialInstance;

		private float outerRadius;

		[Inject]
		private void Construct(GUI_GameplayOverlayCanvas gameplayOverlayCanvas)
		{
			CanvasScaler component = gameplayOverlayCanvas.GetComponent<CanvasScaler>();
			gameCanvasHeight = component.referenceResolution.y;
		}

		protected override void Start()
		{
			base.Start();
			Material material = ringImage.material;
			materialInstance = new Material(material);
			ringImage.material = materialInstance;
			outerRadius = materialInstance.GetFloat(OuterRadiusId);
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			UpdateInnerRadiusFromRect();
		}

		protected override void OnDestroy()
		{
			if ((bool)materialInstance)
			{
				Object.Destroy(materialInstance);
			}
			base.OnDestroy();
		}

		private void UpdateInnerRadiusFromRect()
		{
			if (gameCanvasHeight != 0f)
			{
				float height = ringImage.rectTransform.rect.height;
				float time = height / gameCanvasHeight;
				float num = heightToPercentageCurve.Evaluate(time);
				float num2 = gameCanvasHeight * (num / 100f);
				float num3 = height - num2 * 2f;
				float value = outerRadius * (num3 / height);
				materialInstance.SetFloat(InnerRadiusId, value);
			}
		}
	}
}

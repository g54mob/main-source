using Restory.UserInterface;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Common
{
	public abstract class UiViewSpawnerBase : MonoBehaviour
	{
		[Header("General settings")]
		[SerializeField]
		protected GameObject[] views = new GameObject[0];

		[SerializeField]
		protected bool chooseParentCanvasFromEnum;

		[SerializeField]
		protected Transform parent;

		[SerializeField]
		protected GameplayOverlaySubCanvas parentCanvas;

		private OverlayCanvasProviderService overlayCanvasProviderService;

		private bool instantiated;

		protected GUI_GameplayOverlayCanvas guiGameplayOverlayCanvas;

		[Inject]
		private void Construct([InjectOptional] OverlayCanvasProviderService overlayCanvasProviderService, GUI_GameplayOverlayCanvas guiGameplayOverlayCanvas)
		{
			this.overlayCanvasProviderService = overlayCanvasProviderService;
			this.guiGameplayOverlayCanvas = guiGameplayOverlayCanvas;
		}

		protected virtual void Instantiate(GameObject[] viewPrefabs)
		{
			if (instantiated)
			{
				return;
			}
			if (viewPrefabs == null)
			{
				Debug.LogError("[viewPrefabs] is null in [Instantiate], " + base.gameObject.name + ".");
				return;
			}
			Transform viewParent = GetViewParent();
			if (!guiGameplayOverlayCanvas)
			{
				Debug.LogError("[guiGameplayOverlayCanvas] is null in [Instantiate], " + base.gameObject.name + ".");
				return;
			}
			foreach (GameObject gameObject in viewPrefabs)
			{
				if ((bool)gameObject)
				{
					guiGameplayOverlayCanvas.Show(base.gameObject, gameObject, null, viewParent);
				}
			}
			instantiated = true;
		}

		protected virtual void Dispose(GameObject[] viewPrefabs)
		{
			if (!instantiated)
			{
				return;
			}
			foreach (GameObject gameObject in viewPrefabs)
			{
				if ((bool)gameObject && (bool)guiGameplayOverlayCanvas)
				{
					guiGameplayOverlayCanvas.Close(base.gameObject, gameObject);
				}
			}
			instantiated = false;
		}

		protected void OnDestroy()
		{
			Dispose(views);
			OnPostDestroy();
		}

		protected virtual void OnPostDestroy()
		{
		}

		private Transform GetViewParent()
		{
			if (!chooseParentCanvasFromEnum)
			{
				return parent;
			}
			if (parentCanvas == GameplayOverlaySubCanvas.Default)
			{
				return null;
			}
			if (overlayCanvasProviderService != null)
			{
				return overlayCanvasProviderService.GetCanvasTransform(parentCanvas);
			}
			Debug.LogWarning("[UiViewSpawner] is trying to instantiate a view into a chosen canvas, but the [CanvasProviderService] was not injected. Either install [CanvasProviderService], or select a different option for choosing the view parent. The parent for the view will now not be provided, which will most probably result in the view getting instantiated in the default main canvas.", base.gameObject);
			return null;
		}
	}
}

using Restory.Gameplay.Effects;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class InteractiveObjectVfxActivator : MonoBehaviour
	{
		[SerializeField]
		private InteractiveObject interactiveObject;

		[SerializeField]
		private BounceEffect bounceEffect;

		[SerializeField]
		private Transform vfxPoint;

		private VfxService vfxService;

		[Inject]
		private void Construct(VfxService vfxService)
		{
			this.vfxService = vfxService;
		}

		private void OnEnable()
		{
			interactiveObject.OnDragComplete += ResolveDragComplete;
			interactiveObject.OnDragCanceled += ResolveDragCanceled;
		}

		private void OnDisable()
		{
			interactiveObject.OnDragComplete -= ResolveDragComplete;
			interactiveObject.OnDragCanceled -= ResolveDragCanceled;
		}

		private void ResolveDragComplete()
		{
			bounceEffect.PlayBounce();
			vfxService.PlayPlacementEffect(vfxPoint);
		}

		private void ResolveDragCanceled()
		{
			bounceEffect.PlayBounce();
			vfxService.PlayPlacementEffect(vfxPoint);
		}
	}
}

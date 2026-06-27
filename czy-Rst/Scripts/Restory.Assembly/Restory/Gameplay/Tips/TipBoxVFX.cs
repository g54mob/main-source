using Restory.Gameplay.Effects;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tips
{
	public class TipBoxVFX : MonoBehaviour
	{
		[SerializeField]
		private TipBox tipBox;

		[SerializeField]
		private Transform vfxSpawnPoint;

		[SerializeField]
		private BounceEffect bounceEffect;

		private VfxService vfxService;

		[Inject]
		private void Construct(VfxService vfxService)
		{
			this.vfxService = vfxService;
		}

		private void OnEnable()
		{
			tipBox.OnTipsAdded += ResolveTipsAdded;
			tipBox.OnTipsReturned += ResolveTipsAdded;
			tipBox.OnTipsRemoved += ResolveTipsRemoved;
		}

		private void OnDisable()
		{
			tipBox.OnTipsAdded -= ResolveTipsAdded;
			tipBox.OnTipsReturned -= ResolveTipsAdded;
			tipBox.OnTipsRemoved -= ResolveTipsRemoved;
		}

		private void ResolveTipsAdded(int _)
		{
			bounceEffect.PlayBounce();
			vfxService.PlayMoneyEffect(vfxSpawnPoint ? vfxSpawnPoint : base.transform);
		}

		private void ResolveTipsRemoved()
		{
			bounceEffect.PlayBounce();
		}
	}
}

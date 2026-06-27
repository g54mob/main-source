using Restory.Gameplay.Effects;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.CashRegisters
{
	public class CashRegisterVFX : MonoBehaviour
	{
		[SerializeField]
		private CashRegister cashRegister;

		[SerializeField]
		private Transform vfxSpawnPoint;

		private VfxService vfxService;

		[Inject]
		private void Construct(VfxService vfxService)
		{
			this.vfxService = vfxService;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)vfxService)
			{
				Init();
			}
		}

		private void Init()
		{
			cashRegister.OnMoneyAdded += ResolveMoneyAdded;
		}

		private void OnDisable()
		{
			if (cashRegister.MonoShellExists())
			{
				cashRegister.OnMoneyAdded -= ResolveMoneyAdded;
			}
		}

		private void ResolveMoneyAdded()
		{
			vfxService.PlayMoneyEffect(vfxSpawnPoint ? vfxSpawnPoint : base.transform);
		}
	}
}

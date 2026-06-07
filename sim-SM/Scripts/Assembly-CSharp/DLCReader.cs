using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DLCReader : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRaiseWarningRoutine_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CRaiseWarningRoutine_003Ed__17(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("DLC CLoth")]
	[SerializeField]
	private List<ProductSO> ClothProductSO;

	[SerializeField]
	private List<ProductLicenseSO> ClothLicenseSO;

	[Header("DLC Electronics")]
	[SerializeField]
	private List<ProductSO> ElectronicsProductSO;

	[SerializeField]
	private List<ProductLicenseSO> ElectronicsLicenseSO;

	[Header("DLC Hardware")]
	[SerializeField]
	private List<ProductSO> HardwareProductSO;

	[SerializeField]
	private List<ProductLicenseSO> HardwareLicenseSO;

	[Header("DLC Mix")]
	[SerializeField]
	private List<ProductSO> MixProductSO;

	[SerializeField]
	private List<ProductLicenseSO> MixLicenseSO;

	[Header("DLC Bakery")]
	[SerializeField]
	private List<ProductSO> BakeryProductSO;

	[SerializeField]
	private List<ProductLicenseSO> BakeryLicenseSO;

	[Header("DLC Displays")]
	[SerializeField]
	private List<FurnitureSO> Display_Garment_RackSO;

	[SerializeField]
	private List<FurnitureSO> Display_PegboardSO;

	[SerializeField]
	private List<FurnitureSO> Display_BakerySO;

	[Header("DLC IceCream")]
	[SerializeField]
	private List<ProductSO> IceCreamProductSO;

	[SerializeField]
	private List<ProductLicenseSO> IceCreamLicenseSO;

	[SerializeField]
	private List<FurnitureSO> IceCreamFurnitureSO;

	private bool m_WillAnythingRemove;

	private void Awake()
	{
	}

	[IteratorStateMachine(typeof(_003CRaiseWarningRoutine_003Ed__17))]
	private IEnumerator RaiseWarningRoutine()
	{
		return null;
	}

	public void HandleSaveData()
	{
	}

	private void HandleDLCSaveLicenceAndProducts(List<ProductLicenseSO> dlcProductLicences, List<ProductSO> dlcProducts)
	{
	}

	private void HandleDLCFurnitures()
	{
	}

	private void AssignIDs()
	{
	}

	private void RemoveLicences(List<ProductLicenseSO> productLicenseSos)
	{
	}

	private void RemoveProducts(List<ProductSO> productSos)
	{
	}

	private void RemoveDisplays(List<FurnitureSO> furnitureSos)
	{
	}

	private void SwitchVendingDlc(bool willEnable)
	{
	}

	private void AddProducts(List<ProductSO> ProductSOs)
	{
	}

	private void AddLicenses(List<ProductLicenseSO> ProductLicenseSOs)
	{
	}

	private void AddDisplays(List<FurnitureSO> dlcDisplaysSO)
	{
	}
}

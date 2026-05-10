using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SteamAchievements : MonoBehaviour
{
	[Serializable]
	public class Achievement
	{
		public string AchievementName;

		public int goal;
	}

	[CompilerGenerated]
	private sealed class _003CCheckInitialAchievements_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SteamAchievements _003C_003E4__this;

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
		public _003CCheckInitialAchievements_003Ed__16(int _003C_003E1__state)
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

	[SerializeField]
	private Achievement m_50CheckoutAchievement;

	[SerializeField]
	private Achievement m_100CheckoutAchievement;

	[SerializeField]
	private Achievement m_PurchasedAllSectionsAchievement;

	[SerializeField]
	private Achievement m_PaintWallsAchievement;

	[SerializeField]
	private Achievement m_PaintFloorsAchievement;

	[SerializeField]
	private Achievement m_ChangeDoorPositionAchievement;

	[SerializeField]
	private Achievement m_ChangeFrontStyleAchievement;

	[SerializeField]
	private Achievement m_ChangeDoorNameAchievement;

	[SerializeField]
	private Achievement m_4LicenceAchievement;

	[SerializeField]
	private Achievement m_CategorySignPlacementAchievement;

	[SerializeField]
	private Achievement m_MusicPlayerAchievement;

	[SerializeField]
	private Achievement m_RestockerAchievement;

	[SerializeField]
	private Achievement m_CashierAchievement;

	[SerializeField]
	private Achievement m_TakeLoanAchievement;

	[SerializeField]
	private Achievement m_PayLoanAchievement;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CCheckInitialAchievements_003Ed__16))]
	private IEnumerator CheckInitialAchievements()
	{
		return null;
	}

	private void CheckAllSectionsPurchased()
	{
	}

	private void CheckAllLicencesPurchased()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnCompletedCheckout()
	{
	}

	private void OnSectionPurchased(int id)
	{
	}

	private void OnWallsPainted()
	{
	}

	private void OnFloorsPainted()
	{
	}

	private void OnDoorPositionChanged()
	{
	}

	private void OnFrontStyleChanged()
	{
	}

	private void OnDoorNameChanged()
	{
	}

	private void OnLicencePurchased(int id)
	{
	}

	private void OnCategorySignPlacement()
	{
	}

	private void OnMusicPlayed()
	{
	}

	private void OnRestockerHired()
	{
	}

	private void OnCashierHired()
	{
	}

	private void OnLoanTaken(int i)
	{
	}

	private void OnLoanPaid(int i)
	{
	}
}

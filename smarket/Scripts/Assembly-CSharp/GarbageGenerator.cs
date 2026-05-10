using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Data;

public class GarbageGenerator : NoktaSingletonPunCallbacks<GarbageGenerator>
{
	[CompilerGenerated]
	private sealed class _003CTryToFindDust_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GarbageGenerator _003C_003E4__this;

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
		public _003CTryToFindDust_003Ed__60(int _003C_003E1__state)
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
	private List<Garbage> m_GarbagePrefabs;

	[SerializeField]
	private List<Garbage> m_License1Garbages;

	[SerializeField]
	private Dirt m_DirtPrefab;

	[SerializeField]
	private List<Dust> m_Dusts;

	[SerializeField]
	private Vector2 m_xRange;

	[SerializeField]
	private Vector2 m_zRange;

	[SerializeField]
	private Transform m_GarbageParentTransform;

	[SerializeField]
	private Transform m_DirtParentTransform;

	[SerializeField]
	private float m_yGarbageOffSet;

	[SerializeField]
	private float m_yDirtOffSet;

	[SerializeField]
	private int m_DirtExp;

	[SerializeField]
	private int m_GarbageExp;

	public Action<bool> OnGarbageBagDestroyed;

	public Action<bool> OnGarbageDespawned;

	public Action<bool> OnDirtDespawned;

	public Action<bool> OnGlassCleaned;

	public Action OnDirtLevelChange;

	public float range;

	private List<Garbage> ownedProductsGarbages;

	private List<Garbage> garbages;

	private List<Dirt> dirts;

	private bool isDirtIndicatorEnable;

	private List<int> _closedGarbagePhotonViews;

	public int DirtsCount => 0;

	public bool IsDirtIndicatorEnable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public List<Dust> Dusts
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<Garbage> OwnedProductsGarbages
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<Dirt> Dirts
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<Garbage> Garbages
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	private void OnSaveRequested()
	{
	}

	private void OnSyncRequestHandler(string invokerUserID)
	{
	}

	[PunRPC]
	public void CloseOldGarbageList(int[] closedGarbagePhotonViews)
	{
	}

	public override void OnJoinedRoom()
	{
	}

	private bool IsPointInRange(float x, float z)
	{
		return false;
	}

	private bool IsOnNavMesh(Vector3 position)
	{
		return false;
	}

	private bool RandomPoint(out Vector3 result)
	{
		result = default(Vector3);
		return false;
	}

	public void UpdateOwnedProductsGarbage()
	{
	}

	private void SwitchDirtIndicator(bool value)
	{
	}

	[PunRPC]
	public void GetDirtList_RPC(string userID, bool value)
	{
	}

	[PunRPC]
	public void SetDirtListAndIndicator(int[] dirtPhotonViewIDs, int[] activeJanitorTargetDirt, bool value)
	{
	}

	private void DirtIndicatorStat(bool value)
	{
	}

	public void SpawnGarbage(bool isFromSaveFile)
	{
	}

	public void SpawnAllGarbages(GarbageSaveData garbageData)
	{
	}

	public void SpawnDirt(bool isFromSaveFile)
	{
	}

	public void LoadSaveData()
	{
	}

	public void SaveDustingData(DustingSaveData saveData)
	{
	}

	public Dust Dusting()
	{
		return null;
	}

	public void Dusting(bool isOnboarding)
	{
	}

	[IteratorStateMachine(typeof(_003CTryToFindDust_003Ed__60))]
	private IEnumerator TryToFindDust()
	{
		return null;
	}

	public void Despawn(Garbage garbage)
	{
	}

	[PunRPC]
	public void GarbageClose_RPC(int viewID)
	{
	}

	[PunRPC]
	public void DirtClose_RPC(int viewID)
	{
	}

	public void Despawn(Dirt dirt)
	{
	}

	public void SpawnGarbageNetwork(bool isFromSaveFile)
	{
	}

	public Garbage GenerateRandomGarbageNetwork(GarbageSaveData garbageSaveData)
	{
		return null;
	}

	public void GenerateRandomDirtNetwork(bool isFromSaveFile)
	{
	}

	public void DustingNetwork()
	{
	}

	[PunRPC]
	public void RPC_Dust()
	{
	}

	public void LoadDustingNetwork()
	{
	}

	[PunRPC]
	public void LoadDusting_RPC(string dustJson)
	{
	}

	private void GenerateRandomGarbageLocal()
	{
	}

	private void GenerateRandomDirtLocal()
	{
	}
}

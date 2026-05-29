using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;

public class IceCreamManager : NoktaSingleton<IceCreamManager>
{
	[Serializable]
	public class StandBoxData
	{
		public int[] ConeCounts;

		public IceCreamFlavourData[] FlavourData;

		private static readonly byte[] m_Bytes;

		public static short Serialize(StreamBuffer outStream, object customObject)
		{
			return 0;
		}

		public static StandBoxData Deserialize(StreamBuffer inStream, short len)
		{
			return null;
		}
	}

	[Serializable]
	public class StandData
	{
		public TransformData Transform;

		public IceCreamFlavourData[] Flavours;

		public int[] ConeCounts;

		public NetworkIceCreamStand.SyncState ToSyncState()
		{
			return default(NetworkIceCreamStand.SyncState);
		}
	}

	private List<IceCreamStand> m_Stands;

	private List<StandData> m_Data;

	[SerializeField]
	private IceCreamBucket m_BucketPrefab;

	[SerializeField]
	private FurnitureSO m_StandSO;

	[SerializeField]
	private IceCreamRequestVisualGenerator m_IceCreamRequestVisualGenerator;

	[SerializeField]
	private IceCreamRequestDisplay m_RequestDisplay;

	[SerializeField]
	private ProductSO[] m_ConeProductSO;

	private static bool m_Registered;

	public List<StandData> Data
	{
		get
		{
			return null;
		}
		private set
		{
		}
	}

	public bool IsLoaded { get; private set; }

	public FurnitureSO StandSO => null;

	public IceCreamRequestVisualGenerator IceCreamRequestVisualGenerator => null;

	public IceCreamRequestDisplay RequestDisplay => null;

	public ProductSO[] ConeProductSO => null;

	[RuntimeInitializeOnLoadMethod]
	private static void ResetRegistrationStatus()
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnStartedNewDay()
	{
	}

	private void OnSaveRequested()
	{
	}

	private void LoadSaveProgress()
	{
	}

	private void LoadData()
	{
	}

	public void AddStand(IceCreamStand stand)
	{
	}

	public void Remove(IceCreamStand stand)
	{
	}

	public bool TryGetActiveStand(out IceCreamStand value)
	{
		value = null;
		return false;
	}

	public float CalculatePrice(IceCreamStatus status)
	{
		return 0f;
	}

	public IEnumerable<IceCreamStand> IterateStands()
	{
		return null;
	}

	public IceCreamStand GetAvailableStandForEmployee()
	{
		return null;
	}

	public void AddHelper(IceCreamHelper iceCreamHelper = null)
	{
	}

	public void RemoveEmployee(IceCreamHelper helper)
	{
	}
}

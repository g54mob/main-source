using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public class NetworkedAreaItemScript : MonoBehaviour, INetworkedAreaItem
	{
		private bool _active = true;

		private float _lastWriteTime;

		[SerializeField]
		private bool _requestDamageReceiverId;

		public INetworkedArea Area { get; private set; }

		public byte? DamageReceiverId { get; private set; }

		public bool IsActive
		{
			get
			{
				return _active;
			}
			set
			{
				if (_active != value)
				{
					_active = value;
					base.gameObject.SetActive(value);
				}
			}
		}

		public byte ItemID { get; private set; }

		public float TimeSinceLastWrite => Time.time - _lastWriteTime;

		public virtual float CalculateDelta()
		{
			return 0f;
		}

		public virtual void InitializeArea(INetworkedArea area, byte itemID)
		{
			ItemID = itemID;
			Area = area;
			if (_requestDamageReceiverId)
			{
				DamageReceiverId = itemID;
			}
		}

		public virtual void ReadState(PooledReader reader, float timeDelta)
		{
		}

		public void UpdateLastWriteTime()
		{
			_lastWriteTime = Time.time;
		}

		public virtual void WriteState(PooledWriter writer)
		{
		}

		protected virtual void Awake()
		{
		}
	}
}

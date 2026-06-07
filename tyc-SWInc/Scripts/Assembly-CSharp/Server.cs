using System;
using Achievements;
using UnityEngine;
using UnityEngine.Serialization;

public class Server : Writeable, IServerHost
{
	public const float ISPCost = 18f;

	private string _serverName;

	[NonSerialized]
	public Server WiredTo;

	[NonSerialized]
	private Furniture _furn;

	public TextMesh TextObj;

	[NonSerialized]
	public bool Selected;

	[SerializeField]
	[FormerlySerializedAs("Power")]
	private float _power = 1f;

	[NonSerialized]
	public float _available = 1f;

	[NonSerialized]
	public bool PreWired;

	public string TServerName
	{
		get
		{
			return _serverName;
		}
		set
		{
			_serverName = value;
			TextObj.text = _serverName;
			GameSettings.Instance.ValidateServer(this);
		}
	}

	public string ServerName
	{
		get
		{
			return TServerName;
		}
		set
		{
			TServerName = value;
		}
	}

	public Furniture furn
	{
		get
		{
			if (_furn.IsReferenceNull())
			{
				_furn = GetComponent<Furniture>();
			}
			else if (!_furn.IsGOActive)
			{
				return null;
			}
			return _furn;
		}
	}

	public float Available
	{
		get
		{
			return _available;
		}
		set
		{
			_available = value;
		}
	}

	public ServerGroup Group
	{
		get
		{
			return GameSettings.Instance.GetServerGroup(ServerName);
		}
	}

	private Upgradable Upg
	{
		get
		{
			if (!(furn == null))
			{
				return furn.upg;
			}
			return null;
		}
	}

	public float Power
	{
		get
		{
			return _power;
		}
		set
		{
			_power = value;
		}
	}

	public static float GetISPCost()
	{
		return GameSettings.Instance.Environment.ISPCostFactor * 18f;
	}

	private void Start()
	{
		if (furn == null || furn.isTemporary || furn.Map != null)
		{
			return;
		}
		InitWritable();
		if (!Deserialized)
		{
			TutorialSystem.Instance.StartTutorial("Server");
			if (!PreWired)
			{
				ServerName = GameSettings.Instance.GenerateServerName();
			}
			CameraScript.Instance.WireRender.ForceDirty = true;
			AchievementController.SetInteraction(AchievementController.Mechanics.Servers);
		}
		GameSettings.CalculateServerPowerNow.Add(ServerName);
	}

	public override string ToString()
	{
		return ServerName;
	}

	private void OnDestroy()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			Furniture component = GetComponent<Furniture>();
			if (component == null || !component.isTemporary)
			{
				CancelWire(true);
				GameSettings.Instance.RemoveServer(this, component == null || !component.NonPlayerDestruction);
			}
		}
	}

	public bool IsRep()
	{
		ServerGroup serverGroup = GameSettings.Instance.GetServerGroup(ServerName);
		if (serverGroup != null)
		{
			return serverGroup.Rep == this;
		}
		return true;
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull() || furn.IsReferenceNull() || furn.isTemporary)
		{
			return;
		}
		if (GameSettings.Instance.WireMode && (furn.Parent.Floor <= GameSettings.Instance.ActiveFloor || Selected))
		{
			bool flag = IsRep();
			TextObj.gameObject.SetActive(flag);
			if (flag)
			{
				TextObj.transform.rotation = Quaternion.LookRotation(new Vector3(base.transform.position.x - CameraScript.Instance.mainCam.transform.position.x, 0f, base.transform.position.z - CameraScript.Instance.mainCam.transform.position.z));
			}
		}
		else
		{
			TextObj.gameObject.SetActive(false);
		}
	}

	public void CancelWire(bool pendingDestruction = false)
	{
		if (GameSettings.Instance.IsReferenceNull() || HUD.Instance == null)
		{
			return;
		}
		ServerGroup serverGroup = GameSettings.Instance.GetServerGroup(ServerName);
		if (serverGroup != null && serverGroup.Servers.Count > 1)
		{
			WiredTo = null;
			GameSettings.Instance.RemoveServer(this);
			if (!pendingDestruction)
			{
				GameSettings.Instance.AddServer(this);
				GameSettings.FixServerWiringNow.Add(ServerName);
			}
		}
	}

	public void ReWire()
	{
		CameraScript.Instance.WireRender.ForceDirty = true;
	}

	public void WireTo(Server server)
	{
		if (server.ServerName != ServerName)
		{
			GameSettings.Instance.RemoveServer(this);
			ServerName = server.ServerName;
			GameSettings.FixServerWiringNow.Add(ServerName);
		}
		else
		{
			ReWire();
		}
	}

	public override string WriteName()
	{
		return "Server";
	}

	public float GetGroupAvailable()
	{
		ServerGroup serverGroup = GameSettings.Instance.GetServerGroup(ServerName);
		if (serverGroup == null)
		{
			return 1f;
		}
		return serverGroup.Available;
	}

	public override void PostDeserialize()
	{
		base.PostDeserialize();
		TimeProbe.BeginTime("Server init time:");
		GameSettings.Instance.ValidateServer(this);
		GameSettings.FixServerWiringNow.Add(ServerName);
		TimeProbe.EndTime("Server init time:");
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		_serverName = dictionary.Get("Name", "Server X");
		TextObj.text = _serverName;
		return this;
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		dictionary["WiredTo"] = ((!(WiredTo == null)) ? WiredTo.DID : 0u);
		dictionary["Name"] = ServerName;
	}
}

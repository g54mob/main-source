using System.Collections;
using DV.CabControls;
using TMPro;
using UnityEngine;

public class CouplingHoseCouplerAdapter : CouplingHoseAdapterBase
{
	private const string ANIM_NAME = "CockLever_LFS";

	public GameObject cockGameObject;

	public Transform cockLever;

	public TextMeshPro debugTMPRO;

	public CouplingHoseAudio hoseAudio;

	[HideInInspector]
	public Coupler coupler;

	private ControlImplBase cockControl;

	private Animation cockAnim;

	private AnimationState cockAnimState;

	public override bool IsConnected
	{
		get
		{
			if (coupler != null)
			{
				return coupler.hoseAndCock.IsHoseConnected;
			}
			return false;
		}
	}

	public override bool IsInitialized => coupler != null;

	public void Init(Coupler coupler)
	{
		this.coupler = coupler;
		coupler.HoseConnectionChanged += OnHoseConnectionChangedExternally;
		HandleIfAlreadyConnectedOnSpawn();
		coupler.train.InteriorAboutToBeDestroyed += base.OnCarInteriorAboutToBeDestroyed;
	}

	public void Start()
	{
		StartCoroutine(DelayedControlInit());
	}

	private IEnumerator DelayedControlInit()
	{
		for (int i = 0; i < 100; i++)
		{
			cockControl = cockGameObject.GetComponent<ControlImplBase>();
			if (cockControl != null)
			{
				break;
			}
			yield return null;
		}
		if (cockControl == null)
		{
			Debug.LogError("cockLever did not initialize!");
			yield break;
		}
		cockAnim = cockLever.GetComponent<Animation>();
		cockAnimState = cockAnim["CockLever_LFS"];
		cockControl.SetValue(coupler.IsCockOpen ? 1 : 0);
		cockControl.Used += OnCockUsed;
		coupler.hoseAndCock.CockChanged += OnCockChangedExternally;
	}

	public override HoseType GetHoseType()
	{
		return HoseType.Brake;
	}

	public override void RequestConnectImplementation(CouplingHoseRig other)
	{
		CouplingHoseCouplerAdapter couplingHoseCouplerAdapter = other.adapter as CouplingHoseCouplerAdapter;
		if (couplingHoseCouplerAdapter == null)
		{
			Debug.LogError("Attempted to connect different type of adapters!", this);
		}
		else
		{
			coupler.ConnectAirHose(couplingHoseCouplerAdapter.coupler, playAudio: true);
		}
	}

	public override void RequestDisconnectImplementation()
	{
		coupler.DisconnectAirHose(playAudio: true);
	}

	private void OnDestroy()
	{
		if ((bool)coupler)
		{
			coupler.hoseAndCock.CockChanged -= OnCockChangedExternally;
			coupler.HoseConnectionChanged -= OnHoseConnectionChangedExternally;
		}
		if ((bool)cockControl)
		{
			cockControl.Used -= OnCockUsed;
		}
	}

	private void HandleIfAlreadyConnectedOnSpawn()
	{
		if (!rig.ConnectionManager.IsConnected && !(coupler.GetAirHoseConnectedTo() == null))
		{
			CouplingHoseCouplerAdapter hoseAdapter = coupler.CoupledToOrWithinBreakDistance.visualCoupler.hoseAdapter;
			if (!hoseAdapter)
			{
				Debug.LogWarning("CouplingHoseCouplerAdapter couldn't find other adapter", this);
			}
			else
			{
				rig.ConnectionManager.Connect(hoseAdapter.rig);
			}
		}
	}

	private void OnCockUsed()
	{
		bool flag = !coupler.IsCockOpen;
		coupler.IsCockOpen = flag;
		UpdateCock(flag);
	}

	private void OnCockChangedExternally(bool open)
	{
		hoseAudio.PlayCockSound(open);
		UpdateCock(open);
	}

	private void OnHoseConnectionChangedExternally(bool connected, bool _, bool playAudio)
	{
		if (connected)
		{
			VisualCouplerInit visualCoupler = coupler.GetAirHoseConnectedTo().visualCoupler;
			if (!visualCoupler)
			{
				return;
			}
			CouplingHoseRig couplingHoseRig = visualCoupler.hoseAdapter.rig;
			if (CouplingHoseConnectionManager.GetMaster(rig, couplingHoseRig) == rig)
			{
				rig.ConnectionManager.Connect(couplingHoseRig);
				if (playAudio)
				{
					hoseAudio.PlayConnectSound();
				}
			}
		}
		else if (rig.ConnectionManager.IsMaster)
		{
			rig.ConnectionManager.Disconnect();
			if (playAudio)
			{
				hoseAudio.PlayDisconnectSound();
			}
		}
	}

	private void UpdateCock(bool open)
	{
		cockAnimState.speed = (open ? 1 : (-1));
		if (!cockAnim.isPlaying)
		{
			cockAnimState.time = (open ? 0f : cockAnimState.length);
		}
		cockAnim.Play("CockLever_LFS");
	}

	private void Update()
	{
		if (coupler != null && !cockAnim.isPlaying)
		{
			bool isCockOpen = coupler.IsCockOpen;
			float num = cockLever.transform.localRotation.eulerAngles.y;
			if (num > 0f)
			{
				num -= 180f;
			}
			else if (num < -180f)
			{
				num += 180f;
			}
			if ((isCockOpen && num != -135f) || (!isCockOpen && num != -45f))
			{
				UpdateCock(isCockOpen);
			}
		}
	}
}

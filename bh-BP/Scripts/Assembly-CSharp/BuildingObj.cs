using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingObj : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_MoveToPos_003Ed__38 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BuildingObj _003C_003E4__this;

		public Vector3 pos;

		private Vector3 _003CstartPos_003E5__2;

		private float _003CstartTime_003E5__3;

		private float _003Clen_003E5__4;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_MoveToPos_003Ed__38(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003C_MoveToRot_003Ed__44 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BuildingObj _003C_003E4__this;

		public int rot;

		private float _003CcurRot_003E5__2;

		private float _003CtgtRot_003E5__3;

		private float _003CstartTime_003E5__4;

		private float _003Clen_003E5__5;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_MoveToRot_003Ed__44(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003C_RunBounce_003Ed__64 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Vector2 hitNormal;

		public BuildingObj _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Vector3 _003CbounceOffset_003E5__3;

		private Transform _003CtgtXfm_003E5__4;

		private Vector3 _003CdefaultBldMeshEulerAngles_003E5__5;

		private float _003CdefaultScale_003E5__6;

		private Vector3 _003CsqueezeScale_003E5__7;

		private Vector3 _003CdefaultPos_003E5__8;

		private Vector3 _003CdefaultRot_003E5__9;

		private Vector3 _003CrotAmt_003E5__10;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunBounce_003Ed__64(int _003C_003E1__state)
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

	[NonSerialized]
	[OdinSerialize]
	public BuildingInst Inst;

	public Transform MeshWrapper;

	public BuildingMeshObj MeshObj;

	public BaseScaffoldObj Scaffold;

	private bool _isHover;

	public Transform ColWrapper;

	public Collider2D Col;

	public BoxCollider2D BoxCol;

	public CircleCollider2D CircleCol;

	public PolygonCollider2D PolyCol;

	private CoroutineHandle _curBounceAnim;

	private CoroutineHandle _hitFlashAnim;

	private bool _subscribed;

	private CoroutineHandle _curRotAnim;

	private CoroutineHandle _curMoveAnim;

	private Vector3 _defaultSpritePos;

	private bool _isPreview;

	public GameObject WrapperOverlay;

	public Image ImgOverlayStatus;

	public Image ImgOverlayNotif;

	public RectTransform WrapperOverlayResources;

	public TextMeshProUGUI TxtOverlayResources;

	public Transform WrapperLauncherAim;

	public GameObject WrapperBldBar;

	public Image BldBarFill;

	private bool _isMoving;

	private bool _isRotating;

	private CoroutineHandle _updateAnim;

	private const float kBounceLen = 0.175f;

	private const float kSqueezeScale = 0.0125f;

	private void Awake()
	{
	}

	public void Init(BuildingInst b, bool isPreview)
	{
	}

	public bool HasMesh()
	{
		return false;
	}

	public void SetOutline(Color c)
	{
	}

	public void ClearOutline()
	{
	}

	public void SetColor(Color c)
	{
	}

	private void UpdateWorkstationProgress()
	{
	}

	private void RefreshLayers()
	{
	}

	public void SetPos(Vector3 pos)
	{
	}

	public void MoveToPos(Vector3 pos)
	{
	}

	[IteratorStateMachine(typeof(_003C_MoveToPos_003Ed__38))]
	private IEnumerator<float> _MoveToPos(Vector3 pos)
	{
		return null;
	}

	public bool IsMoving()
	{
		return false;
	}

	public bool IsRotating()
	{
		return false;
	}

	public Vector3 GetDefaultEulerAngles()
	{
		return default(Vector3);
	}

	public void SetRot(int rot)
	{
	}

	public void MoveToRot(int rot)
	{
	}

	[IteratorStateMachine(typeof(_003C_MoveToRot_003Ed__44))]
	private IEnumerator<float> _MoveToRot(int rot)
	{
		return null;
	}

	public void RunHarvestFX(bool isDepleted)
	{
	}

	public void RefreshCollider(bool isInitial)
	{
	}

	public void InitScaffold(bool animateEntry)
	{
	}

	public void OnScaffoldHit()
	{
	}

	public void DisableScaffold(bool animateExit)
	{
	}

	public void RefreshSprite(bool isPreview)
	{
	}

	public void Reset()
	{
	}

	public void RefreshBuildBar()
	{
	}

	public bool IsEmpty()
	{
		return false;
	}

	public bool CanBuildOn()
	{
		return false;
	}

	public void OnBaseStateChanged()
	{
	}

	private void OnResourcesChanged(ResourceType rt)
	{
	}

	public void RefreshStatusIcon()
	{
	}

	public void SetHover(bool hover)
	{
	}

	public void RunBounce(Vector2 hitNormal)
	{
	}

	public void OnHit(BallObj b, Vector2 hitNormal)
	{
	}

	public Vector3 GetTiltRot(Vector2 hitNormal, Vector3 hitOffset)
	{
		return default(Vector3);
	}

	[IteratorStateMachine(typeof(_003C_RunBounce_003Ed__64))]
	private IEnumerator<float> _RunBounce(Vector2 hitNormal)
	{
		return null;
	}

	public void RunHoverBounce()
	{
	}
}

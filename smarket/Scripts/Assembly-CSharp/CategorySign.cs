using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyBox;
using Photon.Pun;
using TinyGiantStudio.Text;
using UnityEngine;
using __Project__.Scripts.Data;
using __Project__.Scripts.Multiplayer;

public class CategorySign : MonoBehaviour, IInteractable
{
	[CompilerGenerated]
	private sealed class _003CDelayedBackgroundSwitch_003Ed__69 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CategorySign _003C_003E4__this;

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
		public _003CDelayedBackgroundSwitch_003Ed__69(int _003C_003E1__state)
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

	[Separator("Placing Settings", false)]
	[SerializeField]
	private FurniturePlacingMode m_PlacingMode;

	[SerializeField]
	private int m_ID;

	[SerializeField]
	private Modular3DText m_SignFrontText;

	[SerializeField]
	private Modular3DText m_SignBackText;

	[SerializeField]
	private MeshRenderer m_NameBackgroundRenderer;

	[SerializeField]
	private MeshRenderer m_IconFrontRenderer;

	[SerializeField]
	private MeshRenderer m_IconBackRenderer;

	private CategorySignData m_CategorySignData;

	private PhotonView m_PhotonView;

	private NetworkCategorySign m_NetworkCategorySign;

	private bool m_IsOccupied;

	public PhotonView PhotonView => null;

	public bool IsOccupied
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public NetworkCategorySign OwnNetworkCategorySign => null;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool NeedRepair { get; set; }

	public FurniturePlacingMode PlacingMode => null;

	public InteractionType InteractionType => default(InteractionType);

	public int ID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public CategorySignData Data
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Modular3DText SignFrontText
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Modular3DText SignBackText
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public MeshRenderer NameBackgroundRenderer
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public MeshRenderer IconFrontRenderer
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public MeshRenderer IconBackRenderer
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnSave()
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public void StartPlacingMode()
	{
	}

	public void StartPlacingModeOrder(string userId)
	{
	}

	public void PlaceCategorySign()
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedBackgroundSwitch_003Ed__69))]
	private IEnumerator DelayedBackgroundSwitch()
	{
		return null;
	}

	public void Despawn()
	{
	}

	public void OccupyCategorySign(bool isOccupied)
	{
	}

	public void OccupyOrder(bool isOccupied)
	{
	}

	public bool CustomInteract()
	{
		return false;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace __Project__.Scripts.FloorPaintSystem
{
	public class PaintableFloor : MonoBehaviour, IInteractable
	{
		[CompilerGenerated]
		private sealed class _003CDelayedDespawn_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CDelayedDespawn_003Ed__35(int _003C_003E1__state)
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

		public FloorSaveData floorSaveData;

		private FloorTextureData m_TextureData;

		public List<MeshRenderer> floorRenderers;

		public int floorID;

		public Transform pivotObject;

		public InteractactableType Type => default(InteractactableType);

		public bool ContinousInteraction => false;

		public InteractionType InteractionType => default(InteractionType);

		public string InstantInteractionHint => null;

		public string HoldingInteractionHint => null;

		public string SecondInteractionHint => null;

		public string RepairInteractionHint => null;

		public bool NeedRepair { get; set; }

		public FloorTextureData TextureData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public FloorTextureType TextureType => default(FloorTextureType);

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

		public bool RemoteInteract(string userId)
		{
			return false;
		}

		public bool CustomInteract()
		{
			return false;
		}

		public void Initialize(FloorTextureData textureData)
		{
		}

		public void CloseThisFloor()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedDespawn_003Ed__35))]
		private IEnumerator DelayedDespawn(FloorTextureData textureData)
		{
			return null;
		}

		public void BePainted(FloorTextureData textureData)
		{
		}
	}
}

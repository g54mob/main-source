using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ShellanderGames.WeaponWheel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.UI
{
	public class WeaponWheelController : NoktaSingleton<WeaponWheelController>
	{
		[CompilerGenerated]
		private sealed class _003CDelayedClosed_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CDelayedClosed_003Ed__33(int _003C_003E1__state)
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

		public float closeDelay;

		[Header("Scanner")]
		[SerializeField]
		private Image m_ScannerClosedImage;

		[SerializeField]
		private Image m_ScannerImage;

		[SerializeField]
		private TMP_Text m_ScannerText;

		[SerializeField]
		private TMP_Text m_ScannerLockedText;

		[Header("Crate")]
		[SerializeField]
		private Image m_CrateClosedImage;

		[SerializeField]
		private Image m_CrateImage;

		[SerializeField]
		private TMP_Text m_CrateText;

		[SerializeField]
		private TMP_Text m_CrateLockedText;

		[Header("Mop")]
		[SerializeField]
		private Image m_MopImage;

		[SerializeField]
		private TMP_Text m_MopText;

		[Header("Sponge")]
		[SerializeField]
		private Image m_SpongeImage;

		[SerializeField]
		private TMP_Text m_SpongeText;

		[Header("Bat")]
		[SerializeField]
		private Image m_BatClosedImage;

		[SerializeField]
		private Image m_BatImage;

		[SerializeField]
		private TMP_Text m_BatText;

		[SerializeField]
		private TMP_Text m_BatLockedText;

		[Header("Paper Bag")]
		[SerializeField]
		private Image m_PaperBagClosedImage;

		[SerializeField]
		private Image m_PaperBagImage;

		[SerializeField]
		private TMP_Text m_PaperBagText;

		[SerializeField]
		private TMP_Text m_PaperBagLockedText;

		private SgWeaponWheel m_WeaponWheel;

		public Action onToolSelected;

		public Action onToolWheelOpened;

		public bool IsOpen { get; set; }

		public bool IsWheelInteraction => false;

		private void Start()
		{
		}

		public void OnOpened()
		{
		}

		public void OnClosed()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedClosed_003Ed__33))]
		private IEnumerator DelayedClosed()
		{
			return null;
		}

		public void OnToolSelected(SgSliceController sliceController)
		{
		}

		public void OnToolSelectedNetwork(string userID, string toolName)
		{
		}
	}
}

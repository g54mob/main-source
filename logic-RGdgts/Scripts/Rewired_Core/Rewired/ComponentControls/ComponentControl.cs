using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentControl : MonoBehaviour, IComponentControl
	{
		private sealed class OkrcUkwYxNquQmBxYxxxsDJlAsXo : IDisposable, IEnumerator, IEnumerator<object>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private object USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			public ComponentControl GZXxEqHwrHYIyUJtInpLwgTukJaY;

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
			public OkrcUkwYxNquQmBxYxxxsDJlAsXo(int P_0)
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

		private IComponentController _controller;

		[NonSerialized]
		private bool juAmOHdlEuZcdEbopfsigKMAJgtHb;

		[NonSerialized]
		private bool CmiBUFsLMHUgAlaHTFsrJVtqAftp;

		private int _lastUpdateFrame;

		internal abstract bool lQbkmKnTRMhMmINePIJrIZrbBwDnA { get; }

		internal bool qumTafanxrjKbDduWdypwIzXqmiP => false;

		[CustomObfuscation]
		internal ComponentControl()
		{
		}

		public abstract void ClearValue();

		void IComponentControl.Update()
		{
		}

		[CustomObfuscation]
		internal virtual void Awake()
		{
		}

		[CustomObfuscation]
		internal virtual void Start()
		{
		}

		[CustomObfuscation]
		internal virtual void OnEnable()
		{
		}

		[CustomObfuscation]
		internal virtual void OnDisable()
		{
		}

		[CustomObfuscation]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation]
		internal virtual void OnValidate()
		{
		}

		[CustomObfuscation]
		internal virtual void OnCanvasGroupChanged()
		{
		}

		[CustomObfuscation]
		internal virtual void OnTransformParentChanged()
		{
		}

		[CustomObfuscation]
		internal virtual void OnDidApplyAnimationProperties()
		{
		}

		[CustomObfuscation]
		internal virtual void Reset()
		{
		}

		internal virtual void IghfPvNUXsucbZILFgzLRWwwGmUeA()
		{
		}

		internal virtual bool qrhyEDreMhRqasASvGWwEiXwPpSPA()
		{
			return false;
		}

		internal virtual void uhEFXpfuSMWRlvfmhKQBEnwDmHLy()
		{
		}

		internal virtual void pmxmOeyRAlBoCxmllQyaxtECbvcr()
		{
		}

		internal virtual void KhQueZDBBtkbvKkxubYmYxeSHJrfA()
		{
		}

		internal virtual void CbvCdtcgkXIqLYOKEKJdhBmfrjFcB()
		{
		}

		internal virtual void wfYqWOGHtnIUbtMhSNJLmUHIcfqd()
		{
		}

		internal virtual void LLzALYpKRiDYsyFTIBJvkresqDwWA()
		{
		}

		internal bool BmJxkhIhAZjPFwDWRTfFEWoVOzdM()
		{
			return false;
		}

		internal bool WxjgszJOjbxlRCNUKYbaHdWiodnx()
		{
			return false;
		}

		internal IComponentController jEXzKujpjLIhjTJCTTXuiKAPfKVb()
		{
			return null;
		}

		[CustomObfuscation]
		internal abstract IComponentController FindController();

		[CustomObfuscation]
		internal abstract Type GetRequiredControllerType();

		private IEnumerator kQUIFOCdkeyHwGfhjtxnuJIuWHOQ()
		{
			return null;
		}

		private void zBFbVgFivIFkRriBBSLwgWJemDVY()
		{
		}

		private bool qfsLyjdmcZwvIKgTdfBWbFYINZEs(bool P_0, bool P_1)
		{
			return false;
		}

		private void fLESigLZMfTrdvEIqdmveetSjBkA()
		{
		}

		private void vEXOvbTaIIFRHIZgpBymQtpGpuYE()
		{
		}
	}
}

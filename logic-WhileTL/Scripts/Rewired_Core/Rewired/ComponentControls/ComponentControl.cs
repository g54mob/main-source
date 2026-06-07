using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired.Utils;
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
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public OkrcUkwYxNquQmBxYxxxsDJlAsXo(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				ComponentControl gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
				{
				default:
					return false;
				case 0:
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					USjDTWbJtWhEBdYYYfLUglTcnnGrA = null;
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
					return true;
				case 1:
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					if (!gZXxEqHwrHYIyUJtInpLwgTukJaY.BmJxkhIhAZjPFwDWRTfFEWoVOzdM())
					{
						return false;
					}
					gZXxEqHwrHYIyUJtInpLwgTukJaY.OnEnable();
					return false;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private IComponentController _controller;

		[NonSerialized]
		private bool juAmOHdlEuZcdEbopfsigKMAJgtHb;

		[NonSerialized]
		private bool CmiBUFsLMHUgAlaHTFsrJVtqAftp;

		private int _lastUpdateFrame = -1;

		internal abstract bool lQbkmKnTRMhMmINePIJrIZrbBwDnA { get; }

		internal bool qumTafanxrjKbDduWdypwIzXqmiP => juAmOHdlEuZcdEbopfsigKMAJgtHb;

		[CustomObfuscation(rename = false)]
		internal ComponentControl()
		{
		}

		public abstract void ClearValue();

		void IComponentControl.Update()
		{
			int frameCount = Time.frameCount;
			if (_lastUpdateFrame != frameCount)
			{
				_lastUpdateFrame = frameCount;
				IghfPvNUXsucbZILFgzLRWwwGmUeA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			CmiBUFsLMHUgAlaHTFsrJVtqAftp = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!CmiBUFsLMHUgAlaHTFsrJVtqAftp)
			{
				juAmOHdlEuZcdEbopfsigKMAJgtHb = false;
				StartCoroutine(kQUIFOCdkeyHwGfhjtxnuJIuWHOQ());
				CmiBUFsLMHUgAlaHTFsrJVtqAftp = true;
			}
			else if (Application.isPlaying)
			{
				zBFbVgFivIFkRriBBSLwgWJemDVY();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (Application.isPlaying)
			{
				uhEFXpfuSMWRlvfmhKQBEnwDmHLy();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				fLESigLZMfTrdvEIqdmveetSjBkA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				qfsLyjdmcZwvIKgTdfBWbFYINZEs(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				qfsLyjdmcZwvIKgTdfBWbFYINZEs(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			_ = juAmOHdlEuZcdEbopfsigKMAJgtHb;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			_ = juAmOHdlEuZcdEbopfsigKMAJgtHb;
		}

		internal virtual void IghfPvNUXsucbZILFgzLRWwwGmUeA()
		{
		}

		internal virtual bool qrhyEDreMhRqasASvGWwEiXwPpSPA()
		{
			juAmOHdlEuZcdEbopfsigKMAJgtHb = false;
			if (!qfsLyjdmcZwvIKgTdfBWbFYINZEs(true, true))
			{
				return false;
			}
			_controller.Register(this);
			return true;
		}

		internal virtual void uhEFXpfuSMWRlvfmhKQBEnwDmHLy()
		{
			ClearValue();
			if (!_controller.IsNullOrDestroyed())
			{
				_controller.Deregister(this);
			}
			KhQueZDBBtkbvKkxubYmYxeSHJrfA();
			juAmOHdlEuZcdEbopfsigKMAJgtHb = false;
		}

		internal virtual void pmxmOeyRAlBoCxmllQyaxtECbvcr()
		{
			if (!_controller.IsNullOrDestroyed())
			{
				KhQueZDBBtkbvKkxubYmYxeSHJrfA();
			}
		}

		internal virtual void KhQueZDBBtkbvKkxubYmYxeSHJrfA()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void CbvCdtcgkXIqLYOKEKJdhBmfrjFcB()
		{
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				fLESigLZMfTrdvEIqdmveetSjBkA();
			}
		}

		internal virtual void wfYqWOGHtnIUbtMhSNJLmUHIcfqd()
		{
			_ = juAmOHdlEuZcdEbopfsigKMAJgtHb;
		}

		internal virtual void LLzALYpKRiDYsyFTIBJvkresqDwWA()
		{
		}

		internal bool BmJxkhIhAZjPFwDWRTfFEWoVOzdM()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool WxjgszJOjbxlRCNUKYbaHdWiodnx()
		{
			return this == null;
		}

		internal IComponentController jEXzKujpjLIhjTJCTTXuiKAPfKVb()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		private IEnumerator kQUIFOCdkeyHwGfhjtxnuJIuWHOQ()
		{
			return new OkrcUkwYxNquQmBxYxxxsDJlAsXo(0)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this
			};
		}

		private void zBFbVgFivIFkRriBBSLwgWJemDVY()
		{
			if (qrhyEDreMhRqasASvGWwEiXwPpSPA())
			{
				LLzALYpKRiDYsyFTIBJvkresqDwWA();
				juAmOHdlEuZcdEbopfsigKMAJgtHb = true;
				pmxmOeyRAlBoCxmllQyaxtECbvcr();
			}
		}

		private bool qfsLyjdmcZwvIKgTdfBWbFYINZEs(bool P_0, bool P_1)
		{
			bool flag = false;
			try
			{
				IComponentController componentController = FindController();
				if (!_controller.IsNullOrDestroyed() && _controller != componentController)
				{
					flag = true;
				}
				_controller = componentController;
				if (_controller == null)
				{
					Type type = GetRequiredControllerType();
					if ((object)type == null)
					{
						type = typeof(IComponentController);
					}
					if (P_1)
					{
						Logger.LogError(type.Name + " could not be found. You must have a component that extends from " + type.Name + " on this or a parent GameObject.");
					}
					throw new Exception();
				}
				if (!P_0 && flag)
				{
					zBFbVgFivIFkRriBBSLwgWJemDVY();
				}
				return true;
			}
			catch
			{
				uhEFXpfuSMWRlvfmhKQBEnwDmHLy();
				return false;
			}
		}

		private void fLESigLZMfTrdvEIqdmveetSjBkA()
		{
			qfsLyjdmcZwvIKgTdfBWbFYINZEs(false, true);
		}

		private void vEXOvbTaIIFRHIZgpBymQtpGpuYE()
		{
			if (!WxjgszJOjbxlRCNUKYbaHdWiodnx() && BmJxkhIhAZjPFwDWRTfFEWoVOzdM())
			{
				IghfPvNUXsucbZILFgzLRWwwGmUeA();
			}
		}
	}
}

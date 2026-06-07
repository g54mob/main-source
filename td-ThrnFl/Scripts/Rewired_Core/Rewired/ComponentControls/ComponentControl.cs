using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentControl : MonoBehaviour, IComponentControl
	{
		private sealed class NKxJdkdzTfadJfkXbeBpiyRunbHEA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int ZjtrtzYdHpxNkXovhxExAbFMHxBj;

			private object yXCfTIJslZgyTwcUfJYwhegPxpeE;

			public ComponentControl bMvuXYLhlJsPTEjIlGFaBjKRzpRvA;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return yXCfTIJslZgyTwcUfJYwhegPxpeE;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return yXCfTIJslZgyTwcUfJYwhegPxpeE;
				}
			}

			[DebuggerHidden]
			public NKxJdkdzTfadJfkXbeBpiyRunbHEA(int P_0)
			{
				ZjtrtzYdHpxNkXovhxExAbFMHxBj = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int zjtrtzYdHpxNkXovhxExAbFMHxBj = ZjtrtzYdHpxNkXovhxExAbFMHxBj;
				ComponentControl componentControl = bMvuXYLhlJsPTEjIlGFaBjKRzpRvA;
				switch (zjtrtzYdHpxNkXovhxExAbFMHxBj)
				{
				default:
					return false;
				case 0:
					ZjtrtzYdHpxNkXovhxExAbFMHxBj = -1;
					yXCfTIJslZgyTwcUfJYwhegPxpeE = null;
					ZjtrtzYdHpxNkXovhxExAbFMHxBj = 1;
					return true;
				case 1:
					ZjtrtzYdHpxNkXovhxExAbFMHxBj = -1;
					if (!componentControl.kxzKiGOSSGHSvNhOTCCxvpjgSZtV())
					{
						return false;
					}
					componentControl.OnEnable();
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
		private bool cdDAQkeWJpYSOBABixYnsTtUKQweb;

		[NonSerialized]
		private bool DZmQxkYTniRpMsKYzhdgcJVLcxxX;

		private int _lastUpdateFrame = -1;

		internal abstract bool OPBVHezjFVpJBDXXXJwLabYlHTYR { get; }

		internal bool JwovWyXnUHPSJEoogdblYDhMeVmfA => cdDAQkeWJpYSOBABixYnsTtUKQweb;

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
				qnLhJkUiUIykMbMYQAAaROlmDNjm();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			DZmQxkYTniRpMsKYzhdgcJVLcxxX = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!DZmQxkYTniRpMsKYzhdgcJVLcxxX)
			{
				cdDAQkeWJpYSOBABixYnsTtUKQweb = false;
				StartCoroutine(uTIIjFscsJiaviPGVuLhsoaptCNb());
				DZmQxkYTniRpMsKYzhdgcJVLcxxX = true;
			}
			else if (Application.isPlaying)
			{
				ezprqYphKjjUJdSBFLaeNxYViQeiA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (Application.isPlaying)
			{
				VHelwwdTmpLozrANhBGUgBmiPlbg();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (cdDAQkeWJpYSOBABixYnsTtUKQweb)
			{
				vpyLAfVqbRhWBuNvQzvdMDlVimfq();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (cdDAQkeWJpYSOBABixYnsTtUKQweb)
			{
				FAyrKhzfBFhPhBJXKhsYuVEnYcvh(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (cdDAQkeWJpYSOBABixYnsTtUKQweb)
			{
				FAyrKhzfBFhPhBJXKhsYuVEnYcvh(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			_ = cdDAQkeWJpYSOBABixYnsTtUKQweb;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			_ = cdDAQkeWJpYSOBABixYnsTtUKQweb;
		}

		internal virtual void qnLhJkUiUIykMbMYQAAaROlmDNjm()
		{
		}

		internal virtual bool FwgDUBYWZVAxBlviSDOiGLrhpKDhb()
		{
			cdDAQkeWJpYSOBABixYnsTtUKQweb = false;
			if (!FAyrKhzfBFhPhBJXKhsYuVEnYcvh(true, true))
			{
				return false;
			}
			_controller.Register(this);
			return true;
		}

		internal virtual void VHelwwdTmpLozrANhBGUgBmiPlbg()
		{
			ClearValue();
			if (!_controller.IsNullOrDestroyed())
			{
				_controller.Deregister(this);
			}
			KGwGMnCEMITMZwqyMMLmHNafbmhAc();
			cdDAQkeWJpYSOBABixYnsTtUKQweb = false;
		}

		internal virtual void yMFFBQAzgLfmUacPqgBfPeOEneEtA()
		{
			if (!_controller.IsNullOrDestroyed())
			{
				KGwGMnCEMITMZwqyMMLmHNafbmhAc();
			}
		}

		internal virtual void KGwGMnCEMITMZwqyMMLmHNafbmhAc()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void dGrkdAigHPtPsfObCbIMleiXpdpl()
		{
			if (cdDAQkeWJpYSOBABixYnsTtUKQweb)
			{
				vpyLAfVqbRhWBuNvQzvdMDlVimfq();
			}
		}

		internal virtual void GIsfEluetqtLurkiIFZQxQLPGRycA()
		{
			_ = cdDAQkeWJpYSOBABixYnsTtUKQweb;
		}

		internal virtual void MjIDXYWmitHbBFyYFyYFABOuxGYqA()
		{
		}

		internal bool kxzKiGOSSGHSvNhOTCCxvpjgSZtV()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool ZnXagxitKQCMwbkcjJHaQZKYHTZMb()
		{
			return this == null;
		}

		internal IComponentController BqDzxgPEIVLpZbYXMXRjqpdlsvAF()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		[IteratorStateMachine(typeof(NKxJdkdzTfadJfkXbeBpiyRunbHEA))]
		private IEnumerator uTIIjFscsJiaviPGVuLhsoaptCNb()
		{
			return new NKxJdkdzTfadJfkXbeBpiyRunbHEA(0)
			{
				bMvuXYLhlJsPTEjIlGFaBjKRzpRvA = this
			};
		}

		private void ezprqYphKjjUJdSBFLaeNxYViQeiA()
		{
			if (FwgDUBYWZVAxBlviSDOiGLrhpKDhb())
			{
				MjIDXYWmitHbBFyYFyYFABOuxGYqA();
				cdDAQkeWJpYSOBABixYnsTtUKQweb = true;
				yMFFBQAzgLfmUacPqgBfPeOEneEtA();
			}
		}

		private bool FAyrKhzfBFhPhBJXKhsYuVEnYcvh(bool P_0, bool P_1)
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
					if (type == null)
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
					ezprqYphKjjUJdSBFLaeNxYViQeiA();
				}
				return true;
			}
			catch
			{
				VHelwwdTmpLozrANhBGUgBmiPlbg();
				return false;
			}
		}

		private void vpyLAfVqbRhWBuNvQzvdMDlVimfq()
		{
			FAyrKhzfBFhPhBJXKhsYuVEnYcvh(false, true);
		}

		private void vlbstAyjTGBHtdYPgivocHFgVQUC()
		{
			if (!ZnXagxitKQCMwbkcjJHaQZKYHTZMb() && kxzKiGOSSGHSvNhOTCCxvpjgSZtV())
			{
				qnLhJkUiUIykMbMYQAAaROlmDNjm();
			}
		}
	}
}

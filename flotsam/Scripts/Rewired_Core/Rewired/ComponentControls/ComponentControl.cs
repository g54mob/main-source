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
		private sealed class ikJFMWpIOzhmOCUGLEhOjcoAIxASb : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int qGPMqTMIaxyStejDHLAAWCocJvGg;

			private object PYaSegTtyHxSMJWrBxgVjBZhFhrr;

			public ComponentControl UqNYiiTVoLBIGboFNvfJtKfjJpCr;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return PYaSegTtyHxSMJWrBxgVjBZhFhrr;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return PYaSegTtyHxSMJWrBxgVjBZhFhrr;
				}
			}

			[DebuggerHidden]
			public ikJFMWpIOzhmOCUGLEhOjcoAIxASb(int P_0)
			{
				qGPMqTMIaxyStejDHLAAWCocJvGg = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				qGPMqTMIaxyStejDHLAAWCocJvGg = -2;
			}

			private bool MoveNext()
			{
				int num = qGPMqTMIaxyStejDHLAAWCocJvGg;
				ComponentControl uqNYiiTVoLBIGboFNvfJtKfjJpCr = UqNYiiTVoLBIGboFNvfJtKfjJpCr;
				switch (num)
				{
				default:
					return false;
				case 0:
					qGPMqTMIaxyStejDHLAAWCocJvGg = -1;
					PYaSegTtyHxSMJWrBxgVjBZhFhrr = null;
					qGPMqTMIaxyStejDHLAAWCocJvGg = 1;
					return true;
				case 1:
					qGPMqTMIaxyStejDHLAAWCocJvGg = -1;
					if (!uqNYiiTVoLBIGboFNvfJtKfjJpCr.NxZqTcOaFYxDkedTdVaCjfSAMJmR())
					{
						return false;
					}
					uqNYiiTVoLBIGboFNvfJtKfjJpCr.OnEnable();
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
		private bool XSfSfUKAMfrNDjmYExmYBqKyhWjz;

		[NonSerialized]
		private bool aVIlMOQkqkbgDDELNdRFEkkpKfchA;

		private int _lastUpdateFrame = -1;

		internal abstract bool lgrxeUlsSPQSCicUhAbuoUnLaBDCA { get; }

		internal bool mGSVjCDCJJtDWhXvCjLMSqYiVZpn => XSfSfUKAMfrNDjmYExmYBqKyhWjz;

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
				ZCxYpOKPlUdrVINhgqDHNCUEVWof();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			aVIlMOQkqkbgDDELNdRFEkkpKfchA = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!aVIlMOQkqkbgDDELNdRFEkkpKfchA)
			{
				XSfSfUKAMfrNDjmYExmYBqKyhWjz = false;
				StartCoroutine(TcxfVMarHlfhERUzICgbiJHlpHhA());
				aVIlMOQkqkbgDDELNdRFEkkpKfchA = true;
			}
			else if (Application.isPlaying)
			{
				TvXMRohNPhPXSpUCjCOLlfszOVfC();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (Application.isPlaying)
			{
				cIOELEdvxnSCyKfHNjrpgKRUrLuN();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (XSfSfUKAMfrNDjmYExmYBqKyhWjz)
			{
				MAKSbVBMyNaNUhPosZHGhYKtjqiVA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (XSfSfUKAMfrNDjmYExmYBqKyhWjz)
			{
				kNSEVLfSyFmDysCneBKbcxNLUiSc(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (XSfSfUKAMfrNDjmYExmYBqKyhWjz)
			{
				kNSEVLfSyFmDysCneBKbcxNLUiSc(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			_ = XSfSfUKAMfrNDjmYExmYBqKyhWjz;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			_ = XSfSfUKAMfrNDjmYExmYBqKyhWjz;
		}

		internal virtual void ZCxYpOKPlUdrVINhgqDHNCUEVWof()
		{
		}

		internal virtual bool mHOefbJCUXqkQiKpeekFQZKFzWONA()
		{
			XSfSfUKAMfrNDjmYExmYBqKyhWjz = false;
			if (!kNSEVLfSyFmDysCneBKbcxNLUiSc(true, true))
			{
				return false;
			}
			_controller.Register(this);
			return true;
		}

		internal virtual void cIOELEdvxnSCyKfHNjrpgKRUrLuN()
		{
			ClearValue();
			if (!_controller.IsNullOrDestroyed())
			{
				_controller.Deregister(this);
			}
			xrUDlDfYTKrFCEXzaElDtJTTsamLA();
			XSfSfUKAMfrNDjmYExmYBqKyhWjz = false;
		}

		internal virtual void DMbaaaKznZLdNtHCSKxCxkjgxkVZ()
		{
			if (!_controller.IsNullOrDestroyed())
			{
				xrUDlDfYTKrFCEXzaElDtJTTsamLA();
			}
		}

		internal virtual void xrUDlDfYTKrFCEXzaElDtJTTsamLA()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void KgLXihurbPinOWJqLZtFhFebpoIB()
		{
			if (XSfSfUKAMfrNDjmYExmYBqKyhWjz)
			{
				MAKSbVBMyNaNUhPosZHGhYKtjqiVA();
			}
		}

		internal virtual void jLSKtHkuianWhYafcwdbvietoPrW()
		{
			_ = XSfSfUKAMfrNDjmYExmYBqKyhWjz;
		}

		internal virtual void zJkGwshYbhWqYUTRreweBVxFKGVVB()
		{
		}

		internal bool NxZqTcOaFYxDkedTdVaCjfSAMJmR()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool sqlETDdrPWvXdhJlnKjPsHvhhNAuA()
		{
			return this == null;
		}

		internal IComponentController wabUkEZZZJIoUMDQmjwMkPKXcLHJ()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		[IteratorStateMachine(typeof(ikJFMWpIOzhmOCUGLEhOjcoAIxASb))]
		private IEnumerator TcxfVMarHlfhERUzICgbiJHlpHhA()
		{
			return new ikJFMWpIOzhmOCUGLEhOjcoAIxASb(0)
			{
				UqNYiiTVoLBIGboFNvfJtKfjJpCr = this
			};
		}

		private void TvXMRohNPhPXSpUCjCOLlfszOVfC()
		{
			if (mHOefbJCUXqkQiKpeekFQZKFzWONA())
			{
				zJkGwshYbhWqYUTRreweBVxFKGVVB();
				XSfSfUKAMfrNDjmYExmYBqKyhWjz = true;
				DMbaaaKznZLdNtHCSKxCxkjgxkVZ();
			}
		}

		private bool kNSEVLfSyFmDysCneBKbcxNLUiSc(bool P_0, bool P_1)
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
					TvXMRohNPhPXSpUCjCOLlfszOVfC();
				}
				return true;
			}
			catch
			{
				cIOELEdvxnSCyKfHNjrpgKRUrLuN();
				return false;
			}
		}

		private void MAKSbVBMyNaNUhPosZHGhYKtjqiVA()
		{
			kNSEVLfSyFmDysCneBKbcxNLUiSc(false, true);
		}

		private void YXFLvawaXSWUiKZWWEHkemdYBDQc()
		{
			if (!sqlETDdrPWvXdhJlnKjPsHvhhNAuA() && NxZqTcOaFYxDkedTdVaCjfSAMJmR())
			{
				ZCxYpOKPlUdrVINhgqDHNCUEVWof();
			}
		}
	}
}

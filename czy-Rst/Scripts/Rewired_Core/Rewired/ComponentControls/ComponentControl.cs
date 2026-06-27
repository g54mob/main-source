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
		private sealed class fTsGTRstTzMjveRIiOPGHyzhJVpI : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int zyaFYYCDRvnOWBKfHegSwpbqZxlSB;

			private object UJHJWnCLnZJHtbfzusWJEOOAsDMW;

			public ComponentControl XulahMOlRUmlpNNqvGLdCiQOLjjb;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return UJHJWnCLnZJHtbfzusWJEOOAsDMW;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UJHJWnCLnZJHtbfzusWJEOOAsDMW;
				}
			}

			[DebuggerHidden]
			public fTsGTRstTzMjveRIiOPGHyzhJVpI(int P_0)
			{
				zyaFYYCDRvnOWBKfHegSwpbqZxlSB = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = zyaFYYCDRvnOWBKfHegSwpbqZxlSB;
				ComponentControl xulahMOlRUmlpNNqvGLdCiQOLjjb = XulahMOlRUmlpNNqvGLdCiQOLjjb;
				switch (num)
				{
				default:
					return false;
				case 0:
					zyaFYYCDRvnOWBKfHegSwpbqZxlSB = -1;
					UJHJWnCLnZJHtbfzusWJEOOAsDMW = null;
					zyaFYYCDRvnOWBKfHegSwpbqZxlSB = 1;
					return true;
				case 1:
					zyaFYYCDRvnOWBKfHegSwpbqZxlSB = -1;
					if (!xulahMOlRUmlpNNqvGLdCiQOLjjb.GlaXMdVzEWtLRKxLWJPCCCZtpeXE())
					{
						return false;
					}
					xulahMOlRUmlpNNqvGLdCiQOLjjb.OnEnable();
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
		private bool GpWdgNRXIdbjmNGIvLIAaaTTwtAH;

		[NonSerialized]
		private bool hNhdQVDdtwLOqbQRiraFVmfAzFJn;

		private int _lastUpdateFrame = -1;

		internal abstract bool sBSyLdyBEZqxqMQAUOeeTuCypwge { get; }

		internal bool fcnhgNSGjBrchLlUpyTOdBRVbCMd => GpWdgNRXIdbjmNGIvLIAaaTTwtAH;

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
				QcGIWLDDCIjLkBgZbJZNrqDVlpFrb();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			hNhdQVDdtwLOqbQRiraFVmfAzFJn = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!hNhdQVDdtwLOqbQRiraFVmfAzFJn)
			{
				GpWdgNRXIdbjmNGIvLIAaaTTwtAH = false;
				StartCoroutine(CjFznEfamNpTIjzEKhtoNHGgaVup());
				hNhdQVDdtwLOqbQRiraFVmfAzFJn = true;
			}
			else if (Application.isPlaying)
			{
				InsbVluFEbNxhJVCCmlZEeaQSuMu();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (Application.isPlaying)
			{
				pabkOBaqynfkFqgRuwUhJaWhDlVhA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (GpWdgNRXIdbjmNGIvLIAaaTTwtAH)
			{
				LEtdPOYzlLznnvgcFyMMrRZAEAXF();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (GpWdgNRXIdbjmNGIvLIAaaTTwtAH)
			{
				vVheEIAkJBJQZxGWNmqzFNkmTmJiA(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (GpWdgNRXIdbjmNGIvLIAaaTTwtAH)
			{
				vVheEIAkJBJQZxGWNmqzFNkmTmJiA(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			_ = GpWdgNRXIdbjmNGIvLIAaaTTwtAH;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			_ = GpWdgNRXIdbjmNGIvLIAaaTTwtAH;
		}

		internal virtual void QcGIWLDDCIjLkBgZbJZNrqDVlpFrb()
		{
		}

		internal virtual bool hAzjIoLkVRUAzeftDHXXgALoBupgA()
		{
			GpWdgNRXIdbjmNGIvLIAaaTTwtAH = false;
			if (!vVheEIAkJBJQZxGWNmqzFNkmTmJiA(true, true))
			{
				return false;
			}
			_controller.Register(this);
			return true;
		}

		internal virtual void pabkOBaqynfkFqgRuwUhJaWhDlVhA()
		{
			ClearValue();
			if (!_controller.IsNullOrDestroyed())
			{
				_controller.Deregister(this);
			}
			oSbbeYZAlAddfrbvTGLFoGMuOsPK();
			GpWdgNRXIdbjmNGIvLIAaaTTwtAH = false;
		}

		internal virtual void USEuUjubaDLUifCGdCzGVsQJWggG()
		{
			if (!_controller.IsNullOrDestroyed())
			{
				oSbbeYZAlAddfrbvTGLFoGMuOsPK();
			}
		}

		internal virtual void oSbbeYZAlAddfrbvTGLFoGMuOsPK()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void HAozJjtCaBQEIiVJLswvClYOjXTs()
		{
			if (GpWdgNRXIdbjmNGIvLIAaaTTwtAH)
			{
				LEtdPOYzlLznnvgcFyMMrRZAEAXF();
			}
		}

		internal virtual void uqpvXSxBdciqAsrvTMJdOHfWenSP()
		{
			_ = GpWdgNRXIdbjmNGIvLIAaaTTwtAH;
		}

		internal virtual void yvFsmjTmMlGFbdTAOPvckifnkrae()
		{
		}

		internal bool GlaXMdVzEWtLRKxLWJPCCCZtpeXE()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool bsOJSOyOeEjUEpfUOQkBksJExGnD()
		{
			return this == null;
		}

		internal IComponentController jhYECROEMZNsxuaWZgOAkBVcaKmGb()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		[IteratorStateMachine(typeof(fTsGTRstTzMjveRIiOPGHyzhJVpI))]
		private IEnumerator CjFznEfamNpTIjzEKhtoNHGgaVup()
		{
			return new fTsGTRstTzMjveRIiOPGHyzhJVpI(0)
			{
				XulahMOlRUmlpNNqvGLdCiQOLjjb = this
			};
		}

		private void InsbVluFEbNxhJVCCmlZEeaQSuMu()
		{
			if (hAzjIoLkVRUAzeftDHXXgALoBupgA())
			{
				yvFsmjTmMlGFbdTAOPvckifnkrae();
				GpWdgNRXIdbjmNGIvLIAaaTTwtAH = true;
				USEuUjubaDLUifCGdCzGVsQJWggG();
			}
		}

		private bool vVheEIAkJBJQZxGWNmqzFNkmTmJiA(bool P_0, bool P_1)
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
					InsbVluFEbNxhJVCCmlZEeaQSuMu();
				}
				return true;
			}
			catch
			{
				pabkOBaqynfkFqgRuwUhJaWhDlVhA();
				return false;
			}
		}

		private void LEtdPOYzlLznnvgcFyMMrRZAEAXF()
		{
			vVheEIAkJBJQZxGWNmqzFNkmTmJiA(false, true);
		}

		private void HFaaRtJztWpwFqwVfcpLaZrdvrspA()
		{
			if (!bsOJSOyOeEjUEpfUOQkBksJExGnD() && GlaXMdVzEWtLRKxLWJPCCCZtpeXE())
			{
				QcGIWLDDCIjLkBgZbJZNrqDVlpFrb();
			}
		}
	}
}

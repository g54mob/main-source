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
		private sealed class VtAffTIidefhSjrDhthlYAQTOaso : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			public ComponentControl GxphHAMqMhNBLjnlhXuBQmXaALiE;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					WCNlIsEdYuVTqbNYvICUPcTebLU = null;
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
					return true;
				case 1:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.PmzPLRTbzhVAsZEWmVqPqmwBgpn())
					{
						GxphHAMqMhNBLjnlhXuBQmXaALiE.OnEnable();
					}
					break;
				}
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
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public VtAffTIidefhSjrDhthlYAQTOaso(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
			}
		}

		private IComponentController _controller;

		[NonSerialized]
		private bool rXobafaxvUDrItlgWahiaYSKJqn;

		[NonSerialized]
		private bool MiSexzdwxtpRdMgXwPzvhUxarph;

		private int _lastUpdateFrame = -1;

		internal abstract bool hasController { get; }

		internal bool initialized => rXobafaxvUDrItlgWahiaYSKJqn;

		[CustomObfuscation(rename = false)]
		internal ComponentControl()
		{
		}

		public abstract void ClearValue();

		private void wnYphiIcvFyMaSvLtDKrIOhabXSb()
		{
			int frameCount = Time.frameCount;
			if (_lastUpdateFrame != frameCount)
			{
				_lastUpdateFrame = frameCount;
				GoDzCZSWyCxHOoFNmmNBncoqcAY();
			}
		}

		void IComponentControl.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in wnYphiIcvFyMaSvLtDKrIOhabXSb
			this.wnYphiIcvFyMaSvLtDKrIOhabXSb();
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			MiSexzdwxtpRdMgXwPzvhUxarph = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!MiSexzdwxtpRdMgXwPzvhUxarph)
			{
				rXobafaxvUDrItlgWahiaYSKJqn = false;
				StartCoroutine(cgypWwRfPIGlDhBxGCizKMSkBRE());
				MiSexzdwxtpRdMgXwPzvhUxarph = true;
			}
			else if (Application.isPlaying)
			{
				zptlECrQiHzwILTuMWcaXVcgZFC();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (Application.isPlaying)
			{
				spudbBcbrcjDQUMsSHQPchiNiLD();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (rXobafaxvUDrItlgWahiaYSKJqn)
			{
				lobXwMhkakKXYKYMfyRgSFyhrnN();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (rXobafaxvUDrItlgWahiaYSKJqn)
			{
				ySGbUXigXhFdnDfVWvGYTHMGUTCK(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (rXobafaxvUDrItlgWahiaYSKJqn)
			{
				ySGbUXigXhFdnDfVWvGYTHMGUTCK(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			_ = rXobafaxvUDrItlgWahiaYSKJqn;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			_ = rXobafaxvUDrItlgWahiaYSKJqn;
		}

		internal virtual void GoDzCZSWyCxHOoFNmmNBncoqcAY()
		{
		}

		internal virtual bool yTsKtkkrFvbLTmEALJcKJZadFG()
		{
			rXobafaxvUDrItlgWahiaYSKJqn = false;
			if (!ySGbUXigXhFdnDfVWvGYTHMGUTCK(true, true))
			{
				return false;
			}
			_controller.Register(this);
			return true;
		}

		internal virtual void spudbBcbrcjDQUMsSHQPchiNiLD()
		{
			ClearValue();
			if (!_controller.IsNullOrDestroyed())
			{
				_controller.Deregister(this);
			}
			EryQQjAUaPnoItWfLGLmyUsSpHl();
			rXobafaxvUDrItlgWahiaYSKJqn = false;
		}

		internal virtual void dJZdkEnsfJibdbIbYyjwTTIGMtqV()
		{
			if (!_controller.IsNullOrDestroyed())
			{
				EryQQjAUaPnoItWfLGLmyUsSpHl();
			}
		}

		internal virtual void EryQQjAUaPnoItWfLGLmyUsSpHl()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void MxNDYRdNWvbuwnEvdAejdyZphUD()
		{
			if (rXobafaxvUDrItlgWahiaYSKJqn)
			{
				lobXwMhkakKXYKYMfyRgSFyhrnN();
			}
		}

		internal virtual void qBJzEuLceLbZngSExWQZwAUKrscK()
		{
			_ = rXobafaxvUDrItlgWahiaYSKJqn;
		}

		internal virtual void RDNrpouRiMCNDFrHrSWdTBgqpLi()
		{
		}

		internal bool PmzPLRTbzhVAsZEWmVqPqmwBgpn()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool QzVIzNUjATmewxkIfyKqlEEwknb()
		{
			return this == null;
		}

		internal IComponentController hZevHcoOYBFDWiLDwrMDSkKLprQ()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		private IEnumerator cgypWwRfPIGlDhBxGCizKMSkBRE()
		{
			VtAffTIidefhSjrDhthlYAQTOaso vtAffTIidefhSjrDhthlYAQTOaso = new VtAffTIidefhSjrDhthlYAQTOaso(0);
			vtAffTIidefhSjrDhthlYAQTOaso.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			return vtAffTIidefhSjrDhthlYAQTOaso;
		}

		private void zptlECrQiHzwILTuMWcaXVcgZFC()
		{
			if (yTsKtkkrFvbLTmEALJcKJZadFG())
			{
				RDNrpouRiMCNDFrHrSWdTBgqpLi();
				rXobafaxvUDrItlgWahiaYSKJqn = true;
				dJZdkEnsfJibdbIbYyjwTTIGMtqV();
			}
		}

		private bool ySGbUXigXhFdnDfVWvGYTHMGUTCK(bool P_0, bool P_1)
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
					zptlECrQiHzwILTuMWcaXVcgZFC();
				}
				return true;
			}
			catch
			{
				spudbBcbrcjDQUMsSHQPchiNiLD();
				return false;
			}
		}

		private void lobXwMhkakKXYKYMfyRgSFyhrnN()
		{
			ySGbUXigXhFdnDfVWvGYTHMGUTCK(false, true);
		}

		private void vttNuRQivaGIubowAbSqJuvGozKm()
		{
			if (!QzVIzNUjATmewxkIfyKqlEEwknb() && PmzPLRTbzhVAsZEWmVqPqmwBgpn())
			{
				GoDzCZSWyCxHOoFNmmNBncoqcAY();
			}
		}
	}
}

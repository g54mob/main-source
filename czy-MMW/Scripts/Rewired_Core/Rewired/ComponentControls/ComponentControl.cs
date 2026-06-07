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
		private sealed class wwMJtqiVfaKHjejVuUciRgDCDrpp : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int gXUEZhNTHiNMOABksroihyHmUDdr;

			private object JNrbPIgOtYsBbRlgogYzICmhkrMwA;

			public ComponentControl YYSzXKIezQhylZfUmUCtMJYlAxlhA;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return JNrbPIgOtYsBbRlgogYzICmhkrMwA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JNrbPIgOtYsBbRlgogYzICmhkrMwA;
				}
			}

			[DebuggerHidden]
			public wwMJtqiVfaKHjejVuUciRgDCDrpp(int P_0)
			{
				gXUEZhNTHiNMOABksroihyHmUDdr = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = gXUEZhNTHiNMOABksroihyHmUDdr;
				ComponentControl yYSzXKIezQhylZfUmUCtMJYlAxlhA = YYSzXKIezQhylZfUmUCtMJYlAxlhA;
				switch (num)
				{
				default:
					return false;
				case 0:
					gXUEZhNTHiNMOABksroihyHmUDdr = -1;
					JNrbPIgOtYsBbRlgogYzICmhkrMwA = null;
					gXUEZhNTHiNMOABksroihyHmUDdr = 1;
					return true;
				case 1:
					gXUEZhNTHiNMOABksroihyHmUDdr = -1;
					if (!yYSzXKIezQhylZfUmUCtMJYlAxlhA.DfQIcSJUPXlHPQKgUHsgOrKCBhBG())
					{
						return false;
					}
					yYSzXKIezQhylZfUmUCtMJYlAxlhA.OnEnable();
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
		private bool JPgySsBfXsjjoVgZlHTysdtiBIQv;

		[NonSerialized]
		private bool agBXuPJdFtYcbnWDmiGzVPqtxDVE;

		private int _lastUpdateFrame = -1;

		internal abstract bool tCmDnaqSHMayjAbLSbCCIFMNrLegA { get; }

		internal bool ufLiLiMyYKjqbRkyhyTivexwTJMJ => JPgySsBfXsjjoVgZlHTysdtiBIQv;

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
				HDehBiVJQHtZseCWJjHvsFnOvLVX();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			agBXuPJdFtYcbnWDmiGzVPqtxDVE = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!agBXuPJdFtYcbnWDmiGzVPqtxDVE)
			{
				JPgySsBfXsjjoVgZlHTysdtiBIQv = false;
				StartCoroutine(FJflalzYiStBGrJZAlvGNmeBuhyQ());
				agBXuPJdFtYcbnWDmiGzVPqtxDVE = true;
			}
			else if (Application.isPlaying)
			{
				ZgWEMbaODyzFrFTbAbPhASdhKnYD();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (Application.isPlaying)
			{
				oxPAXgGwqmUeHrkKsdKLaNagKLVZB();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (JPgySsBfXsjjoVgZlHTysdtiBIQv)
			{
				SXZmjmKxFOphNzbFZccuhhlxmcXe();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (JPgySsBfXsjjoVgZlHTysdtiBIQv)
			{
				qRRDHvwpJSDWLWlLHawDDLMPZWVR(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (JPgySsBfXsjjoVgZlHTysdtiBIQv)
			{
				qRRDHvwpJSDWLWlLHawDDLMPZWVR(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			_ = JPgySsBfXsjjoVgZlHTysdtiBIQv;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			_ = JPgySsBfXsjjoVgZlHTysdtiBIQv;
		}

		internal virtual void HDehBiVJQHtZseCWJjHvsFnOvLVX()
		{
		}

		internal virtual bool gFHceRVuTSMIduHiFFMdoyvBSShL()
		{
			JPgySsBfXsjjoVgZlHTysdtiBIQv = false;
			if (!qRRDHvwpJSDWLWlLHawDDLMPZWVR(true, true))
			{
				return false;
			}
			_controller.Register(this);
			return true;
		}

		internal virtual void oxPAXgGwqmUeHrkKsdKLaNagKLVZB()
		{
			ClearValue();
			if (!_controller.IsNullOrDestroyed())
			{
				_controller.Deregister(this);
			}
			lOVmbxHnQRpetlnyVYvfclmLyjPj();
			JPgySsBfXsjjoVgZlHTysdtiBIQv = false;
		}

		internal virtual void HxsvWAoeiQDIunyZnWagHUOesAck()
		{
			if (!_controller.IsNullOrDestroyed())
			{
				lOVmbxHnQRpetlnyVYvfclmLyjPj();
			}
		}

		internal virtual void lOVmbxHnQRpetlnyVYvfclmLyjPj()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void GVYKMShboUeUKeoSXOyDKQsdAjHGb()
		{
			if (JPgySsBfXsjjoVgZlHTysdtiBIQv)
			{
				SXZmjmKxFOphNzbFZccuhhlxmcXe();
			}
		}

		internal virtual void pUDwhrfBtvoGUyjyVCwDYOFnTkUL()
		{
			_ = JPgySsBfXsjjoVgZlHTysdtiBIQv;
		}

		internal virtual void zufrCMNxgeKWhzoQOBSWuDAOKOwh()
		{
		}

		internal bool DfQIcSJUPXlHPQKgUHsgOrKCBhBG()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool eywMHvkOQBdkUpnmGAezmRMzPllH()
		{
			return this == null;
		}

		internal IComponentController mfofVmiWYOAkxIwVFRGmjFvZZyueB()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		[IteratorStateMachine(typeof(wwMJtqiVfaKHjejVuUciRgDCDrpp))]
		private IEnumerator FJflalzYiStBGrJZAlvGNmeBuhyQ()
		{
			return new wwMJtqiVfaKHjejVuUciRgDCDrpp(0)
			{
				YYSzXKIezQhylZfUmUCtMJYlAxlhA = this
			};
		}

		private void ZgWEMbaODyzFrFTbAbPhASdhKnYD()
		{
			if (gFHceRVuTSMIduHiFFMdoyvBSShL())
			{
				zufrCMNxgeKWhzoQOBSWuDAOKOwh();
				JPgySsBfXsjjoVgZlHTysdtiBIQv = true;
				HxsvWAoeiQDIunyZnWagHUOesAck();
			}
		}

		private bool qRRDHvwpJSDWLWlLHawDDLMPZWVR(bool P_0, bool P_1)
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
					ZgWEMbaODyzFrFTbAbPhASdhKnYD();
				}
				return true;
			}
			catch
			{
				oxPAXgGwqmUeHrkKsdKLaNagKLVZB();
				return false;
			}
		}

		private void SXZmjmKxFOphNzbFZccuhhlxmcXe()
		{
			qRRDHvwpJSDWLWlLHawDDLMPZWVR(false, true);
		}

		private void SBOKCYrpdBdaZiICddlnFSFWUHoP()
		{
			if (!eywMHvkOQBdkUpnmGAezmRMzPllH() && DfQIcSJUPXlHPQKgUHsgOrKCBhBG())
			{
				HDehBiVJQHtZseCWJjHvsFnOvLVX();
			}
		}
	}
}

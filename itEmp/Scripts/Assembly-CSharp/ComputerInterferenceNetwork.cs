using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ComputerInterferenceNetwork : PTSMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimObject_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Transform obj;

		public Transform targetPosition;

		public bool stepAwayDevice;

		public float time;

		private Vector3 _003CstartPosition_003E5__2;

		private Quaternion _003CstartRotation_003E5__3;

		private Vector3 _003CendPosition_003E5__4;

		private Quaternion _003CendRotation_003E5__5;

		private float _003CelapsedTime_003E5__6;

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
		public _003CAnimObject_003Ed__36(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CAnimationCameraClose_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerInterferenceNetwork _003C_003E4__this;

		public bool stepAwayDevice;

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
		public _003CAnimationCameraClose_003Ed__33(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CAnimationCameraOpen_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerInterferenceNetwork _003C_003E4__this;

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
		public _003CAnimationCameraOpen_003Ed__32(int _003C_003E1__state)
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

	[Header("Components")]
	public PlayerManager playerManager;

	public NetworkCanvasButtonAction networkCanvasButtonAction;

	public ComputerNetwork computerNetwork;

	public ButtonInformationByDevice buttonInformationByDevice;

	[Header("Detection")]
	public DetectionManager detectionManager;

	[Header("Materials")]
	public Material materialSelectedPatchcord;

	public Material materialPatchcordYellow;

	public Material materialSelectedExistingPatchcord;

	public Material materialPatchcord;

	[Header("Anim")]
	public Transform ComputerObject;

	public Transform PlayerCamera;

	public Transform[] AnimPointsFirst;

	public Transform[] AnimPoints;

	[Header("Network")]
	public RectTransform CardNetworkCanvas;

	public Image CardNetworkPort;

	public Transform CardNetworkPatchcord;

	public NetworkSocketRJ[] MySockets;

	[Header("UI")]
	public RectTransform UIEQ;

	[Header("Other")]
	public bool modeActive;

	public NetworkSocketRJ SelectedSocket;

	public bool SelectedPortCard;

	public bool usingCIN;

	[Header("Audio Settings")]
	public AudioSource audioSource;

	public AudioClip clip;

	public float clipStartTime;

	public bool activeAnimation;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void CreateInteraction()
	{
	}

	private bool CanUseComputer()
	{
		return false;
	}

	private bool CanExitComputer()
	{
		return false;
	}

	private void CameraAnimation(KeyCode key, object[] param)
	{
	}

	[IteratorStateMachine(typeof(_003CAnimationCameraOpen_003Ed__32))]
	private IEnumerator AnimationCameraOpen()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAnimationCameraClose_003Ed__33))]
	private IEnumerator AnimationCameraClose(bool stepAwayDevice = false)
	{
		return null;
	}

	public void StepAwayDevice()
	{
	}

	public void SetFirstPosition(Transform obj, Transform targetPosition)
	{
	}

	[IteratorStateMachine(typeof(_003CAnimObject_003Ed__36))]
	public IEnumerator AnimObject(Transform obj, Transform targetPosition, float time, bool stepAwayDevice = false)
	{
		return null;
	}

	public void UpdateUIAndPathcord()
	{
	}

	public void SelectSocket(Transform socket)
	{
	}

	public void SelectPortCart()
	{
	}

	public void UpdateCanvasAndAction()
	{
	}
}

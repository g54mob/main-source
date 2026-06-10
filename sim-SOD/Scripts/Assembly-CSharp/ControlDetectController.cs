using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired;
using TMPro;
using UnityEngine;

public class ControlDetectController : MonoBehaviour
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CLoadMainScene_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public ControlDetectController _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[Header("Components")]
	public TextMeshProUGUI pressAnyKeyText;

	public List<CanvasRenderer> fadeOutRenderers;

	public List<CanvasRenderer> fadeInRenderers;

	public RectTransform loadingIcon;

	public AnimationCurve loadingIconAnimCurve;

	[NonSerialized]
	public Rewired.Player player;

	[Header("Variables")]
	public bool loadSceneTriggered;

	private bool loadingScene;

	public float fadeOut;

	private static ControlDetectController _instance;

	public static ControlDetectController Instance => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	[AsyncStateMachine(typeof(_003CLoadMainScene_003Ed__15))]
	private void LoadMainScene()
	{
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-content-fitter/")]
	public class ProCamera2DContentFitter : BasePC2D, ISizeOverrider
	{
		[CompilerGenerated]
		private sealed class _003CStart_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DContentFitter _003C_003E4__this;

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
			public _003CStart_003Ed__34(int _003C_003E1__state)
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
		private sealed class _003CUpdateFixedAspectRatio_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DContentFitter _003C_003E4__this;

			private bool _003CisPillarbox_003E5__2;

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
			public _003CUpdateFixedAspectRatio_003Ed__42(int _003C_003E1__state)
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

		public static string ExtensionName;

		[SerializeField]
		private ContentFitterMode _contentFitterMode;

		[SerializeField]
		private bool _useLetterOrPillarboxing;

		[SerializeField]
		private float _targetHeight;

		[SerializeField]
		private float _targetWidth;

		[Range(0.1f, 3f)]
		[SerializeField]
		private float _targetAspectRatio;

		[Range(-1f, 1f)]
		public float VerticalAlignment;

		[Range(-1f, 1f)]
		public float HorizontalAlignment;

		private float _prevTargetHeight;

		private float _prevTargetWidth;

		private float _prevTargetAspectRatio;

		private float _prevAspectRatio;

		private float _prevVerticalAlignment;

		private float _prevHorizontalAlignment;

		private bool _prevUseLetterOrPillarboxing;

		private Camera _letterPillarboxingCamera;

		private int _soOrder;

		public ContentFitterMode ContentFitterMode
		{
			get
			{
				return default(ContentFitterMode);
			}
			set
			{
			}
		}

		public bool UseLetterOrPillarboxing
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private static float ScreenAspectRatio => 0f;

		public float TargetHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TargetWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TargetAspectRatio
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int SOOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__34))]
		private IEnumerator Start()
		{
			return null;
		}

		protected override void OnDestroy()
		{
		}

		public float OverrideSize(float deltaTime, float originalSize)
		{
			return 0f;
		}

		private float GetSize(ContentFitterMode mode)
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CUpdateFixedAspectRatio_003Ed__42))]
		private IEnumerator UpdateFixedAspectRatio()
		{
			return null;
		}

		private static void UpdateCameraAlignment(Camera cam, bool isPillarbox, float targetAspectRatio, float horizontalAlignment, float verticalAlignment)
		{
		}

		private static Matrix4x4 GetScissorRect(Rect targetScissor, Matrix4x4 camProjectionMatrix)
		{
			return default(Matrix4x4);
		}

		private static void UpdateLetterPillarbox(Camera cam, bool isPillarbox, float targetAspectRatio, float horizontalAlignment, float verticalAlignment)
		{
		}

		private void ToggleLetterPillarboxing(bool value)
		{
		}

		private void CreateLetterPillarboxingCamera()
		{
		}

		private Vector3[] DrawGizmoRectangle(float x, float y, float width, float height, Color fillColor, Color borderColor)
		{
			return null;
		}
	}
}

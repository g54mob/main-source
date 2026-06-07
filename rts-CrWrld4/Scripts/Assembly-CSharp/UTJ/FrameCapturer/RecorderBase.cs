using System.Collections;
using UnityEngine;

namespace UTJ.FrameCapturer
{
	[ExecuteInEditMode]
	public abstract class RecorderBase : MonoBehaviour
	{
		public enum ResolutionUnit
		{
			Percent = 0,
			Pixels = 1
		}

		public enum FrameRateMode
		{
			Variable = 0,
			Constant = 1
		}

		public enum CaptureControl
		{
			Manual = 0,
			FrameRange = 1,
			TimeRange = 2
		}

		[SerializeField]
		protected DataPath m_outputDir;

		[SerializeField]
		protected ResolutionUnit m_resolution;

		[SerializeField]
		protected int m_resolutionPercent;

		[SerializeField]
		protected int m_resolutionWidth;

		[SerializeField]
		protected FrameRateMode m_framerateMode;

		[SerializeField]
		protected int m_targetFramerate;

		[SerializeField]
		protected bool m_fixDeltaTime;

		[SerializeField]
		protected bool m_waitDeltaTime;

		[SerializeField]
		protected int m_captureEveryNthFrame;

		[SerializeField]
		protected CaptureControl m_captureControl;

		[SerializeField]
		protected int m_startFrame;

		[SerializeField]
		protected int m_endFrame;

		[SerializeField]
		protected float m_startTime;

		[SerializeField]
		protected float m_endTime;

		[SerializeField]
		private bool m_recordOnStart;

		protected bool m_recording;

		protected bool m_aborted;

		protected int m_initialFrame;

		protected float m_initialTime;

		protected float m_initialRealTime;

		protected int m_frame;

		protected int m_recordedFrames;

		protected int m_recordedSamples;

		public DataPath outputDir
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ResolutionUnit resolutionUnit
		{
			get
			{
				return default(ResolutionUnit);
			}
			set
			{
			}
		}

		public int resolutionPercent
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int resolutionWidth
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public FrameRateMode framerateMode
		{
			get
			{
				return default(FrameRateMode);
			}
			set
			{
			}
		}

		public int targetFramerate
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool fixDeltaTime
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool waitDeltaTime
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int captureEveryNthFrame
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public CaptureControl captureControl
		{
			get
			{
				return default(CaptureControl);
			}
			set
			{
			}
		}

		public int startFrame
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int endFrame
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float startTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float endTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool isRecording
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool recordOnStart
		{
			set
			{
			}
		}

		public virtual bool BeginRecording()
		{
			return false;
		}

		public virtual void EndRecording()
		{
		}

		protected void GetCaptureResolution(ref int w, ref int h)
		{
		}

		protected IEnumerator Wait()
		{
			return null;
		}

		protected virtual void Start()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void Update()
		{
		}
	}
}

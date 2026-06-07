using System;

namespace Gh.Tk
{
	[PersistenceOptIn]
	public abstract class AlertBadgeBase : IPersistable, ILateRestoreState
	{
		[PersistenceOptIn]
		protected float _pollIntervalInSeconds;

		[PersistenceOptIn]
		private bool _wasVisible;

		[PersistenceOptIn]
		private string _alertType;

		[PersistenceOptIn]
		private string _iconId;

		private string _titleKey;

		protected string _tooltipKey;

		[PersistenceOptIn]
		private int _number;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceAllowBrokenReferenceOnLoad]
		public TooltipData _peristedTooltipData;

		private TooltipData _runtimeTooltipData;

		private bool _nudgeSuspended;

		private bool _nudgeSoundSuspended;

		protected Alert_3DUIView _visual;

		[PersistenceOptIn]
		private float _unfreezeIn;

		[PersistenceOptIn]
		protected string _eventCameraVisualId;

		private string _eventCamId;

		protected string AlertType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected string IconId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected string TitleKey
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected string TooltipKey
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected int Number
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected AlertBadgeBase()
		{
		}

		public AlertBadgeBase(string alertType, string iconId, string titleKey, string tooltipKey = null)
		{
		}

		public void SetPollInterval(float seconds)
		{
		}

		protected void InitPollInterval()
		{
		}

		private void RecreateVisual()
		{
		}

		private void UpdateTooltipObject()
		{
		}

		protected IDisposable BeginSuspendNudgeVisual()
		{
			return null;
		}

		protected IDisposable BeginSuspendNudgeSound()
		{
			return null;
		}

		protected virtual void CreateBadge()
		{
		}

		public virtual void LateRestoreState(IDataStore data)
		{
		}

		protected void Freeze(float seconds)
		{
		}

		protected virtual void OnClick(Alert_3DUIView source)
		{
		}

		internal void DestroyBadge()
		{
		}

		public void Update()
		{
		}

		protected void CycleObjectSet(GameObjectX[] objects, Action<GameObjectX> cycleAction = null)
		{
		}

		protected abstract bool UpdateInternal();

		protected void ShowEventCamera()
		{
		}

		private void OnEventCameraClicked(object sender, EventArgs<(EventCamera camera, EventCameraSettings settings)> e)
		{
		}

		protected void HideEventCam()
		{
		}
	}
}

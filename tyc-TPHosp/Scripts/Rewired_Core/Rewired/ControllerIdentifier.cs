using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int hVLcwKGZNRwDcwqMxzBMRgucbhPa;

		private ControllerType beJOxBqDtyzXnNjzgKyRzARzFSQ;

		private Guid EAIQLWgbsQDNGcJuOWaoPBaXKTl;

		private string EwSIuwKmClNejrdvYdergFlVidpN;

		private Guid PklKNibBDUZkzudeZtiBAWsAYiS;

		public int controllerId
		{
			get
			{
				return hVLcwKGZNRwDcwqMxzBMRgucbhPa;
			}
			set
			{
				hVLcwKGZNRwDcwqMxzBMRgucbhPa = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return beJOxBqDtyzXnNjzgKyRzARzFSQ;
			}
			set
			{
				beJOxBqDtyzXnNjzgKyRzARzFSQ = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return EAIQLWgbsQDNGcJuOWaoPBaXKTl;
			}
			set
			{
				EAIQLWgbsQDNGcJuOWaoPBaXKTl = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return EwSIuwKmClNejrdvYdergFlVidpN;
			}
			set
			{
				EwSIuwKmClNejrdvYdergFlVidpN = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return PklKNibBDUZkzudeZtiBAWsAYiS;
			}
			set
			{
				PklKNibBDUZkzudeZtiBAWsAYiS = value;
			}
		}

		public static ControllerIdentifier Blank => new ControllerIdentifier
		{
			hVLcwKGZNRwDcwqMxzBMRgucbhPa = -1
		};

		internal ControllerIdentifier(Controller controller)
		{
			hVLcwKGZNRwDcwqMxzBMRgucbhPa = controller.id;
			beJOxBqDtyzXnNjzgKyRzARzFSQ = controller.type;
			EAIQLWgbsQDNGcJuOWaoPBaXKTl = controller.EAIQLWgbsQDNGcJuOWaoPBaXKTl;
			EwSIuwKmClNejrdvYdergFlVidpN = controller.hardwareIdentifier;
			PklKNibBDUZkzudeZtiBAWsAYiS = controller.deviceInstanceGuid;
		}
	}
}

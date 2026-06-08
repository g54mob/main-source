namespace Rewired.Platforms.PS4
{
	public sealed class PS4AimExtension : PS4ControllerExtension
	{
		private IPS4AimExtensionSource Source => (GetSource() as QOdDAjipcJPwgZuTsFEhhEYyIafH).QhiXIzSBnzSGaWwDVddQlyhdvkF as IPS4AimExtensionSource;

		internal PS4AimExtension(IPS4AimExtensionSource source)
			: base(source)
		{
		}

		private PS4AimExtension(PS4AimExtension source)
			: base(source)
		{
		}

		public float GetVibration(PS4AimMotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			return GetVibration(CdIbnjCGqrhYHGaOviydZjmFhOk(motor));
		}

		public void SetVibration(PS4AimMotorType motor, float motorLevel)
		{
			SetVibration(motor, motorLevel, 0f, stopOtherMotors: false);
		}

		public void SetVibration(PS4AimMotorType motor, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motor, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(PS4AimMotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					switch (0x737F8E5D ^ 0x737F8E5F)
					{
					case 0:
						continue;
					case 2:
						ReInput.CheckInitialized(_reInputId);
						return;
					}
					break;
				}
			}
			SetVibration(CdIbnjCGqrhYHGaOviydZjmFhOk(motor), motorLevel, duration, stopOtherMotors);
		}

		public void SetVibration(float strongMotorLevel, float weakMotorLevel)
		{
			SetVibration(strongMotorLevel, weakMotorLevel, 0f, 0f);
		}

		public void SetVibration(float strongMotorLevel, float weakMotorLevel, float strongMotorDuration, float weakMotorDuration)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					switch (0x56A9A99E ^ 0x56A9A99F)
					{
					case 0:
						continue;
					case 1:
						ReInput.CheckInitialized(_reInputId);
						return;
					}
					break;
				}
			}
			SetVibration(CdIbnjCGqrhYHGaOviydZjmFhOk(PS4AimMotorType.StrongMotor), strongMotorLevel, strongMotorDuration, stopOtherMotors: false);
			SetVibration(CdIbnjCGqrhYHGaOviydZjmFhOk(PS4AimMotorType.WeakMotor), weakMotorLevel, weakMotorDuration, stopOtherMotors: false);
		}

		internal override Controller.Extension EilcbgeeBHODbenDzVGhaquGLZK()
		{
			return new PS4AimExtension(this);
		}

		private static int CdIbnjCGqrhYHGaOviydZjmFhOk(PS4AimMotorType P_0)
		{
			return (int)P_0;
		}
	}
}

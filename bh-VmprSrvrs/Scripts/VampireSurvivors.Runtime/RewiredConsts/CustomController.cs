using System;

namespace RewiredConsts
{
	public static class CustomController
	{
		public static class OnScreenJoystick
		{
			public static class Axis
			{
				public const int StickX = 0;

				public const int StickY = 1;
			}

			public const int sourceId = 0;

			public const string name = "OnScreenJoystick";

			public static readonly Guid typeGuid;
		}

		public static class AutomationVirtualGamepad
		{
			public static class Axis
			{
				public const int Left_Stick_X_Axis = 0;

				public const int Left_Stick_Y_Axis = 1;
			}

			public static class Button
			{
				public const int Confirm__A_ = 2;

				public const int Cancel__B_ = 3;

				public const int Start = 4;
			}

			public const int sourceId = 1;

			public const string name = "AutomationVirtualGamepad";

			public static readonly Guid typeGuid;
		}
	}
}

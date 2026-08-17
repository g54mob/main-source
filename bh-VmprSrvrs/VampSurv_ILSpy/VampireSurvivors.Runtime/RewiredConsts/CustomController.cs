using System;

namespace RewiredConsts;

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

		unsafe static OnScreenJoystick()
		{
			//IL_006e: Expected O, but got Ref
			if ("201d37d2-846a-453f-b03a-9f5b0ec9c164" == null)
			{
				ArgumentNullException ex = new ArgumentNullException("g");
				throw ex;
			}
			object obj = default(object);
			Guid.GuidResult result = default(Guid.GuidResult);
			if (Guid.TryParseGuid((ReadOnlySpan<char>)(&obj), Guid.GuidStyles.Any, ref result))
			{
				typeGuid = (Guid)result;
				return;
			}
			Exception guidParseException = result.GetGuidParseException();
			throw guidParseException;
		}
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

		unsafe static AutomationVirtualGamepad()
		{
			//IL_006e: Expected O, but got Ref
			if ("f915a8c3-862d-4539-91ec-e7f9f20c3583" == null)
			{
				ArgumentNullException ex = new ArgumentNullException("g");
				throw ex;
			}
			object obj = default(object);
			Guid.GuidResult result = default(Guid.GuidResult);
			if (Guid.TryParseGuid((ReadOnlySpan<char>)(&obj), Guid.GuidStyles.Any, ref result))
			{
				typeGuid = (Guid)result;
				return;
			}
			Exception guidParseException = result.GetGuidParseException();
			throw guidParseException;
		}
	}
}

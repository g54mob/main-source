using System;

namespace Rewired
{
	public sealed class CustomControllerMap : ControllerMapWithAxes
	{
		private int daMfGKxhFqOdaowmOEUuPDAFZJxI;

		public int sourceControllerId
		{
			get
			{
				return daMfGKxhFqOdaowmOEUuPDAFZJxI;
			}
			set
			{
				daMfGKxhFqOdaowmOEUuPDAFZJxI = value;
			}
		}

		public CustomControllerMap()
		{
			_controllerType = ControllerType.Custom;
		}

		public CustomControllerMap(CustomControllerMap P_0)
			: base(P_0)
		{
			daMfGKxhFqOdaowmOEUuPDAFZJxI = P_0.daMfGKxhFqOdaowmOEUuPDAFZJxI;
		}

		internal void BTTeANcpZxbIKMGHTZlOfKJhVHSmA(Guid P_0, int P_1, int P_2, int P_3)
		{
			_hardwareGuid = P_0;
			daMfGKxhFqOdaowmOEUuPDAFZJxI = P_1;
			_categoryId = P_2;
			_layoutId = P_3;
		}

		internal static CustomControllerMap WzvmTWEFCkKUnRYLvufrwGixUEhp(Guid P_0, int P_1, int P_2, int P_3)
		{
			return new CustomControllerMap
			{
				_hardwareGuid = P_0,
				daMfGKxhFqOdaowmOEUuPDAFZJxI = P_1,
				_sourceMapId = -1,
				_categoryId = P_2,
				_layoutId = P_3
			};
		}
	}
}

using System;

namespace Rewired
{
	public sealed class CustomControllerMap : ControllerMapWithAxes
	{
		private int vUQgDyEUwUqMvoapqXLfhYXnTaPfA;

		public int sourceControllerId
		{
			get
			{
				return vUQgDyEUwUqMvoapqXLfhYXnTaPfA;
			}
			set
			{
				vUQgDyEUwUqMvoapqXLfhYXnTaPfA = value;
			}
		}

		public CustomControllerMap()
		{
			_controllerType = ControllerType.Custom;
		}

		public CustomControllerMap(CustomControllerMap P_0)
			: base(P_0)
		{
			vUQgDyEUwUqMvoapqXLfhYXnTaPfA = P_0.vUQgDyEUwUqMvoapqXLfhYXnTaPfA;
		}

		internal void LjeArvcYCmRMpfvMaoswgaDMorho(Guid P_0, int P_1, int P_2, int P_3)
		{
			_hardwareGuid = P_0;
			vUQgDyEUwUqMvoapqXLfhYXnTaPfA = P_1;
			_categoryId = P_2;
			_layoutId = P_3;
		}

		internal static CustomControllerMap MVHnYJGaDhkxSLeIEDskEDGaPFUOA(Guid P_0, int P_1, int P_2, int P_3)
		{
			return new CustomControllerMap
			{
				_hardwareGuid = P_0,
				vUQgDyEUwUqMvoapqXLfhYXnTaPfA = P_1,
				_sourceMapId = -1,
				_categoryId = P_2,
				_layoutId = P_3
			};
		}
	}
}

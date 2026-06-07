using System;

namespace Rewired
{
	public sealed class CustomControllerMap : ControllerMapWithAxes
	{
		private int YjGLwFPmrwSzCJzUxSuMEdnMATfaA;

		public int sourceControllerId
		{
			get
			{
				return YjGLwFPmrwSzCJzUxSuMEdnMATfaA;
			}
			set
			{
				YjGLwFPmrwSzCJzUxSuMEdnMATfaA = value;
			}
		}

		public CustomControllerMap()
		{
			_controllerType = ControllerType.Custom;
		}

		public CustomControllerMap(CustomControllerMap P_0)
			: base(P_0)
		{
			YjGLwFPmrwSzCJzUxSuMEdnMATfaA = P_0.YjGLwFPmrwSzCJzUxSuMEdnMATfaA;
		}

		internal void akFcZMRBxxMvoxUzyuXkRTwgFiAL(Guid P_0, int P_1, int P_2, int P_3)
		{
			_hardwareGuid = P_0;
			YjGLwFPmrwSzCJzUxSuMEdnMATfaA = P_1;
			_categoryId = P_2;
			_layoutId = P_3;
		}

		internal static CustomControllerMap nwnGfJyTiuAlTAipWVNZSlXoRWpgA(Guid P_0, int P_1, int P_2, int P_3)
		{
			return new CustomControllerMap
			{
				_hardwareGuid = P_0,
				YjGLwFPmrwSzCJzUxSuMEdnMATfaA = P_1,
				_sourceMapId = -1,
				_categoryId = P_2,
				_layoutId = P_3
			};
		}
	}
}

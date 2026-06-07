using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class COUAbpKeuXqLvBpbzwQGcJgjPueY
{
	private class jubmnVRtGFzYxETXFnicUBGRZat
	{
		private readonly AList<IControllerTemplate> WHeApkgLGAZTtUIEfvfXHvQYCck;

		private IList kpoyltMVuxFoUcFsnYkQhnzszbo;

		private IList RpyAKaPrIFjZzgtmwIcKPximWJq;

		public readonly Type HdaJmHCefHXcxpAZsILnwqxwADsE;

		public jubmnVRtGFzYxETXFnicUBGRZat(Type type)
		{
			HdaJmHCefHXcxpAZsILnwqxwADsE = type;
			WHeApkgLGAZTtUIEfvfXHvQYCck = new AList<IControllerTemplate>();
		}

		public IList<T> HheeqPSzhzsItAfizdvPAJfWzRo<T>() where T : IControllerTemplate
		{
			if (kpoyltMVuxFoUcFsnYkQhnzszbo == null)
			{
				AOKJTffcyjGuyfUrwflwWPzREUX<T>();
			}
			return RpyAKaPrIFjZzgtmwIcKPximWJq as IList<T>;
		}

		public void qlbbxAfDiGgDoAbvzdeYICHvGcx(IControllerTemplate P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				WHeApkgLGAZTtUIEfvfXHvQYCck.Add(P_0);
				int num = 1586303670;
				while (true)
				{
					switch (num ^ 0x5E8D12B2)
					{
					case 0:
						num = 1586303665;
						continue;
					default:
						return;
					case 3:
						break;
					case 2:
						kpoyltMVuxFoUcFsnYkQhnzszbo.Add(P_0);
						num = 1586303667;
						continue;
					case 4:
					{
						int num2;
						if (kpoyltMVuxFoUcFsnYkQhnzszbo == null)
						{
							num = 1586303667;
							num2 = num;
						}
						else
						{
							num = 1586303664;
							num2 = num;
						}
						continue;
					}
					case 1:
						return;
					}
					break;
				}
			}
		}

		public void FJHNCYGYhfbNGgXMnQKRPLpDCwz(IControllerTemplate P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				WHeApkgLGAZTtUIEfvfXHvQYCck.Remove(P_0);
				int num = -1167958166;
				while (true)
				{
					switch (num ^ -1167958167)
					{
					case 0:
						num = -1167958165;
						continue;
					default:
						return;
					case 1:
						kpoyltMVuxFoUcFsnYkQhnzszbo.Remove(P_0);
						num = -1167958163;
						continue;
					case 3:
					{
						int num2;
						if (kpoyltMVuxFoUcFsnYkQhnzszbo == null)
						{
							num = -1167958163;
							num2 = num;
						}
						else
						{
							num = -1167958168;
							num2 = num;
						}
						continue;
					}
					case 2:
						break;
					case 4:
						return;
					}
					break;
				}
			}
		}

		private void AOKJTffcyjGuyfUrwflwWPzREUX<T>() where T : IControllerTemplate
		{
			kpoyltMVuxFoUcFsnYkQhnzszbo = new AList<T>();
			int num2 = default(int);
			while (true)
			{
				int num = 2053232786;
				while (true)
				{
					switch (num ^ 0x7A61D891)
					{
					case 2:
						break;
					case 3:
						RpyAKaPrIFjZzgtmwIcKPximWJq = new ReadOnlyCollection<T>((AList<T>)kpoyltMVuxFoUcFsnYkQhnzszbo);
						num2 = 0;
						num = 2053232784;
						continue;
					case 0:
						kpoyltMVuxFoUcFsnYkQhnzszbo.Add(WHeApkgLGAZTtUIEfvfXHvQYCck._items[num2]);
						num2++;
						num = 2053232784;
						continue;
					default:
						if (num2 >= WHeApkgLGAZTtUIEfvfXHvQYCck._count)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}
	}

	private readonly AList<jubmnVRtGFzYxETXFnicUBGRZat> JZbhNpypmeAwwhiixsUFliEFruTP;

	private readonly Type[] kiEEsvRWRFfnmGTUKqUvGAitRkA;

	private readonly Type[] WijfwlKUnKyNViNnwanTzbxgadEg;

	private readonly int cyqcRschlYzFrNwxbtworXLeAyI;

	public COUAbpKeuXqLvBpbzwQGcJgjPueY(Type[] templateTypes, Type[] interfaceTypes)
	{
		int num2 = default(int);
		while (true)
		{
			int num = -631464304;
			while (true)
			{
				switch (num ^ -631464303)
				{
				case 4:
					break;
				case 1:
					if (templateTypes.Length != interfaceTypes.Length)
					{
						throw new Exception("Controller template types and controller template interface types array lengths do not match.");
					}
					goto case 5;
				case 0:
					JZbhNpypmeAwwhiixsUFliEFruTP.Add(new jubmnVRtGFzYxETXFnicUBGRZat(WijfwlKUnKyNViNnwanTzbxgadEg[num2]));
					num2++;
					num = -631464301;
					continue;
				case 3:
					num = -631464301;
					continue;
				case 5:
					kiEEsvRWRFfnmGTUKqUvGAitRkA = templateTypes;
					WijfwlKUnKyNViNnwanTzbxgadEg = interfaceTypes;
					cyqcRschlYzFrNwxbtworXLeAyI = kiEEsvRWRFfnmGTUKqUvGAitRkA.Length;
					JZbhNpypmeAwwhiixsUFliEFruTP = new AList<jubmnVRtGFzYxETXFnicUBGRZat>();
					num2 = 0;
					num = -631464302;
					continue;
				default:
					if (num2 >= cyqcRschlYzFrNwxbtworXLeAyI)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	public void DQFfftDmidgQeZhyhKnTyuCofPy(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		jubmnVRtGFzYxETXFnicUBGRZat jubmnVRtGFzYxETXFnicUBGRZat2 = default(jubmnVRtGFzYxETXFnicUBGRZat);
		Type type = default(Type);
		IControllerTemplate controllerTemplate = default(IControllerTemplate);
		while (true)
		{
			int templateCount = P_0.templateCount;
			int num = 0;
			int num2 = 135620630;
			while (true)
			{
				switch (num2 ^ 0x8156811)
				{
				case 6:
					num2 = 135620633;
					continue;
				case 2:
					num++;
					num2 = 135620630;
					continue;
				case 5:
					jubmnVRtGFzYxETXFnicUBGRZat2 = InDimEqGZnapEGxrDUZmRzQHYSY(type);
					num2 = 135620625;
					continue;
				case 8:
					break;
				case 3:
					type = rDecJjAubPQItZvsCmdttUTyxqj(controllerTemplate.GetType());
					if (type == null)
					{
						Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
						num2 = 135620627;
						continue;
					}
					goto case 5;
				case 4:
				{
					controllerTemplate = P_0.Templates[num];
					int num3;
					if (controllerTemplate == null)
					{
						num2 = 135620624;
						num3 = num2;
					}
					else
					{
						num2 = 135620626;
						num3 = num2;
					}
					continue;
				}
				case 0:
					if (jubmnVRtGFzYxETXFnicUBGRZat2 != null)
					{
						jubmnVRtGFzYxETXFnicUBGRZat2.qlbbxAfDiGgDoAbvzdeYICHvGcx(controllerTemplate);
						num2 = 135620627;
						continue;
					}
					goto case 2;
				case 1:
					Logger.LogError("Template was null.");
					num2 = 135620627;
					continue;
				default:
					if (num >= templateCount)
					{
						return;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	public void imOvIGjOATSBDNJuFHrmrpVSbPY(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		Type type = default(Type);
		IControllerTemplate controllerTemplate = default(IControllerTemplate);
		while (true)
		{
			int templateCount = P_0.templateCount;
			int num = 0;
			int num2 = -1800851154;
			while (true)
			{
				switch (num2 ^ -1800851153)
				{
				case 8:
					num2 = -1800851159;
					continue;
				case 2:
				{
					jubmnVRtGFzYxETXFnicUBGRZat jubmnVRtGFzYxETXFnicUBGRZat2 = InDimEqGZnapEGxrDUZmRzQHYSY(type);
					if (jubmnVRtGFzYxETXFnicUBGRZat2 != null)
					{
						jubmnVRtGFzYxETXFnicUBGRZat2.FJHNCYGYhfbNGgXMnQKRPLpDCwz(controllerTemplate);
						num2 = -1800851153;
						continue;
					}
					goto case 0;
				}
				case 4:
					controllerTemplate = P_0.Templates[num];
					if (controllerTemplate == null)
					{
						Logger.LogError("Template was null.");
						num2 = -1800851160;
						continue;
					}
					goto case 3;
				case 1:
					num2 = -1800851158;
					continue;
				case 6:
					break;
				case 7:
					num2 = -1800851153;
					continue;
				case 0:
					num++;
					num2 = -1800851158;
					continue;
				case 3:
					type = rDecJjAubPQItZvsCmdttUTyxqj(controllerTemplate.GetType());
					if (type == null)
					{
						Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
						num2 = -1800851153;
						continue;
					}
					goto case 2;
				default:
					if (num >= templateCount)
					{
						return;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	public IList<T> HheeqPSzhzsItAfizdvPAJfWzRo<T>() where T : IControllerTemplate
	{
		Type typeFromHandle = typeof(T);
		int num = 0;
		string text = default(string);
		int num2 = default(int);
		jubmnVRtGFzYxETXFnicUBGRZat jubmnVRtGFzYxETXFnicUBGRZat2;
		while (true)
		{
			IL_006a:
			int num3;
			if (num >= JZbhNpypmeAwwhiixsUFliEFruTP._count)
			{
				text = "";
				num2 = 0;
				num3 = -1765047603;
				goto IL_0014;
			}
			goto IL_003c;
			IL_0014:
			while (true)
			{
				switch (num3 ^ -1765047602)
				{
				case 0:
					num3 = -1765047606;
					continue;
				case 4:
					break;
				case 5:
					goto IL_006a;
				case 2:
					num2++;
					num3 = -1765047603;
					continue;
				case 1:
					text += WijfwlKUnKyNViNnwanTzbxgadEg[num2].Name;
					if (num2 != WijfwlKUnKyNViNnwanTzbxgadEg.Length - 1)
					{
						text += "\n";
						num3 = -1765047604;
						continue;
					}
					goto case 2;
				default:
					if (num2 >= WijfwlKUnKyNViNnwanTzbxgadEg.Length)
					{
						Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					goto case 1;
				}
				break;
			}
			goto IL_003c;
			IL_003c:
			jubmnVRtGFzYxETXFnicUBGRZat2 = JZbhNpypmeAwwhiixsUFliEFruTP._items[num];
			if (object.ReferenceEquals(jubmnVRtGFzYxETXFnicUBGRZat2.HdaJmHCefHXcxpAZsILnwqxwADsE, typeFromHandle))
			{
				break;
			}
			num++;
			num3 = -1765047605;
			goto IL_0014;
		}
		return jubmnVRtGFzYxETXFnicUBGRZat2.HheeqPSzhzsItAfizdvPAJfWzRo<T>();
	}

	private jubmnVRtGFzYxETXFnicUBGRZat InDimEqGZnapEGxrDUZmRzQHYSY(Type P_0)
	{
		int num = 0;
		while (true)
		{
			int num2 = 907767096;
			while (true)
			{
				switch (num2 ^ 0x361B6D39)
				{
				case 3:
					break;
				case 1:
					num2 = 907767097;
					continue;
				case 2:
					if (object.ReferenceEquals(P_0, JZbhNpypmeAwwhiixsUFliEFruTP._items[num].HdaJmHCefHXcxpAZsILnwqxwADsE))
					{
						return JZbhNpypmeAwwhiixsUFliEFruTP._items[num];
					}
					num++;
					num2 = 907767097;
					continue;
				default:
					if (num >= JZbhNpypmeAwwhiixsUFliEFruTP._count)
					{
						return null;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	private Type rDecJjAubPQItZvsCmdttUTyxqj(Type P_0)
	{
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num >= cyqcRschlYzFrNwxbtworXLeAyI)
			{
				num2 = 1082901608;
				num3 = num2;
			}
			else
			{
				num2 = 1082901610;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x408BC468)
				{
				case 3:
					num2 = 1082901610;
					continue;
				case 2:
					if (object.ReferenceEquals(kiEEsvRWRFfnmGTUKqUvGAitRkA[num], P_0))
					{
						return WijfwlKUnKyNViNnwanTzbxgadEg[num];
					}
					num++;
					num2 = 1082901609;
					continue;
				case 1:
					break;
				default:
					return null;
				}
				break;
			}
		}
	}
}

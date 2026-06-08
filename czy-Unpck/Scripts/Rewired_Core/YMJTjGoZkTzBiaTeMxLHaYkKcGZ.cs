using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class YMJTjGoZkTzBiaTeMxLHaYkKcGZ
{
	private class kKeolLJrItDCfBhkAWVJjbXTbYc
	{
		private readonly AList<IControllerTemplate> AzgbkpBsuARdvmLsMFAITmLDyAKN;

		private IList wwkVXvWZsbSCypGqCBwHUBQrlGS;

		private IList HRsfgmFOxPhjLrmOBVXNccAleVK;

		public readonly Type RAuDIZQDIBZEHyIvPjkkNMFnwNC;

		public kKeolLJrItDCfBhkAWVJjbXTbYc(Type type)
		{
			RAuDIZQDIBZEHyIvPjkkNMFnwNC = type;
			AzgbkpBsuARdvmLsMFAITmLDyAKN = new AList<IControllerTemplate>();
		}

		public IList<T> VZqSGZQOIbFUZVzJGEEYrQpJptG<T>() where T : IControllerTemplate
		{
			if (wwkVXvWZsbSCypGqCBwHUBQrlGS == null)
			{
				while (true)
				{
					int num = 1664873406;
					while (true)
					{
						switch (num ^ 0x633BF3BF)
						{
						case 2:
							break;
						case 1:
							GrIEzrboLlJSKsOVRfCxrhVWmMb<T>();
							num = 1664873407;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			return HRsfgmFOxPhjLrmOBVXNccAleVK as IList<T>;
		}

		public void molwHYloiMfWCHJFERCRuvnmrARS(IControllerTemplate P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				AzgbkpBsuARdvmLsMFAITmLDyAKN.Add(P_0);
				int num;
				int num2;
				if (wwkVXvWZsbSCypGqCBwHUBQrlGS == null)
				{
					num = -2058959065;
					num2 = num;
				}
				else
				{
					num = -2058959067;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -2058959066)
					{
					case 0:
						num = -2058959068;
						continue;
					default:
						return;
					case 2:
						break;
					case 3:
						wwkVXvWZsbSCypGqCBwHUBQrlGS.Add(P_0);
						num = -2058959065;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		public void TsDqYOIbChtRedvmCnjKwRJSExZ(IControllerTemplate P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				AzgbkpBsuARdvmLsMFAITmLDyAKN.Remove(P_0);
				if (wwkVXvWZsbSCypGqCBwHUBQrlGS == null)
				{
					break;
				}
				wwkVXvWZsbSCypGqCBwHUBQrlGS.Remove(P_0);
				int num = -1966904683;
				while (true)
				{
					switch (num ^ -1966904681)
					{
					case 0:
						goto IL_0004;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0004:
					num = -1966904682;
				}
			}
		}

		private void GrIEzrboLlJSKsOVRfCxrhVWmMb<T>() where T : IControllerTemplate
		{
			wwkVXvWZsbSCypGqCBwHUBQrlGS = new AList<T>();
			HRsfgmFOxPhjLrmOBVXNccAleVK = new ReadOnlyCollection<T>((AList<T>)wwkVXvWZsbSCypGqCBwHUBQrlGS);
			int num2 = default(int);
			while (true)
			{
				int num = 116696417;
				while (true)
				{
					switch (num ^ 0x6F4A563)
					{
					case 3:
						break;
					case 2:
						num2 = 0;
						num = 116696423;
						continue;
					case 0:
						wwkVXvWZsbSCypGqCBwHUBQrlGS.Add(AzgbkpBsuARdvmLsMFAITmLDyAKN._items[num2]);
						num2++;
						num = 116696418;
						continue;
					case 4:
						num = 116696418;
						continue;
					default:
						if (num2 >= AzgbkpBsuARdvmLsMFAITmLDyAKN._count)
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

	private readonly AList<kKeolLJrItDCfBhkAWVJjbXTbYc> LnvbjdisRibUKDtIIurMCLeEainT;

	private readonly Type[] swAEHrXacZGPUJLobdbcArSwTscS;

	private readonly Type[] YRbGelCGOYterdBrLGGESAJjhis;

	private readonly int eJukvkmJGIXhDWqZGfDxYXjleeqa;

	public YMJTjGoZkTzBiaTeMxLHaYkKcGZ(Type[] templateTypes, Type[] interfaceTypes)
	{
		if (templateTypes.Length != interfaceTypes.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		swAEHrXacZGPUJLobdbcArSwTscS = templateTypes;
		YRbGelCGOYterdBrLGGESAJjhis = interfaceTypes;
		eJukvkmJGIXhDWqZGfDxYXjleeqa = swAEHrXacZGPUJLobdbcArSwTscS.Length;
		LnvbjdisRibUKDtIIurMCLeEainT = new AList<kKeolLJrItDCfBhkAWVJjbXTbYc>();
		for (int i = 0; i < eJukvkmJGIXhDWqZGfDxYXjleeqa; i++)
		{
			LnvbjdisRibUKDtIIurMCLeEainT.Add(new kKeolLJrItDCfBhkAWVJjbXTbYc(YRbGelCGOYterdBrLGGESAJjhis[i]));
		}
	}

	public void BvPfHvHLNzqGeTIHCnrafZGRLbzd(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int num2 = default(int);
		Type type = default(Type);
		IControllerTemplate controllerTemplate = default(IControllerTemplate);
		while (true)
		{
			int templateCount = P_0.templateCount;
			int num = -2108283588;
			while (true)
			{
				switch (num ^ -2108283586)
				{
				case 4:
					num = -2108283585;
					continue;
				default:
					return;
				case 1:
					break;
				case 7:
				{
					int num4;
					if (num2 >= templateCount)
					{
						num = -2108283597;
						num4 = num;
					}
					else
					{
						num = -2108283587;
						num4 = num;
					}
					continue;
				}
				case 11:
				{
					kKeolLJrItDCfBhkAWVJjbXTbYc kKeolLJrItDCfBhkAWVJjbXTbYc2 = GNJUNWkvklBhioTJuoadQqcACBa(type);
					if (kKeolLJrItDCfBhkAWVJjbXTbYc2 != null)
					{
						kKeolLJrItDCfBhkAWVJjbXTbYc2.molwHYloiMfWCHJFERCRuvnmrARS(controllerTemplate);
						num = -2108283586;
						continue;
					}
					goto case 0;
				}
				case 3:
					controllerTemplate = P_0.Templates[num2];
					num = -2108283598;
					continue;
				case 10:
					type = bBafrnaKWNgcPqdUncWeAhxtPiD(controllerTemplate.GetType());
					num = -2108283594;
					continue;
				case 0:
					num2++;
					num = -2108283591;
					continue;
				case 12:
				{
					int num3;
					if (controllerTemplate == null)
					{
						num = -2108283593;
						num3 = num;
					}
					else
					{
						num = -2108283596;
						num3 = num;
					}
					continue;
				}
				case 9:
					Logger.LogError("Template was null.");
					num = -2108283586;
					continue;
				case 6:
					num = -2108283586;
					continue;
				case 8:
					if ((object)type == null)
					{
						Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
						num = -2108283592;
						continue;
					}
					goto case 11;
				case 2:
					num2 = 0;
					num = -2108283589;
					continue;
				case 5:
					num = -2108283591;
					continue;
				case 13:
					return;
				}
				break;
			}
		}
	}

	public void utEyQKdpAPrHxIeSoECnMypLPFi(Controller P_0)
	{
		if (P_0 == null)
		{
			goto IL_0006;
		}
		goto IL_00d8;
		IL_0006:
		int num = -1613334607;
		goto IL_000b;
		IL_000b:
		IControllerTemplate controllerTemplate = default(IControllerTemplate);
		Type type = default(Type);
		int num2 = default(int);
		int templateCount = default(int);
		while (true)
		{
			switch (num ^ -1613334608)
			{
			case 2:
				break;
			case 5:
				if (controllerTemplate == null)
				{
					Logger.LogError("Template was null.");
					num = -1613334605;
					continue;
				}
				goto case 8;
			case 8:
				type = bBafrnaKWNgcPqdUncWeAhxtPiD(controllerTemplate.GetType());
				if ((object)type == null)
				{
					Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
					num = -1613334605;
					continue;
				}
				goto case 4;
			case 7:
				controllerTemplate = P_0.Templates[num2];
				num = -1613334603;
				continue;
			case 1:
				return;
			case 3:
				num2++;
				num = -1613334608;
				continue;
			case 4:
			{
				kKeolLJrItDCfBhkAWVJjbXTbYc kKeolLJrItDCfBhkAWVJjbXTbYc2 = GNJUNWkvklBhioTJuoadQqcACBa(type);
				if (kKeolLJrItDCfBhkAWVJjbXTbYc2 != null)
				{
					kKeolLJrItDCfBhkAWVJjbXTbYc2.TsDqYOIbChtRedvmCnjKwRJSExZ(controllerTemplate);
					num = -1613334605;
					continue;
				}
				goto case 3;
			}
			case 6:
				goto IL_00d8;
			default:
				if (num2 >= templateCount)
				{
					return;
				}
				goto case 7;
			}
			break;
		}
		goto IL_0006;
		IL_00d8:
		templateCount = P_0.templateCount;
		num2 = 0;
		num = -1613334608;
		goto IL_000b;
	}

	public IList<T> VZqSGZQOIbFUZVzJGEEYrQpJptG<T>() where T : IControllerTemplate
	{
		Type typeFromHandle = typeof(T);
		int num3 = default(int);
		kKeolLJrItDCfBhkAWVJjbXTbYc kKeolLJrItDCfBhkAWVJjbXTbYc2 = default(kKeolLJrItDCfBhkAWVJjbXTbYc);
		string text = default(string);
		int num2 = default(int);
		while (true)
		{
			int num = -393228765;
			while (true)
			{
				switch (num ^ -393228760)
				{
				case 0:
					break;
				case 11:
					num3 = 0;
					num = -393228753;
					continue;
				case 7:
					num = -393228757;
					continue;
				case 2:
					kKeolLJrItDCfBhkAWVJjbXTbYc2 = LnvbjdisRibUKDtIIurMCLeEainT._items[num3];
					num = -393228759;
					continue;
				case 6:
					num = -393228756;
					continue;
				case 9:
					text += YRbGelCGOYterdBrLGGESAJjhis[num2].Name;
					if (num2 != YRbGelCGOYterdBrLGGESAJjhis.Length - 1)
					{
						text += "\n";
						num = -393228755;
						continue;
					}
					goto case 5;
				case 1:
					if (object.ReferenceEquals(kKeolLJrItDCfBhkAWVJjbXTbYc2.RAuDIZQDIBZEHyIvPjkkNMFnwNC, typeFromHandle))
					{
						return kKeolLJrItDCfBhkAWVJjbXTbYc2.VZqSGZQOIbFUZVzJGEEYrQpJptG<T>();
					}
					num3++;
					num = -393228757;
					continue;
				case 3:
					if (num3 >= LnvbjdisRibUKDtIIurMCLeEainT._count)
					{
						text = "";
						num = -393228768;
						continue;
					}
					goto case 2;
				case 8:
					num2 = 0;
					num = -393228754;
					continue;
				case 5:
					num2++;
					num = -393228756;
					continue;
				case 4:
					if (num2 >= YRbGelCGOYterdBrLGGESAJjhis.Length)
					{
						Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
						num = -393228766;
						continue;
					}
					goto case 9;
				default:
					return EmptyObjects<T>.EmptyReadOnlyIListT;
				}
				break;
			}
		}
	}

	private kKeolLJrItDCfBhkAWVJjbXTbYc GNJUNWkvklBhioTJuoadQqcACBa(Type P_0)
	{
		int num = 0;
		while (num < LnvbjdisRibUKDtIIurMCLeEainT._count)
		{
			while (true)
			{
				if (object.ReferenceEquals(P_0, LnvbjdisRibUKDtIIurMCLeEainT._items[num].RAuDIZQDIBZEHyIvPjkkNMFnwNC))
				{
					return LnvbjdisRibUKDtIIurMCLeEainT._items[num];
				}
				num++;
				int num2 = 1468779770;
				while (true)
				{
					switch (num2 ^ 0x578BCCF8)
					{
					case 0:
						num2 = 1468779769;
						continue;
					case 1:
						break;
					default:
						goto end_IL_0022;
					}
					break;
				}
				continue;
				end_IL_0022:
				break;
			}
		}
		return null;
	}

	private Type bBafrnaKWNgcPqdUncWeAhxtPiD(Type P_0)
	{
		int num = 0;
		while (true)
		{
			int num2 = -1286819676;
			while (true)
			{
				switch (num2 ^ -1286819673)
				{
				case 2:
					break;
				case 3:
					num2 = -1286819674;
					continue;
				case 0:
					if (object.ReferenceEquals(swAEHrXacZGPUJLobdbcArSwTscS[num], P_0))
					{
						return YRbGelCGOYterdBrLGGESAJjhis[num];
					}
					num++;
					num2 = -1286819674;
					continue;
				default:
					if (num >= eJukvkmJGIXhDWqZGfDxYXjleeqa)
					{
						return null;
					}
					goto case 0;
				}
				break;
			}
		}
	}
}

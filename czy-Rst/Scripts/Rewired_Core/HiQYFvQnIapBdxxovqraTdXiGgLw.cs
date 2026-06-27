using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class HiQYFvQnIapBdxxovqraTdXiGgLw
{
	private class JgbYkOGOAtLVqmiIhFiBoayDEzbD
	{
		private readonly AList<IControllerTemplate> yoWBJkGeIMuQuFfbJxhivySIoDOkA;

		private IList eGQAsNsfLPsxnfIDKEezeUrhTLjl;

		private IList aDySHHPnvEuaMnfeZzVtPKeaZjpw;

		public readonly Type AwBkojSqcFEtWqIlhpdbdohevsPQ;

		public JgbYkOGOAtLVqmiIhFiBoayDEzbD(Type P_0)
		{
			AwBkojSqcFEtWqIlhpdbdohevsPQ = P_0;
			yoWBJkGeIMuQuFfbJxhivySIoDOkA = new AList<IControllerTemplate>();
		}

		public IList<_0001> FLOuaAgXxbocBuiCabtMekXaEaQlA<_0001>() where _0001 : IControllerTemplate
		{
			if (eGQAsNsfLPsxnfIDKEezeUrhTLjl == null)
			{
				yioqacklrIBWwhPUIJLAQFfZTvkM<_0001>();
			}
			return aDySHHPnvEuaMnfeZzVtPKeaZjpw as IList<_0001>;
		}

		public void jBdhjvatrakxcvemOaGbruKLzZbq(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				yoWBJkGeIMuQuFfbJxhivySIoDOkA.Add(P_0);
				if (eGQAsNsfLPsxnfIDKEezeUrhTLjl != null)
				{
					eGQAsNsfLPsxnfIDKEezeUrhTLjl.Add(P_0);
				}
			}
		}

		public void PRngJMklvJNjjWDaDyoXabhomXlo(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				yoWBJkGeIMuQuFfbJxhivySIoDOkA.Remove(P_0);
				if (eGQAsNsfLPsxnfIDKEezeUrhTLjl != null)
				{
					eGQAsNsfLPsxnfIDKEezeUrhTLjl.Remove(P_0);
				}
			}
		}

		private void yioqacklrIBWwhPUIJLAQFfZTvkM<_0001>() where _0001 : IControllerTemplate
		{
			eGQAsNsfLPsxnfIDKEezeUrhTLjl = new AList<_0001>();
			aDySHHPnvEuaMnfeZzVtPKeaZjpw = new ReadOnlyCollection<_0001>((AList<_0001>)eGQAsNsfLPsxnfIDKEezeUrhTLjl);
			for (int i = 0; i < yoWBJkGeIMuQuFfbJxhivySIoDOkA._count; i++)
			{
				eGQAsNsfLPsxnfIDKEezeUrhTLjl.Add(yoWBJkGeIMuQuFfbJxhivySIoDOkA._items[i]);
			}
		}
	}

	private readonly AList<JgbYkOGOAtLVqmiIhFiBoayDEzbD> WYcKtNzYEwrHGgIkkXyyhYEgaJDI;

	private readonly Type[] iszndaNOAYaLVsHBNghpFAQbbHhXA;

	private readonly Type[] jtDOuQIuiZOvPxbkkdRXqHaEwtFP;

	private readonly int hipvtsfCbtOVHyUpcSfliSaElchI;

	public HiQYFvQnIapBdxxovqraTdXiGgLw(Type[] P_0, Type[] P_1)
	{
		if (P_0.Length != P_1.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		iszndaNOAYaLVsHBNghpFAQbbHhXA = P_0;
		jtDOuQIuiZOvPxbkkdRXqHaEwtFP = P_1;
		hipvtsfCbtOVHyUpcSfliSaElchI = iszndaNOAYaLVsHBNghpFAQbbHhXA.Length;
		WYcKtNzYEwrHGgIkkXyyhYEgaJDI = new AList<JgbYkOGOAtLVqmiIhFiBoayDEzbD>();
		for (int i = 0; i < hipvtsfCbtOVHyUpcSfliSaElchI; i++)
		{
			WYcKtNzYEwrHGgIkkXyyhYEgaJDI.Add(new JgbYkOGOAtLVqmiIhFiBoayDEzbD(jtDOuQIuiZOvPxbkkdRXqHaEwtFP[i]));
		}
	}

	public void nfEkqZqZRNUInmTJUkYYXDLywkdD(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int templateCount = P_0.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = P_0.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
				continue;
			}
			Type type = yLSCXcfbVAAyADrrOpDQWXSUyWuQ(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				JTFyTBlBsYStKnhwhgxtqYLDlKWA(type)?.jBdhjvatrakxcvemOaGbruKLzZbq(controllerTemplate);
			}
		}
	}

	public void IlxVkhbJblcRsHURxmeSjqVJSnQRA(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int templateCount = P_0.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = P_0.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
				continue;
			}
			Type type = yLSCXcfbVAAyADrrOpDQWXSUyWuQ(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				JTFyTBlBsYStKnhwhgxtqYLDlKWA(type)?.PRngJMklvJNjjWDaDyoXabhomXlo(controllerTemplate);
			}
		}
	}

	public IList<_0001> HAdedHyoXZKkmMTAwgYAQrwqrIeW<_0001>() where _0001 : IControllerTemplate
	{
		Type typeFromHandle = typeof(_0001);
		for (int i = 0; i < WYcKtNzYEwrHGgIkkXyyhYEgaJDI._count; i++)
		{
			JgbYkOGOAtLVqmiIhFiBoayDEzbD jgbYkOGOAtLVqmiIhFiBoayDEzbD = WYcKtNzYEwrHGgIkkXyyhYEgaJDI._items[i];
			if ((object)jgbYkOGOAtLVqmiIhFiBoayDEzbD.AwBkojSqcFEtWqIlhpdbdohevsPQ == typeFromHandle)
			{
				return jgbYkOGOAtLVqmiIhFiBoayDEzbD.FLOuaAgXxbocBuiCabtMekXaEaQlA<_0001>();
			}
		}
		string text = "";
		for (int j = 0; j < jtDOuQIuiZOvPxbkkdRXqHaEwtFP.Length; j++)
		{
			text += jtDOuQIuiZOvPxbkkdRXqHaEwtFP[j].Name;
			if (j != jtDOuQIuiZOvPxbkkdRXqHaEwtFP.Length - 1)
			{
				text += "\n";
			}
		}
		Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
		return EmptyObjects<_0001>.EmptyReadOnlyIListT;
	}

	private JgbYkOGOAtLVqmiIhFiBoayDEzbD JTFyTBlBsYStKnhwhgxtqYLDlKWA(Type P_0)
	{
		for (int i = 0; i < WYcKtNzYEwrHGgIkkXyyhYEgaJDI._count; i++)
		{
			if ((object)P_0 == WYcKtNzYEwrHGgIkkXyyhYEgaJDI._items[i].AwBkojSqcFEtWqIlhpdbdohevsPQ)
			{
				return WYcKtNzYEwrHGgIkkXyyhYEgaJDI._items[i];
			}
		}
		return null;
	}

	private Type yLSCXcfbVAAyADrrOpDQWXSUyWuQ(Type P_0)
	{
		for (int i = 0; i < hipvtsfCbtOVHyUpcSfliSaElchI; i++)
		{
			if ((object)iszndaNOAYaLVsHBNghpFAQbbHhXA[i] == P_0)
			{
				return jtDOuQIuiZOvPxbkkdRXqHaEwtFP[i];
			}
		}
		return null;
	}
}

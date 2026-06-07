using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class XPTCKTooCGCKcMxzkZtfjnOrnRvn
{
	private class LJJWQmTYmRLadtJWEjlpkCMXkWnT
	{
		private readonly AList<IControllerTemplate> VclIzXqzjHdMOfpSsGrynyTedqzj;

		private IList nCvYBJOlEiplXNDmmJTdFJVUEMxE;

		private IList YjffrKaRsMKWiABgFnDdYrMhUwjyb;

		public readonly Type CefBbBSFYQrgJOZchsbEQPsQoljE;

		public LJJWQmTYmRLadtJWEjlpkCMXkWnT(Type P_0)
		{
			CefBbBSFYQrgJOZchsbEQPsQoljE = P_0;
			VclIzXqzjHdMOfpSsGrynyTedqzj = new AList<IControllerTemplate>();
		}

		public IList<_0001> EThRTrEQTiAbwrmxuQKaeHxocOdfA<_0001>() where _0001 : IControllerTemplate
		{
			if (nCvYBJOlEiplXNDmmJTdFJVUEMxE == null)
			{
				ZIBhcZztYkYrlKQlfHMNqpRbfvIEA<_0001>();
			}
			return YjffrKaRsMKWiABgFnDdYrMhUwjyb as IList<_0001>;
		}

		public void fyeqCafQbFyflbNbajUvornPxfgy(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				VclIzXqzjHdMOfpSsGrynyTedqzj.Add(P_0);
				if (nCvYBJOlEiplXNDmmJTdFJVUEMxE != null)
				{
					nCvYBJOlEiplXNDmmJTdFJVUEMxE.Add(P_0);
				}
			}
		}

		public void QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				VclIzXqzjHdMOfpSsGrynyTedqzj.Remove(P_0);
				if (nCvYBJOlEiplXNDmmJTdFJVUEMxE != null)
				{
					nCvYBJOlEiplXNDmmJTdFJVUEMxE.Remove(P_0);
				}
			}
		}

		private void ZIBhcZztYkYrlKQlfHMNqpRbfvIEA<_0001>() where _0001 : IControllerTemplate
		{
			nCvYBJOlEiplXNDmmJTdFJVUEMxE = new AList<_0001>();
			YjffrKaRsMKWiABgFnDdYrMhUwjyb = new ReadOnlyCollection<_0001>((AList<_0001>)nCvYBJOlEiplXNDmmJTdFJVUEMxE);
			for (int i = 0; i < VclIzXqzjHdMOfpSsGrynyTedqzj._count; i++)
			{
				nCvYBJOlEiplXNDmmJTdFJVUEMxE.Add(VclIzXqzjHdMOfpSsGrynyTedqzj._items[i]);
			}
		}
	}

	private readonly AList<LJJWQmTYmRLadtJWEjlpkCMXkWnT> OagqPDkGBjzEhDwvixCuOwcbVMAD;

	private readonly Type[] bODDhPBpdEoslrUJDrOAyQjHRfHE;

	private readonly Type[] ZNcbBLKKNPHQGNgzfKKuPDJImSHx;

	private readonly int xrtaqUGwVVZIiWunoTRLeVvWMVPBA;

	public XPTCKTooCGCKcMxzkZtfjnOrnRvn(Type[] P_0, Type[] P_1)
	{
		if (P_0.Length != P_1.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		bODDhPBpdEoslrUJDrOAyQjHRfHE = P_0;
		ZNcbBLKKNPHQGNgzfKKuPDJImSHx = P_1;
		xrtaqUGwVVZIiWunoTRLeVvWMVPBA = bODDhPBpdEoslrUJDrOAyQjHRfHE.Length;
		OagqPDkGBjzEhDwvixCuOwcbVMAD = new AList<LJJWQmTYmRLadtJWEjlpkCMXkWnT>();
		for (int i = 0; i < xrtaqUGwVVZIiWunoTRLeVvWMVPBA; i++)
		{
			OagqPDkGBjzEhDwvixCuOwcbVMAD.Add(new LJJWQmTYmRLadtJWEjlpkCMXkWnT(ZNcbBLKKNPHQGNgzfKKuPDJImSHx[i]));
		}
	}

	public void GXYfOFJtEarnZyYbwQfGKoAqjIOO(Controller P_0)
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
			Type type = crtmwPwgVMVdqGRgNKAYPLrARdci(controllerTemplate.GetType());
			if ((object)type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				VgENAaqvfecwNCxXUioLTmCxjYLD(type)?.fyeqCafQbFyflbNbajUvornPxfgy(controllerTemplate);
			}
		}
	}

	public void zaBdfgpdaOdEOaceIWYVHDxywmNx(Controller P_0)
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
			Type type = crtmwPwgVMVdqGRgNKAYPLrARdci(controllerTemplate.GetType());
			if ((object)type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				VgENAaqvfecwNCxXUioLTmCxjYLD(type)?.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(controllerTemplate);
			}
		}
	}

	public IList<_0001> EThRTrEQTiAbwrmxuQKaeHxocOdfA<_0001>() where _0001 : IControllerTemplate
	{
		Type typeFromHandle = typeof(_0001);
		for (int i = 0; i < OagqPDkGBjzEhDwvixCuOwcbVMAD._count; i++)
		{
			LJJWQmTYmRLadtJWEjlpkCMXkWnT lJJWQmTYmRLadtJWEjlpkCMXkWnT = OagqPDkGBjzEhDwvixCuOwcbVMAD._items[i];
			if ((object)lJJWQmTYmRLadtJWEjlpkCMXkWnT.CefBbBSFYQrgJOZchsbEQPsQoljE == typeFromHandle)
			{
				return lJJWQmTYmRLadtJWEjlpkCMXkWnT.EThRTrEQTiAbwrmxuQKaeHxocOdfA<_0001>();
			}
		}
		string text = "";
		for (int j = 0; j < ZNcbBLKKNPHQGNgzfKKuPDJImSHx.Length; j++)
		{
			text += ZNcbBLKKNPHQGNgzfKKuPDJImSHx[j].Name;
			if (j != ZNcbBLKKNPHQGNgzfKKuPDJImSHx.Length - 1)
			{
				text += "\n";
			}
		}
		Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
		return EmptyObjects<_0001>.EmptyReadOnlyIListT;
	}

	private LJJWQmTYmRLadtJWEjlpkCMXkWnT VgENAaqvfecwNCxXUioLTmCxjYLD(Type P_0)
	{
		for (int i = 0; i < OagqPDkGBjzEhDwvixCuOwcbVMAD._count; i++)
		{
			if ((object)P_0 == OagqPDkGBjzEhDwvixCuOwcbVMAD._items[i].CefBbBSFYQrgJOZchsbEQPsQoljE)
			{
				return OagqPDkGBjzEhDwvixCuOwcbVMAD._items[i];
			}
		}
		return null;
	}

	private Type crtmwPwgVMVdqGRgNKAYPLrARdci(Type P_0)
	{
		for (int i = 0; i < xrtaqUGwVVZIiWunoTRLeVvWMVPBA; i++)
		{
			if ((object)bODDhPBpdEoslrUJDrOAyQjHRfHE[i] == P_0)
			{
				return ZNcbBLKKNPHQGNgzfKKuPDJImSHx[i];
			}
		}
		return null;
	}
}

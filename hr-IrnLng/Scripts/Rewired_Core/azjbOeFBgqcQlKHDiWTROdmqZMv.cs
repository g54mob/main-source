using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class azjbOeFBgqcQlKHDiWTROdmqZMv
{
	private class sVFyPJZoLcpogDJVxHAvnoImAOLJ
	{
		private readonly AList<IControllerTemplate> yxHUQoFParyiBpDywOfWIJsrbSp;

		private IList UUFxafzFtKVMrXAoggZXeaaDIhD;

		private IList xRBnKleslylqbFmKpFyBUxbRCkv;

		public readonly Type bAPyGAfeWoGVtSjhtFRwzpyXFad;

		public sVFyPJZoLcpogDJVxHAvnoImAOLJ(Type type)
		{
			bAPyGAfeWoGVtSjhtFRwzpyXFad = type;
			yxHUQoFParyiBpDywOfWIJsrbSp = new AList<IControllerTemplate>();
		}

		public IList<T> xbXCiCGpUEnZvbvPgjxSgXChLGvD<T>() where T : IControllerTemplate
		{
			if (UUFxafzFtKVMrXAoggZXeaaDIhD == null)
			{
				ssflTiCuJALDcWQFdvbnXowgcxCd<T>();
			}
			return xRBnKleslylqbFmKpFyBUxbRCkv as IList<T>;
		}

		public void MoYefDcYehcNuEtBwCxDvPMYqtm(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				yxHUQoFParyiBpDywOfWIJsrbSp.Add(P_0);
				if (UUFxafzFtKVMrXAoggZXeaaDIhD != null)
				{
					UUFxafzFtKVMrXAoggZXeaaDIhD.Add(P_0);
				}
			}
		}

		public void tsiIiRnEIKEeGXdmsiYIGAemsrcr(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				yxHUQoFParyiBpDywOfWIJsrbSp.Remove(P_0);
				if (UUFxafzFtKVMrXAoggZXeaaDIhD != null)
				{
					UUFxafzFtKVMrXAoggZXeaaDIhD.Remove(P_0);
				}
			}
		}

		private void ssflTiCuJALDcWQFdvbnXowgcxCd<T>() where T : IControllerTemplate
		{
			UUFxafzFtKVMrXAoggZXeaaDIhD = new AList<T>();
			xRBnKleslylqbFmKpFyBUxbRCkv = new ReadOnlyCollection<T>((AList<T>)UUFxafzFtKVMrXAoggZXeaaDIhD);
			for (int i = 0; i < yxHUQoFParyiBpDywOfWIJsrbSp._count; i++)
			{
				UUFxafzFtKVMrXAoggZXeaaDIhD.Add(yxHUQoFParyiBpDywOfWIJsrbSp._items[i]);
			}
		}
	}

	private readonly AList<sVFyPJZoLcpogDJVxHAvnoImAOLJ> lnSFvwZOVFBkyRmOeUuQpPHuBRY;

	private readonly Type[] SwviymijqsSEczSkFOsuVVpUZbN;

	private readonly Type[] osAalorEGxweXNfNdcfSwqwJQCX;

	private readonly int UJBRRjJgIjwmxiCVcDcjGiMZERJs;

	public azjbOeFBgqcQlKHDiWTROdmqZMv(Type[] templateTypes, Type[] interfaceTypes)
	{
		if (templateTypes.Length != interfaceTypes.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		SwviymijqsSEczSkFOsuVVpUZbN = templateTypes;
		osAalorEGxweXNfNdcfSwqwJQCX = interfaceTypes;
		UJBRRjJgIjwmxiCVcDcjGiMZERJs = SwviymijqsSEczSkFOsuVVpUZbN.Length;
		lnSFvwZOVFBkyRmOeUuQpPHuBRY = new AList<sVFyPJZoLcpogDJVxHAvnoImAOLJ>();
		for (int i = 0; i < UJBRRjJgIjwmxiCVcDcjGiMZERJs; i++)
		{
			lnSFvwZOVFBkyRmOeUuQpPHuBRY.Add(new sVFyPJZoLcpogDJVxHAvnoImAOLJ(osAalorEGxweXNfNdcfSwqwJQCX[i]));
		}
	}

	public void ztcXjeonNMANOsnNizYgnnvxcMY(Controller P_0)
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
			Type type = PaZNHwPQDudonCEcZzgaiBIFHLo(controllerTemplate.GetType());
			if ((object)type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				qniqgVNqoQYwQIqZQXRjohHuhpV(type)?.MoYefDcYehcNuEtBwCxDvPMYqtm(controllerTemplate);
			}
		}
	}

	public void EpPUHSOjmleHMsWUMfpjcKkxcPX(Controller P_0)
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
			Type type = PaZNHwPQDudonCEcZzgaiBIFHLo(controllerTemplate.GetType());
			if ((object)type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				qniqgVNqoQYwQIqZQXRjohHuhpV(type)?.tsiIiRnEIKEeGXdmsiYIGAemsrcr(controllerTemplate);
			}
		}
	}

	public IList<T> xbXCiCGpUEnZvbvPgjxSgXChLGvD<T>() where T : IControllerTemplate
	{
		Type typeFromHandle = typeof(T);
		for (int i = 0; i < lnSFvwZOVFBkyRmOeUuQpPHuBRY._count; i++)
		{
			sVFyPJZoLcpogDJVxHAvnoImAOLJ sVFyPJZoLcpogDJVxHAvnoImAOLJ2 = lnSFvwZOVFBkyRmOeUuQpPHuBRY._items[i];
			if (object.ReferenceEquals(sVFyPJZoLcpogDJVxHAvnoImAOLJ2.bAPyGAfeWoGVtSjhtFRwzpyXFad, typeFromHandle))
			{
				return sVFyPJZoLcpogDJVxHAvnoImAOLJ2.xbXCiCGpUEnZvbvPgjxSgXChLGvD<T>();
			}
		}
		string text = "";
		for (int j = 0; j < osAalorEGxweXNfNdcfSwqwJQCX.Length; j++)
		{
			text += osAalorEGxweXNfNdcfSwqwJQCX[j].Name;
			if (j != osAalorEGxweXNfNdcfSwqwJQCX.Length - 1)
			{
				text += "\n";
			}
		}
		Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
		return EmptyObjects<T>.EmptyReadOnlyIListT;
	}

	private sVFyPJZoLcpogDJVxHAvnoImAOLJ qniqgVNqoQYwQIqZQXRjohHuhpV(Type P_0)
	{
		for (int i = 0; i < lnSFvwZOVFBkyRmOeUuQpPHuBRY._count; i++)
		{
			if (object.ReferenceEquals(P_0, lnSFvwZOVFBkyRmOeUuQpPHuBRY._items[i].bAPyGAfeWoGVtSjhtFRwzpyXFad))
			{
				return lnSFvwZOVFBkyRmOeUuQpPHuBRY._items[i];
			}
		}
		return null;
	}

	private Type PaZNHwPQDudonCEcZzgaiBIFHLo(Type P_0)
	{
		for (int i = 0; i < UJBRRjJgIjwmxiCVcDcjGiMZERJs; i++)
		{
			if (object.ReferenceEquals(SwviymijqsSEczSkFOsuVVpUZbN[i], P_0))
			{
				return osAalorEGxweXNfNdcfSwqwJQCX[i];
			}
		}
		return null;
	}
}

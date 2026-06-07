using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class Controller
	{
		public abstract class Element
		{
			internal abstract class YYFavhdGVsNIbUaKjsVOXMYlnVR
			{
				public abstract class tjTJrqnqtNKWRfypZNbpGSZfeVZ
				{
					public abstract void agvWMBoHtblzmgSmVloJbsDkfGk();
				}

				protected readonly int aMjgVbFAeJESFQCKeNOBqOJWwrB;

				protected readonly int[] gUNLFGDzsYivuMVwxuBTNVowmzr;

				protected tjTJrqnqtNKWRfypZNbpGSZfeVZ[] KKxvXzhbFzmenMQwioAojqUOeaj;

				public tjTJrqnqtNKWRfypZNbpGSZfeVZ TrWUdtjebjTxiTudwuGvXSlDJgg;

				private int jZIrWyBTDMYPCOWflxuDUQgsNSP;

				public int xzsHlpfVkUipOIFvAGjOgLamtlLt = -1;

				protected ReadOnlyCollection<tjTJrqnqtNKWRfypZNbpGSZfeVZ> yoqCLRPIGLOttSVGREtmLPRWxoT;

				public IList<tjTJrqnqtNKWRfypZNbpGSZfeVZ> Data => yoqCLRPIGLOttSVGREtmLPRWxoT;

				public UpdateLoopType updateLoop
				{
					set
					{
						if (xzsHlpfVkUipOIFvAGjOgLamtlLt != (int)value)
						{
							xzsHlpfVkUipOIFvAGjOgLamtlLt = (int)value;
							jZIrWyBTDMYPCOWflxuDUQgsNSP = gUNLFGDzsYivuMVwxuBTNVowmzr[(int)value];
							TrWUdtjebjTxiTudwuGvXSlDJgg = KKxvXzhbFzmenMQwioAojqUOeaj[jZIrWyBTDMYPCOWflxuDUQgsNSP];
						}
					}
				}

				public YYFavhdGVsNIbUaKjsVOXMYlnVR(UpdateLoopSetting updateLoopSetting)
				{
					gUNLFGDzsYivuMVwxuBTNVowmzr = new int[3];
					aMjgVbFAeJESFQCKeNOBqOJWwrB = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
						for (int i = 0; i < list.Count; i++)
						{
							gUNLFGDzsYivuMVwxuBTNVowmzr[(int)list[i]] = aMjgVbFAeJESFQCKeNOBqOJWwrB;
							aMjgVbFAeJESFQCKeNOBqOJWwrB++;
						}
					}
					KKxvXzhbFzmenMQwioAojqUOeaj = new tjTJrqnqtNKWRfypZNbpGSZfeVZ[aMjgVbFAeJESFQCKeNOBqOJWwrB];
					yoqCLRPIGLOttSVGREtmLPRWxoT = new ReadOnlyCollection<tjTJrqnqtNKWRfypZNbpGSZfeVZ>(KKxvXzhbFzmenMQwioAojqUOeaj);
				}

				public void agvWMBoHtblzmgSmVloJbsDkfGk()
				{
					for (int i = 0; i < aMjgVbFAeJESFQCKeNOBqOJWwrB; i++)
					{
						KKxvXzhbFzmenMQwioAojqUOeaj[i].agvWMBoHtblzmgSmVloJbsDkfGk();
					}
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal YYFavhdGVsNIbUaKjsVOXMYlnVR pkldeucTgnDEMPziBuveeikAmAF;

			internal int QdmQKcVfQWABUruEwPDVptuKFDI;

			internal Controller frSJxBhFNALntnzeNKOcTHuHKsS;

			internal readonly int VumWnlylMgxSbyJcluXptXvaaZa;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = frSJxBhFNALntnzeNKOcTHuHKsS.GetElementIdentifierById(id);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			public bool isMemberElement
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return QdmQKcVfQWABUruEwPDVptuKFDI > 0;
				}
			}

			internal Element(Controller controller, int elementIdentifierId, string name, ControllerElementType type)
			{
				frSJxBhFNALntnzeNKOcTHuHKsS = controller;
				id = elementIdentifierId;
				this.name = name;
				this.type = type;
				VumWnlylMgxSbyJcluXptXvaaZa = ReInput.id;
			}

			public void Reset()
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else if (pkldeucTgnDEMPziBuveeikAmAF != null)
				{
					pkldeucTgnDEMPziBuveeikAmAF.agvWMBoHtblzmgSmVloJbsDkfGk();
				}
			}

			internal void reRAUCJEGyKXOXrFHDJjhvkiueE()
			{
				if (QdmQKcVfQWABUruEwPDVptuKFDI > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
				}
				QdmQKcVfQWABUruEwPDVptuKFDI++;
			}

			internal void SktnbLHKdKzyJMdCYBSokIvWCARP()
			{
				if (QdmQKcVfQWABUruEwPDVptuKFDI == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					QdmQKcVfQWABUruEwPDVptuKFDI = 0;
				}
				else
				{
					QdmQKcVfQWABUruEwPDVptuKFDI--;
				}
			}
		}

		public sealed class Axis : Element
		{
			internal class REPeWgxCQchujMmvLCjrEJuTKPm : YYFavhdGVsNIbUaKjsVOXMYlnVR
			{
				public class tDZjwRUFktaJtmvXxDafqhREUla : tjTJrqnqtNKWRfypZNbpGSZfeVZ
				{
					private const float iOvoetXWEsbgUbemLteuwhSCAJef = 0.001f;

					public float lvXCTCWOhrCtuFDbbEqyqyUVPhp;

					public float zbTlRpPDVFNVMgeQOZGyokKEojW;

					public float nmfCWMfUuKHnBMFEcYZgIKMwjDEo;

					public float EfgWLWEMnhsuRkoPPgoLysSNrHD;

					public float WtEWgQCHpbhDjFfESxevtlZlFJX;

					public float dXnAuhulAwehiqyyUsKhIxmmlGI;

					public double ANJDLjNtIDwGjmVFWtpExFYwcVb;

					public double ozlPLzrUVOstanEQARQaCzANtmX;

					public double hOFtRmJriTPAVLjFUAUTkduLUqg;

					public double dGpAccauvxxwBJqtLjMlOnZVls;

					public double SkYoLLbwBTBTTsrbrelbFspYEbq;

					public double YEGnyDIkuKGNtZLmTiUrqnfyZAC;

					public double timeActive
					{
						get
						{
							if ((double)lvXCTCWOhrCtuFDbbEqyqyUVPhp == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - hOFtRmJriTPAVLjFUAUTkduLUqg;
						}
					}

					public double timeActiveRaw
					{
						get
						{
							if ((double)nmfCWMfUuKHnBMFEcYZgIKMwjDEo == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - dGpAccauvxxwBJqtLjMlOnZVls;
						}
					}

					public double timeInactive
					{
						get
						{
							if (lvXCTCWOhrCtuFDbbEqyqyUVPhp != 0f)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - ANJDLjNtIDwGjmVFWtpExFYwcVb;
						}
					}

					public double timeInactiveRaw
					{
						get
						{
							if ((double)nmfCWMfUuKHnBMFEcYZgIKMwjDEo != 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - ozlPLzrUVOstanEQARQaCzANtmX;
						}
					}

					public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA(bool P_0)
					{
						double unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							if (!MathTools.Approximately(WtEWgQCHpbhDjFfESxevtlZlFJX, 0f))
							{
								ANJDLjNtIDwGjmVFWtpExFYwcVb = unscaledTime;
							}
							else
							{
								hOFtRmJriTPAVLjFUAUTkduLUqg = unscaledTime;
							}
							if (!MathTools.IsNear(WtEWgQCHpbhDjFfESxevtlZlFJX, dXnAuhulAwehiqyyUsKhIxmmlGI, 0.001f))
							{
								SkYoLLbwBTBTTsrbrelbFspYEbq = unscaledTime;
							}
						}
						else
						{
							if (!MathTools.Approximately(lvXCTCWOhrCtuFDbbEqyqyUVPhp, 0f))
							{
								ANJDLjNtIDwGjmVFWtpExFYwcVb = unscaledTime;
							}
							else
							{
								hOFtRmJriTPAVLjFUAUTkduLUqg = unscaledTime;
							}
							if (!MathTools.IsNear(lvXCTCWOhrCtuFDbbEqyqyUVPhp, zbTlRpPDVFNVMgeQOZGyokKEojW, 0.001f))
							{
								SkYoLLbwBTBTTsrbrelbFspYEbq = unscaledTime;
							}
						}
						if (!MathTools.Approximately(nmfCWMfUuKHnBMFEcYZgIKMwjDEo, 0f))
						{
							ozlPLzrUVOstanEQARQaCzANtmX = unscaledTime;
						}
						else
						{
							dGpAccauvxxwBJqtLjMlOnZVls = unscaledTime;
						}
						if (!MathTools.IsNear(nmfCWMfUuKHnBMFEcYZgIKMwjDEo, EfgWLWEMnhsuRkoPPgoLysSNrHD, 0.001f))
						{
							YEGnyDIkuKGNtZLmTiUrqnfyZAC = unscaledTime;
						}
					}

					public void CbRfqHVsrqTfKytSDNmBtrZHtpK(float P_0)
					{
						if (EfgWLWEMnhsuRkoPPgoLysSNrHD != nmfCWMfUuKHnBMFEcYZgIKMwjDEo)
						{
							EfgWLWEMnhsuRkoPPgoLysSNrHD = nmfCWMfUuKHnBMFEcYZgIKMwjDEo;
						}
						if (nmfCWMfUuKHnBMFEcYZgIKMwjDEo != P_0)
						{
							nmfCWMfUuKHnBMFEcYZgIKMwjDEo = P_0;
						}
					}

					public override void agvWMBoHtblzmgSmVloJbsDkfGk()
					{
						lvXCTCWOhrCtuFDbbEqyqyUVPhp = 0f;
						zbTlRpPDVFNVMgeQOZGyokKEojW = 0f;
						nmfCWMfUuKHnBMFEcYZgIKMwjDEo = 0f;
						EfgWLWEMnhsuRkoPPgoLysSNrHD = 0f;
						ANJDLjNtIDwGjmVFWtpExFYwcVb = 0.0;
						ozlPLzrUVOstanEQARQaCzANtmX = 0.0;
						hOFtRmJriTPAVLjFUAUTkduLUqg = 0.0;
						dGpAccauvxxwBJqtLjMlOnZVls = 0.0;
						SkYoLLbwBTBTTsrbrelbFspYEbq = 0.0;
						YEGnyDIkuKGNtZLmTiUrqnfyZAC = 0.0;
					}
				}

				public REPeWgxCQchujMmvLCjrEJuTKPm(UpdateLoopSetting updateCycle)
					: base(updateCycle)
				{
					for (int i = 0; i < aMjgVbFAeJESFQCKeNOBqOJWwrB; i++)
					{
						KKxvXzhbFzmenMQwioAojqUOeaj[i] = new tDZjwRUFktaJtmvXxDafqhREUla();
					}
					TrWUdtjebjTxiTudwuGvXSlDJgg = KKxvXzhbFzmenMQwioAojqUOeaj[0];
				}
			}

			internal readonly AxisRange mIIiZPczxeHAfphksJuAwyyIhJc;

			internal readonly HardwareAxisInfo PlYUFxznkverJWuzpbzUWwQOLjs;

			public float value
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).WtEWgQCHpbhDjFfESxevtlZlFJX;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).lvXCTCWOhrCtuFDbbEqyqyUVPhp;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).dXnAuhulAwehiqyyUsKhIxmmlGI;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).zbTlRpPDVFNVMgeQOZGyokKEojW;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).nmfCWMfUuKHnBMFEcYZgIKMwjDEo;
				}
				internal set
				{
					((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).CbRfqHVsrqTfKytSDNmBtrZHtpK(value);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).EfgWLWEMnhsuRkoPPgoLysSNrHD;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).nmfCWMfUuKHnBMFEcYZgIKMwjDEo - ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).EfgWLWEMnhsuRkoPPgoLysSNrHD;
				}
			}

			public double lastTimeActive
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).ANJDLjNtIDwGjmVFWtpExFYwcVb;
				}
			}

			public double lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).ozlPLzrUVOstanEQARQaCzANtmX;
				}
			}

			public double lastTimeInactive
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).hOFtRmJriTPAVLjFUAUTkduLUqg;
				}
			}

			public double lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).dGpAccauvxxwBJqtLjMlOnZVls;
				}
			}

			public double lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).SkYoLLbwBTBTTsrbrelbFspYEbq;
				}
			}

			public double lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).YEGnyDIkuKGNtZLmTiUrqnfyZAC;
				}
			}

			public double timeActive
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).timeActive;
				}
			}

			public double timeActiveRaw
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).timeActive;
				}
			}

			public double timeInactive
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).timeInactive;
				}
			}

			public double timeInactiveRaw
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).timeInactiveRaw;
				}
			}

			public float pollingDeadZone
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					if (PlYUFxznkverJWuzpbzUWwQOLjs == null)
					{
						return -1f;
					}
					return PlYUFxznkverJWuzpbzUWwQOLjs._pollingDeadZone;
				}
				set
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					if (value < 0f)
					{
						value = -1f;
					}
					if (PlYUFxznkverJWuzpbzUWwQOLjs != null)
					{
						PlYUFxznkverJWuzpbzUWwQOLjs._pollingDeadZone = value;
					}
				}
			}

			internal float selfValue => ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).lvXCTCWOhrCtuFDbbEqyqyUVPhp;

			internal float selfValuePrev => ((REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).zbTlRpPDVFNVMgeQOZGyokKEojW;

			internal float effectivePollingDeadZone
			{
				get
				{
					if (PlYUFxznkverJWuzpbzUWwQOLjs == null)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (PlYUFxznkverJWuzpbzUWwQOLjs._pollingDeadZone >= 0f)
					{
						return PlYUFxznkverJWuzpbzUWwQOLjs._pollingDeadZone;
					}
					return PlYUFxznkverJWuzpbzUWwQOLjs._dataFormat switch
					{
						AxisCoordinateMode.Absolute => ReInput.configuration.defaultAbsoluteAxisPollingDeadZone, 
						AxisCoordinateMode.Relative => ReInput.configuration.defaultRelativeAxisPollingDeadZone, 
						_ => throw new NotImplementedException(), 
					};
				}
			}

			internal void yinHvkwLYKCdkAuHMhncoWTOTvxp(float P_0)
			{
				REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla tDZjwRUFktaJtmvXxDafqhREUla = (REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg;
				tDZjwRUFktaJtmvXxDafqhREUla.dXnAuhulAwehiqyyUsKhIxmmlGI = tDZjwRUFktaJtmvXxDafqhREUla.WtEWgQCHpbhDjFfESxevtlZlFJX;
				tDZjwRUFktaJtmvXxDafqhREUla.WtEWgQCHpbhDjFfESxevtlZlFJX = P_0;
			}

			internal Axis(Controller controller, int elementIdentifierId, string name, AxisRange axisRange, HardwareAxisInfo axisInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Axis)
			{
				pkldeucTgnDEMPziBuveeikAmAF = new REPeWgxCQchujMmvLCjrEJuTKPm(ReInput.configVars.updateLoop);
				mIIiZPczxeHAfphksJuAwyyIhJc = axisRange;
				PlYUFxznkverJWuzpbzUWwQOLjs = axisInfo;
			}

			internal void HDwiRdALLxvIAmnSNVoeBHCYrsG(UpdateLoopType P_0)
			{
				if (pkldeucTgnDEMPziBuveeikAmAF != null && pkldeucTgnDEMPziBuveeikAmAF.xzsHlpfVkUipOIFvAGjOgLamtlLt != (int)P_0)
				{
					pkldeucTgnDEMPziBuveeikAmAF.updateLoop = P_0;
				}
			}

			internal void ufFFYZMrHQyqgOSHtbWQZtKNiSH(AxisCalibration P_0)
			{
				REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla tDZjwRUFktaJtmvXxDafqhREUla = (REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg;
				tDZjwRUFktaJtmvXxDafqhREUla.zbTlRpPDVFNVMgeQOZGyokKEojW = tDZjwRUFktaJtmvXxDafqhREUla.lvXCTCWOhrCtuFDbbEqyqyUVPhp;
				float lvXCTCWOhrCtuFDbbEqyqyUVPhp = P_0.GetCalibratedValue(tDZjwRUFktaJtmvXxDafqhREUla.nmfCWMfUuKHnBMFEcYZgIKMwjDEo, mIIiZPczxeHAfphksJuAwyyIhJc);
				if (P_0.applyRangeCalibration)
				{
					lvXCTCWOhrCtuFDbbEqyqyUVPhp = MathTools.Clamp(lvXCTCWOhrCtuFDbbEqyqyUVPhp, -1f, 1f);
				}
				tDZjwRUFktaJtmvXxDafqhREUla.lvXCTCWOhrCtuFDbbEqyqyUVPhp = lvXCTCWOhrCtuFDbbEqyqyUVPhp;
			}

			internal void ufFFYZMrHQyqgOSHtbWQZtKNiSH()
			{
				REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla tDZjwRUFktaJtmvXxDafqhREUla = (REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg;
				tDZjwRUFktaJtmvXxDafqhREUla.zbTlRpPDVFNVMgeQOZGyokKEojW = tDZjwRUFktaJtmvXxDafqhREUla.lvXCTCWOhrCtuFDbbEqyqyUVPhp;
				tDZjwRUFktaJtmvXxDafqhREUla.lvXCTCWOhrCtuFDbbEqyqyUVPhp = tDZjwRUFktaJtmvXxDafqhREUla.nmfCWMfUuKHnBMFEcYZgIKMwjDEo;
			}

			internal void HoMbxmMIHAknkYYJohvQOkdzoQg()
			{
				REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla tDZjwRUFktaJtmvXxDafqhREUla = (REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg;
				tDZjwRUFktaJtmvXxDafqhREUla.zbTlRpPDVFNVMgeQOZGyokKEojW = tDZjwRUFktaJtmvXxDafqhREUla.lvXCTCWOhrCtuFDbbEqyqyUVPhp;
				tDZjwRUFktaJtmvXxDafqhREUla.lvXCTCWOhrCtuFDbbEqyqyUVPhp = 0f;
			}

			internal void VeybDNgeRuzuipYCxcQLFBZMvKnD()
			{
				REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla tDZjwRUFktaJtmvXxDafqhREUla = (REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg;
				tDZjwRUFktaJtmvXxDafqhREUla.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(base.isMemberElement);
			}

			internal void pCMBGfAndFZFhiJAYgVSmXZFKf(float P_0)
			{
				for (int i = 0; i < pkldeucTgnDEMPziBuveeikAmAF.Data.Count; i++)
				{
					if (pkldeucTgnDEMPziBuveeikAmAF.Data[i] is REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla tDZjwRUFktaJtmvXxDafqhREUla)
					{
						tDZjwRUFktaJtmvXxDafqhREUla.CbRfqHVsrqTfKytSDNmBtrZHtpK(P_0);
						tDZjwRUFktaJtmvXxDafqhREUla.zbTlRpPDVFNVMgeQOZGyokKEojW = tDZjwRUFktaJtmvXxDafqhREUla.lvXCTCWOhrCtuFDbbEqyqyUVPhp;
						tDZjwRUFktaJtmvXxDafqhREUla.lvXCTCWOhrCtuFDbbEqyqyUVPhp = 0f;
						tDZjwRUFktaJtmvXxDafqhREUla.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(base.isMemberElement);
					}
				}
			}

			internal float gVohVLHuWUpHrVjZObwFoNpydjL(UpdateLoopType P_0, AxisCalibration P_1)
			{
				REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla tDZjwRUFktaJtmvXxDafqhREUla = (REPeWgxCQchujMmvLCjrEJuTKPm.tDZjwRUFktaJtmvXxDafqhREUla)pkldeucTgnDEMPziBuveeikAmAF.Data[(int)P_0];
				float result = P_1.GetCalibratedValue(tDZjwRUFktaJtmvXxDafqhREUla.nmfCWMfUuKHnBMFEcYZgIKMwjDEo, mIIiZPczxeHAfphksJuAwyyIhJc, P_1.deadZone, applySensitivity: false, applyInversion: true);
				if (P_1.applyRangeCalibration)
				{
					result = MathTools.Clamp(result, -1f, 1f);
				}
				return result;
			}
		}

		public sealed class Button : Element
		{
			internal class AGCxjuPhOgIoCGujznzFaYbOApey : YYFavhdGVsNIbUaKjsVOXMYlnVR
			{
				public class LTEaQRTssYTnoXQXAMpCmloftEj : tjTJrqnqtNKWRfypZNbpGSZfeVZ
				{
					public bool lvXCTCWOhrCtuFDbbEqyqyUVPhp;

					public bool zbTlRpPDVFNVMgeQOZGyokKEojW;

					public ButtonStateRecorder hINbncBEUJKltBlRUeuYoBIfknxm;

					public PquZCbpjYFkKlBIfdRFwpRnRWHO sCVHtgjCEKMVCiQAalpHjhdabyfx;

					public LTEaQRTssYTnoXQXAMpCmloftEj()
					{
						hINbncBEUJKltBlRUeuYoBIfknxm = new ButtonStateRecorder();
						sCVHtgjCEKMVCiQAalpHjhdabyfx = new PquZCbpjYFkKlBIfdRFwpRnRWHO(0.3f);
					}

					public void aYsFvoceHxJCyLcdXQiYPSoYSvl(bool P_0)
					{
						if (zbTlRpPDVFNVMgeQOZGyokKEojW != lvXCTCWOhrCtuFDbbEqyqyUVPhp)
						{
							zbTlRpPDVFNVMgeQOZGyokKEojW = lvXCTCWOhrCtuFDbbEqyqyUVPhp;
						}
						if (lvXCTCWOhrCtuFDbbEqyqyUVPhp != P_0)
						{
							lvXCTCWOhrCtuFDbbEqyqyUVPhp = P_0;
						}
						hINbncBEUJKltBlRUeuYoBIfknxm.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(P_0 && !zbTlRpPDVFNVMgeQOZGyokKEojW, P_0, ReInput.unscaledTime);
						sCVHtgjCEKMVCiQAalpHjhdabyfx.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(0.3f, P_0 && !zbTlRpPDVFNVMgeQOZGyokKEojW, P_0);
					}

					public override void agvWMBoHtblzmgSmVloJbsDkfGk()
					{
						lvXCTCWOhrCtuFDbbEqyqyUVPhp = false;
						zbTlRpPDVFNVMgeQOZGyokKEojW = false;
						hINbncBEUJKltBlRUeuYoBIfknxm.agvWMBoHtblzmgSmVloJbsDkfGk();
						sCVHtgjCEKMVCiQAalpHjhdabyfx.agvWMBoHtblzmgSmVloJbsDkfGk();
					}
				}

				public class vNaFkZFqHOPCXJDOuGeuqIELOet : LTEaQRTssYTnoXQXAMpCmloftEj
				{
					public float WEheqhHsSNnXsJBeVGhdJUamKyOS;

					public float dHyyFIgElpXcMcBWKAmJPoyjVuk;

					public void aYsFvoceHxJCyLcdXQiYPSoYSvl(float P_0)
					{
						if (dHyyFIgElpXcMcBWKAmJPoyjVuk != WEheqhHsSNnXsJBeVGhdJUamKyOS)
						{
							dHyyFIgElpXcMcBWKAmJPoyjVuk = WEheqhHsSNnXsJBeVGhdJUamKyOS;
						}
						if (WEheqhHsSNnXsJBeVGhdJUamKyOS != P_0)
						{
							WEheqhHsSNnXsJBeVGhdJUamKyOS = ((P_0 > 0.001f) ? P_0 : 0f);
						}
						aYsFvoceHxJCyLcdXQiYPSoYSvl((WEheqhHsSNnXsJBeVGhdJUamKyOS > 0f) ? true : false);
					}

					public override void agvWMBoHtblzmgSmVloJbsDkfGk()
					{
						base.agvWMBoHtblzmgSmVloJbsDkfGk();
						WEheqhHsSNnXsJBeVGhdJUamKyOS = 0f;
						dHyyFIgElpXcMcBWKAmJPoyjVuk = 0f;
					}
				}

				public AGCxjuPhOgIoCGujznzFaYbOApey(UpdateLoopSetting updateCycle, bool isPressureSensitive)
					: base(updateCycle)
				{
					for (int i = 0; i < aMjgVbFAeJESFQCKeNOBqOJWwrB; i++)
					{
						if (isPressureSensitive)
						{
							KKxvXzhbFzmenMQwioAojqUOeaj[i] = new vNaFkZFqHOPCXJDOuGeuqIELOet();
						}
						else
						{
							KKxvXzhbFzmenMQwioAojqUOeaj[i] = new LTEaQRTssYTnoXQXAMpCmloftEj();
						}
					}
					TrWUdtjebjTxiTudwuGvXSlDJgg = KKxvXzhbFzmenMQwioAojqUOeaj[0];
				}

				public void KchEFsezucSEHYhMiyTfqxLZDkz(float P_0)
				{
					for (int i = 0; i < KKxvXzhbFzmenMQwioAojqUOeaj.Length; i++)
					{
						((LTEaQRTssYTnoXQXAMpCmloftEj)KKxvXzhbFzmenMQwioAojqUOeaj[i]).sCVHtgjCEKMVCiQAalpHjhdabyfx.NvdAKrQlqPLyYWDQMUQclkSncjJ(P_0);
					}
				}

				public void kYijQKWgILALBIXmnmztfztDHRuK()
				{
					for (int i = 0; i < KKxvXzhbFzmenMQwioAojqUOeaj.Length; i++)
					{
						((LTEaQRTssYTnoXQXAMpCmloftEj)KKxvXzhbFzmenMQwioAojqUOeaj[i]).sCVHtgjCEKMVCiQAalpHjhdabyfx.NvdAKrQlqPLyYWDQMUQclkSncjJ(0.3f);
					}
				}
			}

			internal readonly bool eQdisGnMMEOIkPANvRwfvFWbGDFH;

			internal readonly HardwareButtonInfo fWxEnTgklXNabkggtTtrimrYIMaN;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).zbTlRpPDVFNVMgeQOZGyokKEojW;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).lvXCTCWOhrCtuFDbbEqyqyUVPhp;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					if (!eQdisGnMMEOIkPANvRwfvFWbGDFH)
					{
						if (!((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).lvXCTCWOhrCtuFDbbEqyqyUVPhp)
						{
							return 0f;
						}
						return 1f;
					}
					return ((AGCxjuPhOgIoCGujznzFaYbOApey.vNaFkZFqHOPCXJDOuGeuqIELOet)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).WEheqhHsSNnXsJBeVGhdJUamKyOS;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0f;
					}
					if (!eQdisGnMMEOIkPANvRwfvFWbGDFH)
					{
						if (!((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).zbTlRpPDVFNVMgeQOZGyokKEojW)
						{
							return 0f;
						}
						return 1f;
					}
					return ((AGCxjuPhOgIoCGujznzFaYbOApey.vNaFkZFqHOPCXJDOuGeuqIELOet)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).dHyyFIgElpXcMcBWKAmJPoyjVuk;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return eQdisGnMMEOIkPANvRwfvFWbGDFH;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (!((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).zbTlRpPDVFNVMgeQOZGyokKEojW && ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).lvXCTCWOhrCtuFDbbEqyqyUVPhp)
					{
						return true;
					}
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).zbTlRpPDVFNVMgeQOZGyokKEojW && !((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).lvXCTCWOhrCtuFDbbEqyqyUVPhp)
					{
						return true;
					}
					return false;
				}
			}

			public bool justChangedState
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).zbTlRpPDVFNVMgeQOZGyokKEojW != ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).lvXCTCWOhrCtuFDbbEqyqyUVPhp)
					{
						return true;
					}
					return false;
				}
			}

			public bool doublePressedAndHeld
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).sCVHtgjCEKMVCiQAalpHjhdabyfx.doublePressHold;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).sCVHtgjCEKMVCiQAalpHjhdabyfx.doublePressHold;
				}
			}

			public double timePressed
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).hINbncBEUJKltBlRUeuYoBIfknxm.timePressed;
				}
			}

			public double timeUnpressed
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).hINbncBEUJKltBlRUeuYoBIfknxm.timeUnpressed;
				}
			}

			public double lastTimePressed
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).hINbncBEUJKltBlRUeuYoBIfknxm.lastTimePressed;
				}
			}

			public double lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).hINbncBEUJKltBlRUeuYoBIfknxm.lastTimeUnpressed;
				}
			}

			public double lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0.0;
					}
					return ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).hINbncBEUJKltBlRUeuYoBIfknxm.lastTimeStateChanged;
				}
			}

			internal ButtonStateFlags state
			{
				get
				{
					AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj lTEaQRTssYTnoXQXAMpCmloftEj = (AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh;
					if (lTEaQRTssYTnoXQXAMpCmloftEj.lvXCTCWOhrCtuFDbbEqyqyUVPhp)
					{
						buttonStateFlags |= ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa;
						if (!lTEaQRTssYTnoXQXAMpCmloftEj.zbTlRpPDVFNVMgeQOZGyokKEojW)
						{
							buttonStateFlags |= ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU;
						}
					}
					else if (lTEaQRTssYTnoXQXAMpCmloftEj.zbTlRpPDVFNVMgeQOZGyokKEojW)
					{
						buttonStateFlags |= ButtonStateFlags.UQGNyIlHcyEjlcCTeYUyHSUqsWj;
					}
					return buttonStateFlags;
				}
			}

			internal Button(Controller controller, int elementIdentifierId, string name, HardwareButtonInfo buttonInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Button)
			{
				fWxEnTgklXNabkggtTtrimrYIMaN = buttonInfo;
				pkldeucTgnDEMPziBuveeikAmAF = new AGCxjuPhOgIoCGujznzFaYbOApey(ReInput.configVars.updateLoop, isPressureSensitive: false);
			}

			internal Button(Controller controller, int elementIdentifierId, string name, bool isPressureSensitive, HardwareButtonInfo buttonInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Button)
			{
				fWxEnTgklXNabkggtTtrimrYIMaN = buttonInfo;
				eQdisGnMMEOIkPANvRwfvFWbGDFH = isPressureSensitive;
				pkldeucTgnDEMPziBuveeikAmAF = new AGCxjuPhOgIoCGujznzFaYbOApey(ReInput.configVars.updateLoop, isPressureSensitive);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return false;
				}
				if (speed <= 0f)
				{
					return ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).sCVHtgjCEKMVCiQAalpHjhdabyfx.doublePressHold;
				}
				return ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).hINbncBEUJKltBlRUeuYoBIfknxm.qqoQTcwXGEOuvgOuoaHFIhKZOIw(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).sCVHtgjCEKMVCiQAalpHjhdabyfx.doublePressHold;
				}
				return ((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).hINbncBEUJKltBlRUeuYoBIfknxm.qqoQTcwXGEOuvgOuoaHFIhKZOIw(speed);
			}

			internal void aYsFvoceHxJCyLcdXQiYPSoYSvl(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (pkldeucTgnDEMPziBuveeikAmAF != null && pkldeucTgnDEMPziBuveeikAmAF.xzsHlpfVkUipOIFvAGjOgLamtlLt != (int)P_0)
				{
					pkldeucTgnDEMPziBuveeikAmAF.updateLoop = P_0;
				}
				if (eQdisGnMMEOIkPANvRwfvFWbGDFH)
				{
					((AGCxjuPhOgIoCGujznzFaYbOApey.vNaFkZFqHOPCXJDOuGeuqIELOet)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).aYsFvoceHxJCyLcdXQiYPSoYSvl(P_2.buttonPressureValues[P_1]);
				}
				else
				{
					((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).aYsFvoceHxJCyLcdXQiYPSoYSvl(P_2.buttonValues[P_1]);
				}
			}

			internal void liCBqUUdAWsLupKdoBvfarDijWb(UpdateLoopType P_0)
			{
				if (pkldeucTgnDEMPziBuveeikAmAF != null && pkldeucTgnDEMPziBuveeikAmAF.xzsHlpfVkUipOIFvAGjOgLamtlLt != (int)P_0)
				{
					pkldeucTgnDEMPziBuveeikAmAF.updateLoop = P_0;
				}
				if (eQdisGnMMEOIkPANvRwfvFWbGDFH)
				{
					((AGCxjuPhOgIoCGujznzFaYbOApey.vNaFkZFqHOPCXJDOuGeuqIELOet)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).aYsFvoceHxJCyLcdXQiYPSoYSvl(0f);
				}
				else
				{
					((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)pkldeucTgnDEMPziBuveeikAmAF.TrWUdtjebjTxiTudwuGvXSlDJgg).aYsFvoceHxJCyLcdXQiYPSoYSvl(false);
				}
			}

			internal void pCMBGfAndFZFhiJAYgVSmXZFKf()
			{
				for (int i = 0; i < pkldeucTgnDEMPziBuveeikAmAF.Data.Count; i++)
				{
					YYFavhdGVsNIbUaKjsVOXMYlnVR.tjTJrqnqtNKWRfypZNbpGSZfeVZ tjTJrqnqtNKWRfypZNbpGSZfeVZ = pkldeucTgnDEMPziBuveeikAmAF.Data[i];
					if (tjTJrqnqtNKWRfypZNbpGSZfeVZ != null)
					{
						if (eQdisGnMMEOIkPANvRwfvFWbGDFH)
						{
							((AGCxjuPhOgIoCGujznzFaYbOApey.vNaFkZFqHOPCXJDOuGeuqIELOet)tjTJrqnqtNKWRfypZNbpGSZfeVZ).aYsFvoceHxJCyLcdXQiYPSoYSvl(0f);
						}
						else
						{
							((AGCxjuPhOgIoCGujznzFaYbOApey.LTEaQRTssYTnoXQXAMpCmloftEj)tjTJrqnqtNKWRfypZNbpGSZfeVZ).aYsFvoceHxJCyLcdXQiYPSoYSvl(false);
						}
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class PChAUcfKDXODZrTIRKbYqJifCuuv
			{
				public readonly Element PROiOPXLPssOzqJmzIHKLhOlSLw;

				public readonly int wHCEUJitVESWMGMqQdXkciHhAsCv;

				public PChAUcfKDXODZrTIRKbYqJifCuuv(Element element, int elementIndex)
				{
					PROiOPXLPssOzqJmzIHKLhOlSLw = element;
					wHCEUJitVESWMGMqQdXkciHhAsCv = elementIndex;
				}
			}

			private int MAfbKattduhdBJEmosLzsDAtqCjp;

			private string qpIGvFaemznETzYbpRdmOKmaPCL;

			private CompoundControllerElementType AkkykLRVUWzqzDOfDtdSigYijIy;

			private int miqLAIiHXdFucCNqFOcSCTFkdXH;

			private PChAUcfKDXODZrTIRKbYqJifCuuv[] fHYhNBaQNYWfQUnIKASBnOPzYNC;

			private Controller frSJxBhFNALntnzeNKOcTHuHKsS;

			internal readonly int VumWnlylMgxSbyJcluXptXvaaZa;

			public int id
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return -1;
					}
					return MAfbKattduhdBJEmosLzsDAtqCjp;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return string.Empty;
					}
					return qpIGvFaemznETzYbpRdmOKmaPCL;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return CompoundControllerElementType.Axis2D;
					}
					return AkkykLRVUWzqzDOfDtdSigYijIy;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return miqLAIiHXdFucCNqFOcSCTFkdXH > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					return miqLAIiHXdFucCNqFOcSCTFkdXH;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = frSJxBhFNALntnzeNKOcTHuHKsS.GetElementIdentifierById(MAfbKattduhdBJEmosLzsDAtqCjp);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			internal CompoundElement(Controller controller, int elementIdentifierId, string name, CompoundControllerElementType type)
			{
				frSJxBhFNALntnzeNKOcTHuHKsS = controller;
				MAfbKattduhdBJEmosLzsDAtqCjp = elementIdentifierId;
				qpIGvFaemznETzYbpRdmOKmaPCL = name;
				AkkykLRVUWzqzDOfDtdSigYijIy = type;
				fHYhNBaQNYWfQUnIKASBnOPzYNC = new PChAUcfKDXODZrTIRKbYqJifCuuv[elementCapacity];
				VumWnlylMgxSbyJcluXptXvaaZa = ReInput.id;
			}

			internal Element mqLOUmOxEQDrMnAgTyphyrVuicA(int P_0)
			{
				if (P_0 < 0 || P_0 >= fHYhNBaQNYWfQUnIKASBnOPzYNC.Length)
				{
					return null;
				}
				if (fHYhNBaQNYWfQUnIKASBnOPzYNC[P_0] == null)
				{
					return null;
				}
				return fHYhNBaQNYWfQUnIKASBnOPzYNC[P_0].PROiOPXLPssOzqJmzIHKLhOlSLw;
			}

			internal T mqLOUmOxEQDrMnAgTyphyrVuicA<T>(int P_0) where T : Element
			{
				if (P_0 < 0 || P_0 >= fHYhNBaQNYWfQUnIKASBnOPzYNC.Length)
				{
					return null;
				}
				if (fHYhNBaQNYWfQUnIKASBnOPzYNC[P_0] == null)
				{
					return null;
				}
				return fHYhNBaQNYWfQUnIKASBnOPzYNC[P_0].PROiOPXLPssOzqJmzIHKLhOlSLw as T;
			}

			internal T cITyZiXogCKEnwwvOgUeTPulzHr<T>(int P_0, out int P_1) where T : Element
			{
				P_1 = -1;
				if (P_0 < 0 || P_0 >= fHYhNBaQNYWfQUnIKASBnOPzYNC.Length)
				{
					return null;
				}
				if (fHYhNBaQNYWfQUnIKASBnOPzYNC[P_0] == null)
				{
					return null;
				}
				P_1 = fHYhNBaQNYWfQUnIKASBnOPzYNC[P_0].wHCEUJitVESWMGMqQdXkciHhAsCv;
				return fHYhNBaQNYWfQUnIKASBnOPzYNC[P_0].PROiOPXLPssOzqJmzIHKLhOlSLw as T;
			}

			internal bool SSjwBZRYcJqbFyjnlHATtvRHxFM(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (miqLAIiHXdFucCNqFOcSCTFkdXH >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (fwbDaChzymRXvBFGPgTvfaASCmdT(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					return false;
				}
				int num = NLxTuWHndPduiieonmqvhiSVNaCD();
				if (num < 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				return bZAfGXCQmFbcZDnmHDaBqmyBDRNb(P_0, P_1, num);
			}

			internal bool kXxCUpsUlYgIEebZEKEIWVvXTzl(Element P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (miqLAIiHXdFucCNqFOcSCTFkdXH == 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				}
				int num = fwbDaChzymRXvBFGPgTvfaASCmdT(P_0);
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				return IMgdLOhgKdgkigGgdnXlhsSqeKhT(num);
			}

			internal void yBsxogjHfuuDtEdmEOAsTSZqnJN()
			{
				for (int i = 0; i < fHYhNBaQNYWfQUnIKASBnOPzYNC.Length; i++)
				{
					IMgdLOhgKdgkigGgdnXlhsSqeKhT(i);
				}
				miqLAIiHXdFucCNqFOcSCTFkdXH = 0;
			}

			private int fwbDaChzymRXvBFGPgTvfaASCmdT(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				for (int i = 0; i < fHYhNBaQNYWfQUnIKASBnOPzYNC.Length; i++)
				{
					if (fHYhNBaQNYWfQUnIKASBnOPzYNC[i] != null && fHYhNBaQNYWfQUnIKASBnOPzYNC[i].PROiOPXLPssOzqJmzIHKLhOlSLw == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private bool bZAfGXCQmFbcZDnmHDaBqmyBDRNb(Element P_0, int P_1, int P_2)
			{
				if (P_2 < 0 || P_2 >= fHYhNBaQNYWfQUnIKASBnOPzYNC.Length)
				{
					return false;
				}
				if (fHYhNBaQNYWfQUnIKASBnOPzYNC[P_2] != null)
				{
					return false;
				}
				fHYhNBaQNYWfQUnIKASBnOPzYNC[P_2] = new PChAUcfKDXODZrTIRKbYqJifCuuv(P_0, P_1);
				P_0.reRAUCJEGyKXOXrFHDJjhvkiueE();
				miqLAIiHXdFucCNqFOcSCTFkdXH++;
				return true;
			}

			private bool IMgdLOhgKdgkigGgdnXlhsSqeKhT(int P_0)
			{
				if (P_0 < 0 || P_0 >= fHYhNBaQNYWfQUnIKASBnOPzYNC.Length)
				{
					return false;
				}
				if (fHYhNBaQNYWfQUnIKASBnOPzYNC[P_0] == null)
				{
					return false;
				}
				if (fHYhNBaQNYWfQUnIKASBnOPzYNC[P_0].PROiOPXLPssOzqJmzIHKLhOlSLw != null)
				{
					fHYhNBaQNYWfQUnIKASBnOPzYNC[P_0].PROiOPXLPssOzqJmzIHKLhOlSLw.SktnbLHKdKzyJMdCYBSokIvWCARP();
				}
				fHYhNBaQNYWfQUnIKASBnOPzYNC[P_0] = null;
				miqLAIiHXdFucCNqFOcSCTFkdXH--;
				return true;
			}

			private int NLxTuWHndPduiieonmqvhiSVNaCD()
			{
				for (int i = 0; i < fHYhNBaQNYWfQUnIKASBnOPzYNC.Length; i++)
				{
					if (fHYhNBaQNYWfQUnIKASBnOPzYNC[i] == null)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int eyJXoRkPqEytvxlYgrhRdagSrJa = 2;

			private CalibrationMap DUdtRPKkaCSmJggwvCzYFANfomFJ;

			public override int elementCapacity => 2;

			public Axis xAxis
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return mqLOUmOxEQDrMnAgTyphyrVuicA<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return mqLOUmOxEQDrMnAgTyphyrVuicA<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector2.zero;
					}
					return WgELRhxDVLLXQvIYhjoZEYnXbqF();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector2.zero;
					}
					return OIjYhWtiDrmHcFoQqiBnhNEDgZe();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller controller, int elementIdentifierId, string name, Axis xAxis, Axis yAxis, int xAxisIndex, int yAxisIndex, CalibrationMap calibratonMap)
				: base(controller, elementIdentifierId, name, CompoundControllerElementType.Axis2D)
			{
				SSjwBZRYcJqbFyjnlHATtvRHxFM(xAxis, xAxisIndex);
				SSjwBZRYcJqbFyjnlHATtvRHxFM(yAxis, yAxisIndex);
				DUdtRPKkaCSmJggwvCzYFANfomFJ = calibratonMap;
			}

			internal void VEShBtNHGklmRUxZTegSZNXZpDo()
			{
				Vector2 vector = value;
				if (xAxis != null)
				{
					xAxis.yinHvkwLYKCdkAuHMhncoWTOTvxp(vector.x);
				}
				if (yAxis != null)
				{
					yAxis.yinHvkwLYKCdkAuHMhncoWTOTvxp(vector.y);
				}
			}

			private Vector2 WgELRhxDVLLXQvIYhjoZEYnXbqF()
			{
				if (DUdtRPKkaCSmJggwvCzYFANfomFJ == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = cITyZiXogCKEnwwvOgUeTPulzHr<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = cITyZiXogCKEnwwvOgUeTPulzHr<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRaw ?? 0f;
				float valueRawY = axis2?.valueRaw ?? 0f;
				return DUdtRPKkaCSmJggwvCzYFANfomFJ.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}

			private Vector2 OIjYhWtiDrmHcFoQqiBnhNEDgZe()
			{
				if (DUdtRPKkaCSmJggwvCzYFANfomFJ == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = cITyZiXogCKEnwwvOgUeTPulzHr<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = cITyZiXogCKEnwwvOgUeTPulzHr<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRawPrev ?? 0f;
				float valueRawY = axis2?.valueRawPrev ?? 0f;
				return DUdtRPKkaCSmJggwvCzYFANfomFJ.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int eyJXoRkPqEytvxlYgrhRdagSrJa = 8;

			private const int PfXHDqIAXDetYRbFzWEcHWyFfuT = 0;

			private const int aARJaBtyLfKTFVGvPaItcenrnTy = 1;

			private const int RSWWJaTumexkSdPRrreRNxesGhs = 2;

			private const int stIDcRELbCOfOzmadrAIChtIsRUG = 3;

			private const int RccuKDplCvBBnAOKtiSCnIvZjzq = 4;

			private const int DYwHImRIVYrBPcdICRwFDnNCohw = 5;

			private const int FmQfhNJXcGPCrAeZRLSFEDRmYSG = 6;

			private const int cEsxhxUJzycKzAuDyhZamXMradyX = 7;

			private readonly int BIqrSHxnfVeJEnjKdnGBTolrmbG;

			private readonly Button[] BSdobvxzcvULrRIsWxFTPPpGtUR;

			private readonly ReadOnlyCollection<Button> gkjvdFmAbySauKejxDKCszWJGfl;

			private readonly int[] ruKuWNfVCvWTuSHnUSAIsEprZxR;

			private bool VuDbESzaNnOyBAoVGpaXEcaukzs;

			public override int elementCapacity => 8;

			public bool force4Way
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return VuDbESzaNnOyBAoVGpaXEcaukzs;
				}
				set
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						VuDbESzaNnOyBAoVGpaXEcaukzs = value;
					}
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					return BIqrSHxnfVeJEnjKdnGBTolrmbG;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return gkjvdFmAbySauKejxDKCszWJGfl;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return mqLOUmOxEQDrMnAgTyphyrVuicA<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return mqLOUmOxEQDrMnAgTyphyrVuicA<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return mqLOUmOxEQDrMnAgTyphyrVuicA<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return mqLOUmOxEQDrMnAgTyphyrVuicA<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return mqLOUmOxEQDrMnAgTyphyrVuicA<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return mqLOUmOxEQDrMnAgTyphyrVuicA<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return mqLOUmOxEQDrMnAgTyphyrVuicA<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return mqLOUmOxEQDrMnAgTyphyrVuicA<Button>(7);
				}
			}

			internal Hat(Controller controller, int elementIdentifierId, string name, Button[] buttons, int[] buttonIndices)
				: base(controller, elementIdentifierId, name, CompoundControllerElementType.Hat)
			{
				int num = ((buttons != null) ? buttons.Length : 0);
				if (num != ((buttonIndices != null) ? buttonIndices.Length : 0))
				{
					throw new ArgumentException("button.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4 && num != 8)
				{
					throw new ArgumentException("button.Length must be 0, 4, or 8! Length: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					SSjwBZRYcJqbFyjnlHATtvRHxFM(buttons[i], buttonIndices[i]);
				}
				BSdobvxzcvULrRIsWxFTPPpGtUR = buttons;
				ruKuWNfVCvWTuSHnUSAIsEprZxR = buttonIndices;
				BIqrSHxnfVeJEnjKdnGBTolrmbG = num;
				gkjvdFmAbySauKejxDKCszWJGfl = new ReadOnlyCollection<Button>(buttons);
			}

			internal void VEShBtNHGklmRUxZTegSZNXZpDo(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (BIqrSHxnfVeJEnjKdnGBTolrmbG == 0)
				{
					return;
				}
				if (BIqrSHxnfVeJEnjKdnGBTolrmbG == 8 && (VuDbESzaNnOyBAoVGpaXEcaukzs || ReInput.configVars.force4WayHats))
				{
					epZSEWPIzderKaKUVnfkrVTUpoG(BSdobvxzcvULrRIsWxFTPPpGtUR[0], ruKuWNfVCvWTuSHnUSAIsEprZxR[0], ruKuWNfVCvWTuSHnUSAIsEprZxR[7], ruKuWNfVCvWTuSHnUSAIsEprZxR[1], P_0, P_1);
					epZSEWPIzderKaKUVnfkrVTUpoG(BSdobvxzcvULrRIsWxFTPPpGtUR[2], ruKuWNfVCvWTuSHnUSAIsEprZxR[2], ruKuWNfVCvWTuSHnUSAIsEprZxR[1], ruKuWNfVCvWTuSHnUSAIsEprZxR[3], P_0, P_1);
					epZSEWPIzderKaKUVnfkrVTUpoG(BSdobvxzcvULrRIsWxFTPPpGtUR[4], ruKuWNfVCvWTuSHnUSAIsEprZxR[4], ruKuWNfVCvWTuSHnUSAIsEprZxR[5], ruKuWNfVCvWTuSHnUSAIsEprZxR[3], P_0, P_1);
					epZSEWPIzderKaKUVnfkrVTUpoG(BSdobvxzcvULrRIsWxFTPPpGtUR[6], ruKuWNfVCvWTuSHnUSAIsEprZxR[6], ruKuWNfVCvWTuSHnUSAIsEprZxR[5], ruKuWNfVCvWTuSHnUSAIsEprZxR[7], P_0, P_1);
					vaLRiCZbMQnGZWcBpfiQhFrmDgz(BSdobvxzcvULrRIsWxFTPPpGtUR[1], ruKuWNfVCvWTuSHnUSAIsEprZxR[1], P_0, P_1);
					vaLRiCZbMQnGZWcBpfiQhFrmDgz(BSdobvxzcvULrRIsWxFTPPpGtUR[3], ruKuWNfVCvWTuSHnUSAIsEprZxR[3], P_0, P_1);
					vaLRiCZbMQnGZWcBpfiQhFrmDgz(BSdobvxzcvULrRIsWxFTPPpGtUR[5], ruKuWNfVCvWTuSHnUSAIsEprZxR[5], P_0, P_1);
					vaLRiCZbMQnGZWcBpfiQhFrmDgz(BSdobvxzcvULrRIsWxFTPPpGtUR[7], ruKuWNfVCvWTuSHnUSAIsEprZxR[7], P_0, P_1);
					return;
				}
				for (int i = 0; i < BSdobvxzcvULrRIsWxFTPPpGtUR.Length; i++)
				{
					if (BSdobvxzcvULrRIsWxFTPPpGtUR[i] != null)
					{
						BSdobvxzcvULrRIsWxFTPPpGtUR[i].aYsFvoceHxJCyLcdXQiYPSoYSvl(P_0, ruKuWNfVCvWTuSHnUSAIsEprZxR[i], P_1);
					}
				}
			}

			private void epZSEWPIzderKaKUVnfkrVTUpoG(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
			{
				if (P_0 == null || P_1 < 0 || P_1 >= P_5.buttonCount)
				{
					return;
				}
				if (!P_0.isPressureSensitive)
				{
					if (P_2 >= 0 && P_2 < P_5.buttonCount)
					{
						ref bool reference = ref P_5.buttonValues[P_1];
						reference |= P_5.buttonValues[P_2];
					}
					if (P_3 >= 0 && P_3 < P_5.buttonCount)
					{
						ref bool reference2 = ref P_5.buttonValues[P_1];
						reference2 |= P_5.buttonValues[P_3];
					}
				}
				else
				{
					P_5.buttonPressureValues[P_1] = MathTools.MaxMagnitude(P_5.buttonPressureValues[P_1], MathTools.MaxMagnitude((P_2 >= 0 && P_2 < P_5.buttonCount) ? P_5.buttonPressureValues[P_2] : 0f, (P_3 >= 0 && P_3 < P_5.buttonCount) ? P_5.buttonPressureValues[P_3] : 0f));
				}
				P_0.aYsFvoceHxJCyLcdXQiYPSoYSvl(P_4, P_1, P_5);
			}

			private void vaLRiCZbMQnGZWcBpfiQhFrmDgz(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
			{
				if (P_0 != null && P_1 >= 0 && P_1 < P_3.buttonCount)
				{
					if (!P_0.isPressureSensitive)
					{
						P_3.buttonValues[P_1] = false;
					}
					else
					{
						P_3.buttonPressureValues[P_1] = 0f;
					}
					P_0.aYsFvoceHxJCyLcdXQiYPSoYSvl(P_2, P_1, P_3);
				}
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller frSJxBhFNALntnzeNKOcTHuHKsS;

			private IControllerExtensionSource fzzXbvFoZzdAqHDolrszRhFTkOz;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (frSJxBhFNALntnzeNKOcTHuHKsS == null)
					{
						return false;
					}
					return frSJxBhFNALntnzeNKOcTHuHKsS._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (frSJxBhFNALntnzeNKOcTHuHKsS == null)
					{
						return false;
					}
					return frSJxBhFNALntnzeNKOcTHuHKsS.enabled;
				}
			}

			internal Controller controller => frSJxBhFNALntnzeNKOcTHuHKsS;

			internal Extension(IControllerExtensionSource source)
			{
				_reInputId = ReInput.id;
				VHZOplAgZGnDXrRlCLXEbyTodOL(source);
			}

			internal Extension(Extension source)
				: this(source.fzzXbvFoZzdAqHDolrszRhFTkOz)
			{
				frSJxBhFNALntnzeNKOcTHuHKsS = source.frSJxBhFNALntnzeNKOcTHuHKsS;
			}

			internal T GetController<T>() where T : Controller
			{
				if (frSJxBhFNALntnzeNKOcTHuHKsS == null)
				{
					return null;
				}
				return frSJxBhFNALntnzeNKOcTHuHKsS as T;
			}

			internal void SetController(Controller controller)
			{
				frSJxBhFNALntnzeNKOcTHuHKsS = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return fzzXbvFoZzdAqHDolrszRhFTkOz;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					VHZOplAgZGnDXrRlCLXEbyTodOL(null);
				}
				else
				{
					VHZOplAgZGnDXrRlCLXEbyTodOL(extension.fzzXbvFoZzdAqHDolrszRhFTkOz);
				}
			}

			private void VHZOplAgZGnDXrRlCLXEbyTodOL(IControllerExtensionSource P_0)
			{
				fzzXbvFoZzdAqHDolrszRhFTkOz = P_0;
				SourceUpdated(fzzXbvFoZzdAqHDolrszRhFTkOz);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		private sealed class IvgbXLLPBbFxeebTdiBljIPDeAwo : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public Controller GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int ruJbLfoHPdAHKbMrcgEkYTYDkQVf;

			public int yWZJxYWZcVrvBHtXEtLwFBfGdLIH;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				IvgbXLLPBbFxeebTdiBljIPDeAwo ivgbXLLPBbFxeebTdiBljIPDeAwo;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					ivgbXLLPBbFxeebTdiBljIPDeAwo = this;
				}
				else
				{
					ivgbXLLPBbFxeebTdiBljIPDeAwo = new IvgbXLLPBbFxeebTdiBljIPDeAwo(0);
					ivgbXLLPBbFxeebTdiBljIPDeAwo.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				return ivgbXLLPBbFxeebTdiBljIPDeAwo;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
						break;
					}
					GxphHAMqMhNBLjnlhXuBQmXaALiE.UpdatePollingFrameTracking();
					ruJbLfoHPdAHKbMrcgEkYTYDkQVf = 0;
					goto IL_00ea;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_00dc;
					}
					IL_00ea:
					if (ruJbLfoHPdAHKbMrcgEkYTYDkQVf >= GxphHAMqMhNBLjnlhXuBQmXaALiE._buttonCount)
					{
						break;
					}
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.tWyyUhLBjTfQQyGhrbEFaQCMyds(ruJbLfoHPdAHKbMrcgEkYTYDkQVf, out yWZJxYWZcVrvBHtXEtLwFBfGdLIH))
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = new ControllerPollingInfo(success: true, -1, GxphHAMqMhNBLjnlhXuBQmXaALiE.id, GxphHAMqMhNBLjnlhXuBQmXaALiE._name, GxphHAMqMhNBLjnlhXuBQmXaALiE._type, ControllerElementType.Button, ruJbLfoHPdAHKbMrcgEkYTYDkQVf, Pole.Positive, GxphHAMqMhNBLjnlhXuBQmXaALiE.rEqQznEUmYwtoLNJsErzjlKjjYY.GetElementIdentifierName(yWZJxYWZcVrvBHtXEtLwFBfGdLIH), yWZJxYWZcVrvBHtXEtLwFBfGdLIH, KeyCode.None);
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						return true;
					}
					goto IL_00dc;
					IL_00dc:
					ruJbLfoHPdAHKbMrcgEkYTYDkQVf++;
					goto IL_00ea;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public IvgbXLLPBbFxeebTdiBljIPDeAwo(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class DRydwjCRJZMWzEbGbClLGkpCyqee : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public Controller GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int fCAGNNAyppDTdvaeZJQkvckPjfa;

			public int LevejuThGUVumQxbMqEiqzrFVJY;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				DRydwjCRJZMWzEbGbClLGkpCyqee dRydwjCRJZMWzEbGbClLGkpCyqee;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					dRydwjCRJZMWzEbGbClLGkpCyqee = this;
				}
				else
				{
					dRydwjCRJZMWzEbGbClLGkpCyqee = new DRydwjCRJZMWzEbGbClLGkpCyqee(0);
					dRydwjCRJZMWzEbGbClLGkpCyqee.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				return dRydwjCRJZMWzEbGbClLGkpCyqee;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
						break;
					}
					GxphHAMqMhNBLjnlhXuBQmXaALiE.UpdatePollingFrameTracking();
					fCAGNNAyppDTdvaeZJQkvckPjfa = 0;
					goto IL_00ea;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_00dc;
					}
					IL_00ea:
					if (fCAGNNAyppDTdvaeZJQkvckPjfa >= GxphHAMqMhNBLjnlhXuBQmXaALiE._buttonCount)
					{
						break;
					}
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.fqnSXJIECUuXLVAcRYAMrDrDtXM(fCAGNNAyppDTdvaeZJQkvckPjfa, out LevejuThGUVumQxbMqEiqzrFVJY))
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = new ControllerPollingInfo(success: true, -1, GxphHAMqMhNBLjnlhXuBQmXaALiE.id, GxphHAMqMhNBLjnlhXuBQmXaALiE._name, GxphHAMqMhNBLjnlhXuBQmXaALiE._type, ControllerElementType.Button, fCAGNNAyppDTdvaeZJQkvckPjfa, Pole.Positive, GxphHAMqMhNBLjnlhXuBQmXaALiE.rEqQznEUmYwtoLNJsErzjlKjjYY.GetElementIdentifierName(LevejuThGUVumQxbMqEiqzrFVJY), LevejuThGUVumQxbMqEiqzrFVJY, KeyCode.None);
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						return true;
					}
					goto IL_00dc;
					IL_00dc:
					fCAGNNAyppDTdvaeZJQkvckPjfa++;
					goto IL_00ea;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public DRydwjCRJZMWzEbGbClLGkpCyqee(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		public readonly int id;

		protected string _tag;

		protected string _name;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid whqrPnRNEDctHvdjThUpHsqpUGr;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension hROuCGhdASTVBaBVhwSmSNLFQTP;

		private bool fnEBjitvkHhPtXTzRLmBYpIxFbt;

		private ControllerIdentifier QXZxcyuIcKDcyTLEKHYgHgSjPRP;

		internal int VumWnlylMgxSbyJcluXptXvaaZa;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> omxIKEAXItSjJrzFPUwpagFQPsi;

		private readonly ReadOnlyCollection<Element> WOxVRRtZDKwuVNgdENoHiNyWQgT;

		internal readonly InputSource iRyNPwfaIbylCKBnafrigDzkSzy;

		internal readonly ControllerDataUpdater QlXkhNBHPYUNWwhKurdwrqFgWTf;

		internal readonly HardwareControllerMap_Game rEqQznEUmYwtoLNJsErzjlKjjYY;

		internal uint vqxXpHkrAYztQxTWVORrRrBeeU;

		private uint fMeQlMcORDaFGBVMlftWCGxhvgGW;

		private uint kwqgRQKclbIvjfDLGFogCfAhiWCa;

		private Action<bool> tGjExmrsAcHOmVrgLTgCsqJPOrA;

		private IControllerTemplate[] CiMviYvMxazKwgqWQRkNHbQqbMV;

		private ReadOnlyCollection<IControllerTemplate> QHAAdVrmdINLwSrzPkAJVjuWtgi;

		private static Func<Controller, Guid, bool> xAbjJIbweBjHqeqKlfdDakofLdV;

		private static Func<Controller, Type, bool> mAJCIgdkjaqdOTAwFSQHWtEtDrmY;

		[CompilerGenerated]
		private static Func<Controller, Guid, bool> qHBJmKNCVjycjQRAvhwoDOstoTn;

		[CompilerGenerated]
		private static Func<Controller, Type, bool> hXecteAuDBMixCRzxtdbRatMBIs;

		internal bool wasPollingPrev => fMeQlMcORDaFGBVMlftWCGxhvgGW == ReInput.previousFrame;

		public bool enabled
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return false;
				}
				return fnEBjitvkHhPtXTzRLmBYpIxFbt;
			}
			set
			{
				WyEAtncPpRVmZFtqAefsZKfkUci(value);
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return string.Empty;
				}
				return _name;
			}
			internal set
			{
				_name = value;
			}
		}

		public string tag
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					_tag = value;
				}
			}
		}

		public string hardwareName
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Guid.Empty;
				}
				return whqrPnRNEDctHvdjThUpHsqpUGr;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier => QXZxcyuIcKDcyTLEKHYgHgSjPRP;

		public bool isConnected
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else if (!value)
				{
					Disconnected();
				}
				else
				{
					Connected();
				}
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return string.Empty;
				}
				return _hardwareIdentifier;
			}
		}

		public string mapTypeString => _type.ToString() + "Map";

		public int elementCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				return omxIKEAXItSjJrzFPUwpagFQPsi.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return WOxVRRtZDKwuVNgdENoHiNyWQgT;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return hROuCGhdASTVBaBVhwSmSNLFQTP;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return rEqQznEUmYwtoLNJsErzjlKjjYY.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return rEqQznEUmYwtoLNJsErzjlKjjYY.buttonElementIdentifiers_readOnly;
			}
		}

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return QHAAdVrmdINLwSrzPkAJVjuWtgi;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				return CiMviYvMxazKwgqWQRkNHbQqbMV.Length;
			}
		}

		internal static Func<Controller, Guid, bool> implementsTemplateDelegate_Guid => (Controller P_0, Guid P_1) => P_0.ImplementsTemplate(P_1);

		internal static Func<Controller, Type, bool> implementsTemplateDelegate_Type => (Controller P_0, Type P_1) => P_0.ImplementsTemplate(P_1);

		internal event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				tGjExmrsAcHOmVrgLTgCsqJPOrA = (Action<bool>)Delegate.Combine(tGjExmrsAcHOmVrgLTgCsqJPOrA, value);
			}
			remove
			{
				tGjExmrsAcHOmVrgLTgCsqJPOrA = (Action<bool>)Delegate.Remove(tGjExmrsAcHOmVrgLTgCsqJPOrA, value);
			}
		}

		internal Controller(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, ControllerType type, Guid hardwareTypeGuid, int buttonCount, bool[] isButtonPressureSensitive, HardwareButtonInfo[] hwButtonInfo, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
		{
			id = controllerId;
			iRyNPwfaIbylCKBnafrigDzkSzy = inputSource;
			_type = type;
			whqrPnRNEDctHvdjThUpHsqpUGr = hardwareTypeGuid;
			_buttonCount = buttonCount;
			_name = name;
			_hardwareName = hardwareName;
			_hardwareIdentifier = hardwareIdentifier;
			QlXkhNBHPYUNWwhKurdwrqFgWTf = dataUpdater;
			rEqQznEUmYwtoLNJsErzjlKjjYY = hardwareMap;
			fnEBjitvkHhPtXTzRLmBYpIxFbt = true;
			VumWnlylMgxSbyJcluXptXvaaZa = ReInput.id;
			MQlLBrEAWyhDmoKqYimFKMGgKUX(extension);
			omxIKEAXItSjJrzFPUwpagFQPsi = new List<Element>(buttonCount);
			WOxVRRtZDKwuVNgdENoHiNyWQgT = new ReadOnlyCollection<Element>(omxIKEAXItSjJrzFPUwpagFQPsi);
			buttons = new Button[buttonCount];
			if (isButtonPressureSensitive == null || isButtonPressureSensitive.Length < buttonCount)
			{
				for (int i = 0; i < buttonCount; i++)
				{
					buttons[i] = new Button(this, hardwareMap.buttonElementIdentifierIds[i], "Button " + i, isPressureSensitive: false, (hwButtonInfo != null) ? hwButtonInfo[i] : new HardwareButtonInfo());
					SSjwBZRYcJqbFyjnlHATtvRHxFM(buttons[i]);
				}
			}
			else
			{
				for (int j = 0; j < buttonCount; j++)
				{
					buttons[j] = new Button(this, hardwareMap.buttonElementIdentifierIds[j], "Button " + j, isButtonPressureSensitive[j], (hwButtonInfo != null) ? hwButtonInfo[j] : new HardwareButtonInfo());
					SSjwBZRYcJqbFyjnlHATtvRHxFM(buttons[j]);
				}
			}
			buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
			CiMviYvMxazKwgqWQRkNHbQqbMV = EmptyObjects<IControllerTemplate>.array;
			QHAAdVrmdINLwSrzPkAJVjuWtgi = new ReadOnlyCollection<IControllerTemplate>(CiMviYvMxazKwgqWQRkNHbQqbMV);
			Connected();
		}

		internal virtual void ANKdbHXpmTNShTcixGbSxMIpqJK()
		{
			QXZxcyuIcKDcyTLEKHYgHgSjPRP = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			if (rEqQznEUmYwtoLNJsErzjlKjjYY == null)
			{
				return null;
			}
			int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0)
			{
				return null;
			}
			return buttons[buttonIndex];
		}

		public int GetButtonIndexById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return -1;
			}
			return rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			return rEqQznEUmYwtoLNJsErzjlKjjYY.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].value;
		}

		public virtual bool GetButtonDown(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].justPressed;
		}

		public virtual bool GetButtonUp(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].justReleased;
		}

		public virtual bool GetButtonChanged(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].value != buttons[index].valuePrev;
		}

		public virtual bool GetButtonPrev(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].valuePrev;
		}

		public virtual bool GetButtonDoublePressHold(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDown(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].JustDoublePressed(speed);
		}

		public virtual double GetButtonTimePressed(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].timePressed;
		}

		public virtual double GetButtonTimeUnpressed(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressed(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressed(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].lastTimeUnpressed;
		}

		public virtual bool GetAnyButton()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].value)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonDown()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justPressed)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonUp()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justReleased)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonPrev()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].valuePrev)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonChanged()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justChangedState)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetButtonById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].value;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justPressed;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justReleased;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].JustDoublePressed(speed);
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].valuePrev;
		}

		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timePressed;
		}

		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			int buttonIndex = rEqQznEUmYwtoLNJsErzjlKjjYY.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimeUnpressed;
		}

		public virtual ControllerPollingInfo PollForFirstElement()
		{
			return PollForFirstButton();
		}

		public virtual ControllerPollingInfo PollForFirstElementDown()
		{
			return PollForFirstButtonDown();
		}

		public virtual ControllerPollingInfo PollForFirstButton()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (tWyyUhLBjTfQQyGhrbEFaQCMyds(i, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, rEqQznEUmYwtoLNJsErzjlKjjYY.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (fqnSXJIECUuXLVAcRYAMrDrDtXM(i, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, rEqQznEUmYwtoLNJsErzjlKjjYY.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return PollForAllButtons();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return PollForAllButtonsDown();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			IvgbXLLPBbFxeebTdiBljIPDeAwo ivgbXLLPBbFxeebTdiBljIPDeAwo = new IvgbXLLPBbFxeebTdiBljIPDeAwo(-2);
			ivgbXLLPBbFxeebTdiBljIPDeAwo.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			return ivgbXLLPBbFxeebTdiBljIPDeAwo;
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			DRydwjCRJZMWzEbGbClLGkpCyqee dRydwjCRJZMWzEbGbClLGkpCyqee = new DRydwjCRJZMWzEbGbClLGkpCyqee(-2);
			dRydwjCRJZMWzEbGbClLGkpCyqee.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			return dRydwjCRJZMWzEbGbClLGkpCyqee;
		}

		private bool tWyyUhLBjTfQQyGhrbEFaQCMyds(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].value || buttons[P_0].fWxEnTgklXNabkggtTtrimrYIMaN._excludeFromPolling)
			{
				return false;
			}
			P_1 = rEqQznEUmYwtoLNJsErzjlKjjYY.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		private bool fqnSXJIECUuXLVAcRYAMrDrDtXM(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].justPressed || buttons[P_0].fWxEnTgklXNabkggtTtrimrYIMaN._excludeFromPolling)
			{
				return false;
			}
			P_1 = rEqQznEUmYwtoLNJsErzjlKjjYY.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		protected void UpdatePollingFrameTracking()
		{
			if (kwqgRQKclbIvjfDLGFogCfAhiWCa == ReInput.currentFrame)
			{
				return;
			}
			fMeQlMcORDaFGBVMlftWCGxhvgGW = kwqgRQKclbIvjfDLGFogCfAhiWCa;
			kwqgRQKclbIvjfDLGFogCfAhiWCa = ReInput.currentFrame;
			if (!wasPollingPrev)
			{
				if (vqxXpHkrAYztQxTWVORrRrBeeU == uint.MaxValue)
				{
					vqxXpHkrAYztQxTWVORrRrBeeU = 0u;
				}
				else
				{
					vqxXpHkrAYztQxTWVORrRrBeeU++;
				}
			}
		}

		public virtual double GetLastTimeActive()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public virtual double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual double GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public double GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			if (buttons == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < buttons.Length; i++)
			{
				double lastTimePressed = buttons[i].lastTimePressed;
				if (lastTimePressed > num)
				{
					num = lastTimePressed;
				}
			}
			return num;
		}

		public double GetLastTimeAnyButtonChanged()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			if (buttons == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < buttons.Length; i++)
			{
				double lastTimeStateChanged = buttons[i].lastTimeStateChanged;
				if (lastTimeStateChanged > num)
				{
					num = lastTimeStateChanged;
				}
			}
			return num;
		}

		public T GetExtension<T>() where T : class
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			return hROuCGhdASTVBaBVhwSmSNLFQTP as T;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			for (int i = 0; i < CiMviYvMxazKwgqWQRkNHbQqbMV.Length; i++)
			{
				if (CiMviYvMxazKwgqWQRkNHbQqbMV[i].typeGuid == typeGuid)
				{
					return CiMviYvMxazKwgqWQRkNHbQqbMV[i];
				}
			}
			return null;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			for (int i = 0; i < CiMviYvMxazKwgqWQRkNHbQqbMV.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(CiMviYvMxazKwgqWQRkNHbQqbMV[i].GetType(), type))
				{
					return CiMviYvMxazKwgqWQRkNHbQqbMV[i];
				}
			}
			return null;
		}

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			for (int i = 0; i < CiMviYvMxazKwgqWQRkNHbQqbMV.Length; i++)
			{
				if (CiMviYvMxazKwgqWQRkNHbQqbMV[i] as T != null)
				{
					return CiMviYvMxazKwgqWQRkNHbQqbMV[i] as T;
				}
			}
			return null;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			for (int i = 0; i < CiMviYvMxazKwgqWQRkNHbQqbMV.Length; i++)
			{
				if (CiMviYvMxazKwgqWQRkNHbQqbMV[i].typeGuid == typeGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			for (int i = 0; i < CiMviYvMxazKwgqWQRkNHbQqbMV.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(CiMviYvMxazKwgqWQRkNHbQqbMV[i].GetType(), type))
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate<T>() where T : class
		{
			return ImplementsTemplate(typeof(T));
		}

		internal void VPmIumURnacprhihAJMOLbDiKmb(IControllerTemplate[] P_0)
		{
			if (P_0 != null)
			{
				CiMviYvMxazKwgqWQRkNHbQqbMV = P_0;
				QHAAdVrmdINLwSrzPkAJVjuWtgi = new ReadOnlyCollection<IControllerTemplate>(CiMviYvMxazKwgqWQRkNHbQqbMV);
			}
		}

		internal virtual void KcNfORqUkjxfSzjWExwXXCRKlZu(UpdateLoopType P_0)
		{
			bool flag = ReInput.IsInputAllowed(_type);
			int num = _buttonCount;
			if (flag)
			{
				for (int i = 0; i < num; i++)
				{
					if (buttons[i].QdmQKcVfQWABUruEwPDVptuKFDI <= 0)
					{
						buttons[i].aYsFvoceHxJCyLcdXQiYPSoYSvl(P_0, i, QlXkhNBHPYUNWwhKurdwrqFgWTf);
					}
				}
			}
			else
			{
				for (int j = 0; j < num; j++)
				{
					if (buttons[j].QdmQKcVfQWABUruEwPDVptuKFDI <= 0)
					{
						buttons[j].liCBqUUdAWsLupKdoBvfarDijWb(P_0);
					}
				}
			}
			if (hROuCGhdASTVBaBVhwSmSNLFQTP != null)
			{
				hROuCGhdASTVBaBVhwSmSNLFQTP.UpdateData(P_0);
			}
		}

		internal virtual ButtonStateFlags SWrixoLkyvQSLlmQGIDCFFrrltz(int P_0)
		{
			if (P_0 < 0 || P_0 >= _buttonCount)
			{
				return ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh;
			}
			return buttons[P_0].state;
		}

		internal void MQlLBrEAWyhDmoKqYimFKMGgKUX(Extension P_0)
		{
			if (P_0 == null)
			{
				hROuCGhdASTVBaBVhwSmSNLFQTP = null;
				return;
			}
			if (hROuCGhdASTVBaBVhwSmSNLFQTP != null)
			{
				MaqBxIfsVBIKoTpaiokNgulHaUMu(P_0);
				return;
			}
			P_0.SetController(this);
			hROuCGhdASTVBaBVhwSmSNLFQTP = P_0.Clone();
		}

		internal void MaqBxIfsVBIKoTpaiokNgulHaUMu(Extension P_0)
		{
			if (hROuCGhdASTVBaBVhwSmSNLFQTP != null)
			{
				hROuCGhdASTVBaBVhwSmSNLFQTP.SetSource(P_0);
				hROuCGhdASTVBaBVhwSmSNLFQTP.SetController(this);
				P_0?.SetController(this);
			}
			else
			{
				MQlLBrEAWyhDmoKqYimFKMGgKUX(P_0);
			}
		}

		internal virtual void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
		{
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i] != null)
				{
					buttons[i].Reset();
				}
			}
			if (QlXkhNBHPYUNWwhKurdwrqFgWTf != null)
			{
				QlXkhNBHPYUNWwhKurdwrqFgWTf.ClearData();
			}
			if (hROuCGhdASTVBaBVhwSmSNLFQTP != null)
			{
				hROuCGhdASTVBaBVhwSmSNLFQTP.Clear();
			}
		}

		internal virtual bool WyEAtncPpRVmZFtqAefsZKfkUci(bool P_0)
		{
			if (fnEBjitvkHhPtXTzRLmBYpIxFbt == P_0)
			{
				return false;
			}
			if (!P_0)
			{
				VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}
			fnEBjitvkHhPtXTzRLmBYpIxFbt = P_0;
			if (tGjExmrsAcHOmVrgLTgCsqJPOrA != null)
			{
				tGjExmrsAcHOmVrgLTgCsqJPOrA(P_0);
			}
			return true;
		}

		internal virtual void udRnEWOwQJDseTQQIEzfgbieiXAF(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			P_0.controllerId = id;
			P_0.controllerType = _type;
			IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
			for (int i = 0; i < buttonMaps.Count; i++)
			{
				IginakiartMCXcNztgFGkBgBmEe(P_0, buttonMaps[i]);
			}
			for (int num = buttonMaps.Count - 1; num >= 0; num--)
			{
				if (buttonMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(buttonMaps[num].JYRMuwETpVNRqJXmtBgBFhZdTeP);
				}
			}
		}

		internal virtual void IginakiartMCXcNztgFGkBgBmEe(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null && P_1._elementType == ControllerElementType.Button)
			{
				P_1.qOVDONBKVKOloJeRYYKGTFZqcKAM(P_0);
			}
		}

		internal bool FzGQGbkmFSyHrWWApQQYywIiiad(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			P_2 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int cRqOTsiLfoazJbodeeofQgavSxg = P_0.CRqOTsiLfoazJbodeeofQgavSxg;
			if (cRqOTsiLfoazJbodeeofQgavSxg < 0 || cRqOTsiLfoazJbodeeofQgavSxg >= _buttonCount)
			{
				return false;
			}
			P_3 = buttons[cRqOTsiLfoazJbodeeofQgavSxg].eQdisGnMMEOIkPANvRwfvFWbGDFH;
			float num = ((!P_3) ? (buttons[cRqOTsiLfoazJbodeeofQgavSxg].value ? 1f : 0f) : buttons[cRqOTsiLfoazJbodeeofQgavSxg].pressure);
			if (num > 0f)
			{
				if (P_0._elementType == ControllerElementType.Button)
				{
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (P_0._elementType == ControllerElementType.Axis)
				{
					if (P_0._axisRange == AxisRange.Full)
					{
						if (P_0._invert)
						{
							num *= -1f;
						}
					}
					else if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
			}
			P_2 = num;
			return true;
		}

		internal bool FzGQGbkmFSyHrWWApQQYywIiiad(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
		{
			P_3 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			float num = (P_2 ? 1f : 0f);
			if (num > 0f)
			{
				if (P_0._elementType == ControllerElementType.Button)
				{
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (P_0._elementType == ControllerElementType.Axis)
				{
					if (P_0._axisRange == AxisRange.Full)
					{
						if (P_0._invert)
						{
							num *= -1f;
						}
					}
					else if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
			}
			P_3 = num;
			return true;
		}

		internal void SSjwBZRYcJqbFyjnlHATtvRHxFM(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(omxIKEAXItSjJrzFPUwpagFQPsi, P_0);
			}
		}

		internal virtual Guid caWdOsPTKQqhUHixMcWhIiCqgaue()
		{
			return Guid.Empty;
		}

		protected virtual void Connected()
		{
			_isConnected = true;
		}

		protected virtual void Disconnected()
		{
			_isConnected = false;
			if (QlXkhNBHPYUNWwhKurdwrqFgWTf != null)
			{
				QlXkhNBHPYUNWwhKurdwrqFgWTf.ClearData();
			}
		}

		[CompilerGenerated]
		private static bool ZMvgVcWuvQXOpqjqNxUzEJHLsxu(Controller P_0, Guid P_1)
		{
			return P_0.ImplementsTemplate(P_1);
		}

		[CompilerGenerated]
		private static bool vpTdrFFqMagoFbxDHEevmxPfVGJx(Controller P_0, Type P_1)
		{
			return P_0.ImplementsTemplate(P_1);
		}
	}
}

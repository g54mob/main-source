using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
			internal abstract class QztnFVuAiGETKibYSGUCCxOfnpXKc
			{
				public abstract class BHyGbhBbTlcvRODZUJJSDLaTJvUp
				{
					public abstract void ooNidbhWzBcZZJydutNALDEuSswc();
				}

				protected readonly int yfViQNEGbvoVyRxINlWZIgKQXsZV;

				protected readonly int[] sxdBpaYjPuliXdEyQIUVniaagjdw;

				protected BHyGbhBbTlcvRODZUJJSDLaTJvUp[] OhZfPLeiCZorKUdCTHxwoDcQlqvkA;

				public BHyGbhBbTlcvRODZUJJSDLaTJvUp FzeFBTyCrPwRSotVRRvPtdRXkqzA;

				private int hXbwTkGIglELkIvAOJmgZwYkqPGIA;

				public int rxSDcDkNBigQzfrdvekKpcuczXDh = -1;

				protected ReadOnlyCollection<BHyGbhBbTlcvRODZUJJSDLaTJvUp> qFUvixMFpnqLElaHyQBdnRBYafeeA;

				public IList<BHyGbhBbTlcvRODZUJJSDLaTJvUp> UUgPWBrSTqNRuGRORrxdXffrDujU => qFUvixMFpnqLElaHyQBdnRBYafeeA;

				public UpdateLoopType KKlbldiDPbDuxfifcGjVGpjaqJEqB
				{
					set
					{
						if (rxSDcDkNBigQzfrdvekKpcuczXDh != (int)updateLoopType)
						{
							rxSDcDkNBigQzfrdvekKpcuczXDh = (int)updateLoopType;
							hXbwTkGIglELkIvAOJmgZwYkqPGIA = sxdBpaYjPuliXdEyQIUVniaagjdw[(int)updateLoopType];
							FzeFBTyCrPwRSotVRRvPtdRXkqzA = OhZfPLeiCZorKUdCTHxwoDcQlqvkA[hXbwTkGIglELkIvAOJmgZwYkqPGIA];
						}
					}
				}

				public QztnFVuAiGETKibYSGUCCxOfnpXKc(UpdateLoopSetting P_0)
				{
					sxdBpaYjPuliXdEyQIUVniaagjdw = new int[3];
					yfViQNEGbvoVyRxINlWZIgKQXsZV = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(P_0, list);
						for (int i = 0; i < list.Count; i++)
						{
							sxdBpaYjPuliXdEyQIUVniaagjdw[(int)list[i]] = yfViQNEGbvoVyRxINlWZIgKQXsZV;
							yfViQNEGbvoVyRxINlWZIgKQXsZV++;
						}
					}
					OhZfPLeiCZorKUdCTHxwoDcQlqvkA = new BHyGbhBbTlcvRODZUJJSDLaTJvUp[yfViQNEGbvoVyRxINlWZIgKQXsZV];
					qFUvixMFpnqLElaHyQBdnRBYafeeA = new ReadOnlyCollection<BHyGbhBbTlcvRODZUJJSDLaTJvUp>(OhZfPLeiCZorKUdCTHxwoDcQlqvkA);
				}

				public void ooNidbhWzBcZZJydutNALDEuSswc()
				{
					for (int i = 0; i < yfViQNEGbvoVyRxINlWZIgKQXsZV; i++)
					{
						OhZfPLeiCZorKUdCTHxwoDcQlqvkA[i].ooNidbhWzBcZZJydutNALDEuSswc();
					}
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal QztnFVuAiGETKibYSGUCCxOfnpXKc bkZtJEvHoZbIvIynmTvuhYaEuaTlA;

			internal int KmSCiCBAjyPVjhEIXLEHgVkeKROEB;

			internal Controller nEgdvbuTaiHYWdQfyyXkKnXDhOQcb;

			internal readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

			private CompoundElement ybMFprmKGqECdmeqIHoYvoHVvoFH;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = nEgdvbuTaiHYWdQfyyXkKnXDhOQcb.GetElementIdentifierById(id);
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return KmSCiCBAjyPVjhEIXLEHgVkeKROEB > 0;
				}
			}

			public CompoundElement compoundElement => ybMFprmKGqECdmeqIHoYvoHVvoFH;

			internal Element(Controller P_0, int P_1, string P_2, ControllerElementType P_3)
			{
				nEgdvbuTaiHYWdQfyyXkKnXDhOQcb = P_0;
				id = P_1;
				name = P_2;
				type = P_3;
				TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput.id;
			}

			public void Reset()
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else if (bkZtJEvHoZbIvIynmTvuhYaEuaTlA != null)
				{
					bkZtJEvHoZbIvIynmTvuhYaEuaTlA.ooNidbhWzBcZZJydutNALDEuSswc();
				}
			}

			internal void bRhOegEfrGfGzGaTedYhmNisveCLA(CompoundElement P_0)
			{
				if (KmSCiCBAjyPVjhEIXLEHgVkeKROEB > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
				}
				KmSCiCBAjyPVjhEIXLEHgVkeKROEB++;
				if (ybMFprmKGqECdmeqIHoYvoHVvoFH != null)
				{
					ybMFprmKGqECdmeqIHoYvoHVvoFH = P_0;
				}
			}

			internal void WNDCNlSkOwinmrZSnDDcmTnGmOBN(CompoundElement P_0)
			{
				if (KmSCiCBAjyPVjhEIXLEHgVkeKROEB == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					KmSCiCBAjyPVjhEIXLEHgVkeKROEB = 0;
					return;
				}
				KmSCiCBAjyPVjhEIXLEHgVkeKROEB--;
				if (ybMFprmKGqECdmeqIHoYvoHVvoFH == P_0)
				{
					ybMFprmKGqECdmeqIHoYvoHVvoFH = null;
				}
			}
		}

		public sealed class Axis : Element
		{
			internal class ZtjNCCodbGyhAbEhufmdJygNBVgnA : QztnFVuAiGETKibYSGUCCxOfnpXKc
			{
				public class KJpiPafrhiTnNaGpzyvEQiKnwKuP : BHyGbhBbTlcvRODZUJJSDLaTJvUp
				{
					private const float qdLbOVSmpOqtrQXiaMnoIvGSkHyw = 0.001f;

					public float pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;

					public float bMznxTYFodIvfBsMbJGsEvCKxoQK;

					public float pdBqMoNjTswdyswKBULoeOMwTsQj;

					public float IRCvavZQjFrcNFThgxILMWdBJmFE;

					public float QdcMqOLOhPWBEeQYnbwdTFIfZQRe;

					public float xqFwmKxFIOGnLIHwbnbnQcnkZpUlA;

					public double YabIfHUFtpexQPHTvfwAGBIuPuvaA;

					public double azRCrZEmtaKjJWESdnEkiebfNdBGc;

					public double tzxpAUUZavVexsFGhVALIkfRgbgh;

					public double vCaaoOIvFFneVjakfGgGoahuTxeMB;

					public double GDiKIxcaybaKeZudWFndGjvSrCocA;

					public double SQqcUdBKFuyYGupqaNDvSqncTEUM;

					public double AzzTuvMUZKEtxSfwUvwJaDConfWr
					{
						get
						{
							if ((double)pWbMhcBQKZEHHDwvEOhqpAUJhzfpA == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - tzxpAUUZavVexsFGhVALIkfRgbgh;
						}
					}

					public double VnvAxLJmshihEVGCWidhLMKmhIHC
					{
						get
						{
							if ((double)pdBqMoNjTswdyswKBULoeOMwTsQj == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - vCaaoOIvFFneVjakfGgGoahuTxeMB;
						}
					}

					public double AAVaqzpKtpjZnrGkRSlkVwYhQVre
					{
						get
						{
							if (pWbMhcBQKZEHHDwvEOhqpAUJhzfpA != 0f)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - YabIfHUFtpexQPHTvfwAGBIuPuvaA;
						}
					}

					public double eJcNIOZJTpgkKCRhWtSdTongBWEgb
					{
						get
						{
							if ((double)pdBqMoNjTswdyswKBULoeOMwTsQj != 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - azRCrZEmtaKjJWESdnEkiebfNdBGc;
						}
					}

					public void sOLNzBCCbZmFXkMugfndpShqgrUP(bool P_0)
					{
						double unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							if (!MathTools.Approximately(QdcMqOLOhPWBEeQYnbwdTFIfZQRe, 0f))
							{
								YabIfHUFtpexQPHTvfwAGBIuPuvaA = unscaledTime;
							}
							else
							{
								tzxpAUUZavVexsFGhVALIkfRgbgh = unscaledTime;
							}
							if (!MathTools.IsNear(QdcMqOLOhPWBEeQYnbwdTFIfZQRe, xqFwmKxFIOGnLIHwbnbnQcnkZpUlA, 0.001f))
							{
								GDiKIxcaybaKeZudWFndGjvSrCocA = unscaledTime;
							}
						}
						else
						{
							if (!MathTools.Approximately(pWbMhcBQKZEHHDwvEOhqpAUJhzfpA, 0f))
							{
								YabIfHUFtpexQPHTvfwAGBIuPuvaA = unscaledTime;
							}
							else
							{
								tzxpAUUZavVexsFGhVALIkfRgbgh = unscaledTime;
							}
							if (!MathTools.IsNear(pWbMhcBQKZEHHDwvEOhqpAUJhzfpA, bMznxTYFodIvfBsMbJGsEvCKxoQK, 0.001f))
							{
								GDiKIxcaybaKeZudWFndGjvSrCocA = unscaledTime;
							}
						}
						if (!MathTools.Approximately(pdBqMoNjTswdyswKBULoeOMwTsQj, 0f))
						{
							azRCrZEmtaKjJWESdnEkiebfNdBGc = unscaledTime;
						}
						else
						{
							vCaaoOIvFFneVjakfGgGoahuTxeMB = unscaledTime;
						}
						if (!MathTools.IsNear(pdBqMoNjTswdyswKBULoeOMwTsQj, IRCvavZQjFrcNFThgxILMWdBJmFE, 0.001f))
						{
							SQqcUdBKFuyYGupqaNDvSqncTEUM = unscaledTime;
						}
					}

					public void MtrHPzGqKSeQpbFYqJMZlVDXdzYlA(float P_0)
					{
						if (IRCvavZQjFrcNFThgxILMWdBJmFE != pdBqMoNjTswdyswKBULoeOMwTsQj)
						{
							IRCvavZQjFrcNFThgxILMWdBJmFE = pdBqMoNjTswdyswKBULoeOMwTsQj;
						}
						if (pdBqMoNjTswdyswKBULoeOMwTsQj != P_0)
						{
							pdBqMoNjTswdyswKBULoeOMwTsQj = P_0;
						}
					}

					public override void ooNidbhWzBcZZJydutNALDEuSswc()
					{
						pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = 0f;
						bMznxTYFodIvfBsMbJGsEvCKxoQK = 0f;
						pdBqMoNjTswdyswKBULoeOMwTsQj = 0f;
						IRCvavZQjFrcNFThgxILMWdBJmFE = 0f;
						YabIfHUFtpexQPHTvfwAGBIuPuvaA = 0.0;
						azRCrZEmtaKjJWESdnEkiebfNdBGc = 0.0;
						tzxpAUUZavVexsFGhVALIkfRgbgh = 0.0;
						vCaaoOIvFFneVjakfGgGoahuTxeMB = 0.0;
						GDiKIxcaybaKeZudWFndGjvSrCocA = 0.0;
						SQqcUdBKFuyYGupqaNDvSqncTEUM = 0.0;
					}
				}

				public ZtjNCCodbGyhAbEhufmdJygNBVgnA(UpdateLoopSetting P_0)
					: base(P_0)
				{
					for (int i = 0; i < yfViQNEGbvoVyRxINlWZIgKQXsZV; i++)
					{
						OhZfPLeiCZorKUdCTHxwoDcQlqvkA[i] = new KJpiPafrhiTnNaGpzyvEQiKnwKuP();
					}
					FzeFBTyCrPwRSotVRRvPtdRXkqzA = OhZfPLeiCZorKUdCTHxwoDcQlqvkA[0];
				}
			}

			internal readonly AxisRange kHytYvdOKSYoCQbwRpoWYapCFjaG;

			internal readonly HardwareAxisInfo LCaxfXkPMXiCslbaIiVAoElQhhmD;

			public float value
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).QdcMqOLOhPWBEeQYnbwdTFIfZQRe;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).xqFwmKxFIOGnLIHwbnbnQcnkZpUlA;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).bMznxTYFodIvfBsMbJGsEvCKxoQK;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).pdBqMoNjTswdyswKBULoeOMwTsQj;
				}
				internal set
				{
					((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).MtrHPzGqKSeQpbFYqJMZlVDXdzYlA(num);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).IRCvavZQjFrcNFThgxILMWdBJmFE;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).pdBqMoNjTswdyswKBULoeOMwTsQj - ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).IRCvavZQjFrcNFThgxILMWdBJmFE;
				}
			}

			public double lastTimeActive
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).YabIfHUFtpexQPHTvfwAGBIuPuvaA;
				}
			}

			public double lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).azRCrZEmtaKjJWESdnEkiebfNdBGc;
				}
			}

			public double lastTimeInactive
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).tzxpAUUZavVexsFGhVALIkfRgbgh;
				}
			}

			public double lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).vCaaoOIvFFneVjakfGgGoahuTxeMB;
				}
			}

			public double lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).GDiKIxcaybaKeZudWFndGjvSrCocA;
				}
			}

			public double lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).SQqcUdBKFuyYGupqaNDvSqncTEUM;
				}
			}

			public double timeActive
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).AzzTuvMUZKEtxSfwUvwJaDConfWr;
				}
			}

			public double timeActiveRaw
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).AzzTuvMUZKEtxSfwUvwJaDConfWr;
				}
			}

			public double timeInactive
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).AAVaqzpKtpjZnrGkRSlkVwYhQVre;
				}
			}

			public double timeInactiveRaw
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).eJcNIOZJTpgkKCRhWtSdTongBWEgb;
				}
			}

			public float pollingDeadZone
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					if (LCaxfXkPMXiCslbaIiVAoElQhhmD == null)
					{
						return -1f;
					}
					return LCaxfXkPMXiCslbaIiVAoElQhhmD._pollingDeadZone;
				}
				set
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return;
					}
					if (value < 0f)
					{
						value = -1f;
					}
					if (LCaxfXkPMXiCslbaIiVAoElQhhmD != null)
					{
						LCaxfXkPMXiCslbaIiVAoElQhhmD._pollingDeadZone = value;
					}
				}
			}

			internal float lNTITuzKxvaSykcNfibFKUxlAbywA => ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;

			internal float NLoufYAoaMGWVshlcWaDvRPJnRBU => ((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).bMznxTYFodIvfBsMbJGsEvCKxoQK;

			internal float yPNbebGHfNNuYBAoGSUXYkgODJVPB
			{
				get
				{
					if (LCaxfXkPMXiCslbaIiVAoElQhhmD == null)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (LCaxfXkPMXiCslbaIiVAoElQhhmD._pollingDeadZone >= 0f)
					{
						return LCaxfXkPMXiCslbaIiVAoElQhhmD._pollingDeadZone;
					}
					return LCaxfXkPMXiCslbaIiVAoElQhhmD._dataFormat switch
					{
						AxisCoordinateMode.Absolute => ReInput.configuration.defaultAbsoluteAxisPollingDeadZone, 
						AxisCoordinateMode.Relative => ReInput.configuration.defaultRelativeAxisPollingDeadZone, 
						_ => throw new NotImplementedException(), 
					};
				}
			}

			internal void yHLTcCljhgDqRJLPpLamoETACbxz(float P_0)
			{
				ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP obj = (ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA;
				obj.xqFwmKxFIOGnLIHwbnbnQcnkZpUlA = obj.QdcMqOLOhPWBEeQYnbwdTFIfZQRe;
				obj.QdcMqOLOhPWBEeQYnbwdTFIfZQRe = P_0;
			}

			internal Axis(Controller P_0, int P_1, string P_2, AxisRange P_3, HardwareAxisInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Axis)
			{
				bkZtJEvHoZbIvIynmTvuhYaEuaTlA = new ZtjNCCodbGyhAbEhufmdJygNBVgnA(ReInput.configVars.updateLoop);
				kHytYvdOKSYoCQbwRpoWYapCFjaG = P_3;
				LCaxfXkPMXiCslbaIiVAoElQhhmD = P_4;
			}

			internal void JQMhIHVomNcwpRBKcICkFvIExdCCA(UpdateLoopType P_0)
			{
				if (bkZtJEvHoZbIvIynmTvuhYaEuaTlA != null && bkZtJEvHoZbIvIynmTvuhYaEuaTlA.rxSDcDkNBigQzfrdvekKpcuczXDh != (int)P_0)
				{
					bkZtJEvHoZbIvIynmTvuhYaEuaTlA.KKlbldiDPbDuxfifcGjVGpjaqJEqB = P_0;
				}
			}

			internal void gktexvDkCazOJpTsGLKIhKgBWrJC(AxisCalibration P_0)
			{
				ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP kJpiPafrhiTnNaGpzyvEQiKnwKuP = (ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA;
				kJpiPafrhiTnNaGpzyvEQiKnwKuP.bMznxTYFodIvfBsMbJGsEvCKxoQK = kJpiPafrhiTnNaGpzyvEQiKnwKuP.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
				float pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = P_0.GetCalibratedValue(kJpiPafrhiTnNaGpzyvEQiKnwKuP.pdBqMoNjTswdyswKBULoeOMwTsQj, kHytYvdOKSYoCQbwRpoWYapCFjaG);
				if (P_0.applyRangeCalibration)
				{
					pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = MathTools.Clamp(pWbMhcBQKZEHHDwvEOhqpAUJhzfpA, -1f, 1f);
				}
				kJpiPafrhiTnNaGpzyvEQiKnwKuP.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
			}

			internal void gktexvDkCazOJpTsGLKIhKgBWrJC()
			{
				ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP obj = (ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA;
				obj.bMznxTYFodIvfBsMbJGsEvCKxoQK = obj.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
				obj.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = obj.pdBqMoNjTswdyswKBULoeOMwTsQj;
			}

			internal void VbyiNYaTxeSxPNfKRycKgustYwcy()
			{
				ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP obj = (ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA;
				obj.bMznxTYFodIvfBsMbJGsEvCKxoQK = obj.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
				obj.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = 0f;
			}

			internal void DKjtzBbwElhXUfSIQLPatJOaCbIb()
			{
				((ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).sOLNzBCCbZmFXkMugfndpShqgrUP(base.isMemberElement);
			}

			internal void zuiXmeemKZeAsEjTlDFRmkJLGDbaA(float P_0)
			{
				for (int i = 0; i < bkZtJEvHoZbIvIynmTvuhYaEuaTlA.UUgPWBrSTqNRuGRORrxdXffrDujU.Count; i++)
				{
					if (bkZtJEvHoZbIvIynmTvuhYaEuaTlA.UUgPWBrSTqNRuGRORrxdXffrDujU[i] is ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP kJpiPafrhiTnNaGpzyvEQiKnwKuP)
					{
						kJpiPafrhiTnNaGpzyvEQiKnwKuP.MtrHPzGqKSeQpbFYqJMZlVDXdzYlA(P_0);
						kJpiPafrhiTnNaGpzyvEQiKnwKuP.bMznxTYFodIvfBsMbJGsEvCKxoQK = kJpiPafrhiTnNaGpzyvEQiKnwKuP.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
						kJpiPafrhiTnNaGpzyvEQiKnwKuP.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = 0f;
						kJpiPafrhiTnNaGpzyvEQiKnwKuP.sOLNzBCCbZmFXkMugfndpShqgrUP(base.isMemberElement);
					}
				}
			}

			internal float ssUeJfYfdgHsOGaTfHqZKArcnbHGb(UpdateLoopType P_0, AxisCalibration P_1)
			{
				ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP kJpiPafrhiTnNaGpzyvEQiKnwKuP = (ZtjNCCodbGyhAbEhufmdJygNBVgnA.KJpiPafrhiTnNaGpzyvEQiKnwKuP)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.UUgPWBrSTqNRuGRORrxdXffrDujU[(int)P_0];
				float result = P_1.GetCalibratedValue(kJpiPafrhiTnNaGpzyvEQiKnwKuP.pdBqMoNjTswdyswKBULoeOMwTsQj, kHytYvdOKSYoCQbwRpoWYapCFjaG, P_1.deadZone, applySensitivity: false, applyInversion: true);
				if (P_1.applyRangeCalibration)
				{
					result = MathTools.Clamp(result, -1f, 1f);
				}
				return result;
			}
		}

		public sealed class Button : Element
		{
			internal class ONoJMiKjvStdJLlmUaPfqzKEdeob : QztnFVuAiGETKibYSGUCCxOfnpXKc
			{
				public class gbBXbKknbaCAYEFxhOVUnIvBWWMu : BHyGbhBbTlcvRODZUJJSDLaTJvUp
				{
					public bool pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;

					public bool bMznxTYFodIvfBsMbJGsEvCKxoQK;

					public ButtonStateRecorder lnlXsCZflroIMKHBtnXWhYAbfXjH;

					public NzUoNPoCfhLLQcCzMeSoVLbTCJUZ gptXlYRvFeOejhOtByoXZpPzmqzc;

					public gbBXbKknbaCAYEFxhOVUnIvBWWMu()
					{
						lnlXsCZflroIMKHBtnXWhYAbfXjH = new ButtonStateRecorder();
						gptXlYRvFeOejhOtByoXZpPzmqzc = new NzUoNPoCfhLLQcCzMeSoVLbTCJUZ(0.3f);
					}

					public void oZQllQxQuNaPXytzirxUjNaKuQtr(bool P_0)
					{
						if (bMznxTYFodIvfBsMbJGsEvCKxoQK != pWbMhcBQKZEHHDwvEOhqpAUJhzfpA)
						{
							bMznxTYFodIvfBsMbJGsEvCKxoQK = pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
						}
						if (pWbMhcBQKZEHHDwvEOhqpAUJhzfpA != P_0)
						{
							pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = P_0;
						}
						lnlXsCZflroIMKHBtnXWhYAbfXjH.sOLNzBCCbZmFXkMugfndpShqgrUP(P_0 && !bMznxTYFodIvfBsMbJGsEvCKxoQK, P_0, ReInput.unscaledTime);
						gptXlYRvFeOejhOtByoXZpPzmqzc.sOLNzBCCbZmFXkMugfndpShqgrUP(0.3f, P_0 && !bMznxTYFodIvfBsMbJGsEvCKxoQK, P_0);
					}

					public override void ooNidbhWzBcZZJydutNALDEuSswc()
					{
						pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = false;
						bMznxTYFodIvfBsMbJGsEvCKxoQK = false;
						lnlXsCZflroIMKHBtnXWhYAbfXjH.ooNidbhWzBcZZJydutNALDEuSswc();
						gptXlYRvFeOejhOtByoXZpPzmqzc.ooNidbhWzBcZZJydutNALDEuSswc();
					}
				}

				public class nVTaVDloyEYqMgJdGKGZVhuUdXHl : gbBXbKknbaCAYEFxhOVUnIvBWWMu
				{
					public float QRDEXLMujbUOVwWyyuubececynCL;

					public float nMKuYsbqhLaYjFSCvONFflkbhDsm;

					public void oZQllQxQuNaPXytzirxUjNaKuQtr(float P_0)
					{
						if (nMKuYsbqhLaYjFSCvONFflkbhDsm != QRDEXLMujbUOVwWyyuubececynCL)
						{
							nMKuYsbqhLaYjFSCvONFflkbhDsm = QRDEXLMujbUOVwWyyuubececynCL;
						}
						if (QRDEXLMujbUOVwWyyuubececynCL != P_0)
						{
							QRDEXLMujbUOVwWyyuubececynCL = ((P_0 > 0.001f) ? P_0 : 0f);
						}
						oZQllQxQuNaPXytzirxUjNaKuQtr(QRDEXLMujbUOVwWyyuubececynCL > 0f);
					}

					public override void ooNidbhWzBcZZJydutNALDEuSswc()
					{
						base.ooNidbhWzBcZZJydutNALDEuSswc();
						QRDEXLMujbUOVwWyyuubececynCL = 0f;
						nMKuYsbqhLaYjFSCvONFflkbhDsm = 0f;
					}
				}

				public ONoJMiKjvStdJLlmUaPfqzKEdeob(UpdateLoopSetting P_0, bool P_1)
					: base(P_0)
				{
					for (int i = 0; i < yfViQNEGbvoVyRxINlWZIgKQXsZV; i++)
					{
						if (P_1)
						{
							OhZfPLeiCZorKUdCTHxwoDcQlqvkA[i] = new nVTaVDloyEYqMgJdGKGZVhuUdXHl();
						}
						else
						{
							OhZfPLeiCZorKUdCTHxwoDcQlqvkA[i] = new gbBXbKknbaCAYEFxhOVUnIvBWWMu();
						}
					}
					FzeFBTyCrPwRSotVRRvPtdRXkqzA = OhZfPLeiCZorKUdCTHxwoDcQlqvkA[0];
				}

				public void OPHlvSlwZCJHqrCOXJYnUXZJkgjw(float P_0)
				{
					for (int i = 0; i < OhZfPLeiCZorKUdCTHxwoDcQlqvkA.Length; i++)
					{
						((gbBXbKknbaCAYEFxhOVUnIvBWWMu)OhZfPLeiCZorKUdCTHxwoDcQlqvkA[i]).gptXlYRvFeOejhOtByoXZpPzmqzc.FADpiPLxRzjlvxhCpxFaLYIzWfRt(P_0);
					}
				}

				public void mRKwwcRblfILcuSoSocjBjnLfXws()
				{
					for (int i = 0; i < OhZfPLeiCZorKUdCTHxwoDcQlqvkA.Length; i++)
					{
						((gbBXbKknbaCAYEFxhOVUnIvBWWMu)OhZfPLeiCZorKUdCTHxwoDcQlqvkA[i]).gptXlYRvFeOejhOtByoXZpPzmqzc.FADpiPLxRzjlvxhCpxFaLYIzWfRt(0.3f);
					}
				}
			}

			internal readonly bool kDXWNgilryFkZclNKzwjTGOhNaNH;

			internal readonly HardwareButtonInfo xSDBOvvCEphVCFyJSiGpShYQSSqD;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).bMznxTYFodIvfBsMbJGsEvCKxoQK;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).pWbMhcBQKZEHHDwvEOhqpAUJhzfpA;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					if (!kDXWNgilryFkZclNKzwjTGOhNaNH)
					{
						if (!((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).pWbMhcBQKZEHHDwvEOhqpAUJhzfpA)
						{
							return 0f;
						}
						return 1f;
					}
					return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.nVTaVDloyEYqMgJdGKGZVhuUdXHl)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).QRDEXLMujbUOVwWyyuubececynCL;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					if (!kDXWNgilryFkZclNKzwjTGOhNaNH)
					{
						if (!((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).bMznxTYFodIvfBsMbJGsEvCKxoQK)
						{
							return 0f;
						}
						return 1f;
					}
					return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.nVTaVDloyEYqMgJdGKGZVhuUdXHl)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).nMKuYsbqhLaYjFSCvONFflkbhDsm;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return kDXWNgilryFkZclNKzwjTGOhNaNH;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (!((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).bMznxTYFodIvfBsMbJGsEvCKxoQK && ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).pWbMhcBQKZEHHDwvEOhqpAUJhzfpA)
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).bMznxTYFodIvfBsMbJGsEvCKxoQK && !((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).pWbMhcBQKZEHHDwvEOhqpAUJhzfpA)
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).bMznxTYFodIvfBsMbJGsEvCKxoQK != ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).pWbMhcBQKZEHHDwvEOhqpAUJhzfpA)
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
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).gptXlYRvFeOejhOtByoXZpPzmqzc.yliRNEhSDlcaDrVrrFIFgXQqwyPb;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).gptXlYRvFeOejhOtByoXZpPzmqzc.yliRNEhSDlcaDrVrrFIFgXQqwyPb;
				}
			}

			public double timePressed
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).lnlXsCZflroIMKHBtnXWhYAbfXjH.zFYktExCDERkeiAGjHURuluNGvdF;
				}
			}

			public double timeUnpressed
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).lnlXsCZflroIMKHBtnXWhYAbfXjH.wfqIimNKfrzNPPFEnsIzzWEJIHOh;
				}
			}

			public double lastTimePressed
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).lnlXsCZflroIMKHBtnXWhYAbfXjH.AOOFjVgwdjPGWaHrlkHQfSNMVCCn;
				}
			}

			public double lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).lnlXsCZflroIMKHBtnXWhYAbfXjH.HDiGyDQglqAgoKOwrdRbGhKkPeoZb;
				}
			}

			public double lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0.0;
					}
					return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).lnlXsCZflroIMKHBtnXWhYAbfXjH.uIulUiVtMaNQGPBrtuyAjsVqhZoe;
				}
			}

			internal ButtonStateFlags NdfIaBgxBgEDSMCdGRkmFhYCFUMaB
			{
				get
				{
					ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu gbBXbKknbaCAYEFxhOVUnIvBWWMu = (ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
					if (gbBXbKknbaCAYEFxhOVUnIvBWWMu.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA)
					{
						buttonStateFlags |= ButtonStateFlags.On;
						if (!gbBXbKknbaCAYEFxhOVUnIvBWWMu.bMznxTYFodIvfBsMbJGsEvCKxoQK)
						{
							buttonStateFlags |= ButtonStateFlags.Down;
						}
					}
					else if (gbBXbKknbaCAYEFxhOVUnIvBWWMu.bMznxTYFodIvfBsMbJGsEvCKxoQK)
					{
						buttonStateFlags |= ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
			}

			internal Button(Controller P_0, int P_1, string P_2, HardwareButtonInfo P_3)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				xSDBOvvCEphVCFyJSiGpShYQSSqD = P_3;
				bkZtJEvHoZbIvIynmTvuhYaEuaTlA = new ONoJMiKjvStdJLlmUaPfqzKEdeob(ReInput.configVars.updateLoop, false);
			}

			internal Button(Controller P_0, int P_1, string P_2, bool P_3, HardwareButtonInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				xSDBOvvCEphVCFyJSiGpShYQSSqD = P_4;
				kDXWNgilryFkZclNKzwjTGOhNaNH = P_3;
				bkZtJEvHoZbIvIynmTvuhYaEuaTlA = new ONoJMiKjvStdJLlmUaPfqzKEdeob(ReInput.configVars.updateLoop, P_3);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				if (speed <= 0f)
				{
					return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).gptXlYRvFeOejhOtByoXZpPzmqzc.yliRNEhSDlcaDrVrrFIFgXQqwyPb;
				}
				return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).lnlXsCZflroIMKHBtnXWhYAbfXjH.aFKNmAzLpwuFGNmULczLFmKDMEiSA(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).gptXlYRvFeOejhOtByoXZpPzmqzc.yliRNEhSDlcaDrVrrFIFgXQqwyPb;
				}
				return ((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).lnlXsCZflroIMKHBtnXWhYAbfXjH.aFKNmAzLpwuFGNmULczLFmKDMEiSA(speed);
			}

			internal void oZQllQxQuNaPXytzirxUjNaKuQtr(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (bkZtJEvHoZbIvIynmTvuhYaEuaTlA != null && bkZtJEvHoZbIvIynmTvuhYaEuaTlA.rxSDcDkNBigQzfrdvekKpcuczXDh != (int)P_0)
				{
					bkZtJEvHoZbIvIynmTvuhYaEuaTlA.KKlbldiDPbDuxfifcGjVGpjaqJEqB = P_0;
				}
				if (kDXWNgilryFkZclNKzwjTGOhNaNH)
				{
					((ONoJMiKjvStdJLlmUaPfqzKEdeob.nVTaVDloyEYqMgJdGKGZVhuUdXHl)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).oZQllQxQuNaPXytzirxUjNaKuQtr(P_2.buttonPressureValues[P_1]);
				}
				else
				{
					((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).oZQllQxQuNaPXytzirxUjNaKuQtr(P_2.buttonValues[P_1]);
				}
			}

			internal void hNuBxubZfiRxPGobDeIzgMHqJjlrA(UpdateLoopType P_0)
			{
				if (bkZtJEvHoZbIvIynmTvuhYaEuaTlA != null && bkZtJEvHoZbIvIynmTvuhYaEuaTlA.rxSDcDkNBigQzfrdvekKpcuczXDh != (int)P_0)
				{
					bkZtJEvHoZbIvIynmTvuhYaEuaTlA.KKlbldiDPbDuxfifcGjVGpjaqJEqB = P_0;
				}
				if (kDXWNgilryFkZclNKzwjTGOhNaNH)
				{
					((ONoJMiKjvStdJLlmUaPfqzKEdeob.nVTaVDloyEYqMgJdGKGZVhuUdXHl)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).oZQllQxQuNaPXytzirxUjNaKuQtr(0f);
				}
				else
				{
					((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bkZtJEvHoZbIvIynmTvuhYaEuaTlA.FzeFBTyCrPwRSotVRRvPtdRXkqzA).oZQllQxQuNaPXytzirxUjNaKuQtr(false);
				}
			}

			internal void zuiXmeemKZeAsEjTlDFRmkJLGDbaA()
			{
				for (int i = 0; i < bkZtJEvHoZbIvIynmTvuhYaEuaTlA.UUgPWBrSTqNRuGRORrxdXffrDujU.Count; i++)
				{
					QztnFVuAiGETKibYSGUCCxOfnpXKc.BHyGbhBbTlcvRODZUJJSDLaTJvUp bHyGbhBbTlcvRODZUJJSDLaTJvUp = bkZtJEvHoZbIvIynmTvuhYaEuaTlA.UUgPWBrSTqNRuGRORrxdXffrDujU[i];
					if (bHyGbhBbTlcvRODZUJJSDLaTJvUp != null)
					{
						if (kDXWNgilryFkZclNKzwjTGOhNaNH)
						{
							((ONoJMiKjvStdJLlmUaPfqzKEdeob.nVTaVDloyEYqMgJdGKGZVhuUdXHl)bHyGbhBbTlcvRODZUJJSDLaTJvUp).oZQllQxQuNaPXytzirxUjNaKuQtr(0f);
						}
						else
						{
							((ONoJMiKjvStdJLlmUaPfqzKEdeob.gbBXbKknbaCAYEFxhOVUnIvBWWMu)bHyGbhBbTlcvRODZUJJSDLaTJvUp).oZQllQxQuNaPXytzirxUjNaKuQtr(false);
						}
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class JBOkIdHihAOoUyCqRoUUlutXuwCA
			{
				public readonly Element BCuHApOmoSObQBcmCUJCdFCnCAsFA;

				public readonly int sqskcboieqNphlkypEagOBTMghIL;

				public JBOkIdHihAOoUyCqRoUUlutXuwCA(Element P_0, int P_1)
				{
					BCuHApOmoSObQBcmCUJCdFCnCAsFA = P_0;
					sqskcboieqNphlkypEagOBTMghIL = P_1;
				}
			}

			private int MToyChcGWGmeBbeiJGjHlICtSgbd;

			private string gbaFwplwRPDIuUufIuWmknaoIHDK;

			private CompoundControllerElementType OkGTKhIUqsJqQkbQwDsMbAsaAzwbb;

			private int kiYHfahFeDPjHhkmohjSmWVgsjLv;

			private JBOkIdHihAOoUyCqRoUUlutXuwCA[] vgykPhbigkeVbdfSvoLHgDXxKMQQA;

			private Controller nEgdvbuTaiHYWdQfyyXkKnXDhOQcb;

			internal readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

			public int id
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return -1;
					}
					return MToyChcGWGmeBbeiJGjHlICtSgbd;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return string.Empty;
					}
					return gbaFwplwRPDIuUufIuWmknaoIHDK;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return CompoundControllerElementType.Axis2D;
					}
					return OkGTKhIUqsJqQkbQwDsMbAsaAzwbb;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return kiYHfahFeDPjHhkmohjSmWVgsjLv > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					return kiYHfahFeDPjHhkmohjSmWVgsjLv;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = nEgdvbuTaiHYWdQfyyXkKnXDhOQcb.GetElementIdentifierById(MToyChcGWGmeBbeiJGjHlICtSgbd);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			internal CompoundElement(Controller P_0, int P_1, string P_2, CompoundControllerElementType P_3)
			{
				nEgdvbuTaiHYWdQfyyXkKnXDhOQcb = P_0;
				MToyChcGWGmeBbeiJGjHlICtSgbd = P_1;
				gbaFwplwRPDIuUufIuWmknaoIHDK = P_2;
				OkGTKhIUqsJqQkbQwDsMbAsaAzwbb = P_3;
				vgykPhbigkeVbdfSvoLHgDXxKMQQA = new JBOkIdHihAOoUyCqRoUUlutXuwCA[elementCapacity];
				TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput.id;
			}

			internal Element eFnogOZmzyuQdEpygQflSqDcOeKp(int P_0)
			{
				if (P_0 < 0 || P_0 >= vgykPhbigkeVbdfSvoLHgDXxKMQQA.Length)
				{
					return null;
				}
				if (vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_0] == null)
				{
					return null;
				}
				return vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_0].BCuHApOmoSObQBcmCUJCdFCnCAsFA;
			}

			internal _0001 eFnogOZmzyuQdEpygQflSqDcOeKp<_0001>(int P_0) where _0001 : Element
			{
				if (P_0 < 0 || P_0 >= vgykPhbigkeVbdfSvoLHgDXxKMQQA.Length)
				{
					return null;
				}
				if (vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_0] == null)
				{
					return null;
				}
				return vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_0].BCuHApOmoSObQBcmCUJCdFCnCAsFA as _0001;
			}

			internal _0001 wfzXClSoPsGNjHtqrDjEBxXrJnVDA<_0001>(int P_0, out int P_1) where _0001 : Element
			{
				P_1 = -1;
				if (P_0 < 0 || P_0 >= vgykPhbigkeVbdfSvoLHgDXxKMQQA.Length)
				{
					return null;
				}
				if (vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_0] == null)
				{
					return null;
				}
				P_1 = vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_0].sqskcboieqNphlkypEagOBTMghIL;
				return vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_0].BCuHApOmoSObQBcmCUJCdFCnCAsFA as _0001;
			}

			internal bool EXLSSjQnrrQtaZMvCcEDTNZBhhQt(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (kiYHfahFeDPjHhkmohjSmWVgsjLv >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (nZHQVsgVTUQcIoUXkGNrGIPCwOzc(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					return false;
				}
				int num = BlVAGuWUibxaHFbmSdCzSGERjgCN();
				if (num < 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				return bqggOnPRGhpsiAwRmpKNOkNVBeHG(P_0, P_1, num);
			}

			internal bool ouBMeTtvWunVbVUXjSRAwprFBvtq(Element P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (kiYHfahFeDPjHhkmohjSmWVgsjLv == 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				}
				int num = nZHQVsgVTUQcIoUXkGNrGIPCwOzc(P_0);
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				return IjGMpainhLabDbDkOrSnUxMsdEnw(num);
			}

			internal void sTGEBEHswQyvSMfapMLudrPHerZyB()
			{
				for (int i = 0; i < vgykPhbigkeVbdfSvoLHgDXxKMQQA.Length; i++)
				{
					IjGMpainhLabDbDkOrSnUxMsdEnw(i);
				}
				kiYHfahFeDPjHhkmohjSmWVgsjLv = 0;
			}

			private int nZHQVsgVTUQcIoUXkGNrGIPCwOzc(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				for (int i = 0; i < vgykPhbigkeVbdfSvoLHgDXxKMQQA.Length; i++)
				{
					if (vgykPhbigkeVbdfSvoLHgDXxKMQQA[i] != null && vgykPhbigkeVbdfSvoLHgDXxKMQQA[i].BCuHApOmoSObQBcmCUJCdFCnCAsFA == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private bool bqggOnPRGhpsiAwRmpKNOkNVBeHG(Element P_0, int P_1, int P_2)
			{
				if (P_2 < 0 || P_2 >= vgykPhbigkeVbdfSvoLHgDXxKMQQA.Length)
				{
					return false;
				}
				if (vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_2] != null)
				{
					return false;
				}
				vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_2] = new JBOkIdHihAOoUyCqRoUUlutXuwCA(P_0, P_1);
				P_0.bRhOegEfrGfGzGaTedYhmNisveCLA(this);
				kiYHfahFeDPjHhkmohjSmWVgsjLv++;
				return true;
			}

			private bool IjGMpainhLabDbDkOrSnUxMsdEnw(int P_0)
			{
				if (P_0 < 0 || P_0 >= vgykPhbigkeVbdfSvoLHgDXxKMQQA.Length)
				{
					return false;
				}
				if (vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_0] == null)
				{
					return false;
				}
				if (vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_0].BCuHApOmoSObQBcmCUJCdFCnCAsFA != null)
				{
					vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_0].BCuHApOmoSObQBcmCUJCdFCnCAsFA.WNDCNlSkOwinmrZSnDDcmTnGmOBN(this);
				}
				vgykPhbigkeVbdfSvoLHgDXxKMQQA[P_0] = null;
				kiYHfahFeDPjHhkmohjSmWVgsjLv--;
				return true;
			}

			private int BlVAGuWUibxaHFbmSdCzSGERjgCN()
			{
				for (int i = 0; i < vgykPhbigkeVbdfSvoLHgDXxKMQQA.Length; i++)
				{
					if (vgykPhbigkeVbdfSvoLHgDXxKMQQA[i] == null)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int mXjCbxHdokPrUkEfPuslqLcOWlmKA = 2;

			private CalibrationMap XtRppuBXystgNHihKgIwoDxhiHdB;

			public override int elementCapacity => 2;

			public Axis xAxis
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return eFnogOZmzyuQdEpygQflSqDcOeKp<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return eFnogOZmzyuQdEpygQflSqDcOeKp<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector2.zero;
					}
					return UpubtBwoclVKnEpYQHdHwIxVgyLZ();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector2.zero;
					}
					return IHPTqLsaGZWEJkUoXGVlJQhXNVgE();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller P_0, int P_1, string P_2, Axis P_3, Axis P_4, int P_5, int P_6, CalibrationMap P_7)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Axis2D)
			{
				EXLSSjQnrrQtaZMvCcEDTNZBhhQt(P_3, P_5);
				EXLSSjQnrrQtaZMvCcEDTNZBhhQt(P_4, P_6);
				XtRppuBXystgNHihKgIwoDxhiHdB = P_7;
			}

			internal void HKmEXBOMtGYkijZBmPdErwHXVruq()
			{
				Vector2 vector = value;
				if (xAxis != null)
				{
					xAxis.yHLTcCljhgDqRJLPpLamoETACbxz(vector.x);
				}
				if (yAxis != null)
				{
					yAxis.yHLTcCljhgDqRJLPpLamoETACbxz(vector.y);
				}
			}

			private Vector2 UpubtBwoclVKnEpYQHdHwIxVgyLZ()
			{
				if (XtRppuBXystgNHihKgIwoDxhiHdB == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = wfzXClSoPsGNjHtqrDjEBxXrJnVDA<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = wfzXClSoPsGNjHtqrDjEBxXrJnVDA<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRaw ?? 0f;
				float valueRawY = axis2?.valueRaw ?? 0f;
				return XtRppuBXystgNHihKgIwoDxhiHdB.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}

			private Vector2 IHPTqLsaGZWEJkUoXGVlJQhXNVgE()
			{
				if (XtRppuBXystgNHihKgIwoDxhiHdB == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = wfzXClSoPsGNjHtqrDjEBxXrJnVDA<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = wfzXClSoPsGNjHtqrDjEBxXrJnVDA<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRawPrev ?? 0f;
				float valueRawY = axis2?.valueRawPrev ?? 0f;
				return XtRppuBXystgNHihKgIwoDxhiHdB.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int mXjCbxHdokPrUkEfPuslqLcOWlmKA = 8;

			private const int JlthdCLJexnevqEVAXXyhwqBLkDQ = 0;

			private const int ynzSRzqkaDSGisPjeLDpWGljILsQ = 1;

			private const int LWcFkKBEHQgexAKPhYioZxrooYcTb = 2;

			private const int ycmUIpWgIcalhLFsSPtEPFvQRJWi = 3;

			private const int XuYgAzwIfDIUQihGYPxQmHrBhjscb = 4;

			private const int NVWaCYGOimCCuFnQzdwHhJSWfGug = 5;

			private const int LisTNhUeeqIOCGdBegUXlsPaMEEFb = 6;

			private const int wjYJLXJMEGRSpZDBFYsbtSlvpklc = 7;

			private readonly int BhCbgrefAhFSrJIISsNLWhvlnnANA;

			private readonly Button[] ZvPFEBoODFIFAalgjPuHlidSttRw;

			private readonly ReadOnlyCollection<Button> qgZyZFrdnOZZVhkmWiOSIapDvSjV;

			private readonly int[] jTyeDjwfNJWUNzhcnZfIYCndtnLL;

			private bool VDvcBecasVMDsAlZxuwFGagqMnuBA;

			public override int elementCapacity => 8;

			public bool force4Way
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return VDvcBecasVMDsAlZxuwFGagqMnuBA;
				}
				set
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					}
					else
					{
						VDvcBecasVMDsAlZxuwFGagqMnuBA = value;
					}
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0;
					}
					return BhCbgrefAhFSrJIISsNLWhvlnnANA;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return qgZyZFrdnOZZVhkmWiOSIapDvSjV;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return eFnogOZmzyuQdEpygQflSqDcOeKp<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return eFnogOZmzyuQdEpygQflSqDcOeKp<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return eFnogOZmzyuQdEpygQflSqDcOeKp<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return eFnogOZmzyuQdEpygQflSqDcOeKp<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return eFnogOZmzyuQdEpygQflSqDcOeKp<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return eFnogOZmzyuQdEpygQflSqDcOeKp<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return eFnogOZmzyuQdEpygQflSqDcOeKp<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return eFnogOZmzyuQdEpygQflSqDcOeKp<Button>(7);
				}
			}

			internal Hat(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Hat)
			{
				int num = ((P_3 != null) ? P_3.Length : 0);
				if (num != ((P_4 != null) ? P_4.Length : 0))
				{
					throw new ArgumentException("button.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4 && num != 8)
				{
					throw new ArgumentException("button.Length must be 0, 4, or 8! Length: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					EXLSSjQnrrQtaZMvCcEDTNZBhhQt(P_3[i], P_4[i]);
				}
				ZvPFEBoODFIFAalgjPuHlidSttRw = P_3;
				jTyeDjwfNJWUNzhcnZfIYCndtnLL = P_4;
				BhCbgrefAhFSrJIISsNLWhvlnnANA = num;
				qgZyZFrdnOZZVhkmWiOSIapDvSjV = new ReadOnlyCollection<Button>(P_3);
			}

			internal void HKmEXBOMtGYkijZBmPdErwHXVruq(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (BhCbgrefAhFSrJIISsNLWhvlnnANA == 0)
				{
					return;
				}
				if (BhCbgrefAhFSrJIISsNLWhvlnnANA == 8 && (VDvcBecasVMDsAlZxuwFGagqMnuBA || ReInput.configVars.force4WayHats))
				{
					sbjmuuCyENJtvNkKiSseHEJUlnQM(ZvPFEBoODFIFAalgjPuHlidSttRw[0], jTyeDjwfNJWUNzhcnZfIYCndtnLL[0], jTyeDjwfNJWUNzhcnZfIYCndtnLL[7], jTyeDjwfNJWUNzhcnZfIYCndtnLL[1], P_0, P_1);
					sbjmuuCyENJtvNkKiSseHEJUlnQM(ZvPFEBoODFIFAalgjPuHlidSttRw[2], jTyeDjwfNJWUNzhcnZfIYCndtnLL[2], jTyeDjwfNJWUNzhcnZfIYCndtnLL[1], jTyeDjwfNJWUNzhcnZfIYCndtnLL[3], P_0, P_1);
					sbjmuuCyENJtvNkKiSseHEJUlnQM(ZvPFEBoODFIFAalgjPuHlidSttRw[4], jTyeDjwfNJWUNzhcnZfIYCndtnLL[4], jTyeDjwfNJWUNzhcnZfIYCndtnLL[5], jTyeDjwfNJWUNzhcnZfIYCndtnLL[3], P_0, P_1);
					sbjmuuCyENJtvNkKiSseHEJUlnQM(ZvPFEBoODFIFAalgjPuHlidSttRw[6], jTyeDjwfNJWUNzhcnZfIYCndtnLL[6], jTyeDjwfNJWUNzhcnZfIYCndtnLL[5], jTyeDjwfNJWUNzhcnZfIYCndtnLL[7], P_0, P_1);
					fNvWbaGaCgxwqfAgOXoOXYXsDXdP(ZvPFEBoODFIFAalgjPuHlidSttRw[1], jTyeDjwfNJWUNzhcnZfIYCndtnLL[1], P_0, P_1);
					fNvWbaGaCgxwqfAgOXoOXYXsDXdP(ZvPFEBoODFIFAalgjPuHlidSttRw[3], jTyeDjwfNJWUNzhcnZfIYCndtnLL[3], P_0, P_1);
					fNvWbaGaCgxwqfAgOXoOXYXsDXdP(ZvPFEBoODFIFAalgjPuHlidSttRw[5], jTyeDjwfNJWUNzhcnZfIYCndtnLL[5], P_0, P_1);
					fNvWbaGaCgxwqfAgOXoOXYXsDXdP(ZvPFEBoODFIFAalgjPuHlidSttRw[7], jTyeDjwfNJWUNzhcnZfIYCndtnLL[7], P_0, P_1);
					return;
				}
				for (int i = 0; i < ZvPFEBoODFIFAalgjPuHlidSttRw.Length; i++)
				{
					if (ZvPFEBoODFIFAalgjPuHlidSttRw[i] != null)
					{
						ZvPFEBoODFIFAalgjPuHlidSttRw[i].oZQllQxQuNaPXytzirxUjNaKuQtr(P_0, jTyeDjwfNJWUNzhcnZfIYCndtnLL[i], P_1);
					}
				}
			}

			private void sbjmuuCyENJtvNkKiSseHEJUlnQM(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
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
				P_0.oZQllQxQuNaPXytzirxUjNaKuQtr(P_4, P_1, P_5);
			}

			private void fNvWbaGaCgxwqfAgOXoOXYXsDXdP(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
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
					P_0.oZQllQxQuNaPXytzirxUjNaKuQtr(P_2, P_1, P_3);
				}
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller nEgdvbuTaiHYWdQfyyXkKnXDhOQcb;

			private IControllerExtensionSource vPTVBGMeTSLLhqcGnbvGjLFkMncb;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (nEgdvbuTaiHYWdQfyyXkKnXDhOQcb == null)
					{
						return false;
					}
					return nEgdvbuTaiHYWdQfyyXkKnXDhOQcb._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (nEgdvbuTaiHYWdQfyyXkKnXDhOQcb == null)
					{
						return false;
					}
					return nEgdvbuTaiHYWdQfyyXkKnXDhOQcb.enabled;
				}
			}

			internal Controller controller => nEgdvbuTaiHYWdQfyyXkKnXDhOQcb;

			internal Extension(IControllerExtensionSource P_0)
			{
				_reInputId = ReInput.id;
				VmntoFXbPmYmuYoLzIEBDPecwxAbA(P_0);
			}

			internal Extension(Extension P_0)
				: this(P_0.vPTVBGMeTSLLhqcGnbvGjLFkMncb)
			{
				nEgdvbuTaiHYWdQfyyXkKnXDhOQcb = P_0.nEgdvbuTaiHYWdQfyyXkKnXDhOQcb;
			}

			internal T GetController<T>() where T : Controller
			{
				if (nEgdvbuTaiHYWdQfyyXkKnXDhOQcb == null)
				{
					return null;
				}
				return nEgdvbuTaiHYWdQfyyXkKnXDhOQcb as T;
			}

			internal void SetController(Controller controller)
			{
				nEgdvbuTaiHYWdQfyyXkKnXDhOQcb = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return vPTVBGMeTSLLhqcGnbvGjLFkMncb;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					VmntoFXbPmYmuYoLzIEBDPecwxAbA(null);
				}
				else
				{
					VmntoFXbPmYmuYoLzIEBDPecwxAbA(extension.vPTVBGMeTSLLhqcGnbvGjLFkMncb);
				}
			}

			private void VmntoFXbPmYmuYoLzIEBDPecwxAbA(IControllerExtensionSource P_0)
			{
				vPTVBGMeTSLLhqcGnbvGjLFkMncb = P_0;
				SourceUpdated(vPTVBGMeTSLLhqcGnbvGjLFkMncb);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		[Serializable]
		private sealed class qBIjofBOLkgxUTcOskNsrlTzFSAd
		{
			public static readonly qBIjofBOLkgxUTcOskNsrlTzFSAd _003C_003E9 = new qBIjofBOLkgxUTcOskNsrlTzFSAd();

			public static Func<Controller, Guid, bool> _003C_003E9__158_0;

			public static Func<Controller, Type, bool> _003C_003E9__161_0;

			internal bool vFjVmZTegtesubhpRsmCMKXbqzJEb(Controller P_0, Guid P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}

			internal bool UidqeMJlszSLKwRloyhxjLdLXepl(Controller P_0, Type P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}
		}

		private sealed class abVNQvTioMkIozEoGXlPqZGWbUjF : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public Controller GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public abVNQvTioMkIozEoGXlPqZGWbUjF(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				Controller gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_00a0;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				gZXxEqHwrHYIyUJtInpLwgTukJaY.UpdatePollingFrameTracking();
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
				goto IL_00b0;
				IL_00b0:
				if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY._buttonCount)
				{
					if (gZXxEqHwrHYIyUJtInpLwgTukJaY.vZEhATYGSzMilBnrAsNDSASKstgp(aWiJmJHWwqZlYdpLUbqxiFaJSHeg, out var num))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(true, -1, gZXxEqHwrHYIyUJtInpLwgTukJaY.id, gZXxEqHwrHYIyUJtInpLwgTukJaY._name, gZXxEqHwrHYIyUJtInpLwgTukJaY._type, ControllerElementType.Button, aWiJmJHWwqZlYdpLUbqxiFaJSHeg, Pole.Positive, gZXxEqHwrHYIyUJtInpLwgTukJaY.jnGTQDFeNsixRwgRJcghDqCbQWSP.GetElementIdentifierName(num), num, KeyCode.None);
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
				goto IL_00b0;
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

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				abVNQvTioMkIozEoGXlPqZGWbUjF abVNQvTioMkIozEoGXlPqZGWbUjF2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					abVNQvTioMkIozEoGXlPqZGWbUjF2 = this;
				}
				else
				{
					abVNQvTioMkIozEoGXlPqZGWbUjF2 = new abVNQvTioMkIozEoGXlPqZGWbUjF(0);
					abVNQvTioMkIozEoGXlPqZGWbUjF2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				return abVNQvTioMkIozEoGXlPqZGWbUjF2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class cYXhnRVMPnVXgsUxmlyGLXUxKbZN : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public Controller GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public cYXhnRVMPnVXgsUxmlyGLXUxKbZN(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				Controller gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_00a0;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (ReInput._id != gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(gZXxEqHwrHYIyUJtInpLwgTukJaY.TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				gZXxEqHwrHYIyUJtInpLwgTukJaY.UpdatePollingFrameTracking();
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg = 0;
				goto IL_00b0;
				IL_00b0:
				if (aWiJmJHWwqZlYdpLUbqxiFaJSHeg < gZXxEqHwrHYIyUJtInpLwgTukJaY._buttonCount)
				{
					if (gZXxEqHwrHYIyUJtInpLwgTukJaY.taFdplBpLgAVykuqqRCKFlqVZTME(aWiJmJHWwqZlYdpLUbqxiFaJSHeg, out var num))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = new ControllerPollingInfo(true, -1, gZXxEqHwrHYIyUJtInpLwgTukJaY.id, gZXxEqHwrHYIyUJtInpLwgTukJaY._name, gZXxEqHwrHYIyUJtInpLwgTukJaY._type, ControllerElementType.Button, aWiJmJHWwqZlYdpLUbqxiFaJSHeg, Pole.Positive, gZXxEqHwrHYIyUJtInpLwgTukJaY.jnGTQDFeNsixRwgRJcghDqCbQWSP.GetElementIdentifierName(num), num, KeyCode.None);
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				aWiJmJHWwqZlYdpLUbqxiFaJSHeg++;
				goto IL_00b0;
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

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				cYXhnRVMPnVXgsUxmlyGLXUxKbZN cYXhnRVMPnVXgsUxmlyGLXUxKbZN2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					cYXhnRVMPnVXgsUxmlyGLXUxKbZN2 = this;
				}
				else
				{
					cYXhnRVMPnVXgsUxmlyGLXUxKbZN2 = new cYXhnRVMPnVXgsUxmlyGLXUxKbZN(0);
					cYXhnRVMPnVXgsUxmlyGLXUxKbZN2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				return cYXhnRVMPnVXgsUxmlyGLXUxKbZN2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		public readonly int id;

		protected string _tag;

		protected string _name;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid ajOkBXCGxlWjiAJvaOHxjyadfWfu;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension twcsiuijVoCQoRBtCRDysXzVVTPD;

		private bool llkLFSoLVtaASCstwdnHCsIDxnhYb;

		private ControllerIdentifier GpoMGthPunlHsuMxJLaEtGCxZVgB;

		internal int TcEXPUvjqSTMTFutCAtGRnMeNwub;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> aUQWeyXieBvNOUAjqzTkUKmMbRkq;

		private readonly ReadOnlyCollection<Element> ABLlvSkeHalgmkxVjrUFAcOGcjTf;

		private readonly IList<CompoundElement> TGUDkZGRWSPJXMDrjuUgzjHVPnGF;

		private readonly ReadOnlyCollection<CompoundElement> valBLEeMLxbvYXitYdErrNJWhIRib;

		[CustomObfuscation(rename = false)]
		internal readonly InputSource inputSource;

		internal readonly ControllerDataUpdater WlduKdCdymfJzhLxPcswpRugJOzgb;

		internal readonly HardwareControllerMap_Game jnGTQDFeNsixRwgRJcghDqCbQWSP;

		internal uint fYIZlNlUKsgmElwBbwHLXAhVYoKT;

		private uint lLCFhsxeglgSfkBUKgeUsrfdykKP;

		private uint eyWxVuLFOVkOWkNqxxZiBQMwCSYC;

		private Action<bool> vPTVuMiQdGJnDqRyojAKUwFPnFYJ;

		private IControllerTemplate[] KOoKmykMiOLFnXYRlIJsvUpmWZqB;

		private ReadOnlyCollection<IControllerTemplate> WOiKovqMAoGQNlFzeghPjhhYEvgFb;

		private static Func<Controller, Guid, bool> rVZwVvclVjYuLDneIEmDEMqfyNXy;

		private static Func<Controller, Type, bool> cXhyAQleMQaHvpaseXCLLCGrBncp;

		internal bool iQespGcTWCNzBziiICPOZaJmbqkFA => lLCFhsxeglgSfkBUKgeUsrfdykKP == ReInput.previousFrame;

		public bool enabled
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				return llkLFSoLVtaASCstwdnHCsIDxnhYb;
			}
			set
			{
				CPoVkJzroBtMRwmbFEndkvOzAAwfb(value);
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return string.Empty;
				}
				return _name;
			}
			internal set
			{
				_name = text;
			}
		}

		public string tag
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return Guid.Empty;
				}
				return ajOkBXCGxlWjiAJvaOHxjyadfWfu;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier => GpoMGthPunlHsuMxJLaEtGCxZVgB;

		public bool isConnected
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				}
				else if (!flag)
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				return aUQWeyXieBvNOUAjqzTkUKmMbRkq.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return ABLlvSkeHalgmkxVjrUFAcOGcjTf;
			}
		}

		public IList<CompoundElement> CompoundElements
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<CompoundElement>.EmptyReadOnlyIListT;
				}
				return valBLEeMLxbvYXitYdErrNJWhIRib;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return twcsiuijVoCQoRBtCRDysXzVVTPD;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return jnGTQDFeNsixRwgRJcghDqCbQWSP.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return jnGTQDFeNsixRwgRJcghDqCbQWSP.buttonElementIdentifiers_readOnly;
			}
		}

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return WOiKovqMAoGQNlFzeghPjhhYEvgFb;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				return KOoKmykMiOLFnXYRlIJsvUpmWZqB.Length;
			}
		}

		internal static Func<Controller, Guid, bool> dFkVXhAFwrQgvJljPtxUJDLIqhzH => qBIjofBOLkgxUTcOskNsrlTzFSAd._003C_003E9.vFjVmZTegtesubhpRsmCMKXbqzJEb;

		internal static Func<Controller, Type, bool> NfNTreNAWxuYBJmtoEPkaJedDOZb => qBIjofBOLkgxUTcOskNsrlTzFSAd._003C_003E9.UidqeMJlszSLKwRloyhxjLdLXepl;

		internal event Action<bool> CDUVxEflSzPxxsCRoZnzGfSbmPlC
		{
			add
			{
				vPTVuMiQdGJnDqRyojAKUwFPnFYJ = (Action<bool>)Delegate.Combine(vPTVuMiQdGJnDqRyojAKUwFPnFYJ, b);
			}
			remove
			{
				vPTVuMiQdGJnDqRyojAKUwFPnFYJ = (Action<bool>)Delegate.Remove(vPTVuMiQdGJnDqRyojAKUwFPnFYJ, value2);
			}
		}

		internal Controller(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, bool[] P_8, HardwareButtonInfo[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
		{
			id = P_0;
			inputSource = P_1;
			_type = P_5;
			ajOkBXCGxlWjiAJvaOHxjyadfWfu = P_6;
			_buttonCount = P_7;
			_name = P_2;
			_hardwareName = P_3;
			_hardwareIdentifier = P_4;
			WlduKdCdymfJzhLxPcswpRugJOzgb = P_12;
			jnGTQDFeNsixRwgRJcghDqCbQWSP = P_10;
			llkLFSoLVtaASCstwdnHCsIDxnhYb = true;
			TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput.id;
			AgRSpBTkpMroZBOUrPrqgqIkOGWn(P_11);
			aUQWeyXieBvNOUAjqzTkUKmMbRkq = new List<Element>(P_7);
			ABLlvSkeHalgmkxVjrUFAcOGcjTf = new ReadOnlyCollection<Element>(aUQWeyXieBvNOUAjqzTkUKmMbRkq);
			TGUDkZGRWSPJXMDrjuUgzjHVPnGF = new List<CompoundElement>();
			valBLEeMLxbvYXitYdErrNJWhIRib = new ReadOnlyCollection<CompoundElement>(TGUDkZGRWSPJXMDrjuUgzjHVPnGF);
			buttons = new Button[P_7];
			if (P_8 == null || P_8.Length < P_7)
			{
				for (int i = 0; i < P_7; i++)
				{
					buttons[i] = new Button(this, P_10.buttonElementIdentifierIds[i], "Button " + i, false, (P_9 != null) ? P_9[i] : new HardwareButtonInfo());
					EXLSSjQnrrQtaZMvCcEDTNZBhhQt(buttons[i]);
				}
			}
			else
			{
				for (int j = 0; j < P_7; j++)
				{
					buttons[j] = new Button(this, P_10.buttonElementIdentifierIds[j], "Button " + j, P_8[j], (P_9 != null) ? P_9[j] : new HardwareButtonInfo());
					EXLSSjQnrrQtaZMvCcEDTNZBhhQt(buttons[j]);
				}
			}
			buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
			KOoKmykMiOLFnXYRlIJsvUpmWZqB = EmptyObjects<IControllerTemplate>.array;
			WOiKovqMAoGQNlFzeghPjhhYEvgFb = new ReadOnlyCollection<IControllerTemplate>(KOoKmykMiOLFnXYRlIJsvUpmWZqB);
			Connected();
		}

		internal virtual void WCmnBnYePrGAMdoiUNBATVOhqgEEA()
		{
			GpoMGthPunlHsuMxJLaEtGCxZVgB = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			if (jnGTQDFeNsixRwgRJcghDqCbQWSP == null)
			{
				return null;
			}
			int buttonIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0)
			{
				return null;
			}
			return buttons[buttonIndex];
		}

		public virtual CompoundElement GetCompundElementById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			int count = TGUDkZGRWSPJXMDrjuUgzjHVPnGF.Count;
			for (int i = 0; i < count; i++)
			{
				if (TGUDkZGRWSPJXMDrjuUgzjHVPnGF[i] != null && TGUDkZGRWSPJXMDrjuUgzjHVPnGF[i].id == elementIdentifierId)
				{
					return TGUDkZGRWSPJXMDrjuUgzjHVPnGF[i];
				}
			}
			return null;
		}

		public int GetButtonIndexById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return -1;
			}
			return jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			return jnGTQDFeNsixRwgRJcghDqCbQWSP.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			int buttonIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].value;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			int buttonIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justPressed;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			int buttonIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justReleased;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			int buttonIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			int buttonIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].JustDoublePressed(speed);
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			int buttonIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			int buttonIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			int buttonIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].valuePrev;
		}

		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			int buttonIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timePressed;
		}

		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			int buttonIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			int buttonIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			int buttonIndex = jnGTQDFeNsixRwgRJcghDqCbQWSP.GetButtonIndex(elementIdentifierId);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (vZEhATYGSzMilBnrAsNDSASKstgp(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, jnGTQDFeNsixRwgRJcghDqCbQWSP.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (taFdplBpLgAVykuqqRCKFlqVZTME(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, jnGTQDFeNsixRwgRJcghDqCbQWSP.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
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
			return new abVNQvTioMkIozEoGXlPqZGWbUjF(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this
			};
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return new cYXhnRVMPnVXgsUxmlyGLXUxKbZN(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this
			};
		}

		private bool vZEhATYGSzMilBnrAsNDSASKstgp(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].value || buttons[P_0].xSDBOvvCEphVCFyJSiGpShYQSSqD._excludeFromPolling)
			{
				return false;
			}
			P_1 = jnGTQDFeNsixRwgRJcghDqCbQWSP.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		private bool taFdplBpLgAVykuqqRCKFlqVZTME(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].justPressed || buttons[P_0].xSDBOvvCEphVCFyJSiGpShYQSSqD._excludeFromPolling)
			{
				return false;
			}
			P_1 = jnGTQDFeNsixRwgRJcghDqCbQWSP.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		protected void UpdatePollingFrameTracking()
		{
			if (eyWxVuLFOVkOWkNqxxZiBQMwCSYC == ReInput.currentFrame)
			{
				return;
			}
			lLCFhsxeglgSfkBUKgeUsrfdykKP = eyWxVuLFOVkOWkNqxxZiBQMwCSYC;
			eyWxVuLFOVkOWkNqxxZiBQMwCSYC = ReInput.currentFrame;
			if (!iQespGcTWCNzBziiICPOZaJmbqkFA)
			{
				if (fYIZlNlUKsgmElwBbwHLXAhVYoKT == uint.MaxValue)
				{
					fYIZlNlUKsgmElwBbwHLXAhVYoKT = 0u;
				}
				else
				{
					fYIZlNlUKsgmElwBbwHLXAhVYoKT++;
				}
			}
		}

		public virtual double GetLastTimeActive()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public virtual double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual double GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0.0;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public double GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			return twcsiuijVoCQoRBtCRDysXzVVTPD as T;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			for (int i = 0; i < KOoKmykMiOLFnXYRlIJsvUpmWZqB.Length; i++)
			{
				if (KOoKmykMiOLFnXYRlIJsvUpmWZqB[i].typeGuid == typeGuid)
				{
					return KOoKmykMiOLFnXYRlIJsvUpmWZqB[i];
				}
			}
			return null;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			for (int i = 0; i < KOoKmykMiOLFnXYRlIJsvUpmWZqB.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(KOoKmykMiOLFnXYRlIJsvUpmWZqB[i].GetType(), type))
				{
					return KOoKmykMiOLFnXYRlIJsvUpmWZqB[i];
				}
			}
			return null;
		}

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			for (int i = 0; i < KOoKmykMiOLFnXYRlIJsvUpmWZqB.Length; i++)
			{
				if (KOoKmykMiOLFnXYRlIJsvUpmWZqB[i] as T != null)
				{
					return KOoKmykMiOLFnXYRlIJsvUpmWZqB[i] as T;
				}
			}
			return null;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			for (int i = 0; i < KOoKmykMiOLFnXYRlIJsvUpmWZqB.Length; i++)
			{
				if (KOoKmykMiOLFnXYRlIJsvUpmWZqB[i].typeGuid == typeGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			for (int i = 0; i < KOoKmykMiOLFnXYRlIJsvUpmWZqB.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(KOoKmykMiOLFnXYRlIJsvUpmWZqB[i].GetType(), type))
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

		internal void TGYesMFrSMGpMWYtbuUUruLunOlp(IControllerTemplate[] P_0)
		{
			if (P_0 != null)
			{
				KOoKmykMiOLFnXYRlIJsvUpmWZqB = P_0;
				WOiKovqMAoGQNlFzeghPjhhYEvgFb = new ReadOnlyCollection<IControllerTemplate>(KOoKmykMiOLFnXYRlIJsvUpmWZqB);
			}
		}

		internal virtual void OPzMeptHNTMsrWdWvslRxoVUdTujA(UpdateLoopType P_0)
		{
			bool num = ReInput.IsInputAllowed(_type);
			int num2 = _buttonCount;
			if (num)
			{
				for (int i = 0; i < num2; i++)
				{
					if (buttons[i].KmSCiCBAjyPVjhEIXLEHgVkeKROEB <= 0)
					{
						buttons[i].oZQllQxQuNaPXytzirxUjNaKuQtr(P_0, i, WlduKdCdymfJzhLxPcswpRugJOzgb);
					}
				}
			}
			else
			{
				for (int j = 0; j < num2; j++)
				{
					if (buttons[j].KmSCiCBAjyPVjhEIXLEHgVkeKROEB <= 0)
					{
						buttons[j].hNuBxubZfiRxPGobDeIzgMHqJjlrA(P_0);
					}
				}
			}
			if (twcsiuijVoCQoRBtCRDysXzVVTPD != null)
			{
				twcsiuijVoCQoRBtCRDysXzVVTPD.UpdateData(P_0);
			}
		}

		internal virtual ButtonStateFlags UZVGEYSBDBxHaOdubTHSxJdnGrbt(int P_0)
		{
			if (P_0 < 0 || P_0 >= _buttonCount)
			{
				return ButtonStateFlags.Off;
			}
			return buttons[P_0].NdfIaBgxBgEDSMCdGRkmFhYCFUMaB;
		}

		internal void AgRSpBTkpMroZBOUrPrqgqIkOGWn(Extension P_0)
		{
			if (P_0 == null)
			{
				twcsiuijVoCQoRBtCRDysXzVVTPD = null;
				return;
			}
			if (twcsiuijVoCQoRBtCRDysXzVVTPD != null)
			{
				KCCLiPpizAZVlUwLGfVBUliUUOBb(P_0);
				return;
			}
			P_0.SetController(this);
			twcsiuijVoCQoRBtCRDysXzVVTPD = P_0.Clone();
		}

		internal void KCCLiPpizAZVlUwLGfVBUliUUOBb(Extension P_0)
		{
			if (twcsiuijVoCQoRBtCRDysXzVVTPD != null)
			{
				twcsiuijVoCQoRBtCRDysXzVVTPD.SetSource(P_0);
				twcsiuijVoCQoRBtCRDysXzVVTPD.SetController(this);
				P_0?.SetController(this);
			}
			else
			{
				AgRSpBTkpMroZBOUrPrqgqIkOGWn(P_0);
			}
		}

		internal virtual void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
		{
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i] != null)
				{
					buttons[i].Reset();
				}
			}
			if (WlduKdCdymfJzhLxPcswpRugJOzgb != null)
			{
				WlduKdCdymfJzhLxPcswpRugJOzgb.ClearData();
			}
			if (twcsiuijVoCQoRBtCRDysXzVVTPD != null)
			{
				twcsiuijVoCQoRBtCRDysXzVVTPD.Clear();
			}
		}

		internal virtual bool CPoVkJzroBtMRwmbFEndkvOzAAwfb(bool P_0)
		{
			if (llkLFSoLVtaASCstwdnHCsIDxnhYb == P_0)
			{
				return false;
			}
			if (!P_0)
			{
				HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
			}
			llkLFSoLVtaASCstwdnHCsIDxnhYb = P_0;
			if (vPTVuMiQdGJnDqRyojAKUwFPnFYJ != null)
			{
				vPTVuMiQdGJnDqRyojAKUwFPnFYJ(P_0);
			}
			return true;
		}

		internal virtual void cnpecuLKhtzxTyAKhiBbYvieXuGi(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			P_0.controllerId = id;
			IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
			for (int i = 0; i < buttonMaps.Count; i++)
			{
				OkYVVItyDNIRrZjZSvdPINJLnmkM(P_0, buttonMaps[i]);
			}
			for (int num = buttonMaps.Count - 1; num >= 0; num--)
			{
				if (buttonMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(buttonMaps[num].HZrDwOTOuvYGJkZRWDMDnUPlFNTs);
				}
			}
		}

		internal virtual void OkYVVItyDNIRrZjZSvdPINJLnmkM(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null && P_1._elementType == ControllerElementType.Button)
			{
				P_1.kArqsxPmpmoyPVFqtFYUjLfaKBQC(P_0);
			}
		}

		internal bool VSiihPxGuiGUWdrCYhBKGgUwyktU(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			P_2 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int uxnXexdLmPFrOAXyWtEwqWmaGYzH = P_0.UxnXexdLmPFrOAXyWtEwqWmaGYzH;
			if (uxnXexdLmPFrOAXyWtEwqWmaGYzH < 0 || uxnXexdLmPFrOAXyWtEwqWmaGYzH >= _buttonCount)
			{
				return false;
			}
			P_3 = buttons[uxnXexdLmPFrOAXyWtEwqWmaGYzH].kDXWNgilryFkZclNKzwjTGOhNaNH;
			float num = ((!P_3) ? (buttons[uxnXexdLmPFrOAXyWtEwqWmaGYzH].value ? 1f : 0f) : buttons[uxnXexdLmPFrOAXyWtEwqWmaGYzH].pressure);
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

		internal bool VSiihPxGuiGUWdrCYhBKGgUwyktU(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
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

		internal void EXLSSjQnrrQtaZMvCcEDTNZBhhQt(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(aUQWeyXieBvNOUAjqzTkUKmMbRkq, P_0);
			}
		}

		internal void zHkFavizqbDuYMnEoaQQxVsTmUceA(CompoundElement P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(TGUDkZGRWSPJXMDrjuUgzjHVPnGF, P_0);
			}
		}

		internal virtual Guid ypoOeCQLpunuzyedjsRxiLYslguo()
		{
			return Guid.Empty;
		}

		internal virtual void ciqEMkdNIetcwAdDEzSvXOVSVQfM(bool P_0)
		{
			if (!P_0 && !ReInput.IsInputAllowed(_type) && twcsiuijVoCQoRBtCRDysXzVVTPD != null)
			{
				twcsiuijVoCQoRBtCRDysXzVVTPD.Clear();
			}
		}

		protected virtual void Connected()
		{
			_isConnected = true;
		}

		protected virtual void Disconnected()
		{
			_isConnected = false;
			if (WlduKdCdymfJzhLxPcswpRugJOzgb != null)
			{
				WlduKdCdymfJzhLxPcswpRugJOzgb.ClearData();
			}
		}
	}
}

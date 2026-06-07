using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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
			internal abstract class sMWgQVDeCjsxpVfukBpTNYQCqwrjA
			{
				public abstract class bDKNnRVdAWXkQGdmGeVhwmHiwavb
				{
					public abstract void RDbatwhRlnoXbWBoPMbjEljHGtqKc();
				}

				protected readonly int LXAzQxsxSynocKITKiWjdwFsNUiS;

				protected readonly int[] UcLHPXdkHdgrmhlbXpFmeZVENEvd;

				protected bDKNnRVdAWXkQGdmGeVhwmHiwavb[] BVqksvdNPWGquKaYEMTtOgWBpSOZA;

				public bDKNnRVdAWXkQGdmGeVhwmHiwavb JKkBiWHfWgSpxVJoNAzqSPPrHkzcA;

				private int lhrmdFuheMbWGFGksavTwRtNUWLtA;

				public int oydnwUFYhFLJdDFLpULSjkQOElbG = -1;

				protected ReadOnlyCollection<bDKNnRVdAWXkQGdmGeVhwmHiwavb> uFezbmNgsUzcQfIYmfdfMwZorXLg;

				public IList<bDKNnRVdAWXkQGdmGeVhwmHiwavb> fAWZtJXuhiOuMVcsuIFSBunRdnIW => uFezbmNgsUzcQfIYmfdfMwZorXLg;

				public UpdateLoopType msEotrEGRKHCawvGkseBexNwfklJ
				{
					set
					{
						if (oydnwUFYhFLJdDFLpULSjkQOElbG != (int)updateLoopType)
						{
							oydnwUFYhFLJdDFLpULSjkQOElbG = (int)updateLoopType;
							lhrmdFuheMbWGFGksavTwRtNUWLtA = UcLHPXdkHdgrmhlbXpFmeZVENEvd[(int)updateLoopType];
							JKkBiWHfWgSpxVJoNAzqSPPrHkzcA = BVqksvdNPWGquKaYEMTtOgWBpSOZA[lhrmdFuheMbWGFGksavTwRtNUWLtA];
						}
					}
				}

				public sMWgQVDeCjsxpVfukBpTNYQCqwrjA(UpdateLoopSetting P_0)
				{
					UcLHPXdkHdgrmhlbXpFmeZVENEvd = new int[3];
					LXAzQxsxSynocKITKiWjdwFsNUiS = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(P_0, list);
						for (int i = 0; i < list.Count; i++)
						{
							UcLHPXdkHdgrmhlbXpFmeZVENEvd[(int)list[i]] = LXAzQxsxSynocKITKiWjdwFsNUiS;
							LXAzQxsxSynocKITKiWjdwFsNUiS++;
						}
					}
					BVqksvdNPWGquKaYEMTtOgWBpSOZA = new bDKNnRVdAWXkQGdmGeVhwmHiwavb[LXAzQxsxSynocKITKiWjdwFsNUiS];
					uFezbmNgsUzcQfIYmfdfMwZorXLg = new ReadOnlyCollection<bDKNnRVdAWXkQGdmGeVhwmHiwavb>(BVqksvdNPWGquKaYEMTtOgWBpSOZA);
				}

				public void VyadTdyTTHOidiIKegHKpLlaXZWs()
				{
					for (int i = 0; i < LXAzQxsxSynocKITKiWjdwFsNUiS; i++)
					{
						BVqksvdNPWGquKaYEMTtOgWBpSOZA[i].RDbatwhRlnoXbWBoPMbjEljHGtqKc();
					}
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal sMWgQVDeCjsxpVfukBpTNYQCqwrjA oopiwvREXxNAEbCTOyqEKOrKGvkk;

			internal int qrdGheDsBazDidJDNgXkuIyuiaaGb;

			internal Controller CVXitzEFsuCUSdKeYEDPsGHkxWOy;

			internal readonly int xGHnuELflkgoUtlGXgjsQVUGyMbY;

			private CompoundElement OmeEHkrDhabvSaGCykGhKzEhdeJTA;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = CVXitzEFsuCUSdKeYEDPsGHkxWOy.GetElementIdentifierById(id);
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
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return false;
					}
					return qrdGheDsBazDidJDNgXkuIyuiaaGb > 0;
				}
			}

			public CompoundElement compoundElement => OmeEHkrDhabvSaGCykGhKzEhdeJTA;

			internal Element(Controller P_0, int P_1, string P_2, ControllerElementType P_3)
			{
				CVXitzEFsuCUSdKeYEDPsGHkxWOy = P_0;
				id = P_1;
				name = P_2;
				type = P_3;
				xGHnuELflkgoUtlGXgjsQVUGyMbY = ReInput.id;
			}

			public void Reset()
			{
				if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
				{
					ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
				}
				else if (oopiwvREXxNAEbCTOyqEKOrKGvkk != null)
				{
					oopiwvREXxNAEbCTOyqEKOrKGvkk.VyadTdyTTHOidiIKegHKpLlaXZWs();
				}
			}

			internal void raNhAFCkLnoIhCYZALeBccaaMDJhE(CompoundElement P_0)
			{
				if (qrdGheDsBazDidJDNgXkuIyuiaaGb > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
				}
				qrdGheDsBazDidJDNgXkuIyuiaaGb++;
				if (OmeEHkrDhabvSaGCykGhKzEhdeJTA != null)
				{
					OmeEHkrDhabvSaGCykGhKzEhdeJTA = P_0;
				}
			}

			internal void gyaWxfycUrBrcnnXhhayhCPVrHgU(CompoundElement P_0)
			{
				if (qrdGheDsBazDidJDNgXkuIyuiaaGb == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					qrdGheDsBazDidJDNgXkuIyuiaaGb = 0;
					return;
				}
				qrdGheDsBazDidJDNgXkuIyuiaaGb--;
				if (OmeEHkrDhabvSaGCykGhKzEhdeJTA == P_0)
				{
					OmeEHkrDhabvSaGCykGhKzEhdeJTA = null;
				}
			}
		}

		public sealed class Axis : Element
		{
			internal class dGEAXSeaZljVvAjLeAVuuXmdoSEUB : sMWgQVDeCjsxpVfukBpTNYQCqwrjA
			{
				public class aaSbGwghZFOPaYcNPRUZNhQEpBECA : bDKNnRVdAWXkQGdmGeVhwmHiwavb
				{
					private const float mtBwXSAzUCcdHSRtpNXiwRqXrkEL = 0.001f;

					public float sOuaDBFDHDNKOIfGpiaHxVLeHbdbb;

					public float SPUtndJtoqwDiPDWQbEUeZwSQUYz;

					public float vupWLgwPcrvmuebrlArncfHTLVDQA;

					public float GFZjyBqhifCSZSLzyMUmDakCKKpj;

					public float FQqbGdSXrVBQqnhaPQGlAMvRAwJDA;

					public float qYbDKwaLENGhpAeAqreiemTPbNLF;

					public double QsKJqEamQklTWDhRHKUzkcqWWKYS;

					public double wYdqqvWbDzfHXhlepVjvSGvwIjkDb;

					public double naNpeoIrykxvScbGHIzjzHjOOBWy;

					public double ZwTPszPYHGAfqjRMxlXQYjfRkSot;

					public double TIWrBJgUwoTIHcODTOrQLykkdROH;

					public double kpRlcKLRUgEFSEuaSTDbuiBaFPJY;

					public double DXFmsKxRacRiRKFdRcqujFaCJCWz
					{
						get
						{
							if ((double)sOuaDBFDHDNKOIfGpiaHxVLeHbdbb == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - naNpeoIrykxvScbGHIzjzHjOOBWy;
						}
					}

					public double MdTvpuRdmZOjzpcoSeiIUupGMoLe
					{
						get
						{
							if ((double)vupWLgwPcrvmuebrlArncfHTLVDQA == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - ZwTPszPYHGAfqjRMxlXQYjfRkSot;
						}
					}

					public double vKOXfKUilmbDrkuNIFOhtZEUuvZjA
					{
						get
						{
							if (sOuaDBFDHDNKOIfGpiaHxVLeHbdbb != 0f)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - QsKJqEamQklTWDhRHKUzkcqWWKYS;
						}
					}

					public double BaMewcuCigzvTLveiRCTPmSzKKVT
					{
						get
						{
							if ((double)vupWLgwPcrvmuebrlArncfHTLVDQA != 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - wYdqqvWbDzfHXhlepVjvSGvwIjkDb;
						}
					}

					public void JgPhBSqhVRkQVrcRNcrwxEAdDrso(bool P_0)
					{
						double unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							if (!MathTools.Approximately(FQqbGdSXrVBQqnhaPQGlAMvRAwJDA, 0f))
							{
								QsKJqEamQklTWDhRHKUzkcqWWKYS = unscaledTime;
							}
							else
							{
								naNpeoIrykxvScbGHIzjzHjOOBWy = unscaledTime;
							}
							if (!MathTools.IsNear(FQqbGdSXrVBQqnhaPQGlAMvRAwJDA, qYbDKwaLENGhpAeAqreiemTPbNLF, 0.001f))
							{
								TIWrBJgUwoTIHcODTOrQLykkdROH = unscaledTime;
							}
						}
						else
						{
							if (!MathTools.Approximately(sOuaDBFDHDNKOIfGpiaHxVLeHbdbb, 0f))
							{
								QsKJqEamQklTWDhRHKUzkcqWWKYS = unscaledTime;
							}
							else
							{
								naNpeoIrykxvScbGHIzjzHjOOBWy = unscaledTime;
							}
							if (!MathTools.IsNear(sOuaDBFDHDNKOIfGpiaHxVLeHbdbb, SPUtndJtoqwDiPDWQbEUeZwSQUYz, 0.001f))
							{
								TIWrBJgUwoTIHcODTOrQLykkdROH = unscaledTime;
							}
						}
						if (!MathTools.Approximately(vupWLgwPcrvmuebrlArncfHTLVDQA, 0f))
						{
							wYdqqvWbDzfHXhlepVjvSGvwIjkDb = unscaledTime;
						}
						else
						{
							ZwTPszPYHGAfqjRMxlXQYjfRkSot = unscaledTime;
						}
						if (!MathTools.IsNear(vupWLgwPcrvmuebrlArncfHTLVDQA, GFZjyBqhifCSZSLzyMUmDakCKKpj, 0.001f))
						{
							kpRlcKLRUgEFSEuaSTDbuiBaFPJY = unscaledTime;
						}
					}

					public void lFRRNndTsejqCLBmOLGbbKBBLbXb(float P_0)
					{
						if (GFZjyBqhifCSZSLzyMUmDakCKKpj != vupWLgwPcrvmuebrlArncfHTLVDQA)
						{
							GFZjyBqhifCSZSLzyMUmDakCKKpj = vupWLgwPcrvmuebrlArncfHTLVDQA;
						}
						if (vupWLgwPcrvmuebrlArncfHTLVDQA != P_0)
						{
							vupWLgwPcrvmuebrlArncfHTLVDQA = P_0;
						}
					}

					public virtual void isTsOrJTXxtehvfkItwePgAqzgld()
					{
						sOuaDBFDHDNKOIfGpiaHxVLeHbdbb = 0f;
						SPUtndJtoqwDiPDWQbEUeZwSQUYz = 0f;
						vupWLgwPcrvmuebrlArncfHTLVDQA = 0f;
						GFZjyBqhifCSZSLzyMUmDakCKKpj = 0f;
						QsKJqEamQklTWDhRHKUzkcqWWKYS = 0.0;
						wYdqqvWbDzfHXhlepVjvSGvwIjkDb = 0.0;
						naNpeoIrykxvScbGHIzjzHjOOBWy = 0.0;
						ZwTPszPYHGAfqjRMxlXQYjfRkSot = 0.0;
						TIWrBJgUwoTIHcODTOrQLykkdROH = 0.0;
						kpRlcKLRUgEFSEuaSTDbuiBaFPJY = 0.0;
					}
				}

				public dGEAXSeaZljVvAjLeAVuuXmdoSEUB(UpdateLoopSetting P_0)
					: base(P_0)
				{
					for (int i = 0; i < LXAzQxsxSynocKITKiWjdwFsNUiS; i++)
					{
						BVqksvdNPWGquKaYEMTtOgWBpSOZA[i] = new aaSbGwghZFOPaYcNPRUZNhQEpBECA();
					}
					JKkBiWHfWgSpxVJoNAzqSPPrHkzcA = BVqksvdNPWGquKaYEMTtOgWBpSOZA[0];
				}
			}

			internal readonly AxisRange lsQLxcaIvVbmWRbvCVneUhKtgnLB;

			internal readonly HardwareAxisInfo ecxPoTuiSHhzEinOJuPZQXPtumTW;

			public float value
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).FQqbGdSXrVBQqnhaPQGlAMvRAwJDA;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).sOuaDBFDHDNKOIfGpiaHxVLeHbdbb;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).qYbDKwaLENGhpAeAqreiemTPbNLF;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).SPUtndJtoqwDiPDWQbEUeZwSQUYz;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0f;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).vupWLgwPcrvmuebrlArncfHTLVDQA;
				}
				internal set
				{
					((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).lFRRNndTsejqCLBmOLGbbKBBLbXb(num);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0f;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).GFZjyBqhifCSZSLzyMUmDakCKKpj;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0f;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).vupWLgwPcrvmuebrlArncfHTLVDQA - ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).GFZjyBqhifCSZSLzyMUmDakCKKpj;
				}
			}

			public double lastTimeActive
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).QsKJqEamQklTWDhRHKUzkcqWWKYS;
				}
			}

			public double lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).wYdqqvWbDzfHXhlepVjvSGvwIjkDb;
				}
			}

			public double lastTimeInactive
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).naNpeoIrykxvScbGHIzjzHjOOBWy;
				}
			}

			public double lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).ZwTPszPYHGAfqjRMxlXQYjfRkSot;
				}
			}

			public double lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).TIWrBJgUwoTIHcODTOrQLykkdROH;
				}
			}

			public double lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).kpRlcKLRUgEFSEuaSTDbuiBaFPJY;
				}
			}

			public double timeActive
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).DXFmsKxRacRiRKFdRcqujFaCJCWz;
				}
			}

			public double timeActiveRaw
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).DXFmsKxRacRiRKFdRcqujFaCJCWz;
				}
			}

			public double timeInactive
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).vKOXfKUilmbDrkuNIFOhtZEUuvZjA;
				}
			}

			public double timeInactiveRaw
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).BaMewcuCigzvTLveiRCTPmSzKKVT;
				}
			}

			public float pollingDeadZone
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0f;
					}
					if (ecxPoTuiSHhzEinOJuPZQXPtumTW == null)
					{
						return -1f;
					}
					return ecxPoTuiSHhzEinOJuPZQXPtumTW._pollingDeadZone;
				}
				set
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return;
					}
					if (value < 0f)
					{
						value = -1f;
					}
					if (ecxPoTuiSHhzEinOJuPZQXPtumTW != null)
					{
						ecxPoTuiSHhzEinOJuPZQXPtumTW._pollingDeadZone = value;
					}
				}
			}

			internal float EKOnpeCnjgKwaagizlAqFjHkIKfjA => ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).sOuaDBFDHDNKOIfGpiaHxVLeHbdbb;

			internal float ZsQXRlXFiTzobHVtvCXphmbgmbrO => ((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).SPUtndJtoqwDiPDWQbEUeZwSQUYz;

			internal float StwpIgWxDqfQXZRhKpNYDDFYqJRQ
			{
				get
				{
					if (ecxPoTuiSHhzEinOJuPZQXPtumTW == null)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (ecxPoTuiSHhzEinOJuPZQXPtumTW._pollingDeadZone >= 0f)
					{
						return ecxPoTuiSHhzEinOJuPZQXPtumTW._pollingDeadZone;
					}
					return ecxPoTuiSHhzEinOJuPZQXPtumTW._dataFormat switch
					{
						AxisCoordinateMode.Absolute => ReInput.configuration.defaultAbsoluteAxisPollingDeadZone, 
						AxisCoordinateMode.Relative => ReInput.configuration.defaultRelativeAxisPollingDeadZone, 
						_ => throw new NotImplementedException(), 
					};
				}
			}

			internal void BXalHgvPJKLwACLUhHWfFawDkyBL(float P_0)
			{
				dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA obj = (dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA;
				obj.qYbDKwaLENGhpAeAqreiemTPbNLF = obj.FQqbGdSXrVBQqnhaPQGlAMvRAwJDA;
				obj.FQqbGdSXrVBQqnhaPQGlAMvRAwJDA = P_0;
			}

			internal Axis(Controller P_0, int P_1, string P_2, AxisRange P_3, HardwareAxisInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Axis)
			{
				oopiwvREXxNAEbCTOyqEKOrKGvkk = new dGEAXSeaZljVvAjLeAVuuXmdoSEUB(ReInput.configVars.updateLoop);
				lsQLxcaIvVbmWRbvCVneUhKtgnLB = P_3;
				ecxPoTuiSHhzEinOJuPZQXPtumTW = P_4;
			}

			internal void kPbLcuwUoNvwvGBjaIkoFKFLQPgXA(UpdateLoopType P_0)
			{
				if (oopiwvREXxNAEbCTOyqEKOrKGvkk != null && oopiwvREXxNAEbCTOyqEKOrKGvkk.oydnwUFYhFLJdDFLpULSjkQOElbG != (int)P_0)
				{
					oopiwvREXxNAEbCTOyqEKOrKGvkk.msEotrEGRKHCawvGkseBexNwfklJ = P_0;
				}
			}

			internal void MZtEBsDfBgdNwKjXPShCaOiLYNtfA(AxisCalibration P_0)
			{
				dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA aaSbGwghZFOPaYcNPRUZNhQEpBECA = (dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA;
				aaSbGwghZFOPaYcNPRUZNhQEpBECA.SPUtndJtoqwDiPDWQbEUeZwSQUYz = aaSbGwghZFOPaYcNPRUZNhQEpBECA.sOuaDBFDHDNKOIfGpiaHxVLeHbdbb;
				float sOuaDBFDHDNKOIfGpiaHxVLeHbdbb = P_0.GetCalibratedValue(aaSbGwghZFOPaYcNPRUZNhQEpBECA.vupWLgwPcrvmuebrlArncfHTLVDQA, lsQLxcaIvVbmWRbvCVneUhKtgnLB);
				if (P_0.applyRangeCalibration)
				{
					sOuaDBFDHDNKOIfGpiaHxVLeHbdbb = MathTools.Clamp(sOuaDBFDHDNKOIfGpiaHxVLeHbdbb, -1f, 1f);
				}
				aaSbGwghZFOPaYcNPRUZNhQEpBECA.sOuaDBFDHDNKOIfGpiaHxVLeHbdbb = sOuaDBFDHDNKOIfGpiaHxVLeHbdbb;
			}

			internal void DcZSbafwbVkAyCDKiCeTiIhvqEUj()
			{
				dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA obj = (dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA;
				obj.SPUtndJtoqwDiPDWQbEUeZwSQUYz = obj.sOuaDBFDHDNKOIfGpiaHxVLeHbdbb;
				obj.sOuaDBFDHDNKOIfGpiaHxVLeHbdbb = obj.vupWLgwPcrvmuebrlArncfHTLVDQA;
			}

			internal void NcVotDFoRjhcILgHyezybLBxCgtoA()
			{
				dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA obj = (dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA;
				obj.SPUtndJtoqwDiPDWQbEUeZwSQUYz = obj.sOuaDBFDHDNKOIfGpiaHxVLeHbdbb;
				obj.sOuaDBFDHDNKOIfGpiaHxVLeHbdbb = 0f;
			}

			internal void cKxkfBKpjqDddPJmSatuPVIjrVeG()
			{
				((dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).JgPhBSqhVRkQVrcRNcrwxEAdDrso(base.isMemberElement);
			}

			internal void FDyuYdWcupLJnTbGrnZaTOrqDzrT(float P_0)
			{
				for (int i = 0; i < oopiwvREXxNAEbCTOyqEKOrKGvkk.fAWZtJXuhiOuMVcsuIFSBunRdnIW.Count; i++)
				{
					if (oopiwvREXxNAEbCTOyqEKOrKGvkk.fAWZtJXuhiOuMVcsuIFSBunRdnIW[i] is dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA aaSbGwghZFOPaYcNPRUZNhQEpBECA)
					{
						aaSbGwghZFOPaYcNPRUZNhQEpBECA.lFRRNndTsejqCLBmOLGbbKBBLbXb(P_0);
						aaSbGwghZFOPaYcNPRUZNhQEpBECA.SPUtndJtoqwDiPDWQbEUeZwSQUYz = aaSbGwghZFOPaYcNPRUZNhQEpBECA.sOuaDBFDHDNKOIfGpiaHxVLeHbdbb;
						aaSbGwghZFOPaYcNPRUZNhQEpBECA.sOuaDBFDHDNKOIfGpiaHxVLeHbdbb = 0f;
						aaSbGwghZFOPaYcNPRUZNhQEpBECA.JgPhBSqhVRkQVrcRNcrwxEAdDrso(base.isMemberElement);
					}
				}
			}

			internal float VOiIvPlSYkhtBtHcBsgbHHVDiiyF(UpdateLoopType P_0, AxisCalibration P_1)
			{
				dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA aaSbGwghZFOPaYcNPRUZNhQEpBECA = (dGEAXSeaZljVvAjLeAVuuXmdoSEUB.aaSbGwghZFOPaYcNPRUZNhQEpBECA)oopiwvREXxNAEbCTOyqEKOrKGvkk.fAWZtJXuhiOuMVcsuIFSBunRdnIW[(int)P_0];
				float result = P_1.GetCalibratedValue(aaSbGwghZFOPaYcNPRUZNhQEpBECA.vupWLgwPcrvmuebrlArncfHTLVDQA, lsQLxcaIvVbmWRbvCVneUhKtgnLB, P_1.deadZone, applySensitivity: false, applyInversion: true);
				if (P_1.applyRangeCalibration)
				{
					result = MathTools.Clamp(result, -1f, 1f);
				}
				return result;
			}
		}

		public sealed class Button : Element
		{
			internal class qdLWdUCRBlVjIJMHqVgSNSzrqDSH : sMWgQVDeCjsxpVfukBpTNYQCqwrjA
			{
				public class UgnZJjxXTFqAmooYFnkxjMlilLEC : bDKNnRVdAWXkQGdmGeVhwmHiwavb
				{
					public bool lqFaPBMqxzDnjEENGmhBjaoDESatB;

					public bool uSXFIKsIugZFAGQewBvDCqcedlkdb;

					public ButtonStateRecorder JNZUKPpkkynMjouMNPPmsrpdqqDU;

					public zofruRwGVEervqTPkNbbgrhaaYqP snZaqxHpMyIAHINXwpkCafUIOKSDb;

					public UgnZJjxXTFqAmooYFnkxjMlilLEC()
					{
						JNZUKPpkkynMjouMNPPmsrpdqqDU = new ButtonStateRecorder();
						snZaqxHpMyIAHINXwpkCafUIOKSDb = new zofruRwGVEervqTPkNbbgrhaaYqP(0.3f);
					}

					public void CIiTskDCmubJFAePfVyHvGuFidys(bool P_0)
					{
						if (uSXFIKsIugZFAGQewBvDCqcedlkdb != lqFaPBMqxzDnjEENGmhBjaoDESatB)
						{
							uSXFIKsIugZFAGQewBvDCqcedlkdb = lqFaPBMqxzDnjEENGmhBjaoDESatB;
						}
						if (lqFaPBMqxzDnjEENGmhBjaoDESatB != P_0)
						{
							lqFaPBMqxzDnjEENGmhBjaoDESatB = P_0;
						}
						JNZUKPpkkynMjouMNPPmsrpdqqDU.PKSIiewsISepeCDPnJYsdrHXRYuk(P_0 && !uSXFIKsIugZFAGQewBvDCqcedlkdb, P_0, ReInput.unscaledTime);
						snZaqxHpMyIAHINXwpkCafUIOKSDb.vRhRkGancaRWnErpdojAYOApcXQDA(0.3f, P_0 && !uSXFIKsIugZFAGQewBvDCqcedlkdb, P_0);
					}

					public virtual void ZgUFdrVphsGhHqmWVEkXeIFBRxnE()
					{
						lqFaPBMqxzDnjEENGmhBjaoDESatB = false;
						uSXFIKsIugZFAGQewBvDCqcedlkdb = false;
						JNZUKPpkkynMjouMNPPmsrpdqqDU.tlgirfYAzuCbVATihbkErOBqltOhA();
						snZaqxHpMyIAHINXwpkCafUIOKSDb.AsrgNxWngCIVwCWJIAOJiIBsvIaO();
					}
				}

				public class VHmIWNxUVtQAbkLZkhsCgwkrgCbD : UgnZJjxXTFqAmooYFnkxjMlilLEC
				{
					public float XtzyCKwIxGKrcMFPufZBnyPvDCTB;

					public float xLCVZAmsnVvVdKDGPnAmSeZqJlcN;

					public void FcEOxubhgEpSCXNkhnPGtDPStLoS(float P_0)
					{
						if (xLCVZAmsnVvVdKDGPnAmSeZqJlcN != XtzyCKwIxGKrcMFPufZBnyPvDCTB)
						{
							xLCVZAmsnVvVdKDGPnAmSeZqJlcN = XtzyCKwIxGKrcMFPufZBnyPvDCTB;
						}
						if (XtzyCKwIxGKrcMFPufZBnyPvDCTB != P_0)
						{
							XtzyCKwIxGKrcMFPufZBnyPvDCTB = ((P_0 > 0.001f) ? P_0 : 0f);
						}
						CIiTskDCmubJFAePfVyHvGuFidys(XtzyCKwIxGKrcMFPufZBnyPvDCTB > 0f);
					}

					public virtual void DFcEdSBtkHXDmpsqpsqJayIBwmQdA()
					{
						ZgUFdrVphsGhHqmWVEkXeIFBRxnE();
						XtzyCKwIxGKrcMFPufZBnyPvDCTB = 0f;
						xLCVZAmsnVvVdKDGPnAmSeZqJlcN = 0f;
					}
				}

				public qdLWdUCRBlVjIJMHqVgSNSzrqDSH(UpdateLoopSetting P_0, bool P_1)
					: base(P_0)
				{
					for (int i = 0; i < LXAzQxsxSynocKITKiWjdwFsNUiS; i++)
					{
						if (P_1)
						{
							BVqksvdNPWGquKaYEMTtOgWBpSOZA[i] = new VHmIWNxUVtQAbkLZkhsCgwkrgCbD();
						}
						else
						{
							BVqksvdNPWGquKaYEMTtOgWBpSOZA[i] = new UgnZJjxXTFqAmooYFnkxjMlilLEC();
						}
					}
					JKkBiWHfWgSpxVJoNAzqSPPrHkzcA = BVqksvdNPWGquKaYEMTtOgWBpSOZA[0];
				}

				public void UWyQyDpFNbXjKtaiEsWXMjUGCRcV(float P_0)
				{
					for (int i = 0; i < BVqksvdNPWGquKaYEMTtOgWBpSOZA.Length; i++)
					{
						((UgnZJjxXTFqAmooYFnkxjMlilLEC)BVqksvdNPWGquKaYEMTtOgWBpSOZA[i]).snZaqxHpMyIAHINXwpkCafUIOKSDb.JcPYOyBBzUgCRCsVmVSIJuMnCbOib(P_0);
					}
				}

				public void hIAyjiJgTFVVEWLrSmCDkgFkqnUy()
				{
					for (int i = 0; i < BVqksvdNPWGquKaYEMTtOgWBpSOZA.Length; i++)
					{
						((UgnZJjxXTFqAmooYFnkxjMlilLEC)BVqksvdNPWGquKaYEMTtOgWBpSOZA[i]).snZaqxHpMyIAHINXwpkCafUIOKSDb.JcPYOyBBzUgCRCsVmVSIJuMnCbOib(0.3f);
					}
				}
			}

			internal readonly bool hJoohNzUpdiFQyXaGDbxujyRXXpe;

			internal readonly HardwareButtonInfo mpRxFebTZsOdgrIjAOqlsKzfTTuq;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return false;
					}
					return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).uSXFIKsIugZFAGQewBvDCqcedlkdb;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return false;
					}
					return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).lqFaPBMqxzDnjEENGmhBjaoDESatB;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0f;
					}
					if (!hJoohNzUpdiFQyXaGDbxujyRXXpe)
					{
						if (!((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).lqFaPBMqxzDnjEENGmhBjaoDESatB)
						{
							return 0f;
						}
						return 1f;
					}
					return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.VHmIWNxUVtQAbkLZkhsCgwkrgCbD)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).XtzyCKwIxGKrcMFPufZBnyPvDCTB;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0f;
					}
					if (!hJoohNzUpdiFQyXaGDbxujyRXXpe)
					{
						if (!((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).uSXFIKsIugZFAGQewBvDCqcedlkdb)
						{
							return 0f;
						}
						return 1f;
					}
					return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.VHmIWNxUVtQAbkLZkhsCgwkrgCbD)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).xLCVZAmsnVvVdKDGPnAmSeZqJlcN;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return false;
					}
					return hJoohNzUpdiFQyXaGDbxujyRXXpe;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return false;
					}
					if (!((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).uSXFIKsIugZFAGQewBvDCqcedlkdb && ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).lqFaPBMqxzDnjEENGmhBjaoDESatB)
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
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return false;
					}
					if (((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).uSXFIKsIugZFAGQewBvDCqcedlkdb && !((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).lqFaPBMqxzDnjEENGmhBjaoDESatB)
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
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return false;
					}
					if (((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).uSXFIKsIugZFAGQewBvDCqcedlkdb != ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).lqFaPBMqxzDnjEENGmhBjaoDESatB)
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
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return false;
					}
					return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).snZaqxHpMyIAHINXwpkCafUIOKSDb.kGCGCPLgTFAwoAzPeZpxNgchMSLiA;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).snZaqxHpMyIAHINXwpkCafUIOKSDb.kGCGCPLgTFAwoAzPeZpxNgchMSLiA;
				}
			}

			public double timePressed
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).JNZUKPpkkynMjouMNPPmsrpdqqDU.zFOEFCNuaLGsIafeuIHLpVMDcZHBb;
				}
			}

			public double timeUnpressed
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).JNZUKPpkkynMjouMNPPmsrpdqqDU.POOdWfMRbPgAFlHzTLhFNaJAdemI;
				}
			}

			public double lastTimePressed
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).JNZUKPpkkynMjouMNPPmsrpdqqDU.FaumyGogFmFEsISDJZSHdwdnGQqU;
				}
			}

			public double lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).JNZUKPpkkynMjouMNPPmsrpdqqDU.LshoNgADHlqPDOxMNOcCpAdNFubQ;
				}
			}

			public double lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
					{
						ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
						return 0.0;
					}
					return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).JNZUKPpkkynMjouMNPPmsrpdqqDU.VygcKYgftYFkQNyThmpkmsTlklFAb;
				}
			}

			internal ButtonStateFlags OGgMpaPUoXScCDOwjqwukNKxJSXd
			{
				get
				{
					qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC ugnZJjxXTFqAmooYFnkxjMlilLEC = (qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
					if (ugnZJjxXTFqAmooYFnkxjMlilLEC.lqFaPBMqxzDnjEENGmhBjaoDESatB)
					{
						buttonStateFlags |= ButtonStateFlags.On;
						if (!ugnZJjxXTFqAmooYFnkxjMlilLEC.uSXFIKsIugZFAGQewBvDCqcedlkdb)
						{
							buttonStateFlags |= ButtonStateFlags.Down;
						}
					}
					else if (ugnZJjxXTFqAmooYFnkxjMlilLEC.uSXFIKsIugZFAGQewBvDCqcedlkdb)
					{
						buttonStateFlags |= ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
			}

			internal Button(Controller P_0, int P_1, string P_2, HardwareButtonInfo P_3)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				mpRxFebTZsOdgrIjAOqlsKzfTTuq = P_3;
				oopiwvREXxNAEbCTOyqEKOrKGvkk = new qdLWdUCRBlVjIJMHqVgSNSzrqDSH(ReInput.configVars.updateLoop, false);
			}

			internal Button(Controller P_0, int P_1, string P_2, bool P_3, HardwareButtonInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				mpRxFebTZsOdgrIjAOqlsKzfTTuq = P_4;
				hJoohNzUpdiFQyXaGDbxujyRXXpe = P_3;
				oopiwvREXxNAEbCTOyqEKOrKGvkk = new qdLWdUCRBlVjIJMHqVgSNSzrqDSH(ReInput.configVars.updateLoop, P_3);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
				{
					ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
					return false;
				}
				if (speed <= 0f)
				{
					return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).snZaqxHpMyIAHINXwpkCafUIOKSDb.kGCGCPLgTFAwoAzPeZpxNgchMSLiA;
				}
				return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).JNZUKPpkkynMjouMNPPmsrpdqqDU.yfGOCcfohtkMoYtDTQNeqGDftvMx(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != xGHnuELflkgoUtlGXgjsQVUGyMbY)
				{
					ReInput.CheckInitialized(xGHnuELflkgoUtlGXgjsQVUGyMbY);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).snZaqxHpMyIAHINXwpkCafUIOKSDb.kGCGCPLgTFAwoAzPeZpxNgchMSLiA;
				}
				return ((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).JNZUKPpkkynMjouMNPPmsrpdqqDU.yfGOCcfohtkMoYtDTQNeqGDftvMx(speed);
			}

			internal void fTWEzTFLdtzlCVdXMdxyCsXGIGfy(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (oopiwvREXxNAEbCTOyqEKOrKGvkk != null && oopiwvREXxNAEbCTOyqEKOrKGvkk.oydnwUFYhFLJdDFLpULSjkQOElbG != (int)P_0)
				{
					oopiwvREXxNAEbCTOyqEKOrKGvkk.msEotrEGRKHCawvGkseBexNwfklJ = P_0;
				}
				if (hJoohNzUpdiFQyXaGDbxujyRXXpe)
				{
					((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.VHmIWNxUVtQAbkLZkhsCgwkrgCbD)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).FcEOxubhgEpSCXNkhnPGtDPStLoS(P_2.buttonPressureValues[P_1]);
				}
				else
				{
					((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).CIiTskDCmubJFAePfVyHvGuFidys(P_2.buttonValues[P_1]);
				}
			}

			internal void DPCJchXMPtalpvcajSeBOFnLBxQAA(UpdateLoopType P_0)
			{
				if (oopiwvREXxNAEbCTOyqEKOrKGvkk != null && oopiwvREXxNAEbCTOyqEKOrKGvkk.oydnwUFYhFLJdDFLpULSjkQOElbG != (int)P_0)
				{
					oopiwvREXxNAEbCTOyqEKOrKGvkk.msEotrEGRKHCawvGkseBexNwfklJ = P_0;
				}
				if (hJoohNzUpdiFQyXaGDbxujyRXXpe)
				{
					((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.VHmIWNxUVtQAbkLZkhsCgwkrgCbD)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).FcEOxubhgEpSCXNkhnPGtDPStLoS(0f);
				}
				else
				{
					((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)oopiwvREXxNAEbCTOyqEKOrKGvkk.JKkBiWHfWgSpxVJoNAzqSPPrHkzcA).CIiTskDCmubJFAePfVyHvGuFidys(false);
				}
			}

			internal void HFDHNmVMvLfDZeZMXPEqoncTfRis()
			{
				for (int i = 0; i < oopiwvREXxNAEbCTOyqEKOrKGvkk.fAWZtJXuhiOuMVcsuIFSBunRdnIW.Count; i++)
				{
					sMWgQVDeCjsxpVfukBpTNYQCqwrjA.bDKNnRVdAWXkQGdmGeVhwmHiwavb bDKNnRVdAWXkQGdmGeVhwmHiwavb = oopiwvREXxNAEbCTOyqEKOrKGvkk.fAWZtJXuhiOuMVcsuIFSBunRdnIW[i];
					if (bDKNnRVdAWXkQGdmGeVhwmHiwavb != null)
					{
						if (hJoohNzUpdiFQyXaGDbxujyRXXpe)
						{
							((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.VHmIWNxUVtQAbkLZkhsCgwkrgCbD)bDKNnRVdAWXkQGdmGeVhwmHiwavb).FcEOxubhgEpSCXNkhnPGtDPStLoS(0f);
						}
						else
						{
							((qdLWdUCRBlVjIJMHqVgSNSzrqDSH.UgnZJjxXTFqAmooYFnkxjMlilLEC)bDKNnRVdAWXkQGdmGeVhwmHiwavb).CIiTskDCmubJFAePfVyHvGuFidys(false);
						}
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class bBszvGXnKEcMPgDeCRAFILuUphQf
			{
				public readonly Element hDNjgMdvXNazhrQOzSOKjLkfjxGAA;

				public readonly int CbDjnZtJkCgwbktgaSkxTQLlpXo;

				public bBszvGXnKEcMPgDeCRAFILuUphQf(Element P_0, int P_1)
				{
					hDNjgMdvXNazhrQOzSOKjLkfjxGAA = P_0;
					CbDjnZtJkCgwbktgaSkxTQLlpXo = P_1;
				}
			}

			private int xOPSnnASBDLmczyCOboFhqCbBDWv;

			private string vvYREqANQAuKsODdaHJoqfuNOxOj;

			private CompoundControllerElementType fJhAELzfOZnpEpOBaEqjcUBPbqjs;

			private int qDxPXjViWuesKYajOzYYZmMWrjlP;

			private bBszvGXnKEcMPgDeCRAFILuUphQf[] MBlRXAHcUtuWTCrijxrAgOQbkUtA;

			private Controller MWLBdnTirDephCeyhqHeiclIDOqJ;

			internal readonly int oJLbXQKaFEeCqhRRHMlcQSrXxMIsA;

			public int id
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return -1;
					}
					return xOPSnnASBDLmczyCOboFhqCbBDWv;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return string.Empty;
					}
					return vvYREqANQAuKsODdaHJoqfuNOxOj;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return CompoundControllerElementType.Axis2D;
					}
					return fJhAELzfOZnpEpOBaEqjcUBPbqjs;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return false;
					}
					return qDxPXjViWuesKYajOzYYZmMWrjlP > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return 0;
					}
					return qDxPXjViWuesKYajOzYYZmMWrjlP;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = MWLBdnTirDephCeyhqHeiclIDOqJ.GetElementIdentifierById(xOPSnnASBDLmczyCOboFhqCbBDWv);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			internal CompoundElement(Controller P_0, int P_1, string P_2, CompoundControllerElementType P_3)
			{
				MWLBdnTirDephCeyhqHeiclIDOqJ = P_0;
				xOPSnnASBDLmczyCOboFhqCbBDWv = P_1;
				vvYREqANQAuKsODdaHJoqfuNOxOj = P_2;
				fJhAELzfOZnpEpOBaEqjcUBPbqjs = P_3;
				MBlRXAHcUtuWTCrijxrAgOQbkUtA = new bBszvGXnKEcMPgDeCRAFILuUphQf[elementCapacity];
				oJLbXQKaFEeCqhRRHMlcQSrXxMIsA = ReInput.id;
			}

			internal Element oqCLJoiksQOLFrNphjbgIhzLYmNV(int P_0)
			{
				if (P_0 < 0 || P_0 >= MBlRXAHcUtuWTCrijxrAgOQbkUtA.Length)
				{
					return null;
				}
				if (MBlRXAHcUtuWTCrijxrAgOQbkUtA[P_0] == null)
				{
					return null;
				}
				return MBlRXAHcUtuWTCrijxrAgOQbkUtA[P_0].hDNjgMdvXNazhrQOzSOKjLkfjxGAA;
			}

			internal _0001 oqCLJoiksQOLFrNphjbgIhzLYmNV<_0001>(int P_0) where _0001 : Element
			{
				if (P_0 < 0 || P_0 >= MBlRXAHcUtuWTCrijxrAgOQbkUtA.Length)
				{
					return null;
				}
				if (MBlRXAHcUtuWTCrijxrAgOQbkUtA[P_0] == null)
				{
					return null;
				}
				return MBlRXAHcUtuWTCrijxrAgOQbkUtA[P_0].hDNjgMdvXNazhrQOzSOKjLkfjxGAA as _0001;
			}

			internal _0001 zIfdQEMbqvdGczZlwlmaRkSjFoRO<_0001>(int P_0, out int P_1) where _0001 : Element
			{
				P_1 = -1;
				if (P_0 < 0 || P_0 >= MBlRXAHcUtuWTCrijxrAgOQbkUtA.Length)
				{
					return null;
				}
				if (MBlRXAHcUtuWTCrijxrAgOQbkUtA[P_0] == null)
				{
					return null;
				}
				P_1 = MBlRXAHcUtuWTCrijxrAgOQbkUtA[P_0].CbDjnZtJkCgwbktgaSkxTQLlpXo;
				return MBlRXAHcUtuWTCrijxrAgOQbkUtA[P_0].hDNjgMdvXNazhrQOzSOKjLkfjxGAA as _0001;
			}

			internal bool TMIBaHahUKICjxOKtVYbBVlTdqNfA(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (qDxPXjViWuesKYajOzYYZmMWrjlP >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (bMqDlRichHsBsqhsDcRSNIdowTKpA(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					return false;
				}
				int num = RbBjHOZeXhgJuchZmEzxAwumKWaS();
				if (num < 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				return meaznkvcHfFiaXYlacQGcvRgouWi(P_0, P_1, num);
			}

			internal bool HhvrwxXaZkfaYfUqMrpLTJlQoEeuA(Element P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (qDxPXjViWuesKYajOzYYZmMWrjlP == 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				}
				int num = bMqDlRichHsBsqhsDcRSNIdowTKpA(P_0);
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				return OOmBLSqgfGwNDoWTcgxCweqSEDvw(num);
			}

			internal void awYowshRKQaHJmqgsITajKTPTBPE()
			{
				for (int i = 0; i < MBlRXAHcUtuWTCrijxrAgOQbkUtA.Length; i++)
				{
					OOmBLSqgfGwNDoWTcgxCweqSEDvw(i);
				}
				qDxPXjViWuesKYajOzYYZmMWrjlP = 0;
			}

			private int bMqDlRichHsBsqhsDcRSNIdowTKpA(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				for (int i = 0; i < MBlRXAHcUtuWTCrijxrAgOQbkUtA.Length; i++)
				{
					if (MBlRXAHcUtuWTCrijxrAgOQbkUtA[i] != null && MBlRXAHcUtuWTCrijxrAgOQbkUtA[i].hDNjgMdvXNazhrQOzSOKjLkfjxGAA == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private bool meaznkvcHfFiaXYlacQGcvRgouWi(Element P_0, int P_1, int P_2)
			{
				if (P_2 < 0 || P_2 >= MBlRXAHcUtuWTCrijxrAgOQbkUtA.Length)
				{
					return false;
				}
				if (MBlRXAHcUtuWTCrijxrAgOQbkUtA[P_2] != null)
				{
					return false;
				}
				MBlRXAHcUtuWTCrijxrAgOQbkUtA[P_2] = new bBszvGXnKEcMPgDeCRAFILuUphQf(P_0, P_1);
				P_0.raNhAFCkLnoIhCYZALeBccaaMDJhE(this);
				qDxPXjViWuesKYajOzYYZmMWrjlP++;
				return true;
			}

			private bool OOmBLSqgfGwNDoWTcgxCweqSEDvw(int P_0)
			{
				if (P_0 < 0 || P_0 >= MBlRXAHcUtuWTCrijxrAgOQbkUtA.Length)
				{
					return false;
				}
				if (MBlRXAHcUtuWTCrijxrAgOQbkUtA[P_0] == null)
				{
					return false;
				}
				if (MBlRXAHcUtuWTCrijxrAgOQbkUtA[P_0].hDNjgMdvXNazhrQOzSOKjLkfjxGAA != null)
				{
					MBlRXAHcUtuWTCrijxrAgOQbkUtA[P_0].hDNjgMdvXNazhrQOzSOKjLkfjxGAA.gyaWxfycUrBrcnnXhhayhCPVrHgU(this);
				}
				MBlRXAHcUtuWTCrijxrAgOQbkUtA[P_0] = null;
				qDxPXjViWuesKYajOzYYZmMWrjlP--;
				return true;
			}

			private int RbBjHOZeXhgJuchZmEzxAwumKWaS()
			{
				for (int i = 0; i < MBlRXAHcUtuWTCrijxrAgOQbkUtA.Length; i++)
				{
					if (MBlRXAHcUtuWTCrijxrAgOQbkUtA[i] == null)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int cHlEDfjJPRNOcjDRhDvycPIzUsjfA = 2;

			private CalibrationMap hazLQtzRAGCrrkITBDhDbTUWPpEDA;

			int CompoundElement.elementCapacity => 2;

			public Axis xAxis
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return null;
					}
					return oqCLJoiksQOLFrNphjbgIhzLYmNV<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return null;
					}
					return oqCLJoiksQOLFrNphjbgIhzLYmNV<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return Vector2.zero;
					}
					return ppKNmNzFCsYJtRMUZVqMgBBQgAGt();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return Vector2.zero;
					}
					return StwxanJoIkSBjgCPNirbRUhKbJmiA();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller P_0, int P_1, string P_2, Axis P_3, Axis P_4, int P_5, int P_6, CalibrationMap P_7)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Axis2D)
			{
				TMIBaHahUKICjxOKtVYbBVlTdqNfA(P_3, P_5);
				TMIBaHahUKICjxOKtVYbBVlTdqNfA(P_4, P_6);
				hazLQtzRAGCrrkITBDhDbTUWPpEDA = P_7;
			}

			internal void cmHUboBhuFVUuLBwwxJdXXLnrsIx()
			{
				Vector2 vector = value;
				if (xAxis != null)
				{
					xAxis.BXalHgvPJKLwACLUhHWfFawDkyBL(vector.x);
				}
				if (yAxis != null)
				{
					yAxis.BXalHgvPJKLwACLUhHWfFawDkyBL(vector.y);
				}
			}

			private Vector2 ppKNmNzFCsYJtRMUZVqMgBBQgAGt()
			{
				if (hazLQtzRAGCrrkITBDhDbTUWPpEDA == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = zIfdQEMbqvdGczZlwlmaRkSjFoRO<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = zIfdQEMbqvdGczZlwlmaRkSjFoRO<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRaw ?? 0f;
				float valueRawY = axis2?.valueRaw ?? 0f;
				return hazLQtzRAGCrrkITBDhDbTUWPpEDA.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}

			private Vector2 StwxanJoIkSBjgCPNirbRUhKbJmiA()
			{
				if (hazLQtzRAGCrrkITBDhDbTUWPpEDA == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = zIfdQEMbqvdGczZlwlmaRkSjFoRO<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = zIfdQEMbqvdGczZlwlmaRkSjFoRO<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRawPrev ?? 0f;
				float valueRawY = axis2?.valueRawPrev ?? 0f;
				return hazLQtzRAGCrrkITBDhDbTUWPpEDA.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int FvuxDgyiaUOVFBhWCslPUHKyAVxj = 8;

			private const int YipKDBkQSiJviurMxhJvbeMadGjB = 0;

			private const int xRKBYeMCZzfQsJJzSKacoekwUxLP = 1;

			private const int TyMeebXNdZkklLMqfaxHEkWNFsWnA = 2;

			private const int nMMyDCLQWQbFpMtRcBDDgmibbqddb = 3;

			private const int GyoLJcJbGybAONzInTwwGTEFRqCx = 4;

			private const int YTyCWPeJIeZUZlWzevbFuPwGfezBA = 5;

			private const int FTRBWFXUeSCzDWjUYrYyhxnbpsUJ = 6;

			private const int bdpATIOGmdGTceEuEJZhaoVAxfyAc = 7;

			private readonly int WMBTmcvemXDzwDJDkwnyyeYFDYODA;

			private readonly Button[] kPlaxAxgbhBnThRHOvaSYbMYlBog;

			private readonly ReadOnlyCollection<Button> RPWWxXoKriaMISefanAVuZCJMdUN;

			private readonly int[] LMPDSUyKyUvJTDPLTszYzznlAgig;

			private bool NCBdATiOQNzAYyVlbcrGKILSpKCV;

			int CompoundElement.elementCapacity => 8;

			public bool force4Way
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return false;
					}
					return NCBdATiOQNzAYyVlbcrGKILSpKCV;
				}
				set
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
					}
					else
					{
						NCBdATiOQNzAYyVlbcrGKILSpKCV = value;
					}
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return 0;
					}
					return WMBTmcvemXDzwDJDkwnyyeYFDYODA;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return RPWWxXoKriaMISefanAVuZCJMdUN;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return null;
					}
					return oqCLJoiksQOLFrNphjbgIhzLYmNV<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return null;
					}
					return oqCLJoiksQOLFrNphjbgIhzLYmNV<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return null;
					}
					return oqCLJoiksQOLFrNphjbgIhzLYmNV<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return null;
					}
					return oqCLJoiksQOLFrNphjbgIhzLYmNV<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return null;
					}
					return oqCLJoiksQOLFrNphjbgIhzLYmNV<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return null;
					}
					return oqCLJoiksQOLFrNphjbgIhzLYmNV<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return null;
					}
					return oqCLJoiksQOLFrNphjbgIhzLYmNV<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != oJLbXQKaFEeCqhRRHMlcQSrXxMIsA)
					{
						ReInput.CheckInitialized(oJLbXQKaFEeCqhRRHMlcQSrXxMIsA);
						return null;
					}
					return oqCLJoiksQOLFrNphjbgIhzLYmNV<Button>(7);
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
					TMIBaHahUKICjxOKtVYbBVlTdqNfA(P_3[i], P_4[i]);
				}
				kPlaxAxgbhBnThRHOvaSYbMYlBog = P_3;
				LMPDSUyKyUvJTDPLTszYzznlAgig = P_4;
				WMBTmcvemXDzwDJDkwnyyeYFDYODA = num;
				RPWWxXoKriaMISefanAVuZCJMdUN = new ReadOnlyCollection<Button>(P_3);
			}

			internal void MzwGgvxcdXTkxbOnWZcPZgFWBPVg(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (WMBTmcvemXDzwDJDkwnyyeYFDYODA == 0)
				{
					return;
				}
				if (WMBTmcvemXDzwDJDkwnyyeYFDYODA == 8 && (NCBdATiOQNzAYyVlbcrGKILSpKCV || ReInput.configVars.force4WayHats))
				{
					KuCYMQUVRMFcBmrcLBGjxgxJkdfc(kPlaxAxgbhBnThRHOvaSYbMYlBog[0], LMPDSUyKyUvJTDPLTszYzznlAgig[0], LMPDSUyKyUvJTDPLTszYzznlAgig[7], LMPDSUyKyUvJTDPLTszYzznlAgig[1], P_0, P_1);
					KuCYMQUVRMFcBmrcLBGjxgxJkdfc(kPlaxAxgbhBnThRHOvaSYbMYlBog[2], LMPDSUyKyUvJTDPLTszYzznlAgig[2], LMPDSUyKyUvJTDPLTszYzznlAgig[1], LMPDSUyKyUvJTDPLTszYzznlAgig[3], P_0, P_1);
					KuCYMQUVRMFcBmrcLBGjxgxJkdfc(kPlaxAxgbhBnThRHOvaSYbMYlBog[4], LMPDSUyKyUvJTDPLTszYzznlAgig[4], LMPDSUyKyUvJTDPLTszYzznlAgig[5], LMPDSUyKyUvJTDPLTszYzznlAgig[3], P_0, P_1);
					KuCYMQUVRMFcBmrcLBGjxgxJkdfc(kPlaxAxgbhBnThRHOvaSYbMYlBog[6], LMPDSUyKyUvJTDPLTszYzznlAgig[6], LMPDSUyKyUvJTDPLTszYzznlAgig[5], LMPDSUyKyUvJTDPLTszYzznlAgig[7], P_0, P_1);
					nnveMCcPJvcTpGUyeHNlqCPHPnCIB(kPlaxAxgbhBnThRHOvaSYbMYlBog[1], LMPDSUyKyUvJTDPLTszYzznlAgig[1], P_0, P_1);
					nnveMCcPJvcTpGUyeHNlqCPHPnCIB(kPlaxAxgbhBnThRHOvaSYbMYlBog[3], LMPDSUyKyUvJTDPLTszYzznlAgig[3], P_0, P_1);
					nnveMCcPJvcTpGUyeHNlqCPHPnCIB(kPlaxAxgbhBnThRHOvaSYbMYlBog[5], LMPDSUyKyUvJTDPLTszYzznlAgig[5], P_0, P_1);
					nnveMCcPJvcTpGUyeHNlqCPHPnCIB(kPlaxAxgbhBnThRHOvaSYbMYlBog[7], LMPDSUyKyUvJTDPLTszYzznlAgig[7], P_0, P_1);
					return;
				}
				for (int i = 0; i < kPlaxAxgbhBnThRHOvaSYbMYlBog.Length; i++)
				{
					if (kPlaxAxgbhBnThRHOvaSYbMYlBog[i] != null)
					{
						kPlaxAxgbhBnThRHOvaSYbMYlBog[i].fTWEzTFLdtzlCVdXMdxyCsXGIGfy(P_0, LMPDSUyKyUvJTDPLTszYzznlAgig[i], P_1);
					}
				}
			}

			private void KuCYMQUVRMFcBmrcLBGjxgxJkdfc(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
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
				P_0.fTWEzTFLdtzlCVdXMdxyCsXGIGfy(P_4, P_1, P_5);
			}

			private void nnveMCcPJvcTpGUyeHNlqCPHPnCIB(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
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
					P_0.fTWEzTFLdtzlCVdXMdxyCsXGIGfy(P_2, P_1, P_3);
				}
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller fRCmeciePtbvcayzDTkSAFPwNLYLA;

			private IControllerExtensionSource fsjAoMcnasgFiuJWkFoGtQIswbiCA;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (fRCmeciePtbvcayzDTkSAFPwNLYLA == null)
					{
						return false;
					}
					return fRCmeciePtbvcayzDTkSAFPwNLYLA._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (fRCmeciePtbvcayzDTkSAFPwNLYLA == null)
					{
						return false;
					}
					return fRCmeciePtbvcayzDTkSAFPwNLYLA.enabled;
				}
			}

			internal Controller controller => fRCmeciePtbvcayzDTkSAFPwNLYLA;

			internal Extension(IControllerExtensionSource P_0)
			{
				_reInputId = ReInput.id;
				ZOgaNaRUpivGUOGxYOggFdESQUmO(P_0);
			}

			internal Extension(Extension P_0)
				: this(P_0.fsjAoMcnasgFiuJWkFoGtQIswbiCA)
			{
				fRCmeciePtbvcayzDTkSAFPwNLYLA = P_0.fRCmeciePtbvcayzDTkSAFPwNLYLA;
			}

			internal T GetController<T>() where T : Controller
			{
				if (fRCmeciePtbvcayzDTkSAFPwNLYLA == null)
				{
					return null;
				}
				return fRCmeciePtbvcayzDTkSAFPwNLYLA as T;
			}

			internal void SetController(Controller controller)
			{
				fRCmeciePtbvcayzDTkSAFPwNLYLA = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return fsjAoMcnasgFiuJWkFoGtQIswbiCA;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					ZOgaNaRUpivGUOGxYOggFdESQUmO(null);
				}
				else
				{
					ZOgaNaRUpivGUOGxYOggFdESQUmO(extension.fsjAoMcnasgFiuJWkFoGtQIswbiCA);
				}
			}

			private void ZOgaNaRUpivGUOGxYOggFdESQUmO(IControllerExtensionSource P_0)
			{
				fsjAoMcnasgFiuJWkFoGtQIswbiCA = P_0;
				SourceUpdated(fsjAoMcnasgFiuJWkFoGtQIswbiCA);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		[Serializable]
		private sealed class GspgRbNhaTBYdHkUKbFpOozGEYedA
		{
			public static readonly GspgRbNhaTBYdHkUKbFpOozGEYedA _003C_003E9 = new GspgRbNhaTBYdHkUKbFpOozGEYedA();

			public static Func<Controller, Guid, bool> _003C_003E9__158_0;

			public static Func<Controller, Type, bool> _003C_003E9__161_0;

			internal bool fFeZQsBQQPFPMknVTgMLEBzJAbsw(Controller P_0, Guid P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}

			internal bool ThpmxrneGSUoucSSlrmXYykecrMi(Controller P_0, Type P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}
		}

		private sealed class ArmAWpVZExBYPvtCmsQAPcQdAaVN : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int DKxHwpmsKlejUbwlOgONGNMOGYWe;

			private ControllerPollingInfo SLhJRjjGBikAUBFQufFKbItrwtj;

			private int fKkDmUaOdvXatueGCrsmqSzfmtVx;

			public Controller BJDfsCwMfNsRxSgBzIlZhTgamLpab;

			private int NqqSGjpYxhCnNCfzwTSDIoJHwXnc;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return SLhJRjjGBikAUBFQufFKbItrwtj;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return SLhJRjjGBikAUBFQufFKbItrwtj;
				}
			}

			[DebuggerHidden]
			public ArmAWpVZExBYPvtCmsQAPcQdAaVN(int P_0)
			{
				DKxHwpmsKlejUbwlOgONGNMOGYWe = P_0;
				fKkDmUaOdvXatueGCrsmqSzfmtVx = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int dKxHwpmsKlejUbwlOgONGNMOGYWe = DKxHwpmsKlejUbwlOgONGNMOGYWe;
				Controller bJDfsCwMfNsRxSgBzIlZhTgamLpab = BJDfsCwMfNsRxSgBzIlZhTgamLpab;
				if (dKxHwpmsKlejUbwlOgONGNMOGYWe != 0)
				{
					if (dKxHwpmsKlejUbwlOgONGNMOGYWe != 1)
					{
						return false;
					}
					DKxHwpmsKlejUbwlOgONGNMOGYWe = -1;
					goto IL_00a0;
				}
				DKxHwpmsKlejUbwlOgONGNMOGYWe = -1;
				if (ReInput._id != bJDfsCwMfNsRxSgBzIlZhTgamLpab.FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(bJDfsCwMfNsRxSgBzIlZhTgamLpab.FtWUXMFFyhqCthzgjKfOhWsryipI);
					return false;
				}
				bJDfsCwMfNsRxSgBzIlZhTgamLpab.UpdatePollingFrameTracking();
				NqqSGjpYxhCnNCfzwTSDIoJHwXnc = 0;
				goto IL_00b0;
				IL_00b0:
				if (NqqSGjpYxhCnNCfzwTSDIoJHwXnc < bJDfsCwMfNsRxSgBzIlZhTgamLpab._buttonCount)
				{
					if (bJDfsCwMfNsRxSgBzIlZhTgamLpab.uBcrYdxRQrVIhaHarGlHZRyIkpGO(NqqSGjpYxhCnNCfzwTSDIoJHwXnc, out var num))
					{
						SLhJRjjGBikAUBFQufFKbItrwtj = new ControllerPollingInfo(true, -1, bJDfsCwMfNsRxSgBzIlZhTgamLpab.id, bJDfsCwMfNsRxSgBzIlZhTgamLpab._name, bJDfsCwMfNsRxSgBzIlZhTgamLpab._type, ControllerElementType.Button, NqqSGjpYxhCnNCfzwTSDIoJHwXnc, Pole.Positive, bJDfsCwMfNsRxSgBzIlZhTgamLpab.XRregwEugLWeubJCKxSQAwUDapNP.GetElementIdentifierName(num), num, KeyCode.None);
						DKxHwpmsKlejUbwlOgONGNMOGYWe = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				NqqSGjpYxhCnNCfzwTSDIoJHwXnc++;
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
				ArmAWpVZExBYPvtCmsQAPcQdAaVN armAWpVZExBYPvtCmsQAPcQdAaVN;
				if (DKxHwpmsKlejUbwlOgONGNMOGYWe == -2 && fKkDmUaOdvXatueGCrsmqSzfmtVx == Environment.CurrentManagedThreadId)
				{
					DKxHwpmsKlejUbwlOgONGNMOGYWe = 0;
					armAWpVZExBYPvtCmsQAPcQdAaVN = this;
				}
				else
				{
					armAWpVZExBYPvtCmsQAPcQdAaVN = new ArmAWpVZExBYPvtCmsQAPcQdAaVN(0);
					armAWpVZExBYPvtCmsQAPcQdAaVN.BJDfsCwMfNsRxSgBzIlZhTgamLpab = BJDfsCwMfNsRxSgBzIlZhTgamLpab;
				}
				return armAWpVZExBYPvtCmsQAPcQdAaVN;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class EosuoVBDjAGdJaoFCCPVymGUaabQA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int lXPAZSojRslwEakVZrJeaNczmowO;

			private ControllerPollingInfo ijglfDNQHJPmOXrixsadDdJPALlfA;

			private int EhEMrISjGoZHDXqFUbHeHInfIZKg;

			public Controller gGnuldJNwEvWkuCvQiTlxOMeOJzq;

			private int cvgEDStybCbJOZdUhDRPdoFbbhzG;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ijglfDNQHJPmOXrixsadDdJPALlfA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ijglfDNQHJPmOXrixsadDdJPALlfA;
				}
			}

			[DebuggerHidden]
			public EosuoVBDjAGdJaoFCCPVymGUaabQA(int P_0)
			{
				lXPAZSojRslwEakVZrJeaNczmowO = P_0;
				EhEMrISjGoZHDXqFUbHeHInfIZKg = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = lXPAZSojRslwEakVZrJeaNczmowO;
				Controller controller = gGnuldJNwEvWkuCvQiTlxOMeOJzq;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					lXPAZSojRslwEakVZrJeaNczmowO = -1;
					goto IL_00a0;
				}
				lXPAZSojRslwEakVZrJeaNczmowO = -1;
				if (ReInput._id != controller.FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(controller.FtWUXMFFyhqCthzgjKfOhWsryipI);
					return false;
				}
				controller.UpdatePollingFrameTracking();
				cvgEDStybCbJOZdUhDRPdoFbbhzG = 0;
				goto IL_00b0;
				IL_00b0:
				if (cvgEDStybCbJOZdUhDRPdoFbbhzG < controller._buttonCount)
				{
					if (controller.KIBvQHpiJZvMiCFCWfKVvZKhSTds(cvgEDStybCbJOZdUhDRPdoFbbhzG, out var num2))
					{
						ijglfDNQHJPmOXrixsadDdJPALlfA = new ControllerPollingInfo(true, -1, controller.id, controller._name, controller._type, ControllerElementType.Button, cvgEDStybCbJOZdUhDRPdoFbbhzG, Pole.Positive, controller.XRregwEugLWeubJCKxSQAwUDapNP.GetElementIdentifierName(num2), num2, KeyCode.None);
						lXPAZSojRslwEakVZrJeaNczmowO = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				cvgEDStybCbJOZdUhDRPdoFbbhzG++;
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
				EosuoVBDjAGdJaoFCCPVymGUaabQA eosuoVBDjAGdJaoFCCPVymGUaabQA;
				if (lXPAZSojRslwEakVZrJeaNczmowO == -2 && EhEMrISjGoZHDXqFUbHeHInfIZKg == Environment.CurrentManagedThreadId)
				{
					lXPAZSojRslwEakVZrJeaNczmowO = 0;
					eosuoVBDjAGdJaoFCCPVymGUaabQA = this;
				}
				else
				{
					eosuoVBDjAGdJaoFCCPVymGUaabQA = new EosuoVBDjAGdJaoFCCPVymGUaabQA(0);
					eosuoVBDjAGdJaoFCCPVymGUaabQA.gGnuldJNwEvWkuCvQiTlxOMeOJzq = gGnuldJNwEvWkuCvQiTlxOMeOJzq;
				}
				return eosuoVBDjAGdJaoFCCPVymGUaabQA;
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

		internal readonly Guid sfymSjcVHxtWxMcRdJtqvPLgjYLfA;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension nCSbidyrcaIGKgsXLnryaAJUxTHjA;

		private bool NzHaYDTGnLOCESYXvgSKnzKOHnND;

		private ControllerIdentifier pSngyCbKwmEeNjbyqgPJIehbHHHFB;

		internal int FtWUXMFFyhqCthzgjKfOhWsryipI;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> lJeoleoiZSdelPyCXtjpTuohAguo;

		private readonly ReadOnlyCollection<Element> hlzHWGtgneIdRcLWGRoHWcfOQYwkA;

		private readonly IList<CompoundElement> QBetOfTKxuhjUABVzjFHEgIdJpiL;

		private readonly ReadOnlyCollection<CompoundElement> iENqmmujxHQHTBGhgUXASRzVcfyB;

		[CustomObfuscation(rename = false)]
		internal readonly InputSource inputSource;

		internal readonly ControllerDataUpdater jaSaHPudVtcyecnoPKkgZIAqgGJr;

		internal readonly HardwareControllerMap_Game XRregwEugLWeubJCKxSQAwUDapNP;

		internal uint JAAAseaTSCwNzLFBwjMtADgjEIfgc;

		private uint gsOLqBXWnkHXHYguLgzGYDKprsQW;

		private uint SANQLOVbajBegMtxeOxsSZBpRzlO;

		private Action<bool> PIhIQtjnwSWTpdmSObphGLqTiEcJ;

		private IControllerTemplate[] OzcNZuQIDrvDUhcpJPiYBDcfTLVw;

		private ReadOnlyCollection<IControllerTemplate> gnSyLBMBjbauaYOtUlggpaAJmKzJ;

		private static Func<Controller, Guid, bool> DmyvfiQoPwCixuLpNTeARSlPptKD;

		private static Func<Controller, Type, bool> zRvDzsfIvvBwxKESIMcfaJkaUSvw;

		internal bool OuPbFBCWEqwFFhhPaXrwPBbvBjvgA => gsOLqBXWnkHXHYguLgzGYDKprsQW == ReInput.previousFrame;

		public bool enabled
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return false;
				}
				return NzHaYDTGnLOCESYXvgSKnzKOHnND;
			}
			set
			{
				LAwnernCBTrnUblykcVvSoWLkSFf(value);
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return Guid.Empty;
				}
				return sfymSjcVHxtWxMcRdJtqvPLgjYLfA;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier => pSngyCbKwmEeNjbyqgPJIehbHHHFB;

		public bool isConnected
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return 0;
				}
				return lJeoleoiZSdelPyCXtjpTuohAguo.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return 0;
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return hlzHWGtgneIdRcLWGRoHWcfOQYwkA;
			}
		}

		public IList<CompoundElement> CompoundElements
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return EmptyObjects<CompoundElement>.EmptyReadOnlyIListT;
				}
				return iENqmmujxHQHTBGhgUXASRzVcfyB;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return null;
				}
				return nCSbidyrcaIGKgsXLnryaAJUxTHjA;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return XRregwEugLWeubJCKxSQAwUDapNP.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return XRregwEugLWeubJCKxSQAwUDapNP.buttonElementIdentifiers_readOnly;
			}
		}

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return gnSyLBMBjbauaYOtUlggpaAJmKzJ;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return 0;
				}
				return OzcNZuQIDrvDUhcpJPiYBDcfTLVw.Length;
			}
		}

		internal static Func<Controller, Guid, bool> GxctryFQdLTiRyKyXNsoBJqPIENh => GspgRbNhaTBYdHkUKbFpOozGEYedA._003C_003E9.fFeZQsBQQPFPMknVTgMLEBzJAbsw;

		internal static Func<Controller, Type, bool> jfyhkrMaNhjjBjaTcjQCIBTYndmh => GspgRbNhaTBYdHkUKbFpOozGEYedA._003C_003E9.ThpmxrneGSUoucSSlrmXYykecrMi;

		internal event Action<bool> PmmyLpgcEdGkgyLPrwPauXxdXHmj
		{
			add
			{
				PIhIQtjnwSWTpdmSObphGLqTiEcJ = (Action<bool>)Delegate.Combine(PIhIQtjnwSWTpdmSObphGLqTiEcJ, b);
			}
			remove
			{
				PIhIQtjnwSWTpdmSObphGLqTiEcJ = (Action<bool>)Delegate.Remove(PIhIQtjnwSWTpdmSObphGLqTiEcJ, value2);
			}
		}

		internal Controller(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, bool[] P_8, HardwareButtonInfo[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
		{
			id = P_0;
			inputSource = P_1;
			_type = P_5;
			sfymSjcVHxtWxMcRdJtqvPLgjYLfA = P_6;
			_buttonCount = P_7;
			_name = P_2;
			_hardwareName = P_3;
			_hardwareIdentifier = P_4;
			jaSaHPudVtcyecnoPKkgZIAqgGJr = P_12;
			XRregwEugLWeubJCKxSQAwUDapNP = P_10;
			NzHaYDTGnLOCESYXvgSKnzKOHnND = true;
			FtWUXMFFyhqCthzgjKfOhWsryipI = ReInput.id;
			DInnNpiFkzKPZEpYlRYtYfItQoMc(P_11);
			lJeoleoiZSdelPyCXtjpTuohAguo = new List<Element>(P_7);
			hlzHWGtgneIdRcLWGRoHWcfOQYwkA = new ReadOnlyCollection<Element>(lJeoleoiZSdelPyCXtjpTuohAguo);
			QBetOfTKxuhjUABVzjFHEgIdJpiL = new List<CompoundElement>();
			iENqmmujxHQHTBGhgUXASRzVcfyB = new ReadOnlyCollection<CompoundElement>(QBetOfTKxuhjUABVzjFHEgIdJpiL);
			buttons = new Button[P_7];
			if (P_8 == null || P_8.Length < P_7)
			{
				for (int i = 0; i < P_7; i++)
				{
					buttons[i] = new Button(this, P_10.buttonElementIdentifierIds[i], "Button " + i, false, (P_9 != null) ? P_9[i] : new HardwareButtonInfo());
					CVjGIDIJiXhwLsmsFrqeTAHhDbES(buttons[i]);
				}
			}
			else
			{
				for (int j = 0; j < P_7; j++)
				{
					buttons[j] = new Button(this, P_10.buttonElementIdentifierIds[j], "Button " + j, P_8[j], (P_9 != null) ? P_9[j] : new HardwareButtonInfo());
					CVjGIDIJiXhwLsmsFrqeTAHhDbES(buttons[j]);
				}
			}
			buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
			OzcNZuQIDrvDUhcpJPiYBDcfTLVw = EmptyObjects<IControllerTemplate>.array;
			gnSyLBMBjbauaYOtUlggpaAJmKzJ = new ReadOnlyCollection<IControllerTemplate>(OzcNZuQIDrvDUhcpJPiYBDcfTLVw);
			Connected();
		}

		internal virtual void rHrZhWmlidFfQIdUaELuLMacpKhFA()
		{
			pSngyCbKwmEeNjbyqgPJIehbHHHFB = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return null;
			}
			if (XRregwEugLWeubJCKxSQAwUDapNP == null)
			{
				return null;
			}
			int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0)
			{
				return null;
			}
			return buttons[buttonIndex];
		}

		public virtual CompoundElement GetCompundElementById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return null;
			}
			int count = QBetOfTKxuhjUABVzjFHEgIdJpiL.Count;
			for (int i = 0; i < count; i++)
			{
				if (QBetOfTKxuhjUABVzjFHEgIdJpiL[i] != null && QBetOfTKxuhjUABVzjFHEgIdJpiL[i].id == elementIdentifierId)
				{
					return QBetOfTKxuhjUABVzjFHEgIdJpiL[i];
				}
			}
			return null;
		}

		public int GetButtonIndexById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return -1;
			}
			return XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return null;
			}
			return XRregwEugLWeubJCKxSQAwUDapNP.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].value;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justPressed;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justReleased;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].JustDoublePressed(speed);
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].valuePrev;
		}

		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timePressed;
		}

		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			int buttonIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetButtonIndex(elementIdentifierId);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (uBcrYdxRQrVIhaHarGlHZRyIkpGO(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, XRregwEugLWeubJCKxSQAwUDapNP.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (KIBvQHpiJZvMiCFCWfKVvZKhSTds(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, XRregwEugLWeubJCKxSQAwUDapNP.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return PollForAllButtons();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return PollForAllButtonsDown();
		}

		[IteratorStateMachine(typeof(ArmAWpVZExBYPvtCmsQAPcQdAaVN))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return new ArmAWpVZExBYPvtCmsQAPcQdAaVN(-2)
			{
				BJDfsCwMfNsRxSgBzIlZhTgamLpab = this
			};
		}

		[IteratorStateMachine(typeof(EosuoVBDjAGdJaoFCCPVymGUaabQA))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return new EosuoVBDjAGdJaoFCCPVymGUaabQA(-2)
			{
				gGnuldJNwEvWkuCvQiTlxOMeOJzq = this
			};
		}

		private bool uBcrYdxRQrVIhaHarGlHZRyIkpGO(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].value || buttons[P_0].mpRxFebTZsOdgrIjAOqlsKzfTTuq._excludeFromPolling)
			{
				return false;
			}
			P_1 = XRregwEugLWeubJCKxSQAwUDapNP.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		private bool KIBvQHpiJZvMiCFCWfKVvZKhSTds(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].justPressed || buttons[P_0].mpRxFebTZsOdgrIjAOqlsKzfTTuq._excludeFromPolling)
			{
				return false;
			}
			P_1 = XRregwEugLWeubJCKxSQAwUDapNP.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		protected void UpdatePollingFrameTracking()
		{
			if (SANQLOVbajBegMtxeOxsSZBpRzlO == ReInput.currentFrame)
			{
				return;
			}
			gsOLqBXWnkHXHYguLgzGYDKprsQW = SANQLOVbajBegMtxeOxsSZBpRzlO;
			SANQLOVbajBegMtxeOxsSZBpRzlO = ReInput.currentFrame;
			if (!OuPbFBCWEqwFFhhPaXrwPBbvBjvgA)
			{
				if (JAAAseaTSCwNzLFBwjMtADgjEIfgc == uint.MaxValue)
				{
					JAAAseaTSCwNzLFBwjMtADgjEIfgc = 0u;
				}
				else
				{
					JAAAseaTSCwNzLFBwjMtADgjEIfgc++;
				}
			}
		}

		public virtual double GetLastTimeActive()
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public virtual double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual double GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public double GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return null;
			}
			return nCSbidyrcaIGKgsXLnryaAJUxTHjA as T;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return null;
			}
			for (int i = 0; i < OzcNZuQIDrvDUhcpJPiYBDcfTLVw.Length; i++)
			{
				if (OzcNZuQIDrvDUhcpJPiYBDcfTLVw[i].typeGuid == typeGuid)
				{
					return OzcNZuQIDrvDUhcpJPiYBDcfTLVw[i];
				}
			}
			return null;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return null;
			}
			for (int i = 0; i < OzcNZuQIDrvDUhcpJPiYBDcfTLVw.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(OzcNZuQIDrvDUhcpJPiYBDcfTLVw[i].GetType(), type))
				{
					return OzcNZuQIDrvDUhcpJPiYBDcfTLVw[i];
				}
			}
			return null;
		}

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return null;
			}
			for (int i = 0; i < OzcNZuQIDrvDUhcpJPiYBDcfTLVw.Length; i++)
			{
				if (OzcNZuQIDrvDUhcpJPiYBDcfTLVw[i] as T != null)
				{
					return OzcNZuQIDrvDUhcpJPiYBDcfTLVw[i] as T;
				}
			}
			return null;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			for (int i = 0; i < OzcNZuQIDrvDUhcpJPiYBDcfTLVw.Length; i++)
			{
				if (OzcNZuQIDrvDUhcpJPiYBDcfTLVw[i].typeGuid == typeGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			for (int i = 0; i < OzcNZuQIDrvDUhcpJPiYBDcfTLVw.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(OzcNZuQIDrvDUhcpJPiYBDcfTLVw[i].GetType(), type))
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

		internal void RcKgGhVLmceQaZhbgGLMAQtdJoGw(IControllerTemplate[] P_0)
		{
			if (P_0 != null)
			{
				OzcNZuQIDrvDUhcpJPiYBDcfTLVw = P_0;
				gnSyLBMBjbauaYOtUlggpaAJmKzJ = new ReadOnlyCollection<IControllerTemplate>(OzcNZuQIDrvDUhcpJPiYBDcfTLVw);
			}
		}

		internal virtual void WpPadHsJSmWHmPNyDjEbriEWORwq(UpdateLoopType P_0)
		{
			bool num = ReInput.IsInputAllowed(_type);
			int num2 = _buttonCount;
			if (num)
			{
				for (int i = 0; i < num2; i++)
				{
					if (buttons[i].qrdGheDsBazDidJDNgXkuIyuiaaGb <= 0)
					{
						buttons[i].fTWEzTFLdtzlCVdXMdxyCsXGIGfy(P_0, i, jaSaHPudVtcyecnoPKkgZIAqgGJr);
					}
				}
			}
			else
			{
				for (int j = 0; j < num2; j++)
				{
					if (buttons[j].qrdGheDsBazDidJDNgXkuIyuiaaGb <= 0)
					{
						buttons[j].DPCJchXMPtalpvcajSeBOFnLBxQAA(P_0);
					}
				}
			}
			if (nCSbidyrcaIGKgsXLnryaAJUxTHjA != null)
			{
				nCSbidyrcaIGKgsXLnryaAJUxTHjA.UpdateData(P_0);
			}
		}

		internal virtual ButtonStateFlags kyqBftSHvuReXoRMAYBSHHnbCbRK(int P_0)
		{
			if (P_0 < 0 || P_0 >= _buttonCount)
			{
				return ButtonStateFlags.Off;
			}
			return buttons[P_0].OGgMpaPUoXScCDOwjqwukNKxJSXd;
		}

		internal void DInnNpiFkzKPZEpYlRYtYfItQoMc(Extension P_0)
		{
			if (P_0 == null)
			{
				nCSbidyrcaIGKgsXLnryaAJUxTHjA = null;
				return;
			}
			if (nCSbidyrcaIGKgsXLnryaAJUxTHjA != null)
			{
				RUfXaFdyAqfECHOzugcKayQiDLrw(P_0);
				return;
			}
			P_0.SetController(this);
			nCSbidyrcaIGKgsXLnryaAJUxTHjA = P_0.Clone();
		}

		internal void RUfXaFdyAqfECHOzugcKayQiDLrw(Extension P_0)
		{
			if (nCSbidyrcaIGKgsXLnryaAJUxTHjA != null)
			{
				nCSbidyrcaIGKgsXLnryaAJUxTHjA.SetSource(P_0);
				nCSbidyrcaIGKgsXLnryaAJUxTHjA.SetController(this);
				P_0?.SetController(this);
			}
			else
			{
				DInnNpiFkzKPZEpYlRYtYfItQoMc(P_0);
			}
		}

		internal virtual void oiLcdkgzyxvAnauVHzgHdoryrXqiA()
		{
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i] != null)
				{
					buttons[i].Reset();
				}
			}
			if (jaSaHPudVtcyecnoPKkgZIAqgGJr != null)
			{
				jaSaHPudVtcyecnoPKkgZIAqgGJr.ClearData();
			}
			if (nCSbidyrcaIGKgsXLnryaAJUxTHjA != null)
			{
				nCSbidyrcaIGKgsXLnryaAJUxTHjA.Clear();
			}
		}

		internal virtual bool LAwnernCBTrnUblykcVvSoWLkSFf(bool P_0)
		{
			if (NzHaYDTGnLOCESYXvgSKnzKOHnND == P_0)
			{
				return false;
			}
			if (!P_0)
			{
				oiLcdkgzyxvAnauVHzgHdoryrXqiA();
			}
			NzHaYDTGnLOCESYXvgSKnzKOHnND = P_0;
			if (PIhIQtjnwSWTpdmSObphGLqTiEcJ != null)
			{
				PIhIQtjnwSWTpdmSObphGLqTiEcJ(P_0);
			}
			return true;
		}

		internal virtual void CFaHiJEFpgwiVcWJwPEuwOjLMzZm(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			P_0.controllerId = id;
			IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
			for (int i = 0; i < buttonMaps.Count; i++)
			{
				YTencsjPWuJIOCxnxAitAELcIHlkA(P_0, buttonMaps[i]);
			}
			for (int num = buttonMaps.Count - 1; num >= 0; num--)
			{
				if (buttonMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(buttonMaps[num].oFUAyzlkDBdPoonWGgEIgJYWTzJOA);
				}
			}
		}

		internal virtual void YTencsjPWuJIOCxnxAitAELcIHlkA(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null && P_1._elementType == ControllerElementType.Button)
			{
				P_1.PZvEkWRBkXBIEonMjbHYqghRdEUeA(P_0);
			}
		}

		internal bool IsLhMigbUjEXecGyOLVKpDqHLWvyA(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			P_2 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int rLYEVHHFczfqTKqknfIMkkwHoRbL = P_0.rLYEVHHFczfqTKqknfIMkkwHoRbL;
			if (rLYEVHHFczfqTKqknfIMkkwHoRbL < 0 || rLYEVHHFczfqTKqknfIMkkwHoRbL >= _buttonCount)
			{
				return false;
			}
			P_3 = buttons[rLYEVHHFczfqTKqknfIMkkwHoRbL].hJoohNzUpdiFQyXaGDbxujyRXXpe;
			float num = ((!P_3) ? (buttons[rLYEVHHFczfqTKqknfIMkkwHoRbL].value ? 1f : 0f) : buttons[rLYEVHHFczfqTKqknfIMkkwHoRbL].pressure);
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

		internal bool uabTTFdLmcHfacHzwsFmzogjgfZP(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
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

		internal void CVjGIDIJiXhwLsmsFrqeTAHhDbES(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(lJeoleoiZSdelPyCXtjpTuohAguo, P_0);
			}
		}

		internal void jfCHyspoaXTmfkKJWHiciLsUNkMe(CompoundElement P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(QBetOfTKxuhjUABVzjFHEgIdJpiL, P_0);
			}
		}

		internal virtual Guid bEYVbWSWqRzYLCsZcKBPFokoraOI()
		{
			return Guid.Empty;
		}

		internal virtual void kmaQpzOvBKrdjELpnQNLefZBEXTR(bool P_0)
		{
			if (!P_0 && !ReInput.IsInputAllowed(_type) && nCSbidyrcaIGKgsXLnryaAJUxTHjA != null)
			{
				nCSbidyrcaIGKgsXLnryaAJUxTHjA.Clear();
			}
		}

		protected virtual void Connected()
		{
			_isConnected = true;
		}

		protected virtual void Disconnected()
		{
			_isConnected = false;
			if (jaSaHPudVtcyecnoPKkgZIAqgGJr != null)
			{
				jaSaHPudVtcyecnoPKkgZIAqgGJr.ClearData();
			}
		}
	}
}

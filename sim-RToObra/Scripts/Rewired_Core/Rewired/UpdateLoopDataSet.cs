using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class UpdateLoopDataSet<T> where T : class
	{
		private class OhabrbNxoqPeBqThgRDKwFGKMKG
		{
			public readonly UpdateLoopType uZqPISCyPgGPOetNKiFUKtuJqjV;

			public T AdqDRmvMCTHHDQWIUGnRloZhdLl;

			public OhabrbNxoqPeBqThgRDKwFGKMKG(UpdateLoopType updateLoop)
			{
				uZqPISCyPgGPOetNKiFUKtuJqjV = updateLoop;
			}
		}

		private const int GzGMkBjgUrhNsqriMeLbnGxnqnm = 0;

		private OhabrbNxoqPeBqThgRDKwFGKMKG AaXfcgJdekgBaHxoPeTTheDgCVGd;

		private int oCjExPQBVRiArAcbiSwTmwqUBqb;

		public readonly int fixedUpdateSetIndex = -1;

		private readonly int[] xcSjpzzrNYXAIxAxYcwPczRgjNT;

		private readonly OhabrbNxoqPeBqThgRDKwFGKMKG[] mtnCXNhGEJZnJZGQpwPudPTRhtR;

		private UpdateLoopType gBuNkASdFGZVNuOTDPDQpcgOAgT = (UpdateLoopType)(-1);

		public T Current
		{
			get
			{
				return AaXfcgJdekgBaHxoPeTTheDgCVGd.AdqDRmvMCTHHDQWIUGnRloZhdLl;
			}
		}

		public int Count
		{
			get
			{
				return oCjExPQBVRiArAcbiSwTmwqUBqb;
			}
		}

		public T this[int index]
		{
			get
			{
				if (index >= 0)
				{
					if (index < oCjExPQBVRiArAcbiSwTmwqUBqb)
					{
						goto IL_0038;
					}
					while (true)
					{
						switch (-1882488771 ^ -1882488769)
						{
						case 0:
							break;
						case 2:
							goto end_IL_000d;
						default:
							goto IL_0038;
						}
						continue;
						end_IL_000d:
						break;
					}
				}
				throw new IndexOutOfRangeException();
				IL_0038:
				return mtnCXNhGEJZnJZGQpwPudPTRhtR[index].AdqDRmvMCTHHDQWIUGnRloZhdLl;
			}
			set
			{
				if (index >= 0)
				{
					while (true)
					{
						int num = -1229517427;
						while (true)
						{
							switch (num ^ -1229517425)
							{
							case 0:
								break;
							case 2:
								goto IL_0026;
							case 3:
								goto end_IL_0004;
							default:
								mtnCXNhGEJZnJZGQpwPudPTRhtR[index].AdqDRmvMCTHHDQWIUGnRloZhdLl = value;
								return;
							}
							break;
							IL_0026:
							int num2;
							if (index >= oCjExPQBVRiArAcbiSwTmwqUBqb)
							{
								num = -1229517428;
								num2 = num;
							}
							else
							{
								num = -1229517426;
								num2 = num;
							}
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				throw new IndexOutOfRangeException();
			}
		}

		public UpdateLoopDataSet(UpdateLoopSetting updateLoops)
			: this(updateLoops, (Func<T>)null)
		{
		}

		public UpdateLoopDataSet(UpdateLoopSetting updateLoops, Func<T> instantiatorDelegate)
		{
			List<OhabrbNxoqPeBqThgRDKwFGKMKG> list2 = default(List<OhabrbNxoqPeBqThgRDKwFGKMKG>);
			while (true)
			{
				int num = 1899408826;
				while (true)
				{
					switch (num ^ 0x7136ADB8)
					{
					case 0:
						break;
					case 2:
						goto IL_0032;
					default:
					{
						int num2 = 0;
						using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
						{
							List<UpdateLoopType> list = tList.list;
							EnumConverter.ToUpdateLoopTypes(updateLoops, list);
							for (int i = 0; i < list.Count; i++)
							{
								OhabrbNxoqPeBqThgRDKwFGKMKG ohabrbNxoqPeBqThgRDKwFGKMKG = new OhabrbNxoqPeBqThgRDKwFGKMKG(list[i]);
								if (instantiatorDelegate != null)
								{
									T adqDRmvMCTHHDQWIUGnRloZhdLl = instantiatorDelegate();
									ohabrbNxoqPeBqThgRDKwFGKMKG.AdqDRmvMCTHHDQWIUGnRloZhdLl = adqDRmvMCTHHDQWIUGnRloZhdLl;
								}
								list2.Add(ohabrbNxoqPeBqThgRDKwFGKMKG);
								xcSjpzzrNYXAIxAxYcwPczRgjNT[(int)list[i]] = num2;
								if (list[i] == UpdateLoopType.FixedUpdate)
								{
									fixedUpdateSetIndex = num2;
								}
								num2++;
							}
						}
						mtnCXNhGEJZnJZGQpwPudPTRhtR = list2.ToArray();
						oCjExPQBVRiArAcbiSwTmwqUBqb = mtnCXNhGEJZnJZGQpwPudPTRhtR.Length;
						SetUpdateLoop(mtnCXNhGEJZnJZGQpwPudPTRhtR[0].uZqPISCyPgGPOetNKiFUKtuJqjV);
						return;
					}
					}
					break;
					IL_0032:
					xcSjpzzrNYXAIxAxYcwPczRgjNT = new int[3];
					ArrayTools.Fill(xcSjpzzrNYXAIxAxYcwPczRgjNT, -1);
					list2 = new List<OhabrbNxoqPeBqThgRDKwFGKMKG>();
					num = 1899408825;
				}
			}
		}

		public void SetUpdateLoop(UpdateLoopType updateLoop)
		{
			if (gBuNkASdFGZVNuOTDPDQpcgOAgT == updateLoop)
			{
				return;
			}
			while (true)
			{
				gBuNkASdFGZVNuOTDPDQpcgOAgT = updateLoop;
				int num = -1877599036;
				while (true)
				{
					switch (num ^ -1877599034)
					{
					case 0:
						goto IL_000a;
					case 1:
						break;
					default:
						AaXfcgJdekgBaHxoPeTTheDgCVGd = mtnCXNhGEJZnJZGQpwPudPTRhtR[xcSjpzzrNYXAIxAxYcwPczRgjNT[(int)updateLoop]];
						return;
					}
					break;
					IL_000a:
					num = -1877599033;
				}
			}
		}

		public T Get(int index)
		{
			if (index >= 0)
			{
				if (index < oCjExPQBVRiArAcbiSwTmwqUBqb)
				{
					goto IL_0038;
				}
				while (true)
				{
					switch (0x174C2F95 ^ 0x174C2F94)
					{
					case 2:
						break;
					case 1:
						goto end_IL_000d;
					default:
						goto IL_0038;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			throw new IndexOutOfRangeException();
			IL_0038:
			return mtnCXNhGEJZnJZGQpwPudPTRhtR[index].AdqDRmvMCTHHDQWIUGnRloZhdLl;
		}

		public T Get(UpdateLoopType updateLoop)
		{
			return mtnCXNhGEJZnJZGQpwPudPTRhtR[xcSjpzzrNYXAIxAxYcwPczRgjNT[(int)updateLoop]].AdqDRmvMCTHHDQWIUGnRloZhdLl;
		}

		public void Set(int index, T item)
		{
			if (index >= 0)
			{
				if (index < oCjExPQBVRiArAcbiSwTmwqUBqb)
				{
					goto IL_0038;
				}
				while (true)
				{
					switch (0x4A041845 ^ 0x4A041844)
					{
					case 0:
						break;
					case 1:
						goto end_IL_000d;
					default:
						goto IL_0038;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			throw new IndexOutOfRangeException();
			IL_0038:
			mtnCXNhGEJZnJZGQpwPudPTRhtR[index].AdqDRmvMCTHHDQWIUGnRloZhdLl = item;
		}

		protected UpdateLoopType GetUpdateLoopType(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = -1029193666;
					while (true)
					{
						switch (num ^ -1029193665)
						{
						case 3:
							break;
						case 1:
							goto IL_0026;
						case 2:
							goto end_IL_0004;
						default:
							return mtnCXNhGEJZnJZGQpwPudPTRhtR[index].uZqPISCyPgGPOetNKiFUKtuJqjV;
						}
						break;
						IL_0026:
						int num2;
						if (index >= oCjExPQBVRiArAcbiSwTmwqUBqb)
						{
							num = -1029193667;
							num2 = num;
						}
						else
						{
							num = -1029193665;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}
	}
}

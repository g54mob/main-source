using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class ActionCategoryMap
	{
		[Serializable]
		public class Entry
		{
			private sealed class zzQFdtgYAkTlvJxCxUraLfpfHKYj : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
			{
				private int ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public Entry syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public int hiVyGFBHBEUrTbjNbbkGOXgGryf;

				int IEnumerator<int>.Current
				{
					[DebuggerHidden]
					get
					{
						return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
					}
				}

				[DebuggerHidden]
				IEnumerator<int> IEnumerable<int>.GetEnumerator()
				{
					zzQFdtgYAkTlvJxCxUraLfpfHKYj zzQFdtgYAkTlvJxCxUraLfpfHKYj2;
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						zzQFdtgYAkTlvJxCxUraLfpfHKYj2 = this;
					}
					else
					{
						while (true)
						{
							zzQFdtgYAkTlvJxCxUraLfpfHKYj2 = new zzQFdtgYAkTlvJxCxUraLfpfHKYj(0);
							int num = 1086785443;
							while (true)
							{
								switch (num ^ 0x40C707A1)
								{
								case 0:
									num = 1086785440;
									continue;
								case 1:
									break;
								case 2:
									zzQFdtgYAkTlvJxCxUraLfpfHKYj2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
									num = 1086785442;
									continue;
								default:
									goto end_IL_0049;
								}
								break;
							}
							continue;
							end_IL_0049:
							break;
						}
					}
					return zzQFdtgYAkTlvJxCxUraLfpfHKYj2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<int>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = 1687575157;
						while (true)
						{
							switch (num2 ^ 0x64965A7C)
							{
							case 2:
								break;
							case 4:
								return true;
							case 1:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionIds[hiVyGFBHBEUrTbjNbbkGOXgGryf];
								num2 = 1687575164;
								continue;
							case 7:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionIds != null)
								{
									hiVyGFBHBEUrTbjNbbkGOXgGryf = 0;
									num2 = 1687575167;
									continue;
								}
								goto default;
							case 8:
							{
								int num3;
								if (hiVyGFBHBEUrTbjNbbkGOXgGryf >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.actionIds.Count)
								{
									num2 = 1687575161;
									num3 = num2;
								}
								else
								{
									num2 = 1687575165;
									num3 = num2;
								}
								continue;
							}
							case 3:
								num2 = 1687575156;
								continue;
							case 0:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num2 = 1687575160;
								continue;
							case 9:
								switch (num)
								{
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									hiVyGFBHBEUrTbjNbbkGOXgGryf++;
									num2 = 1687575156;
									continue;
								case 0:
									break;
								default:
									num2 = 1687575162;
									continue;
								}
								goto case 7;
							case 6:
								num2 = 1687575161;
								continue;
							default:
								return false;
							}
							break;
						}
					}
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
				public zzQFdtgYAkTlvJxCxUraLfpfHKYj(int _003C_003E1__state)
				{
					while (true)
					{
						int num = 401408368;
						while (true)
						{
							switch (num ^ 0x17ED0171)
							{
							case 0:
								break;
							default:
								return;
							case 1:
								goto IL_0024;
							case 2:
								return;
							}
							break;
							IL_0024:
							isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
							TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
							num = 401408371;
						}
					}
				}
			}

			public int categoryId;

			public List<int> actionIds;

			public IEnumerable<int> ActionIds
			{
				get
				{
					zzQFdtgYAkTlvJxCxUraLfpfHKYj zzQFdtgYAkTlvJxCxUraLfpfHKYj2 = new zzQFdtgYAkTlvJxCxUraLfpfHKYj(-2);
					zzQFdtgYAkTlvJxCxUraLfpfHKYj2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					return zzQFdtgYAkTlvJxCxUraLfpfHKYj2;
				}
			}

			public Entry()
			{
				actionIds = new List<int>();
			}

			public Entry(int categoryId)
				: this()
			{
				this.categoryId = categoryId;
			}

			public Entry(Entry source)
			{
				while (true)
				{
					int num = 742273944;
					while (true)
					{
						switch (num ^ 0x2C3E339A)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0024;
						case 1:
							return;
						}
						break;
						IL_0024:
						actionIds = ListTools.ShallowCopy(source.actionIds);
						num = 742273947;
					}
				}
			}

			public void AddAction(int actionId)
			{
				if (!actionIds.Contains(actionId))
				{
					actionIds.Add(actionId);
				}
			}

			public bool InsertAction(int actionId, int index)
			{
				if (index < 0)
				{
					goto IL_0004;
				}
				if (actionIds.Contains(actionId))
				{
					return true;
				}
				int num;
				if (index >= actionIds.Count)
				{
					actionIds.Add(actionId);
					num = 857577650;
					goto IL_0009;
				}
				goto IL_0059;
				IL_0004:
				num = 857577648;
				goto IL_0009;
				IL_0009:
				switch (num ^ 0x331D98B3)
				{
				case 0:
					break;
				case 3:
					return false;
				case 2:
					goto IL_0059;
				default:
					return true;
				}
				goto IL_0004;
				IL_0059:
				actionIds.Insert(index, actionId);
				num = 857577650;
				goto IL_0009;
			}

			public bool ReorderAction(int actionId, bool offsetDown, bool offsetNow)
			{
				int num = IndexOfAction(actionId);
				if (num < 0)
				{
					return false;
				}
				if (!offsetDown && num == 0)
				{
					goto IL_0014;
				}
				if (offsetDown && num >= actionIds.Count - 1)
				{
					return false;
				}
				if (!offsetNow)
				{
					return true;
				}
				int value = actionIds[num];
				int num2;
				if (offsetDown)
				{
					actionIds[num] = actionIds[num + 1];
					actionIds[num + 1] = value;
					num2 = 1340571803;
					goto IL_0019;
				}
				goto IL_00c3;
				IL_0019:
				while (true)
				{
					switch (num2 ^ 0x4FE78099)
					{
					case 5:
						break;
					case 1:
						return false;
					case 2:
						num2 = 1340571802;
						continue;
					case 4:
						actionIds[num - 1] = value;
						num2 = 1340571802;
						continue;
					case 0:
						goto IL_00c3;
					default:
						return true;
					}
					break;
				}
				goto IL_0014;
				IL_0014:
				num2 = 1340571800;
				goto IL_0019;
				IL_00c3:
				actionIds[num] = actionIds[num - 1];
				num2 = 1340571805;
				goto IL_0019;
			}

			public void RemoveAction(int actionId)
			{
				int num = IndexOfAction(actionId);
				if (num >= 0)
				{
					actionIds.RemoveAt(num);
				}
			}

			public int IndexOfAction(int id)
			{
				if (actionIds == null)
				{
					goto IL_0008;
				}
				int num = 0;
				int num2 = 1675426569;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num2 ^ 0x63DCFB09)
					{
					case 4:
						break;
					case 2:
						if (actionIds[num] == id)
						{
							num2 = 1675426570;
							continue;
						}
						num++;
						num2 = 1675426568;
						continue;
					case 3:
						return num;
					case 5:
						return -1;
					case 0:
						num2 = 1675426568;
						continue;
					default:
						if (num >= actionIds.Count)
						{
							return -1;
						}
						goto case 2;
					}
					break;
				}
				goto IL_0008;
				IL_0008:
				num2 = 1675426572;
				goto IL_000d;
			}

			public bool ContainsAction(int id)
			{
				return IndexOfAction(id) >= 0;
			}

			public Entry Clone()
			{
				return new Entry(this);
			}
		}

		private sealed class VrBqLsCshZDtPJJIxGvSAYKeDKR : IDisposable, IEnumerable<int>, IEnumerator<int>, IEnumerator, IEnumerable
		{
			private int ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public ActionCategoryMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int zyxfKmmGBAIKBECdOlnoEPzdzfBO;

			public int UhsycSZObtJgBZPiZPsnHWKIQVY;

			public int WWeDNKkICUooiNtSnKZJzuWpGQgG;

			public int vPNEamBwkSFcykYTQpVoocpGEPFB;

			public IEnumerator<int> KMgVEhuoYioXREaDfevsvSEgFVu;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					goto IL_0023;
				}
				goto IL_0049;
				IL_0028:
				int num;
				VrBqLsCshZDtPJJIxGvSAYKeDKR vrBqLsCshZDtPJJIxGvSAYKeDKR = default(VrBqLsCshZDtPJJIxGvSAYKeDKR);
				while (true)
				{
					switch (num ^ -776702442)
					{
					case 3:
						break;
					case 0:
						goto IL_0049;
					case 2:
						num = -776702446;
						continue;
					case 1:
						vrBqLsCshZDtPJJIxGvSAYKeDKR = this;
						num = -776702444;
						continue;
					default:
						vrBqLsCshZDtPJJIxGvSAYKeDKR.zyxfKmmGBAIKBECdOlnoEPzdzfBO = UhsycSZObtJgBZPiZPsnHWKIQVY;
						return vrBqLsCshZDtPJJIxGvSAYKeDKR;
					}
					break;
				}
				goto IL_0023;
				IL_0049:
				vrBqLsCshZDtPJJIxGvSAYKeDKR = new VrBqLsCshZDtPJJIxGvSAYKeDKR(0);
				vrBqLsCshZDtPJJIxGvSAYKeDKR.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = -776702446;
				goto IL_0028;
				IL_0023:
				num = -776702441;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num;
					int num3;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					default:
						num = -1498146416;
						goto IL_001e;
					case 1:
						goto IL_006c;
					case 2:
						goto IL_0075;
					case 0:
						goto IL_0116;
						IL_001e:
						while (true)
						{
							switch (num ^ -1498146409)
							{
							case 10:
								break;
							default:
								goto end_IL_0008;
							case 5:
								result = true;
								goto end_IL_0008;
							case 0:
								goto IL_006c;
							case 4:
								goto IL_0075;
							case 6:
								goto IL_0083;
							case 2:
								vPNEamBwkSFcykYTQpVoocpGEPFB = KMgVEhuoYioXREaDfevsvSEgFVu.Current;
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = vPNEamBwkSFcykYTQpVoocpGEPFB;
								num = -1498146410;
								continue;
							case 11:
								if (!KMgVEhuoYioXREaDfevsvSEgFVu.MoveNext())
								{
									WGmZBpthxKLXLScOLKGOOIsFBTjJ();
									num = -1498146409;
									continue;
								}
								goto case 2;
							case 7:
								num = -1498146409;
								continue;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
								num = -1498146414;
								continue;
							case 9:
								goto IL_0116;
							case 3:
								KMgVEhuoYioXREaDfevsvSEgFVu = syCPfFbHYMDOvEPjTnPLBqiOhsPv.list[WWeDNKkICUooiNtSnKZJzuWpGQgG].ActionIds.GetEnumerator();
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = -1498146404;
								continue;
							case 8:
								goto end_IL_0008;
							}
							break;
							IL_0083:
							WWeDNKkICUooiNtSnKZJzuWpGQgG = syCPfFbHYMDOvEPjTnPLBqiOhsPv.IndexOfCategory(zyxfKmmGBAIKBECdOlnoEPzdzfBO);
							int num2;
							if (WWeDNKkICUooiNtSnKZJzuWpGQgG < 0)
							{
								num = -1498146409;
								num2 = num;
							}
							else
							{
								num = -1498146412;
								num2 = num;
							}
						}
						goto default;
						IL_0116:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.list == null)
						{
							num = -1498146409;
							num3 = num;
						}
						else
						{
							num = -1498146415;
							num3 = num;
						}
						goto IL_001e;
						IL_0075:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
						num = -1498146404;
						goto IL_001e;
						IL_006c:
						result = false;
						num = -1498146401;
						goto IL_001e;
						end_IL_0008:
						break;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
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
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						WGmZBpthxKLXLScOLKGOOIsFBTjJ();
					}
				}
			}

			[DebuggerHidden]
			public VrBqLsCshZDtPJJIxGvSAYKeDKR(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}

			private void WGmZBpthxKLXLScOLKGOOIsFBTjJ()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				if (KMgVEhuoYioXREaDfevsvSEgFVu == null)
				{
					return;
				}
				while (true)
				{
					int num = -950393622;
					while (true)
					{
						switch (num ^ -950393624)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_002d;
						case 1:
							return;
						}
						break;
						IL_002d:
						KMgVEhuoYioXREaDfevsvSEgFVu.Dispose();
						num = -950393623;
					}
				}
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Entry> list;

		public IEnumerable<int> ActionIdsInCategory(int categoryId)
		{
			VrBqLsCshZDtPJJIxGvSAYKeDKR vrBqLsCshZDtPJJIxGvSAYKeDKR = new VrBqLsCshZDtPJJIxGvSAYKeDKR(-2);
			vrBqLsCshZDtPJJIxGvSAYKeDKR.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			vrBqLsCshZDtPJJIxGvSAYKeDKR.UhsycSZObtJgBZPiZPsnHWKIQVY = categoryId;
			return vrBqLsCshZDtPJJIxGvSAYKeDKR;
		}

		public ActionCategoryMap()
		{
			list = new List<Entry>();
		}

		public ActionCategoryMap(ActionCategoryMap source)
		{
			if (source.list != null)
			{
				list = new List<Entry>(source.list.Count);
				for (int i = 0; i < source.list.Count; i++)
				{
					list[i] = source.list[i].Clone();
				}
			}
		}

		public void AddCategory(int id)
		{
			list.Add(new Entry(id));
		}

		public void RemoveCategory(int id)
		{
			int num = IndexOfCategory(id);
			if (num >= 0)
			{
				list.RemoveAt(num);
			}
		}

		public bool ReorderCategory(int id, bool offsetDown)
		{
			int num = IndexOfCategory(id);
			if (num < 0)
			{
				return false;
			}
			if (!offsetDown)
			{
				goto IL_0011;
			}
			goto IL_0043;
			IL_0043:
			if (offsetDown && num >= list.Count - 1)
			{
				return false;
			}
			Entry value = list[num];
			int num2;
			if (offsetDown)
			{
				list[num] = list[num + 1];
				list[num + 1] = value;
				num2 = -372791681;
				goto IL_0016;
			}
			goto IL_00b4;
			IL_0011:
			num2 = -372791688;
			goto IL_0016;
			IL_0016:
			while (true)
			{
				switch (num2 ^ -372791684)
				{
				case 0:
					break;
				case 4:
					goto IL_003e;
				case 2:
					list[num - 1] = value;
					num2 = -372791687;
					continue;
				case 1:
					goto IL_00b4;
				case 3:
					num2 = -372791687;
					continue;
				default:
					return true;
				}
				break;
			}
			goto IL_0011;
			IL_00b4:
			list[num] = list[num - 1];
			num2 = -372791682;
			goto IL_0016;
			IL_003e:
			if (num == 0)
			{
				return false;
			}
			goto IL_0043;
		}

		public bool ChangeCategory(int actionId, int newCategoryId)
		{
			if (list == null)
			{
				return false;
			}
			bool result = false;
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = -2067965433;
				while (true)
				{
					switch (num ^ -2067965438)
					{
					case 9:
						break;
					case 6:
						if (list[num2].ContainsAction(actionId))
						{
							list[num2].RemoveAction(actionId);
							num = -2067965440;
							continue;
						}
						goto case 2;
					case 7:
						num = -2067965434;
						continue;
					case 4:
					{
						int num4;
						if (num3 >= list.Count)
						{
							num = -2067965430;
							num4 = num;
						}
						else
						{
							num = -2067965438;
							num4 = num;
						}
						continue;
					}
					case 0:
						if (list[num3].categoryId == newCategoryId)
						{
							list[num3].AddAction(actionId);
							num = -2067965432;
							continue;
						}
						goto case 11;
					case 2:
						num2++;
						num = -2067965437;
						continue;
					case 3:
						num = -2067965437;
						continue;
					case 11:
						num3++;
						num = -2067965434;
						continue;
					case 5:
						num2 = 0;
						num = -2067965439;
						continue;
					case 10:
						result = true;
						num = -2067965431;
						continue;
					case 1:
						if (num2 >= list.Count)
						{
							num3 = 0;
							num = -2067965435;
							continue;
						}
						goto case 6;
					default:
						return result;
					}
					break;
				}
			}
		}

		public int IndexOfCategory(int id)
		{
			if (list == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2 = 1752964055;
				while (true)
				{
					switch (num2 ^ 0x687C1BD3)
					{
					case 0:
						break;
					case 4:
						num2 = 1752964049;
						continue;
					case 2:
					{
						int num3;
						if (num >= list.Count)
						{
							num2 = 1752964050;
							num3 = num2;
						}
						else
						{
							num2 = 1752964048;
							num3 = num2;
						}
						continue;
					}
					case 3:
						if (list[num].categoryId == id)
						{
							return num;
						}
						num++;
						num2 = 1752964049;
						continue;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public bool AddAction(int categoryId, int actionId)
		{
			if (list == null)
			{
				goto IL_0008;
			}
			int num = IndexOfCategory(categoryId);
			int num2 = 1350495764;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ 0x507EEE14)
				{
				case 3:
					break;
				case 1:
					return false;
				case 0:
					if (num < 0)
					{
						goto IL_003f;
					}
					list[num].AddAction(actionId);
					return true;
				default:
					return false;
				}
				break;
				IL_003f:
				num2 = 1350495766;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1350495765;
			goto IL_000d;
		}

		public bool InsertAction(int categoryId, int actionId, int index)
		{
			if (index < 0)
			{
				return false;
			}
			int num = IndexOfCategory(categoryId);
			if (num < 0)
			{
				return false;
			}
			return list[num].InsertAction(actionId, index);
		}

		public bool ReorderAction(int categoryId, int actionId, bool offsetDown, bool offsetNow)
		{
			int num = IndexOfCategory(categoryId);
			while (true)
			{
				int num2 = -253374582;
				while (true)
				{
					switch (num2 ^ -253374584)
					{
					case 0:
						break;
					case 2:
						if (num < 0)
						{
							goto IL_002a;
						}
						return list[num].ReorderAction(actionId, offsetDown, offsetNow);
					default:
						return false;
					}
					break;
					IL_002a:
					num2 = -253374583;
				}
			}
		}

		public void RemoveAction(int categoryId, int actionId)
		{
			int num = IndexOfCategory(categoryId);
			if (num >= 0)
			{
				list[num].RemoveAction(actionId);
			}
		}

		public int IndexOfAction(int categoryId, int actionId)
		{
			int num = IndexOfCategory(categoryId);
			if (num < 0)
			{
				return -1;
			}
			return list[num].IndexOfAction(actionId);
		}

		public ActionCategoryMap Clone()
		{
			return new ActionCategoryMap(this);
		}
	}
}

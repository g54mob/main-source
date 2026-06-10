using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace TwitchSDK.Interop
{
	public static class Types
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MarshallableTaskCallback(IntPtr ret, IntPtr completion);

		public class TypeMarshallingInfo
		{
			private static readonly Type[] PlainDataTypes = new Type[4]
			{
				typeof(int),
				typeof(long),
				typeof(byte),
				typeof(IntPtr)
			};

			private static readonly Type[] ReferenceTypes = new Type[1] { typeof(GenericTaskCallback) };

			public PropMarshallingInfo[] Properties { get; }

			public int Size { get; private set; }

			public TypeMarshallingInfo(Type type)
			{
				Size = 0;
				List<PropMarshallingInfo> list = new List<PropMarshallingInfo>();
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					Type type2 = fieldInfo.FieldType;
					int? num = null;
					PropMarshallingInfo propMarshallingInfo = new PropMarshallingInfo
					{
						PropInfo = fieldInfo,
						IsPlain = false,
						IsEnum = false
					};
					if (type2.IsEnum)
					{
						type2 = type2.GetEnumUnderlyingType();
						propMarshallingInfo.IsEnum = true;
					}
					propMarshallingInfo.Type = type2;
					int num2;
					if (PlainDataTypes.Contains(type2))
					{
						num2 = Marshal.SizeOf(type2);
						propMarshallingInfo.IsPlain = true;
					}
					else if (type2 == typeof(bool))
					{
						num2 = 1;
					}
					else if (ReferenceTypes.Contains(type2))
					{
						num2 = IntPtr.Size;
					}
					else if (type2 == typeof(string))
					{
						num2 = IntPtr.Size + 8;
						num = IntPtr.Size;
					}
					else if (type2 == typeof(string[]))
					{
						num2 = 2 * IntPtr.Size;
						num = IntPtr.Size;
					}
					else if (type2.IsArray)
					{
						num2 = IntPtr.Size + 8;
						num = IntPtr.Size;
					}
					else
					{
						if (!typeof(IMarshallable).IsAssignableFrom(type2))
						{
							throw new InvalidProgramException();
						}
						num2 = GetForNestedType(type2).Size;
						num = IntPtr.Size;
					}
					int num3 = num ?? num2;
					int num4 = Size % num3;
					if (num4 != 0)
					{
						Size += num3 - num4;
					}
					propMarshallingInfo.Offset = Size;
					list.Add(propMarshallingInfo);
					Size += num2;
				}
				int num5 = Size % IntPtr.Size;
				if (num5 != 0)
				{
					Size += IntPtr.Size - num5;
				}
				Properties = list.ToArray();
			}

			public IntPtr Serialize(object value)
			{
				IntPtr intPtr = Marshal.AllocHGlobal(Size);
				Serialize(intPtr, value);
				return intPtr;
			}

			public void Serialize(IntPtr data, object value)
			{
				PropMarshallingInfo[] properties = Properties;
				foreach (PropMarshallingInfo propMarshallingInfo in properties)
				{
					Type type = propMarshallingInfo.Type;
					object obj = propMarshallingInfo.PropInfo.GetValue(value);
					if (propMarshallingInfo.IsEnum)
					{
						obj = Convert.ChangeType(obj, type);
					}
					if (propMarshallingInfo.IsPlain)
					{
						Marshal.StructureToPtr(obj, data + propMarshallingInfo.Offset, fDeleteOld: false);
						continue;
					}
					if (type == typeof(bool))
					{
						Marshal.WriteByte(data, propMarshallingInfo.Offset, (byte)(((bool)obj) ? 1u : 0u));
						continue;
					}
					IntPtr intPtr;
					if (type == typeof(string))
					{
						intPtr = Marshal.StringToHGlobalUni((string)obj);
						Marshal.WriteInt32(data, propMarshallingInfo.Offset + IntPtr.Size, ((string)obj)?.Length ?? 0);
					}
					else if (type == typeof(string[]))
					{
						IntPtr intPtr2;
						if (obj == null)
						{
							intPtr = IntPtr.Zero;
							intPtr2 = IntPtr.Zero;
						}
						else
						{
							string[] array = (string[])obj;
							intPtr = Marshal.AllocHGlobal(array.Length * IntPtr.Size);
							intPtr2 = Marshal.AllocHGlobal((array.Length + 1) * 4);
							Marshal.WriteInt32(intPtr2, 0, array.Length);
							for (int j = 0; j < array.Length; j++)
							{
								Marshal.WriteIntPtr(intPtr, j * IntPtr.Size, Marshal.StringToHGlobalUni(array[j]));
								Marshal.WriteInt32(intPtr2, (j + 1) * 4, array[j]?.Length ?? 0);
							}
						}
						Marshal.WriteIntPtr(data, propMarshallingInfo.Offset + IntPtr.Size, intPtr2);
					}
					else
					{
						if (!type.IsArray)
						{
							throw new InvalidProgramException();
						}
						TypeMarshallingInfo forNestedType = GetForNestedType(type.GetElementType());
						Array array2 = (obj as Array) ?? Array.Empty<object>();
						Marshal.WriteInt32(data, propMarshallingInfo.Offset + IntPtr.Size, array2.Length);
						if (array2.Length == 0)
						{
							intPtr = IntPtr.Zero;
						}
						else
						{
							intPtr = Marshal.AllocHGlobal(array2.Length * forNestedType.Size);
							for (int k = 0; k < array2.Length; k++)
							{
								forNestedType.Serialize(intPtr + k * forNestedType.Size, array2.GetValue(k));
							}
						}
					}
					Marshal.WriteIntPtr(data, propMarshallingInfo.Offset, intPtr);
				}
			}

			private static TypeMarshallingInfo GetForNestedType(Type tele)
			{
				return (TypeMarshallingInfo)typeof(StructHolder<>).MakeGenericType(tele).GetField("MarshalInfo").GetValue(null);
			}

			public T Deserialize<T>(IntPtr ptr)
			{
				return (T)Deserialize(ptr, typeof(T));
			}

			public object Deserialize(IntPtr ptr, Type type)
			{
				object obj = Activator.CreateInstance(type);
				PropMarshallingInfo[] properties = Properties;
				foreach (PropMarshallingInfo propMarshallingInfo in properties)
				{
					Type type2 = propMarshallingInfo.Type;
					object value;
					if (propMarshallingInfo.IsPlain)
					{
						value = Marshal.PtrToStructure(ptr + propMarshallingInfo.Offset, type2);
					}
					else if (type2 == typeof(bool))
					{
						value = Marshal.ReadByte(ptr, propMarshallingInfo.Offset) != 0;
					}
					else
					{
						IntPtr intPtr = Marshal.ReadIntPtr(ptr, propMarshallingInfo.Offset);
						if (type2 == typeof(string))
						{
							int num = Marshal.ReadInt32(ptr, propMarshallingInfo.Offset + IntPtr.Size);
							value = ((num == 0) ? string.Empty : Marshal.PtrToStringUni(intPtr, num));
						}
						else if (type2 == typeof(string[]))
						{
							IntPtr intPtr2 = Marshal.ReadIntPtr(ptr, propMarshallingInfo.Offset + IntPtr.Size);
							if (intPtr2 == IntPtr.Zero)
							{
								value = null;
							}
							else
							{
								int num2 = Marshal.ReadInt32(intPtr2);
								string[] array = new string[num2];
								value = array;
								for (int j = 0; j < num2; j++)
								{
									int num3 = Marshal.ReadInt32(intPtr2, (j + 1) * 4);
									IntPtr ptr2 = Marshal.ReadIntPtr(intPtr, j * IntPtr.Size);
									array[j] = ((num3 == 0) ? string.Empty : Marshal.PtrToStringUni(ptr2, num3));
								}
							}
						}
						else if (type2 == typeof(GenericTaskCallback))
						{
							value = Marshal.GetDelegateForFunctionPointer<GenericTaskCallback>(intPtr);
						}
						else if (type2.IsArray)
						{
							Type elementType = type2.GetElementType();
							TypeMarshallingInfo forNestedType = GetForNestedType(elementType);
							int num4 = Marshal.ReadInt32(ptr, propMarshallingInfo.Offset + IntPtr.Size);
							Array array2 = Array.CreateInstance(elementType, num4);
							for (int k = 0; k < num4; k++)
							{
								array2.SetValue(forNestedType.Deserialize(intPtr + k * forNestedType.Size, elementType), k);
							}
							value = array2;
						}
						else
						{
							if (!typeof(IMarshallable).IsAssignableFrom(type2))
							{
								throw new InvalidProgramException();
							}
							value = GetForNestedType(type2).Deserialize(ptr + propMarshallingInfo.Offset, type2);
						}
					}
					propMarshallingInfo.PropInfo.SetValue(obj, value);
				}
				return obj;
			}

			public void Free(IntPtr ptr, bool isOwned = true)
			{
				PropMarshallingInfo[] properties = Properties;
				foreach (PropMarshallingInfo propMarshallingInfo in properties)
				{
					if (propMarshallingInfo.IsPlain || propMarshallingInfo.Type == typeof(bool))
					{
						continue;
					}
					IntPtr intPtr = Marshal.ReadIntPtr(ptr, propMarshallingInfo.Offset);
					if (propMarshallingInfo.Type == typeof(string[]))
					{
						IntPtr intPtr2 = Marshal.ReadIntPtr(ptr, propMarshallingInfo.Offset + IntPtr.Size);
						int num = ((!(intPtr2 == IntPtr.Zero)) ? Marshal.ReadInt32(intPtr2) : 0);
						for (int j = 0; j < num; j++)
						{
							Marshal.FreeHGlobal(Marshal.ReadIntPtr(intPtr, j * IntPtr.Size));
						}
						Marshal.FreeHGlobal(intPtr2);
					}
					else if (propMarshallingInfo.Type.IsArray)
					{
						Type elementType = propMarshallingInfo.Type.GetElementType();
						TypeMarshallingInfo typeMarshallingInfo = (TypeMarshallingInfo)typeof(StructHolder<>).MakeGenericType(elementType).GetField("MarshalInfo").GetValue(null);
						int num2 = Marshal.ReadInt32(ptr, propMarshallingInfo.Offset + IntPtr.Size);
						for (int k = 0; k < num2; k++)
						{
							typeMarshallingInfo.Free(intPtr + k * typeMarshallingInfo.Size, isOwned: false);
						}
					}
					Marshal.FreeHGlobal(intPtr);
				}
				if (isOwned)
				{
					Marshal.FreeHGlobal(ptr);
				}
			}
		}

		public class PropMarshallingInfo
		{
			public Type Type { get; set; }

			public FieldInfo PropInfo { get; set; }

			public int Offset { get; set; }

			public bool IsPlain { get; set; }

			public bool IsEnum { get; set; }

			public override string ToString()
			{
				return $"{PropInfo} @ {Offset:x}";
			}
		}

		public class StructHolder<T> : BaseDisposable where T : IMarshallable
		{
			public static readonly TypeMarshallingInfo MarshalInfo = new TypeMarshallingInfo(typeof(T));

			public IntPtr Data { get; private set; }

			public StructHolder(T value)
			{
				if (value != null)
				{
					Data = MarshalInfo.Serialize(value);
				}
			}

			protected override void DisposeUnmanaged()
			{
				if (!(Data == IntPtr.Zero))
				{
					MarshalInfo.Free(Data);
					Data = IntPtr.Zero;
				}
			}
		}

		private static readonly MarshallableTaskCallback DoCompleteMarshallableTaskDelegate = DoCompleteMarshallableTask;

		public static IMarshallable Unmarshal(IntPtr payload)
		{
			return Marshal.ReadInt32(payload) switch
			{
				824783168 => StructHolder<AuthState>.MarshalInfo.Deserialize<AuthState>(payload), 
				1840358796 => StructHolder<ChannelRaidEvent>.MarshalInfo.Deserialize<ChannelRaidEvent>(payload), 
				-1152625179 => StructHolder<CustomRewardResolveRequest>.MarshalInfo.Deserialize<CustomRewardResolveRequest>(payload), 
				1747825069 => StructHolder<HypeTrainContribution>.MarshalInfo.Deserialize<HypeTrainContribution>(payload), 
				1200007443 => StructHolder<HypeTrainEvent>.MarshalInfo.Deserialize<HypeTrainEvent>(payload), 
				1158389922 => StructHolder<CustomRewardDefinition>.MarshalInfo.Deserialize<CustomRewardDefinition>(payload), 
				-67112796 => StructHolder<CustomRewardList>.MarshalInfo.Deserialize<CustomRewardList>(payload), 
				-432329023 => StructHolder<BitsLeaderboardEntry>.MarshalInfo.Deserialize<BitsLeaderboardEntry>(payload), 
				-1209729142 => StructHolder<BitsLeaderboard>.MarshalInfo.Deserialize<BitsLeaderboard>(payload), 
				794647764 => StructHolder<BitsLeaderboardRequest>.MarshalInfo.Deserialize<BitsLeaderboardRequest>(payload), 
				-895127529 => StructHolder<ChannelFollowEvent>.MarshalInfo.Deserialize<ChannelFollowEvent>(payload), 
				-1586617571 => StructHolder<ChannelCheerEvent>.MarshalInfo.Deserialize<ChannelCheerEvent>(payload), 
				-800396378 => StructHolder<CustomRewardEvent>.MarshalInfo.Deserialize<CustomRewardEvent>(payload), 
				973764268 => StructHolder<EventStreamRequest>.MarshalInfo.Deserialize<EventStreamRequest>(payload), 
				853853815 => StructHolder<EventStreamDesc>.MarshalInfo.Deserialize<EventStreamDesc>(payload), 
				-1414041357 => StructHolder<ModifyChannelInfoRequest>.MarshalInfo.Deserialize<ModifyChannelInfoRequest>(payload), 
				-354228052 => StructHolder<PredictionDefinition>.MarshalInfo.Deserialize<PredictionDefinition>(payload), 
				2038549629 => StructHolder<PredictionOutcome>.MarshalInfo.Deserialize<PredictionOutcome>(payload), 
				-1418330344 => StructHolder<PredictionInfo>.MarshalInfo.Deserialize<PredictionInfo>(payload), 
				-359250458 => StructHolder<EndPredictionRequest>.MarshalInfo.Deserialize<EndPredictionRequest>(payload), 
				25655671 => StructHolder<StreamMarkerInfo>.MarshalInfo.Deserialize<StreamMarkerInfo>(payload), 
				374164541 => StructHolder<ClipInfo>.MarshalInfo.Deserialize<ClipInfo>(payload), 
				-1225210291 => StructHolder<EndPollRequest>.MarshalInfo.Deserialize<EndPollRequest>(payload), 
				1335005312 => StructHolder<PollChoiceInfo>.MarshalInfo.Deserialize<PollChoiceInfo>(payload), 
				41019527 => StructHolder<PollInfo>.MarshalInfo.Deserialize<PollInfo>(payload), 
				-1548732846 => StructHolder<StreamQuery>.MarshalInfo.Deserialize<StreamQuery>(payload), 
				706061000 => StructHolder<WebRequestResult>.MarshalInfo.Deserialize<WebRequestResult>(payload), 
				-1503227594 => StructHolder<None>.MarshalInfo.Deserialize<None>(payload), 
				-1549817923 => StructHolder<PlainInt>.MarshalInfo.Deserialize<PlainInt>(payload), 
				988587891 => StructHolder<PlainString>.MarshalInfo.Deserialize<PlainString>(payload), 
				288933883 => StructHolder<PlainBool>.MarshalInfo.Deserialize<PlainBool>(payload), 
				-256913275 => StructHolder<AuthenticationInfo>.MarshalInfo.Deserialize<AuthenticationInfo>(payload), 
				-1875581513 => StructHolder<MarshalException>.MarshalInfo.Deserialize<MarshalException>(payload), 
				-1969979977 => StructHolder<UserInfo>.MarshalInfo.Deserialize<UserInfo>(payload), 
				-903042935 => StructHolder<StreamInfo>.MarshalInfo.Deserialize<StreamInfo>(payload), 
				1775991607 => StructHolder<StreamQueryResult>.MarshalInfo.Deserialize<StreamQueryResult>(payload), 
				1666538230 => StructHolder<ChannelSubscribeEvent>.MarshalInfo.Deserialize<ChannelSubscribeEvent>(payload), 
				-1536148643 => StructHolder<UserSubscriptionCheckResult>.MarshalInfo.Deserialize<UserSubscriptionCheckResult>(payload), 
				-1429450289 => StructHolder<PollDefinition>.MarshalInfo.Deserialize<PollDefinition>(payload), 
				-1855527540 => StructHolder<WebRequestRequest>.MarshalInfo.Deserialize<WebRequestRequest>(payload), 
				-504035953 => StructHolder<SleepRequest>.MarshalInfo.Deserialize<SleepRequest>(payload), 
				-1182308723 => StructHolder<ReadFileRequest>.MarshalInfo.Deserialize<ReadFileRequest>(payload), 
				-1420421173 => StructHolder<WriteFileRequest>.MarshalInfo.Deserialize<WriteFileRequest>(payload), 
				1210189489 => StructHolder<LogRequest>.MarshalInfo.Deserialize<LogRequest>(payload), 
				-1487905959 => StructHolder<CreateWebSocketRequest>.MarshalInfo.Deserialize<CreateWebSocketRequest>(payload), 
				-223523082 => StructHolder<SendWebSocketMessageRequest>.MarshalInfo.Deserialize<SendWebSocketMessageRequest>(payload), 
				1869071618 => StructHolder<RecvWebSocketMessageRequest>.MarshalInfo.Deserialize<RecvWebSocketMessageRequest>(payload), 
				-2145718554 => StructHolder<CloseWebSocketRequest>.MarshalInfo.Deserialize<CloseWebSocketRequest>(payload), 
				_ => throw new Exception("Unknown type code while unmarshalling. Probably a version mismatch between core library and .NET wrapper."), 
			};
		}

		public static Task<R> InvokeMarshallable<R>(Action<IntPtr, IntPtr, MarshallableTaskCallback, IntPtr> func, IntPtr self) where R : IMarshallable
		{
			return InvokeMarshallable<None, R>(func, self, new None());
		}

		public static async Task<R> InvokeMarshallable<P, R>(Action<IntPtr, IntPtr, MarshallableTaskCallback, IntPtr> func, IntPtr self, P p) where P : IMarshallable where R : IMarshallable
		{
			if (self == IntPtr.Zero)
			{
				throw new ObjectDisposedException(typeof(CoreLibrary).FullName);
			}
			TaskCompletionSource<IMarshallable> taskCompletionSource = new TaskCompletionSource<IMarshallable>(TaskCreationOptions.RunContinuationsAsynchronously);
			GCHandle value = GCHandle.Alloc(taskCompletionSource);
			using (StructHolder<P> structHolder = new StructHolder<P>(p))
			{
				func(self, structHolder.Data, DoCompleteMarshallableTaskDelegate, GCHandle.ToIntPtr(value));
			}
			return (R)(await taskCompletionSource.Task.ConfigureAwait(continueOnCapturedContext: false));
		}

		[MonoPInvokeCallback(typeof(GenericTaskCallback))]
		private static void DoCompleteMarshallableTask(IntPtr ret, IntPtr completion)
		{
			GCHandle gCHandle = GCHandle.FromIntPtr(completion);
			try
			{
				TaskCompletionSource<IMarshallable> taskCompletionSource = (TaskCompletionSource<IMarshallable>)gCHandle.Target;
				try
				{
					IMarshallable marshallable = Unmarshal(ret);
					if (marshallable is MarshalException ex)
					{
						taskCompletionSource.SetException(new CoreLibraryException(ex.What));
					}
					else
					{
						taskCompletionSource.SetResult(marshallable);
					}
				}
				catch (Exception exception)
				{
					taskCompletionSource.TrySetException(exception);
				}
			}
			finally
			{
				gCHandle.Free();
			}
		}

		public static void ReturnTask<T>(this T msa, Func<T, Task> run) where T : IMarshallableStartAsync
		{
			msa.ReturnTask(async delegate(T t)
			{
				await run(t).ConfigureAwait(continueOnCapturedContext: false);
				return new None();
			});
		}

		public static void ReturnTask<T>(this T msa, Func<T, Task<string>> run) where T : IMarshallableStartAsync
		{
			msa.ReturnTask(async delegate(T t)
			{
				PlainString plainString = new PlainString();
				PlainString plainString2 = plainString;
				plainString2.Data = await run(t).ConfigureAwait(continueOnCapturedContext: false);
				return plainString;
			});
		}

		public static void ReturnTask<T>(this T msa, Func<T, Task<int>> run) where T : IMarshallableStartAsync
		{
			msa.ReturnTask(async delegate(T t)
			{
				PlainInt plainInt = new PlainInt();
				PlainInt plainInt2 = plainInt;
				plainInt2.Data = await run(t).ConfigureAwait(continueOnCapturedContext: false);
				return plainInt;
			});
		}

		public static async void ReturnTask<T, R>(this T msa, Func<T, Task<R>> run) where T : IMarshallableStartAsync where R : IMarshallable
		{
			try
			{
				using StructHolder<R> structHolder = new StructHolder<R>(await run(msa).ConfigureAwait(continueOnCapturedContext: false));
				msa.TaskCallback(msa.TaskCallbackPayload, structHolder.Data);
			}
			catch (Exception ex)
			{
				using StructHolder<MarshalException> structHolder2 = new StructHolder<MarshalException>(new MarshalException
				{
					What = ex.ToString()
				});
				msa.TaskCallback(msa.TaskCallbackPayload, structHolder2.Data);
			}
		}
	}
}

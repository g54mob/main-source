using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using MLAPI.Configuration;
using MLAPI.Hashing;
using MLAPI.Logging;
using MLAPI.Messaging;
using MLAPI.NetworkedVar;
using MLAPI.Reflection;
using MLAPI.Security;
using MLAPI.Serialization;
using MLAPI.Serialization.Pooled;
using MLAPI.Spawning;
using UnityEngine;

namespace MLAPI
{
	public abstract class NetworkedBehaviour : MonoBehaviour
	{
		public delegate void RpcMethod();

		public delegate void RpcMethod<T1>(T1 t1);

		public delegate void RpcMethod<T1, T2>(T1 t1, T2 t2);

		public delegate void RpcMethod<T1, T2, T3>(T1 t1, T2 t2, T3 t3);

		public delegate void RpcMethod<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4);

		public delegate void RpcMethod<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31);

		public delegate void RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32);

		public delegate TResult ResponseRpcMethod<TResult>();

		public delegate TResult ResponseRpcMethod<TResult, T1>(T1 t1);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2>(T1 t1, T2 t2);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3>(T1 t1, T2 t2, T3 t3);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31);

		public delegate TResult ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32);

		internal ulong executingRpcSender;

		private NetworkedObject _networkedObject;

		internal bool networkedStartInvoked;

		internal bool internalNetworkedStartInvoked;

		private bool varInit;

		private readonly List<HashSet<int>> channelMappedNetworkedVarIndexes = new List<HashSet<int>>();

		private readonly List<string> channelsForNetworkedVarGroups = new List<string>();

		internal readonly List<INetworkedVar> networkedVarFields = new List<INetworkedVar>();

		private static readonly Dictionary<Type, FieldInfo[]> fieldTypes = new Dictionary<Type, FieldInfo[]>();

		private readonly List<HashSet<int>> channelMappedSyncedVarIndexes = new List<HashSet<int>>();

		private readonly List<string> channelsForSyncedVarGroups = new List<string>();

		internal readonly List<SyncedVarContainer> syncedVars = new List<SyncedVarContainer>();

		private readonly List<int> syncedVarIndexesToReset = new List<int>();

		private readonly HashSet<int> syncedVarIndexesToResetSet = new HashSet<int>();

		private readonly List<int> networkedVarIndexesToReset = new List<int>();

		private readonly HashSet<int> networkedVarIndexesToResetSet = new HashSet<int>();

		private static readonly StringBuilder methodInfoStringBuilder = new StringBuilder();

		private static readonly Dictionary<MethodInfo, ulong> methodInfoHashTable = new Dictionary<MethodInfo, ulong>();

		private RpcTypeDefinition rpcDefinition;

		internal RpcDelegate[] rpcDelegates;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsLocalPlayer instead", false)]
		public bool isLocalPlayer => IsLocalPlayer;

		public bool IsLocalPlayer => NetworkedObject.IsLocalPlayer;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsOwner instead", false)]
		public bool isOwner => IsOwner;

		public bool IsOwner => NetworkedObject.IsOwner;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsServer instead", false)]
		protected bool isServer => IsServer;

		protected bool IsServer
		{
			get
			{
				if (IsRunning)
				{
					return NetworkingManager.Singleton.IsServer;
				}
				return false;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsClient instead")]
		protected bool isClient => IsClient;

		protected bool IsClient
		{
			get
			{
				if (IsRunning)
				{
					return NetworkingManager.Singleton.IsClient;
				}
				return false;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsHost instead", false)]
		protected bool isHost => IsHost;

		protected bool IsHost
		{
			get
			{
				if (IsRunning)
				{
					return NetworkingManager.Singleton.IsHost;
				}
				return false;
			}
		}

		private bool IsRunning
		{
			get
			{
				if (NetworkingManager.Singleton != null)
				{
					return NetworkingManager.Singleton.IsListening;
				}
				return false;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsOwnedByServer instead", false)]
		public bool isOwnedByServer => IsOwnedByServer;

		public bool IsOwnedByServer => NetworkedObject.IsOwnedByServer;

		protected ulong ExecutingRpcSender => executingRpcSender;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use NetworkedObject instead", false)]
		public NetworkedObject networkedObject => NetworkedObject;

		public NetworkedObject NetworkedObject
		{
			get
			{
				if (_networkedObject == null)
				{
					_networkedObject = GetComponentInParent<NetworkedObject>();
				}
				if (_networkedObject == null)
				{
					throw new NullReferenceException("Could not get NetworkedObject for the NetworkedBehaviour. Are you missing a NetworkedObject component?");
				}
				return _networkedObject;
			}
		}

		public bool HasNetworkedObject
		{
			get
			{
				if (_networkedObject == null)
				{
					_networkedObject = GetComponentInParent<NetworkedObject>();
				}
				return _networkedObject != null;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use NetworkId instead", false)]
		public ulong networkId => NetworkId;

		public ulong NetworkId => NetworkedObject.NetworkId;

		public ulong OwnerClientId => NetworkedObject.OwnerClientId;

		public virtual void NetworkStart()
		{
		}

		public virtual void NetworkStart(Stream stream)
		{
			NetworkStart();
		}

		internal void InternalNetworkStart()
		{
			rpcDefinition = RpcTypeDefinition.Get(GetType());
			rpcDelegates = rpcDefinition.CreateTargetedDelegates(this);
			InitializeVars();
		}

		public virtual void OnSyncVarUpdate()
		{
		}

		public virtual void OnGainedOwnership()
		{
		}

		public virtual void OnLostOwnership()
		{
		}

		public ushort GetBehaviourId()
		{
			return NetworkedObject.GetOrderIndex(this);
		}

		protected NetworkedBehaviour GetBehaviour(ushort id)
		{
			return NetworkedObject.GetBehaviourAtOrderIndex(id);
		}

		private static FieldInfo[] GetFieldInfoForType(Type type)
		{
			if (!fieldTypes.ContainsKey(type))
			{
				fieldTypes.Add(type, GetFieldInfoForTypeRecursive(type));
			}
			return fieldTypes[type];
		}

		private static FieldInfo[] GetFieldInfoForTypeRecursive(Type type, List<FieldInfo> list = null)
		{
			if (list == null)
			{
				list = new List<FieldInfo>();
				list.AddRange(type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			}
			else
			{
				list.AddRange(type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic));
			}
			if ((object)type.BaseType != null && (object)type.BaseType != typeof(NetworkedBehaviour))
			{
				return GetFieldInfoForTypeRecursive(type.BaseType, list);
			}
			return list.OrderBy((FieldInfo x) => x.Name, StringComparer.Ordinal).ToArray();
		}

		internal void InitializeVars()
		{
			if (varInit)
			{
				return;
			}
			varInit = true;
			FieldInfo[] fieldInfoForType = GetFieldInfoForType(GetType());
			for (int i = 0; i < fieldInfoForType.Length; i++)
			{
				Type fieldType = fieldInfoForType[i].FieldType;
				SyncedVarAttribute[] array = (SyncedVarAttribute[])fieldInfoForType[i].GetCustomAttributes(typeof(SyncedVarAttribute), inherit: true);
				if (array.Length == 1)
				{
					if (SerializationManager.IsTypeSupported(fieldType))
					{
						syncedVars.Add(new SyncedVarContainer
						{
							field = fieldInfoForType[i],
							fieldInstance = this,
							isDirty = false,
							value = fieldInfoForType[i].GetValue(this),
							attribute = array[0]
						});
					}
					else if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
					{
						NetworkLog.LogError("SyncedVar has unsupported type");
					}
				}
				if (fieldType.HasInterface(typeof(INetworkedVar)))
				{
					INetworkedVar networkedVar = (INetworkedVar)fieldInfoForType[i].GetValue(this);
					if (networkedVar == null)
					{
						networkedVar = (INetworkedVar)Activator.CreateInstance(fieldType, nonPublic: true);
						fieldInfoForType[i].SetValue(this, networkedVar);
					}
					networkedVar.SetNetworkedBehaviour(this);
					networkedVarFields.Add(networkedVar);
				}
			}
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			int num = 0;
			for (int j = 0; j < syncedVars.Count; j++)
			{
				string channel = syncedVars[j].attribute.Channel;
				if (!dictionary.ContainsKey(channel))
				{
					dictionary.Add(channel, num);
					channelsForSyncedVarGroups.Add(channel);
					num++;
				}
				if (dictionary[channel] >= channelMappedSyncedVarIndexes.Count)
				{
					channelMappedSyncedVarIndexes.Add(new HashSet<int>());
				}
				channelMappedSyncedVarIndexes[dictionary[channel]].Add(j);
			}
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
			int num2 = 0;
			for (int k = 0; k < networkedVarFields.Count; k++)
			{
				string channel2 = networkedVarFields[k].GetChannel();
				if (!dictionary2.ContainsKey(channel2))
				{
					dictionary2.Add(channel2, num2);
					channelsForNetworkedVarGroups.Add(channel2);
					num2++;
				}
				if (dictionary2[channel2] >= channelMappedNetworkedVarIndexes.Count)
				{
					channelMappedNetworkedVarIndexes.Add(new HashSet<int>());
				}
				channelMappedNetworkedVarIndexes[dictionary2[channel2]].Add(k);
			}
		}

		internal void VarUpdate()
		{
			if (!varInit)
			{
				InitializeVars();
			}
			SyncedVarUpdate();
			NetworkedVarUpdate();
		}

		private void SyncedVarUpdate()
		{
			if (!IsServer || !CouldHaveDirtySyncedVars())
			{
				return;
			}
			syncedVarIndexesToReset.Clear();
			syncedVarIndexesToResetSet.Clear();
			for (int i = 0; i < NetworkingManager.Singleton.ConnectedClientsList.Count; i++)
			{
				if (!NetworkedObject.observers.Contains(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId))
				{
					continue;
				}
				for (int j = 0; j < channelMappedSyncedVarIndexes.Count; j++)
				{
					using PooledBitStream pooledBitStream = PooledBitStream.Get();
					using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
					pooledBitWriter.WriteUInt64Packed(NetworkId);
					pooledBitWriter.WriteUInt16Packed(NetworkedObject.GetOrderIndex(this));
					ulong clientId = NetworkingManager.Singleton.ConnectedClientsList[i].ClientId;
					bool flag = false;
					for (int k = 0; k < syncedVars.Count; k++)
					{
						if (!channelMappedSyncedVarIndexes[j].Contains(k))
						{
							if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
							{
								pooledBitWriter.WriteUInt16Packed(0);
							}
							else
							{
								pooledBitWriter.WriteBool(value: false);
							}
							continue;
						}
						bool flag2 = syncedVars[k].IsDirty();
						if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
						{
							if (!flag2)
							{
								pooledBitWriter.WriteUInt16Packed(0);
							}
						}
						else
						{
							pooledBitWriter.WriteBool(flag2);
						}
						if (!flag2)
						{
							continue;
						}
						flag = true;
						if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
						{
							using PooledBitStream pooledBitStream2 = PooledBitStream.Get();
							syncedVars[k].WriteValue(pooledBitStream2, checkDirty: false);
							pooledBitStream2.PadStream();
							pooledBitWriter.WriteUInt16Packed((ushort)pooledBitStream2.Length);
							pooledBitStream.CopyFrom(pooledBitStream2);
						}
						else
						{
							syncedVars[k].WriteValue(pooledBitStream, checkDirty: false);
						}
						if (!syncedVarIndexesToResetSet.Contains(k))
						{
							syncedVarIndexesToResetSet.Add(k);
							syncedVarIndexesToReset.Add(k);
						}
					}
					if (flag)
					{
						InternalMessageSender.Send(clientId, 23, channelsForSyncedVarGroups[j], pooledBitStream, SecuritySendFlags.None, NetworkedObject);
					}
				}
			}
			for (int l = 0; l < syncedVarIndexesToReset.Count; l++)
			{
				syncedVars[syncedVarIndexesToReset[l]].ResetDirty();
			}
		}

		private void NetworkedVarUpdate()
		{
			if (!CouldHaveDirtyNetworkedVars())
			{
				return;
			}
			networkedVarIndexesToReset.Clear();
			networkedVarIndexesToResetSet.Clear();
			for (int i = 0; i < ((!IsServer) ? 1 : NetworkingManager.Singleton.ConnectedClientsList.Count); i++)
			{
				if (IsServer && !NetworkedObject.observers.Contains(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId))
				{
					continue;
				}
				for (int j = 0; j < channelMappedNetworkedVarIndexes.Count; j++)
				{
					using PooledBitStream pooledBitStream = PooledBitStream.Get();
					using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
					pooledBitWriter.WriteUInt64Packed(NetworkId);
					pooledBitWriter.WriteUInt16Packed(NetworkedObject.GetOrderIndex(this));
					ulong clientId = (IsServer ? NetworkingManager.Singleton.ConnectedClientsList[i].ClientId : NetworkingManager.Singleton.ServerClientId);
					bool flag = false;
					for (int k = 0; k < networkedVarFields.Count; k++)
					{
						if (!channelMappedNetworkedVarIndexes[j].Contains(k))
						{
							if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
							{
								pooledBitWriter.WriteUInt16Packed(0);
							}
							else
							{
								pooledBitWriter.WriteBool(value: false);
							}
							continue;
						}
						bool flag2 = networkedVarFields[k].IsDirty() && (!IsServer || networkedVarFields[k].CanClientRead(clientId));
						if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
						{
							if (!flag2)
							{
								pooledBitWriter.WriteUInt16Packed(0);
							}
						}
						else
						{
							pooledBitWriter.WriteBool(flag2);
						}
						if (!flag2)
						{
							continue;
						}
						flag = true;
						if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
						{
							using PooledBitStream pooledBitStream2 = PooledBitStream.Get();
							networkedVarFields[k].WriteDelta(pooledBitStream2);
							pooledBitStream2.PadStream();
							pooledBitWriter.WriteUInt16Packed((ushort)pooledBitStream2.Length);
							pooledBitStream.CopyFrom(pooledBitStream2);
						}
						else
						{
							networkedVarFields[k].WriteDelta(pooledBitStream);
						}
						if (!networkedVarIndexesToResetSet.Contains(k))
						{
							networkedVarIndexesToResetSet.Add(k);
							networkedVarIndexesToReset.Add(k);
						}
					}
					if (flag)
					{
						if (IsServer)
						{
							InternalMessageSender.Send(clientId, 12, channelsForNetworkedVarGroups[j], pooledBitStream, SecuritySendFlags.None, NetworkedObject);
						}
						else
						{
							InternalMessageSender.Send(NetworkingManager.Singleton.ServerClientId, 12, channelsForNetworkedVarGroups[j], pooledBitStream, SecuritySendFlags.None, null);
						}
					}
				}
			}
			for (int l = 0; l < networkedVarIndexesToReset.Count; l++)
			{
				networkedVarFields[networkedVarIndexesToReset[l]].ResetDirty();
			}
		}

		private bool CouldHaveDirtyNetworkedVars()
		{
			for (int i = 0; i < networkedVarFields.Count; i++)
			{
				if (networkedVarFields[i].IsDirty())
				{
					return true;
				}
			}
			return false;
		}

		private bool CouldHaveDirtySyncedVars()
		{
			for (int i = 0; i < syncedVars.Count; i++)
			{
				if (syncedVars[i].IsDirty())
				{
					return true;
				}
			}
			return false;
		}

		internal static void HandleSyncedVarValue(List<SyncedVarContainer> syncedVarList, Stream stream, ulong clientId, NetworkedBehaviour logInstance)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			for (int i = 0; i < syncedVarList.Count; i++)
			{
				ushort num = 0;
				if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					num = pooledBitReader.ReadUInt16Packed();
					if (num == 0)
					{
						continue;
					}
				}
				else if (!pooledBitReader.ReadBool())
				{
					continue;
				}
				long position = stream.Position;
				syncedVarList[i].ReadValue(stream);
				if (!NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					continue;
				}
				(stream as BitStream).SkipPadBits();
				if (stream.Position > position + num)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("SyncedVar read too far. " + (stream.Position - (position + num)) + " bytes." + ((logInstance != null) ? ("NetworkId: " + logInstance.NetworkId + " BehaviourIndex: " + logInstance.NetworkedObject.GetOrderIndex(logInstance) + " VariableIndex: " + i) : string.Empty));
					}
					stream.Position = position + num;
				}
				else if (stream.Position < position + num)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("SyncedVar read too little. " + (position + num - stream.Position) + " bytes." + ((logInstance != null) ? ("NetworkId: " + logInstance.NetworkId + " BehaviourIndex: " + logInstance.NetworkedObject.GetOrderIndex(logInstance) + " VariableIndex: " + i) : string.Empty));
					}
					stream.Position = position + num;
				}
			}
		}

		internal static void HandleNetworkedVarDeltas(List<INetworkedVar> networkedVarList, Stream stream, ulong clientId, NetworkedBehaviour logInstance)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			for (int i = 0; i < networkedVarList.Count; i++)
			{
				ushort num = 0;
				if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					num = pooledBitReader.ReadUInt16Packed();
					if (num == 0)
					{
						continue;
					}
				}
				else if (!pooledBitReader.ReadBool())
				{
					continue;
				}
				if (NetworkingManager.Singleton.IsServer && !networkedVarList[i].CanClientWrite(clientId))
				{
					if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
					{
						if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
						{
							NetworkLog.LogWarning("Client wrote to NetworkedVar without permission. " + ((logInstance != null) ? ("NetworkId: " + logInstance.NetworkId + " BehaviourIndex: " + logInstance.NetworkedObject.GetOrderIndex(logInstance) + " VariableIndex: " + i) : string.Empty));
						}
						stream.Position += num;
						continue;
					}
					if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
					{
						NetworkLog.LogError("Client wrote to NetworkedVar without permission. No more variables can be read. This is critical. " + ((logInstance != null) ? ("NetworkId: " + logInstance.NetworkId + " BehaviourIndex: " + logInstance.NetworkedObject.GetOrderIndex(logInstance) + " VariableIndex: " + i) : string.Empty));
					}
					break;
				}
				long position = stream.Position;
				networkedVarList[i].ReadDelta(stream, NetworkingManager.Singleton.IsServer);
				if (!NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					continue;
				}
				(stream as BitStream).SkipPadBits();
				if (stream.Position > position + num)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("Var delta read too far. " + (stream.Position - (position + num)) + " bytes." + ((logInstance != null) ? ("NetworkId: " + logInstance.NetworkId + " BehaviourIndex: " + logInstance.NetworkedObject.GetOrderIndex(logInstance) + " VariableIndex: " + i) : string.Empty));
					}
					stream.Position = position + num;
				}
				else if (stream.Position < position + num)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("Var delta read too little. " + (position + num - stream.Position) + " bytes." + ((logInstance != null) ? ("NetworkId: " + logInstance.NetworkId + " BehaviourIndex: " + logInstance.NetworkedObject.GetOrderIndex(logInstance) + " VariableIndex: " + i) : string.Empty));
					}
					stream.Position = position + num;
				}
			}
		}

		internal static void HandleNetworkedVarUpdate(List<INetworkedVar> networkedVarList, Stream stream, ulong clientId, NetworkedBehaviour logInstance)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			for (int i = 0; i < networkedVarList.Count; i++)
			{
				ushort num = 0;
				if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					num = pooledBitReader.ReadUInt16Packed();
					if (num == 0)
					{
						continue;
					}
				}
				else if (!pooledBitReader.ReadBool())
				{
					continue;
				}
				if (NetworkingManager.Singleton.IsServer && !networkedVarList[i].CanClientWrite(clientId))
				{
					if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
					{
						if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
						{
							NetworkLog.LogWarning("Client wrote to NetworkedVar without permission. " + ((logInstance != null) ? ("NetworkId: " + logInstance.NetworkId + " BehaviourIndex: " + logInstance.NetworkedObject.GetOrderIndex(logInstance) + " VariableIndex: " + i) : string.Empty));
						}
						stream.Position += num;
						continue;
					}
					if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
					{
						NetworkLog.LogError("Client wrote to NetworkedVar without permission. No more variables can be read. This is critical. " + ((logInstance != null) ? ("NetworkId: " + logInstance.NetworkId + " BehaviourIndex: " + logInstance.NetworkedObject.GetOrderIndex(logInstance) + " VariableIndex: " + i) : string.Empty));
					}
					break;
				}
				long position = stream.Position;
				networkedVarList[i].ReadField(stream);
				if (!NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					continue;
				}
				if (stream is BitStream bitStream)
				{
					bitStream.SkipPadBits();
				}
				if (stream.Position > position + num)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("Var update read too far. " + (stream.Position - (position + num)) + " bytes." + ((logInstance != null) ? ("NetworkId: " + logInstance.NetworkId + " BehaviourIndex: " + logInstance.NetworkedObject.GetOrderIndex(logInstance) + " VariableIndex: " + i) : string.Empty));
					}
					stream.Position = position + num;
				}
				else if (stream.Position < position + num)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("Var update read too little. " + (position + num - stream.Position) + " bytes." + ((logInstance != null) ? ("NetworkId: " + logInstance.NetworkId + " BehaviourIndex: " + logInstance.NetworkedObject.GetOrderIndex(logInstance) + " VariableIndex: " + i) : string.Empty));
					}
					stream.Position = position + num;
				}
			}
		}

		internal static void WriteSyncedVarData(List<SyncedVarContainer> syncedVarList, Stream stream, ulong clientId)
		{
			if (syncedVarList.Count == 0)
			{
				return;
			}
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			for (int i = 0; i < syncedVarList.Count; i++)
			{
				if (!NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					pooledBitWriter.WriteBool(value: true);
				}
				if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					using PooledBitStream pooledBitStream = PooledBitStream.Get();
					syncedVarList[i].WriteValue(pooledBitStream);
					pooledBitStream.PadStream();
					pooledBitWriter.WriteUInt16Packed((ushort)pooledBitStream.Length);
					pooledBitStream.CopyTo(stream);
				}
				else
				{
					syncedVarList[i].WriteValue(stream);
				}
			}
		}

		internal static void SetSyncedVarData(List<SyncedVarContainer> syncedVarList, Stream stream)
		{
			if (syncedVarList.Count == 0)
			{
				return;
			}
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			for (int i = 0; i < syncedVarList.Count; i++)
			{
				ushort num = 0;
				if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					num = pooledBitReader.ReadUInt16Packed();
					if (num == 0)
					{
						continue;
					}
				}
				else if (!pooledBitReader.ReadBool())
				{
					continue;
				}
				long position = stream.Position;
				syncedVarList[i].ReadValue(stream);
				if (!NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					continue;
				}
				if (stream is BitStream bitStream)
				{
					bitStream.SkipPadBits();
				}
				if (stream.Position > position + num)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("SyncedVar data read too far. " + (stream.Position - (position + num)) + " bytes.");
					}
					stream.Position = position + num;
				}
				else if (stream.Position < position + num)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("SyncedVar data read too little. " + (position + num - stream.Position) + " bytes.");
					}
					stream.Position = position + num;
				}
			}
		}

		internal static void WriteNetworkedVarData(List<INetworkedVar> networkedVarList, Stream stream, ulong clientId)
		{
			if (networkedVarList.Count == 0)
			{
				return;
			}
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			for (int i = 0; i < networkedVarList.Count; i++)
			{
				bool flag = networkedVarList[i].CanClientRead(clientId);
				if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					if (!flag)
					{
						pooledBitWriter.WriteUInt16Packed(0);
					}
				}
				else
				{
					pooledBitWriter.WriteBool(flag);
				}
				if (!flag)
				{
					continue;
				}
				if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					using PooledBitStream pooledBitStream = PooledBitStream.Get();
					networkedVarList[i].WriteField(pooledBitStream);
					pooledBitStream.PadStream();
					pooledBitWriter.WriteUInt16Packed((ushort)pooledBitStream.Length);
					pooledBitStream.CopyTo(stream);
				}
				else
				{
					networkedVarList[i].WriteField(stream);
				}
			}
		}

		internal static void SetNetworkedVarData(List<INetworkedVar> networkedVarList, Stream stream)
		{
			if (networkedVarList.Count == 0)
			{
				return;
			}
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			for (int i = 0; i < networkedVarList.Count; i++)
			{
				ushort num = 0;
				if (NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					num = pooledBitReader.ReadUInt16Packed();
					if (num == 0)
					{
						continue;
					}
				}
				else if (!pooledBitReader.ReadBool())
				{
					continue;
				}
				long position = stream.Position;
				networkedVarList[i].ReadField(stream);
				if (!NetworkingManager.Singleton.NetworkConfig.EnsureNetworkedVarLengthSafety)
				{
					continue;
				}
				if (stream is BitStream bitStream)
				{
					bitStream.SkipPadBits();
				}
				if (stream.Position > position + num)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("Var data read too far. " + (stream.Position - (position + num)) + " bytes.");
					}
					stream.Position = position + num;
				}
				else if (stream.Position < position + num)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("Var data read too little. " + (position + num - stream.Position) + " bytes.");
					}
					stream.Position = position + num;
				}
			}
		}

		internal static ulong HashMethodName(string name)
		{
			return NetworkingManager.Singleton.NetworkConfig.RpcHashSize switch
			{
				HashSize.VarIntTwoBytes => name.GetStableHash16(), 
				HashSize.VarIntFourBytes => name.GetStableHash32(), 
				HashSize.VarIntEightBytes => name.GetStableHash64(), 
				_ => 0uL, 
			};
		}

		private ulong HashMethod(MethodInfo method)
		{
			if (methodInfoHashTable.ContainsKey(method))
			{
				return methodInfoHashTable[method];
			}
			ulong num = HashMethodName(GetHashableMethodSignature(method));
			methodInfoHashTable.Add(method, num);
			return num;
		}

		internal static string GetHashableMethodSignature(MethodInfo method)
		{
			methodInfoStringBuilder.Length = 0;
			methodInfoStringBuilder.Append(method.Name);
			ParameterInfo[] parameters = method.GetParameters();
			for (int i = 0; i < parameters.Length; i++)
			{
				methodInfoStringBuilder.Append(parameters[i].ParameterType.Name);
			}
			return methodInfoStringBuilder.ToString();
		}

		internal object OnRemoteServerRPC(ulong hash, ulong senderClientId, Stream stream)
		{
			if (!rpcDefinition.serverMethods.ContainsKey(hash))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("ServerRPC request method not found");
				}
				return null;
			}
			return InvokeServerRPCLocal(hash, senderClientId, stream);
		}

		internal object OnRemoteClientRPC(ulong hash, ulong senderClientId, Stream stream)
		{
			if (!rpcDefinition.clientMethods.ContainsKey(hash))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("ClientRPC request method not found");
				}
				return null;
			}
			return InvokeClientRPCLocal(hash, senderClientId, stream);
		}

		private object InvokeServerRPCLocal(ulong hash, ulong senderClientId, Stream stream)
		{
			if (rpcDefinition.serverMethods.ContainsKey(hash))
			{
				return rpcDefinition.serverMethods[hash].Invoke(this, senderClientId, stream);
			}
			return null;
		}

		private object InvokeClientRPCLocal(ulong hash, ulong senderClientId, Stream stream)
		{
			if (rpcDefinition.clientMethods.ContainsKey(hash))
			{
				return rpcDefinition.clientMethods[hash].Invoke(this, senderClientId, stream);
			}
			return null;
		}

		internal void SendServerRPCBoxed(ulong hash, string channel, SecuritySendFlags security, params object[] parameters)
		{
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			for (int i = 0; i < parameters.Length; i++)
			{
				pooledBitWriter.WriteObjectPacked(parameters[i]);
			}
			SendServerRPCPerformance(hash, pooledBitStream, channel, security);
		}

		internal RpcResponse<T> SendServerRPCBoxedResponse<T>(ulong hash, string channel, SecuritySendFlags security, params object[] parameters)
		{
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			for (int i = 0; i < parameters.Length; i++)
			{
				pooledBitWriter.WriteObjectPacked(parameters[i]);
			}
			return SendServerRPCPerformanceResponse<T>(hash, pooledBitStream, channel, security);
		}

		internal void SendClientRPCBoxedToClient(ulong hash, ulong clientId, string channel, SecuritySendFlags security, params object[] parameters)
		{
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			for (int i = 0; i < parameters.Length; i++)
			{
				pooledBitWriter.WriteObjectPacked(parameters[i]);
			}
			SendClientRPCPerformance(hash, clientId, pooledBitStream, channel, security);
		}

		internal RpcResponse<T> SendClientRPCBoxedResponse<T>(ulong hash, ulong clientId, string channel, SecuritySendFlags security, params object[] parameters)
		{
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			for (int i = 0; i < parameters.Length; i++)
			{
				pooledBitWriter.WriteObjectPacked(parameters[i]);
			}
			return SendClientRPCPerformanceResponse<T>(hash, clientId, pooledBitStream, channel, security);
		}

		internal void SendClientRPCBoxed(ulong hash, List<ulong> clientIds, string channel, SecuritySendFlags security, params object[] parameters)
		{
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			for (int i = 0; i < parameters.Length; i++)
			{
				pooledBitWriter.WriteObjectPacked(parameters[i]);
			}
			SendClientRPCPerformance(hash, clientIds, pooledBitStream, channel, security);
		}

		internal void SendClientRPCBoxedToEveryoneExcept(ulong clientIdToIgnore, ulong hash, string channel, SecuritySendFlags security, params object[] parameters)
		{
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			for (int i = 0; i < parameters.Length; i++)
			{
				pooledBitWriter.WriteObjectPacked(parameters[i]);
			}
			SendClientRPCPerformance(hash, pooledBitStream, clientIdToIgnore, channel, security);
		}

		internal void SendServerRPCPerformance(ulong hash, Stream messageStream, string channel, SecuritySendFlags security)
		{
			if (!IsClient && IsRunning)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Only client and host can invoke ServerRPC");
				}
				return;
			}
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			pooledBitWriter.WriteUInt64Packed(NetworkId);
			pooledBitWriter.WriteUInt16Packed(NetworkedObject.GetOrderIndex(this));
			pooledBitWriter.WriteUInt64Packed(hash);
			pooledBitStream.CopyFrom(messageStream);
			if (IsHost)
			{
				messageStream.Position = 0L;
				InvokeServerRPCLocal(hash, NetworkingManager.Singleton.LocalClientId, messageStream);
			}
			else
			{
				InternalMessageSender.Send(NetworkingManager.Singleton.ServerClientId, 14, string.IsNullOrEmpty(channel) ? "MLAPI_DEFAULT_MESSAGE" : channel, pooledBitStream, security, null);
			}
		}

		internal RpcResponse<T> SendServerRPCPerformanceResponse<T>(ulong hash, Stream messageStream, string channel, SecuritySendFlags security)
		{
			if (!IsClient && IsRunning)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Only client and host can invoke ServerRPC");
				}
				return null;
			}
			ulong num = ResponseMessageManager.GenerateMessageId();
			RpcResponse<T> rpcResponse;
			using (PooledBitStream pooledBitStream = PooledBitStream.Get())
			{
				using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
				pooledBitWriter.WriteUInt64Packed(NetworkId);
				pooledBitWriter.WriteUInt16Packed(NetworkedObject.GetOrderIndex(this));
				pooledBitWriter.WriteUInt64Packed(hash);
				if (!IsHost)
				{
					pooledBitWriter.WriteUInt64Packed(num);
				}
				pooledBitStream.CopyFrom(messageStream);
				if (IsHost)
				{
					messageStream.Position = 0L;
					object result = InvokeServerRPCLocal(hash, NetworkingManager.Singleton.LocalClientId, messageStream);
					rpcResponse = new RpcResponse<T>();
					rpcResponse.Id = num;
					rpcResponse.IsDone = true;
					rpcResponse.IsSuccessful = true;
					rpcResponse.Result = result;
					rpcResponse.Type = typeof(T);
					rpcResponse.ClientId = NetworkingManager.Singleton.ServerClientId;
					rpcResponse = rpcResponse;
				}
				else
				{
					RpcResponse<T> rpcResponse2 = new RpcResponse<T>();
					rpcResponse2.Id = num;
					rpcResponse2.IsDone = false;
					rpcResponse2.IsSuccessful = false;
					rpcResponse2.Type = typeof(T);
					rpcResponse2.ClientId = NetworkingManager.Singleton.ServerClientId;
					RpcResponse<T> rpcResponse3 = rpcResponse2;
					ResponseMessageManager.Add(rpcResponse3.Id, rpcResponse3);
					InternalMessageSender.Send(NetworkingManager.Singleton.ServerClientId, 15, string.IsNullOrEmpty(channel) ? "MLAPI_DEFAULT_MESSAGE" : channel, pooledBitStream, security, null);
					rpcResponse = rpcResponse3;
				}
			}
			return rpcResponse;
		}

		internal void SendClientRPCPerformance(ulong hash, List<ulong> clientIds, Stream messageStream, string channel, SecuritySendFlags security)
		{
			if (!IsServer && IsRunning)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Only servers and hosts can invoke ClientRPC");
				}
				return;
			}
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			pooledBitWriter.WriteUInt64Packed(NetworkId);
			pooledBitWriter.WriteUInt16Packed(NetworkedObject.GetOrderIndex(this));
			pooledBitWriter.WriteUInt64Packed(hash);
			pooledBitStream.CopyFrom(messageStream);
			if (IsHost)
			{
				if (NetworkedObject.observers.Contains(NetworkingManager.Singleton.LocalClientId))
				{
					messageStream.Position = 0L;
					InvokeClientRPCLocal(hash, NetworkingManager.Singleton.LocalClientId, messageStream);
				}
				else if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
				{
					NetworkLog.LogWarning("Silently suppressed ClientRPC because a connected client was not an observer");
				}
			}
			InternalMessageSender.Send(17, string.IsNullOrEmpty(channel) ? "MLAPI_DEFAULT_MESSAGE" : channel, clientIds, pooledBitStream, security, NetworkedObject);
		}

		internal void SendClientRPCPerformance(ulong hash, Stream messageStream, ulong clientIdToIgnore, string channel, SecuritySendFlags security)
		{
			if (!IsServer && IsRunning)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Only servers and hosts can invoke ClientRPC");
				}
				return;
			}
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			pooledBitWriter.WriteUInt64Packed(NetworkId);
			pooledBitWriter.WriteUInt16Packed(NetworkedObject.GetOrderIndex(this));
			pooledBitWriter.WriteUInt64Packed(hash);
			pooledBitStream.CopyFrom(messageStream);
			if (IsHost && NetworkingManager.Singleton.LocalClientId != clientIdToIgnore)
			{
				if (NetworkedObject.observers.Contains(NetworkingManager.Singleton.LocalClientId))
				{
					messageStream.Position = 0L;
					InvokeClientRPCLocal(hash, NetworkingManager.Singleton.LocalClientId, messageStream);
				}
				else if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
				{
					NetworkLog.LogWarning("Silently suppressed ClientRPC because a connected client was not an observer");
				}
			}
			InternalMessageSender.Send(17, string.IsNullOrEmpty(channel) ? "MLAPI_DEFAULT_MESSAGE" : channel, clientIdToIgnore, pooledBitStream, security, NetworkedObject);
		}

		internal void SendClientRPCPerformance(ulong hash, ulong clientId, Stream messageStream, string channel, SecuritySendFlags security)
		{
			if (!IsServer && IsRunning)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Only servers and hosts can invoke ClientRPC");
				}
				return;
			}
			if (!NetworkedObject.observers.Contains(clientId))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Cannot send ClientRPC to client without visibility to the object");
				}
				return;
			}
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			pooledBitWriter.WriteUInt64Packed(NetworkId);
			pooledBitWriter.WriteUInt16Packed(NetworkedObject.GetOrderIndex(this));
			pooledBitWriter.WriteUInt64Packed(hash);
			pooledBitStream.CopyFrom(messageStream);
			if (IsHost && clientId == NetworkingManager.Singleton.LocalClientId)
			{
				messageStream.Position = 0L;
				InvokeClientRPCLocal(hash, NetworkingManager.Singleton.LocalClientId, messageStream);
			}
			else
			{
				InternalMessageSender.Send(clientId, 17, string.IsNullOrEmpty(channel) ? "MLAPI_DEFAULT_MESSAGE" : channel, pooledBitStream, security, null);
			}
		}

		internal RpcResponse<T> SendClientRPCPerformanceResponse<T>(ulong hash, ulong clientId, Stream messageStream, string channel, SecuritySendFlags security)
		{
			if (!IsServer && IsRunning)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Only servers and hosts can invoke ClientRPC");
				}
				return null;
			}
			if (!NetworkedObject.observers.Contains(clientId))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Cannot send ClientRPC to client without visibility to the object");
				}
				return null;
			}
			ulong num = ResponseMessageManager.GenerateMessageId();
			RpcResponse<T> rpcResponse;
			using (PooledBitStream pooledBitStream = PooledBitStream.Get())
			{
				using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
				pooledBitWriter.WriteUInt64Packed(NetworkId);
				pooledBitWriter.WriteUInt16Packed(NetworkedObject.GetOrderIndex(this));
				pooledBitWriter.WriteUInt64Packed(hash);
				if (!IsHost || clientId != NetworkingManager.Singleton.LocalClientId)
				{
					pooledBitWriter.WriteUInt64Packed(num);
				}
				pooledBitStream.CopyFrom(messageStream);
				if (IsHost && clientId == NetworkingManager.Singleton.LocalClientId)
				{
					messageStream.Position = 0L;
					object result = InvokeClientRPCLocal(hash, NetworkingManager.Singleton.LocalClientId, messageStream);
					rpcResponse = new RpcResponse<T>();
					rpcResponse.Id = num;
					rpcResponse.IsDone = true;
					rpcResponse.IsSuccessful = true;
					rpcResponse.Result = result;
					rpcResponse.Type = typeof(T);
					rpcResponse.ClientId = clientId;
					rpcResponse = rpcResponse;
				}
				else
				{
					RpcResponse<T> rpcResponse2 = new RpcResponse<T>();
					rpcResponse2.Id = num;
					rpcResponse2.IsDone = false;
					rpcResponse2.IsSuccessful = false;
					rpcResponse2.Type = typeof(T);
					rpcResponse2.ClientId = clientId;
					RpcResponse<T> rpcResponse3 = rpcResponse2;
					ResponseMessageManager.Add(rpcResponse3.Id, rpcResponse3);
					InternalMessageSender.Send(clientId, 18, string.IsNullOrEmpty(channel) ? "MLAPI_DEFAULT_MESSAGE" : channel, pooledBitStream, security, null);
					rpcResponse = rpcResponse3;
				}
			}
			return rpcResponse;
		}

		protected NetworkedObject GetNetworkedObject(ulong networkId)
		{
			if (SpawnManager.SpawnedObjects.ContainsKey(networkId))
			{
				return SpawnManager.SpawnedObjects[networkId];
			}
			return null;
		}

		public void InvokeClientRpc(string methodName, List<ulong> clientIds, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security);
		}

		public void InvokeClientRpc(RpcMethod method, List<ulong> clientIds, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security);
		}

		public void InvokeClientRpc<T1>(string methodName, List<ulong> clientIds, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1);
		}

		public void InvokeClientRpc<T1>(RpcMethod<T1> method, List<ulong> clientIds, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1);
		}

		public void InvokeClientRpc<T1, T2>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2);
		}

		public void InvokeClientRpc<T1, T2>(RpcMethod<T1, T2> method, List<ulong> clientIds, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2);
		}

		public void InvokeClientRpc<T1, T2, T3>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3);
		}

		public void InvokeClientRpc<T1, T2, T3>(RpcMethod<T1, T2, T3> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3);
		}

		public void InvokeClientRpc<T1, T2, T3, T4>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4);
		}

		public void InvokeClientRpc<T1, T2, T3, T4>(RpcMethod<T1, T2, T3, T4> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5>(RpcMethod<T1, T2, T3, T4, T5> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6>(RpcMethod<T1, T2, T3, T4, T5, T6> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7>(RpcMethod<T1, T2, T3, T4, T5, T6, T7> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(string methodName, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32);
		}

		public void InvokeClientRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32> method, List<ulong> clientIds, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), clientIds, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32);
		}

		public void InvokeClientRpcOnClient(RpcMethod method, ulong clientId, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security);
		}

		public void InvokeClientRpcOnClient(string methodName, ulong clientId, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security);
		}

		public void InvokeClientRpcOnClient<T1>(RpcMethod<T1> method, ulong clientId, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1);
		}

		public void InvokeClientRpcOnClient<T1>(string methodName, ulong clientId, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1);
		}

		public void InvokeClientRpcOnClient<T1, T2>(RpcMethod<T1, T2> method, ulong clientId, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2);
		}

		public void InvokeClientRpcOnClient<T1, T2>(string methodName, ulong clientId, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3>(RpcMethod<T1, T2, T3> method, ulong clientId, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4>(RpcMethod<T1, T2, T3, T4> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5>(RpcMethod<T1, T2, T3, T4, T5> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6>(RpcMethod<T1, T2, T3, T4, T5, T6> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7>(RpcMethod<T1, T2, T3, T4, T5, T6, T7> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32);
		}

		public void InvokeClientRpcOnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), clientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32);
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult>(ResponseRpcMethod<TResult> method, ulong clientId, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[0]);
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult>(string methodName, ulong clientId, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[0]);
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1>(ResponseRpcMethod<TResult, T1> method, ulong clientId, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[1] { t1 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1>(string methodName, ulong clientId, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[1] { t1 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2>(ResponseRpcMethod<TResult, T1, T2> method, ulong clientId, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[2] { t1, t2 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2>(string methodName, ulong clientId, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[2] { t1, t2 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3>(ResponseRpcMethod<TResult, T1, T2, T3> method, ulong clientId, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[3] { t1, t2, t3 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[3] { t1, t2, t3 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4>(ResponseRpcMethod<TResult, T1, T2, T3, T4> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[4] { t1, t2, t3, t4 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[4] { t1, t2, t3, t4 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[5] { t1, t2, t3, t4, t5 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[5] { t1, t2, t3, t4, t5 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[6] { t1, t2, t3, t4, t5, t6 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[6] { t1, t2, t3, t4, t5, t6 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[7] { t1, t2, t3, t4, t5, t6, t7 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[7] { t1, t2, t3, t4, t5, t6, t7 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[8] { t1, t2, t3, t4, t5, t6, t7, t8 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[8] { t1, t2, t3, t4, t5, t6, t7, t8 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[9] { t1, t2, t3, t4, t5, t6, t7, t8, t9 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[9] { t1, t2, t3, t4, t5, t6, t7, t8, t9 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[10] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[10] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[11]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[11]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[12]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[12]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[13]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[13]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[14]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[14]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[15]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[15]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[16]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[16]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[17]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[17]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[18]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[18]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[19]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[19]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[20]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[20]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[21]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[21]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[22]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[22]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[23]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[23]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[24]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[24]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[25]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[25]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[26]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[26]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[27]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[27]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[28]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[28]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[29]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[29]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[30]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[30]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[31]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
				t31
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[31]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
				t31
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32> method, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), clientId, channel, security, new object[32]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
				t31, t32
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnClient<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(string methodName, ulong clientId, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), clientId, channel, security, new object[32]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
				t31, t32
			});
		}

		public void InvokeClientRpcOnEveryone(RpcMethod method, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security);
		}

		public void InvokeClientRpcOnEveryone(string methodName, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security);
		}

		public void InvokeClientRpcOnEveryone<T1>(RpcMethod<T1> method, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1);
		}

		public void InvokeClientRpcOnEveryone<T1>(string methodName, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1);
		}

		public void InvokeClientRpcOnEveryone<T1, T2>(RpcMethod<T1, T2> method, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2);
		}

		public void InvokeClientRpcOnEveryone<T1, T2>(string methodName, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3>(RpcMethod<T1, T2, T3> method, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3>(string methodName, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4>(RpcMethod<T1, T2, T3, T4> method, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5>(RpcMethod<T1, T2, T3, T4, T5> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6>(RpcMethod<T1, T2, T3, T4, T5, T6> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7>(RpcMethod<T1, T2, T3, T4, T5, T6, T7> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethod(method.Method), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32);
		}

		public void InvokeClientRpcOnEveryone<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxed(HashMethodName(methodName), null, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32);
		}

		public void InvokeClientRpcOnEveryoneExcept(RpcMethod method, ulong clientIdToIgnore, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security);
		}

		public void InvokeClientRpcOnEveryoneExcept(string methodName, ulong clientIdToIgnore, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1>(RpcMethod<T1> method, ulong clientIdToIgnore, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1>(string methodName, ulong clientIdToIgnore, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2>(RpcMethod<T1, T2> method, ulong clientIdToIgnore, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3>(RpcMethod<T1, T2, T3> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4>(RpcMethod<T1, T2, T3, T4> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5>(RpcMethod<T1, T2, T3, T4, T5> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6>(RpcMethod<T1, T2, T3, T4, T5, T6> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7>(RpcMethod<T1, T2, T3, T4, T5, T6, T7> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32> method, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32);
		}

		public void InvokeClientRpcOnEveryoneExcept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(string methodName, ulong clientIdToIgnore, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToEveryoneExcept(clientIdToIgnore, HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32);
		}

		public void InvokeClientRpcOnOwner(RpcMethod method, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security);
		}

		public void InvokeClientRpcOnOwner(string methodName, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security);
		}

		public void InvokeClientRpcOnOwner<T1>(RpcMethod<T1> method, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1);
		}

		public void InvokeClientRpcOnOwner<T1>(string methodName, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1);
		}

		public void InvokeClientRpcOnOwner<T1, T2>(RpcMethod<T1, T2> method, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2);
		}

		public void InvokeClientRpcOnOwner<T1, T2>(string methodName, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3>(RpcMethod<T1, T2, T3> method, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3>(string methodName, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4>(RpcMethod<T1, T2, T3, T4> method, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5>(RpcMethod<T1, T2, T3, T4, T5> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6>(RpcMethod<T1, T2, T3, T4, T5, T6> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7>(RpcMethod<T1, T2, T3, T4, T5, T6, T7> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethod(method.Method), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32);
		}

		public void InvokeClientRpcOnOwner<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCBoxedToClient(HashMethodName(methodName), OwnerClientId, channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32);
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult>(ResponseRpcMethod<TResult> method, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[0]);
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult>(string methodName, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[0]);
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1>(ResponseRpcMethod<TResult, T1> method, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[1] { t1 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1>(string methodName, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[1] { t1 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2>(ResponseRpcMethod<TResult, T1, T2> method, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[2] { t1, t2 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2>(string methodName, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[2] { t1, t2 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3>(ResponseRpcMethod<TResult, T1, T2, T3> method, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[3] { t1, t2, t3 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3>(string methodName, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[3] { t1, t2, t3 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4>(ResponseRpcMethod<TResult, T1, T2, T3, T4> method, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[4] { t1, t2, t3, t4 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[4] { t1, t2, t3, t4 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[5] { t1, t2, t3, t4, t5 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[5] { t1, t2, t3, t4, t5 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[6] { t1, t2, t3, t4, t5, t6 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[6] { t1, t2, t3, t4, t5, t6 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[7] { t1, t2, t3, t4, t5, t6, t7 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[7] { t1, t2, t3, t4, t5, t6, t7 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[8] { t1, t2, t3, t4, t5, t6, t7, t8 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[8] { t1, t2, t3, t4, t5, t6, t7, t8 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[9] { t1, t2, t3, t4, t5, t6, t7, t8, t9 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[9] { t1, t2, t3, t4, t5, t6, t7, t8, t9 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[10] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[10] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 });
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[11]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[11]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[12]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[12]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[13]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[13]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[14]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[14]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[15]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[15]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[16]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[16]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[17]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[17]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[18]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[18]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[19]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[19]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[20]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[20]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[21]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[21]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[22]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[22]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[23]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[23]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[24]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[24]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[25]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[25]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[26]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[26]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[27]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[27]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[28]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[28]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[29]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[29]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[30]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[30]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[31]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
				t31
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[31]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
				t31
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethod(method.Method), OwnerClientId, channel, security, new object[32]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
				t31, t32
			});
		}

		public RpcResponse<TResult> InvokeClientRpcOnOwner<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendClientRPCBoxedResponse<TResult>(HashMethodName(methodName), OwnerClientId, channel, security, new object[32]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
				t31, t32
			});
		}

		public void InvokeServerRpc(RpcMethod method, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security);
		}

		public void InvokeServerRpc(string methodName, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult>(ResponseRpcMethod<TResult> method, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[0]);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult>(string methodName, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[0]);
		}

		public void InvokeServerRpc<T1>(RpcMethod<T1> method, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1>(ResponseRpcMethod<TResult, T1> method, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[1] { t1 });
		}

		public void InvokeServerRpc<T1>(string methodName, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1>(string methodName, T1 t1, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[1] { t1 });
		}

		public void InvokeServerRpc<T1, T2>(RpcMethod<T1, T2> method, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2>(ResponseRpcMethod<TResult, T1, T2> method, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[2] { t1, t2 });
		}

		public void InvokeServerRpc<T1, T2>(string methodName, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2>(string methodName, T1 t1, T2 t2, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[2] { t1, t2 });
		}

		public void InvokeServerRpc<T1, T2, T3>(RpcMethod<T1, T2, T3> method, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3>(ResponseRpcMethod<TResult, T1, T2, T3> method, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[3] { t1, t2, t3 });
		}

		public void InvokeServerRpc<T1, T2, T3>(string methodName, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3>(string methodName, T1 t1, T2 t2, T3 t3, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[3] { t1, t2, t3 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4>(RpcMethod<T1, T2, T3, T4> method, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4>(ResponseRpcMethod<TResult, T1, T2, T3, T4> method, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[4] { t1, t2, t3, t4 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[4] { t1, t2, t3, t4 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5>(RpcMethod<T1, T2, T3, T4, T5> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[5] { t1, t2, t3, t4, t5 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[5] { t1, t2, t3, t4, t5 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6>(RpcMethod<T1, T2, T3, T4, T5, T6> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[6] { t1, t2, t3, t4, t5, t6 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[6] { t1, t2, t3, t4, t5, t6 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7>(RpcMethod<T1, T2, T3, T4, T5, T6, T7> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[7] { t1, t2, t3, t4, t5, t6, t7 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[7] { t1, t2, t3, t4, t5, t6, t7 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[8] { t1, t2, t3, t4, t5, t6, t7, t8 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[8] { t1, t2, t3, t4, t5, t6, t7, t8 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[9] { t1, t2, t3, t4, t5, t6, t7, t8, t9 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[9] { t1, t2, t3, t4, t5, t6, t7, t8, t9 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[10] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[10] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 });
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[11]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[11]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[12]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[12]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[13]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[13]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[14]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[14]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[15]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[15]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[16]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[16]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[17]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[17]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[18]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[18]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[19]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[19]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[20]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[20]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[21]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[21]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[22]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[22]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[23]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[23]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[24]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[24]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[25]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[25]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[26]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[26]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[27]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[27]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[28]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[28]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[29]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[29]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[30]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[30]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[31]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
				t31
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[31]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
				t31
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(RpcMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethod(method.Method), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(ResponseRpcMethod<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32> method, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethod(method.Method), channel, security, new object[32]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
				t31, t32
			});
		}

		public void InvokeServerRpc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCBoxed(HashMethodName(methodName), channel, security, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32);
		}

		public RpcResponse<TResult> InvokeServerRpc<TResult, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32>(string methodName, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15, T16 t16, T17 t17, T18 t18, T19 t19, T20 t20, T21 t21, T22 t22, T23 t23, T24 t24, T25 t25, T26 t26, T27 t27, T28 t28, T29 t29, T30 t30, T31 t31, T32 t32, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			return SendServerRPCBoxedResponse<TResult>(HashMethodName(methodName), channel, security, new object[32]
			{
				t1, t2, t3, t4, t5, t6, t7, t8, t9, t10,
				t11, t12, t13, t14, t15, t16, t17, t18, t19, t20,
				t21, t22, t23, t24, t25, t26, t27, t28, t29, t30,
				t31, t32
			});
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use InvokeClientRpcPerformance instead")]
		public void InvokeClientRpc(RpcDelegate method, List<ulong> clientIds, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethod(method.Method), clientIds, stream, channel, security);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use InvokeClientRpcOnOwnerPerformance instead")]
		public void InvokeClientRpcOnOwner(RpcDelegate method, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethod(method.Method), OwnerClientId, stream, channel, security);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use InvokeClientRpcOnClientPerformance instead")]
		public void InvokeClientRpcOnClient(RpcDelegate method, ulong clientId, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethod(method.Method), clientId, stream, channel, security);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use InvokeClientRpcOnEveryonePerformance instead")]
		public void InvokeClientRpcOnEveryone(RpcDelegate method, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethod(method.Method), null, stream, channel, security);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use InvokeClientRpcOnEveryoneExceptPerformance instead")]
		public void InvokeClientRpcOnEveryoneExcept(RpcDelegate method, ulong clientIdToIgnore, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethod(method.Method), stream, clientIdToIgnore, channel, security);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use InvokeClientRpcPerformance instead")]
		public void InvokeClientRpc(string methodName, List<ulong> clientIds, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethodName(methodName), clientIds, stream, channel, security);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use InvokeClientRpcOnClientPerformance instead")]
		public void InvokeClientRpcOnClient(string methodName, ulong clientId, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethodName(methodName), clientId, stream, channel, security);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use InvokeClientRpcOnOwnerPerformance instead")]
		public void InvokeClientRpcOnOwner(string methodName, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethodName(methodName), OwnerClientId, stream, channel, security);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use InvokeClientRpcOnEveryonePerformance instead")]
		public void InvokeClientRpcOnEveryone(string methodName, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethodName(methodName), null, stream, channel, security);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use InvokeClientRpcOnEveryoneExceptPerformance instead")]
		public void InvokeClientRpcOnEveryoneExcept(string methodName, ulong clientIdToIgnore, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethodName(methodName), stream, clientIdToIgnore, channel, security);
		}

		public void InvokeClientRpcPerformance(RpcDelegate method, List<ulong> clientIds, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethod(method.Method), clientIds, stream, channel, security);
		}

		public void InvokeClientRpcOnOwnerPerformance(RpcDelegate method, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethod(method.Method), OwnerClientId, stream, channel, security);
		}

		public void InvokeClientRpcOnClientPerformance(RpcDelegate method, ulong clientId, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethod(method.Method), clientId, stream, channel, security);
		}

		public void InvokeClientRpcOnEveryonePerformance(RpcDelegate method, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethod(method.Method), null, stream, channel, security);
		}

		public void InvokeClientRpcOnEveryoneExceptPerformance(RpcDelegate method, ulong clientIdToIgnore, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethod(method.Method), stream, clientIdToIgnore, channel, security);
		}

		public void InvokeClientRpcPerformance(string methodName, List<ulong> clientIds, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethodName(methodName), clientIds, stream, channel, security);
		}

		public void InvokeClientRpcOnClientPerformance(string methodName, ulong clientId, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethodName(methodName), clientId, stream, channel, security);
		}

		public void InvokeClientRpcOnOwnerPerformance(string methodName, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethodName(methodName), OwnerClientId, stream, channel, security);
		}

		public void InvokeClientRpcOnEveryonePerformance(string methodName, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethodName(methodName), null, stream, channel, security);
		}

		public void InvokeClientRpcOnEveryoneExceptPerformance(string methodName, ulong clientIdToIgnore, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendClientRPCPerformance(HashMethodName(methodName), stream, clientIdToIgnore, channel, security);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use InvokeServerRpcPerformance instead")]
		public void InvokeServerRpc(RpcDelegate method, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCPerformance(HashMethod(method.Method), stream, channel, security);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use InvokeServerRpcPerformance instead")]
		public void InvokeServerRpc(string methodName, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCPerformance(HashMethodName(methodName), stream, channel, security);
		}

		public void InvokeServerRpcPerformance(RpcDelegate method, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCPerformance(HashMethod(method.Method), stream, channel, security);
		}

		public void InvokeServerRpcPerformance(string methodName, Stream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			SendServerRPCPerformance(HashMethodName(methodName), stream, channel, security);
		}
	}
}

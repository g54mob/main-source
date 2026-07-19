namespace UniJSON
{
	public static class RpcExtensions
	{
		public static void Request(this IRpc rpc, string method)
		{
			rpc.Request(Utf8String.From(method));
		}

		public static void Request<A0>(this IRpc rpc, string method, A0 a0)
		{
			rpc.Request(Utf8String.From(method), a0);
		}

		public static void Request<A0, A1>(this IRpc rpc, string method, A0 a0, A1 a1)
		{
			rpc.Request(Utf8String.From(method), a0, a1);
		}

		public static void Request<A0, A1, A2>(this IRpc rpc, string method, A0 a0, A1 a1, A2 a2)
		{
			rpc.Request(Utf8String.From(method), a0, a1, a2);
		}

		public static void Request<A0, A1, A2, A3>(this IRpc rpc, string method, A0 a0, A1 a1, A2 a2, A3 a3)
		{
			rpc.Request(Utf8String.From(method), a0, a1, a2, a3);
		}

		public static void Request<A0, A1, A2, A3, A4>(this IRpc rpc, string method, A0 a0, A1 a1, A2 a2, A3 a3, A4 a4)
		{
			rpc.Request(Utf8String.From(method), a0, a1, a2, a3, a4);
		}

		public static void Request<A0, A1, A2, A3, A4, A5>(this IRpc rpc, string method, A0 a0, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
		{
			rpc.Request(Utf8String.From(method), a0, a1, a2, a3, a4, a5);
		}

		public static void Notify(this IRpc rpc, string method)
		{
			rpc.Notify(Utf8String.From(method));
		}

		public static void Notify<A0>(this IRpc rpc, string method, A0 a0)
		{
			rpc.Notify(Utf8String.From(method), a0);
		}

		public static void Notify<A0, A1>(this IRpc rpc, string method, A0 a0, A1 a1)
		{
			rpc.Notify(Utf8String.From(method), a0, a1);
		}

		public static void Notify<A0, A1, A2>(this IRpc rpc, string method, A0 a0, A1 a1, A2 a2)
		{
			rpc.Notify(Utf8String.From(method), a0, a1, a2);
		}

		public static void Notify<A0, A1, A2, A3>(this IRpc rpc, string method, A0 a0, A1 a1, A2 a2, A3 a3)
		{
			rpc.Notify(Utf8String.From(method), a0, a1, a2, a3);
		}

		public static void Notify<A0, A1, A2, A3, A4>(this IRpc rpc, string method, A0 a0, A1 a1, A2 a2, A3 a3, A4 a4)
		{
			rpc.Notify(Utf8String.From(method), a0, a1, a2, a3, a4);
		}

		public static void Notify<A0, A1, A2, A3, A4, A5>(this IRpc rpc, string method, A0 a0, A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
		{
			rpc.Notify(Utf8String.From(method), a0, a1, a2, a3, a4, a5);
		}
	}
}

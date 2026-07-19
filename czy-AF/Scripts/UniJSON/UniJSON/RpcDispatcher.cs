using System;
using System.Collections.Generic;

namespace UniJSON
{
	public class RpcDispatcher<T> where T : IListTreeItem, IValue<T>
	{
		private delegate void Callback(int id, ListTreeNode<T> args, IRpc f);

		private Dictionary<string, Callback> m_map = new Dictionary<string, Callback>();

		public void Register<A0>(string method, Action<A0> action)
		{
			m_map.Add(method, delegate(int id, ListTreeNode<T> args, IRpc f)
			{
				IEnumerator<ListTreeNode<T>> enumerator = args.ArrayItems().GetEnumerator();
				A0 value = default(A0);
				enumerator.MoveNext();
				enumerator.Current.Deserialize(ref value);
				try
				{
					action(value);
					f.ResponseSuccess(id);
				}
				catch (Exception error)
				{
					f.ResponseError(id, error);
				}
			});
		}

		public void Register<A0, A1>(string method, Action<A0, A1> action)
		{
			throw new NotImplementedException();
		}

		public void Register<A0, A1, R>(string method, Func<A0, A1, R> action)
		{
			m_map.Add(method, delegate(int id, ListTreeNode<T> args, IRpc f)
			{
				IEnumerator<ListTreeNode<T>> enumerator = args.ArrayItems().GetEnumerator();
				A0 value = default(A0);
				enumerator.MoveNext();
				enumerator.Current.Deserialize(ref value);
				A1 value2 = default(A1);
				enumerator.MoveNext();
				enumerator.Current.Deserialize(ref value2);
				try
				{
					R result = action(value, value2);
					f.ResponseSuccess(id, result);
				}
				catch (Exception error)
				{
					f.ResponseError(id, error);
				}
			});
		}

		public void Call(IRpc f, int id, string method, ListTreeNode<T> args)
		{
			if (!m_map.TryGetValue(method, out var value))
			{
				throw new KeyNotFoundException();
			}
			value(id, args, f);
		}
	}
}

using System;
using System.Threading.Tasks.Sources;

namespace Cysharp.Threading.Tasks
{
	public interface IUniTaskSource : IValueTaskSource
	{
		new UniTaskStatus GetStatus(short token);

		void OnCompleted(Action<object> continuation, object state, short token);

		new void GetResult(short token);

		UniTaskStatus UnsafeGetStatus();

		private virtual ValueTaskSourceStatus System_002EThreading_002ETasks_002ESources_002EIValueTaskSource_002EGetStatus(short token)
		{
			return default(ValueTaskSourceStatus);
		}

		private virtual void System_002EThreading_002ETasks_002ESources_002EIValueTaskSource_002EGetResult(short token)
		{
		}

		private virtual void System_002EThreading_002ETasks_002ESources_002EIValueTaskSource_002EOnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags)
		{
		}
	}
	public interface IUniTaskSource<out T> : IUniTaskSource, IValueTaskSource, IValueTaskSource<T>
	{
		new T GetResult(short token);

		new UniTaskStatus GetStatus(short token)
		{
			return default(UniTaskStatus);
		}

		new void OnCompleted(Action<object> continuation, object state, short token)
		{
		}

		private virtual ValueTaskSourceStatus System_002EThreading_002ETasks_002ESources_002EIValueTaskSource_003CT_003E_002EGetStatus(short token)
		{
			return default(ValueTaskSourceStatus);
		}

		private virtual T System_002EThreading_002ETasks_002ESources_002EIValueTaskSource_003CT_003E_002EGetResult(short token)
		{
			return default(T);
		}

		private virtual void System_002EThreading_002ETasks_002ESources_002EIValueTaskSource_003CT_003E_002EOnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags)
		{
		}
	}
}

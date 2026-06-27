using System;
using System.Collections.Generic;
using System.Linq;
using RSG.Exceptions;
using RSG.Promises;

namespace RSG
{
	public class Promise<PromisedT> : IPromise<PromisedT>, IPendingPromise<PromisedT>, IRejectable, IPromiseInfo
	{
		private Exception rejectionException;

		private PromisedT resolveValue;

		private List<RejectHandler> rejectHandlers;

		private List<ProgressHandler> progressHandlers;

		private List<Action<PromisedT>> resolveCallbacks;

		private List<IRejectable> resolveRejectables;

		private readonly int id;

		public int Id => id;

		public string Name { get; private set; }

		public PromiseState CurState { get; private set; }

		public Promise()
		{
			CurState = PromiseState.Pending;
			id = Promise.NextId();
			if (Promise.EnablePromiseTracking)
			{
				Promise.PendingPromises.Add(this);
			}
		}

		public Promise(Action<Action<PromisedT>, Action<Exception>> resolver)
		{
			CurState = PromiseState.Pending;
			id = Promise.NextId();
			if (Promise.EnablePromiseTracking)
			{
				Promise.PendingPromises.Add(this);
			}
			try
			{
				resolver(Resolve, Reject);
			}
			catch (Exception ex)
			{
				Reject(ex);
			}
		}

		private void AddRejectHandler(Action<Exception> onRejected, IRejectable rejectable)
		{
			if (rejectHandlers == null)
			{
				rejectHandlers = new List<RejectHandler>();
			}
			rejectHandlers.Add(new RejectHandler
			{
				callback = onRejected,
				rejectable = rejectable
			});
		}

		private void AddResolveHandler(Action<PromisedT> onResolved, IRejectable rejectable)
		{
			if (resolveCallbacks == null)
			{
				resolveCallbacks = new List<Action<PromisedT>>();
			}
			if (resolveRejectables == null)
			{
				resolveRejectables = new List<IRejectable>();
			}
			resolveCallbacks.Add(onResolved);
			resolveRejectables.Add(rejectable);
		}

		private void AddProgressHandler(Action<float> onProgress, IRejectable rejectable)
		{
			if (progressHandlers == null)
			{
				progressHandlers = new List<ProgressHandler>();
			}
			progressHandlers.Add(new ProgressHandler
			{
				callback = onProgress,
				rejectable = rejectable
			});
		}

		private void InvokeHandler<T>(Action<T> callback, IRejectable rejectable, T value)
		{
			try
			{
				callback(value);
			}
			catch (Exception ex)
			{
				rejectable.Reject(ex);
			}
		}

		private void ClearHandlers()
		{
			rejectHandlers = null;
			resolveCallbacks = null;
			resolveRejectables = null;
			progressHandlers = null;
		}

		private void InvokeRejectHandlers(Exception ex)
		{
			if (rejectHandlers != null)
			{
				rejectHandlers.Each(delegate(RejectHandler handler)
				{
					InvokeHandler(handler.callback, handler.rejectable, ex);
				});
			}
			ClearHandlers();
		}

		private void InvokeResolveHandlers(PromisedT value)
		{
			if (resolveCallbacks != null)
			{
				int i = 0;
				for (int count = resolveCallbacks.Count; i < count; i++)
				{
					InvokeHandler(resolveCallbacks[i], resolveRejectables[i], value);
				}
			}
			ClearHandlers();
		}

		private void InvokeProgressHandlers(float progress)
		{
			if (progressHandlers != null)
			{
				progressHandlers.Each(delegate(ProgressHandler handler)
				{
					InvokeHandler(handler.callback, handler.rejectable, progress);
				});
			}
		}

		public void Reject(Exception ex)
		{
			if (CurState != PromiseState.Pending)
			{
				throw new PromiseStateException(string.Concat("Attempt to reject a promise that is already in state: ", CurState, ", a promise can only be rejected when it is still in state: ", PromiseState.Pending));
			}
			rejectionException = ex;
			CurState = PromiseState.Rejected;
			if (Promise.EnablePromiseTracking)
			{
				Promise.PendingPromises.Remove(this);
			}
			InvokeRejectHandlers(ex);
		}

		public void Resolve(PromisedT value)
		{
			if (CurState != PromiseState.Pending)
			{
				throw new PromiseStateException(string.Concat("Attempt to resolve a promise that is already in state: ", CurState, ", a promise can only be resolved when it is still in state: ", PromiseState.Pending));
			}
			resolveValue = value;
			CurState = PromiseState.Resolved;
			if (Promise.EnablePromiseTracking)
			{
				Promise.PendingPromises.Remove(this);
			}
			InvokeResolveHandlers(value);
		}

		public void ReportProgress(float progress)
		{
			if (CurState != PromiseState.Pending)
			{
				throw new PromiseStateException(string.Concat("Attempt to report progress on a promise that is already in state: ", CurState, ", a promise can only report progress when it is still in state: ", PromiseState.Pending));
			}
			InvokeProgressHandlers(progress);
		}

		public void Done(Action<PromisedT> onResolved, Action<Exception> onRejected)
		{
			Then(onResolved, onRejected).Catch(delegate(Exception ex)
			{
				Promise.PropagateUnhandledException(this, ex);
			});
		}

		public void Done(Action<PromisedT> onResolved)
		{
			Then(onResolved).Catch(delegate(Exception ex)
			{
				Promise.PropagateUnhandledException(this, ex);
			});
		}

		public void Done()
		{
			Catch(delegate(Exception ex)
			{
				Promise.PropagateUnhandledException(this, ex);
			});
		}

		public IPromise<PromisedT> WithName(string name)
		{
			Name = name;
			return this;
		}

		public IPromise Catch(Action<Exception> onRejected)
		{
			Promise resultPromise = new Promise();
			resultPromise.WithName(Name);
			Action<PromisedT> resolveHandler = delegate
			{
				resultPromise.Resolve();
			};
			Action<Exception> rejectHandler = delegate(Exception ex)
			{
				try
				{
					onRejected(ex);
					resultPromise.Resolve();
				}
				catch (Exception ex2)
				{
					resultPromise.Reject(ex2);
				}
			};
			ActionHandlers(resultPromise, resolveHandler, rejectHandler);
			ProgressHandlers(resultPromise, delegate(float v)
			{
				resultPromise.ReportProgress(v);
			});
			return resultPromise;
		}

		public IPromise<PromisedT> Catch(Func<Exception, PromisedT> onRejected)
		{
			Promise<PromisedT> resultPromise = new Promise<PromisedT>();
			resultPromise.WithName(Name);
			Action<PromisedT> resolveHandler = delegate(PromisedT v)
			{
				resultPromise.Resolve(v);
			};
			Action<Exception> rejectHandler = delegate(Exception ex)
			{
				try
				{
					resultPromise.Resolve(onRejected(ex));
				}
				catch (Exception ex2)
				{
					resultPromise.Reject(ex2);
				}
			};
			ActionHandlers(resultPromise, resolveHandler, rejectHandler);
			ProgressHandlers(resultPromise, delegate(float v)
			{
				resultPromise.ReportProgress(v);
			});
			return resultPromise;
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<PromisedT, IPromise<ConvertedT>> onResolved)
		{
			return Then(onResolved, null, null);
		}

		public IPromise Then(Func<PromisedT, IPromise> onResolved)
		{
			return Then(onResolved, null, null);
		}

		public IPromise Then(Action<PromisedT> onResolved)
		{
			return Then(onResolved, null, null);
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<PromisedT, IPromise<ConvertedT>> onResolved, Func<Exception, IPromise<ConvertedT>> onRejected)
		{
			return Then(onResolved, onRejected, null);
		}

		public IPromise Then(Func<PromisedT, IPromise> onResolved, Action<Exception> onRejected)
		{
			return Then(onResolved, onRejected, null);
		}

		public IPromise Then(Action<PromisedT> onResolved, Action<Exception> onRejected)
		{
			return Then(onResolved, onRejected, null);
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<PromisedT, IPromise<ConvertedT>> onResolved, Func<Exception, IPromise<ConvertedT>> onRejected, Action<float> onProgress)
		{
			Promise<ConvertedT> resultPromise = new Promise<ConvertedT>();
			resultPromise.WithName(Name);
			Action<PromisedT> resolveHandler = delegate(PromisedT v)
			{
				onResolved(v).Progress(delegate(float progress)
				{
					resultPromise.ReportProgress(progress);
				}).Then(delegate(ConvertedT chainedValue)
				{
					resultPromise.Resolve(chainedValue);
				}, delegate(Exception ex)
				{
					resultPromise.Reject(ex);
				});
			};
			Action<Exception> rejectHandler = delegate(Exception ex)
			{
				if (onRejected == null)
				{
					resultPromise.Reject(ex);
					return;
				}
				try
				{
					onRejected(ex).Then(delegate(ConvertedT chainedValue)
					{
						resultPromise.Resolve(chainedValue);
					}, delegate(Exception callbackEx)
					{
						resultPromise.Reject(callbackEx);
					});
				}
				catch (Exception ex2)
				{
					resultPromise.Reject(ex2);
				}
			};
			ActionHandlers(resultPromise, resolveHandler, rejectHandler);
			if (onProgress != null)
			{
				ProgressHandlers(this, onProgress);
			}
			return resultPromise;
		}

		public IPromise Then(Func<PromisedT, IPromise> onResolved, Action<Exception> onRejected, Action<float> onProgress)
		{
			Promise resultPromise = new Promise();
			resultPromise.WithName(Name);
			Action<PromisedT> resolveHandler = delegate(PromisedT v)
			{
				if (onResolved != null)
				{
					onResolved(v).Progress(delegate(float progress)
					{
						resultPromise.ReportProgress(progress);
					}).Then(delegate
					{
						resultPromise.Resolve();
					}, delegate(Exception ex)
					{
						resultPromise.Reject(ex);
					});
				}
				else
				{
					resultPromise.Resolve();
				}
			};
			Action<Exception> rejectHandler = delegate(Exception ex)
			{
				if (onRejected != null)
				{
					onRejected(ex);
				}
				resultPromise.Reject(ex);
			};
			ActionHandlers(resultPromise, resolveHandler, rejectHandler);
			if (onProgress != null)
			{
				ProgressHandlers(this, onProgress);
			}
			return resultPromise;
		}

		public IPromise Then(Action<PromisedT> onResolved, Action<Exception> onRejected, Action<float> onProgress)
		{
			Promise resultPromise = new Promise();
			resultPromise.WithName(Name);
			Action<PromisedT> resolveHandler = delegate(PromisedT v)
			{
				if (onResolved != null)
				{
					onResolved(v);
				}
				resultPromise.Resolve();
			};
			Action<Exception> rejectHandler = delegate(Exception ex)
			{
				if (onRejected != null)
				{
					onRejected(ex);
				}
				resultPromise.Reject(ex);
			};
			ActionHandlers(resultPromise, resolveHandler, rejectHandler);
			if (onProgress != null)
			{
				ProgressHandlers(this, onProgress);
			}
			return resultPromise;
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<PromisedT, ConvertedT> transform)
		{
			return Then((PromisedT value) => Promise<ConvertedT>.Resolved(transform(value)));
		}

		private void ActionHandlers(IRejectable resultPromise, Action<PromisedT> resolveHandler, Action<Exception> rejectHandler)
		{
			if (CurState == PromiseState.Resolved)
			{
				InvokeHandler(resolveHandler, resultPromise, resolveValue);
				return;
			}
			if (CurState == PromiseState.Rejected)
			{
				InvokeHandler(rejectHandler, resultPromise, rejectionException);
				return;
			}
			AddResolveHandler(resolveHandler, resultPromise);
			AddRejectHandler(rejectHandler, resultPromise);
		}

		private void ProgressHandlers(IRejectable resultPromise, Action<float> progressHandler)
		{
			if (CurState == PromiseState.Pending)
			{
				AddProgressHandler(progressHandler, resultPromise);
			}
		}

		public IPromise<IEnumerable<ConvertedT>> ThenAll<ConvertedT>(Func<PromisedT, IEnumerable<IPromise<ConvertedT>>> chain)
		{
			return Then((PromisedT value) => Promise<ConvertedT>.All(chain(value)));
		}

		public IPromise ThenAll(Func<PromisedT, IEnumerable<IPromise>> chain)
		{
			return Then((PromisedT value) => Promise.All(chain(value)));
		}

		public static IPromise<IEnumerable<PromisedT>> All(params IPromise<PromisedT>[] promises)
		{
			return All((IEnumerable<IPromise<PromisedT>>)promises);
		}

		public static IPromise<IEnumerable<PromisedT>> All(IEnumerable<IPromise<PromisedT>> promises)
		{
			IPromise<PromisedT>[] array = promises.ToArray();
			if (array.Length == 0)
			{
				return Promise<IEnumerable<PromisedT>>.Resolved(Enumerable.Empty<PromisedT>());
			}
			int remainingCount = array.Length;
			PromisedT[] results = new PromisedT[remainingCount];
			float[] progress = new float[remainingCount];
			Promise<IEnumerable<PromisedT>> resultPromise = new Promise<IEnumerable<PromisedT>>();
			resultPromise.WithName("All");
			array.Each(delegate(IPromise<PromisedT> promise, int index)
			{
				promise.Progress(delegate(float v)
				{
					progress[index] = v;
					if (resultPromise.CurState == PromiseState.Pending)
					{
						resultPromise.ReportProgress(progress.Average());
					}
				}).Then(delegate(PromisedT result)
				{
					progress[index] = 1f;
					results[index] = result;
					int num = remainingCount - 1;
					remainingCount = num;
					if (remainingCount <= 0 && resultPromise.CurState == PromiseState.Pending)
					{
						resultPromise.Resolve(results);
					}
				}).Catch(delegate(Exception ex)
				{
					if (resultPromise.CurState == PromiseState.Pending)
					{
						resultPromise.Reject(ex);
					}
				})
					.Done();
			});
			return resultPromise;
		}

		public IPromise<ConvertedT> ThenRace<ConvertedT>(Func<PromisedT, IEnumerable<IPromise<ConvertedT>>> chain)
		{
			return Then((PromisedT value) => Promise<ConvertedT>.Race(chain(value)));
		}

		public IPromise ThenRace(Func<PromisedT, IEnumerable<IPromise>> chain)
		{
			return Then((PromisedT value) => Promise.Race(chain(value)));
		}

		public static IPromise<PromisedT> Race(params IPromise<PromisedT>[] promises)
		{
			return Race((IEnumerable<IPromise<PromisedT>>)promises);
		}

		public static IPromise<PromisedT> Race(IEnumerable<IPromise<PromisedT>> promises)
		{
			IPromise<PromisedT>[] array = promises.ToArray();
			if (array.Length == 0)
			{
				throw new InvalidOperationException("At least 1 input promise must be provided for Race");
			}
			Promise<PromisedT> resultPromise = new Promise<PromisedT>();
			resultPromise.WithName("Race");
			float[] progress = new float[array.Length];
			array.Each(delegate(IPromise<PromisedT> promise, int index)
			{
				promise.Progress(delegate(float v)
				{
					if (resultPromise.CurState == PromiseState.Pending)
					{
						progress[index] = v;
						resultPromise.ReportProgress(progress.Max());
					}
				}).Then(delegate(PromisedT result)
				{
					if (resultPromise.CurState == PromiseState.Pending)
					{
						resultPromise.Resolve(result);
					}
				}).Catch(delegate(Exception ex)
				{
					if (resultPromise.CurState == PromiseState.Pending)
					{
						resultPromise.Reject(ex);
					}
				})
					.Done();
			});
			return resultPromise;
		}

		public static IPromise<PromisedT> Resolved(PromisedT promisedValue)
		{
			Promise<PromisedT> promise = new Promise<PromisedT>();
			promise.Resolve(promisedValue);
			return promise;
		}

		public static IPromise<PromisedT> Rejected(Exception ex)
		{
			Promise<PromisedT> promise = new Promise<PromisedT>();
			promise.Reject(ex);
			return promise;
		}

		public IPromise<PromisedT> Finally(Action onComplete)
		{
			Promise<PromisedT> promise = new Promise<PromisedT>();
			promise.WithName(Name);
			Then(delegate(PromisedT x)
			{
				promise.Resolve(x);
			});
			Catch(delegate(Exception e)
			{
				try
				{
					onComplete();
					promise.Reject(e);
				}
				catch (Exception ex)
				{
					promise.Reject(ex);
				}
			});
			return promise.Then(delegate(PromisedT v)
			{
				onComplete();
				return v;
			});
		}

		public IPromise ContinueWith(Func<IPromise> onComplete)
		{
			Promise promise = new Promise();
			promise.WithName(Name);
			Then(delegate
			{
				promise.Resolve();
			});
			Catch(delegate
			{
				promise.Resolve();
			});
			return promise.Then(onComplete);
		}

		public IPromise<ConvertedT> ContinueWith<ConvertedT>(Func<IPromise<ConvertedT>> onComplete)
		{
			Promise promise = new Promise();
			promise.WithName(Name);
			Then(delegate
			{
				promise.Resolve();
			});
			Catch(delegate
			{
				promise.Resolve();
			});
			return promise.Then(onComplete);
		}

		public IPromise<PromisedT> Progress(Action<float> onProgress)
		{
			if (onProgress != null)
			{
				ProgressHandlers(this, onProgress);
			}
			return this;
		}
	}
	public class Promise : IPromise, IPendingPromise, IRejectable, IPromiseInfo
	{
		public struct ResolveHandler
		{
			public Action callback;

			public IRejectable rejectable;
		}

		public static bool EnablePromiseTracking = false;

		private static EventHandler<ExceptionEventArgs> unhandlerException;

		private static int nextPromiseId;

		internal static readonly HashSet<IPromiseInfo> PendingPromises = new HashSet<IPromiseInfo>();

		private Exception rejectionException;

		private List<RejectHandler> rejectHandlers;

		private List<ResolveHandler> resolveHandlers;

		private List<ProgressHandler> progressHandlers;

		private readonly int id;

		public int Id => id;

		public string Name { get; private set; }

		public PromiseState CurState { get; private set; }

		public static event EventHandler<ExceptionEventArgs> UnhandledException
		{
			add
			{
				unhandlerException = (EventHandler<ExceptionEventArgs>)Delegate.Combine(unhandlerException, value);
			}
			remove
			{
				unhandlerException = (EventHandler<ExceptionEventArgs>)Delegate.Remove(unhandlerException, value);
			}
		}

		public static IEnumerable<IPromiseInfo> GetPendingPromises()
		{
			return PendingPromises;
		}

		public Promise()
		{
			CurState = PromiseState.Pending;
			id = NextId();
			if (EnablePromiseTracking)
			{
				PendingPromises.Add(this);
			}
		}

		public Promise(Action<Action, Action<Exception>> resolver)
		{
			CurState = PromiseState.Pending;
			id = NextId();
			if (EnablePromiseTracking)
			{
				PendingPromises.Add(this);
			}
			try
			{
				resolver(Resolve, Reject);
			}
			catch (Exception ex)
			{
				Reject(ex);
			}
		}

		internal static int NextId()
		{
			return ++nextPromiseId;
		}

		private void AddRejectHandler(Action<Exception> onRejected, IRejectable rejectable)
		{
			if (rejectHandlers == null)
			{
				rejectHandlers = new List<RejectHandler>();
			}
			rejectHandlers.Add(new RejectHandler
			{
				callback = onRejected,
				rejectable = rejectable
			});
		}

		private void AddResolveHandler(Action onResolved, IRejectable rejectable)
		{
			if (resolveHandlers == null)
			{
				resolveHandlers = new List<ResolveHandler>();
			}
			resolveHandlers.Add(new ResolveHandler
			{
				callback = onResolved,
				rejectable = rejectable
			});
		}

		private void AddProgressHandler(Action<float> onProgress, IRejectable rejectable)
		{
			if (progressHandlers == null)
			{
				progressHandlers = new List<ProgressHandler>();
			}
			progressHandlers.Add(new ProgressHandler
			{
				callback = onProgress,
				rejectable = rejectable
			});
		}

		private void InvokeRejectHandler(Action<Exception> callback, IRejectable rejectable, Exception value)
		{
			try
			{
				callback(value);
			}
			catch (Exception ex)
			{
				rejectable.Reject(ex);
			}
		}

		private void InvokeResolveHandler(Action callback, IRejectable rejectable)
		{
			try
			{
				callback();
			}
			catch (Exception ex)
			{
				rejectable.Reject(ex);
			}
		}

		private void InvokeProgressHandler(Action<float> callback, IRejectable rejectable, float progress)
		{
			try
			{
				callback(progress);
			}
			catch (Exception ex)
			{
				rejectable.Reject(ex);
			}
		}

		private void ClearHandlers()
		{
			rejectHandlers = null;
			resolveHandlers = null;
			progressHandlers = null;
		}

		private void InvokeRejectHandlers(Exception ex)
		{
			if (rejectHandlers != null)
			{
				rejectHandlers.Each(delegate(RejectHandler handler)
				{
					InvokeRejectHandler(handler.callback, handler.rejectable, ex);
				});
			}
			ClearHandlers();
		}

		private void InvokeResolveHandlers()
		{
			if (resolveHandlers != null)
			{
				resolveHandlers.Each(delegate(ResolveHandler handler)
				{
					InvokeResolveHandler(handler.callback, handler.rejectable);
				});
			}
			ClearHandlers();
		}

		private void InvokeProgressHandlers(float progress)
		{
			if (progressHandlers != null)
			{
				progressHandlers.Each(delegate(ProgressHandler handler)
				{
					InvokeProgressHandler(handler.callback, handler.rejectable, progress);
				});
			}
		}

		public void Reject(Exception ex)
		{
			if (CurState != PromiseState.Pending)
			{
				throw new PromiseStateException(string.Concat("Attempt to reject a promise that is already in state: ", CurState, ", a promise can only be rejected when it is still in state: ", PromiseState.Pending));
			}
			rejectionException = ex;
			CurState = PromiseState.Rejected;
			if (EnablePromiseTracking)
			{
				PendingPromises.Remove(this);
			}
			InvokeRejectHandlers(ex);
		}

		public void Resolve()
		{
			if (CurState != PromiseState.Pending)
			{
				throw new PromiseStateException(string.Concat("Attempt to resolve a promise that is already in state: ", CurState, ", a promise can only be resolved when it is still in state: ", PromiseState.Pending));
			}
			CurState = PromiseState.Resolved;
			if (EnablePromiseTracking)
			{
				PendingPromises.Remove(this);
			}
			InvokeResolveHandlers();
		}

		public void ReportProgress(float progress)
		{
			if (CurState != PromiseState.Pending)
			{
				throw new PromiseStateException(string.Concat("Attempt to report progress on a promise that is already in state: ", CurState, ", a promise can only report progress when it is still in state: ", PromiseState.Pending));
			}
			InvokeProgressHandlers(progress);
		}

		public void Done(Action onResolved, Action<Exception> onRejected)
		{
			Then(onResolved, onRejected).Catch(delegate(Exception ex)
			{
				PropagateUnhandledException(this, ex);
			});
		}

		public void Done(Action onResolved)
		{
			Then(onResolved).Catch(delegate(Exception ex)
			{
				PropagateUnhandledException(this, ex);
			});
		}

		public void Done()
		{
			Catch(delegate(Exception ex)
			{
				PropagateUnhandledException(this, ex);
			});
		}

		public IPromise WithName(string name)
		{
			Name = name;
			return this;
		}

		public IPromise Catch(Action<Exception> onRejected)
		{
			Promise resultPromise = new Promise();
			resultPromise.WithName(Name);
			Action resolveHandler = delegate
			{
				resultPromise.Resolve();
			};
			Action<Exception> rejectHandler = delegate(Exception ex)
			{
				try
				{
					onRejected(ex);
					resultPromise.Resolve();
				}
				catch (Exception ex2)
				{
					resultPromise.Reject(ex2);
				}
			};
			ActionHandlers(resultPromise, resolveHandler, rejectHandler);
			ProgressHandlers(resultPromise, delegate(float v)
			{
				resultPromise.ReportProgress(v);
			});
			return resultPromise;
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<IPromise<ConvertedT>> onResolved)
		{
			return Then(onResolved, null, null);
		}

		public IPromise Then(Func<IPromise> onResolved)
		{
			return Then(onResolved, null, null);
		}

		public IPromise Then(Action onResolved)
		{
			return Then(onResolved, null, null);
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<IPromise<ConvertedT>> onResolved, Func<Exception, IPromise<ConvertedT>> onRejected)
		{
			return Then(onResolved, onRejected, null);
		}

		public IPromise Then(Func<IPromise> onResolved, Action<Exception> onRejected)
		{
			return Then(onResolved, onRejected, null);
		}

		public IPromise Then(Action onResolved, Action<Exception> onRejected)
		{
			return Then(onResolved, onRejected, null);
		}

		public IPromise<ConvertedT> Then<ConvertedT>(Func<IPromise<ConvertedT>> onResolved, Func<Exception, IPromise<ConvertedT>> onRejected, Action<float> onProgress)
		{
			Promise<ConvertedT> resultPromise = new Promise<ConvertedT>();
			resultPromise.WithName(Name);
			Action resolveHandler = delegate
			{
				onResolved().Progress(delegate(float progress)
				{
					resultPromise.ReportProgress(progress);
				}).Then(delegate(ConvertedT chainedValue)
				{
					resultPromise.Resolve(chainedValue);
				}, delegate(Exception ex)
				{
					resultPromise.Reject(ex);
				});
			};
			Action<Exception> rejectHandler = delegate(Exception ex)
			{
				if (onRejected == null)
				{
					resultPromise.Reject(ex);
					return;
				}
				try
				{
					onRejected(ex).Then(delegate(ConvertedT chainedValue)
					{
						resultPromise.Resolve(chainedValue);
					}, delegate(Exception callbackEx)
					{
						resultPromise.Reject(callbackEx);
					});
				}
				catch (Exception ex2)
				{
					resultPromise.Reject(ex2);
				}
			};
			ActionHandlers(resultPromise, resolveHandler, rejectHandler);
			if (onProgress != null)
			{
				ProgressHandlers(this, onProgress);
			}
			return resultPromise;
		}

		public IPromise Then(Func<IPromise> onResolved, Action<Exception> onRejected, Action<float> onProgress)
		{
			Promise resultPromise = new Promise();
			resultPromise.WithName(Name);
			Action resolveHandler = delegate
			{
				if (onResolved != null)
				{
					onResolved().Progress(delegate(float progress)
					{
						resultPromise.ReportProgress(progress);
					}).Then(delegate
					{
						resultPromise.Resolve();
					}, delegate(Exception ex)
					{
						resultPromise.Reject(ex);
					});
				}
				else
				{
					resultPromise.Resolve();
				}
			};
			Action<Exception> rejectHandler = delegate(Exception ex)
			{
				if (onRejected != null)
				{
					onRejected(ex);
				}
				resultPromise.Reject(ex);
			};
			ActionHandlers(resultPromise, resolveHandler, rejectHandler);
			if (onProgress != null)
			{
				ProgressHandlers(this, onProgress);
			}
			return resultPromise;
		}

		public IPromise Then(Action onResolved, Action<Exception> onRejected, Action<float> onProgress)
		{
			Promise resultPromise = new Promise();
			resultPromise.WithName(Name);
			Action resolveHandler = delegate
			{
				if (onResolved != null)
				{
					onResolved();
				}
				resultPromise.Resolve();
			};
			Action<Exception> rejectHandler = delegate(Exception ex)
			{
				if (onRejected != null)
				{
					onRejected(ex);
					resultPromise.Resolve();
				}
				else
				{
					resultPromise.Reject(ex);
				}
			};
			ActionHandlers(resultPromise, resolveHandler, rejectHandler);
			if (onProgress != null)
			{
				ProgressHandlers(this, onProgress);
			}
			return resultPromise;
		}

		private void ActionHandlers(IRejectable resultPromise, Action resolveHandler, Action<Exception> rejectHandler)
		{
			if (CurState == PromiseState.Resolved)
			{
				InvokeResolveHandler(resolveHandler, resultPromise);
				return;
			}
			if (CurState == PromiseState.Rejected)
			{
				InvokeRejectHandler(rejectHandler, resultPromise, rejectionException);
				return;
			}
			AddResolveHandler(resolveHandler, resultPromise);
			AddRejectHandler(rejectHandler, resultPromise);
		}

		private void ProgressHandlers(IRejectable resultPromise, Action<float> progressHandler)
		{
			if (CurState == PromiseState.Pending)
			{
				AddProgressHandler(progressHandler, resultPromise);
			}
		}

		public IPromise ThenAll(Func<IEnumerable<IPromise>> chain)
		{
			return Then(() => All(chain()));
		}

		public IPromise<IEnumerable<ConvertedT>> ThenAll<ConvertedT>(Func<IEnumerable<IPromise<ConvertedT>>> chain)
		{
			return Then(() => Promise<ConvertedT>.All(chain()));
		}

		public static IPromise All(params IPromise[] promises)
		{
			return All((IEnumerable<IPromise>)promises);
		}

		public static IPromise All(IEnumerable<IPromise> promises)
		{
			IPromise[] array = promises.ToArray();
			if (array.Length == 0)
			{
				return Resolved();
			}
			int remainingCount = array.Length;
			Promise resultPromise = new Promise();
			resultPromise.WithName("All");
			float[] progress = new float[remainingCount];
			array.Each(delegate(IPromise promise, int index)
			{
				promise.Progress(delegate(float v)
				{
					progress[index] = v;
					if (resultPromise.CurState == PromiseState.Pending)
					{
						resultPromise.ReportProgress(progress.Average());
					}
				}).Then(delegate
				{
					progress[index] = 1f;
					int num = remainingCount - 1;
					remainingCount = num;
					if (remainingCount <= 0 && resultPromise.CurState == PromiseState.Pending)
					{
						resultPromise.Resolve();
					}
				}).Catch(delegate(Exception ex)
				{
					if (resultPromise.CurState == PromiseState.Pending)
					{
						resultPromise.Reject(ex);
					}
				})
					.Done();
			});
			return resultPromise;
		}

		public IPromise ThenSequence(Func<IEnumerable<Func<IPromise>>> chain)
		{
			return Then(() => Sequence(chain()));
		}

		public static IPromise Sequence(params Func<IPromise>[] fns)
		{
			return Sequence((IEnumerable<Func<IPromise>>)fns);
		}

		public static IPromise Sequence(IEnumerable<Func<IPromise>> fns)
		{
			Promise promise = new Promise();
			int count = 0;
			fns.Aggregate(Resolved(), delegate(IPromise prevPromise, Func<IPromise> fn)
			{
				int itemSequence = count;
				int num = count + 1;
				count = num;
				return prevPromise.Then(delegate
				{
					float num2 = 1f / (float)count;
					promise.ReportProgress(num2 * (float)itemSequence);
					return fn();
				}).Progress(delegate(float v)
				{
					float num2 = 1f / (float)count;
					promise.ReportProgress(num2 * (v + (float)itemSequence));
				});
			}).Then(delegate
			{
				promise.Resolve();
			}).Catch(promise.Reject);
			return promise;
		}

		public IPromise ThenRace(Func<IEnumerable<IPromise>> chain)
		{
			return Then(() => Race(chain()));
		}

		public IPromise<ConvertedT> ThenRace<ConvertedT>(Func<IEnumerable<IPromise<ConvertedT>>> chain)
		{
			return Then(() => Promise<ConvertedT>.Race(chain()));
		}

		public static IPromise Race(params IPromise[] promises)
		{
			return Race((IEnumerable<IPromise>)promises);
		}

		public static IPromise Race(IEnumerable<IPromise> promises)
		{
			IPromise[] array = promises.ToArray();
			if (array.Length == 0)
			{
				throw new InvalidOperationException("At least 1 input promise must be provided for Race");
			}
			Promise resultPromise = new Promise();
			resultPromise.WithName("Race");
			float[] progress = new float[array.Length];
			array.Each(delegate(IPromise promise, int index)
			{
				promise.Progress(delegate(float v)
				{
					progress[index] = v;
					resultPromise.ReportProgress(progress.Max());
				}).Catch(delegate(Exception ex)
				{
					if (resultPromise.CurState == PromiseState.Pending)
					{
						resultPromise.Reject(ex);
					}
				}).Then(delegate
				{
					if (resultPromise.CurState == PromiseState.Pending)
					{
						resultPromise.Resolve();
					}
				})
					.Done();
			});
			return resultPromise;
		}

		public static IPromise Resolved()
		{
			Promise promise = new Promise();
			promise.Resolve();
			return promise;
		}

		public static IPromise Rejected(Exception ex)
		{
			Promise promise = new Promise();
			promise.Reject(ex);
			return promise;
		}

		public IPromise Finally(Action onComplete)
		{
			Promise promise = new Promise();
			promise.WithName(Name);
			Then(delegate
			{
				promise.Resolve();
			});
			Catch(delegate(Exception e)
			{
				try
				{
					onComplete();
					promise.Reject(e);
				}
				catch (Exception ex)
				{
					promise.Reject(ex);
				}
			});
			return promise.Then(onComplete);
		}

		public IPromise ContinueWith(Func<IPromise> onComplete)
		{
			Promise promise = new Promise();
			promise.WithName(Name);
			Then(delegate
			{
				promise.Resolve();
			});
			Catch(delegate
			{
				promise.Resolve();
			});
			return promise.Then(onComplete);
		}

		public IPromise<ConvertedT> ContinueWith<ConvertedT>(Func<IPromise<ConvertedT>> onComplete)
		{
			Promise promise = new Promise();
			promise.WithName(Name);
			Then(delegate
			{
				promise.Resolve();
			});
			Catch(delegate
			{
				promise.Resolve();
			});
			return promise.Then(onComplete);
		}

		public IPromise Progress(Action<float> onProgress)
		{
			if (onProgress != null)
			{
				ProgressHandlers(this, onProgress);
			}
			return this;
		}

		internal static void PropagateUnhandledException(object sender, Exception ex)
		{
			if (unhandlerException != null)
			{
				unhandlerException(sender, new ExceptionEventArgs(ex));
			}
		}
	}
}

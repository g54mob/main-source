using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx.InternalUtil;
using UniRx.Triggers;
using UnityEngine;

namespace UniRx
{
	public static class ObserveExtensions
	{
		public static IObservable<TProperty> ObserveEveryValueChanged<TSource, TProperty>(this TSource source, Func<TSource, TProperty> propertySelector, FrameCountType frameCountType = FrameCountType.Update, bool fastDestroyCheck = false) where TSource : class
		{
			return source.ObserveEveryValueChanged(propertySelector, frameCountType, UnityEqualityComparer.GetDefault<TProperty>(), fastDestroyCheck);
		}

		public static IObservable<TProperty> ObserveEveryValueChanged<TSource, TProperty>(this TSource source, Func<TSource, TProperty> propertySelector, FrameCountType frameCountType, IEqualityComparer<TProperty> comparer) where TSource : class
		{
			return source.ObserveEveryValueChanged(propertySelector, frameCountType, comparer, fastDestroyCheck: false);
		}

		public static IObservable<TProperty> ObserveEveryValueChanged<TSource, TProperty>(this TSource source, Func<TSource, TProperty> propertySelector, FrameCountType frameCountType, IEqualityComparer<TProperty> comparer, bool fastDestroyCheck) where TSource : class
		{
			if (source == null)
			{
				return Observable.Empty<TProperty>();
			}
			if (comparer == null)
			{
				comparer = UnityEqualityComparer.GetDefault<TProperty>();
			}
			UnityEngine.Object unityObject = source as UnityEngine.Object;
			bool flag = source is UnityEngine.Object;
			if (flag && unityObject == null)
			{
				return Observable.Empty<TProperty>();
			}
			if (flag)
			{
				return Observable.FromMicroCoroutine(delegate(IObserver<TProperty> observer, CancellationToken cancellationToken)
				{
					if (unityObject != null)
					{
						TProperty val = default(TProperty);
						try
						{
							val = propertySelector((TSource)(object)unityObject);
						}
						catch (Exception error)
						{
							observer.OnError(error);
							return EmptyEnumerator();
						}
						observer.OnNext(val);
						return PublishUnityObjectValueChanged(unityObject, val, propertySelector, comparer, observer, cancellationToken, fastDestroyCheck);
					}
					observer.OnCompleted();
					return EmptyEnumerator();
				}, frameCountType);
			}
			WeakReference reference = new WeakReference(source);
			source = null;
			return Observable.FromMicroCoroutine(delegate(IObserver<TProperty> observer, CancellationToken cancellationToken)
			{
				object target = reference.Target;
				if (target != null)
				{
					TProperty val = default(TProperty);
					try
					{
						val = propertySelector((TSource)target);
					}
					catch (Exception error)
					{
						observer.OnError(error);
						return EmptyEnumerator();
					}
					finally
					{
						target = null;
					}
					observer.OnNext(val);
					return PublishPocoValueChanged(reference, val, propertySelector, comparer, observer, cancellationToken);
				}
				observer.OnCompleted();
				return EmptyEnumerator();
			}, frameCountType);
		}

		private static IEnumerator EmptyEnumerator()
		{
			yield break;
		}

		private static IEnumerator PublishPocoValueChanged<TSource, TProperty>(WeakReference sourceReference, TProperty firstValue, Func<TSource, TProperty> propertySelector, IEqualityComparer<TProperty> comparer, IObserver<TProperty> observer, CancellationToken cancellationToken)
		{
			TProperty val = default(TProperty);
			TProperty prevValue = firstValue;
			while (!cancellationToken.IsCancellationRequested)
			{
				object target = sourceReference.Target;
				if (target != null)
				{
					try
					{
						val = propertySelector((TSource)target);
					}
					catch (Exception error)
					{
						observer.OnError(error);
						break;
					}
					finally
					{
					}
					if (!comparer.Equals(val, prevValue))
					{
						observer.OnNext(val);
						prevValue = val;
					}
					yield return null;
					continue;
				}
				observer.OnCompleted();
				break;
			}
		}

		private static IEnumerator PublishUnityObjectValueChanged<TSource, TProperty>(UnityEngine.Object unityObject, TProperty firstValue, Func<TSource, TProperty> propertySelector, IEqualityComparer<TProperty> comparer, IObserver<TProperty> observer, CancellationToken cancellationToken, bool fastDestroyCheck)
		{
			TProperty prevValue = firstValue;
			TSource source = (TSource)(object)unityObject;
			if (fastDestroyCheck)
			{
				GameObject gameObject = unityObject as GameObject;
				if (gameObject == null)
				{
					Component component = unityObject as Component;
					if (component != null)
					{
						gameObject = component.gameObject;
					}
				}
				if (!(gameObject == null))
				{
					ObservableDestroyTrigger destroyTrigger = GetOrAddDestroyTrigger(gameObject);
					while (!cancellationToken.IsCancellationRequested)
					{
						if (destroyTrigger.IsActivated ? (!destroyTrigger.IsCalledOnDestroy) : (unityObject != null))
						{
							TProperty val;
							try
							{
								val = propertySelector(source);
							}
							catch (Exception error)
							{
								observer.OnError(error);
								break;
							}
							if (!comparer.Equals(val, prevValue))
							{
								observer.OnNext(val);
								prevValue = val;
							}
							yield return null;
							continue;
						}
						observer.OnCompleted();
						break;
					}
					yield break;
				}
			}
			while (!cancellationToken.IsCancellationRequested)
			{
				if (unityObject != null)
				{
					TProperty val;
					try
					{
						val = propertySelector(source);
					}
					catch (Exception error2)
					{
						observer.OnError(error2);
						break;
					}
					if (!comparer.Equals(val, prevValue))
					{
						observer.OnNext(val);
						prevValue = val;
					}
					yield return null;
					continue;
				}
				observer.OnCompleted();
				break;
			}
		}

		private static ObservableDestroyTrigger GetOrAddDestroyTrigger(GameObject go)
		{
			ObservableDestroyTrigger observableDestroyTrigger = go.GetComponent<ObservableDestroyTrigger>();
			if (observableDestroyTrigger == null)
			{
				observableDestroyTrigger = go.AddComponent<ObservableDestroyTrigger>();
			}
			return observableDestroyTrigger;
		}
	}
}

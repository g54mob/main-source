using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Moq.Async;
using Moq.Behaviors;
using Moq.Properties;
using TypeNameFormatter;

namespace Moq
{
	internal sealed class MethodCall : SetupWithOutParameterSupport
	{
		private VerifyInvocationCount verifyInvocationCount;

		private Behavior callback;

		private Behavior raiseEvent;

		private Behavior returnOrThrow;

		private Behavior afterReturnCallback;

		private Condition condition;

		private string failMessage;

		private string declarationSite;

		public string FailMessage => failMessage;

		public override Condition Condition => condition;

		public override IEnumerable<Mock> InnerMocks
		{
			get
			{
				Mock mock = Setup.TryGetInnerMockFrom((returnOrThrow as ReturnValue)?.Value);
				if (mock != null)
				{
					yield return mock;
				}
			}
		}

		public MethodCall(Expression originalExpression, Mock mock, Condition condition, MethodExpectation expectation)
			: base(originalExpression, mock, expectation)
		{
			this.condition = condition;
			if ((mock.Switches & Switches.CollectDiagnosticFileInfoForSetups) != Switches.Default)
			{
				declarationSite = GetUserCodeCallSite();
			}
		}

		private static string GetUserCodeCallSite()
		{
			try
			{
				MethodBase thisMethod = MethodBase.GetCurrentMethod();
				Assembly mockAssembly = Assembly.GetExecutingAssembly();
				StackFrame stackFrame = new StackTrace(fNeedFileInfo: true).GetFrames().SkipWhile((StackFrame f) => f.GetMethod() != thisMethod).SkipWhile((StackFrame f) => f.GetMethod().DeclaringType == null || f.GetMethod().DeclaringType.Assembly == mockAssembly)
					.FirstOrDefault();
				MethodBase methodBase = stackFrame?.GetMethod();
				if (methodBase != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendNameOf(methodBase.DeclaringType).Append('.').AppendNameOf(methodBase, includeGenericArgumentList: false);
					string fileName = Path.GetFileName(stackFrame.GetFileName());
					if (fileName != null)
					{
						stringBuilder.Append(" in ").Append(fileName);
						int fileLineNumber = stackFrame.GetFileLineNumber();
						if (fileLineNumber != 0)
						{
							stringBuilder.Append(": line ").Append(fileLineNumber);
						}
					}
					return stringBuilder.ToString();
				}
			}
			catch
			{
			}
			return null;
		}

		protected override void ExecuteCore(Invocation invocation)
		{
			verifyInvocationCount?.Execute(invocation);
			callback?.Execute(invocation);
			raiseEvent?.Execute(invocation);
			if (returnOrThrow != null)
			{
				returnOrThrow.Execute(invocation);
			}
			else if (invocation.Method.ReturnType != typeof(void))
			{
				if (base.Mock.Behavior == MockBehavior.Strict)
				{
					throw MockException.ReturnValueRequired(invocation);
				}
				new ReturnBaseOrDefaultValue(base.Mock).Execute(invocation);
			}
			else
			{
				HandleEventSubscription.Handle(invocation, base.Mock);
			}
			afterReturnCallback?.Execute(invocation);
		}

		public void SetCallBaseBehavior()
		{
			if (base.Mock.MockedType.IsDelegateType())
			{
				throw new NotSupportedException(Resources.CallBaseCannotBeUsedWithDelegateMocks);
			}
			returnOrThrow = ReturnBase.Instance;
		}

		public void SetCallbackBehavior(Delegate callback)
		{
			if ((object)callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			ref Behavior reference = ref returnOrThrow == null ? ref this.callback : ref afterReturnCallback;
			Action callbackWithoutArguments = callback as Action;
			if (callbackWithoutArguments != null)
			{
				reference = new Callback(delegate
				{
					callbackWithoutArguments();
				});
				return;
			}
			if (callback.GetType() == typeof(Action<IInvocation>))
			{
				reference = new Callback((Action<IInvocation>)callback);
				return;
			}
			ParameterTypes parameterTypes = base.Method.GetParameterTypes();
			if (!callback.CompareParameterTypesTo(parameterTypes))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidCallbackParameterMismatch, base.Method.GetParameterTypeList(), callback.GetMethodInfo().GetParameterTypeList()));
			}
			MethodInfo methodInfo = callback.GetMethodInfo();
			if (methodInfo.ReturnType != typeof(void))
			{
				throw new ArgumentException(Resources.InvalidCallbackNotADelegateWithReturnTypeVoid, "callback");
			}
			if (methodInfo.GetParameterTypes().Any(Extensions.IsOrContainsTypeMatcher))
			{
				throw new ArgumentException(Resources.TypeMatchersMayNotBeUsedWithCallbacks);
			}
			reference = new Callback(delegate(IInvocation invocation)
			{
				callback.InvokePreserveStack(invocation.Arguments);
			});
		}

		public void SetFailMessage(string failMessage)
		{
			this.failMessage = failMessage;
		}

		public void SetRaiseEventBehavior<TMock>(Action<TMock> eventExpression, Delegate func) where TMock : class
		{
			Guard.NotNull(eventExpression, "eventExpression");
			Expression<Action<TMock>> expression = ExpressionReconstructor.Instance.ReconstructExpression(eventExpression, base.Mock.ConstructorArguments);
			raiseEvent = new RaiseEvent(base.Mock, expression, func, null);
		}

		public void SetRaiseEventBehavior<TMock>(Action<TMock> eventExpression, params object[] args) where TMock : class
		{
			Guard.NotNull(eventExpression, "eventExpression");
			Expression<Action<TMock>> expression = ExpressionReconstructor.Instance.ReconstructExpression(eventExpression, base.Mock.ConstructorArguments);
			raiseEvent = new RaiseEvent(base.Mock, expression, null, args);
		}

		public void SetReturnValueBehavior(object value)
		{
			returnOrThrow = new ReturnValue(value);
		}

		public void SetReturnComputedValueBehavior(Delegate valueFactory)
		{
			IAwaitableFactory awaitableFactory;
			Type expectedReturnType = (base.Expectation.HasResultExpression(out awaitableFactory) ? awaitableFactory.ResultType : base.Method.ReturnType);
			if ((object)valueFactory == null)
			{
				returnOrThrow = new ReturnValue(expectedReturnType.GetDefaultValue());
				return;
			}
			if (expectedReturnType == typeof(Delegate))
			{
				returnOrThrow = new ReturnValue(valueFactory);
				return;
			}
			if (IsInvocationFunc(valueFactory))
			{
				returnOrThrow = new ReturnComputedValue((IInvocation invocation) => valueFactory.InvokePreserveStack(new object[1] { invocation }));
				return;
			}
			ValidateCallback(valueFactory);
			if (valueFactory.CompareParameterTypesTo(Type.EmptyTypes))
			{
				returnOrThrow = new ReturnComputedValue((IInvocation invocation) => valueFactory.InvokePreserveStack());
			}
			else
			{
				returnOrThrow = new ReturnComputedValue((IInvocation invocation) => valueFactory.InvokePreserveStack(invocation.Arguments));
			}
			bool IsInvocationFunc(Delegate callback)
			{
				Type type = callback.GetType();
				if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Func<, >))
				{
					Type[] genericArguments = type.GetGenericArguments();
					if (genericArguments[0] == typeof(IInvocation))
					{
						if (!(genericArguments[1] == typeof(object)))
						{
							return expectedReturnType.IsAssignableFrom(genericArguments[1]);
						}
						return true;
					}
					return false;
				}
				return false;
			}
			void ValidateCallback(Delegate callback)
			{
				MethodInfo methodInfo = callback.GetMethodInfo();
				ValidateNumberOfCallbackParameters(callback, methodInfo);
				ValidateCallbackReturnType(methodInfo, expectedReturnType);
				if (methodInfo.GetParameterTypes().Any(Extensions.IsOrContainsTypeMatcher))
				{
					throw new ArgumentException(Resources.TypeMatchersMayNotBeUsedWithCallbacks);
				}
			}
		}

		public void SetThrowExceptionBehavior(Exception exception)
		{
			returnOrThrow = new ThrowException(exception);
		}

		public void SetThrowComputedExceptionBehavior(Delegate exceptionFactory)
		{
			if ((object)exceptionFactory == null)
			{
				returnOrThrow = new ThrowException(null);
				return;
			}
			MethodInfo methodInfo = exceptionFactory.GetMethodInfo();
			ValidateNumberOfCallbackParameters(exceptionFactory, methodInfo);
			ValidateCallbackReturnType(methodInfo, typeof(Exception));
			if (exceptionFactory.CompareParameterTypesTo(Type.EmptyTypes))
			{
				returnOrThrow = new ThrowComputedException((IInvocation invocation) => exceptionFactory.InvokePreserveStack() as Exception);
			}
			else
			{
				returnOrThrow = new ThrowComputedException((IInvocation invocation) => exceptionFactory.InvokePreserveStack(invocation.Arguments) as Exception);
			}
		}

		protected override void ResetCore()
		{
			verifyInvocationCount?.Reset();
		}

		public void SetExpectedInvocationCount(Times times)
		{
			verifyInvocationCount = new VerifyInvocationCount(this, times);
		}

		protected override void VerifySelf()
		{
			if (verifyInvocationCount != null)
			{
				verifyInvocationCount.Verify();
			}
			else
			{
				base.VerifySelf();
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (failMessage != null)
			{
				stringBuilder.Append(failMessage).Append(": ");
			}
			stringBuilder.Append(base.ToString());
			if (declarationSite != null)
			{
				stringBuilder.Append(" (").Append(declarationSite).Append(')');
			}
			return stringBuilder.ToString().Trim();
		}

		private void ValidateNumberOfCallbackParameters(Delegate callback, MethodInfo callbackMethod)
		{
			int num = callbackMethod.GetParameters().Length;
			if (callbackMethod.IsStatic && (callbackMethod.IsExtensionMethod() || callback.Target != null))
			{
				num--;
			}
			if (num > 0)
			{
				int num2 = base.Method.GetParameters().Length;
				if (num != num2)
				{
					throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidCallbackParameterCountMismatch, num2, num));
				}
			}
		}

		private void ValidateCallbackReturnType(MethodInfo callbackMethod, Type expectedReturnType)
		{
			Type returnType = callbackMethod.ReturnType;
			if (returnType == typeof(void))
			{
				throw new ArgumentException(Resources.InvalidReturnsCallbackNotADelegateWithReturnType);
			}
			if (!expectedReturnType.IsAssignableFrom(returnType) && !typeof(ITypeMatcher).IsAssignableFrom(expectedReturnType))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidCallbackReturnTypeMismatch, expectedReturnType.GetFormattedName(), returnType.GetFormattedName()));
			}
		}
	}
}

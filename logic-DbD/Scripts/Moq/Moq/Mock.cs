using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq.Async;
using Moq.Expressions.Visitors;
using Moq.Language;
using Moq.Language.Flow;
using Moq.Properties;

namespace Moq
{
	public abstract class Mock : IInterceptor, IFluentInterface
	{
		internal static readonly MethodInfo GetMethod = typeof(Mock).GetMethod("Get", BindingFlags.Static | BindingFlags.Public);

		internal static readonly MethodInfo SetupReturnsMethod = typeof(Mock).GetMethod("SetupReturns", BindingFlags.Static | BindingFlags.NonPublic);

		internal abstract List<Type> AdditionalInterfaces { get; }

		public abstract MockBehavior Behavior { get; }

		public abstract bool CallBase { get; set; }

		internal abstract object[] ConstructorArguments { get; }

		public DefaultValue DefaultValue
		{
			get
			{
				return DefaultValueProvider.Kind;
			}
			set
			{
				DefaultValueProvider = value switch
				{
					DefaultValue.Empty => Moq.DefaultValueProvider.Empty, 
					DefaultValue.Mock => Moq.DefaultValueProvider.Mock, 
					_ => throw new ArgumentOutOfRangeException("value"), 
				};
			}
		}

		internal abstract EventHandlerCollection EventHandlers { get; }

		public object Object => OnGetObject();

		internal abstract Type[] InheritedInterfaces { get; }

		internal abstract bool IsObjectInitialized { get; }

		public IInvocationList Invocations => MutableInvocations;

		internal abstract InvocationCollection MutableInvocations { get; }

		internal abstract Type MockedType { get; }

		public abstract DefaultValueProvider DefaultValueProvider { get; set; }

		internal abstract SetupCollection MutableSetups { get; }

		public ISetupList Setups => MutableSetups;

		public abstract Switches Switches { get; set; }

		internal abstract Dictionary<Type, object> ConfiguredDefaultValues { get; }

		void IInterceptor.Intercept(Invocation invocation)
		{
			if (!HandleWellKnownMethods.Handle(invocation, this))
			{
				RecordInvocation.Handle(invocation, this);
				if (!FindAndExecuteMatchingSetup.Handle(invocation, this) && !HandleEventSubscription.Handle(invocation, this))
				{
					FailForStrictMock.Handle(invocation, this);
					Return.Handle(invocation, this);
				}
			}
		}

		public static T Of<T>() where T : class
		{
			return Of<T>(MockBehavior.Loose);
		}

		public static T Of<T>(MockBehavior behavior) where T : class
		{
			Mock<T> mock = new Mock<T>(behavior);
			if (behavior != MockBehavior.Strict)
			{
				mock.SetupAllProperties();
			}
			return mock.Object;
		}

		public static T Of<T>(Expression<Func<T, bool>> predicate) where T : class
		{
			return Of(predicate, MockBehavior.Loose);
		}

		public static T Of<T>(Expression<Func<T, bool>> predicate, MockBehavior behavior) where T : class
		{
			return Mocks.CreateMockQuery<T>(behavior).First(predicate);
		}

		public static Mock<T> Get<T>(T mocked) where T : class
		{
			if (mocked is IMocked<T> mocked2)
			{
				return mocked2.Mock;
			}
			if (mocked is Delegate { Target: IMocked<T> target })
			{
				return target.Mock;
			}
			if (mocked is IMocked mocked3)
			{
				Mock mock = mocked3.Mock;
				if (mock.ImplementsInterface(typeof(T)))
				{
					return mock.As<T>();
				}
				Type type = mocked.GetType().GetInterfaces().Single((Type i) => i.Name.Equals("IMocked`1", StringComparison.Ordinal));
				Type type2 = type.GetGenericArguments()[0];
				string arg = string.Join(", ", (from t in new Type[1] { type2 }.Concat<Type>(mock.InheritedInterfaces).Concat<Type>(mock.AdditionalInterfaces)
					select t.Name).ToArray());
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidMockGetType, typeof(T).Name, arg));
			}
			throw new ArgumentException(Resources.ObjectInstanceNotMock, "mocked");
		}

		public static void Verify(params Mock[] mocks)
		{
			foreach (Mock mock in mocks)
			{
				mock.Verify();
			}
		}

		public static void VerifyAll(params Mock[] mocks)
		{
			foreach (Mock mock in mocks)
			{
				mock.VerifyAll();
			}
		}

		protected abstract object OnGetObject();

		public void Verify()
		{
			Verify((ISetup setup) => setup.IsVerifiable, new HashSet<Mock>());
		}

		public void VerifyAll()
		{
			Verify((ISetup setup) => true, new HashSet<Mock>());
		}

		internal void Verify(Func<ISetup, bool> predicate, HashSet<Mock> verifiedMocks)
		{
			if (!verifiedMocks.Add(this))
			{
				return;
			}
			foreach (Invocation mutableInvocation in MutableInvocations)
			{
				mutableInvocation.MarkAsVerifiedIfMatchedBy(predicate);
			}
			List<MockException> list = new List<MockException>();
			foreach (Setup item in MutableSetups.FindAll((Setup setup) => !setup.IsConditional && predicate(setup)))
			{
				try
				{
					item.Verify(recursive: true, predicate, verifiedMocks);
				}
				catch (MockException ex) when (ex.IsVerificationError)
				{
					list.Add(ex);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			throw MockException.Combined(list, string.Format(CultureInfo.CurrentCulture, Resources.VerificationErrorsOfMock, this));
		}

		internal static void Verify(Mock mock, LambdaExpression expression, Times times, string failMessage)
		{
			Guard.NotNull(times, "times");
			List<Pair<Invocation, MethodExpectation>> invocationsToBeMarkedAsVerified;
			int matchingInvocationCount = GetMatchingInvocationCount(mock, expression, out invocationsToBeMarkedAsVerified);
			if (times.Validate(matchingInvocationCount))
			{
				foreach (var (invocation2, methodExpectation2) in invocationsToBeMarkedAsVerified)
				{
					methodExpectation2.SetupEvaluatedSuccessfully(invocation2);
					invocation2.MarkAsVerified();
				}
				return;
			}
			throw MockException.NoMatchingCalls(mock, expression, failMessage, times, matchingInvocationCount);
		}

		internal static void VerifyGet(Mock mock, LambdaExpression expression, Times times, string failMessage)
		{
			Guard.NotNull(expression, "expression");
			if (!expression.IsPropertyIndexer())
			{
				PropertyInfo property = expression.ToPropertyInfo();
				Guard.CanRead(property);
			}
			Verify(mock, expression, times, failMessage);
		}

		internal static void VerifySet(Mock mock, LambdaExpression expression, Times times, string failMessage)
		{
			Guard.NotNull(expression, "expression");
			Guard.IsAssignmentToPropertyOrIndexer(expression, "expression");
			Verify(mock, expression, times, failMessage);
		}

		internal static void VerifyAdd(Mock mock, LambdaExpression expression, Times times, string failMessage)
		{
			Guard.NotNull(expression, "expression");
			Guard.IsEventAdd(expression, "expression");
			Verify(mock, expression, times, failMessage);
		}

		internal static void VerifyRemove(Mock mock, LambdaExpression expression, Times times, string failMessage)
		{
			Guard.NotNull(expression, "expression");
			Guard.IsEventRemove(expression, "expression");
			Verify(mock, expression, times, failMessage);
		}

		internal static void VerifyNoOtherCalls(Mock mock)
		{
			VerifyNoOtherCalls(mock, new HashSet<Mock>());
		}

		private static void VerifyNoOtherCalls(Mock mock, HashSet<Mock> verifiedMocks)
		{
			if (!verifiedMocks.Add(mock))
			{
				return;
			}
			Invocation[] unverifiedInvocations = mock.MutableInvocations.ToArray((Invocation invocation) => !invocation.IsVerified);
			IEnumerable<Mock> enumerable = mock.MutableSetups.FindAllInnerMocks();
			if (unverifiedInvocations.Any())
			{
				if (enumerable.Any())
				{
					int i = 0;
					int num = unverifiedInvocations.Length;
					while (i < num)
					{
						Mock mock2 = mock.MutableSetups.FindLastInnerMock((Setup setup) => setup.Matches(unverifiedInvocations[i]));
						if (mock2 != null && mock2.MutableInvocations.Any())
						{
							unverifiedInvocations[i] = null;
						}
						int num2 = i + 1;
						i = num2;
					}
				}
				IEnumerable<Invocation> enumerable2 = unverifiedInvocations.Where((Invocation invocation) => invocation != null);
				if (enumerable2.Any())
				{
					throw MockException.UnverifiedInvocations(mock, enumerable2);
				}
			}
			foreach (Mock item in enumerable)
			{
				VerifyNoOtherCalls(item, verifiedMocks);
			}
		}

		private static int GetMatchingInvocationCount(Mock mock, LambdaExpression expression, out List<Pair<Invocation, MethodExpectation>> invocationsToBeMarkedAsVerified)
		{
			invocationsToBeMarkedAsVerified = new List<Pair<Invocation, MethodExpectation>>();
			return GetMatchingInvocationCount(mock, new ImmutablePopOnlyStack<MethodExpectation>(expression.Split()), new HashSet<Mock>(), invocationsToBeMarkedAsVerified);
		}

		private static int GetMatchingInvocationCount(Mock mock, in ImmutablePopOnlyStack<MethodExpectation> parts, HashSet<Mock> visitedInnerMocks, List<Pair<Invocation, MethodExpectation>> invocationsToBeMarkedAsVerified)
		{
			if (visitedInnerMocks.Contains(mock))
			{
				return 0;
			}
			visitedInnerMocks.Add(mock);
			ImmutablePopOnlyStack<MethodExpectation> stackBelowTop;
			MethodExpectation methodExpectation = parts.Pop(out stackBelowTop);
			int num = 0;
			foreach (Invocation item in mock.MutableInvocations.ToArray().Where(methodExpectation.IsMatch))
			{
				invocationsToBeMarkedAsVerified.Add(new Pair<Invocation, MethodExpectation>(item, methodExpectation));
				if (stackBelowTop.Empty)
				{
					num++;
				}
				else if (Awaitable.TryGetResultRecursive(item.ReturnValue) is IMocked mocked)
				{
					num += GetMatchingInvocationCount(mocked.Mock, in stackBelowTop, visitedInnerMocks, invocationsToBeMarkedAsVerified);
				}
			}
			return num;
		}

		internal static MethodCall Setup(Mock mock, LambdaExpression expression, Condition condition)
		{
			Guard.NotNull(expression, "expression");
			return SetupRecursive(mock, expression, delegate(Mock targetMock, Expression originalExpression, MethodExpectation part)
			{
				MethodCall methodCall = new MethodCall(originalExpression, targetMock, condition, part);
				targetMock.MutableSetups.Add(methodCall);
				return methodCall;
			});
		}

		internal static MethodCall SetupGet(Mock mock, LambdaExpression expression, Condition condition)
		{
			Guard.NotNull(expression, "expression");
			if (!expression.IsPropertyIndexer())
			{
				PropertyInfo property = expression.ToPropertyInfo();
				Guard.CanRead(property);
			}
			return Setup(mock, expression, condition);
		}

		internal static MethodCall SetupSet(Mock mock, LambdaExpression expression, Condition condition)
		{
			Guard.NotNull(expression, "expression");
			Guard.IsAssignmentToPropertyOrIndexer(expression, "expression");
			return Setup(mock, expression, condition);
		}

		internal static bool SetupReturns(Mock mock, LambdaExpression expression, object value)
		{
			Guard.NotNull(expression, "expression");
			SetupRecursive(mock, expression, delegate(Mock targetMock, Expression oe, MethodExpectation part)
			{
				LambdaExpression lambdaExpression = (LambdaExpression)oe;
				if (lambdaExpression.IsProperty())
				{
					PropertyInfo propertyInfo = lambdaExpression.ToPropertyInfo();
					if (propertyInfo.CanWrite(out MethodInfo setter))
					{
						if (!propertyInfo.CanRead(out MethodInfo getter) || !getter.CanOverride() || !ProxyFactory.Instance.IsMethodVisible(getter, out string messageIfNotVisible))
						{
							propertyInfo.SetValue(targetMock.Object, value, null);
							return (MethodCall)null;
						}
						if (setter.CanOverride() && ProxyFactory.Instance.IsMethodVisible(setter, out messageIfNotVisible) && targetMock.MutableSetups.FindLast((Setup s) => s is StubbedPropertiesSetup) is StubbedPropertiesSetup stubbedPropertiesSetup)
						{
							stubbedPropertiesSetup.SetProperty(propertyInfo.Name, value);
							return (MethodCall)null;
						}
					}
				}
				Guard.IsOverridable(part.Method, part.Expression);
				Guard.IsVisibleToProxyFactory(part.Method);
				MethodCall methodCall = new MethodCall(lambdaExpression, targetMock, null, part);
				methodCall.SetReturnValueBehavior(value);
				targetMock.MutableSetups.Add(methodCall);
				return (MethodCall)null;
			}, allowNonOverridableLastProperty: true);
			return true;
		}

		internal static MethodCall SetupAdd(Mock mock, LambdaExpression expression, Condition condition)
		{
			Guard.NotNull(expression, "expression");
			Guard.IsEventAdd(expression, "expression");
			return Setup(mock, expression, condition);
		}

		internal static MethodCall SetupRemove(Mock mock, LambdaExpression expression, Condition condition)
		{
			Guard.NotNull(expression, "expression");
			Guard.IsEventRemove(expression, "expression");
			return Setup(mock, expression, condition);
		}

		internal static SequenceSetup SetupSequence(Mock mock, LambdaExpression expression)
		{
			Guard.NotNull(expression, "expression");
			return SetupRecursive(mock, expression, delegate(Mock targetMock, Expression originalExpression, MethodExpectation part)
			{
				SequenceSetup sequenceSetup = new SequenceSetup(originalExpression, targetMock, part);
				targetMock.MutableSetups.Add(sequenceSetup);
				return sequenceSetup;
			});
		}

		internal static StubbedPropertySetup SetupProperty(Mock mock, LambdaExpression expression, object initialValue)
		{
			Guard.NotNull(expression, "expression");
			PropertyInfo property = expression.ToPropertyInfo();
			if (!property.CanRead(out MethodInfo getter))
			{
				Guard.CanRead(property);
			}
			if (!property.CanWrite(out MethodInfo setter))
			{
				Guard.CanWrite(property);
			}
			return SetupRecursive(mock, expression, delegate(Mock targetMock, Expression _, MethodExpectation _)
			{
				StubbedPropertySetup stubbedPropertySetup = new StubbedPropertySetup(targetMock, expression, getter, setter, initialValue);
				targetMock.MutableSetups.Add(stubbedPropertySetup);
				return stubbedPropertySetup;
			});
		}

		private static TSetup SetupRecursive<TSetup>(Mock mock, LambdaExpression expression, Func<Mock, Expression, MethodExpectation, TSetup> setupLast, bool allowNonOverridableLastProperty = false) where TSetup : ISetup
		{
			Stack<MethodExpectation> parts = expression.Split(allowNonOverridableLastProperty);
			return SetupRecursive(mock, expression, parts, setupLast);
		}

		private static TSetup SetupRecursive<TSetup>(Mock mock, LambdaExpression originalExpression, Stack<MethodExpectation> parts, Func<Mock, Expression, MethodExpectation, TSetup> setupLast) where TSetup : ISetup
		{
			MethodExpectation part = parts.Pop();
			var (expression, method, readOnlyList2) = part;
			if (parts.Count == 0)
			{
				return setupLast(mock, originalExpression, part);
			}
			Mock candidateInnerMock = mock.MutableSetups.FindLastInnerMock((Setup setup2) => setup2.Matches(part));
			if (candidateInnerMock == null)
			{
				object defaultValue = mock.GetDefaultValue(method, out candidateInnerMock, Moq.DefaultValueProvider.Mock);
				if (candidateInnerMock == null)
				{
					throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedExpression, expression.ToStringFixed() + " in " + originalExpression.ToStringFixed() + ":\n" + Resources.TypeNotMockable));
				}
				InnerMockSetup setup = new InnerMockSetup(originalExpression, mock, part, defaultValue);
				mock.MutableSetups.Add(setup);
			}
			return SetupRecursive(candidateInnerMock, originalExpression, parts, setupLast);
		}

		internal static void SetupAllProperties(Mock mock)
		{
			mock.MutableSetups.Add(new StubbedPropertiesSetup(mock));
		}

		internal static void RaiseEvent<T>(Mock mock, Action<T> action, object[] arguments)
		{
			Guard.NotNull(action, "action");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(action, mock.ConstructorArguments);
			Stack<MethodExpectation> parts = expression.Split();
			RaiseEvent(mock, expression, parts, arguments);
		}

		internal static Task RaiseEventAsync<T>(Mock mock, Action<T> action, object[] arguments)
		{
			Guard.NotNull(action, "action");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(action, mock.ConstructorArguments);
			Stack<MethodExpectation> parts = expression.Split();
			return (Task)RaiseEvent(mock, expression, parts, arguments);
		}

		internal static object RaiseEvent(Mock mock, LambdaExpression expression, Stack<MethodExpectation> parts, object[] arguments)
		{
			MethodExpectation part = parts.Pop();
			MethodInfo method = part.Method;
			if (parts.Count == 0)
			{
				EventInfo eventInfo;
				if (method.IsEventAddAccessor())
				{
					MethodInfo implementingMethod = method.GetImplementingMethod(mock.Object.GetType());
					eventInfo = implementingMethod.DeclaringType.GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).SingleOrDefault((EventInfo e) => e.GetAddMethod(nonPublic: true) == implementingMethod);
					if (eventInfo == null)
					{
						throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.SetupNotEventAdd, part.Expression));
					}
				}
				else
				{
					if (!method.IsEventRemoveAccessor())
					{
						throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedExpression, expression));
					}
					MethodInfo implementingMethod2 = method.GetImplementingMethod(mock.Object.GetType());
					eventInfo = implementingMethod2.DeclaringType.GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).SingleOrDefault((EventInfo e) => e.GetRemoveMethod(nonPublic: true) == implementingMethod2);
					if (eventInfo == null)
					{
						throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.SetupNotEventRemove, part.Expression));
					}
				}
				if (mock.EventHandlers.TryGet(eventInfo, out Delegate handlers))
				{
					Type returnType = handlers.GetMethodInfo().ReturnType;
					if (returnType == typeof(Task) || returnType == typeof(ValueTask))
					{
						Delegate[] invocationList = handlers.GetInvocationList();
						List<Task> list = new List<Task>(invocationList.Length);
						Delegate[] array = invocationList;
						foreach (Delegate del in array)
						{
							object obj = del.InvokePreserveStack(arguments);
							if (obj is Task item)
							{
								list.Add(item);
							}
							else if (obj is ValueTask valueTask)
							{
								list.Add(valueTask.AsTask());
							}
						}
						return Task.WhenAll(list);
					}
					return handlers.InvokePreserveStack(arguments);
				}
			}
			else
			{
				Mock mock2 = mock.MutableSetups.FindLastInnerMock((Setup setup) => setup.Matches(part));
				if (mock2 != null)
				{
					return RaiseEvent(mock2, expression, parts, arguments);
				}
			}
			return null;
		}

		public abstract Mock<TInterface> As<TInterface>() where TInterface : class;

		internal bool ImplementsInterface(Type interfaceType)
		{
			if (!InheritedInterfaces.Contains<Type>(interfaceType))
			{
				return AdditionalInterfaces.Contains(interfaceType);
			}
			return true;
		}

		public void SetReturnsDefault<TReturn>(TReturn value)
		{
			ConfiguredDefaultValues[typeof(TReturn)] = value;
		}

		internal object GetDefaultValue(MethodInfo method, out Mock candidateInnerMock, DefaultValueProvider useAlternateProvider = null)
		{
			if (ConfiguredDefaultValues.TryGetValue(method.ReturnType, out object value))
			{
				candidateInnerMock = null;
				return value;
			}
			object defaultReturnValue = (useAlternateProvider ?? DefaultValueProvider).GetDefaultReturnValue(method, this);
			object obj = Awaitable.TryGetResultRecursive(defaultReturnValue);
			candidateInnerMock = (obj as IMocked)?.Mock;
			return defaultReturnValue;
		}

		Type IFluentInterface.GetType()
		{
			return GetType();
		}
	}
	public class Mock<T> : Mock, IMock<T> where T : class
	{
		private static Type[] inheritedInterfaces;

		private static int serialNumberCounter;

		private T instance;

		private List<Type> additionalInterfaces;

		private Dictionary<Type, object> configuredDefaultValues;

		private object[] constructorArguments;

		private DefaultValueProvider defaultValueProvider;

		private EventHandlerCollection eventHandlers;

		private InvocationCollection invocations;

		private string name;

		private SetupCollection setups;

		private MockBehavior behavior;

		private bool callBase;

		private Switches switches;

		public override MockBehavior Behavior => behavior;

		public override bool CallBase
		{
			get
			{
				return callBase;
			}
			set
			{
				if (value && MockedType.IsDelegateType())
				{
					throw new NotSupportedException(Resources.CallBaseCannotBeUsedWithDelegateMocks);
				}
				callBase = value;
			}
		}

		internal override object[] ConstructorArguments => constructorArguments;

		internal override Dictionary<Type, object> ConfiguredDefaultValues => configuredDefaultValues;

		public override DefaultValueProvider DefaultValueProvider
		{
			get
			{
				return defaultValueProvider;
			}
			set
			{
				defaultValueProvider = value ?? throw new ArgumentNullException("value");
			}
		}

		internal override EventHandlerCollection EventHandlers => eventHandlers;

		internal override List<Type> AdditionalInterfaces => additionalInterfaces;

		internal override InvocationCollection MutableInvocations => invocations;

		internal override bool IsObjectInitialized => instance != null;

		public new virtual T Object => (T)base.Object;

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		internal override Type MockedType => typeof(T);

		internal override SetupCollection MutableSetups => setups;

		internal override Type[] InheritedInterfaces => inheritedInterfaces;

		public override Switches Switches
		{
			get
			{
				return switches;
			}
			set
			{
				switches = value;
			}
		}

		static Mock()
		{
			inheritedInterfaces = (from i in typeof(T).GetInterfaces()
				where ProxyFactory.Instance.IsTypeVisible(i) && !i.IsImport
				select i).ToArray();
			serialNumberCounter = 0;
		}

		internal Mock(bool skipInitialize)
		{
		}

		public Mock()
			: this(MockBehavior.Loose)
		{
		}

		public Mock(params object[] args)
			: this(MockBehavior.Loose, args)
		{
		}

		public Mock(MockBehavior behavior)
			: this(behavior, new object[0])
		{
		}

		public Mock(MockBehavior behavior, params object[] args)
		{
			Guard.IsMockable(typeof(T));
			if (args == null)
			{
				args = new object[1];
			}
			additionalInterfaces = new List<Type>();
			this.behavior = behavior;
			configuredDefaultValues = new Dictionary<Type, object>();
			constructorArguments = args;
			defaultValueProvider = Moq.DefaultValueProvider.Empty;
			eventHandlers = new EventHandlerCollection();
			invocations = new InvocationCollection(this);
			name = CreateUniqueDefaultMockName();
			setups = new SetupCollection();
			switches = Switches.Default;
			CheckParameters();
		}

		public Mock(Expression<Func<T>> newExpression, MockBehavior behavior = MockBehavior.Loose)
			: this(behavior, ConstructorCallVisitor.ExtractArgumentValues(newExpression))
		{
		}

		private static string CreateUniqueDefaultMockName()
		{
			int value = Interlocked.Increment(ref serialNumberCounter);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Mock<").AppendNameOf(typeof(T)).Append(':')
				.Append(value)
				.Append('>');
			return stringBuilder.ToString();
		}

		private void CheckParameters()
		{
			if (constructorArguments.Length != 0)
			{
				if (typeof(T).IsInterface)
				{
					throw new ArgumentException(Resources.ConstructorArgsForInterface);
				}
				if (typeof(T).IsDelegateType())
				{
					throw new ArgumentException(Resources.ConstructorArgsForDelegate);
				}
			}
		}

		public override string ToString()
		{
			return Name;
		}

		private void InitializeInstance()
		{
			int count = AdditionalInterfaces.Count;
			Type[] array = new Type[1 + count];
			array[0] = typeof(IMocked<T>);
			AdditionalInterfaces.CopyTo(0, array, 1, count);
			instance = (T)ProxyFactory.Instance.CreateProxy(typeof(T), this, array, constructorArguments);
		}

		protected override object OnGetObject()
		{
			if (instance == null)
			{
				InitializeInstance();
			}
			return instance;
		}

		public override Mock<TInterface> As<TInterface>()
		{
			Type typeFromHandle = typeof(TInterface);
			if (!typeFromHandle.IsInterface)
			{
				throw new ArgumentException(Resources.AsMustBeInterface);
			}
			if (typeof(TInterface) == typeof(T))
			{
				return (Mock<TInterface>)(object)this;
			}
			if (IsObjectInitialized && !ImplementsInterface(typeFromHandle))
			{
				throw new InvalidOperationException(Resources.AlreadyInitialized);
			}
			if (!AdditionalInterfaces.Contains(typeFromHandle))
			{
				AdditionalInterfaces.Add(typeFromHandle);
			}
			return new AsInterface<TInterface>(this);
		}

		public ISetup<T> Setup(Expression<Action<T>> expression)
		{
			MethodCall setup = Mock.Setup(this, expression, null);
			return new VoidSetupPhrase<T>(setup);
		}

		public ISetup<T, TResult> Setup<TResult>(Expression<Func<T, TResult>> expression)
		{
			MethodCall setup = Mock.Setup(this, expression, null);
			return new NonVoidSetupPhrase<T, TResult>(setup);
		}

		public ISetupGetter<T, TProperty> SetupGet<TProperty>(Expression<Func<T, TProperty>> expression)
		{
			MethodCall setup = Mock.SetupGet(this, expression, null);
			return new NonVoidSetupPhrase<T, TProperty>(setup);
		}

		public ISetupSetter<T, TProperty> SetupSet<TProperty>(Action<T> setterExpression)
		{
			Guard.NotNull(setterExpression, "setterExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(setterExpression, ConstructorArguments);
			MethodCall setup = Mock.SetupSet(this, expression, null);
			return new SetterSetupPhrase<T, TProperty>(setup);
		}

		public ISetup<T> SetupSet(Action<T> setterExpression)
		{
			Guard.NotNull(setterExpression, "setterExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(setterExpression, ConstructorArguments);
			MethodCall setup = Mock.SetupSet(this, expression, null);
			return new VoidSetupPhrase<T>(setup);
		}

		public ISetup<T> SetupAdd(Action<T> addExpression)
		{
			Guard.NotNull(addExpression, "addExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(addExpression, ConstructorArguments);
			MethodCall setup = Mock.SetupAdd(this, expression, null);
			return new VoidSetupPhrase<T>(setup);
		}

		public ISetup<T> SetupRemove(Action<T> removeExpression)
		{
			Guard.NotNull(removeExpression, "removeExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(removeExpression, ConstructorArguments);
			MethodCall setup = Mock.SetupRemove(this, expression, null);
			return new VoidSetupPhrase<T>(setup);
		}

		public Mock<T> SetupProperty<TProperty>(Expression<Func<T, TProperty>> property)
		{
			return SetupProperty(property, default(TProperty));
		}

		public Mock<T> SetupProperty<TProperty>(Expression<Func<T, TProperty>> property, TProperty initialValue)
		{
			Mock.SetupProperty(this, property, initialValue);
			return this;
		}

		public Mock<T> SetupAllProperties()
		{
			Mock.SetupAllProperties(this);
			return this;
		}

		public ISetupSequentialResult<TResult> SetupSequence<TResult>(Expression<Func<T, TResult>> expression)
		{
			SequenceSetup setup = Mock.SetupSequence(this, expression);
			return new SetupSequencePhrase<TResult>(setup);
		}

		public ISetupSequentialAction SetupSequence(Expression<Action<T>> expression)
		{
			SequenceSetup setup = Mock.SetupSequence(this, expression);
			return new SetupSequencePhrase(setup);
		}

		public ISetupConditionResult<T> When(Func<bool> condition)
		{
			return new WhenPhrase<T>(this, new Condition(condition));
		}

		public void Verify(Expression<Action<T>> expression)
		{
			Mock.Verify(this, expression, Times.AtLeastOnce(), null);
		}

		public void Verify(Expression<Action<T>> expression, Times times)
		{
			Mock.Verify(this, expression, times, null);
		}

		public void Verify(Expression<Action<T>> expression, Func<Times> times)
		{
			Verify(expression, times());
		}

		public void Verify(Expression<Action<T>> expression, string failMessage)
		{
			Mock.Verify(this, expression, Times.AtLeastOnce(), failMessage);
		}

		public void Verify(Expression<Action<T>> expression, Times times, string failMessage)
		{
			Mock.Verify(this, expression, times, failMessage);
		}

		public void Verify(Expression<Action<T>> expression, Func<Times> times, string failMessage)
		{
			Mock.Verify(this, expression, times(), failMessage);
		}

		public void Verify<TResult>(Expression<Func<T, TResult>> expression)
		{
			Mock.Verify(this, expression, Times.AtLeastOnce(), null);
		}

		public void Verify<TResult>(Expression<Func<T, TResult>> expression, Times times)
		{
			Mock.Verify(this, expression, times, null);
		}

		public void Verify<TResult>(Expression<Func<T, TResult>> expression, Func<Times> times)
		{
			Mock.Verify(this, expression, times(), null);
		}

		public void Verify<TResult>(Expression<Func<T, TResult>> expression, string failMessage)
		{
			Mock.Verify(this, expression, Times.AtLeastOnce(), failMessage);
		}

		public void Verify<TResult>(Expression<Func<T, TResult>> expression, Times times, string failMessage)
		{
			Mock.Verify(this, expression, times, failMessage);
		}

		public void VerifyGet<TProperty>(Expression<Func<T, TProperty>> expression)
		{
			Mock.VerifyGet(this, expression, Times.AtLeastOnce(), null);
		}

		public void VerifyGet<TProperty>(Expression<Func<T, TProperty>> expression, Times times)
		{
			Mock.VerifyGet(this, expression, times, null);
		}

		public void VerifyGet<TProperty>(Expression<Func<T, TProperty>> expression, Func<Times> times)
		{
			Mock.VerifyGet(this, expression, times(), null);
		}

		public void VerifyGet<TProperty>(Expression<Func<T, TProperty>> expression, string failMessage)
		{
			Mock.VerifyGet(this, expression, Times.AtLeastOnce(), failMessage);
		}

		public void VerifyGet<TProperty>(Expression<Func<T, TProperty>> expression, Times times, string failMessage)
		{
			Mock.VerifyGet(this, expression, times, failMessage);
		}

		public void VerifyGet<TProperty>(Expression<Func<T, TProperty>> expression, Func<Times> times, string failMessage)
		{
			Mock.VerifyGet(this, expression, times(), failMessage);
		}

		public void VerifySet(Action<T> setterExpression)
		{
			Guard.NotNull(setterExpression, "setterExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(setterExpression, ConstructorArguments);
			Mock.VerifySet(this, expression, Times.AtLeastOnce(), null);
		}

		public void VerifySet(Action<T> setterExpression, Times times)
		{
			Guard.NotNull(setterExpression, "setterExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(setterExpression, ConstructorArguments);
			Mock.VerifySet(this, expression, times, null);
		}

		public void VerifySet(Action<T> setterExpression, Func<Times> times)
		{
			Guard.NotNull(setterExpression, "setterExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(setterExpression, ConstructorArguments);
			Mock.VerifySet(this, expression, times(), null);
		}

		public void VerifySet(Action<T> setterExpression, string failMessage)
		{
			Guard.NotNull(setterExpression, "setterExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(setterExpression, ConstructorArguments);
			Mock.VerifySet(this, expression, Times.AtLeastOnce(), failMessage);
		}

		public void VerifySet(Action<T> setterExpression, Times times, string failMessage)
		{
			Guard.NotNull(setterExpression, "setterExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(setterExpression, ConstructorArguments);
			Mock.VerifySet(this, expression, times, failMessage);
		}

		public void VerifySet(Action<T> setterExpression, Func<Times> times, string failMessage)
		{
			Guard.NotNull(setterExpression, "setterExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(setterExpression, ConstructorArguments);
			Mock.VerifySet(this, expression, times(), failMessage);
		}

		public void VerifyAdd(Action<T> addExpression)
		{
			Guard.NotNull(addExpression, "addExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(addExpression, ConstructorArguments);
			Mock.VerifyAdd(this, expression, Times.AtLeastOnce(), null);
		}

		public void VerifyAdd(Action<T> addExpression, Times times)
		{
			Guard.NotNull(addExpression, "addExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(addExpression, ConstructorArguments);
			Mock.VerifyAdd(this, expression, times, null);
		}

		public void VerifyAdd(Action<T> addExpression, Func<Times> times)
		{
			Guard.NotNull(addExpression, "addExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(addExpression, ConstructorArguments);
			Mock.VerifyAdd(this, expression, times(), null);
		}

		public void VerifyAdd(Action<T> addExpression, string failMessage)
		{
			Guard.NotNull(addExpression, "addExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(addExpression, ConstructorArguments);
			Mock.VerifyAdd(this, expression, Times.AtLeastOnce(), failMessage);
		}

		public void VerifyAdd(Action<T> addExpression, Times times, string failMessage)
		{
			Guard.NotNull(addExpression, "addExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(addExpression, ConstructorArguments);
			Mock.VerifyAdd(this, expression, times, failMessage);
		}

		public void VerifyAdd(Action<T> addExpression, Func<Times> times, string failMessage)
		{
			Guard.NotNull(addExpression, "addExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(addExpression, ConstructorArguments);
			Mock.VerifyAdd(this, expression, times(), failMessage);
		}

		public void VerifyRemove(Action<T> removeExpression)
		{
			Guard.NotNull(removeExpression, "removeExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(removeExpression, ConstructorArguments);
			Mock.VerifyRemove(this, expression, Times.AtLeastOnce(), null);
		}

		public void VerifyRemove(Action<T> removeExpression, Times times)
		{
			Guard.NotNull(removeExpression, "removeExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(removeExpression, ConstructorArguments);
			Mock.VerifyRemove(this, expression, times, null);
		}

		public void VerifyRemove(Action<T> removeExpression, Func<Times> times)
		{
			Guard.NotNull(removeExpression, "removeExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(removeExpression, ConstructorArguments);
			Mock.VerifyRemove(this, expression, times(), null);
		}

		public void VerifyRemove(Action<T> removeExpression, string failMessage)
		{
			Guard.NotNull(removeExpression, "removeExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(removeExpression, ConstructorArguments);
			Mock.VerifyRemove(this, expression, Times.AtLeastOnce(), failMessage);
		}

		public void VerifyRemove(Action<T> removeExpression, Times times, string failMessage)
		{
			Guard.NotNull(removeExpression, "removeExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(removeExpression, ConstructorArguments);
			Mock.VerifyRemove(this, expression, times, failMessage);
		}

		public void VerifyRemove(Action<T> removeExpression, Func<Times> times, string failMessage)
		{
			Guard.NotNull(removeExpression, "removeExpression");
			Expression<Action<T>> expression = ExpressionReconstructor.Instance.ReconstructExpression(removeExpression, ConstructorArguments);
			Mock.VerifyRemove(this, expression, times(), failMessage);
		}

		public void VerifyNoOtherCalls()
		{
			Mock.VerifyNoOtherCalls(this);
		}

		public void Raise(Action<T> eventExpression, EventArgs args)
		{
			Mock.RaiseEvent(this, eventExpression, new object[2] { Object, args });
		}

		public void Raise(Action<T> eventExpression, params object[] args)
		{
			Mock.RaiseEvent(this, eventExpression, args);
		}

		public Task RaiseAsync(Action<T> eventExpression, params object[] args)
		{
			return Mock.RaiseEventAsync(this, eventExpression, args);
		}

		[Obsolete("Expect has been renamed to Setup.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ISetup<T> Expect(Expression<Action<T>> expression)
		{
			return Setup(expression);
		}

		[Obsolete("Expect has been renamed to Setup.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ISetup<T, TResult> Expect<TResult>(Expression<Func<T, TResult>> expression)
		{
			return Setup(expression);
		}

		[Obsolete("ExpectGet has been renamed to SetupGet.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ISetupGetter<T, TProperty> ExpectGet<TProperty>(Expression<Func<T, TProperty>> expression)
		{
			return SetupGet(expression);
		}

		[Obsolete("ExpectSet has been renamed to SetupSet.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ISetupSetter<T, TProperty> ExpectSet<TProperty>(Expression<Func<T, TProperty>> expression)
		{
			return this.SetupSet(expression);
		}

		[Obsolete("ExpectSet has been renamed to SetupSet, and the new syntax allows you to pass the value in the expression itself, like f => f.Value = 25.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ISetupSetter<T, TProperty> ExpectSet<TProperty>(Expression<Func<T, TProperty>> expression, TProperty value)
		{
			throw new NotSupportedException();
		}
	}
}
